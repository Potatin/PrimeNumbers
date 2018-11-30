using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DesktopApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int totalHeight = button1.Height + textBox1.Height;

            // Set the vertical position of textbox1
            textBox1.Top = (ClientRectangle.Height >> 1) - (totalHeight >> 1);

            // Set the vertical position of button1
            button1.Top = ((ClientRectangle.Height >> 1) - (totalHeight >> 1)) + textBox1.Height;

            // Now set the horizontal positions
            textBox1.Left = (ClientRectangle.Width >> 1) - (textBox1.Width >> 1);
            button1.Left = (ClientRectangle.Width >> 1) - (button1.Width >> 1);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int ok = 1;
            try
            {
                long numar = Convert.ToInt64(textBox1.Text);
               


                for (long i = 2; i <= numar / 2; i++)
                {
                    if (numar % i == 0)

                    {
                        ok = 0;
                        i = numar;
                    }
                }
                if (ok == 0)
                 { this.BackColor = Color.FromArgb(255, 69, 0); textBox2.BackColor = Color.FromArgb(255, 69, 0); textBox2.Text = "That is NOT a prime number!"; }
                else
                 { this.BackColor = Color.FromArgb(65, 105, 255); textBox2.BackColor = Color.FromArgb(65, 105, 255); textBox2.Text = "That IS a prime number!"; }
            }
            catch(OverflowException)
            {
                MessageBox.Show("The number is WAYY too big!");
                textBox1.Text = textBox1.Text.Remove(textBox1.Lines.Length - 1);
                textBox2.Text = "Please write a smaller number!";
                this.BackColor = Color.FromArgb(255, 255, 255);
                textBox2.BackColor = Color.FromArgb(255, 255, 255);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox1.Text = textBox1.Text.Remove(textBox1.Lines.Length - 1);
            }
            var box = (TextBox)sender;
            if (box.Text.StartsWith("0")) box.Text = "";
        }
    }
}
