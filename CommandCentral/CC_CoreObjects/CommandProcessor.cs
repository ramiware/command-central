using CommandCentral.CC_Common;
using CommandCentral.CC_Data;
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
    public class CommandProcessor
    {
        private CommandCentralWindow oCmdWin;

        private InternalCmdsList oInternalCmdsList = new InternalCmdsList();
        private CustomCmdsList oCustomCmdsList = new CustomCmdsList();


        // Row Types
        public enum RowType
        {
            Error,
            InfoProvided,
            Executing,
            ReadyForInput
        }

        // Command Types
        public enum CmdType
        {
            Empty,
            Help,
            internalListRequest,
            Custom,
            Internal,
            Unknown
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
        /// Tries to execute the command string passed
        /// </summary>
        /// <param name="cmdName"></param>
        /// <returns></returns>
        public bool executeCmd(string cmdName)
        {

            // Get Command Type
            CommandProcessor.CmdType cmdType = getCmdType(new CommandObject(cmdName));
            // Is this a Help command request?
            if (cmdType.Equals(CommandProcessor.CmdType.Help))
            {
                oCmdWin.createNewRow(CommandProcessor.RowType.InfoProvided, getHelpCmdMessage());
                return true;
            }

            // Is this an Internal List request?
            if (cmdType.Equals(CommandProcessor.CmdType.internalListRequest))
            {
                oCmdWin.createNewRow(CommandProcessor.RowType.InfoProvided, getInternalListMessage());
                return true;
            }

            // Is this an Internal Command request?
            if (cmdType.Equals(CommandProcessor.CmdType.Internal))
            {
                oCmdWin.createNewRow(CommandProcessor.RowType.ReadyForInput);
                return processInternalCmd(new InternalCmd(cmdName));
            }

            // Is this an Custom command request?
            if (cmdType.Equals(CommandProcessor.CmdType.Custom))
            {
                oCmdWin.createNewRow(CommandProcessor.RowType.Executing, Lib.RETURN_MSG_EXECUTING);
                bool result = processCustomCmd(new CommandObject(cmdName));
                if (!result)
                    oCmdWin.createNewRow(CommandProcessor.RowType.Error, Lib.RETURN_MSG_CMDFAILED, false);
                return result;
            }

            // CommandType unknown
            if (cmdType.Equals(CommandProcessor.CmdType.Unknown))
            {
                oCmdWin.createNewRow(CommandProcessor.RowType.Executing, Lib.RETURN_MSG_EXECUTING);
                bool result = tryProcessNativeCmd(cmdName);
                if (!result)
                    oCmdWin.createNewRow(CommandProcessor.RowType.Error, Lib.RETURN_MSG_CMDFAILED, false);
                return result;
            }

            return false;
        }

        /// <summary>
        /// Updates the CommandsList
        /// </summary>
        /// <param name="cmdList"></param>
        public void updateCommandsList(CustomCmdsList cmdList)
        {
            oCustomCmdsList = cmdList;
        }

        /// <summary>
        /// Returns the cmd type
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="runCmdReturnCode"></param>
        /// <param name="runCmdReturnMessage"></param>
        /// <returns></returns>
        private CmdType getCmdType(CommandObject cmd)
        {
            // Validate
            if (!isCmdNameValid(cmd.CmdName))
                return CmdType.Empty;

            // Is this a Help command request?
            if (isHelpCommand(cmd.CmdName))
                return CmdType.Help;

            // Is this an Internal List request?
            if (isInternalListRequest(cmd.CmdName))
                return CmdType.internalListRequest;

            // Is this an Internal Command request?
            if (oInternalCmdsList.getCommandsList().Contains(new InternalCmd(cmd.CmdName)))
                return CmdType.Internal;

            // Is this a Custom command request? (Check for arguments to get CmdName, and Parms)
            string cmdNameValue = (!cmd.CmdName.Contains(" ")) ? cmd.CmdName : cmd.CmdName.Substring(0, cmd.CmdName.IndexOf(" "));
            string cmdParmsValue = (!cmd.CmdName.Contains(" ")) ? "" : cmd.CmdName.Substring(cmd.CmdName.IndexOf(" ") + 1);

            if (oCustomCmdsList.getCommandsList().Contains(new CustomCmd(cmdNameValue)))
                return CmdType.Custom;

            return CmdType.Unknown;
        }

        /// <summary>
        /// Validates the cmdName
        /// </summary>
        /// <param name="cmdName"></param>
        /// <returns></returns>
        private bool isCmdNameValid(string cmdName)
        {
            if (cmdName == null || cmdName.Trim().Length == 0)
                return false;


            return true;
        }

        /// <summary>
        /// is this a help command?
        /// </summary>
        /// <param name="cmdName"></param>
        /// <returns></returns>
        private bool isHelpCommand(string cmdName)
        {
            if (cmdName.Equals("help", StringComparison.CurrentCultureIgnoreCase))
                return true;

            return false;
        }

        /// <summary>
        /// is this an internal list request?
        /// </summary>
        /// <param name="cmdName"></param>
        /// <returns></returns>
        private bool isInternalListRequest(string cmdName)
        {
            if (cmdName.Equals("/i", StringComparison.CurrentCultureIgnoreCase))
                return true;

            return false;
        }

        /// <summary>
        /// Returns help cmd message
        /// </summary>
        /// <param name="runCmdReturnCode"></param>
        /// <param name="runCmdReturnMessage"></param>
        private string getHelpCmdMessage()
        {
            return Lib.RETURN_MSG_HELP_1OF3 + Lib.NL + Lib.RETURN_MSG_HELP_2OF3 + Lib.NL + Lib.RETURN_MSG_HELP_3OF3 + Lib.NL;
        }

        /// <summary>
        /// Display internal commands
        /// </summary>
        /// <returns></returns>
        private string getInternalListMessage()
        {
            string message = "Here is a list of Internal Commands:" + Lib.NL;

            for (int i = 0; i < oInternalCmdsList.getCommandsList().Count; i++)
                message += "[" + oInternalCmdsList.getCommandsList()[i].CmdName + "]" + Lib.NL + oInternalCmdsList.getCommandsList()[i].CmdDesc + Lib.NL;

            return message;
        }

        /// <summary>
        /// Processes an internal cmd
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        private bool processInternalCmd(InternalCmd cmd)
        {
            // Validate
            if (!oInternalCmdsList.getCommandsList().Contains(cmd))
                return false;


            // cmdmgr: Command manager window
            if (cmd.CmdName.Equals("cmdmgr"))
            {
                CommandManagerWindow oCmdMngrWin = new CommandManagerWindow(oCmdWin);
                oCmdMngrWin.StartPosition = FormStartPosition.CenterParent;
                oCmdMngrWin.ShowDialog(oCmdWin);
            }

            // settings: command central settings window
            if (cmd.CmdName.Equals("settings"))
            {
                CommandCentralSettingsWindow oCustAppWin = new CommandCentralSettingsWindow(oCmdWin);
                oCustAppWin.StartPosition = FormStartPosition.CenterParent;
                oCustAppWin.ShowDialog(oCmdWin);
            }

            // note: creates a note taking window
            if (cmd.CmdName.Equals("note"))
            {
                NoteWindow oNoteWin = new NoteWindow();
                oNoteWin.StartPosition = FormStartPosition.CenterScreen;
                oNoteWin.Show();
            }

            // note: opens all saved notes
            if (cmd.CmdName.Equals("onotes"))
            {
                // Open all note files
                NoteLib noteLibrary = new NoteLib();
                noteLibrary.openAllNotes();
            }

            // clear
            if (cmd.CmdName.Equals("clear"))
            {
                oCmdWin.clearScreen();
                oCmdWin.createNewRow(RowType.ReadyForInput);
            }

            // exit script
            if (cmd.CmdName.Equals("exit"))
                Application.ExitThread();


            return true;
        }

        /// <summary>
        /// Processes a custom cmd
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        private bool processCustomCmd(CommandObject cmd)
        {
            //Check for arguments to get CmdName, and Parms
            string cmdNameValue = (!cmd.CmdName.Contains(" ")) ? cmd.CmdName : cmd.CmdName.Substring(0, cmd.CmdName.IndexOf(" "));
            string cmdParmsValue = (!cmd.CmdName.Contains(" ")) ? "" : cmd.CmdName.Substring(cmd.CmdName.IndexOf(" ") + 1);
            CustomCmd customCmd = new CustomCmd(cmdNameValue);

            // Validate
            if (!oCustomCmdsList.getCommandsList().Contains(customCmd))
                return false;

            // Validate RunCmd
            if (customCmd.RunCmd == null || customCmd.RunCmd.Length == 0)
                return false;

            try
            {
                // Attempt to run custom cmd
                Process cmdProcess;

                // Run without parms
                if (cmdParmsValue.Length == 0)
                {
                    cmdProcess = Process.Start(customCmd.RunCmd);
                    return true;
                }
                // Run with parms
                if (cmdParmsValue.Length > 0)
                {
                    cmdProcess = Process.Start(customCmd.RunCmd, cmdParmsValue);
                    return true;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Try to process as a native windows command.
        /// </summary>
        /// <param name="cmdString"></param>
        /// <returns></returns>
        private bool tryProcessNativeCmd(string cmdString)
        {
             // Get CmdName, and Parms cmdNameSent
            string cmdNameValue = (!cmdString.Contains(" ")) ? cmdString : cmdString.Substring(0, cmdString.IndexOf(" "));
            string cmdParmsValue = (!cmdString.Contains(" ")) ? "" : cmdString.Substring(cmdString.IndexOf(" ") + 1);

            try
            {
                // Attempt to run native cmd
                Process cmdProcess;

                // Run without parms
                if (cmdParmsValue.Length == 0)
                {
                    cmdProcess = Process.Start(cmdNameValue);
                    return true;
                }
                // Run with parms
                if (cmdParmsValue.Length > 0)
                {
                    cmdProcess = Process.Start(cmdNameValue, cmdParmsValue);
                    return true;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
