using CommandCentral.CC_Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CommandCentral.CC_Data
{
    class AppSettings
    {
        private string SETTINGS_FILEPATH = "";
        private string SETTINGS_FILENAME = "settings.rami";

        // Settings
        public enum CCSettingKeys
        {
            //BackColor,
            //ForeColor,
            Transparency,
            TopMost,
            Width,
            Height,
            LocX,
            LocY,
            CPUThresholdLevel1,
            CPUThresholdLevel2,
            RAMThresholdLevel1,
            RAMThresholdLevel2
        }


        /// <summary>
        /// Create settings file and path if it does not already exist
        /// </summary>
        public AppSettings()
        {
            FileStream settingsFile = null;
            try
            {
                // Create Path if it does not exist - C:\Users\ramis\AppData\Local\Ramiware\
                SETTINGS_FILEPATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData, Environment.SpecialFolderOption.Create), About.APP_PARENT_NAME + @"\" + About.APP_NAME_LONG);
                SETTINGS_FILEPATH += @"\";

                if (!Directory.Exists(SETTINGS_FILEPATH))
                    Directory.CreateDirectory(SETTINGS_FILEPATH);

                if (!File.Exists(SETTINGS_FILEPATH + SETTINGS_FILENAME))
                {
                    settingsFile = File.Create(SETTINGS_FILEPATH + SETTINGS_FILENAME);
                    settingsFile.Close();

                    StreamWriter sr = null;
                    using (sr = new StreamWriter(SETTINGS_FILEPATH + SETTINGS_FILENAME))
                    {
                        sr.WriteLine(CCSettingKeys.LocX.ToString() + "=0");
                        sr.WriteLine(CCSettingKeys.LocY.ToString() + "=0");
                        sr.WriteLine(CCSettingKeys.Height.ToString() + "=0");
                        sr.WriteLine(CCSettingKeys.Width.ToString() + "=0");
                        sr.WriteLine(CCSettingKeys.Transparency.ToString() + "=" + Lib.DEFAULT_TRANSPARENCY.ToString());
                        sr.WriteLine(CCSettingKeys.TopMost.ToString() + "=No");
                        sr.WriteLine(CCSettingKeys.CPUThresholdLevel1.ToString() + "=" + Lib.DEFAULT_CPU_THRESHOLD_WARNING_LEVEL1.ToString());
                        sr.WriteLine(CCSettingKeys.CPUThresholdLevel2.ToString() + "=" + Lib.DEFAULT_CPU_THRESHOLD_WARNING_LEVEL2.ToString());
                        sr.WriteLine(CCSettingKeys.RAMThresholdLevel1.ToString() + "=" + Lib.DEFAULT_RAM_THRESHOLD_WARNING_LEVEL1.ToString());
                        sr.WriteLine(CCSettingKeys.RAMThresholdLevel2.ToString() + "=" + Lib.DEFAULT_RAM_THRESHOLD_WARNING_LEVEL2.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("An Error occurred while trying to create the Settings file." + About.APP_CONTACT + "\n\n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                settingsFile.Close();
                return;
            }
        }

        /// <summary>
        /// Returns the value of the settingKey requested
        /// </summary>
        /// <param name="settingKey"></param>
        /// <returns></returns>
        public string getSettingValue(CCSettingKeys settingKey)
        {
            StreamReader sr = null;
            try
            {
                using (sr = new StreamReader(SETTINGS_FILEPATH + SETTINGS_FILENAME))
                {
                   
                    string currReadLine = "";
                    while (sr.Peek() != -1)
                    {
                        currReadLine = sr.ReadLine();

                        if (currReadLine.Contains(settingKey.ToString()))
                        {
                            sr.Close();
                            return currReadLine.Replace(settingKey.ToString() + "=", "");
                        }
                    }
                    sr.Close();
                    return "";
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("An Error occurred while trying to access the Settings file." + About.APP_CONTACT + "\n\n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sr.Close();
                return "";
            }
            finally
            {
                sr.Close();
            }
 
        }

        /// <summary>
        /// Sets the settingValue to the settingKey in the settings file
        /// </summary>
        /// <param name="settingKey"></param>
        /// <param name="settingValue"></param>
        /// <returns></returns>
        public bool setSettingsValue(CCSettingKeys settingKey, string settingValue)
        {
            List<string> fileContentsList = new List<string>();
            StreamReader sr = null;
            StreamWriter sw = null;
            try
            {
                using (sr = new StreamReader(SETTINGS_FILEPATH + SETTINGS_FILENAME))
                {
                    while (sr.Peek() != -1)
                        fileContentsList.Add(sr.ReadLine());
                }
                sr.Close();

                using (sw = new StreamWriter(SETTINGS_FILEPATH + SETTINGS_FILENAME))
                {
                    foreach (string line in fileContentsList)
                    {
                        if (line.Contains(settingKey.ToString()))
                            sw.WriteLine(settingKey.ToString() + "=" + settingValue);
                        else
                            sw.WriteLine(line);
                    }
                    sw.Close();
                    return true;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("An Error occurred while trying to access the Settings file." + About.APP_CONTACT + "\n\n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sr.Close();
                return false;
            }
            finally
            {
                sr.Close();
            }
        }

    }
}
