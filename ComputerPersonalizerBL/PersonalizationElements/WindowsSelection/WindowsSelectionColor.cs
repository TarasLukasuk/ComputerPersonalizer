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

        public int Red { get;}
        public int Green { get;}
        public int Blue { get;}
    }
}
