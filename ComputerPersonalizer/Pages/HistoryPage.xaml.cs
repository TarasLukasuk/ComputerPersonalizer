using ComputerPersonalizer.Control;
using ComputerPersonalizerBL.Controllers.ControllerWindowsSelection;
using System.Windows;
using System.Windows.Controls;
using ComputerPersonalizerData;
namespace ComputerPersonalizer.Pages
{
    /// <summary>
    /// Логика взаимодействия для HistoryPage.xaml
    /// </summary>
    public partial class HistoryPage : Page
    {
        private readonly ControllerWindowsSelection controllerWindowsSelection = new ControllerWindowsSelection();
        private HistoryColorControl historyColorControl;
        private readonly ComputerPersonalizerDatas computerPersonalizerData = new ComputerPersonalizerDatas();

        public HistoryPage() => InitializeComponent();

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in computerPersonalizerData.ReadingHistoryColors())
            {
                historyColorControl = new HistoryColorControl();
                historyColorControl.ShowColor.Background = controllerWindowsSelection.ColorDisplay(item);
                historyColorControl.HistoryColorText.Content = item;
                historyColorControl.Margin = new Thickness(10,0,10,0);

                StackPanel.Orientation = Orientation.Vertical;
                StackPanel.Children.Add(historyColorControl);
            }
        }
    }
}
