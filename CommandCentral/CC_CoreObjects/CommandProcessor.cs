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


        // Command Process Return Codes
        public enum RunCmdReturnCode
        {
            Error,
            InfoProvided,
            Executed,
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
        public bool executeCmd(CommandObject cmd, out RunCmdReturnCode runCmdReturnCode, out string runCmdReturnMessage)
        {
            try
            {
                // Validate
                if (!isCmdNameValid(cmd, out runCmdReturnCode, out runCmdReturnMessage))
                    return true;

                // Get clean cmdName
                string cmdNameValue = cmd.CmdName.Trim();

                // Is this a Help command request?
                if (isHelpCommand(cmdNameValue, out runCmdReturnCode, out runCmdReturnMessage))
                    return true;


                // Is this an Internal Command request?
                if (oICommandsList.getCommandsList().Contains(new ICommand(cmdNameValue)))
                    return processInternalCmd(new ICommand(cmdNameValue), out runCmdReturnCode, out runCmdReturnMessage);


                // Is this an External command request?
                // If processExternalCmd returns false, try to process as a native windows command.
                if (!processExternalCmd(cmdNameValue, out runCmdReturnCode, out runCmdReturnMessage))
                    return tryProcessNativeCmd(cmdNameValue, out runCmdReturnCode, out runCmdReturnMessage);
                else 
                    return true;

            }
            catch (Exception e)
            {
                runCmdReturnMessage = Lib.RETURN_MSG_CMDFAILED;
                runCmdReturnCode = RunCmdReturnCode.Error;
                return false;
            }
        }

        /// <summary>
        /// Validates the cmd object and the cmdName attribute
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="runCmdReturnCode"></param>
        /// <param name="runCmdReturnMessage"></param>
        /// <returns></returns>
        private bool isCmdNameValid(CommandObject cmd, out RunCmdReturnCode runCmdReturnCode, out string runCmdReturnMessage)
        {
            if (cmd == null || cmd.CmdName == null || cmd.CmdName.Trim().Length == 0)
            {
                runCmdReturnMessage = "";
                runCmdReturnCode = RunCmdReturnCode.ReadyForInput;
                return false;
            }

            runCmdReturnMessage = "";
            runCmdReturnCode = RunCmdReturnCode.ReadyForInput;
            return true;
        }

        /// <summary>
        /// IF cmdName is identified as a help command, process it and return true
        /// </summary>
        /// <param name="cmdName"></param>
        /// <param name="runCmdReturnMessage"></param>
        /// <returns></returns>
        private bool isHelpCommand(string cmdName, out RunCmdReturnCode runCmdReturnCode, out string runCmdReturnMessage)
        {
            // ----------------------------------------------------
            // DISPLAY HELP
            // ----------------------------------------------------
            if (cmdName.Equals("help", StringComparison.CurrentCultureIgnoreCase))
            {
                runCmdReturnMessage = Lib.RETURN_MSG_HELP_1OF3 + Lib.NL + Lib.RETURN_MSG_HELP_2OF3 + Lib.NL + Lib.RETURN_MSG_HELP_3OF3 + Lib.NL;
                runCmdReturnCode = RunCmdReturnCode.InfoProvided;
                return true;
            }


            // ----------------------------------------------------
            // DISPLAY INTERNAL COMMANDS
            // ----------------------------------------------------

            // /i - display internal commands
            if (cmdName.Equals("/i", StringComparison.CurrentCultureIgnoreCase))
            {
                runCmdReturnMessage = "Here is a list of Internal Commands:" + Lib.NL;

                for (int i = 0; i < oICommandsList.getCommandsList().Count; i++)
                    runCmdReturnMessage += "[" + oICommandsList.getCommandsList()[i].CmdName + "]" + Lib.NL + "     " + oICommandsList.getCommandsList()[i].CmdDesc + Lib.NL;

                runCmdReturnCode = RunCmdReturnCode.InfoProvided;
                return true;
            }

            runCmdReturnMessage = "";
            runCmdReturnCode = RunCmdReturnCode.ReadyForInput;
            return false;
        }



        /// <summary>
        /// Processes internal commands
        /// </summary>
        /// <param name="cmdName"></param>
        private bool processInternalCmd(ICommand cmd, out RunCmdReturnCode runCmdReturnCode, out string runCmdReturnMessage)
        {
            // Is this an actual internal command?
            runCmdReturnMessage = "";
            runCmdReturnCode = RunCmdReturnCode.ReadyForInput;
            if (!oICommandsList.getCommandsList().Contains(cmd))
                return false;


            // cmdmgr: Command manager window
            if (cmd.CmdName.Equals("cmdmgr"))
            {
                CommandManagerWindow oCmdMngrWin = new CommandManagerWindow(oCmdWin);
                oCmdMngrWin.StartPosition = FormStartPosition.CenterParent;
                oCmdMngrWin.ShowDialog(oCmdWin);
            }

            // cust: Customize Appearance window
            if (cmd.CmdName.Equals("cust"))
            {
                CustomizeAppearanceWindow oCustAppWin = new CustomizeAppearanceWindow(oCmdWin);
                oCustAppWin.StartPosition = FormStartPosition.CenterParent;
                oCustAppWin.ShowDialog(oCmdWin);
            }

            // processes
            if (cmd.CmdName.Equals("pid"))
            {
                String returnMessageAsString;
                RunCmdReturnCode returnCode;
                tryProcessNativeCmd("taskmgr.exe", out returnCode, out returnMessageAsString);
            }

            // clear
            if (cmd.CmdName.Equals("clear"))
            {
                runCmdReturnMessage = "";
                runCmdReturnCode = RunCmdReturnCode.ReadyForInput;
                oCmdWin.clearScreen();
            }

            // exit script
            if (cmd.CmdName.Equals("exit"))
                Application.ExitThread();
                 //Application.Exit();


            return true;

        }


        /// <summary>
        /// Process external custom commands
        /// </summary>
        /// <param name="runCmdRequested"></param>
        /// <param name="runCmdReturnCode"></param>
        /// <param name="runCmdReturnMessage"></param>
        /// <returns></returns>
        private bool processExternalCmd(string runCmdRequested, out RunCmdReturnCode runCmdReturnCode, out string runCmdReturnMessage)
        {
            // Validate cmdName
            if (!isCmdNameValid(new CommandObject(runCmdRequested), out runCmdReturnCode, out runCmdReturnMessage))
                return false;

            // Get CmdName, Parms and RunCmd using cmdNameSent
            string cmdNameValue = (!runCmdRequested.Contains(" ")) ? runCmdRequested : runCmdRequested.Substring(0, runCmdRequested.IndexOf(" "));
            string cmdParmsValue = (!runCmdRequested.Contains(" ")) ? "" : runCmdRequested.Substring(runCmdRequested.IndexOf(" ") + 1);
            ECommand eCmd = new ECommand(cmdNameValue);


            // Validate ECommand
            if (!oECommandsList.getCommandsList().Contains(eCmd))
            {
                runCmdReturnMessage = "";
                runCmdReturnCode = RunCmdReturnCode.ReadyForInput;
                return false;
            }

            // Validate RunCmd
            if (eCmd.RunCmd == null || eCmd.RunCmd.Length == 0)
            {
                runCmdReturnMessage = Lib.RETURN_MSG_CMDNOTFOUND;
                runCmdReturnCode = RunCmdReturnCode.Error;
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
                    runCmdReturnMessage = Lib.RETURN_MSG_EXECUTING;
                    runCmdReturnCode = RunCmdReturnCode.Executed;
                    return true;
                }
                // Run with parms
                if (cmdParmsValue.Length > 0)
                {
                    cmdProcess = Process.Start(eCmd.RunCmd, cmdParmsValue);
                    runCmdReturnMessage = "Executing...";
                    runCmdReturnCode = RunCmdReturnCode.Executed;
                    return true;
                }

                // All other cases
                runCmdReturnMessage = "";
                runCmdReturnCode = RunCmdReturnCode.ReadyForInput;
                return true;
            }
            catch (Exception e)
            {
                runCmdReturnMessage = Lib.RETURN_MSG_CMDFAILED;
                runCmdReturnCode = RunCmdReturnCode.Error;
                return false;
            }
        }

        /// <summary>
        /// Attempt to run command as is (native command)
        /// </summary>
        /// <param name="cmdNameSent"></param>
        /// <param name="runCmdReturnCode"></param>
        /// <param name="runCmdReturnMessage"></param>
        /// <returns></returns>
        private bool tryProcessNativeCmd(string cmdNameSent, out RunCmdReturnCode runCmdReturnCode, out string runCmdReturnMessage)
        {
            // Validate cmdName
            if (!isCmdNameValid(new CommandObject(cmdNameSent), out runCmdReturnCode, out runCmdReturnMessage))
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
                    runCmdReturnMessage = "Executing...";
                    runCmdReturnCode = RunCmdReturnCode.Executed;
                    return true;
                }
                // Run with parms
                if (cmdParmsValue.Length > 0)
                {
                    cmdProcess = Process.Start(cmdNameValue, cmdParmsValue);
                    runCmdReturnMessage = "Executing...";
                    runCmdReturnCode = RunCmdReturnCode.Executed;
                    return true;
                }

                // All other cases
                runCmdReturnMessage = "";
                runCmdReturnCode = RunCmdReturnCode.ReadyForInput;
                return true;
            }
            catch (Exception e)
            {
                runCmdReturnMessage = Lib.RETURN_MSG_CMDNOTFOUND;
                runCmdReturnCode = RunCmdReturnCode.Error;
                return false;
            }
        }


    }
}
