using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace B5_6
{
    public partial class Form1 : Form
    {
        private int _nrLinii;
        private TextBox[,] _matriceInitiala;
        private double[,] _matriceInit;
        readonly ListBox _listaRadacini = new ListBox();
        readonly List<TextBox> _polinom = new List<TextBox>();
        readonly List<Label> _puteri = new List<Label>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Generate_Click(object sender, EventArgs e)
        {
            try
            {
                _listaRadacini.Visible = false;
                foreach (var textBox in _polinom)
                {
                    textBox.Visible = false;
                }
                foreach (var label in _puteri)
                {
                    label.Visible = false;
                }
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
                _nrLinii = int.Parse(tb_LinesNr.Text);
                if (_nrLinii < 2)
                {
                    MessageBox.Show(@"Matricea trebuie sa aiba cel putin doua linii / coloane");
                    return;
                }
                _matriceInitiala = new TextBox[_nrLinii, _nrLinii];
                _matriceInit = new double[_nrLinii, _nrLinii];
                AfiseazaMatricea(15, _matriceInitiala);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void AfiseazaMatricea(int x, TextBox[,] matrix)
        {
            for (var i = 0; i < _nrLinii; i++)
            {
                for (var j = 0; j < _nrLinii; j++)
                {
                    matrix[i, j] = new TextBox
                    {
                        Location = new Point(x + j*30, 60 + i*25),
                        Size = new Size(29, 29),
                        Parent = this,
                        Visible = true
                    };
                }
            }
            btn_Verify.Visible = true;
        }

        private void btn_Verify_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var textBox in _polinom)
                {
                    textBox.Visible = false;
                }
                foreach (var label in _puteri)
                {
                    label.Visible = false;
                }
                for (var i = 0; i < _nrLinii; i++)
                {
                    for (var j = 0; j < _nrLinii; j++)
                    {
                        _matriceInit[i, j] = double.Parse(_matriceInitiala[i, j].Text);
                    }
                }
                double[] puteri;
                if (_nrLinii == 2)
                {
                    puteri = new double[3];
                    puteri[0] = 1;
                    puteri[1] = -(_matriceInit[0, 0] + _matriceInit[1, 1]);
                    puteri[2] = _matriceInit[0, 0] * _matriceInit[1, 1] - (_matriceInit[0, 0] * _matriceInit[1, 1]);
                    AfiseazaPuteri(puteri);
                }
                else
                {
                    var diagonala = new double[_nrLinii];
                    for (var i = 0; i < _nrLinii; i++)
                    {
                        diagonala[i] = _matriceInit[i, i];
                    }
                    puteri = Functie(diagonala);
                    for (var i = 0; i < _nrLinii; i++)
                    {
                        var nespeciale = new List<double>();
                        double special = 0;
                        for (var j = 0; j < _nrLinii; j++)
                        {
                            if ((i + j) % _nrLinii == _nrLinii - 1 - j)
                                special = _matriceInit[_nrLinii - 1 - j, _nrLinii - 1 - j];
                            else
                            {
                                nespeciale.Add(_matriceInit[Verificare((i + j) % _nrLinii), Verificare((_nrLinii - 1 - j) % _nrLinii)]);
                            }
                        }
                        double putere1, putere0;
                        CalculareSpeciala(nespeciale, special, out putere1, out putere0);
                        puteri[puteri.Length - 1] -= putere0;
                        puteri[puteri.Length - 2] += putere1;
                    }

                    if (_nrLinii > 2)
                        for (var i = 1; i < _nrLinii; i++)
                        {
                            double temp = 1;
                            for (var j = 0; j < _nrLinii; j++)
                            {
                                temp *= _matriceInit[(i + j) % _nrLinii, (j) % _nrLinii];
                            }
                            puteri[puteri.Length - 1] += temp;
                        }

                    AfiseazaPuteri(puteri);

                }

                var p = new Polynomial(puteri.Reverse().ToArray());
                var radacini = p.Roots();

                _listaRadacini.Items.Clear();
                foreach (var complex in radacini)
                {
                    _listaRadacini.Visible = true;
                    _listaRadacini.Items.Add(complex.ToString() == "" ? "0" : complex.ToString());
                    _listaRadacini.Location = new Point(40, _polinom[0].Bottom + 40);
                    _listaRadacini.Size = new Size(120, 70);
                    _listaRadacini.Parent = this;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void AfiseazaPuteri(double[] puteri)
        {
            _polinom.Clear();
            for (var i = 0; i < puteri.Length; i++)
            {
                _polinom.Add(new TextBox());
                _polinom[i].Location = new Point(15 + i * 45, _matriceInitiala[_nrLinii - 1, _nrLinii - 1].Bottom + 50);
                _polinom[i].Size = new Size(40, 20);
                _polinom[i].Text = puteri[i].ToString(CultureInfo.InvariantCulture);
                _polinom[i].Parent = this;
                _polinom[i].Visible = true;
                _puteri.Add(new Label());
                _puteri[i].Text = @"x^" + (_nrLinii - i);
                _puteri[i].AutoSize = true;
                _puteri[i].Location = new Point(22 + i * 45, _matriceInitiala[_nrLinii - 1, _nrLinii - 1].Bottom + 36);
                _puteri[i].Parent = this;
                _puteri[i].Visible = true;
            }
        }

        public double[] Functie(double[] num)
        {
            var temp = new double[num.Length + 1];
            temp[0] = Math.Pow(-1, num.Length);

            var liste = Permutari(num.Length);

            for (var i = 1; i < num.Length + 1; i++)
            {
                temp[i] = Calculare(liste[i - 1], num) * Math.Pow(-1, num.Length - (i));
            }

            return temp;
        }

        public List<List<List<int>>> Permutari(int numere)
        {
            var final = new List<List<List<int>>>();
            for (var hh = 1; hh <= numere; hh++)
            {
                var a = GetCombinations(Enumerable.Range(1, numere), hh);
                var lists = a.ToList();

                var lists2 = lists.Select(t => t.ToList()).ToList();

                foreach (var t in lists2)
                {
                    for (var j = 0; j < t.Count - 1; j++)
                    {
                        for (var k = j + 1; k < t.Count; k++)
                        {
                            if (t[j] <= t[k]) continue;
                            var aa = t[j];
                            t[j] = t[k];
                            t[k] = aa;
                        }
                    }
                }

                for (var i = 0; i < lists2.Count; i++)
                {
                    var sterge = false;
                    for (var j = 0; j < lists2[i].Count - 1; j++)
                    {
                        for (var k = j + 1; k < lists2[i].Count; k++)
                        {
                            if (lists2[i][j] != lists2[i][k]) continue;
                            sterge = true;
                            break;
                        }

                    }
                    if (!sterge) continue;
                    lists2.RemoveAt(i);
                    i--;
                }

                for (var i = 0; i < lists2.Count - 1; i++)
                {

                    for (var j = i + 1; j < lists2.Count; j++)
                    {
                        if (!lists2[i].SequenceEqual(lists2[j])) continue;
                        lists2.RemoveAt(j);
                        i--;
                        break;
                    }
                }
                final.Add(lists2);
            }
            return final;
        }

        static IEnumerable<IEnumerable<T>> GetCombinations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new[] { t });

            var enumerable = list as IList<T> ?? list.ToList();
            return GetCombinations(enumerable, length - 1)
                .SelectMany(t => enumerable, (t1, t2) => t1.Concat(new[] { t2 }));
        }

        private static double Calculare(IEnumerable<List<int>> list, IReadOnlyList<double> numere)
        {
            return list.Sum(t => t.Aggregate<int, double>(1, (current, t1) => current*numere[t1 - 1]));
        }

        private int Verificare(int p)
        {
            if (p < 0)
                return _nrLinii + p;
            return p;
        }

        public void CalculareSpeciala(List<double> nespecial, double speciala, out double spec, out double neSpec)
        {
            spec = nespecial.Aggregate<double, double>(1, (current, t) => current*t);
            neSpec = speciala * spec;
        }
    }
}
