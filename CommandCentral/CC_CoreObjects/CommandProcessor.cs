using CommandCentral.CC_Common;
using CommandCentral.CC_UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommandCentral.CC_CoreObjects
{
    class CommandProcessor
    {
        private CommandCentralWindow oCmdWin;

        private ICommandsList oICommandsList = new ICommandsList();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cmdWinReference"></param>
        public CommandProcessor(CommandCentralWindow cmdWinReference)
        {
            oCmdWin = cmdWinReference;
        }

        /// <summary>
        /// Handles internal and external command execution
        /// </summary>
        /// <returns></returns>
        public bool executeCmd(ECommand cmd, out string runCmdReturnString)
        {
            try
            {
                // ----------------------------------------------------
                // VALIDATION
                // ----------------------------------------------------
                if (cmd.CmdName.Trim().Length == 0)
                {
                    runCmdReturnString = "";
                    return true;
                }

                // ----------------------------------------------------
                // DISPLAY HELP
                // ----------------------------------------------------
                // help - display help text
                if (cmd.CmdName.Equals("help", StringComparison.CurrentCultureIgnoreCase))
                {
                    runCmdReturnString = "Try a cmd from the Commands List " + Lib.NL +
                                         "or try /i for a list of Internal Commands." + Lib.NL;
                    return true;
                }

                // /i - display internal commands
                if (cmd.CmdName.Equals("/i", StringComparison.CurrentCultureIgnoreCase))
                {
                    runCmdReturnString = "Here is a list of Internal Commands" + Lib.NL;

                    for (int i = 0; i < oICommandsList.getCommandsList().Count; i++)
                        runCmdReturnString += "[" + oICommandsList.getCommandsList()[i].CmdName + "]" + Lib.NL + oICommandsList.getCommandsList()[i].CmdDesc + Lib.NL;

                    return true;
                }

                // ----------------------------------------------------
                // INTERNAL COMMAND?
                // ----------------------------------------------------
                for (int i = 0; i < oICommandsList.getCommandsList().Count; i++)
                {
                    if (cmd.CmdName.Equals(oICommandsList.getCommandsList()[i].CmdName, StringComparison.CurrentCultureIgnoreCase))
                    {
                        processInternalCmd(cmd.CmdName);
                        runCmdReturnString = "";
                        return true;
                    }
                }

                // ----------------------------------------------------
                // EXTERNAL COMMAND?
                // ----------------------------------------------------
                // Validate RunCmd
                if (cmd.RunCmd == null || cmd.RunCmd.Length == 0)
                {
                    runCmdReturnString = "Command not found.  Try 'help'.";
                    return false;
                }

                // Run custom/external command
                Process thisProcess = Process.Start(cmd.RunCmd);
                runCmdReturnString = "Executing...";
                return true;

            }
            catch (Exception e)
            {
                runCmdReturnString = "Command failed.  Try 'help'.";
                return false;
            }
        }

        /// <summary>
        /// processes internal commands
        /// </summary>
        /// <param name="cmdName"></param>
        private void processInternalCmd(string cmdName)
        {
            // Is this an actual internal command?
            bool internalCmdFound = false;
            for (int i = 0; i < oICommandsList.getCommandsList().Count; i++)
            {
                if (cmdName.Equals(oICommandsList.getCommandsList()[i].CmdName, StringComparison.CurrentCultureIgnoreCase))
                {
                    internalCmdFound = true;
                    break;
                }
            }

            if (!internalCmdFound)
                return;

            // mngcmds
            if (cmdName.Equals("cmdmngr", StringComparison.CurrentCultureIgnoreCase))
            {
                CommandManagerWindow oCmdMngrWin = new CommandManagerWindow(oCmdWin);
                oCmdMngrWin.StartPosition = FormStartPosition.CenterParent;
                oCmdMngrWin.ShowDialog(oCmdWin);
            }

            // clear
            if (cmdName.Equals("clear", StringComparison.CurrentCultureIgnoreCase))
                oCmdWin.clearScreen();

            // exit script
            if (cmdName.Equals("exit", StringComparison.CurrentCultureIgnoreCase))
                Application.Exit();

        }
    }
}
