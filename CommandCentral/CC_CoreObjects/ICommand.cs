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
    class ICommand
    {
        public string CmdName { get; set; }
        public string CmdDesc { get; set; }

        public ICommand(string cmdName, string cmdDesc)
        {
            CmdName = cmdName;
            CmdDesc = cmdDesc;
        }
    }
}
