using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandCentral.CC_UI
{
    struct CommandGridAttributes
    {
        /// GRID COLUMNS
        public struct Columns
        {
            public const String COL_MARGIN = "Margin";
            public const String COL_COMMAND = "Command";
        }

        public static int ROW_HEIGHT = 15;

        public static string MARGIN_CHAR_DEFAULT = ">";
        //public static string MARGIN_CHAR_DEFAULT = "›";
        public static string MARGIN_CHAR_MESSAGE = "";

    }
}
