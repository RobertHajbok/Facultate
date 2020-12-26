using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Agenda_telefonica
{
    public static class appEngine
    {
        public static Image imageMain = Image.FromFile(@"...\...\Image\main.jpg");
        public static Image imageAdmin = Image.FromFile(@"...\...\Image\admin.jpg");
        public static string image;
        public static List<Contact> contacts;
        public static List<Contact> contactsToShow;

        public static Panel panelMain;
        public static Button buttonAdmin;
        public static Label labelTitle;
        public static Label labelAuthor;

        public static Panel panelAdmin;
        public static ListBox listBox;
        public static PictureBox pictureBox;
        public static Button buttonAddContact;
        public static Label label;
        public static TextBox textBoxSearch;
        public static Button buttonEdit;
        public static Button buttonSave;
        public static Button buttonDelete;
        public static Label labelTitleAdmin;

        public static Graphics graphics;
        public static Bitmap bitmap;
        public static bool edit = false;

        public static void create(System.Windows.Forms.Control t)
        {
            contacts = new List<Contact>();
            contactsToShow = new List<Contact>();

            //Panoul Principal
            panelMain = new Panel();
            panelMain.Parent = t;
            panelMain.Location = new Point(0, 0);
            panelMain.Size = new Size(450, 350);
            panelMain.BackgroundImage = imageMain;
            panelMain.BackgroundImageLayout = ImageLayout.Stretch;

            labelTitle = new Label();
            labelTitle.Parent = panelMain;
            labelTitle.Location = new Point(120, 50);
            labelTitle.Text = "Agenda Telefonica";
            labelTitle.BackColor = Color.Transparent;
            labelTitle.Font = new Font(FontFamily.Families[3], 20, FontStyle.Bold);
            labelTitle.AutoSize = true;

            buttonAdmin = new Button();
            buttonAdmin.Parent = panelMain;
            buttonAdmin.Location = new Point(340, 220);
            buttonAdmin.Size = new Size(75, 50);
            buttonAdmin.Text = "Lanseaza";
            buttonAdmin.Click += new EventHandler(buttonAdmin_Click);

            //Panoul de administrare
            panelAdmin = new Panel();
            panelAdmin.Parent = t;
            panelAdmin.Location = new Point(0, 0);
            panelAdmin.Size = panelMain.Size;
            panelAdmin.BackgroundImage = imageAdmin;
            panelAdmin.BackgroundImageLayout = ImageLayout.Stretch;

            listBox = new ListBox();
            listBox.Parent = panelAdmin;
            listBox.Location = new Point(10, 50);
            listBox.Size = new Size(150, 200);
            listBox.SelectedIndexChanged += new EventHandler(listBox_SelectedIndexChanged);
            listBox.Font = new Font("Consolas", 8);

            labelTitleAdmin = new Label();
            labelTitleAdmin.Parent = panelAdmin;
            labelTitleAdmin.Location = new Point(150, 10);
            labelTitleAdmin.Text = "Agenda Telefonica";
            labelTitleAdmin.BackColor = Color.Transparent;
            labelTitleAdmin.ForeColor = Color.Honeydew;
            labelTitleAdmin.Font = new Font(FontFamily.Families[3], 13, FontStyle.Bold);
            labelTitleAdmin.AutoSize = true;

            pictureBox = new PictureBox();
            pictureBox.Parent = panelAdmin;
            pictureBox.Location = new Point(listBox.Location.X + listBox.Width + 10, listBox.Location.Y);
            pictureBox.Size = new Size(250, 200);
            pictureBox.BorderStyle = BorderStyle.FixedSingle;

            buttonAddContact = new Button();
            buttonAddContact.Parent = panelAdmin;
            buttonAddContact.Location = new Point(listBox.Location.X, listBox.Location.Y + listBox.Height + 10);
            buttonAddContact.Click += new EventHandler(buttonAddContact_Click);
            buttonAddContact.Text = "Adauga contact";
            buttonAddContact.AutoSize = true;

            buttonEdit = new Button();
            buttonEdit.Parent = panelAdmin;
            buttonEdit.Location = new Point(buttonAddContact.Location.X + buttonAddContact.Width + 10, buttonAddContact.Location.Y);
            buttonEdit.Text = "Editeaza";
            buttonEdit.Click += new EventHandler(buttonEdit_Click);

            buttonSave = new Button();
            buttonSave.Parent = panelAdmin;
            buttonSave.Location = new Point(buttonEdit.Location.X + buttonEdit.Width + 10, buttonEdit.Location.Y);
            buttonSave.Text = "Salveaza";
            buttonSave.Click += new EventHandler(buttonSave_Click);

            buttonDelete = new Button();
            buttonDelete.Parent = panelAdmin;
            buttonDelete.Location = new Point(buttonSave.Location.X + buttonSave.Width + 10, buttonSave.Location.Y);
            buttonDelete.Text = "Sterge";
            buttonDelete.Click += new EventHandler(buttonDelete_Click);

            label = new Label();
            label.Parent = panelAdmin;
            label.Location = new Point(buttonAddContact.Location.X, buttonAddContact.Location.Y + buttonAddContact.Height + 10);
            label.Text = "Cautare:";
            label.AutoSize = true;
            label.BackColor = Color.Transparent;
            label.ForeColor = Color.Gray;

            textBoxSearch = new TextBox();
            textBoxSearch.Parent = panelAdmin;
            textBoxSearch.Location = new Point(label.Location.X + label.Width, label.Location.Y);
            textBoxSearch.TextChanged += new EventHandler(textBoxSearch_TextChanged);

            bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.Gray);

            pictureBox.Image = bitmap;

            readFromFile();
        }

        static void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex != -1)
            {
                int i = 0;
                foreach (Contact c in contacts)
                {
                    if (c == contactsToShow[listBox.SelectedIndex])
                    {
                        contacts.RemoveAt(listBox.SelectedIndex);
                        break;
                    }
                    i++;
                }
                contactsToShow.RemoveAt(i);
                loadListBox();
            }
            else
                MessageBox.Show("Va rugam sa selectati un contact");

        }
        static void buttonSave_Click(object sender, EventArgs e)
        {
            TextWriter data = new StreamWriter(@"...\...\Data.txt");

            /*
            string s;
            int i = 0;
            foreach (Contact c in contacts)
            {
                if (c.imgSrc != "" && c.imgSrc != "NA" && c.imgSrc != "N/A")
                {
                    s = c.imgSrc;
                    string[] ss = s.Split('.');
                    if (i < int.Parse(ss[0]))
                        i = int.Parse(ss[0]);
                }
            }
            foreach (Contact c in contacts)
            {
                if(c.imgSrc == "NA")

            }
             */
            foreach (Contact c in contacts)
            {
                data.WriteLine(c.name + ";" + c.number + ";" + c.imgSrc);
            }
            data.Close();
        }
        static void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex != -1)
            {
                edit = true;
                Form2 form2 = new Form2();
                form2.ShowDialog();
            }
            else
                MessageBox.Show("Va rugam sa alegeti un contact");
        }
        static void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex > -1)
            {
                graphics.Clear(Color.Gray);
                if (contactsToShow[listBox.SelectedIndex].image != null)
                    graphics.DrawImage(contactsToShow[listBox.SelectedIndex].image, new Rectangle(0, 0, pictureBox.Width, pictureBox.Height), 0, 0, contactsToShow[listBox.SelectedIndex].image.Width, contactsToShow[listBox.SelectedIndex].image.Height, GraphicsUnit.Pixel);
                pictureBox.Image = bitmap;
            }
        }
        static void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            contactsToShow.Clear();
            listBox.Items.Clear();
            foreach (Contact c in contacts)
            {
                int k = 0;
                if (textBoxSearch.Text.Length != 0)
                    for (int i = 0; i < c.name.Length; i++)
                        if (identicCharacters(c.name[i], textBoxSearch.Text[k]))
                        {
                            k++;
                            if (k == textBoxSearch.Text.Length)
                                break;
                        }
                        else
                            k = 0;
                if (k == textBoxSearch.Text.Length)
                {
                    contactsToShow.Add(c);
                    listBox.Items.Add(space13(c.name, c.number));
                }
            }
        }
        static void buttonAddContact_Click(object sender, EventArgs e)
        {
            edit = false;
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
        static void buttonAdmin_Click(object sender, EventArgs e)
        {
            panelAdmin.Visible = true;
            panelMain.Visible = false;
        }
        static public void loadListBox()
        {
            contactsToShow.Clear();
            listBox.Items.Clear();
            foreach (Contact c in contacts)
            {
                contactsToShow.Add(c);
                listBox.Items.Add(space13(c.name, c.number));
            }
            textBoxSearch.Text = "";
        }
        static void readFromFile()
        {
            TextReader data = new StreamReader(@"...\...\Data.txt");
            string s;
            while ((s = data.ReadLine()) != null)
            {
                string[] ss = s.Split(';');
                contacts.Add(new Contact(ss[0], ss[1], ss[2]));
            }
            sort();
            loadListBox();
            data.Close();
        }
        static bool identicCharacters(char a, char b)
        {
            if (a == b)
                return true;
            if (a >= 'a' && a <= 'z' && b >= 'A' && b <= 'Z')
                if (b == a - ('a' - 'A'))
                    return true;
            if (b >= 'a' && b <= 'z' && a >= 'A' && a <= 'Z')
                if (a == b - ('a' - 'A'))
                    return true;
            return false;
        }
        static string space13(string s0, string s1)
        {
            int x = 13;
            string s = "";
            int i = 0;
            if (s0.Length > x)
            {
                foreach (char c in s0)
                {
                    s += c;
                    if (i == x - 4)
                        break;
                    i++;
                }
                return s + "... " + s1;
            }
            else
            {
                s = s0;
                while (s.Length < x)
                    s += " ";
                return s + " " + s1;
            }
        }
        public static void sort()
        {
            Contact aux;
            for (int i = 0; i < contacts.Count - 1; i++)
                for (int j = i + 1; j < contacts.Count; j++)
                    if (string.Compare(contacts[i].name, contacts[j].name) == 1)
                    {
                        aux = contacts[i];
                        contacts[i] = contacts[j];
                        contacts[j] = aux;
                    }
        }
    }
}
