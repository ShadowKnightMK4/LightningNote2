namespace LightningNote
{
    partial class GotoDialog
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
            TextBoxSelectLine = new TextBox();
            ButtonGoto = new Button();
            CheckBoxSelectIt = new CheckBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // TextBoxSelectLine
            // 
            TextBoxSelectLine.Location = new Point(49, 59);
            TextBoxSelectLine.Name = "TextBoxSelectLine";
            TextBoxSelectLine.Size = new Size(420, 31);
            TextBoxSelectLine.TabIndex = 0;
            TextBoxSelectLine.TextChanged += textBox1_TextChanged;
            // 
            // ButtonGoto
            // 
            ButtonGoto.Location = new Point(548, 59);
            ButtonGoto.Name = "ButtonGoto";
            ButtonGoto.Size = new Size(112, 34);
            ButtonGoto.TabIndex = 1;
            ButtonGoto.Text = "Go!";
            ButtonGoto.UseVisualStyleBackColor = true;
            ButtonGoto.Click += ButtonGoto_Click;
            // 
            // CheckBoxSelectIt
            // 
            CheckBoxSelectIt.AutoSize = true;
            CheckBoxSelectIt.Location = new Point(66, 120);
            CheckBoxSelectIt.Name = "CheckBoxSelectIt";
            CheckBoxSelectIt.Size = new Size(100, 29);
            CheckBoxSelectIt.TabIndex = 2;
            CheckBoxSelectIt.Text = "Select It";
            CheckBoxSelectIt.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(548, 99);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 3;
            button1.Text = "Close";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // GotoDialog
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 222);
            Controls.Add(button1);
            Controls.Add(CheckBoxSelectIt);
            Controls.Add(ButtonGoto);
            Controls.Add(TextBoxSelectLine);
            Name = "GotoDialog";
            Text = "Goto A Line...";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TextBoxSelectLine;
        private Button ButtonGoto;
        private CheckBox CheckBoxSelectIt;
        private Button button1;
    }
}