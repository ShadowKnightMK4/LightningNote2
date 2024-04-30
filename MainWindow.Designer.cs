namespace LightningNote
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem5 = new ToolStripSeparator();
            openToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem7 = new ToolStripSeparator();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem6 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            autosaveOnShutdownLogoffToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            redoToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            cutTextToolStripMenuItem = new ToolStripMenuItem();
            copyTextToolStripMenuItem = new ToolStripMenuItem();
            pasteTextToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripSeparator();
            cutFormatToolStripMenuItem = new ToolStripMenuItem();
            copyFormatToolStripMenuItem = new ToolStripMenuItem();
            pasteFormatToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripSeparator();
            gotoLineToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripSeparator();
            selectAllToolStripMenuItem = new ToolStripMenuItem();
            clearSelectionToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem8 = new ToolStripSeparator();
            flattenToolStripMenuItem = new ToolStripMenuItem();
            exportToolStripMenuItem = new ToolStripMenuItem();
            exportAsANSITextToolStripMenuItem = new ToolStripMenuItem();
            exportAsUnicodeTextToolStripMenuItem = new ToolStripMenuItem();
            huntToolStripMenuItem = new ToolStripMenuItem();
            findToolStripMenuItem = new ToolStripMenuItem();
            findNextToolStripMenuItem = new ToolStripMenuItem();
            findLastToolStripMenuItem = new ToolStripMenuItem();
            replacementToolStripMenuItem = new ToolStripMenuItem();
            formatToolStripMenuItem = new ToolStripMenuItem();
            fontToolStripMenuItem = new ToolStripMenuItem();
            chooseFlattenFontToolStripMenuItem = new ToolStripMenuItem();
            visualToolStripMenuItem = new ToolStripMenuItem();
            zoomToolStripMenuItem = new ToolStripMenuItem();
            zoomInToolStripMenuItem = new ToolStripMenuItem();
            zoomOutToolStripMenuItem = new ToolStripMenuItem();
            resetZoomToolStripMenuItem = new ToolStripMenuItem();
            wordWrapToolStripMenuItem = new ToolStripMenuItem();
            topMostToolStripMenuItem = new ToolStripMenuItem();
            transparentToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            viewGithubForThisProjectToolStripMenuItem = new ToolStripMenuItem();
            debugMenuToolStripMenuItem = new ToolStripMenuItem();
            choosePreferredSaveFolderToolStripMenuItem = new ToolStripMenuItem();
            emptyClipboardToolStripMenuItem = new ToolStripMenuItem();
            RichTextBoxText = new RichTextBox();
            enableVisualsTopMostToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, exportToolStripMenuItem, huntToolStripMenuItem, formatToolStripMenuItem, visualToolStripMenuItem, helpToolStripMenuItem, debugMenuToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 33);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, toolStripMenuItem5, openToolStripMenuItem, toolStripMenuItem7, saveToolStripMenuItem, saveAsToolStripMenuItem, toolStripMenuItem6, exitToolStripMenuItem, autosaveOnShutdownLogoffToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(54, 29);
            fileToolStripMenuItem.Text = "&File";
            fileToolStripMenuItem.Click += fileToolStripMenuItem_Click;
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newToolStripMenuItem.Size = new Size(360, 34);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new Size(357, 6);
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openToolStripMenuItem.Size = new Size(360, 34);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // toolStripMenuItem7
            // 
            toolStripMenuItem7.Name = "toolStripMenuItem7";
            toolStripMenuItem7.Size = new Size(357, 6);
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveToolStripMenuItem.Size = new Size(360, 34);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            saveAsToolStripMenuItem.Size = new Size(360, 34);
            saveAsToolStripMenuItem.Text = "Save As";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // toolStripMenuItem6
            // 
            toolStripMenuItem6.Name = "toolStripMenuItem6";
            toolStripMenuItem6.Size = new Size(357, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(360, 34);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // autosaveOnShutdownLogoffToolStripMenuItem
            // 
            autosaveOnShutdownLogoffToolStripMenuItem.Checked = true;
            autosaveOnShutdownLogoffToolStripMenuItem.CheckOnClick = true;
            autosaveOnShutdownLogoffToolStripMenuItem.CheckState = CheckState.Checked;
            autosaveOnShutdownLogoffToolStripMenuItem.Name = "autosaveOnShutdownLogoffToolStripMenuItem";
            autosaveOnShutdownLogoffToolStripMenuItem.Size = new Size(360, 34);
            autosaveOnShutdownLogoffToolStripMenuItem.Text = "Autosave on Shutdown/Logoff";
            autosaveOnShutdownLogoffToolStripMenuItem.CheckedChanged += autosaveOnShutdownLogoffToolStripMenuItem_CheckedChanged;
            autosaveOnShutdownLogoffToolStripMenuItem.Click += autosaveOnShutdownLogoffToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { undoToolStripMenuItem, redoToolStripMenuItem, toolStripMenuItem1, cutTextToolStripMenuItem, copyTextToolStripMenuItem, pasteTextToolStripMenuItem, toolStripMenuItem2, cutFormatToolStripMenuItem, copyFormatToolStripMenuItem, pasteFormatToolStripMenuItem, toolStripMenuItem3, gotoLineToolStripMenuItem, toolStripMenuItem4, selectAllToolStripMenuItem, clearSelectionToolStripMenuItem, toolStripMenuItem8, flattenToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(58, 29);
            editToolStripMenuItem.Text = "Edit";
            editToolStripMenuItem.DropDownOpened += editToolStripMenuItem_DropDownOpened;
            editToolStripMenuItem.DropDownItemClicked += editToolStripMenuItem_DropDownItemClicked;
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            undoToolStripMenuItem.Size = new Size(265, 34);
            undoToolStripMenuItem.Text = "Undo";
            undoToolStripMenuItem.Click += undoToolStripMenuItem_Click;
            // 
            // redoToolStripMenuItem
            // 
            redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            redoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.Z;
            redoToolStripMenuItem.Size = new Size(265, 34);
            redoToolStripMenuItem.Text = "Redo";
            redoToolStripMenuItem.Click += redoToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(262, 6);
            // 
            // cutTextToolStripMenuItem
            // 
            cutTextToolStripMenuItem.Name = "cutTextToolStripMenuItem";
            cutTextToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            cutTextToolStripMenuItem.Size = new Size(265, 34);
            cutTextToolStripMenuItem.Text = "Cut Text";
            cutTextToolStripMenuItem.Click += cutTextToolStripMenuItem_Click;
            // 
            // copyTextToolStripMenuItem
            // 
            copyTextToolStripMenuItem.Name = "copyTextToolStripMenuItem";
            copyTextToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            copyTextToolStripMenuItem.Size = new Size(265, 34);
            copyTextToolStripMenuItem.Text = "Copy Text";
            copyTextToolStripMenuItem.Click += copyTextToolStripMenuItem_Click;
            // 
            // pasteTextToolStripMenuItem
            // 
            pasteTextToolStripMenuItem.Name = "pasteTextToolStripMenuItem";
            pasteTextToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            pasteTextToolStripMenuItem.Size = new Size(265, 34);
            pasteTextToolStripMenuItem.Text = "Paste Text";
            pasteTextToolStripMenuItem.Click += pasteTextToolStripMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(262, 6);
            // 
            // cutFormatToolStripMenuItem
            // 
            cutFormatToolStripMenuItem.Name = "cutFormatToolStripMenuItem";
            cutFormatToolStripMenuItem.Size = new Size(265, 34);
            cutFormatToolStripMenuItem.Text = "Cut Format";
            cutFormatToolStripMenuItem.Click += cutFormatToolStripMenuItem_Click;
            // 
            // copyFormatToolStripMenuItem
            // 
            copyFormatToolStripMenuItem.Name = "copyFormatToolStripMenuItem";
            copyFormatToolStripMenuItem.Size = new Size(265, 34);
            copyFormatToolStripMenuItem.Text = "Copy Format";
            copyFormatToolStripMenuItem.Click += copyFormatToolStripMenuItem_Click;
            // 
            // pasteFormatToolStripMenuItem
            // 
            pasteFormatToolStripMenuItem.Name = "pasteFormatToolStripMenuItem";
            pasteFormatToolStripMenuItem.Size = new Size(265, 34);
            pasteFormatToolStripMenuItem.Text = "Paste Format";
            pasteFormatToolStripMenuItem.Click += pasteFormatToolStripMenuItem_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(262, 6);
            // 
            // gotoLineToolStripMenuItem
            // 
            gotoLineToolStripMenuItem.Name = "gotoLineToolStripMenuItem";
            gotoLineToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.G;
            gotoLineToolStripMenuItem.Size = new Size(265, 34);
            gotoLineToolStripMenuItem.Text = "Goto Line...";
            gotoLineToolStripMenuItem.Click += gotoLineToolStripMenuItem_Click;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(262, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            selectAllToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;
            selectAllToolStripMenuItem.Size = new Size(265, 34);
            selectAllToolStripMenuItem.Text = "Select All";
            selectAllToolStripMenuItem.Click += selectAllToolStripMenuItem_Click;
            // 
            // clearSelectionToolStripMenuItem
            // 
            clearSelectionToolStripMenuItem.Name = "clearSelectionToolStripMenuItem";
            clearSelectionToolStripMenuItem.Size = new Size(265, 34);
            clearSelectionToolStripMenuItem.Text = "Clear Selection";
            clearSelectionToolStripMenuItem.Click += clearSelectionToolStripMenuItem_Click;
            // 
            // toolStripMenuItem8
            // 
            toolStripMenuItem8.Name = "toolStripMenuItem8";
            toolStripMenuItem8.Size = new Size(262, 6);
            // 
            // flattenToolStripMenuItem
            // 
            flattenToolStripMenuItem.Name = "flattenToolStripMenuItem";
            flattenToolStripMenuItem.Size = new Size(265, 34);
            flattenToolStripMenuItem.Text = "Flatten Text";
            flattenToolStripMenuItem.Click += flattenToolStripMenuItem_Click;
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exportAsANSITextToolStripMenuItem, exportAsUnicodeTextToolStripMenuItem });
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(79, 29);
            exportToolStripMenuItem.Text = "&Export";
            exportToolStripMenuItem.Click += exportToolStripMenuItem_Click;
            // 
            // exportAsANSITextToolStripMenuItem
            // 
            exportAsANSITextToolStripMenuItem.Name = "exportAsANSITextToolStripMenuItem";
            exportAsANSITextToolStripMenuItem.Size = new Size(292, 34);
            exportAsANSITextToolStripMenuItem.Text = "Export as ANSI Text";
            // 
            // exportAsUnicodeTextToolStripMenuItem
            // 
            exportAsUnicodeTextToolStripMenuItem.Name = "exportAsUnicodeTextToolStripMenuItem";
            exportAsUnicodeTextToolStripMenuItem.Size = new Size(292, 34);
            exportAsUnicodeTextToolStripMenuItem.Text = "Export as Unicode Text";
            // 
            // huntToolStripMenuItem
            // 
            huntToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { findToolStripMenuItem, findNextToolStripMenuItem, findLastToolStripMenuItem, replacementToolStripMenuItem });
            huntToolStripMenuItem.Name = "huntToolStripMenuItem";
            huntToolStripMenuItem.Size = new Size(67, 29);
            huntToolStripMenuItem.Text = "Hunt";
            huntToolStripMenuItem.Click += huntToolStripMenuItem_Click;
            // 
            // findToolStripMenuItem
            // 
            findToolStripMenuItem.Name = "findToolStripMenuItem";
            findToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.F;
            findToolStripMenuItem.Size = new Size(302, 34);
            findToolStripMenuItem.Text = "Find";
            findToolStripMenuItem.Click += findToolStripMenuItem_Click;
            // 
            // findNextToolStripMenuItem
            // 
            findNextToolStripMenuItem.Name = "findNextToolStripMenuItem";
            findNextToolStripMenuItem.ShortcutKeys = Keys.F3;
            findNextToolStripMenuItem.Size = new Size(302, 34);
            findNextToolStripMenuItem.Text = "Find Next";
            findNextToolStripMenuItem.Click += findNextToolStripMenuItem_Click;
            // 
            // findLastToolStripMenuItem
            // 
            findLastToolStripMenuItem.Name = "findLastToolStripMenuItem";
            findLastToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.F3;
            findLastToolStripMenuItem.Size = new Size(302, 34);
            findLastToolStripMenuItem.Text = "Find Last";
            findLastToolStripMenuItem.Click += findLastToolStripMenuItem_Click;
            // 
            // replacementToolStripMenuItem
            // 
            replacementToolStripMenuItem.Name = "replacementToolStripMenuItem";
            replacementToolStripMenuItem.Size = new Size(302, 34);
            replacementToolStripMenuItem.Text = "Replacement";
            // 
            // formatToolStripMenuItem
            // 
            formatToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { fontToolStripMenuItem, chooseFlattenFontToolStripMenuItem });
            formatToolStripMenuItem.Name = "formatToolStripMenuItem";
            formatToolStripMenuItem.Size = new Size(85, 29);
            formatToolStripMenuItem.Text = "Format";
            // 
            // fontToolStripMenuItem
            // 
            fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            fontToolStripMenuItem.Size = new Size(285, 34);
            fontToolStripMenuItem.Text = "Font...";
            fontToolStripMenuItem.Click += fontToolStripMenuItem_Click;
            // 
            // chooseFlattenFontToolStripMenuItem
            // 
            chooseFlattenFontToolStripMenuItem.Name = "chooseFlattenFontToolStripMenuItem";
            chooseFlattenFontToolStripMenuItem.Size = new Size(285, 34);
            chooseFlattenFontToolStripMenuItem.Text = "Choose Flatten Font...";
            chooseFlattenFontToolStripMenuItem.Click += chooseFlattenFontToolStripMenuItem_Click;
            // 
            // visualToolStripMenuItem
            // 
            visualToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { zoomToolStripMenuItem, wordWrapToolStripMenuItem, topMostToolStripMenuItem, transparentToolStripMenuItem });
            visualToolStripMenuItem.Name = "visualToolStripMenuItem";
            visualToolStripMenuItem.Size = new Size(74, 29);
            visualToolStripMenuItem.Text = "Visual";
            visualToolStripMenuItem.Click += visualToolStripMenuItem_Click;
            // 
            // zoomToolStripMenuItem
            // 
            zoomToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { zoomInToolStripMenuItem, zoomOutToolStripMenuItem, resetZoomToolStripMenuItem });
            zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            zoomToolStripMenuItem.Size = new Size(274, 34);
            zoomToolStripMenuItem.Text = "Zoom";
            zoomToolStripMenuItem.Click += zoomToolStripMenuItem_Click;
            // 
            // zoomInToolStripMenuItem
            // 
            zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            zoomInToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Oemplus;
            zoomInToolStripMenuItem.Size = new Size(335, 34);
            zoomInToolStripMenuItem.Text = "Zoom In";
            zoomInToolStripMenuItem.Click += zoomInToolStripMenuItem_Click;
            // 
            // zoomOutToolStripMenuItem
            // 
            zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
            zoomOutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.OemMinus;
            zoomOutToolStripMenuItem.Size = new Size(335, 34);
            zoomOutToolStripMenuItem.Text = "Zoom Out";
            zoomOutToolStripMenuItem.Click += zoomOutToolStripMenuItem_Click;
            // 
            // resetZoomToolStripMenuItem
            // 
            resetZoomToolStripMenuItem.Name = "resetZoomToolStripMenuItem";
            resetZoomToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D0;
            resetZoomToolStripMenuItem.Size = new Size(335, 34);
            resetZoomToolStripMenuItem.Text = "Reset Zoom";
            resetZoomToolStripMenuItem.Click += resetZoomToolStripMenuItem_Click;
            // 
            // wordWrapToolStripMenuItem
            // 
            wordWrapToolStripMenuItem.Checked = true;
            wordWrapToolStripMenuItem.CheckOnClick = true;
            wordWrapToolStripMenuItem.CheckState = CheckState.Checked;
            wordWrapToolStripMenuItem.Name = "wordWrapToolStripMenuItem";
            wordWrapToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.W;
            wordWrapToolStripMenuItem.Size = new Size(274, 34);
            wordWrapToolStripMenuItem.Text = "Word Wrap";
            wordWrapToolStripMenuItem.CheckStateChanged += wordWrapToolStripMenuItem_CheckStateChanged;
            wordWrapToolStripMenuItem.Click += wordWrapToolStripMenuItem_Click;
            // 
            // topMostToolStripMenuItem
            // 
            topMostToolStripMenuItem.Checked = true;
            topMostToolStripMenuItem.CheckOnClick = true;
            topMostToolStripMenuItem.CheckState = CheckState.Checked;
            topMostToolStripMenuItem.Name = "topMostToolStripMenuItem";
            topMostToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.T;
            topMostToolStripMenuItem.Size = new Size(274, 34);
            topMostToolStripMenuItem.Text = "Top Most";
            topMostToolStripMenuItem.CheckStateChanged += topMostToolStripMenuItem_CheckStateChanged;
            topMostToolStripMenuItem.Click += topMostToolStripMenuItem_Click;
            // 
            // transparentToolStripMenuItem
            // 
            transparentToolStripMenuItem.Checked = true;
            transparentToolStripMenuItem.CheckOnClick = true;
            transparentToolStripMenuItem.CheckState = CheckState.Checked;
            transparentToolStripMenuItem.Name = "transparentToolStripMenuItem";
            transparentToolStripMenuItem.Size = new Size(274, 34);
            transparentToolStripMenuItem.Text = "Transparent";
            transparentToolStripMenuItem.CheckStateChanged += transparentToolStripMenuItem_CheckStateChanged;
            transparentToolStripMenuItem.Click += transparentToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { viewGithubForThisProjectToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(65, 29);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // viewGithubForThisProjectToolStripMenuItem
            // 
            viewGithubForThisProjectToolStripMenuItem.Name = "viewGithubForThisProjectToolStripMenuItem";
            viewGithubForThisProjectToolStripMenuItem.Size = new Size(332, 34);
            viewGithubForThisProjectToolStripMenuItem.Text = "View Github For this Project";
            viewGithubForThisProjectToolStripMenuItem.Click += viewGithubForThisProjectToolStripMenuItem_Click;
            // 
            // debugMenuToolStripMenuItem
            // 
            debugMenuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { choosePreferredSaveFolderToolStripMenuItem, emptyClipboardToolStripMenuItem, enableVisualsTopMostToolStripMenuItem });
            debugMenuToolStripMenuItem.Name = "debugMenuToolStripMenuItem";
            debugMenuToolStripMenuItem.Size = new Size(132, 29);
            debugMenuToolStripMenuItem.Text = "&Debug Menu";
            // 
            // choosePreferredSaveFolderToolStripMenuItem
            // 
            choosePreferredSaveFolderToolStripMenuItem.Name = "choosePreferredSaveFolderToolStripMenuItem";
            choosePreferredSaveFolderToolStripMenuItem.Size = new Size(348, 34);
            choosePreferredSaveFolderToolStripMenuItem.Text = "Choose Preferred Save Folder";
            choosePreferredSaveFolderToolStripMenuItem.Click += choosePreferredSaveFolderToolStripMenuItem_Click;
            // 
            // emptyClipboardToolStripMenuItem
            // 
            emptyClipboardToolStripMenuItem.Name = "emptyClipboardToolStripMenuItem";
            emptyClipboardToolStripMenuItem.Size = new Size(348, 34);
            emptyClipboardToolStripMenuItem.Text = "Empty Clipboard";
            emptyClipboardToolStripMenuItem.Click += emptyClipboardToolStripMenuItem_Click;
            // 
            // RichTextBoxText
            // 
            RichTextBoxText.Dock = DockStyle.Fill;
            RichTextBoxText.Location = new Point(0, 33);
            RichTextBoxText.Name = "RichTextBoxText";
            RichTextBoxText.Size = new Size(800, 417);
            RichTextBoxText.TabIndex = 1;
            RichTextBoxText.Text = "";
            RichTextBoxText.VScroll += RichTextBoxText_VScroll;
            RichTextBoxText.TextChanged += RichTextBoxText_TextChanged;
            // 
            // enableVisualsTopMostToolStripMenuItem
            // 
            enableVisualsTopMostToolStripMenuItem.Name = "enableVisualsTopMostToolStripMenuItem";
            enableVisualsTopMostToolStripMenuItem.Size = new Size(348, 34);
            enableVisualsTopMostToolStripMenuItem.Text = "Enable Visual's TopMost";
            enableVisualsTopMostToolStripMenuItem.Click += enableVisualsTopMostToolStripMenuItem_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(RichTextBoxText);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainWindow";
            Text = "LightningPad - {0}{1}";
            FormClosed += MainWindow_FormClosed;
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem autosaveOnShutdownLogoffToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem redoToolStripMenuItem;
        private ToolStripMenuItem cutTextToolStripMenuItem;
        private ToolStripMenuItem copyTextToolStripMenuItem;
        private ToolStripMenuItem pasteTextToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem cutFormatToolStripMenuItem;
        private ToolStripMenuItem copyFormatToolStripMenuItem;
        private ToolStripMenuItem pasteFormatToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem gotoLineToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem4;
        private ToolStripMenuItem selectAllToolStripMenuItem;
        private ToolStripMenuItem clearSelectionToolStripMenuItem;
        private ToolStripMenuItem huntToolStripMenuItem;
        private ToolStripMenuItem findToolStripMenuItem;
        private ToolStripMenuItem findNextToolStripMenuItem;
        private ToolStripMenuItem findLastToolStripMenuItem;
        private ToolStripMenuItem replacementToolStripMenuItem;
        private ToolStripMenuItem formatToolStripMenuItem;
        private ToolStripMenuItem fontToolStripMenuItem;
        private ToolStripMenuItem visualToolStripMenuItem;
        private ToolStripMenuItem zoomToolStripMenuItem;
        private ToolStripMenuItem zoomInToolStripMenuItem;
        private ToolStripMenuItem zoomOutToolStripMenuItem;
        private ToolStripMenuItem resetZoomToolStripMenuItem;
        private ToolStripMenuItem wordWrapToolStripMenuItem;
        private ToolStripMenuItem topMostToolStripMenuItem;
        private ToolStripMenuItem transparentToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem5;
        private ToolStripSeparator toolStripMenuItem6;
        private ToolStripSeparator toolStripMenuItem7;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem viewGithubForThisProjectToolStripMenuItem;
        private ToolStripMenuItem exportToolStripMenuItem;
        private ToolStripMenuItem exportAsANSITextToolStripMenuItem;
        private ToolStripMenuItem exportAsUnicodeTextToolStripMenuItem;
        public RichTextBox RichTextBoxText;
        private ToolStripSeparator toolStripMenuItem8;
        private ToolStripMenuItem flattenToolStripMenuItem;
        private ToolStripMenuItem chooseFlattenFontToolStripMenuItem;
        private ToolStripMenuItem debugMenuToolStripMenuItem;
        private ToolStripMenuItem choosePreferredSaveFolderToolStripMenuItem;
        private ToolStripMenuItem emptyClipboardToolStripMenuItem;
        private ToolStripMenuItem enableVisualsTopMostToolStripMenuItem;
    }
}
