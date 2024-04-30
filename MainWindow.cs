using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
namespace LightningNote
{


    public partial class MainWindow : Form
    {
        #region richtext hacky

        #endregion

        #region tools that need this class
        /// <summary>
        /// If a save folder is set, choose that, otherwise default to mydocs
        /// </summary>
        /// <returns></returns>
        string GetUserSaveFolder()
        {
            if (SaveState != null)
            {
                if (SaveState.PreferredSaveLocation != null)
                {
                    if (Directory.Exists(SaveState.PreferredSaveLocation))
                    {
                        return SaveState.PreferredSaveLocation;
                    }
                }
            }
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }
        #endregion

        /// <summary>
        /// This holds our save state for user preferences.
        /// Design flow is json this to appdata and back.
        /// The individual flags in the main Class such as FlagTopMost are set on load which triggers the approprate
        /// setting and updates the flag in the menu system.
        /// </summary>
        class MainWindowFlagState
        {
            /// <summary>
            /// Flag matches to <see cref="autosaveOnShutdownLogoffToolStripMenuItem"/> state which controls if we save on shutdown
            /// </summary>
            public bool FlagSaveOnShutdown { get; set; }
            /// <summary>
            /// Flag matches to <see cref="topMostToolStripMenuItem"/> state which controls if we are above most other windows
            /// </summary>
            public bool FlagTopMost { get; set; }

            /// <summary>
            /// Flag matches <see cref="wordWrapToolStripMenuItem"/> state which controls if richtextbox is wordwrap on or off
            /// </summary>
            public bool FlagWordWrap { get; set; }
            /// <summary>
            /// flag matches <see cref="transparentToolStripMenuItem"/> state which cointrols if the main window is transparent
            /// </summary>
            public bool FlagSeeThru { get; set; }

            /// <summary>
            /// not implemented yet: flag to corospond to state if enabled, we override user's wordwrap preference with file if files >= 2MB
            /// </summary>
            public bool FlagSkipBigWordWrap { get; set; }

            /// <summary>
            /// not implemented yet: controls the size in which we disable word wrap
            /// </summary>
            public uint MinToTriggerSkipWordWrap { get; set; } = 2 * 1024 * 1024;

            /// <summary>
            /// if set replaces the user's my documents folder
            /// </summary>
            public string? PreferredSaveLocation { get; set; }

            /// <summary>
            /// this is the font we replace everything with if we flatten RTF format control
            /// </summary>
            public Font? FlattonFont { get; set; }

            /// <summary>
            /// This is the background color we replace everything with if we flatten the RTF format
            /// </summary>
            public Color FlattonFontFront { get; set; } = Color.White;

            /// <summary>
            /// This is the font color we replace everything with if we flatten the RTF format
            /// </summary>
            public Color FlattonFontBack { get; set; }

            /// <summary>
            /// make an instace of our flag based of a previous saved JSON stream. Returns null if something goes wrong
            /// </summary>
            /// <param name="settings">stream to source from</param>
            /// <returns>returns null if failure happens or an instance of the class based off the json in it.</returns>
            public static MainWindowFlagState? FetchSettings(Stream settings)
            {
                MainWindowFlagState? ret;
                try
                {
                    ret = JsonSerializer.Deserialize<MainWindowFlagState>(settings);
                }
                catch (JsonException)
                {
                    return null;
                }
                return ret;
            }

            /// <summary>
            /// make an instace of our flag based of a previous saved JSON stream. Returns null if something goes wrong
            /// </summary>
            /// <param name="FileName">File to source from</param>
            /// <returns>returns null if failure happens or an instance of the class based off the json in it.</returns>
            public static MainWindowFlagState? FetchSettings(string FileName)
            {
                try
                {
                    using (Stream fn = File.OpenRead(FileName))
                    {
                        return FetchSettings(fn);
                    }
                }
                catch (IOException)
                {
                    return null;
                }
            }

            /// <summary>
            /// Save this instance of the settings to a stream located at output
            /// </summary>
            /// <param name="Output">where to save</param>
            /// <param name="settings">settings to save</param>
            public static void SaveSettings(Stream Output, MainWindowFlagState settings)
            {
                JsonSerializer.Serialize(Output, settings);
            }
            /// <summary>
            /// save this instance of the settings to this file
            /// </summary>
            /// <param name="FileName">file to save at</param>
            /// <param name="settings">settings to save</param>
            /// <exception cref="IOException">Varients of this can occure if the file is not accessable/writeable ect....</exception>
            public static void SaveSettings(String FileName, MainWindowFlagState settings)
            {
                using Stream fn = File.OpenWrite(FileName);
                fn.SetLength(0);
                SaveSettings(fn, settings);
            }

