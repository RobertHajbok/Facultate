using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace A2
{
    public partial class Form1 : Form
    {
        private int _nrLinii;
        private double[,] _matriceInitiala1, _matriceInitiala2, _matriceFinala;
        private Label _inmultire, _egal;
        private TextBox[,] _matriceInit1, _matriceInit2, _matriceFin;

        private void btn_Verify_Click(object sender, EventArgs e)
        {
            try
            {
                for (var i = 0; i < _nrLinii; i++)
                {
                    for (var j = 0; j < _nrLinii; j++)
                    {
                        _matriceInitiala1[i, j] = double.Parse(_matriceInit1[i, j].Text);
                        _matriceInitiala2[i, j] = double.Parse(_matriceInit2[i, j].Text);
                    }
                }
                if (!EsteTriunghiulara(_matriceInitiala1))
                {
                    MessageBox.Show(@"Prima matrice nu este triunghiulara");
                    return;
                }
                if (!EsteTriunghiulara(_matriceInitiala2))
                {
                    MessageBox.Show(@"A doua matrice nu este triunghiulara");
                    return;
                }
                _matriceFinala = Inmultire(_matriceInitiala1, _matriceInitiala2);
                for (var i = 0; i < _nrLinii; i++)
                {
                    for (var j = 0; j < _nrLinii; j++)
                    {
                        _matriceFin[i, j].Text = _matriceFinala[i, j].ToString(CultureInfo.InvariantCulture);
                    }
                }
                MessageBox.Show(EsteTriunghiulara(_matriceFinala)
                    ? "Produsul este tot o matrice triunghiulara"
                    : "Produsul NU este o matrice triunghiulara");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Generate_Click(object sender, EventArgs e)
        {
            try
            {
                _inmultire?.Hide();
                _egal?.Hide();

                if (_matriceInit1 != null)
                    foreach (var box in _matriceInit1)
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
                if (_matriceInit2 != null)
                    foreach (var box in _matriceInit2)
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
                    MessageBox.Show(@"Matricile trebuie sa aiba cel putin doua linii / coloane");
                    return;
                }
                _matriceInitiala1 = new double[_nrLinii, _nrLinii];
                _matriceInitiala2 = new double[_nrLinii, _nrLinii];
                _matriceFinala = new double[_nrLinii, _nrLinii];
                _matriceInit1 = new TextBox[_nrLinii, _nrLinii];
                _matriceInit2 = new TextBox[_nrLinii, _nrLinii];
                _matriceFin = new TextBox[_nrLinii, _nrLinii];

                AfiseazaMatricea(15, _matriceInit1);
                _inmultire = new Label
                {
                    Location = new Point(_matriceInit1[_nrLinii - 1, _nrLinii - 1].Right + 17,
                            (_matriceInit1[0, _nrLinii - 1].Top + _matriceInit1[_nrLinii - 1, _nrLinii - 1].Bottom) / 2 - 8),
                    Text = @"*",
                    AutoSize = true,
                    Parent = this
                };
                AfiseazaMatricea(_matriceInit1[_nrLinii - 1, _nrLinii - 1].Right + 45, _matriceInit2);
                _egal = new Label
                {
                    Location = new Point(_matriceInit2[_nrLinii - 1, _nrLinii - 1].Right + 17,
                            (_matriceInit2[0, _nrLinii - 1].Top + _matriceInit2[_nrLinii - 1, _nrLinii - 1].Bottom) / 2 - 8),
                    Text = @"=",
                    AutoSize = true,
                    Parent = this
                };
                AfiseazaMatricea(_matriceInit2[_nrLinii - 1, _nrLinii - 1].Right + 45, _matriceFin);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void AfiseazaMatricea(int x, TextBox[,] matrice)
        {
            for (var i = 0; i < _nrLinii; i++)
            {
                for (var j = 0; j < _nrLinii; j++)
                {
                    matrice[i, j] = new TextBox
                    {
                        Location = new Point(x + j * 30, 60 + i * 25),
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

        private double[,] Inmultire(double[,] matriceSt, double[,] matriceDr)
        {

            var matrTemp = new double[_nrLinii, _nrLinii];
            for (var i = 0; i < _nrLinii; i++)
            {
                for (var j = 0; j < _nrLinii; j++)
                {

                    double temp = 0;
                    for (var k = 0; k < _nrLinii; k++)
                    {
                        temp += matriceSt[i, k] * matriceDr[k, j];
                    }
                    matrTemp[i, j] = temp;
                }
            }
            return matrTemp;
        }
    }
}
