using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandCentral.CC_CoreObjects
{
    public class CustomCmd : CommandObject
    {
        public string RunCmd { get; set; }

        /// <summary>
        /// Constructor: Creates a Command object
        /// </summary>
        /// <param name="cmdName"></param>
        /// <param name="runCmd"></param>
        public CustomCmd(string cmdName, string runCmd)
        {
            this.CmdName = cmdName;
            this.RunCmd = runCmd;
        }

        /// <summary>
        /// Constructor: Creates a Command object - retrieves RunCmd from CommandsList
        /// </summary>
        /// <param name="cmdName"></param>
        public CustomCmd(string cmdName)
        {
            CmdName = cmdName;

            CustomCmdsList cmdList = new CustomCmdsList();
            RunCmd = cmdList.getRunCmd(cmdName);
        }
    }
}
