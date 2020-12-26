using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GraphDemo_Parallel_Test
{
    public partial class GraphWindow
    {
        private readonly int _pixelWidth;
        private readonly int _pixelHeight;
        private const double DpiX = 96.0;
        private const double DpiY = 96.0;
        private WriteableBitmap _graphBitmap;

        public GraphWindow()
        {
            InitializeComponent();

            var memCounter = new PerformanceCounter("Memory", "Available Bytes");
            var availableMemorySize = Convert.ToUInt64(memCounter.NextValue());

            _pixelWidth = (int)availableMemorySize / 20000;
            if (_pixelWidth < 0 || _pixelWidth > 15000)
                _pixelWidth = 15000;

            _pixelHeight = (int)availableMemorySize / 40000;
            if (_pixelHeight < 0 || _pixelHeight > 7500)
                _pixelHeight = 7500;
        }

        private void plotButton_Click(object sender, RoutedEventArgs e)
        {
            if (_graphBitmap == null)
            {
                _graphBitmap = new WriteableBitmap(_pixelWidth, _pixelHeight, DpiX, DpiY, PixelFormats.Gray8, null);
            }
            var bytesPerPixel = (_graphBitmap.Format.BitsPerPixel + 7) / 8;
            var stride = bytesPerPixel * _pixelWidth;
            var dataSize = stride * _pixelHeight;
            var data = new byte[dataSize];

            var watch = Stopwatch.StartNew();
            GenerateGraphData(data);

            Duration.Content = string.Format("Duration (ms): {0}", watch.ElapsedMilliseconds);
            _graphBitmap.WritePixels(new Int32Rect(0, 0, _pixelWidth, _pixelHeight), data, stride, 0);
            GraphImage.Source = _graphBitmap;
        }

        private void GenerateGraphData(byte[] data)
        {
            Parallel.For(0, _pixelWidth / 2, x => CalculateData(x, data));
        }

        private void CalculateData(int x, byte[] data)
        {
            var a = _pixelWidth / 2;
            var b = a * a;
            var c = _pixelHeight / 2;

            var s = x * x;
            var p = Math.Sqrt(b - s);
            for (var i = -p; i < p; i += 3)
            {
                var r = Math.Sqrt(s + i * i) / a;
                var q = (r - 1) * Math.Sin(24 * r);
                var y = i / 3 + (q * c);

                // ReSharper disable once PossibleLossOfFraction
                PlotXy(data, -x + (_pixelWidth / 2), (int)(y + _pixelHeight / 2));
                // ReSharper disable once PossibleLossOfFraction
                PlotXy(data, x + (_pixelWidth / 2), (int)(y + _pixelHeight / 2));


                // The following code will slow the application down if uncommented
                //Parallel.Invoke(
                //    () => plotXY(data, (int)(-x + (pixelWidth / 2)), (int)(y + (pixelHeight / 2))),
                //    () => plotXY(data, (int)(x + (pixelWidth / 2)), (int)(y + (pixelHeight / 2)))
                //);
            }
        }

        private void PlotXy(IList<byte> data, int x, int y)
        {
            data[x + y * _pixelWidth] = 0xFF;
        }
    }
}
