using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandCentral.CC_Common
{
    class Lib
    {
        public static string FIRST_LINE_VALUE = Environment.MachineName + "/" + Environment.UserName;

        public static string TEXT_TRY_HELP_CMDNOTFOUND = "Command not found. Try 'help'.";
        public static string TEXT_TRY_HELP_CMDFAILED = "Command failed. Try 'help'.";

        public static string TEXT_TRY_ICOMMAND_LINE1OF3 = "Try a cmd from your Commands List on the right";
        public static string TEXT_TRY_ICOMMAND_LINE2OF3 = "or try '/i' for a list of Internal Commands.";
        public static string TEXT_TRY_ICOMMAND_LINE3OF3 = "or try any native Windows utility command.";

        public static string TEXT_END_PROCESS_CONFIRMATION = "If an open program is associated with this process, it will close\n" +
                                                             "and you will lose any unsaved data.  If you end a system\n" +
                                                             "process, it might result in an unstable system.  Are you sure\n" +
                                                             "you want to continue?";

        public static string NL = "ﻥ";

        public static string APP_FONT = "Consolas";

    }
}
