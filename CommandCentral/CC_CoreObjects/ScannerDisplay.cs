using CommandCentral.CC_UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CommandCentral.CC_CoreObjects
{
    class ScannerDisplay
    {
        private const int SCANNER_STRIDE = 2;
        private const int SCANNER_DELAY = 2;

        private Scanner scannerGlow;
        private Boolean moveForwardFlag = true;

        private ToolTip scannerToolTip = new ToolTip();
        private string toolTipText = "Ready...";

        /// <summary>
        /// Initiate scannerDisplay label and start timer
        /// </summary>
        /// <param name="scannerDisplay"></param>
        public ScannerDisplay(Scanner scannerDisplay)
        {
            // Setup Scanner default appearance
            this.scannerGlow = scannerDisplay;
            this.scannerGlow.Location = new Point(0, this.scannerGlow.Location.Y);
            this.scannerToolTip.UseAnimation = true;
            this.scannerToolTip.UseFading = true;
            this.scannerToolTip.SetToolTip(this.scannerGlow, toolTipText);
            this.scannerGlow.Refresh();

            // Start Timer
            Timer scannerTimer = new Timer();
            scannerTimer.Tick += scannerTimer_Tick;
            scannerTimer.Interval = SCANNER_DELAY;
            scannerTimer.Start();

            scannerTimer_Tick(scannerTimer.Interval, null);
        }


        /// <summary>
        /// Every tick, this will happen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void scannerTimer_Tick(object sender, EventArgs e)
        {

            scannerGlow.Refresh();

            int scannerRightMostEdge = scannerGlow.Location.X + scannerGlow.Width;
            int scannerLeftMostEdge = scannerGlow.Location.X;

            // <<-- Controls when to turn left
            if (scannerRightMostEdge >= scannerGlow.Parent.Width || !moveForwardFlag)
            {
                scannerGlow.Location = new Point(scannerGlow.Location.X - SCANNER_STRIDE, scannerGlow.Location.Y);
                moveForwardFlag = false;
            }

            // -->> Controls when to turn right
            if (scannerLeftMostEdge <= 0 || moveForwardFlag)
            {
                scannerGlow.Location = new Point(scannerGlow.Location.X + SCANNER_STRIDE, scannerGlow.Location.Y);
                moveForwardFlag = true;
            }

            scannerGlow.Refresh();

            scannerRightMostEdge = scannerGlow.Location.X + scannerGlow.Width;
            scannerLeftMostEdge = scannerGlow.Location.X;

            // Check if scannerLeftMostEdge has reached lower limit so that the moveForwardFlag can be turned on prior to next tick.
            // Otherwise, scanner will move left and right on next ticket (only 1 move per tick allowed)
            if (scannerLeftMostEdge <= 0)
                moveForwardFlag = true;
            
        }
    }
}
