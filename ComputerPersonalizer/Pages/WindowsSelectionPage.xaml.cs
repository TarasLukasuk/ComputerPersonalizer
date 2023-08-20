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
            if (Regex.Match(RGB.Text,@"[^0-9-\s]").Success)
            {
                RGB.Text=RGB.Text.Remove(RGB.Text.Length-1);
                RGB.SelectionStart = RGB.Text.Length;
                MessageBox.Show("Only numbers");
            }
        }
    }
}
