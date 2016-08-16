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
            iCmdList.Add(new ICommand("cmdmngr", "-allows you to add/edit/del commands"));
            iCmdList.Add(new ICommand("clear", "-clears the screen"));
            iCmdList.Add(new ICommand("exit", "-closes the application"));

        }

        public List<ICommand> getCommandsList()
        {
            return this.iCmdList;
        }
    }
}
