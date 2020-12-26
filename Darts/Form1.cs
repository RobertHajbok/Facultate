using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Darts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This Init region is to declare the private class variables
        /// </summary>
        #region Init

        private int mintThrow = 1;
        private bool mIsNoScore = false;
        private bool mIsSingle = false;
        private bool mIsDouble = false;
        private bool mIsTriple = false;

        private enum enumRingType
        {
            None = 0,
            Single,
            Double,
            Triple,
            SingleBullsEye,
            DoubleBullsEye
        }

        #endregion

        /// <summary>
        /// This Properties region defines all the properties of the control.
        /// </summary>
        #region Properties

        private int mintScore = 0;
        public int Score
        {
            get
            {
                return mintScore;
            }
        }

        private string mstrScoreText = "";
        public string ScoreText
        {
            get
            {
                return mstrScoreText;
            }
        }

        #endregion

        /// <summary>
        /// This ControlActions region shows all the eventhandlers for the controls
        /// </summary>
        #region ControlActions
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            int posX = (e.X - 225);
            int posY = (245 - e.Y);

            mintScore = GetScore(posX, posY);

            int newScore = Convert.ToInt32(label2.Text) + mintScore;

            label2.Text = newScore.ToString();
        }
        #endregion        

        /// <summary>
        /// This Utilities region shows all the private procedures used in
        /// the Control Eventhandlers, Methods and Properties.
        /// </summary>
        #region Utilities

        /// <summary>
        /// Calculates the thrown score based on the X and Y coordinates
        /// </summary>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <returns></returns>
        private int GetScore(int posX, int posY)
        {
            try
            {
                int intScore = 0;

                double dblHoekInRadians = System.Math.Atan2(posY, posX);
                double dblHoekInGraden = dblHoekInRadians * 180 / System.Math.PI;

                int intHoek = (int)dblHoekInGraden;
                if (intHoek < 0)
                {
                    intHoek = 180 + (intHoek + 180);
                }

                int intNummer = GetNumber(intHoek);
                enumRingType enmRing = GetRing(posX, posY);
                mIsNoScore = false;
                mIsSingle = false;
                mIsDouble = false;
                mIsTriple = false;

                switch (enmRing)
                {
                    case enumRingType.None:
                        mstrScoreText = "-";
                        intScore = 0;
                        mIsNoScore = true;
                        break;

                    case enumRingType.Single:
                        mstrScoreText = "S" + intNummer.ToString();
                        intScore = intNummer;
                        mIsSingle = true;
                        break;

                    case enumRingType.Double:
                        mstrScoreText = "D" + intNummer.ToString();
                        intScore = intNummer * 2;
                        mIsDouble = true;
                        break;

                    case enumRingType.Triple:
                        mstrScoreText = "T" + intNummer.ToString();
                        intScore = intNummer * 3;
                        mIsTriple = true;
                        break;

                    case enumRingType.SingleBullsEye:
                        mstrScoreText = "SingleBull";
                        intScore = 25;
                        mIsSingle = true;
                        break;

                    case enumRingType.DoubleBullsEye:
                        mstrScoreText = "DoubleBull";
                        intScore = 50;
                        mIsDouble = true;
                        break;
                }

                return intScore;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the "pie slice" based on given degree
        /// </summary>
        /// <param name="HoekInGraden"></param>
        /// <returns></returns>
        private int GetNumber(int HoekInGraden)
        {
            try
            {
                if (HoekInGraden >= 353) return 6;
                if (HoekInGraden >= 335) return 10;
                if (HoekInGraden >= 317) return 15;
                if (HoekInGraden >= 299) return 2;
                if (HoekInGraden >= 281) return 17;
                if (HoekInGraden >= 263) return 3;
                if (HoekInGraden >= 245) return 19;
                if (HoekInGraden >= 227) return 7;
                if (HoekInGraden >= 209) return 16;
                if (HoekInGraden >= 191) return 8;
                if (HoekInGraden >= 173) return 11;
                if (HoekInGraden >= 155) return 14;
                if (HoekInGraden >= 137) return 9;
                if (HoekInGraden >= 119) return 10;
                if (HoekInGraden >= 101) return 5;
                if (HoekInGraden >= 83) return 20;
                if (HoekInGraden >= 65) return 1;
                if (HoekInGraden >= 47) return 18;
                if (HoekInGraden >= 29) return 4;
                if (HoekInGraden >= 11) return 13;

                return 6;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets one of the rings based on the X and Y coordinates
        /// </summary>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <returns></returns>
        private enumRingType GetRing(int posX, int posY)
        {
            try
            {
                double dblLengte = System.Math.Sqrt(posX * posX + posY * posY);
                int intLengte = (int)System.Math.Floor(dblLengte);

                if (intLengte > 164) return enumRingType.None;

                if (intLengte <= 8) return enumRingType.DoubleBullsEye;
                if (intLengte > 8 && intLengte <= 16) return enumRingType.SingleBullsEye;
                if (intLengte >= 95 && intLengte <= 102) return enumRingType.Triple;
                if (intLengte >= 156 && intLengte <= 164) return enumRingType.Double;

                return enumRingType.Single;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = "0";
        }
    }
}
