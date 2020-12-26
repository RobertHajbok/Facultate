using System;
using System.Windows.Forms;

namespace RecaptchaV2.NET
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show(@"Please provide google site key!");
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show(@"Please provide google secret key!");
                return;
            }

            Recaptcha recaptcha = new Recaptcha(textBox1.Text, textBox2.Text);
            textBox3.Text = recaptcha.GetSecureTokenHTML();
        }
    }
}
