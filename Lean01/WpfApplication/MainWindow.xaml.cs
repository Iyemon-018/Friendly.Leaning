using MahApps.Metro.Controls;
using Microsoft.Win32;

namespace WpfApplication
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Open_Click(object sender, System.Windows.RoutedEventArgs e)
            => new OpenFileDialog().ShowDialog();

        private void Save_Click(object sender, System.Windows.RoutedEventArgs e)
            => new SaveFileDialog().ShowDialog();

        private void Version_Click(object sender, System.Windows.RoutedEventArgs e) 
            => new VersionWindow().ShowDialog();
    }
}
