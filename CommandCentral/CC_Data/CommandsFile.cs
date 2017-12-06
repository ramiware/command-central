using CommandCentral.CC_Common;
using CommandCentral.CC_CoreObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommandCentral.CC_Data
{
    class CommandsFile
    {
        private string COMMANDS_FILEPATH = "";
        private string COMMANDS_FILENAME = "commands.rami";

        /// <summary>
        /// Create commands file and path if it does not exist
        /// </summary>
        public CommandsFile()
        {
            FileStream commandsFile = null;
            try
            {
                // Create Path if it does not exist - C:\Users\ramis\AppData\Local\Ramiware\
                COMMANDS_FILEPATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData, Environment.SpecialFolderOption.Create), About.APP_PARENT_NAME + @"\" + About.APP_NAME_LONG);
                COMMANDS_FILEPATH += @"\";

                if (!Directory.Exists(COMMANDS_FILEPATH))
                    Directory.CreateDirectory(COMMANDS_FILEPATH);

                if (!File.Exists(COMMANDS_FILEPATH + COMMANDS_FILENAME))
                {
                    commandsFile = File.Create(COMMANDS_FILEPATH + COMMANDS_FILENAME);
                    commandsFile.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("An Error occurred while trying to create the Commands File." + About.APP_CONTACT + "\n\n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                commandsFile.Close();
                return;
            }
        }

        /// <summary>
        /// Returns the file contents as an ArrayList
        /// </summary>
        /// <returns></returns>
        public ArrayList getFileContentsAsArrayList()
        {
            ArrayList fileContents = new ArrayList();
            StreamReader sr = null;
            try
            {
                using (sr = new StreamReader(COMMANDS_FILEPATH + COMMANDS_FILENAME))
                {
                    while (sr.Peek() != -1)
                        fileContents.Add(sr.ReadLine());

                    sr.Close();

                    return fileContents;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("An Error occurred while trying to access the Commands File." + About.APP_CONTACT + "\n\n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sr.Close();
                return new ArrayList();
            }
            finally
            {
                sr.Close();
            }
        }

        /// <summary>
        /// Writes the cmdList to the commands file
        /// </summary>
        /// <param name="cmdList"></param>
        /// <returns></returns>
        internal bool writeCmdsToFile(List<ECommand> cmdList)
        {
            StreamWriter sw = null;
            try
            {
                using (sw = File.CreateText(COMMANDS_FILEPATH + COMMANDS_FILENAME))
                {
                    FileInfo commandsFile = new FileInfo(COMMANDS_FILEPATH + COMMANDS_FILENAME);

                    foreach (ECommand cmd in cmdList)
                        sw.WriteLine(cmd.CmdName+"="+cmd.RunCmd);

                    sw.Close();

                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("An Error occurred while trying to add to the Commands File." + About.APP_CONTACT + "\n\n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sw.Close();
                return false;
            }
            finally
            {
                sw.Close();
            }
        }
    }
}
