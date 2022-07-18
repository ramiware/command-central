using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CommandCentral.CC_UI
{
    class Scanner : Panel
    {

        /// <summary>
        /// Panel was inherited in order to create a new type of panel with the following ControlStyles properties to remove image flickering.
        /// </summary>
        public Scanner()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
        }
    }
}
