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

        /// <summary>
        /// Override Equals so that we can use Remove() function
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var other = obj as ECommand;
            if (other == null)
                return false;
            return other.CmdName.Equals(this.CmdName, StringComparison.CurrentCultureIgnoreCase);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
