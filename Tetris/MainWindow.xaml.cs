using System;
using System.Reflection;
using System.Windows.Input;
using System.Windows.Threading;

namespace Tetris
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private DispatcherTimer _timer;
        private Board _myBoard;
        private readonly int _speed;

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(int speed)
        {
            _speed = speed;
            InitializeComponent();
        }

        void MainWindow_Initialized(object sender, EventArgs e)
        {
            _timer = new DispatcherTimer();
            _timer.Tick += GameTick;
            switch (_speed)
            {
                case 1:
                    _timer.Interval = new TimeSpan(0, 0, 0, 0, 550);
                    break;
                case 2:
                    _timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
                    break;
                case 3:
                    _timer.Interval = new TimeSpan(0, 0, 0, 0, 450);
                    break;
                case 4:
                    _timer.Interval = new TimeSpan(0, 0, 0, 0, 400);
                    break;
                case 5:
                    _timer.Interval = new TimeSpan(0, 0, 0, 0, 350);
                    break;
                case 6:
                    _timer.Interval = new TimeSpan(0, 0, 0, 0, 300);
                    break;
                case 7:
                    _timer.Interval = new TimeSpan(0, 0, 0, 0, 250);
                    break;
                case 8:
                    _timer.Interval = new TimeSpan(0, 0, 0, 0, 200);
                    break;
                case 9:
                    _timer.Interval = new TimeSpan(0, 0, 0, 0, 150);
                    break;
                case 10:
                    _timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
                    break;
            }
            GameStart();
        }

        private void GameStart()
        {
            MainGrid.Children.Clear();
            _myBoard = new Board(MainGrid, _speed);
            _timer.Start();
            Speed.Content = "Speed : " + _speed;
            About.Content = GetProductDetails();
        }

        #region About Product

        private static string GetProductDetails()
        {
            var about = "\n";
            about += AssemblyProduct + "\n";
            about += "Version " + AssemblyVersion + "\n";
            about += AssemblyCopyright + "\n";
            about += AssemblyCompany + "\n";
            about += AssemblyDescription + "\n\n";
            return about;
        }

        private static string AssemblyProduct
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                return attributes.Length == 0 ? "" : ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        private static string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        private static string AssemblyCopyright
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                return attributes.Length == 0 ? "" : ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        private static string AssemblyCompany
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                return attributes.Length == 0 ? "" : ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        private static string AssemblyDescription
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                return attributes.Length == 0 ? "" : ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        #endregion

        private void GamePause()
        {
            if(_timer.IsEnabled)
                _timer.Stop();
            else
                _timer.Start();
        }

        private void ChooseSpeed()
        {
            var speedConfig = new SpeedConfig();
            speedConfig.Show();
            Close();
        }

        private void GameTick(object sender, EventArgs e)
        {
            Score.Content = _myBoard.GetScore().ToString("00000000");
            Lines.Content = _myBoard.GetLines().ToString("00000000");
            _myBoard.CurrentTetraminoMoveDown();
        }

        private void HandleKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.A:
                    if(_timer.IsEnabled)
                        _myBoard.CurrentTetraminoMoveLeft();
                    break;
                case Key.D:
                    if (_timer.IsEnabled)
                        _myBoard.CurrentTetraminoMoveRight();
                    break;
                case Key.S:
                    if (_timer.IsEnabled)
                        _myBoard.CurrentTetraminoMoveDown();
                    break;
                case Key.W:
                    if (_timer.IsEnabled)
                        _myBoard.CurrentTetraminoRotate();
                    break;
                case Key.F2:
                    GameStart();
                    break;
                case Key.F3:
                    GamePause();
                    break;
                case Key.F4:
                    ChooseSpeed();
                    break;
            }
        }
    }
}
