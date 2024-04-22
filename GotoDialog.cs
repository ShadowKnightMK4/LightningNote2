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
    public partial class GotoDialog : Form
    {
        public GotoDialog()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ButtonGoto_Click(object sender, EventArgs e)
        {
            MainWindow own = Owner as MainWindow;
            if (own != null)
            {
                int line=-1;
                if (int.TryParse(TextBoxSelectLine.Text, out line))
                {
                    int charindex=-2;
                    try
                    {
                        charindex = own.RichTextBoxText.GetFirstCharIndexFromLine(line);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        MessageBox.Show($"That line {line} is out the the expected range. You either entered a negative number a number larger than the line count");
                    }
                    if (charindex != -2)
                    {
                        own.RichTextBoxText.Select(charindex, 0);
                        own.RichTextBoxText.ScrollToCaret();
                    }
                }

            }
        }
    }
}
