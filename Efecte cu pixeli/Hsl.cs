using System;

namespace Efecte_poze
{
    enum Rgb { Blue, Green, Red };
    enum Hsl { Hue, Saturation, Lightness };


    // Metode statice pentru a converti un vector de valori RGB in HSL si invers
    // Enum-urile HSL si RGB sunt folosite pentru a defini ordinea elementelor din vectorii HSL si RGB
    class HslSpace
    {
        //convert RGB in HSL
        //0.0 <= H,S,L <= 1.0 
        static public float[] RgbToHsl(byte[] rgb)
        {
            var hsl = new float[rgb.Length];   //Vectori de float-uri pentru valorile HSL (0.0 to 1.0)
            for (var i = 0; i < rgb.Length; i += 4)
            {
                var varR = (float)(rgb[i + (int)Rgb.Red] / 255.0);              //valorile RGB normalizate, 0 to 1.0
                var varG = (float)(rgb[i + (int)Rgb.Green] / 255.0);
                var varB = (float)(rgb[i + (int)Rgb.Blue] / 255.0);

                var varMin = Math.Min(Math.Min(varR, varG), varB);  //Valoarea minima RGB
                var varMax = Math.Max(Math.Max(varR, varG), varB);  //Valoarea maxima RGB
                var delMax = varMax - varMin;                          //Valoarea Delta RGB

                var l = (float)((varMax + varMin) / 2.0);
                hsl[i + (int)Hsl.Lightness] = l;

                if (delMax == 0)       //Gri
                {
                    hsl[i + (int)Hsl.Hue] = hsl[i + (int)Hsl.Saturation] = 0;
                }
                else                      //Alte culori
                {
                    if (l < 0.5) 
                        hsl[i + (int)Hsl.Saturation] = delMax / (varMax + varMin);
                    else 
                        hsl[i + (int)Hsl.Saturation] = (float)(delMax / (2.0 - varMax - varMin));

                    var delR = (((varMax - varR) / 6) + (delMax / 2)) / delMax;
                    var delG = (((varMax - varG) / 6) + (delMax / 2)) / delMax;
                    var delB = (((varMax - varB) / 6) + (delMax / 2)) / delMax;

                    if (varR == varMax) 
                        hsl[i + (int)Hsl.Hue] = delB - delG;
                    else if (varG == varMax) 
                        hsl[i + (int)Hsl.Hue] = (float)(1.0 / 3) + delR - delB;
                    else if (varB == varMax) 
                        hsl[i + (int)Hsl.Hue] = (float)(2.0 / 3) + delG - delR;

                    if (hsl[i + (int)Hsl.Hue] < 0) hsl[i + (int)Hsl.Hue] += 1.0F;
                    if (hsl[i + (int)Hsl.Hue] > 1) hsl[i + (int)Hsl.Hue] -= 1.0F;
                }
            }

            return hsl;
        }

        static private float Hue_2_Rgb(float v1, float v2, float vH)
        {
            if (vH < 0) 
                vH += 1.0F;
            if (vH > 1) 
                vH -= 1.0F;
            if ((6 * vH) < 1) 
                return (v1 + (v2 - v1) * 6 * vH);
            if ((2 * vH) < 1) 
                return (v2);
            if ((3 * vH) < 2) 
                return (v1 + (v2 - v1) * ((float)(2.0 / 3.0) - vH) * 6);
            return (v1);
        }


        //Converteste HSL in RGB
        //Valorile HSL intre 0.0 si 1.0
        //Valorile RGB intre 0 si 255
        static public byte[] HslToRgb(float[] hsl)
        {
            var rgb = new byte[hsl.Length];   //Lista de byte pentru valorile RGB
            for (var i = 0; i < hsl.Length; i += 4)
            {
                var hue = hsl[i + (int)Hsl.Hue];
                var saturation = hsl[i + (int)Hsl.Saturation];
                var lightness = hsl[i + (int)Hsl.Lightness];
                //daca Saturation=0 -> gri, seteaza R=G=B -> HSL Lightness 
                if (saturation == 0.0)
                {
                    rgb[i + (int)Rgb.Red] = rgb[i + (int)Rgb.Green] = rgb[i + (int)Rgb.Blue] = (byte)(lightness * 255);
                }
                else
                {
                    float var2;
                    if (lightness < 0.5) 
                        var2 = lightness * (float)(1.0 + saturation);
                    else 
                        var2 = (lightness + saturation) - (saturation * lightness);

                    var var1 = 2 * lightness - var2;

                    rgb[i + (int)Rgb.Red] = (byte)(255 * Hue_2_Rgb(var1, var2, hue + (float)(1.0 / 3.0)));
                    rgb[i + (int)Rgb.Green] = (byte)(255 * Hue_2_Rgb(var1, var2, hue));
                    rgb[i + (int)Rgb.Blue] = (byte)(255 * Hue_2_Rgb(var1, var2, hue - (float)(1.0 / 3.0)));
                }
            }
            return rgb;
        }
    }
}
