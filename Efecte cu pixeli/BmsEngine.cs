using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Efecte_poze
{
    //Aceasta clasa ia datele RGB dintr-o image JPEG si creeaza copii pentru new bitmapSource.
    //Afisarea imaginii se updateaza simplu schimband sursa cu un bitmapSource construit aici.
    static class BmsEngine
    {
        static BitmapSource _parentBms;  //toate copiile se fac dupa acest bms
        static public int DataLength;   //marimea datelor RGB asociate lui bitmapSource
        static private int _stride;
        static private int _pixelWidth;
        static private int _pixelHeight;
        static private double _dpiX;
        static private double _dpiY;
        static private PixelFormat _format;

        static public void Init(BitmapSource imageBms)
        {
            _parentBms = imageBms;   //salveaza bms initial
            //stride
            _stride = imageBms.PixelWidth * ((imageBms.Format.BitsPerPixel + 7) / 8);
            //data length
            DataLength = _stride * imageBms.PixelHeight;
            //salveaza datele orginale pentru a putea face o copei BitmapSource folosind noile date
            _pixelWidth = imageBms.PixelWidth;
            _pixelHeight = imageBms.PixelHeight;
            _dpiX = imageBms.DpiX;
            _dpiY = imageBms.DpiY;
            _format = imageBms.Format;
        }


        static public BitmapSource CloneBms(byte[] newRgbData)
        {
            var childBms = BitmapSource.Create(_pixelWidth, _pixelHeight, _dpiX, _dpiY, _format, null, newRgbData, _stride);
            return childBms;
        }


        static public byte[] GetRgbData()
        {
            var rgb = new byte[DataLength];
            _parentBms.CopyPixels(rgb, _stride, 0);
            return rgb;
        }
    }
}
