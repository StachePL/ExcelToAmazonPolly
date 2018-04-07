using Amazon;
using Amazon.Polly;
using Amazon.Polly.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelToAmazonPolly
{
    public partial class Form1 : Form
    {
        private string _outputFolder = @"C:\VoiceOutput";
        private string _awsID = @Properties.Settings.Default.awsID;
        private string _awsSecret = @Properties.Settings.Default.awsKey;
        private string _region = @Properties.Settings.Default.awsRegion;
        private bool initialized = false;
        private AmazonPollyClient _pc;
        private string _fileFormat = "Ogg_vorbis"; // json | mp3 | ogg_vorbis | pcm
        private List<string> lexiconsList = new List<string>();


        public Form1()
        {
            InitializeComponent();
            Start();
        }

        void Start()
        {
            toolTip1.SetToolTip(btn_folder, "Select output folder");
            toolTip1.SetToolTip(btn_generate, "Generate voiceovers in selected folder");
            toolTip1.SetToolTip(btn_open, "Choose Excel file to open");
        }

        //Loading data from excel to DataTable and displaying it
        private void btn_open_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            string fileExt = string.Empty;
            OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file  
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK) //if there is a file choosen by the user  
            {
                filePath = file.FileName; //get the path of the file  
                fileExt = Path.GetExtension(filePath); //get the file extension  
                if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                {
                    try
                    {
                        DataTable dtExcel = new DataTable();
                        dtExcel = ReadExcel(filePath, fileExt); //read excel file  
                        dataGridView1.Visible = true;
                        dataGridView1.DataSource = dtExcel;

                        dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                    lbl_Status.ForeColor = Color.Green;
                    lbl_Status.Text = "Loaded Spreadsheet";
                }
                else
                {
                    MessageBox.Show("Please choose .xls or .xlsx file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error  
                }
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close(); //to close the window(Form1)  
        }

        private void btn_folder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    _outputFolder = fbd.SelectedPath;
                }
            }

            lbl_folder.Text = "Output folder: " + _outputFolder;
            toolTip1.SetToolTip(lbl_folder, "Click to open folder: " + _outputFolder);
        }

        private void lbl_url_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/StachePL/ExcelToAmazonPolly");
        }

        private void lbl_folder_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(_outputFolder))
            {
                System.Diagnostics.Process.Start(@_outputFolder);
            }
        }
        private void btn_generate_Click(object sender, EventArgs e)
        {

            if (!RefreshConnection())
                return;

            if (_pc != null)
            {
                GenerateVoiceFromDatatable((DataTable)dataGridView1.DataSource);
            }

        }

        private void LexiconsB_Click(object sender, EventArgs e)
        {
            ShowLexiconsList();
        }

        //Helper function to load data from excel, thanks to http://www.c-sharpcorner.com/members/harminder-singh8 
        public DataTable ReadExcel(string fileName, string fileExt)
        {
            string conn = string.Empty;
            DataTable dtexcel = new DataTable();
            if (fileExt.CompareTo(".xls") == 0)
                conn = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';"; //for below excel 2007  
            else
                conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=NO';"; //for above excel 2007  
            using (OleDbConnection con = new OleDbConnection(conn))
            {
                try
                {
                    OleDbDataAdapter oleAdpt = new OleDbDataAdapter("select * from [Sheet1$]", con); //here we read data from sheet1  
                    oleAdpt.Fill(dtexcel); //fill excel data into dataTable  
                }
                catch { }
            }
            return dtexcel;
        }

        bool RefreshConnection()
        {
            if (_pc != null)
                return true;

            //Refresh properties
            Properties.Settings.Default.Reload();
            _awsID = @Properties.Settings.Default.awsID;
            _awsSecret = @Properties.Settings.Default.awsKey;
            _region = @Properties.Settings.Default.awsRegion;
            if (_awsID == "awsID" && _awsSecret == "awsKey")
            {
                MessageBox.Show("Please fill credentials in ExcelToAmazonPolly.exe.config\nto connect with Amazon Polly services.", "One more thing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); //custom messageBox to show error  
                return false;
            }
            else
            {
                InitializePolly(_awsID, _awsSecret, _region);
                return true;
            }
        }

        void InitializePolly(string awsID, string awsSecret, string region)
        {
            RegionEndpoint _region = RegionEndpoint.GetBySystemName(region);
            _pc = new AmazonPollyClient(awsID, awsSecret, _region);

            if (_pc != null)
            {
                initialized = true;
            }
        }

        bool SynthesizeSpeech(string filename, string line, string voice, List<string> lexiconNames)
        {
            try
            {
                SynthesizeSpeechRequest sreq = new SynthesizeSpeechRequest();
                sreq.Text = line;
                sreq.OutputFormat = _fileFormat;
                sreq.VoiceId = voice;

                if (lexiconNames != null)
                    sreq.LexiconNames = lexiconNames;
                
            if (checkBoxSSML.Checked)
                {
                    sreq.TextType = "SSML";
                }

                SynthesizeSpeechResponse sres = _pc.SynthesizeSpeech(sreq);

                using (var fileStream = File.Create(_outputFolder + @"\" + @filename))
                {
                    sres.AudioStream.CopyTo(fileStream);
                    fileStream.Flush();
                    fileStream.Close();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in: " + filename + "\n" +ex.Message, "Amazon Error");
                return false;
            }
            return true;
        }

        void GenerateVoiceFromDatatable(DataTable dtable)
        {
            if (Directory.Exists(_outputFolder)) {
                Cursor.Current = Cursors.WaitCursor;

                foreach (DataRow dataRow in dtable.Rows)
                {
                    lbl_Status.ForeColor = Color.Blue;
                    lbl_Status.Text = "Processing row: " + (dtable.Rows.IndexOf(dataRow)+1) +"/" + dtable.Rows.Count;
                    if (dataRow["Generate"] != DBNull.Value && Convert.ToBoolean(dataRow["Generate"]))
                    {
                        string file = dataRow.Field<string>("File");
                        string line = dataRow.Field<string>("Line");
                        string voice = dataRow.Field<string>("Voice");
                        string lexiconsString = dataRow.Field<string>("Lexicons");
                        List<string> lexicons = null;
                        if (lexiconsString != null)
                            lexicons = lexiconsString.Split(',').ToList();


                        if (!SynthesizeSpeech(file, line, voice, lexicons))
                        {
                            Cursor.Current = Cursors.Default;
                            lbl_Status.ForeColor = Color.Red;
                            lbl_Status.Text = "Error ocurred!";
                            break;
                        }
                    }
                }

                Cursor.Current = Cursors.Default;
                MessageBox.Show("Generation finished!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); //custom messageBox to show error  
            }
            else
            {
                MessageBox.Show("Output folder does not exist.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error  
                lbl_Status.ForeColor = Color.Red;
                lbl_Status.Text = "Output folder does not exist!";
            }
        }

        void ShowLexiconsList()
        {
            
            if (!RefreshConnection())
                return;

            List<LexiconDescription> lexicons = new List<LexiconDescription>();

            try { 
                lexiconsList.Clear();
                
                ListLexiconsRequest req = new ListLexiconsRequest();
                ListLexiconsResponse llr = _pc.ListLexicons(req);
                lexicons = llr.Lexicons;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
                return;
            }

            foreach (LexiconDescription ld in lexicons)
            {
                string lexName = ld.Name;
                lexiconsList.Add(lexName);
            }

            string joinedList ="Lexicons: \n\n" + string.Join("\n", lexiconsList);
            joinedList += "\n\n\n Would you like to go to Amazon Console to manage lexicons?";
            if (MessageBox.Show(joinedList, "Available Lexicons", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
            System.Diagnostics.Process.Start("http://" +_region +".console.aws.amazon.com/polly/home/Lexicons");
            }




        }


    }

}
