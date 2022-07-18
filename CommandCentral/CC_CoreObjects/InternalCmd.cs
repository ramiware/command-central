using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandCentral.CC_CoreObjects
{
    /// <summary>
    /// Internal Commands
    /// </summary>
    public class InternalCmd : CommandObject
    {
        public string CmdDesc { get; set; }

        /// <summary>
        /// Constructor: Creates a Command object
        /// </summary>
        /// <param name="cmdName"></param>
        /// <param name="cmdDesc"></param>
        public InternalCmd(string cmdName, string cmdDesc)
        {
            CmdName = cmdName;
            CmdDesc = cmdDesc;
        }

        /// <summary>
        /// Constructor: Creates a Command object - retrieves CmdDesc from CommandsList
        /// </summary>
        /// <param name="cmdName"></param>
        public InternalCmd(string cmdName)
        {
            CmdName = cmdName;

            InternalCmdsList cmdList = new InternalCmdsList();
            CmdDesc = cmdList.getCmdDesc(cmdName);
        }

    }
}
