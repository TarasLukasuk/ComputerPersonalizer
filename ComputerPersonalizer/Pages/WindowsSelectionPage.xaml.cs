using ComputerPersonalizer.Control;
using ComputerPersonalizerBL.Controllers.ControllerWindowsSelection;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace ComputerPersonalizer.Pages
{
    /// <summary>
    /// Логика взаимодействия для WindowsSelectionPage.xaml
    /// </summary>
    public partial class WindowsSelectionPage : Page
    {
        ControllerWindowsSelection controllerWindowsSelection = new ControllerWindowsSelection();

        public WindowsSelectionPage()
        {
            InitializeComponent();
        }

        private void RGB_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckingInput();
            LineSeparator();
            HEX.Text = controllerWindowsSelection.RgbToHex();
        }

        /// <summary>
        /// Checking the correctness of the entered data
        /// </summary>
        private void CheckingInput()
        {
            if (Regex.Match(RGB.Text, @"[^0-9-\s]").Success)
            {
                RGB.Text = RGB.Text.Remove(RGB.Text.Length - 1);
                RGB.SelectionStart = RGB.Text.Length;
                MessageBox.Show("Only numbers");
            }
        }

        /// <summary>
        /// Splits a string into parts and converts a string to a number
        /// </summary>
        private void LineSeparator()
        {
            int r=0;
            int g=0;
            int b=0;

            string[] separator = RGB.Text.Split(' ');

            try
            {
                r = int.Parse(separator[0]);
                g = int.Parse(separator[1]);
                b = int.Parse(separator[2]);
                
            }
            catch (System.Exception)
            {
            }

            controllerWindowsSelection = new ControllerWindowsSelection(r,g,b);
        }

        private void HEX_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                RGB.Text = controllerWindowsSelection.HexToRgb(HEX.Text);
                ShowColor.Background = controllerWindowsSelection.ColorDisplay(HEX.Text);
            }
            catch (System.Exception)
            {
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
