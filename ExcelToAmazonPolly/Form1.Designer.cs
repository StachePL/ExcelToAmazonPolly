namespace ExcelToAmazonPolly
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_open = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_folder = new System.Windows.Forms.Button();
            this.lbl_folder = new System.Windows.Forms.Label();
            this.btn_generate = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lbl_url = new System.Windows.Forms.LinkLabel();
            this.comboBoxFormat = new System.Windows.Forms.ComboBox();
            this.checkBoxSSML = new System.Windows.Forms.CheckBox();
            this.lbl_Status = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.LexiconsB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_open
            // 
            this.btn_open.Location = new System.Drawing.Point(12, 12);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(75, 23);
            this.btn_open.TabIndex = 0;
            this.btn_open.Text = "Load XLS";
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(863, 463);
            this.dataGridView1.TabIndex = 2;
            // 
            // btn_folder
            // 
            this.btn_folder.Location = new System.Drawing.Point(93, 12);
            this.btn_folder.Name = "btn_folder";
            this.btn_folder.Size = new System.Drawing.Size(75, 23);
            this.btn_folder.TabIndex = 3;
            this.btn_folder.Text = "S. Folder";
            this.btn_folder.UseVisualStyleBackColor = true;
            this.btn_folder.Click += new System.EventHandler(this.btn_folder_Click);
            // 
            // lbl_folder
            // 
            this.lbl_folder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_folder.Location = new System.Drawing.Point(174, 17);
            this.lbl_folder.MinimumSize = new System.Drawing.Size(0, 14);
            this.lbl_folder.Name = "lbl_folder";
            this.lbl_folder.Size = new System.Drawing.Size(404, 14);
            this.lbl_folder.TabIndex = 4;
            this.lbl_folder.Text = "Output folder: C:\\VoiceOutput";
            this.toolTip1.SetToolTip(this.lbl_folder, "Click to open folder.");
            this.lbl_folder.Click += new System.EventHandler(this.lbl_folder_Click);
            // 
            // btn_generate
            // 
            this.btn_generate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_generate.Location = new System.Drawing.Point(800, 12);
            this.btn_generate.Name = "btn_generate";
            this.btn_generate.Size = new System.Drawing.Size(75, 23);
            this.btn_generate.TabIndex = 5;
            this.btn_generate.Text = "Generate VO";
            this.btn_generate.UseVisualStyleBackColor = true;
            this.btn_generate.Click += new System.EventHandler(this.btn_generate_Click);
            // 
            // lbl_url
            // 
            this.lbl_url.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_url.AutoSize = true;
            this.lbl_url.Cursor = System.Windows.Forms.Cursors.Help;
            this.lbl_url.Location = new System.Drawing.Point(624, 507);
            this.lbl_url.Name = "lbl_url";
            this.lbl_url.Size = new System.Drawing.Size(251, 13);
            this.lbl_url.TabIndex = 8;
            this.lbl_url.TabStop = true;
            this.lbl_url.Text = "https://github.com/StachePL/ExcelToAmazonPolly";
            this.toolTip1.SetToolTip(this.lbl_url, "Go to Readme on GitHub");
            this.lbl_url.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl_url_LinkClicked);
            // 
            // comboBoxFormat
            // 
            this.comboBoxFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxFormat.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxFormat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxFormat.Items.AddRange(new object[] {
            "Json",
            "Mp3",
            "Ogg_vorbis",
            "Pcm"});
            this.comboBoxFormat.Location = new System.Drawing.Point(673, 12);
            this.comboBoxFormat.Name = "comboBoxFormat";
            this.comboBoxFormat.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFormat.TabIndex = 9;
            this.comboBoxFormat.Text = "Ogg_vorbis";
            this.toolTip1.SetToolTip(this.comboBoxFormat, "Output file format");
            // 
            // checkBoxSSML
            // 
            this.checkBoxSSML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxSSML.AutoSize = true;
            this.checkBoxSSML.Location = new System.Drawing.Point(612, 16);
            this.checkBoxSSML.Name = "checkBoxSSML";
            this.checkBoxSSML.Size = new System.Drawing.Size(55, 17);
            this.checkBoxSSML.TabIndex = 10;
            this.checkBoxSSML.Text = "SSML";
            this.toolTip1.SetToolTip(this.checkBoxSSML, "Check if using SSML format for the input text");
            this.checkBoxSSML.UseVisualStyleBackColor = true;
            // 
            // lbl_Status
            // 
            this.lbl_Status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Status.Location = new System.Drawing.Point(12, 507);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(746, 13);
            this.lbl_Status.TabIndex = 6;
            this.lbl_Status.Text = "Load XLS file to begin";
            // 
            // LexiconsB
            // 
            this.LexiconsB.Location = new System.Drawing.Point(584, 12);
            this.LexiconsB.Name = "LexiconsB";
            this.LexiconsB.Size = new System.Drawing.Size(22, 23);
            this.LexiconsB.TabIndex = 11;
            this.LexiconsB.Text = "L";
            this.toolTip1.SetToolTip(this.LexiconsB, "Show available lexicons list");
            this.LexiconsB.UseVisualStyleBackColor = true;
            this.LexiconsB.Click += new System.EventHandler(this.LexiconsB_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 529);
            this.Controls.Add(this.LexiconsB);
            this.Controls.Add(this.checkBoxSSML);
            this.Controls.Add(this.comboBoxFormat);
            this.Controls.Add(this.lbl_url);
            this.Controls.Add(this.lbl_Status);
            this.Controls.Add(this.btn_generate);
            this.Controls.Add(this.lbl_folder);
            this.Controls.Add(this.btn_folder);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_open);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Excel to Amazon Polly";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_folder;
        private System.Windows.Forms.Label lbl_folder;
        private System.Windows.Forms.Button btn_generate;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lbl_Status;
        private System.Windows.Forms.LinkLabel lbl_url;
        private System.Windows.Forms.ComboBox comboBoxFormat;
        private System.Windows.Forms.CheckBox checkBoxSSML;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button LexiconsB;
    }
}

