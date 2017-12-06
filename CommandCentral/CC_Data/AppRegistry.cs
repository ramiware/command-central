using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandCentral.CC_Data
{
    class AppRegistry
    {
        // Constants
        private const string APP_PARENT = "RAMIWARE";
        private const string APP_NAME = "Command Central";
        private const string APP_VERSION = "4.0";

        // Reigstry object
        private RegistryKey key;

        // Registery Keys
        public enum CCKeys
        {
            BackColor,
            ForeColor,
            Transparency,
            TopMost,
            Width,
            Height,
            LocX,
            LocY
        }

        /// <summary>
        /// Create app directory in register for current user if it does not already exist
        /// </summary>
        public AppRegistry()
        {
            try
            {
                // Get into "Software" node
                key = Registry.CurrentUser.OpenSubKey("Software", true);

                // Create SubKey APP_PARENT if it does not already exist
                if (key.OpenSubKey(APP_PARENT) == null)
                    key.CreateSubKey(APP_PARENT);
                key = key.OpenSubKey(APP_PARENT, true);

                // Create SubKey APP_NAME if it does not already exist
                if (key.OpenSubKey(APP_NAME) == null)
                    key.CreateSubKey(APP_NAME);
                key = key.OpenSubKey(APP_NAME, true);

                // Create SubKey APP_VERSION if it does not already exist
                if (key.OpenSubKey(APP_VERSION) == null)
                    key.CreateSubKey(APP_VERSION);
                key = key.OpenSubKey(APP_VERSION, true);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error ocurred in AppRegistry() " + "\n\n" + e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool setKeyValue(CCKeys key, string value)
        {
            try
            {
                this.key.SetValue(key.ToString(), value);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error ocurred in AppRegistry() " + "\n\n" + e.Message);
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getKeyValue(CCKeys key)
        {
            if (this.key.GetValue(key.ToString()) == null)
                return "";

            return this.key.GetValue(key.ToString()).ToString();
        }
    }
}
