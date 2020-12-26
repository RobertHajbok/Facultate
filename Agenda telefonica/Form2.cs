using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Agenda_telefonica
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        bool image = false;

        private void button1_Click(object sender, EventArgs e)
        {
            if (appEngine.edit)
            {
                int i = 0;
                foreach (Contact c in appEngine.contacts)
                {
                    if (c == appEngine.contactsToShow[appEngine.listBox.SelectedIndex])
                        break;
                    i++;
                }
                if (!image)
                    appEngine.contactsToShow[appEngine.listBox.SelectedIndex] = new Contact(textBox1.Text, textBox2.Text, "N/A");
                else
                    appEngine.contactsToShow[appEngine.listBox.SelectedIndex] = new Contact(textBox1.Text, textBox2.Text, "NA");
                appEngine.contacts[i] = appEngine.contactsToShow[appEngine.listBox.SelectedIndex];
            }
            else
                if (!image)
                    appEngine.contacts.Add(new Contact(textBox1.Text, textBox2.Text, "N/A"));
                else
                    appEngine.contacts.Add(new Contact(textBox1.Text, textBox2.Text, "NA"));
            appEngine.sort();
            appEngine.loadListBox();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.gif;*.bmp;*.png;*.jpeg|All Files|*.*";
            DialogResult dialog = openFileDialog1.ShowDialog();
            if (dialog == System.Windows.Forms.DialogResult.OK)
            {
                appEngine.image = openFileDialog1.FileName;
                image = true;
            }
        }
    }
}
