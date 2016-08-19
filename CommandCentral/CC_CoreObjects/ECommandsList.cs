using CommandCentral.CC_Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandCentral.CC_CoreObjects
{
    public class ECommandsList
    {
        // List of Commands
        private List<ECommand> cmdsList = new List<ECommand>();

        /// <summary>
        /// Constructor: Loads the commands file entries into the cmdsList local object
        /// </summary>
        public ECommandsList()
        {
            // get commands from command file as array list
            // parse into List<Command> format
            CommandsFile cmdsFile = new CommandsFile();
            ArrayList cmdsListAsArrayList = cmdsFile.getFileContentsAsArrayList();
            string name, runCmd;
            foreach (string currItem in cmdsListAsArrayList)
            {
                name = currItem.Substring(0, currItem.IndexOf("=")).Trim().ToUpper();
                runCmd = currItem.Substring(currItem.IndexOf("=") + 1).Trim();
                cmdsList.Add(new ECommand(name, runCmd));
            }
        }

        /// <summary>
        /// Add newCmd to cmdsList and command file if it does not already exist
        /// </summary>
        /// <param name="newCmd"></param>
        /// <returns></returns>
        public bool addCmd(ECommand newCmd)
        {
            // do not allow 2 commands with same name
            if (cmdsList.Contains(newCmd))
                return false;

            // add cmd to list
            newCmd.CmdName = newCmd.CmdName.ToUpper();
            cmdsList.Add(newCmd);
            // add cmd to file
            CommandsFile cmdsFile = new CommandsFile();
            cmdsFile.writeCmdsToFile(cmdsList);

            return true;
        }

        /// <summary>
        /// Removes the cmd from the cmdsList and command filea
        /// </summary>
        /// <param name="removeCmd"></param>
        public void removeCmd(ECommand removeCmd)
        {
            // remove cmd from list
            cmdsList.Remove(removeCmd);
            // remove cmd from file
            CommandsFile cmdsFile = new CommandsFile();
            cmdsFile.writeCmdsToFile(cmdsList);
        }

        /// <summary>
        /// Returns the Commands List
        /// </summary>
        /// <returns></returns>
        public List<ECommand> getCommandsList()
        {
            return cmdsList;
        }

        /// <summary>
        /// Returns the RunCmd for any given cmd
        /// </summary>
        /// <param name="cmdName"></param>
        /// <returns></returns>
        internal string getRunCmd(string cmdName)
        {
            foreach (ECommand cmdItem in cmdsList)
            {
                if (cmdItem.CmdName.Equals(cmdName, StringComparison.CurrentCultureIgnoreCase))
                    return cmdItem.RunCmd;
            }
            return "";
        }
    }
}
