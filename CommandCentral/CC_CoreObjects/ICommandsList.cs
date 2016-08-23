using CommandCentral.CC_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandCentral.CC_CoreObjects
{
    class ICommandsList
    {

        private List<ICommand> iCmdList = new List<ICommand>();

        public ICommandsList()
        {
            iCmdList.Add(new ICommand("cmdmgr", "-add/edit/del items from your Commands List"));
            iCmdList.Add(new ICommand("clear", "-clears the screen"));
            iCmdList.Add(new ICommand("exit", "-closes the application"));

        }

        /// <summary>
        /// Returns the Commands List
        /// </summary>
        /// <returns></returns>
        public List<ICommand> getCommandsList()
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
            foreach (ICommand cmdItem in iCmdList)
            {
                if (cmdItem.CmdName.Equals(cmdName, StringComparison.CurrentCultureIgnoreCase))
                    return cmdItem.CmdDesc;
            }
            return "";
        }
    }
}