            /// <summary>
            /// save the current instance of this class to the passed stream
            /// </summary>
            /// <param name="output">stream to save</param>
            public void SaveSettings(Stream output)
            {
                SaveSettings(output, this);
            }

            /// <summary>
            /// save this instance of the settings to this file
            /// </summary>
            /// <param name="FileName">file to save at</param>
            /// <exception cref="IOException">Varients of this can occure if the file is not accessable/writeable ect....</exception>
            public void SaveSettings(string Filename)
            {
                SaveSettings(Filename, this);
            }

        }
        #region common dialog boxes
        readonly FontDialog commonFont = new();
        readonly OpenFileDialog commonOpen = new();
        readonly SaveFileDialog commonSave = new();
        readonly FindDialog commonFind = new();
        readonly GotoDialog commonGoto = new();
        #endregion

        #region save state

        /// <summary>
        /// %USER_APPLICATION_DATA%\\ProductName.cfg
        /// </summary>
        /// <returns></returns>
        string MakeUserConfigFileSave()
        {
            string p1 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (p1.Length > 0)
            {
                if (!p1.EndsWith("\\"))
                {
                    p1 += "\\";
                }
                p1 += Application.ProductName;
                p1 += Application.ProductVersion;
                p1 += ".cfg";
            }

            return p1;
        }

        /// <summary>
        /// save our config data to the usual place <see cref="MakeUserConfigFileSave"/>
        /// </summary>
        void SaveUserConfig()
        {
            try
            {
                MainWindowFlagState.SaveSettings(MakeUserConfigFileSave(), SaveState);
            }
            catch (IOException e)
            {
                MessageBox.Show($"There was an error saving to the config file at {MakeUserConfigFileSave()}. Your preferences won't be preserved. Error \"{e.Message}\"");
            }
        }

        /// <summary>
        ///  load our config data from the usual place <see cref="MakeUserConfigFileSave"/>. Use defaults and show error if error other than file not found happens
        /// </summary>
        void LoadUserConfig()
        {
            bool skip = false;
            object savestate = null;
            // play defensive, try loading the config file, revert
            // to default if there's an error.  Only alert user if there's an error other than file not found of the issue.
            try
            {
                savestate = MainWindowFlagState.FetchSettings(MakeUserConfigFileSave());
            }
            catch (FileNotFoundException)
            {
                skip = true;
            }
            catch (IOException)
            {
                MessageBox.Show($"Unable to load config file. Using default settings. Check if this app has access to read/write to {MakeUserConfigFileSave()}. Falling back to default settings.");
                skip = true;
            }

            MainWindowFlagState? test;
            if (skip)
            {
                test = new MainWindowFlagState();
            }
            else
            {
                test = savestate as MainWindowFlagState;
            }
            if (test != null)
            {
                // apply settings
                SaveState = test;
                FlagSaveOnShutdown = SaveState.FlagSaveOnShutdown;
                FlagTopMost = SaveState.FlagTopMost;
                FlagWordWrap = SaveState.FlagWordWrap;
                FlagDisableWordWrapBig = SaveState.FlagSkipBigWordWrap;
                FlagSeeThru = SaveState.FlagSeeThru;
                WantedFolder = SaveState.PreferredSaveLocation;
                if ((WantedFolder is null) || (Directory.Exists(WantedFolder) == false))
                {
                    WantedFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                }
            }
            else
            {
                MessageBox.Show($"Unable to load settings file located at {MakeUserConfigFileSave()} correctly. It may be corrupt.");
            }
        }
        MainWindowFlagState SaveState = new();
        bool FlagEnforceKeywordStuff = true;


        /// <summary>
        /// TODO: control if the app will save the current file if quitting turning a log off/shutdown
        /// </summary>
        /// <remarks> Setting this flag updates the <see cref="SaveState"/> as well as the the menu item <see cref="autosaveOnShutdownLogoffToolStripMenuItem"/></remarks>
        bool FlagSaveOnShutdown
        {
            get
            {
                return SaveState.FlagSaveOnShutdown;
            }
            set
            {
                SaveState.FlagSaveOnShutdown = autosaveOnShutdownLogoffToolStripMenuItem.Checked = value;
            }
        }

