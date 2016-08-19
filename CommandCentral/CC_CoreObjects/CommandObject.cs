using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandCentral.CC_CoreObjects
{
    public class CommandObject : IComparable<CommandObject>
    {
        public string CmdName { get; set; }


        public CommandObject() 
        {
            CmdName = "";
        }

        public CommandObject(string cmdName)
        {
            CmdName = cmdName;
        }

        /// <summary>
        /// Override CompareTo using IComparable to use Sort() function
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(CommandObject other)
        {
            return CmdName.CompareTo(other.CmdName);
        }

        /// <summary>
        /// Override Equals so that we can use Remove(), Contains() functions
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var other = obj as CommandObject;
            if (other == null)
                return false;
            return other.CmdName.ToLower() == this.CmdName.ToLower();
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
