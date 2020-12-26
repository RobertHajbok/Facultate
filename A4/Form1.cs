using System;
using System.Drawing;
using System.Windows.Forms;

namespace A4
{
    public partial class Form1 : Form
    {
        private int _nrLinii;
        private TextBox[,] _matriceInitiala, _matriceTranspusa;
        private Complex[,] _matriceInit, _matriceTrans;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Verify_Click(object sender, EventArgs e)
        {
            try
            {
                for (var i = 0; i < _nrLinii; i++)
                {
                    for (var j = 0; j < _nrLinii; j++)
                    {
                        _matriceInit[i, j] = new Complex(_matriceInitiala[i, j].Text);
                    }
                }
                for (var i = 0; i < _nrLinii; i++)
                {
                    for (var j = 0; j < _nrLinii; j++)
                    {
                        if (_matriceTranspusa[i, j] != null)
                            _matriceTranspusa[i, j].Dispose();
                        _matriceTrans[i, j] = (Complex)_matriceInit[j, i].Clone();
                        _matriceTrans[i, j].Invert();
                    }
                }

                AfiseazaMatricea(_matriceInitiala[_nrLinii - 1, _nrLinii - 1].Right + 40, _matriceTranspusa);

                for (var i = 0; i < _nrLinii; i++)
                {
                    for (var j = 0; j < _nrLinii; j++)
                    {
                        _matriceTranspusa[i, j].Text = _matriceTrans[i, j].ToString();
                    }
                }

                var ok = true;
                for (var i = 0; i < _nrLinii; i++)
                {
                    for (var j = 0; j < _nrLinii; j++)
                    {
                        if (_matriceInit[i, j] == _matriceTrans[i, j]) continue;
                        ok = false;
                        break;
                    }
                }
                MessageBox.Show(ok ? "Matricea este hermitica" : "Matricea NU este hermitica");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void btn_Generate_Click(object sender, EventArgs e)
        {
            try
            {
                if (_matriceInitiala != null)
                    foreach (var box in _matriceInitiala)
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
                if (_matriceTranspusa != null)
                    foreach (var box in _matriceTranspusa)
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
                _matriceInit = new Complex[_nrLinii, _nrLinii];
                _matriceTrans = new Complex[_nrLinii, _nrLinii];
                _matriceInitiala = new TextBox[_nrLinii, _nrLinii];
                _matriceTranspusa = new TextBox[_nrLinii, _nrLinii];

                AfiseazaMatricea(15, _matriceInitiala);
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
    }
}
