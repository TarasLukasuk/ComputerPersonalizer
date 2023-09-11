using ComputerPersonalizerBL.PersonalizationElements.WindowsSelection;
using System;
using System.Windows.Media;

namespace ComputerPersonalizerBL.Controllers.ControllerWindowsSelection
{
    public sealed class ControllerWindowsSelection
    {
        public ControllerWindowsSelection(int Red, int Green, int Blue) => windowsSelectionColor = new WindowsSelectionColor(Red, Green, Blue);

        public ControllerWindowsSelection() => windowsSelectionColor = new WindowsSelectionColor(255, 255, 255);

        private readonly WindowsSelectionColor windowsSelectionColor;

        public string RgbToHex() => $"#{windowsSelectionColor.Red:X2}" + $"{windowsSelectionColor.Green:X2}" + $"{windowsSelectionColor.Blue:X2}";

        public override string ToString() => $"{windowsSelectionColor.Red} {windowsSelectionColor.Green} {windowsSelectionColor.Blue}";

        public string HexToRgb(string hexColor)
        {
            System.Drawing.Color color = System.Drawing.ColorTranslator.FromHtml(hexColor);
            return $"{Convert.ToInt16(color.R)} {Convert.ToInt16(color.G)} {Convert.ToInt16(color.B)}";
        }

        public Brush ColorDisplay(string hexColor)
        {
            Brush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(hexColor));
            return brush;
        }
    }
}
