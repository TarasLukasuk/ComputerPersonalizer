namespace ComputerPersonalizerBL.PersonalizationElements.WindowsSelection
{
    internal struct WindowsSelectionColor
    {
        /// <summary>
        /// Creating a color structure
        /// </summary>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        public WindowsSelectionColor(int red, int green, int blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }
    }
}
