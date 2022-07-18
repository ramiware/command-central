using CommandCentral.CC_Common;
using CommandCentral.CC_CoreObjects;
using CommandCentral.CC_Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CommandCentral.CC_UI
{
    public partial class CommandCentralWindow : Form
    {
        private CommandProcessor cmdProc;
        private CommandBuffer cmdBuffer;
        private Performance performanceObject;
        private ScannerDisplay scannerDisplayObject;
        private Scanner scanner;

        private Frame cFrame;
        /// <summary>
        /// 
        /// </summary>
        public CommandCentralWindow()
        {
            // Initailize UI
            Application.EnableVisualStyles();
            InitializeComponent();
            InitializeUI();
           
            // Refresh CommandsList
            refreshInterfaceCommandsList();

            // CommandProcessor
            cmdProc = new CommandProcessor(this);

            // Command Buffer
            cmdBuffer = new CommandBuffer();

            // Context Menu
            cmdEntryDataGrid.ContextMenuStrip = ccContextMenuStrip;
            cmdsListPanel.ContextMenuStrip = ccContextMenuStrip;
            cmdsListTextArea.ContextMenuStrip = ccContextMenuStrip;
            cmdsListLabel.ContextMenuStrip = ccContextMenuStrip;
            headerLabel.ContextMenuStrip = ccContextMenuStrip;

            // Performance Display
            performanceObject = new Performance(this.footerLabelProcessesValue, this.footerLabelCPUValue, this.footerLabelRAMValue, this);

            // Scanner Display
            scannerDisplayObject = new ScannerDisplay(this.scanner);

            // Program Settings
            setCCSettings();

            // Open Notes
            // Open all note files
            NoteLib noteLibrary = new NoteLib();
            noteLibrary.openAllNotes();
        }


        #region FRAME LOGIC  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        // Create frame
        private void generateFrame()
        {
            Point defaultPoint = new Point(this.Location.X, this.Location.Y);
            
            cFrame = new Frame(this);
            cFrame.Show();
            
            this.Location = defaultPoint;
        }

        // Mirror movements to frame
        private void CommandCentralWindow_LocationChanged(object sender, EventArgs e)
        {
            if (cFrame == null) return;
            cFrame.Location = new Point(this.Location.X, this.Location.Y);
        }
        // Mirror size changes to frame
        private void CommandCentralWindow_SizeChanged(object sender, EventArgs e)
        {
            if (cFrame == null) return;
            cFrame.Size = new Size(this.Width, this.Height);
        }

        #endregion

        #region CORE LOGIC  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        /// <summary>
        /// Generates the solid frame and initialize first row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommandCentralWindow_Shown(object sender, EventArgs e)
        {
            generateFrame();
            createNewRow(CommandProcessor.RowType.ReadyForInput);
        }

        /// <summary>
        /// Clears the grid
        /// </summary>
        public void clearScreen()
        {
            this.cmdEntryDataGrid.Rows.Clear();
        }

        /// <summary>
        /// Loads/refreshes the CommandsList
        /// </summary>
        public void updateCommandsList(CustomCmdsList cmdList)
        {
            this.refreshInterfaceCommandsList(cmdList);
            cmdProc.updateCommandsList(cmdList);
        }
        private void refreshInterfaceCommandsList()
        {
            CustomCmdsList cmdsList = new CustomCmdsList();
            refreshInterfaceCommandsList(cmdsList);
        }
        private void refreshInterfaceCommandsList(CustomCmdsList cmdList)
        {
            CustomCmdsList cmdsList = new CustomCmdsList();
            if (cmdsList.getCommandsList().Count == 0)
                return;

            this.cmdsListTextArea.Text = "";
            for (int i = 0; i < cmdsList.getCommandsList().Count; i++)
                this.cmdsListTextArea.Text += cmdsList.getCommandsList()[i].CmdName + "\r\n";
            
            // Added permanent scrollbar here (Version 4.7)
            this.cmdsListTextArea.ScrollBars = ScrollBars.Vertical;
        }

        /// <summary>
        /// Handles adding new rows to the grid
        /// </summary>
        public void createNewRow(CommandProcessor.RowType rowType, string newRowValue = "", bool newRowRequired=true)
        {
            // Format row we are leaving
            if (this.cmdEntryDataGrid.RowCount > 0)
            {
                this.cmdEntryDataGrid.CurrentCell = this.cmdEntryDataGrid.Rows[cmdEntryDataGrid.RowCount - 1].Cells[CommandGridAttributes.Columns.COL_COMMAND];

                if (rowType.Equals(CommandProcessor.RowType.Error))
                {
                    this.cmdEntryDataGrid.CurrentCell = this.cmdEntryDataGrid.Rows[cmdEntryDataGrid.RowCount - 3].Cells[CommandGridAttributes.Columns.COL_COMMAND];
                    this.cmdEntryDataGrid.CurrentCell.Style.ForeColor = Lib.FAIL_COLOR;
                }
                if (rowType.Equals(CommandProcessor.RowType.InfoProvided) || rowType.Equals(CommandProcessor.RowType.Executing))
                    this.cmdEntryDataGrid.CurrentCell.Style.ForeColor = Lib.DEFAULT_PRIMARY_COLOR;
            }

            // Add new row
            int newRowID;
            if (newRowRequired)
                this.cmdEntryDataGrid.Rows.Add();
            newRowID = cmdEntryDataGrid.RowCount - 1;

            // What to display in the margin depends on the type of row this is
            if (rowType.Equals(CommandProcessor.RowType.Error) || 
                rowType.Equals(CommandProcessor.RowType.InfoProvided) ||
                rowType.Equals(CommandProcessor.RowType.Executing))
                this.cmdEntryDataGrid.Rows[newRowID].Cells[CommandGridAttributes.Columns.COL_MARGIN].Value = CommandGridAttributes.MARGIN_CHAR_MESSAGE;
            
            if (rowType.Equals(CommandProcessor.RowType.ReadyForInput))
                this.cmdEntryDataGrid.Rows[newRowID].Cells[CommandGridAttributes.Columns.COL_MARGIN].Value = CommandGridAttributes.MARGIN_CHAR_DEFAULT;

            // Set newRowValue - single line
            if (!newRowValue.Contains(Lib.NL))
            {
                this.cmdEntryDataGrid.CurrentCell = this.cmdEntryDataGrid.Rows[newRowID].Cells[CommandGridAttributes.Columns.COL_COMMAND];
                this.cmdEntryDataGrid.CurrentCell.Value = newRowValue;
            }

            // Set newRowValue - multi line
            if (newRowValue.Contains(Lib.NL))
            {
                string currRowValue = "";
                for (int i = 0; i < newRowValue.Length; i++)
                {
                    // NewLine character 
                    // - write accumulated text to current row
                    // - add new row
                    if (newRowValue[i].ToString().Equals(Lib.NL))
                    {
                        this.cmdEntryDataGrid.CurrentCell = this.cmdEntryDataGrid.Rows[newRowID].Cells[CommandGridAttributes.Columns.COL_COMMAND];
                        this.cmdEntryDataGrid.CurrentCell.Value = currRowValue;

                        this.cmdEntryDataGrid.Rows.Add();
                        newRowID = cmdEntryDataGrid.RowCount - 1;
                        currRowValue = "";
                    }
                    else // accumulate text
                        currRowValue += newRowValue[i];
                }
            }


            // Add entry row if text was written to user
            if (newRowValue.Length > 0)
            {
                this.cmdEntryDataGrid.Rows.Add();
                this.cmdEntryDataGrid.Rows[cmdEntryDataGrid.RowCount - 1].Cells[CommandGridAttributes.Columns.COL_MARGIN].Value = CommandGridAttributes.MARGIN_CHAR_DEFAULT;
                this.cmdEntryDataGrid.CurrentCell = this.cmdEntryDataGrid.Rows[cmdEntryDataGrid.RowCount - 1].Cells[CommandGridAttributes.Columns.COL_COMMAND];
            }

            // Set focus to new row
            this.cmdEntryDataGrid.Focus();
            this.cmdEntryDataGrid.BeginEdit(false);
        }

        /// <summary>
        /// Show CommandManagerWindow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void commandsMenuItem_Click(object sender, EventArgs e)
        {
            CommandManagerWindow oCmdMngrWin = new CommandManagerWindow(this);
            oCmdMngrWin.StartPosition = FormStartPosition.CenterParent;
            oCmdMngrWin.ShowDialog(this);
        }

        /// <summary>
        /// Show CustomizeAppearanceWindow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void customizeMenuItem_Click(object sender, EventArgs e)
        {
            CommandCentralSettingsWindow oCustAppWin = new CommandCentralSettingsWindow(this);
            oCustAppWin.StartPosition = FormStartPosition.CenterParent;
            oCustAppWin.ShowDialog(this);
        }

        /// <summary>
        /// Main Key press handler - what is and is not allowed on the UI side
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // DO NOT ALLOW THE FOLLOWING KEYS
            // [TAB]
            // [PGUP/PGDN]
            // [CONTROL]
            if (keyData.Equals(Keys.Tab) ||
                keyData.Equals(Keys.PageDown) ||
                keyData.Equals(Keys.PageUp) ||
                keyData.Equals(Keys.Escape) ||
                keyData.ToString().Contains(Keys.Shift.ToString()) ||
                keyData.ToString().Contains(Keys.Control.ToString()))
                return true;

            // ENSURE WE ARE IN THE LAST ROW
            if (this.cmdEntryDataGrid.CurrentCell.RowIndex != this.cmdEntryDataGrid.Rows.Count - 1)
                this.cmdEntryDataGrid.CurrentCell = this.cmdEntryDataGrid.Rows[cmdEntryDataGrid.RowCount - 1].Cells[CommandGridAttributes.Columns.COL_COMMAND];

            // HANDLE ENTER KEY (Process cmd)
            if (keyData.Equals(Keys.Enter))
            {
                // Get cell value
                String cmdName = (this.cmdEntryDataGrid.CurrentCell.EditedFormattedValue == null) ? "" : this.cmdEntryDataGrid.CurrentCell.EditedFormattedValue.ToString();

                // Add to buffer
                if (cmdName.Length > 0)
                    cmdBuffer.addEntry(cmdName);

                // Execute Command
                cmdProc.executeCmd(cmdName);
                return true;
            }

            // HANDLE UP/DOWN ARROW KEYS (Buffer)
            if (keyData.Equals(Keys.Up) || keyData.Equals(Keys.Down))
            {
                // ensure we are in the last row, command column
                if (this.cmdEntryDataGrid.CurrentCell.RowIndex != this.cmdEntryDataGrid.Rows.Count - 1 || this.cmdEntryDataGrid.CurrentCell.ColumnIndex != this.cmdEntryDataGrid.Columns.Count - 1)
                {
                    this.cmdEntryDataGrid.Rows[this.cmdEntryDataGrid.Rows.Count - 1].Selected = true;
                    this.cmdEntryDataGrid.CurrentCell = this.cmdEntryDataGrid.Rows[cmdEntryDataGrid.RowCount - 1].Cells[CommandGridAttributes.Columns.COL_COMMAND];
                    this.cmdEntryDataGrid.BeginEdit(true);
                }

                if (keyData.Equals(Keys.Up))
                {
                    this.cmdEntryDataGrid.CurrentCell.Value = cmdBuffer.getPreviousEntry();
                    this.cmdEntryDataGrid.RefreshEdit();
                    SendKeys.Send("{RIGHT}");

                }
                else if (keyData.Equals(Keys.Down))
                {
                    this.cmdEntryDataGrid.CurrentCell.Value = cmdBuffer.getNextEntry();
                    this.cmdEntryDataGrid.RefreshEdit();
                    SendKeys.Send("{RIGHT}");
                }

                return true;
            }

            // HANDLE LEFT/RIGHT ARROW KEYS
            if (keyData.Equals(Keys.Left))
                return true;


            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// On close, write last settings to the app registry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommandCentralWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save location to registry
            string x = this.Location.X.ToString();
            string y = this.Location.Y.ToString();

            // Save size to registry
            string width = this.Width.ToString();
            string height = this.Height.ToString();

            //AppRegistry appReg = new AppRegistry();

            //appReg.setKeyValue(AppRegistry.CCKeys.LocX, x);
            //appReg.setKeyValue(AppRegistry.CCKeys.LocY, y);

            //appReg.setKeyValue(AppRegistry.CCKeys.Width, width);
            //appReg.setKeyValue(AppRegistry.CCKeys.Height, height);

            AppSettings oAppSettings = new AppSettings();

            // Save location to settings file
            oAppSettings.setSettingsValue(AppSettings.CCSettingKeys.LocX, x);
            oAppSettings.setSettingsValue(AppSettings.CCSettingKeys.LocY, y);

            // Save size to settings file
            oAppSettings.setSettingsValue(AppSettings.CCSettingKeys.Width, width);
            oAppSettings.setSettingsValue(AppSettings.CCSettingKeys.Height, height);
        }

        #endregion

        #region UI SETUP  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// Customizes the interface and program behavior based on the settings in the user settings file
        /// </summary>
        public void setCCSettings(bool setAppTransparency = true, bool setAppTopMost = true, bool setAppStartPosition=true, bool setAppSize = true, bool setThresholdLevels = true)
        {
            // Custom UI Settings
            //AppRegistry oAppReg = new AppRegistry();

            //if (setAppTransparency) this.setAppTransparency(oAppReg.getKeyValue(AppRegistry.CCKeys.Transparency));
            //if (setAppTopMost) this.setAppTopMost(oAppReg.getKeyValue(AppRegistry.CCKeys.TopMost));
            //if (setAppStartPosition) this.setAppStartPosition(oAppReg.getKeyValue(AppRegistry.CCKeys.LocX), oAppReg.getKeyValue(AppRegistry.CCKeys.LocY));
            //if (setAppSize) this.setAppSize(oAppReg.getKeyValue(AppRegistry.CCKeys.Width), oAppReg.getKeyValue(AppRegistry.CCKeys.Height));
        
            // Custom UI settings

            AppSettings oAppSettings = new AppSettings();

            if (setAppTransparency) this.setAppTransparency(oAppSettings.getSettingValue(AppSettings.CCSettingKeys.Transparency));
            if (setAppTopMost) this.setAppTopMost(oAppSettings.getSettingValue(AppSettings.CCSettingKeys.TopMost));
            if (setAppStartPosition) this.setAppStartPosition(oAppSettings.getSettingValue(AppSettings.CCSettingKeys.LocX), oAppSettings.getSettingValue(AppSettings.CCSettingKeys.LocY));
            if (setAppSize) this.setAppSize(oAppSettings.getSettingValue(AppSettings.CCSettingKeys.Width), oAppSettings.getSettingValue(AppSettings.CCSettingKeys.Height));
            if (setThresholdLevels) this.setThresholdLevels(oAppSettings.getSettingValue(AppSettings.CCSettingKeys.CPUThresholdLevel1), oAppSettings.getSettingValue(AppSettings.CCSettingKeys.CPUThresholdLevel2), oAppSettings.getSettingValue(AppSettings.CCSettingKeys.RAMThresholdLevel1), oAppSettings.getSettingValue(AppSettings.CCSettingKeys.RAMThresholdLevel2));
        }

        /// <summary>
        /// Initalizes/draws the UI
        /// </summary>
        private void InitializeUI()
        {
            // Window Title
            this.Text = About.APP_NAME_LONG + " " + About.APP_VERSION;

            //-----------------------------------------------------
            // Header Labels
            //-----------------------------------------------------
            this.headerLabel.Text = About.APP_COPYRIGHT;
            this.headerLabel.Font = new Font(Lib.DEFAULT_APP_FONT, 9.00F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.ForeColor = Lib.DEFAULT_SECONDARY_COLOR;

            this.labelUsername.Text = (Lib.HDR_OS_USER).ToUpper();
            this.labelUsername.Font = new Font(Lib.DEFAULT_APP_FONT, 9.00F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.labelUsername.ForeColor = Lib.DEFAULT_PRIMARY_COLOR;

            //-----------------------------------------------------
            // Commands List
            //-----------------------------------------------------
            this.cmdsListLabel.Font = new Font(Lib.DEFAULT_APP_FONT, 9.00F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.cmdsListLabel.ForeColor = Lib.DEFAULT_PRIMARY_COLOR;

            this.cmdsListTextArea.Font = new Font(Lib.DEFAULT_APP_FONT, 9.00F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.cmdsListTextArea.ForeColor = Lib.DEFAULT_SECONDARY_COLOR;

            //-----------------------------------------------------
            // Footer 
            //-----------------------------------------------------
            Font FooterFont = new Font(Lib.DEFAULT_APP_FONT, 9.00F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.footerPanel.Font = FooterFont;
            this.footerLabelProcessesValue.ForeColor = Lib.DEFAULT_PRIMARY_COLOR;
            this.footerLabelCPUValue.ForeColor = Lib.DEFAULT_PRIMARY_COLOR;
            this.footerLabelRAMValue.ForeColor = Lib.DEFAULT_PRIMARY_COLOR;
            Font ValuesFont = new Font(Lib.DEFAULT_APP_FONT, 10.00F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.footerLabelProcessesValue.Font = ValuesFont;
            this.footerLabelCPUValue.Font = ValuesFont;
            this.footerLabelRAMValue.Font = ValuesFont;

            //-----------------------------------------------------
            // Scanner Display
            //-----------------------------------------------------
            scanner = new Scanner();
            this.scanner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            //this.scanner.BackColor = System.Drawing.Color.LimeGreen;
            this.scanner.BackgroundImage = Properties.Resources.scanner_glow;
            this.scanner.BackgroundImageLayout = ImageLayout.Stretch;
            this.scanner.Location = new System.Drawing.Point(0, 405);
            this.scanner.Name = "panelScannerDisplay";
            this.scanner.Size = new System.Drawing.Size(Properties.Resources.scanner_glow.Width, Properties.Resources.scanner_glow.Height);
            this.scanner.TabIndex = 102;
            this.panelMainArea.Controls.Add(this.scanner);

            //-----------------------------------------------------
            // DataGrid (Main area)
            //-----------------------------------------------------
            // ROW TEMPLATE
            DataGridViewRow templateRow = new DataGridViewRow();
            templateRow.Height = CommandGridAttributes.ROW_HEIGHT;
            this.cmdEntryDataGrid.RowTemplate = templateRow;

            // ADD COLUMNS
            DataGridViewTextBoxColumn marginColumn = new DataGridViewTextBoxColumn();
            marginColumn.Width = 15;
            marginColumn.Name = CommandGridAttributes.Columns.COL_MARGIN;
            marginColumn.ReadOnly = true;

            DataGridViewTextBoxColumn commandColumn = new DataGridViewTextBoxColumn();
            commandColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            commandColumn.Name = CommandGridAttributes.Columns.COL_COMMAND;

            this.cmdEntryDataGrid.Columns.Add(marginColumn);
            this.cmdEntryDataGrid.Columns.Add(commandColumn);

            // DEFAULT CELL STYLE
            DataGridViewCellStyle defaultCellStyle = new DataGridViewCellStyle();
            defaultCellStyle.BackColor = this.BackColor;
            defaultCellStyle.ForeColor = this.ForeColor;
            defaultCellStyle.SelectionBackColor = Color.FromArgb(60, 60, 60);
            defaultCellStyle.SelectionForeColor = Lib.DEFAULT_SECONDARY_COLOR;
            defaultCellStyle.Font = new Font(Lib.DEFAULT_APP_FONT, 9.00F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            this.cmdEntryDataGrid.DefaultCellStyle = defaultCellStyle;


        }

        /// <summary>
        /// Sets the form transparency
        /// </summary>
        /// <param name="amount"></param>
        private void setAppTransparency(double amount)
        {
            this.Opacity = 1-(amount/100);
        }
        public void setAppTransparency(string amount)
        {
            double amountAsDouble;

            // Validate first
            if (amount.Length == 0)
                return;
            else if (double.TryParse(amount, out amountAsDouble))
                setAppTransparency(amountAsDouble);
            else
                return;

        }

        /// <summary>
        /// Sets the TopMost property of the form 
        /// </summary>
        /// <param name="option"></param>
        public void setAppTopMost(string option)
        {
            if (option.Length == 0)
                return;

            if (option.Equals("Yes"))
                this.TopMost = true;
            else if (option.Equals("No"))
                this.TopMost = false;
        }

        /// <summary>
        /// Sets the Forms default location
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void setAppStartPosition(int x, int y)
        {
            if (x < 0) x = 0;
            if (y < 0) y = 0;
            this.Location = new Point(x, y);
        }
        private void setAppStartPosition(string x, string y)
        {
            int xAsInt, yAsInt;

            // Validate first
            if (x.Length == 0 || y.Length == 0)
                return;
            else if (int.TryParse(x, out xAsInt) && int.TryParse(y, out yAsInt))
                setAppStartPosition(xAsInt, yAsInt);
            else
                return;
        }

        /// <summary>
        /// Sets the Forms size
        /// </summary>
        /// <param name="w"></param>
        /// <param name="h"></param>
        private void setAppSize(int w, int h)
        {
            this.Width = (w<0)?0:w;
            this.Height = (h<0)?0:h;
        }
        private void setAppSize(string w, string h)
        {
            int wAsInt, hAsInt;

            // Validate first
            if (w.Length == 0 || h.Length == 0)
                return;
            else if (int.TryParse(w, out wAsInt) && int.TryParse(h, out hAsInt))
                setAppSize(wAsInt, hAsInt);
            else
                return;
        }

        /// <summary>
        /// Set performance threshold values
        /// </summary>
        /// <param name="cpuThreshold1"></param>
        /// <param name="cpuThreshold2"></param>
        /// <param name="ramThreshold1"></param>
        /// <param name="ramThreshold2"></param>
        private void setThresholdLevels(string cpuThreshold1, string cpuThreshold2, string ramThreshold1, string ramThreshold2)
        {
            int cpuThreshold1Value, cpuThreshold2Value;
            double ramThreshold1Value, ramThreshold2Value;

            // Validate first
            if (cpuThreshold1.Length == 0 || cpuThreshold2.Length == 0 || ramThreshold1.Length == 0 || ramThreshold2.Length == 0)
                return;
            else if (int.TryParse(cpuThreshold1, out cpuThreshold1Value) && int.TryParse(cpuThreshold2, out cpuThreshold2Value) &&
                double.TryParse(ramThreshold1, out ramThreshold1Value) && double.TryParse(ramThreshold2, out ramThreshold2Value))
                performanceObject.setThresholdLevels(cpuThreshold1Value, cpuThreshold2Value, ramThreshold1Value, ramThreshold2Value);
            else
                return;
        }
        #endregion --------------------------------------------------------------------------------------------------------

        #region GRID HANDLERS >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// If the Commands List panel is clicked on, sets focus back to the cmdEntryDataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdsListTextArea_Enter(object sender, EventArgs e)
        {
            this.cmdEntryDataGrid.CurrentCell = this.cmdEntryDataGrid.Rows[cmdEntryDataGrid.RowCount - 1].Cells[CommandGridAttributes.Columns.COL_COMMAND];
            this.cmdEntryDataGrid.BeginEdit(false);
        }

        /// <summary>
        /// Invalid Click - click on other than active cell will return focus to active/last cell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdEntryDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Invalid Click - click on other than active cell
            if (e.ColumnIndex == 0 || e.RowIndex != cmdEntryDataGrid.RowCount - 1)
            {
                this.cmdEntryDataGrid.CurrentCell = this.cmdEntryDataGrid.Rows[cmdEntryDataGrid.RowCount - 1].Cells[CommandGridAttributes.Columns.COL_COMMAND];
                this.cmdEntryDataGrid.BeginEdit(false);
                return;
            }
        }


        /// <summary>
        /// Kicks the user out of the cell if it is not the last cell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdEntryDataGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 1 || e.RowIndex != this.cmdEntryDataGrid.Rows.Count - 1)
                SendKeys.Send("{Tab}");
        }

        private void cmdsListTextArea_MouseHover(object sender, EventArgs e)
        {
            // Note: Commented out in version 4.7. Added permanent scrollbar to Constructor.
            //this.cmdsListTextArea.ScrollBars = ScrollBars.Vertical;
        }

        private void cmdsListTextArea_MouseLeave(object sender, EventArgs e)
        {
            // Note: Commented out in version 4.7
            //this.cmdsListTextArea.ScrollBars = ScrollBars.None;
        }

        #endregion

        #region RETIRED

        /// <summary>
        /// Sets the background and text colours
        /// </summary>
        /// <param name="bgColourAsString"></param>
        /// <param name="txtColourAsString"></param>
        //public void setAppColours(string bgColourAsString, string txtColourAsString)
        //{
        //    if (bgColourAsString.Length == 0 && txtColourAsString.Length == 0)
        //        return;

        //    Color bgColour = new Color();
        //    Color textColour = new Color();

        //    bgColour = (bgColourAsString.Length==0) ? this.BackColor : Color.FromName(bgColourAsString);
        //    textColour = (txtColourAsString.Length==0) ? this.ForeColor : Color.FromName(txtColourAsString);

        //    // FORM
        //    this.BackColor = bgColour;
        //    this.ForeColor = textColour;

        //    // DATAGRIDVIEW MAIN
        //    this.cmdEntryDataGrid.BackgroundColor = bgColour;
        //    this.cmdEntryDataGrid.ForeColor = textColour;
        //    DataGridViewCellStyle defaultStyle = new DataGridViewCellStyle();
        //    defaultStyle.BackColor = bgColour;
        //    defaultStyle.ForeColor = textColour;
        //    this.cmdEntryDataGrid.DefaultCellStyle = defaultStyle;

        //    // COMMAND LIST DISPLAY
        //    this.cmdsListPanel.BackColor = bgColour;
        //    this.cmdsListPanel.ForeColor = textColour;
        //    this.cmdsListTextArea.BackColor = bgColour;
        //    this.cmdsListTextArea.ForeColor = textColour;
        //    this.cmdsListLabel.BackColor = bgColour;
        //    this.cmdsListLabel.ForeColor = textColour;

        //    // VERSION LABEL
        //    this.headerLabel.BackColor = bgColour;
        //    this.headerLabel.ForeColor = textColour;
        //}


        #endregion

    }
}
