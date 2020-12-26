using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ceas
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        Bitmap bitmap;
        Pen penSecondHand = new Pen(Color.Red, 3);
        Pen penMinuteHand = new Pen(Color.Gray, 5);
        Pen penHourHand = new Pen(Color.Black, 7);
        Pen penFrame = new Pen(Color.Black, 7);
        SolidBrush brushMiddleCircle = new SolidBrush(Color.Black);
        SolidBrush brushText = new SolidBrush(Color.Gray);
        Color backgroundColor = Color.Transparent;

        PointF center;
        PointF secondHandEndPoint;
        PointF minuteHandEndPoint;
        PointF hourHandEndPoint;
        int secondHandLength = 100;
        int minuteHandLength = 80;
        int hourHandLength = 60;
        int middleCircleRadius = 20;

        public Form1()
        {
            InitializeComponent();

            center.X = pictureBox1.Width / 2;
            center.Y = pictureBox1.Height / 2;

            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            graphics.Clear(backgroundColor);

            // Draw clock as soon as we start the app
            timer1_Tick(null, null);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            graphics.Clear(backgroundColor);

            // Draw frame
            int frameThickness = 4;
            graphics.DrawEllipse(penFrame, frameThickness, frameThickness, pictureBox1.Size.Width - (frameThickness * 2), pictureBox1.Size.Height - (frameThickness * 2));

            // Draw text / blocks
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

            for (int i = 0; i < 12; i++)
            {
                //String hourText = (i + 1).ToString();
                //Font hourFont = new Font("Helvetica", 10);
                //SizeF hourTextSize = graphics.MeasureString(hourText, hourFont);

                //float xText = pictureBox1.Width / 2 + GetCos(i * 30 - 60) * ((pictureBox1.Width / 2) - 30);
                //float yText = pictureBox1.Height / 2 + GetSin(i * 30 - 60) * ((pictureBox1.Height / 2) - 30);

                //graphics.DrawString(hourText, hourFont, brushText, xText - hourTextSize.Width / 2, yText - hourTextSize.Height / 2);

                float x = pictureBox1.Width / 2 + GetCos(i * 30 - 60) * ((pictureBox1.Width / 2) - 10);
                float y = pictureBox1.Height / 2 + GetSin(i * 30 - 60) * ((pictureBox1.Height / 2) - 10);

                graphics.FillRectangle(brushMiddleCircle, x - 5, y - 5, 10, 10);
            }

            // Draw clock
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            DateTime now = DateTime.Now;

            int second = now.Second;
            float secondDegrees = -90 + second * 360 / 60; //second * 360 / 60 * PI / 180;

            float minute = now.Minute + (float)now.Second / 60;
            float minuteDegrees = -90 + minute * 360 / 60; //minute * 360 / 60 * PI / 180;

            float hour = now.Hour % 12 + (float)now.Minute / 60;
            float hourDegrees = -90 + hour * 360 / 12; //hour * 360 / 12 * PI / 180;

            secondHandEndPoint.X = center.X + secondHandLength * GetCos(secondDegrees);
            secondHandEndPoint.Y = center.Y + secondHandLength * GetSin(secondDegrees);

            minuteHandEndPoint.X = center.X + minuteHandLength * GetCos(minuteDegrees);
            minuteHandEndPoint.Y = center.Y + minuteHandLength * GetSin(minuteDegrees);

            hourHandEndPoint.X = center.X + hourHandLength * GetCos(hourDegrees);
            hourHandEndPoint.Y = center.Y + hourHandLength * GetSin(hourDegrees);

            graphics.DrawLine(penSecondHand, center, secondHandEndPoint);
            graphics.DrawLine(penMinuteHand, center, minuteHandEndPoint);
            graphics.DrawLine(penHourHand, center, hourHandEndPoint);

            graphics.FillEllipse(brushMiddleCircle, center.X - (middleCircleRadius / 2), center.Y - (middleCircleRadius / 2), middleCircleRadius, middleCircleRadius);

            pictureBox1.Image = bitmap;

            // Update labels
            hourLabel.Text = now.Hour.ToString("D2");
            minuteLabel.Text = now.Minute.ToString("D2");
            secondLabel.Text = now.Second.ToString("D2");
        }

        private static float GetSin(float degAngle)
        {
            return (float)Math.Sin(Math.PI * degAngle / 180);
        }
        private static float GetCos(float degAngle)
        {
            return (float)Math.Cos(Math.PI * degAngle / 180);
        }
    }
}
