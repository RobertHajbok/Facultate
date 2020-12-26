using System.Windows;

namespace Tetris
{
    /// <summary>
    /// Interaction logic for SpeedConfig.xaml
    /// </summary>
    public partial class SpeedConfig
    {
        public SpeedConfig()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var main =new MainWindow((int)SpeedSlider.Value);
            main.Show();
            Close();
        }
    }
}
