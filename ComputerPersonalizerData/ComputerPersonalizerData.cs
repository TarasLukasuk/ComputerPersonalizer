using ComputerPersonalizerBL.Controllers.ControllerWindowsSelection;
using Microsoft.Win32;
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

        public List<string> ReadingHistoryColors()
        {
            List<string> result = new List<string>();

            using (FileStream stream = new FileStream(PATH_FILE_COLOR_HISTORY, FileMode.OpenOrCreate))
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

        public string GettingColorFromXmlFile()
        {
            string result=string.Empty;

            XDocument xdoc = XDocument.Load(PATH_FILE_SELECTED_СOLOR);
            XElement root = xdoc.Element("configuration");
            if (root != null)
            {
                foreach (XElement person in root.Elements("SelectedСolor"))
                {
                    result = person.Attribute("Color").Value;
                }

                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(PATH_FILE_SELECTED_СOLOR);
                XmlElement xRoot = xDoc.DocumentElement;
                XmlNode firstNode = xRoot?.FirstChild;
                if (firstNode !=null) xRoot?.RemoveChild(firstNode);
                xDoc.Save(PATH_FILE_SELECTED_СOLOR);
            }

            return result;
        }

        private const string HILIGHT = "0 120 215";
        private const string HOT_TRACKING_COLOR = "0 102 204";

        public void SaveWindowsSelectionColor(ControllerWindowsSelection controllerWindowsSelection)
        {
            using (RegistryKey registry = Registry.CurrentUser.CreateSubKey(@"Control Panel\Colors"))
            {
                registry.SetValue("Hilight", controllerWindowsSelection.ToString());
                registry.SetValue("HotTrackingColor", controllerWindowsSelection.ToString());
            }
        }

        public void ResetColor()
        {
            using (RegistryKey registry = Registry.CurrentUser.CreateSubKey(@"Control Panel\Colors"))
            {
                registry.SetValue("Hilight", HILIGHT);
                registry.SetValue("HotTrackingColor", HOT_TRACKING_COLOR);
            }
        }
    }
}
