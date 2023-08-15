using ComputerPersonalizerBL.PersonalizationElements.WindowsSelection;
using Microsoft.Win32;

namespace ComputerPersonalizerBL.Controllers.ControllerWindowsSelection
{
    public class ControllerWindowsSelection
    {
        private readonly string Hilight= "0 120 215";
        private readonly string HotTrackingColor = "0 102 204";

        private WindowsSelectionColor windowsSelection;

        /// <summary>
        /// Assigning colors
        /// </summary>
        /// <param name="Red"></param>
        /// <param name="Green"></param>
        /// <param name="Blue"></param>
        public ControllerWindowsSelection(int Red, int Green, int Blue)
        {
            windowsSelection = new WindowsSelectionColor(Red, Green, Blue);
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
        /// Overriding the ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{windowsSelection.Red} {windowsSelection.Green} {windowsSelection.Blue}";
        }
    }
}
