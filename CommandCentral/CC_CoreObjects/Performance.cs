using CommandCentral.CC_Common;
using CommandCentral.CC_UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace CommandCentral.CC_CoreObjects
{
    class Performance
    {
        private PerformanceCounter cpuCounter, ramCounter;

        private CommandCentralWindow oCmdWin;
        private Label procDisplay, cpuDisplay, ramDisplay;

        private bool cpuThresholdLevel2FlagRaised, ramThresholdLevel2FlagRaised = false;
        private int cpuThresholdWarningLevel1Value = Lib.DEFAULT_CPU_THRESHOLD_WARNING_LEVEL1;
        private int cpuThresholdWarningLevel2Value = Lib.DEFAULT_CPU_THRESHOLD_WARNING_LEVEL2;
        private double ramThresholdWarningLevel1Value = Lib.DEFAULT_RAM_THRESHOLD_WARNING_LEVEL1;
        private double ramThresholdWarningLevel2Value = Lib.DEFAULT_RAM_THRESHOLD_WARNING_LEVEL2;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="performanceDisplay"></param>
        public Performance(Label procDisplay, Label cpuDisplay, Label ramDisplay, CommandCentralWindow cmdWin)
        {
            // CmdWindow
            this.oCmdWin = cmdWin;

            // Displays
            this.procDisplay = procDisplay;
            this.cpuDisplay = cpuDisplay;
            this.ramDisplay = ramDisplay;

            this.procDisplay.Text = "";
            this.cpuDisplay.Text = "";
            this.ramDisplay.Text = "";

            // CPU counter
            cpuCounter = new PerformanceCounter();
            cpuCounter.CategoryName = "Processor";
            cpuCounter.InstanceName = "_Total";
            cpuCounter.CounterName = "% Processor Time";
            
            // Memory counter
            ramCounter = new PerformanceCounter();
            ramCounter.CategoryName = "Memory";
            ramCounter.CounterName = "Available MBytes";

            // Start Timer
            Timer performanceTimer = new Timer();
            performanceTimer.Tick += performanceTimer_Tick;
            performanceTimer.Interval = 1000;
            performanceTimer.Start();

            performanceTimer_Tick(performanceTimer.Interval, null);


            // TESTING
            //testingDisplayPerformanceCounters();

        }

        /// <summary>
        /// On every timer tick, this function will run
        /// - Refresh CPU, proc, ram
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void performanceTimer_Tick(object sender, EventArgs e)
        {
            // Processes
            procDisplay.Text = Process.GetProcesses().Count().ToString();

            // CPU
            string cpuValue = cpuCounter.NextValue().ToString("0");
            cpuDisplay.Text = cpuValue + "%";

            // Color code CPU labels
            if (int.Parse(cpuValue) > cpuThresholdWarningLevel2Value)
            {
                if (!cpuThresholdLevel2FlagRaised)
                {
                    this.cpuDisplay.ForeColor = Lib.DEFAULT_PERFORMANCE_COLOR_WARNING_LEVEL2;
                    this.oCmdWin.createNewRow(CommandProcessor.RowType.InfoProvided, System.DateTime.Now.ToString() + Lib.NL + "Warning: CPU usage over " + cpuThresholdWarningLevel2Value + "%" + Lib.NL);
                    cpuThresholdLevel2FlagRaised = true;
                }
            }
            else if (int.Parse(cpuValue) > cpuThresholdWarningLevel1Value)
            {
                this.cpuDisplay.ForeColor = Lib.DEFAULT_PERFORMANCE_COLOR_WARNING_LEVEL1;
                cpuThresholdLevel2FlagRaised = false;
            }
            else
            {
                this.cpuDisplay.ForeColor = Lib.DEFAULT_PRIMARY_COLOR;
                cpuThresholdLevel2FlagRaised = false;
            }

            // RAM/Memory
            string ramValue = (ramCounter.NextValue() / 1024).ToString("0.00");
            ramDisplay.Text = ramValue + " GB";

            // RAM Threshold handling
            if (double.Parse(ramValue) < ramThresholdWarningLevel2Value)
            {
                if (!ramThresholdLevel2FlagRaised)
                {
                    this.ramDisplay.ForeColor = Lib.DEFAULT_PERFORMANCE_COLOR_WARNING_LEVEL2;
                    this.oCmdWin.createNewRow(CommandProcessor.RowType.InfoProvided, System.DateTime.Now.ToString() + Lib.NL + "Warning: Available RAM less than " + ramThresholdWarningLevel2Value + "GB" + Lib.NL);
                    ramThresholdLevel2FlagRaised = true;
                }
            }
            else if (double.Parse(ramValue) < ramThresholdWarningLevel1Value)
            {
                this.ramDisplay.ForeColor = Lib.DEFAULT_PERFORMANCE_COLOR_WARNING_LEVEL1;
                ramThresholdLevel2FlagRaised = false;
            }
            else
            {
                this.ramDisplay.ForeColor = Lib.DEFAULT_PRIMARY_COLOR;
                ramThresholdLevel2FlagRaised = false;
            }

        }

        /// <summary>
        /// Sets this class's threshold values
        /// </summary>
        /// <param name="cpuThresholdLevel1Value"></param>
        /// <param name="cpuThresholdLevel2Value"></param>
        /// <param name="ramThresholdLevel1Value"></param>
        /// <param name="ramThresholdLevel2Value"></param>
        public void setThresholdLevels(int cpuThresholdLevel1Value, int cpuThresholdLevel2Value, double ramThresholdLevel1Value, double ramThresholdLevel2Value)
        {
            this.cpuThresholdWarningLevel1Value = cpuThresholdLevel1Value;
            this.cpuThresholdWarningLevel2Value = cpuThresholdLevel2Value;

            this.ramThresholdWarningLevel1Value = ramThresholdLevel1Value;
            this.ramThresholdWarningLevel2Value = ramThresholdLevel2Value;
        }


        #region TESTING
        // For Testing Only
        private void testingDisplayPerformanceCounters()
        {
            PerformanceCounterCategory[] cats = PerformanceCounterCategory.GetCategories();
            string[] instances;
            PerformanceCounter[] counts;
            foreach (PerformanceCounterCategory cat in cats)
            {
                //Console.WriteLine(cat.CategoryName + " --> " + cat.CategoryHelp + "\n");
                if (cat.CategoryName.Equals("Processor"))
                {
                    instances = cat.GetInstanceNames();
                    if (instances.Length > 0)
                    {
                        foreach (string instance in instances)
                        {
                            counts = cat.GetCounters(instance);
                            foreach (PerformanceCounter count in counts)
                                Console.WriteLine("CategoryName: " + cat.CategoryName + "\nInstanceName: " + instance + "\nCounterName: " + count.CounterName + "\n\n");
                        }
                    }
                    else
                    {
                        counts = cat.GetCounters();
                        foreach (PerformanceCounter count in counts)
                            Console.WriteLine("CategoryName: " + cat.CategoryName + "\nCounterName: " + count.CounterName + "\n\n");
                    }
                }
            }
        }
        #endregion
    }
}
