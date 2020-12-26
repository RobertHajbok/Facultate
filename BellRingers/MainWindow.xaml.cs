using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using Microsoft.Win32;
using System.Threading;
using System.Windows.Threading;

namespace BellRingers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly string[] _towers = { "Great Shevington", "Little Mudford", 
                                    "Upper Gumtree", "Downley Hatch" };

        private readonly string[] _ringingMethods = {"Plain Bob", "Reverse Canterbury",
            "Grandsire", "Stedman", "Kent Treble Bob", "Old Oxford Delight",
            "Winchendon Place", "Norwich Suprise", "Crayford Little Court" };

        private readonly ContextMenu _windowContextMenu;

        public MainWindow()
        {
            InitializeComponent();
            Reset();

            var saveMemberMenuItem = new MenuItem {Header = "Save Member Details"};
            saveMemberMenuItem.Click += saveMember_Click;

            var clearFormMenuItem = new MenuItem {Header = "Clear Form"};
            clearFormMenuItem.Click += clear_Click;

            _windowContextMenu = new ContextMenu();
            _windowContextMenu.Items.Add(saveMemberMenuItem);
            _windowContextMenu.Items.Add(clearFormMenuItem);
        }

        public void Reset()
        {
            FirstName.Text = String.Empty;
            LastName.Text = String.Empty;

            TowerNames.Items.Clear();
            foreach (var towerName in _towers)
            {
                TowerNames.Items.Add(towerName);
            }
            TowerNames.Text = TowerNames.Items[0] as string;

            Methods.Items.Clear();
            foreach (var method in _ringingMethods.Select(methodName => new CheckBox {Margin = new Thickness(0, 0, 0, 10), Content = methodName}))
            {
                Methods.Items.Add(method);
            }

            IsCaptain.IsChecked = false;
            Novice.IsChecked = true;
            MemberSince.Text = DateTime.Today.ToString(CultureInfo.InvariantCulture);
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        //private void add_Click(object sender, RoutedEventArgs e)
        //{
        //    string nameAndTower = String.Format(
        //        "member name: {0} {1} from the tower at {2} rings the following methods:",
        //        firstName.Text, lastName.Text, towerNames.Text);

        //    StringBuilder details = new StringBuilder();
        //    details.AppendLine(nameAndTower);

        //    foreach (CheckBox cb in methods.Items)
        //    {
        //        if (cb.IsChecked.Value)
        //        {
        //            details.AppendLine(cb.Content.ToString());
        //        }
        //    }

        //    MessageBox.Show(details.ToString(), "Member Information");
        //}

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            var key = MessageBox.Show(
                "Are you sure you want to quit",
                "Confirm",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question,
                MessageBoxResult.No);
            e.Cancel = (key == MessageBoxResult.No);
        }

        private void newMember_Click(object sender, RoutedEventArgs e)
        {
            Reset();
            SaveMember.IsEnabled = true;
            FirstName.IsEnabled = true;
            LastName.IsEnabled = true;
            TowerNames.IsEnabled = true;
            IsCaptain.IsEnabled = true;
            MemberSince.IsEnabled = true;
            YearsExperience.IsEnabled = true;
            Methods.IsEnabled = true;
            Clear.IsEnabled = true;

            ContextMenu = _windowContextMenu;
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveData(string fileName, Member member)
        {
            using (var writer = new StreamWriter(fileName))
            {
                writer.WriteLine("First Name: {0}", member.FirstName);
                writer.WriteLine("Last Name: {0}", member.LastName);
                writer.WriteLine("Tower: {0}", member.TowerName);
                writer.WriteLine("Captain: {0}", member.IsCaptain);
                writer.WriteLine("Member Since: {0}", member.MemberSince);
                writer.WriteLine("Methods: ");
                foreach (var method in member.Methods)
                {
                    writer.WriteLine(method);
                }

                Thread.Sleep(10000);
                Action action = () => Status.Items.Add("Member details saved");
                Dispatcher.Invoke(action, DispatcherPriority.ApplicationIdle);
            }
        }

        private void saveMember_Click(object sender, RoutedEventArgs e)
        {
            var saveDialog = new SaveFileDialog
            {
                DefaultExt = "txt",
                AddExtension = true,
                FileName = "Members",
                InitialDirectory = @"C:\Users\John\Documents",
                OverwritePrompt = true,
                Title = "Bell Ringers",
                ValidateNames = true
            };
            var showDialog = saveDialog.ShowDialog();
            if (showDialog == null || !showDialog.Value) return;
            var member = new Member
            {
                FirstName = FirstName.Text,
                LastName = LastName.Text,
                TowerName = TowerNames.Text
            };
            if (IsCaptain.IsChecked != null)
            {
                member.IsCaptain = IsCaptain.IsChecked.Value;
                if (MemberSince.SelectedDate != null) member.MemberSince = MemberSince.SelectedDate.Value;
                member.Methods = new List<string>();
                foreach (var cb in Methods.Items.Cast<CheckBox>().Where(cb => cb.IsChecked != null && cb.IsChecked.Value))
                {
                    member.Methods.Add(cb.Content.ToString());
                }
            }

            var workerThread = new Thread(
                () => SaveData(saveDialog.FileName, member));
            workerThread.Start();
        }

        private void about_Click(object sender, RoutedEventArgs e)
        {
            var aboutWindow = new About();
            aboutWindow.ShowDialog();
        }

        private void clearName_Click(object sender, RoutedEventArgs e)
        {
            FirstName.Clear();
            LastName.Clear();
        }
    }
}
