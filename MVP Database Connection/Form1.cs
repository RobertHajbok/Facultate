using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MVP_Database_Connection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Initialize();
        }

        Button _btnShow;
        DataGridView _dgvProperties;

        public void Initialize()
        {
            _btnShow = new Button {Text = @"Show", Location = new System.Drawing.Point(12, 12)};
            _btnShow.Click += BtnShowClicked;
            _dgvProperties = new DataGridView
            {
                Location = new System.Drawing.Point(12, 44),
                Anchor = AnchorStyles.Left | AnchorStyles.Top |
                         AnchorStyles.Right | AnchorStyles.Bottom,
                Size = new System.Drawing.Size(540, 280)
            };

            StartPosition = FormStartPosition.CenterScreen;
            //   Size = new System.Drawing.Size(275, 235);

            Controls.Add(_btnShow);
            Controls.Add(_dgvProperties);
        }

        private void GetData(string query)
        {
            using (var scnStudenti = new SqlConnection("Data Source=ROBI-PC;Integrated Security=True;Database=Facultate"))
            {

                var cmdProperties = new SqlCommand(query, scnStudenti);

                var sdaProperties = new SqlDataAdapter();
                var dsProperties = new DataSet("Rezultat");

                scnStudenti.Open();

                sdaProperties.SelectCommand = cmdProperties;
                sdaProperties.Fill(dsProperties);

                _dgvProperties.DataSource = dsProperties.Tables[0];
            }
        }

        private void BtnShowClicked(object sender, EventArgs e)
        {
            GetData(
                "SELECT Student.[nr_matricol], Student.[nume], Student.[prenume], PlanInvatamant.[denumire_disciplina], c1.[nota] AS 'nota 1', c2.[nota] AS 'nota 2', c3.[nota] AS 'nota 3' FROM Catalogul AS c LEFT JOIN Catalogul AS c1 ON c1.[cod] = c.[cod] and c1.[nr_matricol] = c.[nr_matricol] and c1.[nr_examinari] = 1 LEFT JOIN Catalogul AS c2 ON c2.[cod] = c.[cod] and c2.[nr_matricol] = c.[nr_matricol] and c2.[nr_examinari] = 2 LEFT JOIN Catalogul AS c3 ON c3.[cod] = c.[cod] and c3.[nr_matricol] = c.[nr_matricol] and c3.[nr_examinari] = 3 JOIN PlanInvatamant ON c.[cod] = PlanInvatamant.[cod] JOIN Student ON c.[nr_matricol] = Student.[nr_matricol] GROUP BY Student.[nr_matricol], Student.[nume], Student.[prenume], PlanInvatamant.[denumire_disciplina], c1.nota, c2.nota, c3.nota");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            GetData(
                "SELECT Student.[nr_matricol], Student.[nume], Student.[prenume], PlanInvatamant.[denumire_disciplina], c1.[nota] AS 'nota 1', c2.[nota] AS 'nota 2', c3.[nota] AS 'nota 3' FROM Catalogul AS c LEFT JOIN Catalogul AS c1 ON c1.[cod] = c.[cod] and c1.[nr_matricol] = c.[nr_matricol] and c1.[nr_examinari] = 1 LEFT JOIN Catalogul AS c2 ON c2.[cod] = c.[cod] and c2.[nr_matricol] = c.[nr_matricol] and c2.[nr_examinari] = 2 LEFT JOIN Catalogul AS c3 ON c3.[cod] = c.[cod] and c3.[nr_matricol] = c.[nr_matricol] and c3.[nr_examinari] = 3 JOIN PlanInvatamant ON c.[cod] = PlanInvatamant.[cod] JOIN Student ON c.[nr_matricol] = Student.[nr_matricol] GROUP BY Student.[nr_matricol], Student.[nume], Student.[prenume], PlanInvatamant.[denumire_disciplina], c1.nota, c2.nota, c3.nota ORDER BY Student.[nume]");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            GetData(
                 "SELECT Student.[nr_matricol], Student.[nume], Student.[prenume], PlanInvatamant.[denumire_disciplina], c1.[nota] AS 'nota 1', c2.[nota] AS 'nota 2', c3.[nota] AS 'nota 3' FROM Catalogul AS c LEFT JOIN Catalogul AS c1 ON c1.[cod] = c.[cod] and c1.[nr_matricol] = c.[nr_matricol] and c1.[nr_examinari] = 1 LEFT JOIN Catalogul AS c2 ON c2.[cod] = c.[cod] and c2.[nr_matricol] = c.[nr_matricol] and c2.[nr_examinari] = 2 LEFT JOIN Catalogul AS c3 ON c3.[cod] = c.[cod] and c3.[nr_matricol] = c.[nr_matricol] and c3.[nr_examinari] = 3 JOIN PlanInvatamant ON c.[cod] = PlanInvatamant.[cod] JOIN Student ON c.[nr_matricol] = Student.[nr_matricol] GROUP BY Student.[nr_matricol], Student.[nume], Student.[prenume], PlanInvatamant.[denumire_disciplina], c1.nota, c2.nota, c3.nota ORDER BY Student.[nr_matricol]");
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            GetData(
                 "SELECT Student.[nr_matricol], Student.[nume], Student.[prenume], PlanInvatamant.[denumire_disciplina], c1.[nota] AS 'nota 1', c2.[nota] AS 'nota 2', c3.[nota] AS 'nota 3' FROM Catalogul AS c LEFT JOIN Catalogul AS c1 ON c1.[cod] = c.[cod] and c1.[nr_matricol] = c.[nr_matricol] and c1.[nr_examinari] = 1 LEFT JOIN Catalogul AS c2 ON c2.[cod] = c.[cod] and c2.[nr_matricol] = c.[nr_matricol] and c2.[nr_examinari] = 2 LEFT JOIN Catalogul AS c3 ON c3.[cod] = c.[cod] and c3.[nr_matricol] = c.[nr_matricol] and c3.[nr_examinari] = 3 JOIN PlanInvatamant ON c.[cod] = PlanInvatamant.[cod] JOIN Student ON c.[nr_matricol] = Student.[nr_matricol] GROUP BY Student.[nr_matricol], Student.[nume], Student.[prenume], PlanInvatamant.[denumire_disciplina], c1.nota, c2.nota, c3.nota ORDER BY PlanInvatamant.[denumire_disciplina]");
        }
    }
}
