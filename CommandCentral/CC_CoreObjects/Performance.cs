using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace CommandCentral.CC_CoreObjects
{
    class Performance
    {
        private PerformanceCounter cpuCounter;
        private PerformanceCounter ramCounter;

        private Label cpuDisplay, ramDisplay;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="performanceDisplay"></param>
        public Performance(Label cpuDisplay, Label ramDisplay)
        {
            this.cpuDisplay = cpuDisplay;
            this.ramDisplay = ramDisplay;

            this.cpuDisplay.Text = "";
            this.ramDisplay.Text = "";

            cpuCounter = new PerformanceCounter();
            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";

            //ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            ramCounter = new PerformanceCounter("Memory", "Committed Bytes");

            // Start Timer
            Timer performanceTimer = new Timer();
            performanceTimer.Tick += performanceTimer_Tick;
            performanceTimer.Interval = 1000;
            performanceTimer.Start();

        }

        void performanceTimer_Tick(object sender, EventArgs e)
        {
            string cpuValue = cpuCounter.NextValue().ToString("0");
            string ramValue = (ramCounter.NextValue() / 1073741824).ToString("0.00");
            cpuDisplay.Text = cpuValue + "%";
            ramDisplay.Text = ramValue + " GB";
        }
    }
}
