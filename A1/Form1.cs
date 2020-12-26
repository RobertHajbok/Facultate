using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace A1
{
    public partial class Form1 : Form
    {
        private int _nrLinii;
        private double[,] _matriceInitiala;
        private TextBox[,] _matriceInit, _matriceFin;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Generate_Click(object sender, EventArgs e)
        {
            try
            {
                if (_matriceInit != null)
                    foreach (var box in _matriceInit)
                    {
                        try
                        {
                            box.Visible = false;
                        }
                        catch
                        {
                            // ignored
                        }
                    }
                if (_matriceFin != null)
                    foreach (var box in _matriceFin)
                    {
                        try
                        {
                            box.Visible = false;
                        }
                        catch
                        {
                            // ignored
                        }
                    }
                _nrLinii = int.Parse(tb_LinesNr.Text);
                if (_nrLinii < 2)
                {
                    MessageBox.Show(@"Matricea trebuie sa aiba cel putin doua linii / coloane");
                    return;
                }
                _matriceInitiala = new double[_nrLinii, _nrLinii];
                _matriceInit = new TextBox[_nrLinii, _nrLinii];
                _matriceFin = new TextBox[_nrLinii, _nrLinii];
                AfiseazaMatricea();
            }
            catch
            {
                // ignored
            }
        }

        private void btn_Verify_Click(object sender, EventArgs e)
        {
            try
            {
                var transpuse = new double[_nrLinii, _nrLinii];

                for (var i = 0; i < _nrLinii; i++)
                {
                    for (var j = 0; j < _nrLinii; j++)
                    {
                        _matriceInitiala[i, j] = double.Parse(_matriceInit[i, j].Text);
                        transpuse[i, j] = double.Parse(_matriceInit[j, i].Text);
                    }
                }

                if (!EsteTriunghiulara(_matriceInitiala))
                {
                    MessageBox.Show(@"Matricea data trebuie sa fie triungiulara");
                    return;
                }

                var determinant = CalculeazaDeterminant(_matriceInitiala);
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                if (determinant == 0)
                {
                    MessageBox.Show(@"Determinantul este 0, matricea nu este inversabila");
                }
                else
                {
                    var adjuncta = new double[_nrLinii, _nrLinii];
                    if (_nrLinii == 2)
                    {
                        adjuncta[0, 0] = transpuse[1, 1];
                        adjuncta[0, 1] = -transpuse[1, 0];
                        adjuncta[1, 0] = -transpuse[0, 1];
                        adjuncta[1, 1] = transpuse[0, 0];
                    }
                    else
                    {
                        for (var h = 0; h < _nrLinii; h++)
                        {
                            for (var hh = 0; hh < _nrLinii; hh++)
                            {
                                var temp = new double[_nrLinii - 1, _nrLinii - 1];
                                var l = 0;
                                for (var i = 0; i < _nrLinii; i++)
                                {
                                    var k = 0;
                                    for (var j = 0; j < _nrLinii; j++)
                                    {
                                        if (h == i || hh == j) continue;
                                        temp[l, k] = transpuse[i, j];
                                        k++;
                                    }
                                    if (h != i)
                                        l++;
                                }
                                adjuncta[h, hh] = CalculeazaDeterminant(temp) * Math.Pow(-1, h + hh);
                            }
                        }
                    }
                    var matriceFinala = new double[_nrLinii, _nrLinii];

                    for (var i = 0; i < _nrLinii; i++)
                    {
                        for (var j = 0; j < _nrLinii; j++)
                        {
                            matriceFinala[i, j] = (Math.Truncate(adjuncta[i, j] / determinant * 100) / 100);
                        }
                    }


                    for (var i = 0; i < _nrLinii; i++)
                    {
                        for (var j = 0; j < _nrLinii; j++)
                        {
                            _matriceFin[i, j] = new TextBox
                            {
                                Location = new Point(btn_Verify.Location.X + j*40, 60 + i*25),
                                Size = new Size(35, 20),
                                Parent = this,
                                Visible = true,
                                Text = matriceFinala[i, j].ToString(CultureInfo.InvariantCulture)
                            };
                        }
                    }
                    MessageBox.Show(EsteTriunghiulara(matriceFinala)
                        ? "Matricea inversa este tot triunghiulara"
                        : "Matricea inversa NU este tot triunghiulara");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void AfiseazaMatricea()
        {
            for (var i = 0; i < _nrLinii; i++)
            {
                for (var j = 0; j < _nrLinii; j++)
                {
                    _matriceInit[i, j] = new TextBox
                    {
                        Location = new Point(15 + j * 30, 60 + i * 21),
                        Size = new Size(29, 29),
                        Parent = this,
                        Visible = true
                    };
                }
            }
            btn_Verify.Visible = true;
        }

        static bool EsteTriunghiulara(double[,] matr)
        {
            bool sup = true, inf = true;
            for (var i = 0; i < matr.GetLength(0); i++)
            {
                for (var j = 0; j < matr.GetLength(1); j++)
                {
                    // ReSharper disable once CompareOfFloatsByEqualityOperator
                    if (i > j && matr[i, j] != 0)
                        sup = false;
                    // ReSharper disable once CompareOfFloatsByEqualityOperator
                    if (i < j && matr[i, j] != 0)
                        inf = false;
                    // ReSharper disable once CompareOfFloatsByEqualityOperator
                    if (i != j || matr[i, j] != 0) continue;
                    inf = false;
                    sup = false;
                }
            }
            return inf ^ sup;
        }

        private static double CalculeazaDeterminant(double[,] matr)
        {
            if (matr.GetLength(0) == 2)
            {
                return matr[0, 0] * matr[1, 1] - matr[0, 1] * matr[1, 0];
            }
            var k = 0;
            double total = 0;
            for (var i = 0; i < matr.GetLength(0); i++)
            {

                double tempTotal = 1;
                for (var j = 0; j < matr.GetLength(0); j++)
                {
                    tempTotal *= matr[(j + k) % matr.GetLength(0), j];
                }
                total += tempTotal;
                k++;
            }
            k = 0;
            for (var i = 0; i < matr.GetLength(0); i++)
            {

                double tempTotal = 1;
                for (var j = 0; j < matr.GetLength(0); j++)
                {
                    tempTotal *= matr[(j + k) % matr.GetLength(0), (matr.GetLength(0) - 1) - j];
                }
                total -= tempTotal;
                k++;
            }
            return total;
        }
    }
}
