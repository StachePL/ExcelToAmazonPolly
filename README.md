# ExcelToAmazonPolly
[![GitHub release](https://img.shields.io/github/release/StachePL/ExcelToAmazonPolly.svg)]() [![Github All Releases](https://img.shields.io/github/downloads/StachePL/ExcelToAmazonPolly/ExcelToAmazonPolly.zip.svg)]() [![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://raw.githubusercontent.com/SpoinkyNL/Artemis/master/LICENSE) [![GitHub stars](https://img.shields.io/github/stars/StachePL/ExcelToAmazonPolly.svg)](https://github.com/SpoinkyNL/Artemis/stargazers)

ExcelToAmazonPolly is a simple tool I made for faster prototyping in gamedev. It allows user to generate a pack of human-like speech files from an Excel spreadsheet with usage of [Amazon Polly](http://docs.aws.amazon.com/polly/latest/dg/how-text-to-speech-works.html) text to speech service. Keep your voice lines in one excel file, re-generate only the ones that changed! The code is pretty straight forward and easy to reproduce.
Amazon Polly FAQ: https://aws.amazon.com/polly/faqs/

**Why should I use it?** - You may ask.
First: Amazon Polly free quota is quite big and it's very fast to iterate all those guard_hello_03.ogg files with it.
**Download**: https://github.com/StachePL/ExcelToAmazonPolly/releases/

### Features
 - Loads xls file with predefined columns structure
 - Using Amazon Polly generates audio files and stores them in selected folder
 - Reloading credentials on the fly (in case user typed something wrong in config file)

### How to use it?
##### Initial Setup
 - First of all you'll need an Amazon AWS account. You can get it here: https://aws.amazon.com/
 - Then you'll need generated key and secret for the purpose of this app. It'll need only access to Amazon Polly.  Instructions here: http://docs.aws.amazon.com/general/latest/gr/managing-aws-access-keys.html 
 - Fill the **ExcelToAmazonPolly.exe.config** file with your credentials. Follow the pre-filled pattern for the region field.

##### Preparing the list of voice lines
Copy the **_voicelist_example.xls** file and fill it with all the voice lines you need. Mind there are some limits from the Amazon
List of all available voices and languages: http://docs.aws.amazon.com/polly/latest/dg/voicelist.html
For more advanced uses the SSML (Speech Synthesis Markup Language) reference : http://docs.aws.amazon.com/polly/latest/dg/ssml.html
##### Actually launching the app
 1. Load the xls file, after loading it should look something like this: ![Loaded file](https://i.imgur.com/oDdT39J.png)
 2. Select output folder
 3. Check all the voice lines you wish to generate (if you didn't in the xls file)
 4. Click Generate and enjoy!

### Additional info
##### Known issues
 - Please use *.xls files instead of *.xlsx as there are some problems with Microsoft.Office.Interop.Excel package for Office 2016
 - It may hang/crash when internet connection is lost (it's not bulletproof)

##### Plans
 - Add lexicons support
 - Make it more forgiving to the user
 - Clean the code
 - Make it cooler
 
In case you enjoy the tool and would like to add something, feel free to send a pull requests, or create an issue with suggestions.


