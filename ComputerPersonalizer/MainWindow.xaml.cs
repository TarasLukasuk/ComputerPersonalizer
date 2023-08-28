using ComputerPersonalizer.Pages;
using System.Windows;


namespace ComputerPersonalizer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Page.Navigate(new HistoryPage());
        }

        private void Move_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) => DragMove();
    }
}
