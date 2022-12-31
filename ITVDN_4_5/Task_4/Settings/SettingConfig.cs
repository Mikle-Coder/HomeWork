using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Xml;

namespace Task_4.Settings
{
    class SettingConfig : Settings
    {
        string xmlName  = "Settings.config";

        public SettingConfig() : base() 
        {
            if (!File.Exists(xmlName))
                CreateConfigDocument(xmlName);

            ReadFromXML();
        }

        public override void SaveSettings()
        {
            string[] values = Values;

            for (int i = 0; i < Keys.Length; i++)
                UpdateAppSettings(Keys[i], values[i]);
        }

        private void ReadFromXML()
        {
            // Восстановление состояния:
            var bc = new BrushConverter();
            string messageException = string.Empty;


            var configFile = ConfigurationManager.OpenExeConfiguration("Settings.config");
            var settings = configFile.AppSettings.Settings;

            try
            {
                BackColor = (Brush)bc.ConvertFromString(settings["BackColor"].Value);
            }
            catch (Exception)
            {
                BackColor = (Brush)bc.ConvertFromString(Colors.AliceBlue.ToString());
                messageException += "Цвет фона задан не верно: " + settings["BackColor"] + Environment.NewLine;
            }

            try
            {
                TextColor = (Brush)bc.ConvertFromString(settings["TextColor"].Value);
            }
            catch (Exception)
            {
                TextColor = (Brush)bc.ConvertFromString(Colors.Black.ToString());
                messageException += "Цвет текста задан не верно: " + settings["TextColor"] + Environment.NewLine;
            }

            try
            {
                TextSize = int.Parse(settings["TextSize"].Value);
            }
            catch (Exception)
            {
                TextSize = 12;
                messageException += "Размер текста задан не верно: " + settings["TextSize"] + Environment.NewLine;
            }

            try
            {
                TextFont = new FontFamily(settings["TextFont"].Value);
            }
            catch (Exception)
            {
                TextFont = new FontFamily("Segoe UI");
            }


            if (!string.IsNullOrEmpty(messageException))
            {
                MessageBox.Show(messageException);
            }
        }

        private void CreateConfigDocument(string filename)
        {
            

            System.Text.StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            sb.AppendLine("<configuration>");
            sb.AppendLine("</configuration>");

            System.IO.File.WriteAllText(xmlName, sb.ToString());

            SaveSettings();
        }

        public void UpdateAppSettings(string key, string value)
        {
            try
            {
                ConfigurationManager.Crea
                var configFile = ConfigurationManager.OpenExeConfiguration(xmlName);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save();
                ConfigurationManager.RefreshSection(xmlName);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }
    }
}
