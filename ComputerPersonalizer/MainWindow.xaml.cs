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
            Page.Navigate(new WindowsSelectionPage());
        }

        private void Move_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) => DragMove();

        private void WindowsSelection_Click(object sender, RoutedEventArgs e)
        {
            Page.Navigate(new WindowsSelectionPage());
        }

        private void Cursor_Click(object sender, RoutedEventArgs e)
        {
            Page.Navigate(new CursorPage());
        }

        private void History_Click(object sender, RoutedEventArgs e)
        {
            Page.Navigate(new HistoryPage());
        }
    }
}
