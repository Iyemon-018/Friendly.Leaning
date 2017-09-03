using System.Windows.Controls;

namespace WpfApplication
{
    public partial class DemoItemsControl : UserControl
    {
        public DemoItemsControl()
        {
            InitializeComponent();
            DataContext = new[]
            {
                new Person("太郎", 30),
                new Person("次郎", 29),
                new Person("三郎", 28),
                new Person("花子", 27),
            };
        }
    }
}
