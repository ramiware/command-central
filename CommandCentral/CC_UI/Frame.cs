using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommandCentral.CC_UI
{
    public partial class Frame : Form
    {
        private CommandCentralWindow oParent;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentWindow"></param>
        public Frame(CommandCentralWindow parentWindow)
        {
            InitializeComponent();
            oParent = parentWindow;
        }

        /// <summary>
        /// Settings when form is shown must be exactly like parents
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frame_Shown(object sender, EventArgs e)
        {
            // Title
            this.Text = oParent.Text;
            //oParent.Text = "";

            // Icon
            this.Icon = oParent.Icon;
            //oParent.Icon = null;

            // Location
            this.Location = new Point(oParent.Location.X, oParent.Location.Y);

            // Size
            this.Size = new Size(oParent.Width, oParent.Height);

            // Min Size
            this.MinimumSize = new Size(oParent.MinimumSize.Width, oParent.MinimumSize.Height);

            oParent.Focus();
        }

        // Mirror movements
        private void Frame_LocationChanged(object sender, EventArgs e)
        {
            oParent.Location = new Point(this.Location.X, this.Location.Y);
        }
        // Mirror size changes
        private void Frame_SizeChanged(object sender, EventArgs e)
        {
            oParent.Size = new Size(this.Width, this.Height);
        }
        // Close parent
        private void Frame_FormClosing(object sender, FormClosingEventArgs e)
        {
            oParent.Close();
        }
    }
}
