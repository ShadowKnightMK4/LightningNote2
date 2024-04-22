namespace LightningNote
{
    partial class FindDialog
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
            TextBoxSearchText = new TextBox();
            ButtonFindNext = new Button();
            ButtonFindPrev = new Button();
            CheckBoxMatchCase = new CheckBox();
            CheckBoxWrapAround = new CheckBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            RadioButtonDown = new RadioButton();
            RadioButtonUp = new RadioButton();
            ButtonCancel = new Button();
            CheckBoxUseReg = new CheckBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // TextBoxSearchText
            // 
            TextBoxSearchText.Location = new Point(126, 62);
            TextBoxSearchText.Name = "TextBoxSearchText";
            TextBoxSearchText.Size = new Size(434, 31);
            TextBoxSearchText.TabIndex = 0;
            TextBoxSearchText.TextChanged += TextBoxSearchText_TextChanged;
            // 
            // ButtonFindNext
            // 
            ButtonFindNext.Location = new Point(635, 45);
            ButtonFindNext.Name = "ButtonFindNext";
            ButtonFindNext.Size = new Size(112, 34);
            ButtonFindNext.TabIndex = 1;
            ButtonFindNext.Text = "&Find Next";
            ButtonFindNext.UseVisualStyleBackColor = true;
            ButtonFindNext.Click += ButtonFindNext_Click;
            // 
            // ButtonFindPrev
            // 
            ButtonFindPrev.Location = new Point(635, 85);
            ButtonFindPrev.Name = "ButtonFindPrev";
            ButtonFindPrev.Size = new Size(112, 34);
            ButtonFindPrev.TabIndex = 2;
            ButtonFindPrev.Text = "Find &Prev";
            ButtonFindPrev.UseVisualStyleBackColor = true;
            ButtonFindPrev.Click += ButtonFindPrev_Click;
            // 
            // CheckBoxMatchCase
            // 
            CheckBoxMatchCase.AutoSize = true;
            CheckBoxMatchCase.Location = new Point(70, 151);
            CheckBoxMatchCase.Name = "CheckBoxMatchCase";
            CheckBoxMatchCase.Size = new Size(126, 29);
            CheckBoxMatchCase.TabIndex = 3;
            CheckBoxMatchCase.Text = "Match &case";
            CheckBoxMatchCase.UseVisualStyleBackColor = true;
            CheckBoxMatchCase.CheckedChanged += CheckBoxMatchCase_CheckedChanged;
            // 
            // CheckBoxWrapAround
            // 
            CheckBoxWrapAround.AutoSize = true;
            CheckBoxWrapAround.Location = new Point(70, 186);
            CheckBoxWrapAround.Name = "CheckBoxWrapAround";
            CheckBoxWrapAround.Size = new Size(146, 29);
            CheckBoxWrapAround.TabIndex = 4;
            CheckBoxWrapAround.Text = "Wrap Around";
            CheckBoxWrapAround.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 62);
            label1.Name = "label1";
            label1.Size = new Size(89, 25);
            label1.TabIndex = 5;
            label1.Text = "Fi&nd what";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(RadioButtonDown);
            groupBox1.Controls.Add(RadioButtonUp);
            groupBox1.Location = new Point(260, 113);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(300, 110);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Direction";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // RadioButtonDown
            // 
            RadioButtonDown.AutoSize = true;
            RadioButtonDown.Checked = true;
            RadioButtonDown.Location = new Point(24, 81);
            RadioButtonDown.Name = "RadioButtonDown";
            RadioButtonDown.Size = new Size(84, 29);
            RadioButtonDown.TabIndex = 1;
            RadioButtonDown.TabStop = true;
            RadioButtonDown.Text = "Down";
            RadioButtonDown.UseVisualStyleBackColor = true;
            RadioButtonDown.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // RadioButtonUp
            // 
            RadioButtonUp.AutoSize = true;
            RadioButtonUp.Location = new Point(24, 45);
            RadioButtonUp.Name = "RadioButtonUp";
            RadioButtonUp.Size = new Size(60, 29);
            RadioButtonUp.TabIndex = 0;
            RadioButtonUp.Text = "Up";
            RadioButtonUp.UseVisualStyleBackColor = true;
            RadioButtonUp.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // ButtonCancel
            // 
            ButtonCancel.Location = new Point(637, 131);
            ButtonCancel.Name = "ButtonCancel";
            ButtonCancel.Size = new Size(112, 34);
            ButtonCancel.TabIndex = 7;
            ButtonCancel.Text = "Cancel";
            ButtonCancel.UseVisualStyleBackColor = true;
            ButtonCancel.Click += ButtonCancel_Click;
            // 
            // CheckBoxUseReg
            // 
            CheckBoxUseReg.AutoSize = true;
            CheckBoxUseReg.Enabled = false;
            CheckBoxUseReg.Location = new Point(70, 113);
            CheckBoxUseReg.Name = "CheckBoxUseReg";
            CheckBoxUseReg.Size = new Size(124, 29);
            CheckBoxUseReg.TabIndex = 8;
            CheckBoxUseReg.Text = "Use REGEX";
            CheckBoxUseReg.UseVisualStyleBackColor = true;
            // 
            // FindDialog
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(789, 235);
            Controls.Add(CheckBoxUseReg);
            Controls.Add(ButtonCancel);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(CheckBoxWrapAround);
            Controls.Add(CheckBoxMatchCase);
            Controls.Add(ButtonFindPrev);
            Controls.Add(ButtonFindNext);
            Controls.Add(TextBoxSearchText);
            Name = "FindDialog";
            Text = "Find";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TextBoxSearchText;
        private Button ButtonFindNext;
        private Button ButtonFindPrev;
        private CheckBox CheckBoxMatchCase;
        private CheckBox CheckBoxWrapAround;
        private Label label1;
        private GroupBox groupBox1;
        private RadioButton RadioButtonDown;
        private RadioButton RadioButtonUp;
        private Button ButtonCancel;
        private CheckBox CheckBoxUseReg;
    }
}