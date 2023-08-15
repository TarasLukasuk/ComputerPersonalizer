using ComputerPersonalizerBL.Controllers.ControllerWindowsSelection;
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
        }



        private void test_Loaded(object sender, RoutedEventArgs e)
        {
            ControllerWindowsSelection controllerWindowsSelection = new ControllerWindowsSelection(1,56,9);
            test.Content = controllerWindowsSelection.ToString();
        }
    }
}
