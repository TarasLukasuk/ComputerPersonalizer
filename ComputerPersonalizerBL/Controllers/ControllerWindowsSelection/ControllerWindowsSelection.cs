using ComputerPersonalizerBL.PersonalizationElements.WindowsSelection;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows.Media;

namespace ComputerPersonalizerBL.Controllers.ControllerWindowsSelection
{
    public sealed class ControllerWindowsSelection
    {
        private const string HILIGHT= "0 120 215";
        private const string HOT_TRACKING_COLOR = "0 102 204";
        private const string PATH_FILE_COLOR_HISTORY = ".\\HistoryColor.txt";

        private readonly WindowsSelectionColor windowsSelectionColor;

        /// <summary>
        /// Assigning colors
        /// </summary>
        /// <param name="Red"></param>
        /// <param name="Green"></param>
        /// <param name="Blue"></param>
        public ControllerWindowsSelection(int Red, int Green, int Blue)
        {
            windowsSelectionColor = new WindowsSelectionColor(Red, Green, Blue);
        }

        public ControllerWindowsSelection()
        {
            windowsSelectionColor = new WindowsSelectionColor(255,255,255);
        }

        /// <summary>
        /// Setting a highlight color in the system
        /// </summary>
        public void SaveWindowsSelectionColor()
        {
            using (RegistryKey registry= Registry.CurrentUser.CreateSubKey(@"Control Panel\Colors"))
            {
                registry.SetValue("Hilight", ToString());
                registry.SetValue("HotTrackingColor", ToString());
            }
        }

        /// <summary>
        /// Converting Rgb to Hex
        /// </summary>
        /// <returns></returns>
        public string RgbToHex()
        {
            return $"#{windowsSelectionColor.Red:X2}" +
                   $"{windowsSelectionColor.Green:X2}" +
                   $"{windowsSelectionColor.Blue:X2}";
        }

        /// <summary>
        /// Returns the Windows selection color to the default color
        /// </summary>
        public void ResetSelectionColor()
        {
            using (RegistryKey registry = Registry.CurrentUser.CreateSubKey(@"Control Panel\Colors"))
            {
                registry.SetValue("Hilight", HILIGHT);
                registry.SetValue("HotTrackingColor", HOT_TRACKING_COLOR);
            }
        }

        /// <summary>
        /// Overriding the ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{windowsSelectionColor.Red} {windowsSelectionColor.Green} {windowsSelectionColor.Blue}";
        }

        /// <summary>
        /// Converts a Hex color to Rgb
        /// </summary>
        /// <param name="hexColor"></param>
        /// <returns></returns>
        public string HexToRgb(string hexColor)
        {
            System.Drawing.Color color = System.Drawing.ColorTranslator.FromHtml(hexColor);
            return $"{Convert.ToInt16(color.R)} {Convert.ToInt16(color.G)} {Convert.ToInt16(color.B)}";
        }

        /// <summary>
        /// Displays the color on the control
        /// </summary>
        /// <param name="hexColor"></param>
        /// <returns></returns>
        public Brush ColorDisplay(string hexColor)
        {
            Brush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(hexColor));
            return brush;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="color"></param>
        public void RecordingСolorHistory(string color)
        {
            using (FileStream stream = new FileStream(PATH_FILE_COLOR_HISTORY, FileMode.OpenOrCreate))
            {
                using(StreamWriter writer=new StreamWriter(stream))
                {
                    writer.WriteLine(color);
                }
            }
        }

    }
}
