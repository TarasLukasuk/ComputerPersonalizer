using ComputerPersonalizer.Control;
using ComputerPersonalizerBL.Controllers.ControllerWindowsSelection;
using System.Windows;
using System.Windows.Controls;
namespace ComputerPersonalizer.Pages
{
    /// <summary>
    /// Логика взаимодействия для HistoryPage.xaml
    /// </summary>
    public partial class HistoryPage : Page
    {
        private ControllerWindowsSelection controllerWindowsSelection = new ControllerWindowsSelection();
        private HistoryColorControl historyColorControl;

        public HistoryPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in controllerWindowsSelection.ReadingHistoryColors())
            {
                historyColorControl = new HistoryColorControl();
                historyColorControl.ShowColor.Background = controllerWindowsSelection.ColorDisplay(item);
                historyColorControl.HistoryColorText.Content = item;

                StackPanel.Orientation = Orientation.Horizontal;
                StackPanel.Children.Add(historyColorControl);
            }
        }
    }
}
