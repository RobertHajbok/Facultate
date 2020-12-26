using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace C7_8
{
    public partial class Form1 : Form
    {
        private int _nrLinii;
        readonly List<TextBox> _puteri = new List<TextBox>();
        readonly List<Label> _rezultat = new List<Label>();
        private double[] _f, _fd;
        private double[][] _matr;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Generate_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var label in _rezultat)
                {
                    label.Visible = false;
                }
                foreach (var textBox in _puteri)
                {
                    textBox.Visible = false;
                }
                _nrLinii = int.Parse(tb_LinesNr.Text) + 1;
                if (_nrLinii > 5 || _nrLinii < 4)
                {
                    MessageBox.Show(@"Polinomul poate fi de gradul 3 sau 4");
                    return;
                }
                for (var i = 0; i < _nrLinii; i++)
                {
                    var t = new TextBox
                    {
                        Parent = this,
                        Location = new Point(15 + i*80, 60),
                        Size = new Size(29, 29),
                        Visible = true
                    };
                    _puteri.Add(t);
                    
                    var l = new Label {Location = new Point(t.Right, 64)};
                    if (i != _nrLinii - 1)
                    {
                        l.Text = @"X^" + (_nrLinii - 1 - i) + @"+";
                    }
                    else
                    {
                        l.Text = @"X^" + (_nrLinii - 1 - i) + @" = 0";
                    }
                    l.AutoSize = true;
                    l.Parent = this;
                    l.Visible = true;
                    _rezultat.Add(l);
                }
                btn_Verify.Visible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void btn_Verify_Click(object sender, EventArgs e)
        {
            try
            {
                _f = new double[_nrLinii];
                if (_nrLinii == 4)
                    _matr = new double[_nrLinii + 1][];
                if (_nrLinii == 5)
                    _matr = new double[_nrLinii + 2][];
                _fd = new double[_nrLinii - 1];
                for (var i = 0; i < _nrLinii; i++)
                {
                    _f[i] = int.Parse(_puteri[i].Text);
                    if (i != _nrLinii - 1)
                        _fd[i] = _f[i] * (_nrLinii - i - 1);
                }
                

                var k = 0;
                for (var i = 0; i < (_nrLinii - 1) + (_nrLinii - 2); i++)
                {
                    if (_nrLinii == 4)
                        _matr[i] = new double[_nrLinii + 1];
                    if (_nrLinii == 5)
                        _matr[i] = new double[_nrLinii + 2];
                    if (i < _nrLinii - 2)
                    {
                        for (var j = 0; j < _nrLinii; j++)
                        {
                            _matr[i][j + k] = _f[j];
                        }
                        k++;
                    }
                    else
                    {
                        for (var j = 0; j < _nrLinii - 1; j++)
                        {
                            _matr[i][j + k - (_nrLinii - 2)] = _fd[j];
                        }
                        k++;
                    }
                }
                var tempMatr = new double[_matr.GetLength(0)][];
                for (var i = 0; i < _matr.GetLength(0); i++)
                {
                    tempMatr[i] = new double[_matr.GetLength(0)];
                    for (var j = 0; j < _matr.GetLength(0); j++)
                    {
                        tempMatr[i][j] = _matr[i][j];
                    }
                }
                var m = new Matrix(tempMatr, _matr.GetLength(0));

                var r = m.Determinant();
                // ReSharper disable once PossibleLossOfFraction
                var d = Math.Pow(-1, ((_nrLinii - 2) * (_nrLinii - 3) / 2)) * r;

                var ad = "";
                if (_nrLinii - 1 == 3)
                {
                    ad = EstePatratPerfect(d) ? "Grupul Galois asociat este A3" : "Grupul Galois asociat este S3";
                }
                if (_nrLinii - 1 == 4)
                {
                    var radacini = RealPolynomialRootFinder.FindRoots(1, -_matr[0][2], (_matr[0][1] * _matr[0][3]) - (4 * _matr[0][4]), -_matr[0][4] * (_matr[0][1] * _matr[0][1] - 4 * _matr[0][2]));
                    // ReSharper disable once CompareOfFloatsByEqualityOperator
                    var real = radacini.Any(complex => complex.Imaginary == 0);

                    if (real)
                    {
                        ad = EstePatratPerfect(d) ? "Grupul Galois asociat este B4" : "Grupul Galois asociat este B4 extins";
                    }
                    else
                    {
                        ad = EstePatratPerfect(d) ? "Grupul Galois asociat este A4" : "Grupul Galois asociat este S4";
                    }
                }

                var temp = new Label
                {
                    Text = @"R(f,fd)=" + r + Environment.NewLine + @"D(f)=" + d + Environment.NewLine + ad,
                    Location = new Point(15, 150),
                    AutoSize = true,
                    Parent = this
                };
                _rezultat.Add(temp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        static bool EstePatratPerfect(double d)
        {
            for (var i = 0; i <= (int)Math.Sqrt(d); i++)
            {
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                if (i * i == d)
                    return true;
            }
            return false;
        }
    }
}
