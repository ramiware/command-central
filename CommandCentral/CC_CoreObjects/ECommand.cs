using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandCentral.CC_CoreObjects
{
    public class ECommand : IComparable<ECommand>
    {
        public string CmdName { get; set; }
        public string RunCmd { get; set; }

        /// <summary>
        /// Constructor: Creates a Command object
        /// </summary>
        /// <param name="name"></param>
        /// <param name="runCmd"></param>
        public ECommand(string name, string runCmd)
        {
            this.CmdName = name;
            this.RunCmd = runCmd;
        }

        /// <summary>
        /// Constructor: Creates a Command object - retrieves RunCmd from CommandsList
        /// </summary>
        /// <param name="name"></param>
        public ECommand(string name)
        {
            CmdName = name;

            ECommandsList cmdList = new ECommandsList();
            RunCmd = cmdList.getRunCmd(name);
        }

        /// <summary>
        /// Override CompareTo using IComparable to use Sort() function
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(ECommand other)
        {
            return CmdName.CompareTo(other.CmdName);
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
            return other.CmdName == this.CmdName && other.RunCmd == this.RunCmd;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
