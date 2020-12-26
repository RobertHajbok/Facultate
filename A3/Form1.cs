using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace A3
{
    public partial class Form1 : Form
    {
        private Label _adunare, _egal;
        private int _nrLinii;
        private double[,] _matriceInitiala, _matriceFinala1, _matriceFinala2;
        private TextBox[,] _matriceInit, _matriceFin1, _matriceFin2;

        private void btn_Verify_Click(object sender, EventArgs e)
        {
            try
            {
                for (var i = 0; i < _nrLinii; i++)
                {
                    for (var j = 0; j < _nrLinii; j++)
                    {
                        _matriceInitiala[i, j] = double.Parse(_matriceInit[i, j].Text);
                        if(_matriceFin1[i, j] != null)
                            _matriceFin1[i, j].Dispose();
                        if (_matriceFin2[i, j] != null)
                            _matriceFin2[i, j].Dispose();
                    }
                }
                _egal?.Dispose();
                _adunare?.Dispose();
                for (var i = 0; i < _nrLinii; i++)
                {
                    _matriceFinala1[i, i] = _matriceInitiala[i, i];
                    _matriceFinala2[i, i] = 0;
                }

                for (var i = 0; i < _nrLinii; i++)
                {
                    for (var j = i + 1; j < _nrLinii; j++)
                    {
                        double temp1, temp2;
                        CalculeazaElemtele(_matriceInitiala[i, j], _matriceInitiala[j, i], out temp1, out temp2);
                        _matriceFinala1[i, j] = temp1;
                        _matriceFinala1[j, i] = temp1;
                        _matriceFinala2[i, j] = temp2;
                        _matriceFinala2[j, i] = -temp2;
                    }
                }

                _egal = new Label
                {
                    Location = new Point(_matriceInit[_nrLinii - 1, _nrLinii - 1].Right + 17,
                            (_matriceInit[0, _nrLinii - 1].Top + _matriceInit[_nrLinii - 1, _nrLinii - 1].Bottom)/2 - 8),
                    Text = @"=",
                    AutoSize = true,
                    Parent = this
                };
                AfiseazaMatricea(_matriceInit[_nrLinii - 1, _nrLinii - 1].Right + 45, _matriceFin1);
                _adunare = new Label
                {
                    Location = new Point(_matriceFin1[_nrLinii - 1, _nrLinii - 1].Right + 17,
                            (_matriceFin1[0, _nrLinii - 1].Top + _matriceFin1[_nrLinii - 1, _nrLinii - 1].Bottom)/2 - 8),
                    Text = @"+",
                    AutoSize = true,
                    Parent = this
                };
                AfiseazaMatricea(_matriceFin1[_nrLinii - 1, _nrLinii - 1].Right + 45, _matriceFin2);

                for (var i = 0; i < _nrLinii; i++)
                {
                    for (var j = 0; j < _nrLinii; j++)
                    {
                        _matriceFin1[i, j].Text = _matriceFinala1[i, j].ToString(CultureInfo.InvariantCulture);
                        _matriceFin2[i, j].Text = _matriceFinala2[i, j].ToString(CultureInfo.InvariantCulture);
                    }
                }

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
                _adunare?.Hide();
                _egal?.Hide();
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
                if (_matriceFin1 != null)
                    foreach (var box in _matriceFin1)
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
                if (_matriceFin2 != null)
                    foreach (var box in _matriceFin2)
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
                _matriceInitiala = new double[_nrLinii, _nrLinii];
                _matriceFinala1 = new double[_nrLinii, _nrLinii];
                _matriceFinala2 = new double[_nrLinii, _nrLinii];
                _matriceInit = new TextBox[_nrLinii, _nrLinii];
                _matriceFin1 = new TextBox[_nrLinii, _nrLinii];
                _matriceFin2 = new TextBox[_nrLinii, _nrLinii];

                AfiseazaMatricea(15, _matriceInit);
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

        public void CalculeazaElemtele(double x1, double x2, out double nec1, out double nec2)
        {
            nec1 = (x1 + x2) / 2;
            nec2 = x1 - nec1;
        }
    }
}
