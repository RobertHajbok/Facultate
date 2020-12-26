using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class TicTacToe : Form
    {


        private Button[] buttonArray;
        private bool isX;
        private bool isGameOver;
        private int[,] winPattern = 
            {
                {0,1,2},//down horizontal
                {3,4,5},//middle horizontal
                {6,7,8},//top  horizontal
                {0,3,6},//left vertical 
                {1,4,7},//middle vertical
                {2,5,8},//right vertical
                {0,4,8},// / diagonal 
                {2,4,6}// \ diagonal
            };

        public TicTacToe()
        {
            InitializeComponent();

        }

        private void TicTacToe_Load(object sender, EventArgs e)
        {
            buttonArray = new Button[9] { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            foreach (Button ctrlBtn in buttonArray)
            {
                ctrlBtn.Click += new System.EventHandler(this.DrawCharacter);
            }
            InitGame();
        }
        private void InitGame()
        {
            foreach (Button btn in buttonArray)
            {
                btn.Text = "";
                btn.BackColor = Color.Transparent;
                btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            }
            isGameOver = false;
            isX = true;
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            InitGame();
        }
        private void DrawCharacter(object sender, EventArgs e)
        {
            Button tmp = (Button)sender;

            if (this.isGameOver)
            {
                MessageBox.Show("Game Over");
            }
            if (tmp.Text != "")
            {
                MessageBox.Show("Not allowed");
            }
            tmp.Text = (isX) ? "X" : "O";
            isX = !isX;
            this.isGameOver = IsGameOver(buttonArray) || CheckDraw(buttonArray);

        }
        private bool CheckDraw(Button[] btnCtrl)
        {
            foreach (Button btn in btnCtrl)
            {
                if (btn.Text == "")
                    return false;
            }
            MessageBox.Show("Game Draw");

            return true;
        }
        private bool IsGameOver(Button[] btnCtrl)
        {
            bool gameOver = false;
            for (int i = 0; i < 8; i++)
            {
                int a = winPattern[i, 0], b = winPattern[i, 1], c = winPattern[i, 2];

                Button b1 = btnCtrl[a], b2 = btnCtrl[b], b3 = btnCtrl[c];

                if (b1.Text == "" || b2.Text == "" || b3.Text == "")
                    continue;

                if (b1.Text == b2.Text && b2.Text == b3.Text)
                {
                    b1.BackColor = b2.BackColor = b3.BackColor = Color.LightCoral;
                    b1.Font = b2.Font = b3.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Italic & System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
                    gameOver = true;
                    MessageBox.Show("Game Over. " + b1.Text + " wins");
                }
            }
            return gameOver;
        }
    }
}
