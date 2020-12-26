using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace Efecte_poze
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        // Cand modificam imaginea, ImgPhoto se updateaza cu una dintre sursele de mai jos.
        // Acestea sunt null pana sunt folosite
        private BitmapSource _rgbBms;
        private BitmapSource _blueBms;
        private BitmapSource _greenBms;
        private BitmapSource _grayBms;
        private BitmapSource _redBms;
        private BitmapSource _desaturateBms;
        private BitmapSource _cyanBms;
        private BitmapSource _magentaBms;
        private BitmapSource _yellowBms;
        private BitmapSource _cyan2Bms;
        private BitmapSource _magenta2Bms;
        private BitmapSource _yellow2Bms;
        private BitmapSource _blackBms;
        private BitmapSource _cmykToRgbBms;
        private BitmapSource _hslToRgbBms;
        private BitmapSource _hueBms;
        private BitmapSource _saturationBms;
        private BitmapSource _lightnessBms;

        public enum Rgb
        {
            Blue,
            Green,
            Red
        };

        //Doar rgbValues e sigur ca se va putea folosi intotdeauna
        //cmykValues si hslValues sunt construite doar cand sunt folosite
        //Vectorii contin datele din ultima imagine folosita
        private byte[] _rgbValues; //valoarea intre 0 si 255
        private float[] _cmykValues; //valoarea intre 0.0 si 1.0
        private float[] _hslValues; //valoarea intre 0.0 si 1.0


        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExitMenu_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OpenMenu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var op = new OpenFileDialog
                {
                    RestoreDirectory = true,
                    InitialDirectory = "C:\\",
                    FilterIndex = 1,
                    Title = "Alegeti poza",
                    Filter = "|*.jpg;*.jpeg;*.png|" +
                             "(*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                             "(*.png)|*.png"
                };
                if (op.ShowDialog() == true)
                {
                    Stream imageStreamSource = new FileStream(op.FileName, FileMode.Open, FileAccess.Read,
                        FileShare.Read);
                    //PixelFormat
                    var decoder = new JpegBitmapDecoder(imageStreamSource, BitmapCreateOptions.None,
                        BitmapCacheOption.Default);
                    BitmapSource bitmapSource = decoder.Frames[0];
                    BmsEngine.Init(bitmapSource);
                    ImgPhoto.Source = _rgbBms = bitmapSource;
                    _rgbValues = BmsEngine.GetRgbData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message, "Efecte poze", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveMenu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var sv = new SaveFileDialog
                {
                    RestoreDirectory = true,
                    InitialDirectory = "C:\\",
                    FilterIndex = 1,
                    Filter =
                        "jpg Files (*.jpg)|*.jpg|gif Files (*.gif)|*.gif|png Files (*.png)|*.png |bmp Files (*.bmp)|*.bmp"
                };

                sv.ShowDialog();
                var stream = new FileStream(sv.FileName, FileMode.Create);
                var encoder = new JpegBitmapEncoder {QualityLevel = 70};
                encoder.Frames.Add(BitmapFrame.Create((BitmapSource) ImgPhoto.Source));
                encoder.Save(stream);
                stream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message, "Efecte poze", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RGBMenu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBox.Show("Pixel Width: " + ((BitmapSource) ImgPhoto.Source).PixelWidth +
                                "\nPixel Height: " +
                                ((BitmapSource) ImgPhoto.Source).PixelHeight);
                ImgPhoto.Source = _rgbBms;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message, "Efecte poze", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RedMenu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_redBms == null)
                {
                    var newJpegBytes = BmsEngine.GetRgbData();
                    for (var i = 0; i < BmsEngine.DataLength; i += 4)
                    {
                        newJpegBytes[i + (int) Rgb.Blue] = 0; //blue
                        newJpegBytes[i + (int) Rgb.Green] = 0; //green
                    }
                    _redBms = BmsEngine.CloneBms(newJpegBytes);
                }
                ImgPhoto.Source = _redBms;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message, "Efecte poze", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GreenMenu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_greenBms == null)
                {
                    var newJpegBytes = BmsEngine.GetRgbData();
                    for (var i = 0; i < BmsEngine.DataLength; i += 4)
                    {
                        newJpegBytes[i + (int) Rgb.Blue] = 0; //blue
                        newJpegBytes[i + (int) Rgb.Red] = 0; //red
                    }
                    _greenBms = BmsEngine.CloneBms(newJpegBytes);
                }
                ImgPhoto.Source = _greenBms;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message, "Efecte poze", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BlueMenu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_blueBms == null)
                {
                    var newJpegBytes = BmsEngine.GetRgbData();
                    for (var i = 0; i < BmsEngine.DataLength; i += 4)
                    {
                        newJpegBytes[i + (int) Rgb.Green] = 0; //green
                        newJpegBytes[i + (int) Rgb.Red] = 0; //red
                    }
                    _blueBms = BmsEngine.CloneBms(newJpegBytes);
                }
                ImgPhoto.Source = _blueBms;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message, "Efecte poze", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GrayMenu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_grayBms == null)
                {
                    var newJpegBytes = BmsEngine.GetRgbData();
                    for (var i = 0; i < BmsEngine.DataLength; i += 4)
                    {
                        var grayVal = 0.114*_rgbValues[i + (int) Rgb.Blue] + 0.587*_rgbValues[i + (int) Rgb.Green] +
                                      0.299*_rgbValues[i + (int) Rgb.Red];
                        newJpegBytes[i + (int) Rgb.Blue] = (byte) grayVal; //blue
                        newJpegBytes[i + (int) Rgb.Green] = (byte) grayVal; //green
                        newJpegBytes[i + (int) Rgb.Red] = (byte) grayVal; //red
                    }
                    _grayBms = BmsEngine.CloneBms(newJpegBytes);
                }
                ImgPhoto.Source = _grayBms;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message, "Efecte poze", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DesaturateMenu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_desaturateBms == null)
                {
                    var newJpegBytes = BmsEngine.GetRgbData();
                    for (var i = 0; i < BmsEngine.DataLength; i += 4)
                    {
                        var minRgb = Math.Min(Math.Min(_rgbValues[i + (int) Rgb.Blue], _rgbValues[i + (int) Rgb.Green]),
                            _rgbValues[i + (int) Rgb.Red]);
                        var maxRgb = Math.Max(Math.Max(_rgbValues[i + (int) Rgb.Blue], _rgbValues[i + (int) Rgb.Green]),
                            _rgbValues[i + (int) Rgb.Red]);
                        var desatVal = (byte) ((minRgb + maxRgb)/2);
                        newJpegBytes[i + (int) Rgb.Blue] = desatVal;
                        newJpegBytes[i + (int) Rgb.Green] = desatVal;
                        newJpegBytes[i + (int) Rgb.Red] = desatVal;
                    }
                    _desaturateBms = BmsEngine.CloneBms(newJpegBytes);
                }
                ImgPhoto.Source = _desaturateBms;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message, "Efecte poze", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CyanMenu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_cyanBms == null)
                {
                    var newJpegBytes = BmsEngine.GetRgbData();
                    for (var i = 0; i < BmsEngine.DataLength; i += 4)
                    {
                        newJpegBytes[i + (int) Rgb.Red] = 0; //cyan=G+B;
                    }
                    _cyanBms = BmsEngine.CloneBms(newJpegBytes);
                }
                ImgPhoto.Source = _cyanBms;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message, "Efecte poze", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MagentaMenu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_magentaBms == null)
                {
                    var newJpegBytes = BmsEngine.GetRgbData();
                    for (var i = 0; i < BmsEngine.DataLength; i += 4)
                    {
                        newJpegBytes[i + (int) Rgb.Green] = 0; //Magenta=R+B;
                    }
                    _magentaBms = BmsEngine.CloneBms(newJpegBytes);
                }
                ImgPhoto.Source = _magentaBms;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message, "Efecte poze", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void YellowMenu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_yellowBms == null)
                {
                    var newJpegBytes = BmsEngine.GetRgbData();
                    for (var i = 0; i < BmsEngine.DataLength; i += 4)
                    {
                        newJpegBytes[i + (int) Rgb.Blue] = 0; //Yellow=R+G;
                    }
                    _yellowBms = BmsEngine.CloneBms(newJpegBytes);
                }
                ImgPhoto.Source = _yellowBms;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message, "Efecte poze", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cyan2Menu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_cmykValues == null) 
                    _cmykValues = CmykSpace.RgbToCmyk(_rgbValues);
                if (_cyan2Bms == null)
                {
                    var newJpegBytes = new byte[BmsEngine.DataLength];
                    for (var i = 0; i < BmsEngine.DataLength; i += 4)
                    {
                        newJpegBytes[i + (int) Rgb.Blue] =
                            newJpegBytes[i + (int) Rgb.Green] =
                                newJpegBytes[i + (int) Rgb.Red] =
                                    (byte) Math.Min(255.0, (255*(1.0 - _cmykValues[i + (int) Cmyk.Cyan])));
                    }
                    _cyan2Bms = BmsEngine.CloneBms(newJpegBytes);
                }
                ImgPhoto.Source = _cyan2Bms;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message, "Efecte poze", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Magenta2Menu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_cmykValues == null)
                    _cmykValues = CmykSpace.RgbToCmyk(_rgbValues);

                if (_magenta2Bms == null)
                {
                    var newJpegBytes = new byte[BmsEngine.DataLength];
                    for (var i = 0; i < BmsEngine.DataLength; i += 4)
                    {
                        newJpegBytes[i + (int) Rgb.Blue] =
                            newJpegBytes[i + (int) Rgb.Green] =
                                newJpegBytes[i + (int) Rgb.Red] =
                                    (byte) Math.Min(255.0, (255*(1.0 - _cmykValues[i + (int) Cmyk.Magenta])));
                    }
                    _magenta2Bms = BmsEngine.CloneBms(newJpegBytes);
                }
                ImgPhoto.Source = _magenta2Bms;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message, "Efecte poze", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Yellow2Menu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_cmykValues == null)
                    _cmykValues = CmykSpace.RgbToCmyk(_rgbValues);

                if (_yellow2Bms == null)
                {
                    var newJpegBytes = new byte[BmsEngine.DataLength];
                    for (var i = 0; i < BmsEngine.DataLength; i += 4)
                    {
                        newJpegBytes[i + (int) Rgb.Blue] =
                            newJpegBytes[i + (int) Rgb.Green] =
                                newJpegBytes[i + (int) Rgb.Red] =
                                    (byte) Math.Min(255.0, (255*(1.0 - _cmykValues[i + (int) Cmyk.Yellow])));
                    }
                    _yellow2Bms = BmsEngine.CloneBms(newJpegBytes);
                }
                ImgPhoto.Source = _yellow2Bms;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message, "Efecte poze", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BlackMenu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_cmykValues == null)
                    _cmykValues = CmykSpace.RgbToCmyk(_rgbValues);

                if (_blackBms == null)
                {
                    var newJpegBytes = new byte[BmsEngine.DataLength];
                    for (var i = 0; i < BmsEngine.DataLength; i += 4)
                    {
                        newJpegBytes[i + (int) Rgb.Blue] =
                            newJpegBytes[i + (int) Rgb.Green] =
                                newJpegBytes[i + (int) Rgb.Red] =
                                    (byte) Math.Min(255.0, (255*(1.0 - _cmykValues[i + (int) Cmyk.Black])));
                    }
                    _blackBms = BmsEngine.CloneBms(newJpegBytes);
                }
                ImgPhoto.Source = _blackBms;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message, "Efecte poze", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CmykToRGBMenu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_cmykValues == null) 
                    _cmykValues = CmykSpace.RgbToCmyk(_rgbValues);

                if (_cmykToRgbBms == null)
                {
                    var newJpegBytes = CmykSpace.CmykToRgb(_cmykValues);
                    _cmykToRgbBms = BmsEngine.CloneBms(newJpegBytes);
                }
                ImgPhoto.Source = _cmykToRgbBms;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message, "Efecte poze", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void HslToRGBMenu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_hslValues == null)
                    _hslValues = HslSpace.RgbToHsl(_rgbValues);
                if (_hslToRgbBms == null)
                {
                    var newJpegBytes = HslSpace.HslToRgb(_hslValues);
                    _hslToRgbBms = BmsEngine.CloneBms(newJpegBytes);
                }
                ImgPhoto.Source = _hslToRgbBms;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message, "Efecte poze", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void HueMenu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_hslValues == null) _hslValues = HslSpace.RgbToHsl(_rgbValues);

                if (_hueBms == null)
                {
                    var newJpegBytes = new byte[BmsEngine.DataLength];
                    for (var i = 0; i < BmsEngine.DataLength; i += 4)
                    {
                        newJpegBytes[i + (int) Rgb.Red] =
                            newJpegBytes[i + (int) Rgb.Green] =
                                newJpegBytes[i + (int) Rgb.Blue] = (byte) (_hslValues[i + (int) Hsl.Hue]*255);
                    }
                    _hueBms = BmsEngine.CloneBms(newJpegBytes);
                }
                ImgPhoto.Source = _hueBms;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message, "Efecte poze", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaturationMenu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_hslValues == null) 
                    _hslValues = HslSpace.RgbToHsl(_rgbValues);

                if (_saturationBms == null)
                {
                    var newJpegBytes = new byte[BmsEngine.DataLength];
                    for (var i = 0; i < BmsEngine.DataLength; i += 4)
                    {
                        newJpegBytes[i + (int) Rgb.Red] =
                            newJpegBytes[i + (int) Rgb.Green] =
                                newJpegBytes[i + (int) Rgb.Blue] = (byte) (_hslValues[i + (int) Hsl.Saturation]*255);
                    }
                    _saturationBms = BmsEngine.CloneBms(newJpegBytes);
                }
                ImgPhoto.Source = _saturationBms;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message, "Efecte poze", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LightnessMenu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_hslValues == null) 
                    _hslValues = HslSpace.RgbToHsl(_rgbValues);

                if (_lightnessBms == null)
                {
                    var newJpegBytes = new byte[BmsEngine.DataLength];
                    for (var i = 0; i < BmsEngine.DataLength; i += 4)
                    {
                        newJpegBytes[i + (int) Rgb.Red] =
                            newJpegBytes[i + (int) Rgb.Green] =
                                newJpegBytes[i + (int) Rgb.Blue] = (byte) (_hslValues[i + (int) Hsl.Lightness]*255);
                    }
                    _lightnessBms = BmsEngine.CloneBms(newJpegBytes);
                }
                ImgPhoto.Source = _lightnessBms;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message, "Efecte poze", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AboutMenu_Click(object sender, RoutedEventArgs e)
        {
            var about = new BoxAbout();
            about.Show();
        }
    }
}
