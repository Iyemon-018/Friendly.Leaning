using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApplication
{
    public partial class DemoSimpleControl : UserControl
    {
        public DemoSimpleControl()
        {
            InitializeComponent();
        }

        private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
            => MessageBox.Show("Open");

        private void Close_Executed(object sender, ExecutedRoutedEventArgs e)
            => MessageBox.Show("Close");

        private void ParamTest_Executed(object sender, ExecutedRoutedEventArgs e)
            => MessageBox.Show(e.Parameter.ToString());

        private void Cancel_Click(object sender, RoutedEventArgs e)
            => MessageBox.Show("Cancel");

        private void CanExecute_True(object sender, CanExecuteRoutedEventArgs e)
            => e.CanExecute = true;
    }
}

