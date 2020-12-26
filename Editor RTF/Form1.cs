using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Editor_RTF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Deschide fisier";
            openFileDialog1.Filter = "Fisiere Rich Text (*.rtf)|*.rtf";
            openFileDialog1.FileName = "";
            openFileDialog1.InitialDirectory = "MyDocuments";
            openFileDialog1.CheckFileExists = true;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.LoadFile(openFileDialog1.FileName);
            }
        }

        private void deschideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Deschide fisier";
            openFileDialog1.Filter = "Fisiere Rich Text (*.rtf)|*.rtf";
            openFileDialog1.FileName = "";
            openFileDialog1.InitialDirectory = "MyDocuments";
            openFileDialog1.CheckFileExists = true;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.LoadFile(openFileDialog1.FileName);
            }
        }

        private void salveazaCaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Salveaza fisierul";
            saveFileDialog1.DefaultExt = ".rtf";
            saveFileDialog1.OverwritePrompt = true;
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);
                //metoda SaveFile salveaza pe disc textul controlului intr-un fisier cu formatul rtf
            }
        }

        private void iesireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //portiunea selectata din text preia caracteristicile alese de utilizator
                richTextBox1.SelectionFont = fontDialog1.Font;
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDialog1.Font;
            }
        }

        private void culoareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.SelectionColor = colorDialog1.Color;
            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.SelectionColor = colorDialog1.Color;
            }
        }

        private void bulletButton_Click(object sender, EventArgs e)
        {
            //daca butonul este apasat atunci textului selectat nu i se aplica stilul bullet
            if (bulletButton.Checked)
                richTextBox1.SelectionBullet = false;
            else
                richTextBox1.SelectionBullet = true;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Salveaza fisierul";
            saveFileDialog1.DefaultExt = ".rtf";
            saveFileDialog1.OverwritePrompt = true;
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);
            }
        }

        private void nouToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.Text);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.Text);
            richTextBox1.Text = "";
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = richTextBox1.Text.Insert(richTextBox1.SelectionStart, Clipboard.GetText());
        }
    }
}