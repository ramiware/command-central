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
        private ECommandsList oECommandsList = new ECommandsList();


        // Command Process Return Types
        public enum ReturnType
        {
            ErrorMsg,
            InfoMsg,
            ExecMsg,
            ReadyForInput
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cmdWinReference"></param>
        public CommandProcessor(CommandCentralWindow cmdWinReference)
        {
            oCmdWin = cmdWinReference;
        }

        /// <summary>
        /// Handles internal, external, and native command execution
        /// </summary>
        /// <returns></returns>
        public bool executeCmd(CommandObject cmd, out ReturnType runCmdReturnType, out string runCmdReturnString)
        {
            try
            {
                // Validate
                if (!isCmdNameValid(cmd, out runCmdReturnType, out runCmdReturnString))
                    return true;

                // Get clean cmdName
                string cmdNameValue = cmd.CmdName.Trim();

                // Is this a Help command request?
                if (isHelpCommand(cmdNameValue, out runCmdReturnType, out runCmdReturnString))
                    return true;


                // Is this an Internal Command request?
                if (oICommandsList.getCommandsList().Contains(new ICommand(cmdNameValue)))
                    return processInternalCmd(new ICommand(cmdNameValue), out runCmdReturnType, out runCmdReturnString);


                // Is this an External command request?
                // If processExternalCmd returns false, try to process as a native windows command.
                if (!processExternalCmd(cmdNameValue, out runCmdReturnType, out runCmdReturnString))
                    return tryProcessNativeCmd(cmdNameValue, out runCmdReturnType, out runCmdReturnString);
                else 
                    return true;

            }
            catch (Exception e)
            {
                runCmdReturnString = Lib.TEXT_TRY_HELP_CMDFAILED;
                runCmdReturnType = ReturnType.ErrorMsg;
                return false;
            }
        }

        /// <summary>
        /// Validates the cmd object and the cmdName attribute
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="runCmdReturnType"></param>
        /// <param name="runCmdReturnString"></param>
        /// <returns></returns>
        private bool isCmdNameValid(CommandObject cmd, out ReturnType runCmdReturnType, out string runCmdReturnString)
        {
            if (cmd == null || cmd.CmdName == null || cmd.CmdName.Trim().Length == 0)
            {
                runCmdReturnString = "";
                runCmdReturnType = ReturnType.ReadyForInput;
                return false;
            }

            runCmdReturnString = "";
            runCmdReturnType = ReturnType.ReadyForInput;
            return true;
        }

        /// <summary>
        /// IF cmdName is identified as a help command, process it and return true
        /// </summary>
        /// <param name="cmdName"></param>
        /// <param name="runCmdReturnString"></param>
        /// <returns></returns>
        private bool isHelpCommand(string cmdName, out ReturnType runCmdReturnType, out string runCmdReturnString)
        {
            // ----------------------------------------------------
            // DISPLAY HELP
            // ----------------------------------------------------
            if (cmdName.Equals("help", StringComparison.CurrentCultureIgnoreCase))
            {
                runCmdReturnString = Lib.TEXT_TRY_ICOMMAND_LINE1OF3 + Lib.NL + Lib.TEXT_TRY_ICOMMAND_LINE2OF3 + Lib.NL + Lib.TEXT_TRY_ICOMMAND_LINE3OF3 + Lib.NL;
                runCmdReturnType = ReturnType.InfoMsg;
                return true;
            }


            // ----------------------------------------------------
            // DISPLAY INTERNAL COMMANDS
            // ----------------------------------------------------

            // /i - display internal commands
            if (cmdName.Equals("/i", StringComparison.CurrentCultureIgnoreCase))
            {
                runCmdReturnString = "Here is a list of Internal Commands" + Lib.NL;

                for (int i = 0; i < oICommandsList.getCommandsList().Count; i++)
                    runCmdReturnString += "[" + oICommandsList.getCommandsList()[i].CmdName + "]" + Lib.NL + oICommandsList.getCommandsList()[i].CmdDesc + Lib.NL;

                runCmdReturnType = ReturnType.InfoMsg;
                return true;
            }

            runCmdReturnString = "";
            runCmdReturnType = ReturnType.ReadyForInput;
            return false;
        }



        /// <summary>
        /// Processes internal commands
        /// </summary>
        /// <param name="cmdName"></param>
        private bool processInternalCmd(ICommand cmd, out ReturnType runCmdReturnType, out string runCmdReturnString)
        {
            // Is this an actual internal command?
            runCmdReturnString = "";
            runCmdReturnType = ReturnType.ReadyForInput;
            if (!oICommandsList.getCommandsList().Contains(cmd))
                return false;


            // mngcmds
            if (cmd.CmdName.Equals("cmdmgr"))
            {
                CommandManagerWindow oCmdMngrWin = new CommandManagerWindow(oCmdWin);
                oCmdMngrWin.StartPosition = FormStartPosition.CenterParent;
                oCmdMngrWin.ShowDialog(oCmdWin);
            }

            // processes
            if (cmd.CmdName.Equals("processes"))
            {
                ProcessesWindow oProcessesWin = new ProcessesWindow();
                oProcessesWin.StartPosition = FormStartPosition.CenterParent;
                oProcessesWin.ShowDialog(oCmdWin);
            }

            // clear
            if (cmd.CmdName.Equals("clear"))
            {
                runCmdReturnString = Lib.FIRST_LINE_VALUE;
                runCmdReturnType = ReturnType.InfoMsg;
                oCmdWin.clearScreen();
            }

            // exit script
            if (cmd.CmdName.Equals("exit"))
                Application.Exit();

            return true;

        }


        /// <summary>
        /// Process external commands
        /// </summary>
        /// <param name="cmdNameSent"></param>
        /// <param name="runCmdReturnType"></param>
        /// <param name="runCmdReturnString"></param>
        /// <returns></returns>
        private bool processExternalCmd(string cmdNameSent, out ReturnType runCmdReturnType, out string runCmdReturnString)
        {
            // Validate cmdName
            if (!isCmdNameValid(new CommandObject(cmdNameSent), out runCmdReturnType, out runCmdReturnString))
                return false;

            // Get CmdName, Parms and RunCmd using cmdNameSent
            string cmdNameValue = (!cmdNameSent.Contains(" ")) ? cmdNameSent : cmdNameSent.Substring(0, cmdNameSent.IndexOf(" "));
            string cmdParmsValue = (!cmdNameSent.Contains(" ")) ? "" : cmdNameSent.Substring(cmdNameSent.IndexOf(" ") + 1);
            ECommand eCmd = new ECommand(cmdNameValue);


            // Validate ECommand
            if (!oECommandsList.getCommandsList().Contains(eCmd))
            {
                runCmdReturnString = "";
                runCmdReturnType = ReturnType.ReadyForInput;
                return false;
            }

            // Validate RunCmd
            if (eCmd.RunCmd == null || eCmd.RunCmd.Length == 0)
            {
                runCmdReturnString = Lib.TEXT_TRY_HELP_CMDNOTFOUND;
                runCmdReturnType = ReturnType.ErrorMsg;
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
                    runCmdReturnType = ReturnType.ExecMsg;
                    return true;
                }
                // Run with parms
                if (cmdParmsValue.Length > 0)
                {
                    cmdProcess = Process.Start(eCmd.RunCmd, cmdParmsValue);
                    runCmdReturnString = "Executing...";
                    runCmdReturnType = ReturnType.ExecMsg;
                    return true;
                }

                // All other cases
                runCmdReturnString = "";
                runCmdReturnType = ReturnType.ReadyForInput;
                return true;
            }
            catch (Exception e)
            {
                runCmdReturnString = Lib.TEXT_TRY_HELP_CMDFAILED;
                runCmdReturnType = ReturnType.ErrorMsg;
                return false;
            }
        }

        /// <summary>
        /// Attempt to run command as is (native command)
        /// </summary>
        /// <param name="cmdNameSent"></param>
        /// <param name="runCmdReturnType"></param>
        /// <param name="runCmdReturnString"></param>
        /// <returns></returns>
        private bool tryProcessNativeCmd(string cmdNameSent, out ReturnType runCmdReturnType, out string runCmdReturnString)
        {
            // Validate cmdName
            if (!isCmdNameValid(new CommandObject(cmdNameSent), out runCmdReturnType, out runCmdReturnString))
                return false;


            // Get CmdName, and Parms cmdNameSent
            string cmdNameValue = (!cmdNameSent.Contains(" ")) ? cmdNameSent : cmdNameSent.Substring(0, cmdNameSent.IndexOf(" "));
            string cmdParmsValue = (!cmdNameSent.Contains(" ")) ? "" : cmdNameSent.Substring(cmdNameSent.IndexOf(" ") + 1);

            try
            {
                // Attempt to run native cmd
                Process cmdProcess;

                // Run without parms
                if (cmdParmsValue.Length == 0)
                {
                    cmdProcess = Process.Start(cmdNameValue);
                    runCmdReturnString = "Executing...";
                    runCmdReturnType = ReturnType.ExecMsg;
                    return true;
                }
                // Run with parms
                if (cmdParmsValue.Length > 0)
                {
                    cmdProcess = Process.Start(cmdNameValue, cmdParmsValue);
                    runCmdReturnString = "Executing...";
                    runCmdReturnType = ReturnType.ExecMsg;
                    return true;
                }

                // All other cases
                runCmdReturnString = "";
                runCmdReturnType = ReturnType.ReadyForInput;
                return true;
            }
            catch (Exception e)
            {
                runCmdReturnString = Lib.TEXT_TRY_HELP_CMDNOTFOUND;
                runCmdReturnType = ReturnType.ErrorMsg;
                return false;
            }
        }


    }
}
