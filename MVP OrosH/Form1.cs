using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace MVP_OrosH
{
    public partial class Form1 : Form
    {
        List<Persoana> _listaPersoane = new List<Persoana>();
        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _listaPersoane.Clear();
            txtNume.Text = "";
            txtPrenume.Text = "";
            lstPersoane.Items.Clear();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult ret = MessageBox.Show(@"Do you really want to leave this application?", @"Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (ret == DialogResult.No)
                e.Cancel = true;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var a = new About();
            a.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string nume = txtNume.Text.Trim();
            string prenume = txtPrenume.Text.Trim();
            if (nume != "" && prenume != "")
            {
                var persoana = new Persoana(nume, prenume, monthCalendar1.SelectionStart);
                _listaPersoane.Add(persoana);
                lstPersoane.Items.Add(persoana);

                txtNume.Text = "";
                txtPrenume.Text = "";

                MessageBox.Show(@"Persoana a fost adaugata", @"Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show(@"Numele si prenumele sunt obligatorii", @"Atentie", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFileDialog.Filter = @"Persoane|*.prs";
            saveFileDialog.DefaultExt = ".prs";
            saveFileDialog.OverwritePrompt = true;
            DialogResult ret = saveFileDialog.ShowDialog();
            if (ret == DialogResult.OK)
            {
                string filename = saveFileDialog.FileName;
                try
                {
                    FileStream fs = File.Create(filename);
                    IFormatter formatter = new BinaryFormatter();

                    formatter.Serialize(fs, _listaPersoane);
                    fs.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show(@"Nu s-a creat fisierul", @"Mesaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            DialogResult ret = openFileDialog.ShowDialog();
            _listaPersoane = null;
            if (ret == DialogResult.OK)
            {
                string filename = openFileDialog.FileName;
                try
                {
                    var fs = new FileStream(filename, FileMode.Open);
                    IFormatter formatter = new BinaryFormatter();

                    _listaPersoane = (List<Persoana>)formatter.Deserialize(fs);
                    fs.Close();

                    txtNume.Text = "";
                    txtPrenume.Text = "";

                    foreach (var persoana in _listaPersoane)
                    {
                        lstPersoane.Items.Add(persoana);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show(@"Nu s-a deserializat fisierul", @"Mesaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void saveasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFileDialog.Filter = @"Persoane|*.prs|Text|*.txt|Rich Text Document|*.txt";
            DialogResult ret = saveFileDialog.ShowDialog();
            saveFileDialog.OverwritePrompt = true;
            if (ret == DialogResult.OK)
            {
                string filename = saveFileDialog.FileName;
                try
                {
                    FileStream fs = File.Create(filename);
                    IFormatter formatter = new BinaryFormatter();

                    formatter.Serialize(fs, _listaPersoane);
                    fs.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show(@"Nu s-a creat fisierul", @"Mesaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Ensure that text is currently selected in the text box
            if(txtNume.SelectedText.Length>0)
                txtNume.Copy();
            else if(txtPrenume.SelectedText.Length>0)
                txtPrenume.Copy();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Ensure that text is currently selected in the text box
            if (txtNume.SelectedText.Length > 0)
                txtNume.Cut();
            else if (txtPrenume.SelectedText.Length > 0)
                txtPrenume.Cut();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Determine if there is any text in the Clipboard to paste into the text box. 
            var dataObject = Clipboard.GetDataObject();
            if (dataObject == null || !dataObject.GetDataPresent(DataFormats.Text)) return;
            if (txtNume.Focused)
                txtNume.Paste();
            else if(txtPrenume.Focused)
                txtPrenume.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtNume.Focused)
                txtNume.SelectAll();
            else if (txtPrenume.Focused)
                txtPrenume.SelectAll();
        }
    }
}
