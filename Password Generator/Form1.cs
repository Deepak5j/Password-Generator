using System.Security.Cryptography;
using System.Text;
using static Password_Generator.Form1;

namespace Password_Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string digits = "0123456789";
            string charSmall = "abcdefghijklmnopqrstuvwxyz";
            string charCapital = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string charSpecial = "`~!@#$%^&*()_+-=[]{}|;:,.<>/?";
            string passCharString = "";
            int passwordLength = 0;
            int passwordQuantity = 0;
            bool charFlag = false, lenFlag = false, qtyFlag = false;

            if (checkBox1.Checked)
            {
                passCharString += digits;
                charFlag = true;
            }

            if (checkBox2.Checked)
            {
                passCharString += charSmall;
                charFlag = true;
            }

            if (checkBox3.Checked)
            {
                passCharString += charCapital;
                charFlag = true;
            }

            if (checkBox4.Checked)
            {
                passCharString += charSpecial;
                charFlag = true;
            }

            if (textBox1.Text.Length > 0)
            {
                int len;

                if (int.TryParse(textBox1.Text, out len))
                {
                    if (len < 0)
                    {
                        MessageBox.Show("Wrong password length. " +
                            "\nPassword lenght can not be negative. " +
                            "\nEnter a positive number!");
                    }
                    passwordLength = len;
                    lenFlag = true;

                }
                else
                {
                    MessageBox.Show("Wrong password length. " +
                        "\nPassword lenght can not be a string or charecter. " +
                        "\nEnter a positive number!");
                }
            }
            else
            {
                MessageBox.Show("Password lenght is not entered.");
            }

            if (textBox2.Text.Length > 0)
            {
                int qty;
                if (int.TryParse(textBox2.Text, out qty))
                {
                    if (qty < 0)
                    {
                        MessageBox.Show("Wrong password quantity. " +
                            "\nPassword quantity can not be negative. " +
                            "\nEnter a positive number!");
                    }
                    passwordQuantity = qty;
                    qtyFlag = true;
                }
                else
                {
                    MessageBox.Show("Wrong password quantity. " +
                        "\nPassword quantity can not be a string or charecter. " +
                        "\nEnter a positive number!");
                }
            }
            else
            {
                MessageBox.Show("Password quantity is not entered.");
            }

            if (charFlag && lenFlag && qtyFlag)
            {
                string validChars = passCharString;
                Random random = new Random();
                char[] chars = new char[passwordLength];
                string passwords = "";

                for (int i = 0; i < passwordQuantity; i++)
                {
                    for (int j = 0; j < passwordLength; j++)
                    {
                        chars[j] = validChars[random.Next(0, validChars.Length)];
                    }
                    passwords += new string(chars) + "\n";
                }
                richTextBox1.Text = passwords;
            }
            else
            {
                if (charFlag == false)
                {
                    MessageBox.Show("No charecter set is selected. " +
                        "Select atleast one charecter set.");
                }
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string txt = "";
            txt += "Password Generator\n\n";
            txt += "Deepak Gautam\n";
            txt += "Github: https://github.com/deepak5j/\n";
            txt += "Portfolio: https://deepak5j.bitbucket.io/\n";
            txt += "Youtube: https://www.youtube.com/@DeepakGautamX";

            MessageBox.Show(txt);
        }

        private void guidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string txt = "";
            txt += "Double click on a single password text in the YOUR PASSWORD SECTION and then\n";
            txt += "Press CTRL + C to copy the password and use it.\n\n";
            txt += "Press CTRL + A to select all the password and then \n";
            txt += "Press CTRL + C to copy the password and use it\n\n";
            txt += "Press CTRL + A to select all the password and then \n";
            txt += "Press CTRL + X to cut the password and use it\n";

            MessageBox.Show(txt);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.SelectedText);
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.SelectedText);
            richTextBox1.Text = "";

        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = Clipboard.GetText();
        }
    }


}