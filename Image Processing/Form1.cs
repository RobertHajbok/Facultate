using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Image_Processing
{
    public partial class Form1 : Form
    {
        Bitmap newBitmap;
        Image file;
        int lastCol = 0;
        float contrast = 0;
        float gamma = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                file = Image.FromFile(openFileDialog1.FileName);
                newBitmap = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = file;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                if (file != null)
                {
                    if (saveFileDialog1.FileName.Substring(saveFileDialog1.FileName.Length - 3).ToLower() == "bmp")
                    {
                        file.Save(saveFileDialog1.FileName, ImageFormat.Bmp);
                    }

                    if (saveFileDialog1.FileName.Substring(saveFileDialog1.FileName.Length - 3).ToLower() == "jpg")
                    {
                        file.Save(saveFileDialog1.FileName, ImageFormat.Jpeg);
                    }

                    if (saveFileDialog1.FileName.Substring(saveFileDialog1.FileName.Length - 3).ToLower() == "png")
                    {
                        file.Save(saveFileDialog1.FileName, ImageFormat.Png);
                    }

                    if (saveFileDialog1.FileName.Substring(saveFileDialog1.FileName.Length - 3).ToLower() == "gif")
                    {
                        file.Save(saveFileDialog1.FileName, ImageFormat.Gif);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < newBitmap.Width; x++)
            {
                for (int y = 0; y < newBitmap.Height; y++)
                {
                    Color originalColor = newBitmap.GetPixel(x, y);
                    int grayScale = (int)((originalColor.R * .3) + (originalColor.G * .59) + (originalColor.B * .11));
                    Color newColor = Color.FromArgb(grayScale, grayScale, grayScale);
                    newBitmap.SetPixel(x, y, newColor);
                }
            }
            pictureBox1.Image = newBitmap;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int x = 1; x < newBitmap.Width; x++)
            {
                for (int y = 1; y < newBitmap.Height; y++)
                {
                    try
                    {
                        Color prevX = newBitmap.GetPixel(x - 1, y);
                        Color nextX = newBitmap.GetPixel(x + 1, y);
                        Color prevY = newBitmap.GetPixel(x, y - 1);
                        Color nextY = newBitmap.GetPixel(x, y + 1);

                        int avgR = (int)((prevX.R + nextX.R + prevY.R + nextY.R) / 4);
                        int avgG = (int)((prevX.G + nextX.G + prevY.G + nextY.G) / 4);
                        int avgB = (int)((prevX.B + nextX.B + prevY.B + nextY.B) / 4);

                        newBitmap.SetPixel(x, y, Color.FromArgb(avgR, avgG, avgB));

                    }
                    catch (Exception)
                    {
                    }
                }
            }
            pictureBox1.Image = newBitmap;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = trackBar1.Value.ToString();
            pictureBox1.Image = AdjustBrightness(newBitmap, trackBar1.Value);
        }

        public static Bitmap AdjustBrightness(Bitmap Image, int Value)
        {
            Bitmap TempBitmap = Image;
            float FinalValue = (float)Value / 255.0f;
            Bitmap NewBitmap = new Bitmap(TempBitmap.Width, TempBitmap.Height);
            Graphics NewGraphics = Graphics.FromImage(NewBitmap);
            float[][] FloatColorMatrix ={
                    new float[] {1, 0, 0, 0, 0},
                    new float[] {0, 1, 0, 0, 0},
                    new float[] {0, 0, 1, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {FinalValue, FinalValue, FinalValue, 1, 1},
                                        };
            ColorMatrix NewColorMatrix = new ColorMatrix(FloatColorMatrix);
            ImageAttributes Attributes = new ImageAttributes();
            Attributes.SetColorMatrix(NewColorMatrix);
            NewGraphics.DrawImage(TempBitmap, new Rectangle(0, 0, TempBitmap.Width, TempBitmap.Height), 0, 0, TempBitmap.Width, TempBitmap.Height, GraphicsUnit.Pixel, Attributes);
            Attributes.Dispose();
            NewGraphics.Dispose();
            return NewBitmap;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < newBitmap.Width; x++)
            {
                for (int y = 0; y < newBitmap.Height; y++)
                {
                    Color pixel = newBitmap.GetPixel(x, y);
                    int red = pixel.R;
                    int green = pixel.G;
                    int blue = pixel.B;

                    newBitmap.SetPixel(x, y, Color.FromArgb(255 - red, 255 - green, 255 - blue));
                }
            }
            pictureBox1.Image = newBitmap;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Bitmap nB = new Bitmap(newBitmap.Width, newBitmap.Height);

            for (int x = 1; x <= newBitmap.Width - 1; x++)
            {
                for (int y = 1; y <= newBitmap.Height - 1; y++)
                {
                    nB.SetPixel(x, y, Color.DarkGray);
                }
            }

            for (int x = 1; x <= newBitmap.Width - 1; x++)
            {
                for (int y = 1; y <= newBitmap.Height - 1; y++)
                {
                    try
                    {
                        Color pixel = newBitmap.GetPixel(x, y);
                        int colVal = (pixel.R + pixel.G + pixel.B);
                        int diff;

                        if (lastCol == 0)
                            lastCol = (pixel.R + pixel.G + pixel.B);

                        if (colVal > lastCol)
                        {
                            diff = colVal - lastCol;
                        }
                        else
                        {
                            diff = lastCol - colVal;
                        }

                        if (diff > 100)
                        {
                            nB.SetPixel(x, y, Color.Gray);
                            lastCol = colVal;
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            for (int y = 1; y <= newBitmap.Height - 1; y++)
            {

                for (int x = 1; x <= newBitmap.Width - 1; x++)
                {
                    try
                    {
                        Color pixel = newBitmap.GetPixel(x, y);
                        int colVal = (pixel.R + pixel.G + pixel.B);
                        int diff;

                        if (lastCol == 0)
                        {
                            lastCol = (pixel.R + pixel.G + pixel.B);
                        }

                        if (colVal > lastCol)
                        {
                            diff = colVal - lastCol;
                        }
                        else
                        {
                            diff = lastCol - colVal;
                        }

                        if (diff > 100)
                        {
                            nB.SetPixel(x, y, Color.Gray);
                            lastCol = colVal;
                        }

                    }
                    catch (Exception)
                    {
                    }
                }

            }
            pictureBox1.Image = nB;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label3.Text = trackBar2.Value.ToString();
            contrast = 0.04f * trackBar2.Value;

            Bitmap bm = new Bitmap(newBitmap.Width, newBitmap.Height);
            Graphics g = Graphics.FromImage(bm);
            ImageAttributes ia = new ImageAttributes();
            ColorMatrix cm = new ColorMatrix(new float[][]{
                new float[]{contrast,0f,0f,0f,0f},
                new float[]{0f,contrast,0f,0f,0f},
                new float[]{0f,0f,contrast,0f,0f},
                new float[]{0f,0f,0f,1f,0f},
                new float[]{0.001f,0.001f,0.001f,0f,1f}});

            ia.SetColorMatrix(cm);
            g.DrawImage(newBitmap, new Rectangle(0, 0, newBitmap.Width, newBitmap.Height), 0, 0, newBitmap.Width, newBitmap.Height, GraphicsUnit.Pixel, ia);
            g.Dispose();
            ia.Dispose();
            pictureBox1.Image = bm;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            label5.Text = trackBar3.Value.ToString();
            gamma = 0.04f * trackBar3.Value;

            Bitmap bm = new Bitmap(newBitmap.Width, newBitmap.Height);
            Graphics g = Graphics.FromImage(bm);
            ImageAttributes ia = new ImageAttributes();

            ia.SetGamma(gamma);
            g.DrawImage(newBitmap, new Rectangle(0, 0, newBitmap.Width, newBitmap.Height), 0, 0, newBitmap.Width, newBitmap.Height, GraphicsUnit.Pixel, ia);
            g.Dispose();
            ia.Dispose();
            pictureBox1.Image = bm;
        }
    }
}
