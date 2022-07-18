using CommandCentral.CC_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandCentral.CC_CoreObjects
{
    class InternalCmdsList
    {

        private List<InternalCmd> iCmdList = new List<InternalCmd>();

        public InternalCmdsList()
        {
            iCmdList.Add(new InternalCmd("cmdmgr", "- add/edit/del items from your Commands List"));
            iCmdList.Add(new InternalCmd("settings", "- command central settings window"));
            iCmdList.Add(new InternalCmd("note", "- creates a note taking window"));
            iCmdList.Add(new InternalCmd("onotes", "- opens all saved notes"));
            iCmdList.Add(new InternalCmd("clear", "- clears the screen"));
            iCmdList.Add(new InternalCmd("exit", "- closes the application"));

        }

        /// <summary>
        /// Returns the Commands List
        /// </summary>
        /// <returns></returns>
        public List<InternalCmd> getCommandsList()
        {
            return this.iCmdList;
        }

        /// <summary>
        /// Returns the CmdDesc for any given cmd
        /// </summary>
        /// <param name="cmdName"></param>
        /// <returns></returns>
        internal string getCmdDesc(string cmdName)
        {
            foreach (InternalCmd cmdItem in iCmdList)
            {
                if (cmdItem.CmdName.Equals(cmdName, StringComparison.CurrentCultureIgnoreCase))
                    return cmdItem.CmdDesc;
            }
            return "";
        }
    }
}