        /// <summary>
        /// Set if the window is topmost or not
        /// </summary>
        /// <remarks>updates the <see cref="SaveState"/> as well as the <see cref="topMostToolStripMenuItem"/> </remarks>
        bool FlagTopMost
        {
            get
            {
                return TopMost;
            }
            set
            {

                SaveState.FlagTopMost = TopMost = topMostToolStripMenuItem.Checked = value;
            }
        }

        /// <summary>
        /// Control if the wordwrap in the richtext box is active or not
        /// </summary>
        /// <remarks>Updates the <see cref="SaveState"/> as will as <see cref="RichTextBoxText"/> plus <see cref="wordWrapToolStripMenuItem"/></remarks>
        bool FlagWordWrap
        {
            get
            {
                return RichTextBoxText.WordWrap;
            }
            set
            {
                SaveState.FlagWordWrap = RichTextBoxText.WordWrap = wordWrapToolStripMenuItem.Checked = value;
            }
        }

        /// <summary>
        /// Control if we are skipping wordwrap for bit files
        /// </summary>
        /// <remarks>There is currently nothing beyond the <see cref="SaveState"/> to update</remarks>
        bool FlagDisableWordWrapBig
        {
            get
            {
                return SaveState.FlagSkipBigWordWrap;
            }
            set
            {
                SaveState.FlagSkipBigWordWrap = value;
            }
        }

        /// <summary>
        /// set if the main Window is transparent or not
        /// </summary>
        /// <remarks>Updates the <see cref="SaveState"/> plus <see cref="transparentToolStripMenuItem"/> as the Opacity of the main window</remarks>
        bool FlagSeeThru
        {
            get
            {
                return transparentToolStripMenuItem.Checked;
            }
            set
            {
                SaveState.FlagSeeThru = transparentToolStripMenuItem.Checked = value;
                if (transparentToolStripMenuItem.Checked)
                {
                    Opacity = 0.5;
                }
                else
                {
                    Opacity = 1;
                }

            }
        }

        /// <summary>
        /// set on when our textbox changes. Cleared on new file or open file, or save file
        /// </summary>
        bool FlagFileChanged = false;

        /// <summary>
        /// if null, default save/open is the user's my documents.
        /// </summary>
        string WantedFolder = null;

        /// <summary>
        /// default file name
        /// </summary>
        string FileName = "untitled.txt";
        /// <summary>
        /// null means no file loaded. otherwise this is the last loaded file.
        /// </summary>
        string? FileLocation = null;

        const int WM_QUERYENDSESSON = 0x011;
        const int WM_ENDSESSON = 0x16;

        string get_unique_filename(string loc, string start_name, string ext)
        {
            string test_me = Path.Combine(loc, start_name);
            while (true)
            {
                string rand_int = Random.Shared.Next(20000).ToString();
                string test_it = test_me + rand_int + ext;
                if (!File.Exists(test_it))
                {
                    return test_it;
                }
            }
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_QUERYENDSESSON)
            {
                if (autosaveOnShutdownLogoffToolStripMenuItem.Checked == true)
                {
                    FileLocation = get_unique_filename(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "shutdown_save", ".txt");
                    SaveUserFile(false);
                }
            }
            base.WndProc(ref m);
        }
        #endregion

        // actions a few code pathways converage too
        #region common actions
        string general_title = string.Empty;
        /// <summary>
        /// Update our mainWindow's title 
        /// </summary>
        /// <remarks>name - {file name} ** </remarks>
        void UpdateMainForm_Title()
        {
            string changed_icon;
            if (general_title == string.Empty)
            {
                general_title = this.Text;
            }
            if (FlagFileChanged)
                changed_icon = "**";
            else
                changed_icon = string.Empty;

            Text = string.Format(general_title, FileName, changed_icon);
        }
        /// <summary>
        /// Ask if the use wants to save changes?
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        DialogResult prompt_user_for_save_changed(string name)
        {
            return MessageBox.Show(string.Format("\"{0}\" has changed. Save  Changes?", FileName), "Save Changes?", MessageBoxButtons.YesNoCancel);
        }

