using CommandCentral.CC_Common;
using CommandCentral.CC_CoreObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommandCentral.CC_UI
{
    public partial class ProcessesWindow : Form
    {
        private ContextMenuStrip gridContextMenu = new ContextMenuStrip();
        private int currentMouseClickRow = -1;

        /// <summary>
        /// Constructor
        /// </summary>
        public ProcessesWindow()
        {
            InitializeComponent();

            // Grid
            CreateGrid();
            RefreshGrid();
            // Sort grid by Memory column
            this.processesDataGrid.Sort(this.processesDataGrid.Columns["Memory"], ListSortDirection.Descending);

            // Start Timer
            Timer performanceTimer = new Timer();
            performanceTimer.Tick += performanceTimer_Tick;
            performanceTimer.Interval = 1500;
            performanceTimer.Start();

            performanceTimer_Tick(performanceTimer.Interval, null);

            // Handlers
            this.processesDataGrid.MouseClick += processesDataGrid_MouseClick;

            // Performance Display
            Performance performanceObject = new Performance(this.footerLabelProcessesValue, this.footerLabelCPUValue, this.footerLabelRAMValue);
        }


        private void performanceTimer_Tick(object sender, EventArgs e)
        {
            RefreshGrid();
        }


        /// <summary>
        /// 
        /// </summary>
        private void CreateGrid()
        {
            this.processesDataGrid.AllowUserToAddRows = false;
            this.processesDataGrid.AllowUserToResizeRows = false;

            this.processesDataGrid.Columns.Add("ProcessID", "ProcessID");
            this.processesDataGrid.Columns["ProcessID"].Visible = false;

            this.processesDataGrid.Columns.Add("ProcessName", "Process Name");

            this.processesDataGrid.Columns.Add("Responding", "Responding");
            this.processesDataGrid.Columns["Responding"].Width = 100;
            this.processesDataGrid.Columns["Responding"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.processesDataGrid.Columns.Add("CPU", "CPU");
            this.processesDataGrid.Columns["CPU"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.processesDataGrid.Columns["CPU"].DefaultCellStyle.Format = "00";
            this.processesDataGrid.Columns["CPU"].Width = 80;
            this.processesDataGrid.Columns["CPU"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.processesDataGrid.Columns["CPU"].Visible = false;

            this.processesDataGrid.Columns.Add("Memory", "Memory (K)");
            this.processesDataGrid.Columns["Memory"].DefaultCellStyle.Format = "N0";
        }



        PerformanceCounter pcWorkingSet, pcProcessorTime;
        int processID = 0;
        string processName = "";
        float processCPU = 0;
        string processResponding = "Y";
        long processMemory = 0;

        bool processFoundInGrid = false;
        bool processFoundRunning = false;
        int currRowProcessID = 0;
        string currRowProcName = "";

        Process[] procList;// = Process.GetProcesses();

        /// <summary>
        /// Refresh processes grid
        /// </summary>
        private void RefreshGrid()
        {
            // Get all processes currently running
            procList = Process.GetProcesses();

            // Loop through list of currently running processes
            foreach (Process p in procList)
            {
                // Get process id
                processID = p.Id;

                // Get process name
                processName = p.ProcessName;

                // Get process responding status
                processResponding = (p.Responding) ? "Y" : "N";

                try
                {
                    // Get memory
                    pcWorkingSet = new PerformanceCounter("Process", "Working Set - Private", p.ProcessName, true);
                    processMemory = pcWorkingSet.RawValue / 1024;

                    // Get CPU
                    pcProcessorTime = new PerformanceCounter("Process", "% Processor Time", p.ProcessName, true);
                    processCPU = pcProcessorTime.NextValue();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.ToString());
                    continue;
                }

                //TODO: Confirm CPU values are good.
                //TODO: check for a process which disappears while looping

                // ADD / UPDATE row from processDataGrid based on ProcessID comparison
                foreach (DataGridViewRow row in this.processesDataGrid.Rows)
                {
                    currRowProcessID = (row.Cells["ProcessID"].Value == null) ? -1 : int.Parse(row.Cells["ProcessID"].Value.ToString());
                    currRowProcName = (row.Cells["ProcessName"].Value == null) ? "" : row.Cells["ProcessName"].Value.ToString();
                    processFoundInGrid = false;

                    // IF ProcessID DOES exist in processDataGrid
                    // UPDATE
                    if (processID.Equals(currRowProcessID))
                    {
                        processFoundInGrid = true;

                        row.Cells["Responding"].Value = processResponding;
                        row.Cells["CPU"].Value = processCPU;
                        row.Cells["Memory"].Value = processMemory;

                        ListSortDirection sortDirection = (this.processesDataGrid.SortOrder.ToString() == "Ascending") ? ListSortDirection.Ascending : ListSortDirection.Descending;
                        this.processesDataGrid.Sort(this.processesDataGrid.Columns[this.processesDataGrid.SortedColumn.Name], sortDirection);

                        break;
                    }
                }
                // IF ProcessID does NOT exist processDataGrid
                // ADD
                if (!processFoundInGrid)
                    this.processesDataGrid.Rows.Add(processID, processName, processResponding, processCPU, processMemory);
            }

            // Loop through processDataGrid
            // Objective is to remove any processes from the grid that are no longer running.
            foreach (DataGridViewRow row in this.processesDataGrid.Rows)
            {
                currRowProcessID = (row.Cells["ProcessID"].Value == null) ? -1 : int.Parse(row.Cells["ProcessID"].Value.ToString());
                currRowProcName = (row.Cells["ProcessName"].Value == null) ? "" : row.Cells["ProcessName"].Value.ToString();
                processFoundRunning = false;

                // Loop through currently running process
                foreach (Process p in procList)
                {
                    // IF currRowProcessID in processDataGrid AND found in currently running processes
                    if (currRowProcessID == -1 || currRowProcessID.Equals(p.Id))
                    {
                        processFoundRunning = true;
                        break;
                    }
                }

                // IF currRowProcessID in processDataGrid but NOT in currently running processes
                // DELETE ROW
                if (!processFoundRunning)
                    this.processesDataGrid.Rows.Remove(row);
            }
        }


        /// <summary>
        /// Right click selects row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void processesDataGrid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Add this
                this.processesDataGrid.CurrentCell = this.processesDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                // Can leave these here - doesn't hurt
                this.processesDataGrid.Rows[e.RowIndex].Selected = true;
                this.processesDataGrid.Focus();
            }
        }

        /// <summary>
        /// Context Menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void processesDataGrid_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                m.MenuItems.Add(new MenuItem("End Process", miEndProcess_Click));

                currentMouseClickRow = this.processesDataGrid.HitTest(e.X, e.Y).RowIndex;

                if (currentMouseClickRow >= 0)
                    m.Show(this.processesDataGrid, new Point(e.X, e.Y));
            }
        }

        /// <summary>
        /// End Process Menu Item Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miEndProcess_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to end '" + this.processesDataGrid.Rows[currentMouseClickRow].Cells["ProcessName"].Value.ToString() + "'?\n\n" + Lib.TEXT_END_PROCESS_CONFIRMATION, "Process Manager", MessageBoxButtons.YesNo);
            if (result.Equals(DialogResult.Yes))
                killProcess(this.processesDataGrid.Rows[currentMouseClickRow].Cells["ProcessID"].Value.ToString());
        }

        /// <summary>
        /// Ends a process using processID argument
        /// </summary>
        /// <param name="processID"></param>
        private void killProcess(string processID)
        {
            try
            {
                int id;
                if (!int.TryParse(processID, out id))
                    return;

                Process p = Process.GetProcessById(id);
                p.Kill();

                System.Threading.Thread.Sleep(500);
                RefreshGrid();
            }
            catch (Exception e)
            {
                MessageBox.Show("An error occurred while trying to end process with process ID: " + processID + "\n\n" + e.Message, "End Process", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }



    }
}
