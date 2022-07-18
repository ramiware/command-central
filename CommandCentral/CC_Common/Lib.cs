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
        // Default app settings        
        public static string HDR_OS_USER = Environment.MachineName + "/" + Environment.UserName;       

        public static string DEFAULT_APP_FONT = "Calibri";
        public static int DEFAULT_TRANSPARENCY = 25;

        public static Color DEFAULT_PRIMARY_COLOR = Color.LimeGreen;
        public static Color DEFAULT_SECONDARY_COLOR = Color.White;
        public static Color DEFAULT_SCANNER_COLOR = Color.DarkGreen;
        public static Color DEFAULT_PERFORMANCE_COLOR_WARNING_LEVEL1 = Color.Yellow;
        public static Color DEFAULT_PERFORMANCE_COLOR_WARNING_LEVEL2 = Color.FromArgb(255, 50, 50);
        public static Color FAIL_COLOR = Color.FromArgb(255, 50, 50);
        
        public static int DEFAULT_CPU_THRESHOLD_WARNING_LEVEL1 = 50;
        public static int DEFAULT_CPU_THRESHOLD_WARNING_LEVEL2 = 85;
        public static double DEFAULT_RAM_THRESHOLD_WARNING_LEVEL1 = 1.5;
        public static double DEFAULT_RAM_THRESHOLD_WARNING_LEVEL2 = 1;

        // Messaging
        public static string RETURN_MSG_EXECUTING = "Executing...";
        public static string RETURN_MSG_CMDNOTFOUND = "Command not found. Try 'help'.";
        public static string RETURN_MSG_CMDFAILED = "Command failed. Try 'help'.";
        public static string RETURN_MSG_HELP_1OF3 = "Try a cmd from your Commands List on the right";
        public static string RETURN_MSG_HELP_2OF3 = "or try '/i' for a list of Internal Commands,";
        public static string RETURN_MSG_HELP_3OF3 = "or try any native Windows utility command.";

        public static string TEXT_END_PROCESS_CONFIRMATION = "If an open program is associated with this process, it will close\n" +
                                                             "and you will lose any unsaved data.  if you end a system\n" +
                                                             "process, it might result in an unstable system.  are you sure\n" +
                                                             "you want to continue?";

        // New line character
        public static string NL = "ﻥ";

 
        
    }
}