        /// <summary>
        /// Reset to blank file
        /// </summary>
        void reset_to_new_file()
        {
            FileName = "untitled.txt";
            FileLocation = null;

            RichTextBoxText.Text = string.Empty;
            RichTextBoxText.ClearUndo();
            FlagFileChanged = false;
            UpdateMainForm_Title();
        }

        /// <remarks>
        /// if user never saved yet, show savefiledialog. STOP if user cancels.
        ///     call routine to save text.
        ///     Update
        /// </remarks>
        bool UserSelectNewFile()
        {
            bool ok = false;
            void CommonSave_FileOk(object? sender, System.ComponentModel.CancelEventArgs e)
            {
                ok = true;
                FileLocation = commonSave.FileName;
                this.FileName = Path.GetFileName(FileLocation);
            }
            commonSave.FileName = FileName;
            commonSave.AddExtension = true;
            commonSave.FilterIndex = 0;
            commonSave.InitialDirectory = GetUserSaveFolder();



            commonSave.Filter = MainTextStaticTools.TextFilter;
            {
                commonSave.FileOk += CommonSave_FileOk;
                commonSave.ShowDialog();
            }
            return ok;
        }

        /// <summary>
        /// Open a file the user selected as Unicode text
        /// </summary>
        void OpenUserFile()
        {
            void CommonOpen_FileOk(object? sender, System.ComponentModel.CancelEventArgs e)
            {

                {
                    try
                    {

                        string text = File.ReadAllText(commonOpen.FileName);


                        RichTextBoxText.Text = text;
                        FlagFileChanged = false;
                        FileName = commonOpen.SafeFileName;
                        FileLocation = commonOpen.FileName;
                        UpdateMainForm_Title();
                    }
                    catch (IOException err)
                    {
                        MessageBox.Show("Can't open this file. Reason is " + err.Message);
                    }
                }
                commonOpen.FileOk += CommonOpen_FileOk;
            }
            if (FileLocation != null)
            {
                commonOpen.FileName = Path.GetDirectoryName(FileLocation);
            }
            else
            {
                commonOpen.FileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }
            commonOpen.FileOk += CommonOpen_FileOk;
            commonOpen.ShowDialog();


        }



        /// <summary>
        /// Save the User's file.
        /// </summary>
        /// <param name="AlwaysPromptForLocation">if true, will always ask user to select target</param>
        void SaveUserFile(bool AlwaysPromptForLocation)
        {
            void SaveTarget()
            {
                try
                {
                    using (var fn = File.OpenWrite(FileLocation))
                    {
                        fn.SetLength(0);
                        byte[] b = Encoding.UTF8.GetBytes(RichTextBoxText.Text);
                        fn.Write(b, 0, b.Length);
                    }
                    FlagFileChanged = false;
                    UpdateMainForm_Title();
                }
                catch (IOException e)
                {
                    MessageBox.Show($"Error Saving to \"{FileLocation}\". Possible Reason: {e.Message}", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            /*
             * AlwaysPRomptForLocation means we must ask regardless if true but we reserve
             * the option to ask if false.
             * 
             * 
             */

            if (FileLocation == null)
                AlwaysPromptForLocation = true;

            if (AlwaysPromptForLocation)
            {
                if (UserSelectNewFile())
                {
                    SaveTarget();
                }
            }
            else
            {
                SaveTarget();
            }

            return;
            /*
             * Here's our logical
             * FileLocation is null?   THis is text created but NEVER saved, always show the prompt
             * 
             * If prompting - use UserSelectNewFile() which updates our FileLocation if positive.
             * 
             * If saving - write as Unicode Text - reset FileChanged bool to false and update Window Title
             */
            if (FileLocation == null)
            {
                if (AlwaysPromptForLocation)
                {


                    if (UserSelectNewFile())
                    {
                        using (var fn = File.OpenWrite(FileLocation))
                        {
                            byte[] b = Encoding.UTF8.GetBytes(RichTextBoxText.Text);
                            fn.Write(b, 0, b.Length);
                        }
                        FlagFileChanged = false;
                        UpdateMainForm_Title();
                    }
                }
                else
                {
                    MessageBox.Show("Warning: Error in SaveUserFile Dialog. This file was not saved.");
                }
            }
            else
            {
                if (!AlwaysPromptForLocation)
                {
                    using (var fn = File.OpenWrite(FileLocation))
                    {
                        byte[] b = Encoding.UTF8.GetBytes(RichTextBoxText.Text);
                        fn.Write(b, 0, b.Length);
                    }
                    FlagFileChanged = false;
                    UpdateMainForm_Title();
                }
                else
                {
                    if (UserSelectNewFile())
                    {
                        using (var fn = File.OpenWrite(FileLocation))
                        {
                            byte[] b = Encoding.UTF8.GetBytes(RichTextBoxText.Text);
                            fn.Write(b, 0, b.Length);
                        }
                        FlagFileChanged = false;
                        UpdateMainForm_Title();
                    }
                }
            }
        }
        /// <summary>
        /// Save (NOT EXPORT) user file as unicode text
        /// </summary>
        void SaveUserFile()
        {
            SaveUserFile(false);
        }
        #endregion
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// first load, update title bar and load user's preferences
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateMainForm_Title();
            LoadUserConfig();
            // hide debug menu if not debugging.
            if (Debugger.IsAttached)
            {
                debugMenuToolStripMenuItem.Enabled = debugMenuToolStripMenuItem.Visible = Debugger.IsAttached;
                topMostToolStripMenuItem.Enabled = false;
                
                topMostToolStripMenuItem.Text = topMostToolStripMenuItem.Text + "- Disabled to prevent softlock with Visual Studio.";
                FlagTopMost = false;
            }



        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void visualToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        ///  select all text on the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBoxText.SelectAll();
        }

        /// <summary>
        /// clear the selected text- set to blank
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBoxText.SelectedText = string.Empty;
        }

        /// <summary>
        /// set the clipboard to the selected text and clear selected text from here
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cutTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = RichTextBoxText.SelectedText;
            if (text.Length > 0)
            {
                Clipboard.SetText(RichTextBoxText.SelectedText);
                RichTextBoxText.SelectedText = string.Empty;
            }
        }

