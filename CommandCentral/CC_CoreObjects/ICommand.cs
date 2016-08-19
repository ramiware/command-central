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
    class ICommand : CommandObject
    {
        public string CmdDesc { get; set; }

        /// <summary>
        /// Constructor: Creates a Command object
        /// </summary>
        /// <param name="cmdName"></param>
        /// <param name="cmdDesc"></param>
        public ICommand(string cmdName, string cmdDesc)
        {
            CmdName = cmdName;
            CmdDesc = cmdDesc;
        }

        /// <summary>
        /// Constructor: Creates a Command object - retrieves CmdDesc from CommandsList
        /// </summary>
        /// <param name="cmdName"></param>
        public ICommand(string cmdName)
        {
            CmdName = cmdName;

            ICommandsList cmdList = new ICommandsList();
            CmdDesc = cmdList.getCmdDesc(cmdName);
        }

    }
}
