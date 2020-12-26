using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Slots
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonSetBet_Click(object sender, EventArgs e)
        {
            AppEngine.Bet = Int32.Parse(textboxBet.Text);
            if (AppEngine.Bet > AppEngine.maxBet) { AppEngine.Bet = AppEngine.maxBet; }
            AppEngine.BetTotal = AppEngine.Bet * AppEngine.Lines;

            refreshUI();
        }

        private void buttonSetLines_Click(object sender, EventArgs e)
        {
            AppEngine.Lines = Int32.Parse(textboxLines.Text);
            if (AppEngine.Lines > AppEngine.maxLines) { AppEngine.Lines = AppEngine.maxLines; }
            AppEngine.BetTotal = AppEngine.Bet * AppEngine.Lines;

            refreshUI();
        }

        private void buttonBetMax_Click(object sender, EventArgs e)
        {
            AppEngine.Bet = (AppEngine.Bet++ % AppEngine.maxBet) + 1;
            AppEngine.Lines = (AppEngine.Lines++ % AppEngine.maxLines) + 1;
            AppEngine.BetTotal = AppEngine.Bet * AppEngine.Lines;

            refreshUI();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AppEngine.Bet = 1;
            AppEngine.Lines = 1;
            AppEngine.Credit = 10;
            AppEngine.BetTotal = 1;

            AppEngine.initLabels(panel1);

            refreshUI();
        }

        private void refreshUI()
        {
            textboxBet.Text = AppEngine.Bet.ToString();
            textboxLines.Text = AppEngine.Lines.ToString();
            labelCredit.Text = AppEngine.Credit.ToString();
            labelTotalBet.Text = AppEngine.BetTotal.ToString();
        }

        private void buttonSpin_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    AppEngine.matrix[i, j] = AppEngine.random.Next(11);
                    AppEngine.labels[i, j].Text = AppEngine.matrix[i, j].ToString();
                }
            }

            refreshUI();
        }
    }
}
