using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandCentral.CC_CoreObjects
{
    public class ECommand : CommandObject
    {
        public string RunCmd { get; set; }

        /// <summary>
        /// Constructor: Creates a Command object
        /// </summary>
        /// <param name="cmdName"></param>
        /// <param name="runCmd"></param>
        public ECommand(string cmdName, string runCmd)
        {
            this.CmdName = cmdName;
            this.RunCmd = runCmd;
        }

        /// <summary>
        /// Constructor: Creates a Command object - retrieves RunCmd from CommandsList
        /// </summary>
        /// <param name="cmdName"></param>
        public ECommand(string cmdName)
        {
            CmdName = cmdName;

            ECommandsList cmdList = new ECommandsList();
            RunCmd = cmdList.getRunCmd(cmdName);
        }
    }
}
