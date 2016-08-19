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
        public bool executeCmd(ECommand cmd, out CommandGridAttributes.RowType nextRowRowType, out string runCmdReturnString)
        {
            try
            {
                // ----------------------------------------------------
                // VALIDATION
                // ----------------------------------------------------
                if (cmd.CmdName.Trim().Length == 0)
                {
                    runCmdReturnString = "";
                    nextRowRowType = CommandGridAttributes.RowType.Blank;
                    return true;
                }

                // ----------------------------------------------------
                // DISPLAY INTERNAL COMMANDS
                // ----------------------------------------------------

                // /i - display internal commands
                if (cmd.CmdName.Equals("/i", StringComparison.CurrentCultureIgnoreCase))
                {
                    runCmdReturnString = "Here is a list of Internal Commands" + Lib.NL;

                    for (int i = 0; i < oICommandsList.getCommandsList().Count; i++)
                        runCmdReturnString += "[" + oICommandsList.getCommandsList()[i].CmdName + "]" + Lib.NL + oICommandsList.getCommandsList()[i].CmdDesc + Lib.NL;

                    nextRowRowType = CommandGridAttributes.RowType.InfoMsg;
                    return true;
                }

                // ----------------------------------------------------
                // INTERNAL COMMAND?
                // ----------------------------------------------------
                for (int i = 0; i < oICommandsList.getCommandsList().Count; i++)
                {
                    if (cmd.CmdName.Equals(oICommandsList.getCommandsList()[i].CmdName))
                    {
                        processInternalCmd(cmd.CmdName, out nextRowRowType, out runCmdReturnString);
                        return true;
                    }
                }

                // ----------------------------------------------------
                // EXTERNAL COMMAND?
                // ----------------------------------------------------
                processExternalCmd(cmd.CmdName, out nextRowRowType, out runCmdReturnString);
                return true;

            }
            catch (Exception e)
            {
                runCmdReturnString = "Command failed. " + Lib.NL +
                                     "Try a cmd from the Commands List " + Lib.NL +
                                     "or try /i for a list of Internal Commands." + Lib.NL;
                nextRowRowType = CommandGridAttributes.RowType.ErrorMsg;
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="runCmd"></param>
        /// <param name="nextRowRowType"></param>
        /// <param name="runCmdReturnString"></param>
        /// <returns></returns>
        private bool processExternalCmd(string cmdName, out CommandGridAttributes.RowType nextRowRowType, out string runCmdReturnString)
        {
            // Validate cmdName
            if (cmdName == null || cmdName.Length == 0)
            {
                runCmdReturnString = "";
                nextRowRowType = CommandGridAttributes.RowType.ReadyForInput;
                return false;
            }

            // Get RunCmd using CmdName
            string cmdNameValue = (!cmdName.Contains(" ")) ? cmdName : cmdName.Substring(0, cmdName.IndexOf(" "));
            string cmdParmsValue = (!cmdName.Contains(" ")) ? "" : cmdName.Substring(cmdName.IndexOf(" ")+1);
            ECommand eCmd = new ECommand(cmdNameValue);

              
            // Validate RunCmd
            if (eCmd.RunCmd == null || eCmd.RunCmd.Length == 0)
            {
                runCmdReturnString = "Command not found. " + Lib.NL +
                                     "Try a cmd from the Commands List " + Lib.NL +
                                     "or try /i for a list of Internal Commands." + Lib.NL;
                nextRowRowType = CommandGridAttributes.RowType.ErrorMsg;
                return false;
            }

            try
            {
                // Attempt to run external cmd
                Process cmdProcess;

                // Run without parms
                if (cmdParmsValue.Length == 0)
                {
                    cmdProcess = Process.Start(eCmd.RunCmd);
                    runCmdReturnString = "Executing...";
                    nextRowRowType = CommandGridAttributes.RowType.InfoMsg;
                    return true;
                }
                // Run with parms
                if (cmdParmsValue.Length > 0)
                {
                    cmdProcess = Process.Start(eCmd.RunCmd, cmdParmsValue);
                    runCmdReturnString = "Executing...";
                    nextRowRowType = CommandGridAttributes.RowType.InfoMsg;
                    return true;
                }

                // All other cases
                runCmdReturnString = "";
                nextRowRowType = CommandGridAttributes.RowType.ReadyForInput;
                return true;
            }
            catch (Exception e)
            {
                runCmdReturnString = "Command failed. " + Lib.NL +
                                     "Try a cmd from the Commands List " + Lib.NL +
                                     "or try /i for a list of Internal Commands." + Lib.NL;
                nextRowRowType = CommandGridAttributes.RowType.ErrorMsg;
                return false;
            }
        }

        /// <summary>
        /// processes internal commands
        /// </summary>
        /// <param name="cmdName"></param>
        private void processInternalCmd(string cmdName, out CommandGridAttributes.RowType nextRowRowType, out string runCmdReturnString)
        {
            // Is this an actual internal command?
            bool internalCmdFound = false;
            for (int i = 0; i < oICommandsList.getCommandsList().Count; i++)
            {
                if (cmdName.Equals(oICommandsList.getCommandsList()[i].CmdName))
                {
                    internalCmdFound = true;
                    break;
                }
            }

            runCmdReturnString = "";
            nextRowRowType = CommandGridAttributes.RowType.ReadyForInput;
            if (!internalCmdFound)
                return;

            // mngcmds
            if (cmdName.Equals("cmdmngr"))
            {
                CommandManagerWindow oCmdMngrWin = new CommandManagerWindow(oCmdWin);
                oCmdMngrWin.StartPosition = FormStartPosition.CenterParent;
                oCmdMngrWin.ShowDialog(oCmdWin);
            }

            // clear
            if (cmdName.Equals("clear"))
            {
                runCmdReturnString = Lib.FIRST_LINE_VALUE;
                nextRowRowType = CommandGridAttributes.RowType.InfoMsg;
                oCmdWin.clearScreen();
            }

            // exit script
            if (cmdName.Equals("exit"))
                Application.Exit();

        }
    }
}
