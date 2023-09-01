using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace ComputerPersonalizerData
{
    public class ComputerPersonalizerDatas
    {
        private const string PATH_FILE_COLOR_HISTORY = @".\HistoryColor.txt";
        private readonly string PATH_FILE_SELECTED_СOLOR = $"{Environment.CurrentDirectory}".Replace("\\bin\\Debug", "\\File\\SelectedСolor.config");


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

            using (FileStream stream = new FileStream(PATH_FILE_COLOR_HISTORY,FileMode.OpenOrCreate))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        result.Add(line);
                    }
                }
            }

            return result;
        }

        public void CreateandRecordStructureXml(string color)
        {
            XDocument xdoc = new XDocument();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(PATH_FILE_SELECTED_СOLOR);
            XElement tom = new XElement("SelectedСolor");
            XAttribute tomNameAttr = new XAttribute("Color", color);
            tom.Add(tomNameAttr);


            XElement people = new XElement("configuration");
            people.Add(tom);
            xdoc.Add(people);
            xdoc.Save(PATH_FILE_SELECTED_СOLOR);
        }
    }
}
