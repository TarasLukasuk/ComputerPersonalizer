using System.Collections.Generic;
using System.IO;

namespace ComputerPersonalizerData
{
    public class ComputerPersonalizerData
    {
        private const string PATH_FILE_COLOR_HISTORY = @".\HistoryColor.txt";

        /// <summary>
        /// Saves a color to a file with color history
        /// </summary>
        /// <param name="color"></param>
        public void RecordingСolorHistory(string color)
        {
            using (FileStream stream = new FileStream(PATH_FILE_COLOR_HISTORY, FileMode.OpenOrCreate))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.WriteLine(color);
                }
            }
        }

        /// <summary>
        /// Reads the entire file history
        /// </summary>
        /// <returns></returns>
        public List<string> ReadingHistoryColors()
        {
            List<string> result = new List<string>();

            while (File.ReadLines(PATH_FILE_COLOR_HISTORY) != null)
            {
                string N = File.ReadLines(PATH_FILE_COLOR_HISTORY).ToString();
            }

            return result;
        }
    }
}
