using ComputerPersonalizerData;
using System.Windows.Controls;
using System.Windows.Input;

namespace ComputerPersonalizer.Control
{
    /// <summary>
    /// Логика взаимодействия для HistoryColorControl.xaml
    /// </summary>
    public partial class HistoryColorControl : UserControl
    {
        private ComputerPersonalizerDatas computerPersonalizerDatas = new ComputerPersonalizerDatas();

        public HistoryColorControl()
        {
            InitializeComponent();
        }

        private void UserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            computerPersonalizerDatas.CreateandRecordStructureXml(this.HistoryColorText.Content as string); 
        }
    }
}
