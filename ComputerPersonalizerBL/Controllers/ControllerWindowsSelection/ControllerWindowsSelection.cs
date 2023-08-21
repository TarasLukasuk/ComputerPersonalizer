using ComputerPersonalizerBL.PersonalizationElements.WindowsSelection;
using Microsoft.Win32;
using System.Drawing;

namespace ComputerPersonalizerBL.Controllers.ControllerWindowsSelection
{
    public class ControllerWindowsSelection
    {
        private readonly string Hilight= "0 120 215";
        private readonly string HotTrackingColor = "0 102 204";

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
                registry.SetValue("Hilight", Hilight);
                registry.SetValue("HotTrackingColor", HotTrackingColor);
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

    }
}
