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
        private string COMMANDS_FILEPATH = Application.StartupPath + @"\" + Environment.UserName + @"\";
        private string COMMANDS_FILENAME = "commands.rami";

        /// <summary>
        /// Create commands file and path if it does not exist
        /// </summary>
        public CommandsFile()
        {
            FileStream commandsFile = null;
            try
            {
                if (!Directory.Exists(COMMANDS_FILEPATH))
                    Directory.CreateDirectory(COMMANDS_FILEPATH);

                if (!File.Exists(COMMANDS_FILEPATH + COMMANDS_FILENAME))
                {
                    commandsFile = File.Create(COMMANDS_FILEPATH + COMMANDS_FILENAME);
                    commandsFile.Close();
                }
            }
            catch //(Exception e)
            {
                //Console.WriteLine("An error occurred while trying to create the commands file.\n\n" +
                //                 e.Message, "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //oLogFile.WriteLine("An error occurred while trying to create the commands file.\n" + e.Message, LogFile.LOG_TYPES.DEBUG);

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
            catch //(Exception e)
            {
                //MessageBox.Show("An error occurred while trying to access your playlist file contents\n\n" +
                //                 e.Message, "Read Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //oLogFile.WriteLine("An error occurred while trying to access your playlist file contents\n" + e.Message, LogFile.LOG_TYPES.DEBUG);
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
                    FileInfo playlistFile = new FileInfo(COMMANDS_FILEPATH + COMMANDS_FILENAME);

                    foreach (ECommand cmd in cmdList)
                        sw.WriteLine(cmd.CmdName+"="+cmd.RunCmd);

                    sw.Close();

                    return true;
                }
            }
            catch //(Exception e)
            {
                //MessageBox.Show("An error occurred while trying ..\n\n" +
                //                 e.Message, "Add Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //oLogFile.WriteLine("An error occurred while trying to ... ", LogFile.LOG_TYPES.DEBUG);
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
