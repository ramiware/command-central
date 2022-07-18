using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandCentral.CC_Common
{
    class About
    {
        public static string APP_PARENT_NAME = "Ramiware";

        public static string APP_NAME_LONG = "Command Central";
        public static string APP_NAME_SHORT = "CC";
        public static string APP_VERSION = "4.7";

        public static string APP_DESCRIPTION = "Command Central is a hybrid between the command prompt and the windows run command. " +
                                               "Commonly adopted by the advanced user who prefers the keyboard over the mouse, and who loves using shortcuts. " +
                                               "Create your own shortcuts with their own command names like 'fox' for launching firefox or call existing native commands like 'regedit'.";

        public static string APP_CONTACT = "\n\nFor questions, comments, suggestions or to report an issue contact support@ramiware.com or visit www.ramiware.com";

        public static string APP_ABOUT = APP_NAME_LONG + " Version " + APP_VERSION + "\n" +
                                         "Copyright © 2018 Ramiware\n" +
                                         "All rights reserved.";

        public static string APP_COPYRIGHT = "Copyright (c) 2005 - 2018 Ramiware. All rights reserved.";
    }
}
