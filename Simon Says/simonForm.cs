using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Simon_Says
{
    public partial class simonForm : Form
    {
        private Game m_game;

        public simonForm()
        {
            InitializeComponent();
            simonButton1.Enabled = false;
            simonButton2.Enabled = false;
            simonButton3.Enabled = false;
            simonButton4.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Point[] myArray =
      {
        new Point(0,166),
        new Point(9,103),
        new Point(45,45),
        new Point(103,9),
        new Point(166,0)
      };

            Point[] myArray2 =
      {
        new Point(166,0),
        new Point(229,9),
        new Point(287,45),
        new Point(323,103),
        new Point(332,166)
      };

            Point[] myArray3 =
      {
        new Point(332,166),
        new Point(323,229),
        new Point(287,287),
        new Point(229,323),
        new Point(166,332)
      };

            Point[] myArray4 =
      {
        new Point(166,332),
        new Point(103,323),
        new Point(45,287),
        new Point(9,229),
        new Point(0,166)
      };

            GraphicsPath path = new GraphicsPath();
            path.AddCurve(myArray);
            path.AddCurve(myArray2);
            path.AddCurve(myArray3);
            path.AddCurve(myArray4);
            Region reg = new Region(path);
            this.Region = reg;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.button1.Text == "Start")
            {
                this.button1.Enabled = false;

                m_game = new Game();
                m_game.Tick += new EventHandler(GameTick);
                m_game.Start();
            }
        }

        private void GameTick(object sender, EventArgs e)
        {
            if (m_game.Count <= m_game.Turn)
            {
                switch (m_game.TheArray[m_game.Count])
                {
                    case 0:
                        this.simonButton1.Clicked = true;
                        break;

                    case 1:
                        this.simonButton2.Clicked = true;
                        break;

                    case 2:
                        this.simonButton3.Clicked = true;
                        break;

                    case 3:
                        this.simonButton4.Clicked = true;
                        break;

                    default: /* Should never get here */ break;
                }

                m_game.Count++;
                this.turnOffTimer.Enabled = true;
            }

            if (m_game.Count > m_game.Turn)
            {
                m_game.Stop();

                simonButton1.Enabled = true;
                simonButton2.Enabled = true;
                simonButton3.Enabled = true;
                simonButton4.Enabled = true;
            }
        }

        private void turnOffTimer_Tick(object sender, EventArgs e)
        {
            this.simonButton1.Clicked = false;
            this.simonButton2.Clicked = false;
            this.simonButton3.Clicked = false;
            this.simonButton4.Clicked = false;
            this.turnOffTimer.Enabled = false;
        }

        private void simonButton_Click(object sender, EventArgs e)
        {
            if (m_game.Play == true)
            {
                Button btn = (Button)sender;
                int val = 4;

                switch (btn.Text)
                {
                    case "simonButton1":
                        val = 0;
                        break;

                    case "simonButton2":
                        val = 1;
                        break;

                    case "simonButton3":
                        val = 2;
                        break;

                    case "simonButton4":
                        val = 3;
                        break;
                }

                if (val == m_game.TheArray[m_game.Count])
                {
                    if (m_game.Count < m_game.Turn)
                    {
                        m_game.Count++;
                    }
                    else
                    {
                        m_game.Play = false;
                        m_game.Turn++;
                        simonButton1.Enabled = false;
                        simonButton2.Enabled = false;
                        simonButton3.Enabled = false;
                        simonButton4.Enabled = false;
                        m_game.Restart();
                    }
                }
                else
                {
                    m_game.GameOver();
                    simonButton1.Enabled = false;
                    simonButton2.Enabled = false;
                    simonButton3.Enabled = false;
                    simonButton4.Enabled = false;
                    this.button1.Enabled = true;
                }
            }
        }

        #region Movement
        // points to hold the current position and the new position for the form and the mouse

        Point MouseCurrentPos, MouseNewPos, formPos, formNewPos;

        bool mouseDown = false;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            // when the mouse is down we must activate a flag to say that the left button is down
            // and then store the current position of the mouse and the form and we will 
            // use these posotions to calculate the offset that must be added to the loaction
            if (e.Button == MouseButtons.Left)
            {
                mouseDown = true;
                MouseCurrentPos = Control.MousePosition;
                formPos = Location;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            // when the mouse moves we get its new position then calculate the new location that the form 
            // should be moved to 
            // and then set the current position of the form and the mouse with the new ones 
            if (mouseDown == true)
            {
                MouseNewPos = Control.MousePosition;  // get the position of the mouse in the screen
                formNewPos.X = MouseNewPos.X - MouseCurrentPos.X + formPos.X;
                formNewPos.Y = MouseNewPos.Y - MouseCurrentPos.Y + formPos.Y;
                Location = formNewPos;
                formPos = formNewPos;
                MouseCurrentPos = MouseNewPos;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            // when the user release the mouse button we must update the flag
            if (e.Button == MouseButtons.Left)
            {
                mouseDown = false;
            }
        }
        #endregion
    }
}