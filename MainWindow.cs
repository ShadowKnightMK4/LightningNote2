using System.Diagnostics;
using System.Text;

namespace LightningNote
{
    public partial class MainWindow : Form
    {
        #region common dialog boxes
        readonly FontDialog commonFont = new();
        readonly OpenFileDialog commonOpen = new();
        readonly SaveFileDialog commonSave = new();
        readonly FindDialog commonFind = new();
        readonly GotoDialog commonGoto = new();
        #endregion

        #region save state
        bool FileChanged = false;
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
        /// name - {file name} ** 
        /// </summary>
        void UpdateMainForm_Title()
        {
            string changed_icon;
            if (general_title == string.Empty)
            {
                general_title = this.Text;
            }
            if (FileChanged)
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
            FileChanged = false;
            UpdateMainForm_Title();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
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
            if (FileLocation == null)
            {
                commonSave.FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), FileName);
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

                        FileChanged = false;
                        RichTextBoxText.Text = text;
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
        /// <param name="AlwaysPrompt">if true, will always ask user to select target</param>
        void SaveUserFile(bool AlwaysPrompt)
        {
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
                if (AlwaysPrompt)
                {


                    if (UserSelectNewFile())
                    {
                        using (var fn = File.OpenWrite(FileLocation))
                        {
                            byte[] b = Encoding.UTF8.GetBytes(RichTextBoxText.Text);
                            fn.Write(b, 0, b.Length);
                        }
                        FileChanged = false;
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
                if (!AlwaysPrompt)
                {
                    using (var fn = File.OpenWrite(FileLocation))
                    {
                        byte[] b = Encoding.UTF8.GetBytes(RichTextBoxText.Text);
                        fn.Write(b, 0, b.Length);
                    }
                    FileChanged = false;
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
                        FileChanged = false;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateMainForm_Title();
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
            Clipboard.SetText(RichTextBoxText.SelectedText);
            RichTextBoxText.SelectedText = string.Empty;
        }

        /// <summary>
        /// Set the clipboard to contain the selected text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void copyTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(RichTextBoxText.SelectedText);
        }

        /// <summary>
        /// Replace the selected text with the clipboard's text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pasteTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBoxText.SelectedText = Clipboard.GetText(TextDataFormat.Text);
        }

        /// <summary>
        /// set clipbord to selected RTF text (AND FONT) and clear the selection in our window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cutFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(RichTextBoxText.SelectedRtf, TextDataFormat.Rtf);
            RichTextBoxText.SelectedRtf = string.Empty;
        }

        /// <summary>
        /// set clipboard to the selected RTF text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void copyFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(RichTextBoxText.SelectedRtf, TextDataFormat.Rtf);
        }

        /// <summary>
        /// Replace the selected RFT with any on the clipboard.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pasteFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBoxText.SelectedRtf = Clipboard.GetText(TextDataFormat.Rtf);
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
            RichTextBoxText.WordWrap = wordWrapToolStripMenuItem.Checked;
        }

        /// <summary>
        /// Set our Window Top Most flag to this checked menu item state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void topMostToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            TopMost = topMostToolStripMenuItem.Checked;
        }

        /// <summary>
        /// If checked, make 50% transparent, otherwise 0% transplarent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void transparentToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            if (transparentToolStripMenuItem.Checked)
            {
                Opacity = 0.5;
            }
            else
            {
                Opacity = 1;
            }
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
            if (FileChanged)
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
                RichTextBoxText.Font = commonFont.Font;
                commonFont.Apply -= F_Apply;
            }

            {
                commonFont.Font = RichTextBoxText.SelectionFont;
                commonFont.AllowScriptChange = true;
                commonFont.FontMustExist = true;
                commonFont.ShowApply = true;
                commonFont.Apply += F_Apply;
                commonFind.Show();
            }
        }


        private void RichTextBoxText_TextChanged(object sender, EventArgs e)
        {
            FileChanged = true;
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
            pasteTextToolStripMenuItem.Enabled = pasteFormatToolStripMenuItem.Enabled = Clipboard.ContainsText();
            gotoLineToolStripMenuItem.Enabled = !RichTextBoxText.WordWrap;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // if file changed
            if (FileChanged)
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
            SaveUserFile(true);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // invoke the save file logic which MUST display the SAVE File Dialog
            SaveUserFile(false);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // prompt to save changed, bail if out and call Application.Exit() to quit
            if (FileChanged)
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
    }
}
