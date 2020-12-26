using System;

namespace Efecte_poze
{
    enum Cmyk { Cyan, Magenta, Yellow, Black };

    class CmykSpace
    {
        //    Black   = minimum(1-Red,1-Green,1-Blue)
        //    Cyan    = (1-Red-Black)/(1-Black)
        //    Magenta = (1-Green-Black)/(1-Black)
        //    Yellow  = (1-Blue-Black)/(1-Black) 
        //    Aceste ecuatii presupun ca valorile RGB au fost normalizate, adica sunt intre 0.0 si 1.0. 

        static public float[] RgbToCmyk(byte[] rgb)
        {
            var cmyk = new float[rgb.Length];   //Vector de float-uri pentru valorile CMYK (0.0 - 1.0)

            for (var i = 0; i < rgb.Length; i += 4)
            {
                //Black??
                if (rgb[i + (int)MainWindow.Rgb.Red] == 0 && rgb[i + (int)MainWindow.Rgb.Green] == 0 && rgb[i + (int)MainWindow.Rgb.Blue] == 0)
                {
                    cmyk[i + (int)Cmyk.Cyan] = cmyk[i + (int)Cmyk.Magenta] = cmyk[i + (int)Cmyk.Yellow] = 0;
                    cmyk[i + (int)Cmyk.Black] = 1;
                }
                else //Not Black
                {
                    cmyk[i + (int)Cmyk.Cyan] = (float)(1 - rgb[i + (int)MainWindow.Rgb.Red] / 255.0);
                    cmyk[i + (int)Cmyk.Magenta] = (float)(1 - rgb[i + (int)MainWindow.Rgb.Green] / 255.0);
                    cmyk[i + (int)Cmyk.Yellow] = (float)(1 - rgb[i + (int)MainWindow.Rgb.Blue] / 255.0);
                    var minCmyk = Math.Min(Math.Min(cmyk[i + (int)Cmyk.Cyan], cmyk[i + (int)Cmyk.Magenta]), cmyk[i + (int)Cmyk.Yellow]);

                    cmyk[i + (int)Cmyk.Cyan] = (cmyk[i + (int)Cmyk.Cyan] - minCmyk) / (1 - minCmyk);
                    cmyk[i + (int)Cmyk.Magenta] = (cmyk[i + (int)Cmyk.Magenta] - minCmyk) / (1 - minCmyk);
                    cmyk[i + (int)Cmyk.Yellow] = (cmyk[i + (int)Cmyk.Yellow] - minCmyk) / (1 - minCmyk);
                    cmyk[i + (int)Cmyk.Black] = minCmyk;
                }
            }
            return cmyk;
        }


        //    CMYK -> RGB
        //    Red=1-minimum(1, Cyan*(1-Black)+Black)
        //    Green=1-minimum(1, Magenta*(1-Black)+Black)
        //    Blue=1-minimum(1, Yellow*(1-Black)+Black)

        static public byte[] CmykToRgb(float[] cmyk)
        {
            var rgb = new byte[cmyk.Length];

            for (var i = 0; i < cmyk.Length; i += 4)
            {
                var oneMinusB = 1 - cmyk[i + (int)Cmyk.Black];
                var cyan = cmyk[i + (int)Cmyk.Cyan];
                var magenta = cmyk[i + (int)Cmyk.Magenta];
                var yellow = cmyk[i + (int)Cmyk.Yellow];
                rgb[i + (int)MainWindow.Rgb.Red] = (byte)(255 * (oneMinusB - cyan * oneMinusB));
                rgb[i + (int)MainWindow.Rgb.Green] = (byte)(255 * (oneMinusB - magenta * oneMinusB));
                rgb[i + (int)MainWindow.Rgb.Blue] = (byte)(255 * (oneMinusB - yellow * oneMinusB));
            }
            return rgb;
        }
    }
}
