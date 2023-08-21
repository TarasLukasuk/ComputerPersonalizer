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
        public WindowsSelectionPage()
        {
            InitializeComponent();
        }

        private void RGB_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckingInput();
            LineSeparator();
        }

        private void CheckingInput()
        {
            if (Regex.Match(RGB.Text, @"[^0-9-\s]").Success)
            {
                RGB.Text = RGB.Text.Remove(RGB.Text.Length - 1);
                RGB.SelectionStart = RGB.Text.Length;
                MessageBox.Show("Only numbers");
            }
        }

        private int[] LineSeparator()
        {
            string[] separator = RGB.Text.Split(' ');

            int.TryParse(separator[0], out int r);
            int.TryParse(separator[1], out int g);
            int.TryParse(separator[2], out int b);

            int[] result = new int[3];
            result[0] = r;
            result[1] = g;
            result[2] = b;

            return result;
        }
    }
}