        /// <summary>
        /// Set the clipboard to contain the selected text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void copyTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string t = RichTextBoxText.SelectedText;
            if (t.Length > 0)
            {
                Clipboard.SetText(t);
            }

        }

        /// <summary>
        /// Replace the selected text with the clipboard's text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pasteTextToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string text = Clipboard.GetText(TextDataFormat.Text);
            if (text.Length > 0)
                RichTextBoxText.SelectedText = text;
        }

        /// <summary>
        /// set clipbord to selected RTF text (AND FONT) and clear the selection in our window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cutFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = RichTextBoxText.SelectedRtf;
            if (str.Length > 0)
            {
                Clipboard.SetText(str, TextDataFormat.Rtf);
                RichTextBoxText.SelectedRtf = string.Empty;
            }
        }

        /// <summary>
        /// set clipboard to the selected RTF text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void copyFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = RichTextBoxText.SelectedRtf;
            if (str.Length > 0)
                Clipboard.SetText(str, TextDataFormat.Rtf);
        }

        /// <summary>
        /// Replace the selected RFT with any on the clipboard.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pasteFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = Clipboard.GetText(TextDataFormat.Rtf);
            if (str.Length > 0)
                RichTextBoxText.SelectedRtf = str;
        }

        /// <summary>
        /// Undo Something.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBoxText.Undo();
        }

        /// <summary>
        /// Redo Something.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBoxText.Redo();
        }

        /// <summary>
        /// set our RichTextBoxText WordWrap to our checked menu item state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wordWrapToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            FlagWordWrap = wordWrapToolStripMenuItem.Checked;
            //RichTextBoxText.WordWrap = wordWrapToolStripMenuItem.Checked;
        }

        /// <summary>
        /// Set our Window Top Most flag to this checked menu item state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void topMostToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            FlagTopMost = topMostToolStripMenuItem.Checked;
            //TopMost = topMostToolStripMenuItem.Checked;
        }

        /// <summary>
        /// If checked, make 50% transparent, otherwise 0% transplarent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void transparentToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {/*
            if (transparentToolStripMenuItem.Checked)
            {
                Opacity = 0.5;
            }
            else
            {
                Opacity = 1;
            }*/
            FlagSeeThru = transparentToolStripMenuItem.Checked;
        }

        /// <summary>
        /// Increase zoom by 0.25 percent?
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBoxText.ZoomFactor += 0.25f;
        }


        /// <summary>
        /// decrease zoom by 0.25 percent?
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBoxText.ZoomFactor -= 0.25f;
        }


        /// <summary>
        /// reset to 100% zoom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resetZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBoxText.ZoomFactor = 1;
        }

        private void huntToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            commonFind.Show(this);
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // is the file changed? If so, prompt for saving file before new and bail if use cancels dialog.
            if (FlagFileChanged)
            {
                var q = prompt_user_for_save_changed(FileName);
                if (q == DialogResult.Cancel)
                    return;
                else
                {
                    // save the file if the use wants, reset to new file after
                    switch (q)
                    {
                        case DialogResult.Yes:
                            {
                                SaveUserFile();
                                reset_to_new_file();
                                return;
                            }
                        case DialogResult.No:
                            {
                                reset_to_new_file();
                                return;
                            }
                        default: throw new NotImplementedException("prompt returned something other than YES NO or CANCEL");
                    }
                }
            }
            // reset to new file - should only be here if file changed - false
            reset_to_new_file();
        }


        /// <summary>
        /// select a font and apply if the user wants it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {

            void F_Apply(object? sender, EventArgs e)
            {
                RichTextBoxText.SelectionFont = commonFont.Font;
                commonFont.Apply -= F_Apply;
            }

            {
                commonFont.Font = RichTextBoxText.SelectionFont;
                commonFont.AllowScriptChange = true;
                commonFont.FontMustExist = true;
                commonFont.ShowApply = true;
                commonFont.Apply += F_Apply;

                if (commonFont.ShowDialog(this) == DialogResult.OK)
                {
                    RichTextBoxText.SelectionFont = commonFont.Font;
                    commonFont.Apply -= F_Apply;
                }
            }
        }


        private void RichTextBoxText_TextChanged(object sender, EventArgs e)
        {
            FlagFileChanged = true;
            UpdateMainForm_Title();
        }

        private void editToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        /// <summary>
        /// Update our context of Can Redo, Can Undo, can Paste, goto line if NOT word wrapped
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {

            redoToolStripMenuItem.Enabled = RichTextBoxText.CanRedo;
            undoToolStripMenuItem.Enabled = RichTextBoxText.CanUndo;
            pasteTextToolStripMenuItem.Enabled = (Clipboard.ContainsText(TextDataFormat.Text) || (Clipboard.ContainsText(TextDataFormat.UnicodeText)));
            pasteFormatToolStripMenuItem.Enabled = ((Clipboard.ContainsText(TextDataFormat.Rtf)));
            cutTextToolStripMenuItem.Enabled = copyTextToolStripMenuItem.Enabled = (RichTextBoxText.SelectedText != string.Empty);
            cutFormatToolStripMenuItem.Enabled = copyFormatToolStripMenuItem.Enabled = (RichTextBoxText.SelectedRtf != string.Empty);


            gotoLineToolStripMenuItem.Enabled = !RichTextBoxText.WordWrap;


            flattenToolStripMenuItem.Enabled = false;
            if (SaveState != null)
            {
                if (SaveState.FlattonFont != null)
                {
                    flattenToolStripMenuItem.Enabled = true;
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // if file changed
            if (FlagFileChanged)
            {
                // ask if the user wants to save and bail if cancel
                var q = prompt_user_for_save_changed(FileName);
                if (q == DialogResult.Cancel)
                    return;
                switch (q)
                {
                    case DialogResult.Yes:
                        // save the file
                        SaveUserFile();
                        break;
                }
            }
            // prompt user for new one
            OpenUserFile();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // invoke the save file logical which may be allowed to display an SAVE File Dialog
            SaveUserFile(false);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // invoke the save file logic which MUST display the SAVE File Dialog
            SaveUserFile(true);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // prompt to save changed, bail if out and call Application.Exit() to quit
            if (FlagFileChanged)
            {
                var q = prompt_user_for_save_changed(FileName);
                if (q == DialogResult.Cancel)
                    return;
                if (q == DialogResult.Yes)
                {
                    SaveUserFile(true);
                }
            }
            Application.Exit();

        }

        private void findNextToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void findLastToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void zoomToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// TODO: Display the goto line dialog box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void gotoLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            commonGoto.ShowDialog(this);
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void formatToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Word Wrap checked toggle is done as a property of checkbox changeds
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Top Most checked toggle is done as a property of checkbox changeds
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void topMostToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Transparent checked toggle is done as a property of checkbox changeds
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void transparentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void autosaveOnShutdownLogoffToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveUserConfig();
        }

        private void autosaveOnShutdownLogoffToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            SaveState.FlagSaveOnShutdown = autosaveOnShutdownLogoffToolStripMenuItem.Checked;
        }

        private void RichTextBoxText_VScroll(object sender, EventArgs e)
        {

            int first_c = RichTextBoxText.GetCharIndexFromPosition(Point.Empty);
            int last_c = RichTextBoxText.GetCharIndexFromPosition(new Point(RichTextBoxText.Width, RichTextBoxText.Height));

            int first_line = RichTextBoxText.GetLineFromCharIndex(first_c);
            int last_line = RichTextBoxText.GetLineFromCharIndex(last_c);



        }

        private void chooseFlattenFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            void F_Apply(object? sender, EventArgs e)
            {
                RichTextBoxText.Font = commonFont.Font;
                commonFont.Apply -= F_Apply;
            }

            {
                commonFont.Font = RichTextBoxText.SelectionFont;
                commonFont.FontMustExist = true;
                commonFont.Apply += F_Apply;
                commonFont.ShowColor = true;
                commonFont.ShowApply = false;
                if (commonFont.ShowDialog() == DialogResult.OK)
                {
                    SaveState.FlattonFont = commonFont.Font;
                    SaveState.FlattonFontFront = commonFont.Color;

                }
            }

        }

        private void flattenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int carrot_pos, carrot_len;
            const int WM_REDRAW = 11;
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
            static extern IntPtr SendMessage(nint hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

            SendMessage(RichTextBoxText.Handle, WM_REDRAW, 0, 0);
            carrot_pos = RichTextBoxText.SelectionStart;
            carrot_len = RichTextBoxText.SelectionLength;
            RichTextBoxText.SelectAll();
            RichTextBoxText.SelectionFont = SaveState.FlattonFont;
            RichTextBoxText.SelectionBackColor = SaveState.FlattonFontBack;
            RichTextBoxText.SelectionColor = SaveState.FlattonFontFront;
            RichTextBoxText.SelectionStart = carrot_pos;
            RichTextBoxText.SelectionLength = carrot_len;
            RichTextBoxText.ScrollToCaret();
            SendMessage(RichTextBoxText.Handle, WM_REDRAW, 1, 0);
            RichTextBoxText.Invalidate(null, true);

        }

        private void choosePreferredSaveFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var SV = new FolderBrowserDialog())
            {
                SV.InitialDirectory = GetUserSaveFolder();
                SV.Description = "Select Preffered Save Folder";
                if (SV.ShowDialog() == DialogResult.OK)
                {
                    SaveState.PreferredSaveLocation = SV.SelectedPath;
                }
            }
        }

        private void emptyClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
        }

        private void viewGithubForThisProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var exp = new Process())
            {
                exp.StartInfo = new();
                exp.StartInfo.FileName = "https://github.com/ShadowKnightMK4/LightningNote2";
                exp.StartInfo.UseShellExecute = true;
                exp.Start();
            }

        }

        private void enableVisualsTopMostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            topMostToolStripMenuItem.Enabled = true;
            topMostToolStripMenuItem.Text = topMostToolStripMenuItem.Text = "TopMost - Caution Softlock possible.";
        }
    }
}
internal static class MainTextStaticTools
{
    public static readonly string TextFilter = "Text files(*.txt) | *.txt | All files(*.*) | *.* ";
    /// <summary>
    /// Used for slicing a few paths together in opening/saving files.
    /// </summary>
    /// <returns></returns>
    public static string ParanoidPathCombine(string Path1, string Path2)
    {
        string ret;
        if (string.IsNullOrEmpty(Path1))
        {
            return Path2;
        }
        if (string.IsNullOrEmpty(Path2))
        {
            return Path1;
        }

        ret = Path1;
        if (ret.EndsWith(Path.DirectorySeparatorChar) == false) { ret += Path.DirectorySeparatorChar; }

        if ( (Path2.StartsWith(Path.PathSeparator) == false) && (Path2.StartsWith(Path.AltDirectorySeparatorChar) == false))
        {
            ret += Path2;
        }
        else
        {
            if (Path2.Length > 1)
                ret += Path2[1..];
            else
                ret += Path.PathSeparator;
        }

        return ret;
    }

    
}
