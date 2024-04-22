using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightningNote
{
    public partial class FindDialog : Form
    {
        public FindDialog()
        {
            InitializeComponent();
        }

        int last_found = -1;
        void find(bool ForcePrev)
        {
            int result = 0;
            MainWindow own = Owner as MainWindow;
            RichTextBoxFinds flags = RichTextBoxFinds.None;
            int start, stop;
            if (ForcePrev)
                flags |= RichTextBoxFinds.Reverse;
            if (own != null)
            {
                if (last_found != -1)
                {
                    start = last_found + 1;
                }
                else
                {
                    start = 0;
                }

                stop = -1;
                result = own.RichTextBoxText.Find(TextBoxSearchText.Text, start, stop, flags);
                if (result == -1)
                {
                    if (CheckBoxWrapAround.Checked)
                    {
                        result = own.RichTextBoxText.Find(TextBoxSearchText.Text, flags);
                    }
                }

                if (result != -1)
                {
                    own.RichTextBoxText.SelectionStart = result;
                    last_found = result;
                }
                else
                {
                    MessageBox.Show($"Did not find text: \"{TextBoxSearchText.Text}\"");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void CheckBoxMatchCase_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ButtonFindNext_Click(object sender, EventArgs e)
        {
            find(false);
        }

        private void ButtonFindPrev_Click(object sender, EventArgs e)
        {
            find(true);
        }

        private void TextBoxSearchText_TextChanged(object sender, EventArgs e)
        {
            last_found = -1;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

