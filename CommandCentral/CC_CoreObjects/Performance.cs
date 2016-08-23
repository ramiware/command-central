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
        private PerformanceCounter cpuCounter, ramCounter;
        private Label procDisplay, cpuDisplay, ramDisplay;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="performanceDisplay"></param>
        public Performance(Label procDisplay, Label cpuDisplay, Label ramDisplay)
        {
            this.procDisplay = procDisplay;
            this.cpuDisplay = cpuDisplay;
            this.ramDisplay = ramDisplay;

            this.procDisplay.Text = "";
            this.cpuDisplay.Text = "";
            this.ramDisplay.Text = "";

            // CPU
            cpuCounter = new PerformanceCounter();
            cpuCounter.CategoryName = "Processor";
            cpuCounter.InstanceName = "_Total";
            cpuCounter.CounterName = "% Processor Time";
            
            // Memory
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

        void performanceTimer_Tick(object sender, EventArgs e)
        {
            // Processes
            procDisplay.Text = Process.GetProcesses().Count().ToString();

            // CPU
            string cpuValue = cpuCounter.NextValue().ToString("0");
            cpuDisplay.Text = cpuValue + "%";

            // Memory
            string ramValue = (ramCounter.NextValue() / 1024).ToString("0.00");
            ramDisplay.Text = ramValue + " GB";

        }

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
    }
}
