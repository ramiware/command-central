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
            SetCustomUIAttributes();
           
            // Refresh CommandsList
            refreshCommandsList();

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
            //Performance performanceObject = new Performance(this.footerLabelProcessesValue, this.footerLabelCPUValue, this.footerLabelRAMValue);

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
            createNewRow(CommandProcessor.RunCmdReturnCode.ReadyForInput);
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
        public void refreshCommandsList()
        {
            ECommandsList cmdsList = new ECommandsList();
            if (cmdsList.getCommandsList().Count == 0)
                return;

            this.cmdsListTextArea.Text = "";
            for (int i = 0; i < cmdsList.getCommandsList().Count; i++)
                this.cmdsListTextArea.Text += cmdsList.getCommandsList()[i].CmdName + "\r\n";
        }

        /// <summary>
        /// Handles adding new rows to the grid
        /// </summary>
        private void createNewRow(CommandProcessor.RunCmdReturnCode runCmdReturnCode, string newRowValue = "")
        {
            // --------------------------------------
            // Format row we are leaving
            // --------------------------------------
            if (this.cmdEntryDataGrid.RowCount > 0)
            {
                this.cmdEntryDataGrid.CurrentCell = this.cmdEntryDataGrid.Rows[cmdEntryDataGrid.RowCount - 1].Cells[CommandGridAttributes.Columns.COL_COMMAND];

                if (runCmdReturnCode.Equals(CommandProcessor.RunCmdReturnCode.Error))
                    this.cmdEntryDataGrid.CurrentCell.Style.ForeColor = Color.Gray;
                if (runCmdReturnCode.Equals(CommandProcessor.RunCmdReturnCode.InfoProvided))
                    this.cmdEntryDataGrid.CurrentCell.Style.ForeColor = Color.Gold;
                if (runCmdReturnCode.Equals(CommandProcessor.RunCmdReturnCode.Executed))
                    this.cmdEntryDataGrid.CurrentCell.Style.ForeColor = Color.LimeGreen;

            }

            // --------------------------------------
            // Add new row
            // --------------------------------------
            int newRowID;
            this.cmdEntryDataGrid.Rows.Add();
            newRowID = cmdEntryDataGrid.RowCount - 1;

            // What to display in the margin depends on the type of row this is
            if (runCmdReturnCode.Equals(CommandProcessor.RunCmdReturnCode.Error) || 
                runCmdReturnCode.Equals(CommandProcessor.RunCmdReturnCode.InfoProvided) ||
                runCmdReturnCode.Equals(CommandProcessor.RunCmdReturnCode.Executed))
                this.cmdEntryDataGrid.Rows[newRowID].Cells[CommandGridAttributes.Columns.COL_MARGIN].Value = CommandGridAttributes.MARGIN_CHAR_MESSAGE;
            
            if (runCmdReturnCode.Equals(CommandProcessor.RunCmdReturnCode.ReadyForInput))
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
            CustomizeAppearanceWindow oCustAppWin = new CustomizeAppearanceWindow(this);
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
                string runCmdReturnMessage = "";
                CommandProcessor.RunCmdReturnCode runCmdReturnCode;
                cmdProc.executeCmd(new CommandObject(cmdName), out runCmdReturnCode, out runCmdReturnMessage);
                createNewRow(runCmdReturnCode, runCmdReturnMessage);
       
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
            AppRegistry appReg = new AppRegistry();

            // Save location to registry
            string x = this.Location.X.ToString();
            string y = this.Location.Y.ToString();

            appReg.setKeyValue(AppRegistry.CCKeys.LocX, x);
            appReg.setKeyValue(AppRegistry.CCKeys.LocY, y);

            // Save size to registry
            string width = this.Width.ToString();
            string height = this.Height.ToString();

            appReg.setKeyValue(AppRegistry.CCKeys.Width, width);
            appReg.setKeyValue(AppRegistry.CCKeys.Height, height);

        }

        #endregion

        #region UI SETUP  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// Customizes the interface based on the settings in the user registry
        /// </summary>
        public void SetCustomUIAttributes()
        {
            // Custom Settings
            AppRegistry oAppReg = new AppRegistry();

            //this.setAppColours(oAppReg.getKeyValue(AppRegistry.CCKeys.BackColor), oAppReg.getKeyValue(AppRegistry.CCKeys.ForeColor));
            this.setAppTransparency(oAppReg.getKeyValue(AppRegistry.CCKeys.Transparency));
            this.setAppTopMost(oAppReg.getKeyValue(AppRegistry.CCKeys.TopMost));
            this.setAppStartPosition(oAppReg.getKeyValue(AppRegistry.CCKeys.LocX), oAppReg.getKeyValue(AppRegistry.CCKeys.LocY));
            this.setAppSize(oAppReg.getKeyValue(AppRegistry.CCKeys.Width), oAppReg.getKeyValue(AppRegistry.CCKeys.Height));
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
            this.headerLabel.Font = new Font(Lib.APP_FONT, 9.00F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            this.labelUsername.Text = (Lib.HDR_OS_USER).ToUpper();
            this.labelUsername.Font = new Font(Lib.APP_FONT, 9.00F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.labelUsername.ForeColor = Color.LimeGreen;

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
            defaultCellStyle.SelectionForeColor = Color.White;
            defaultCellStyle.Font = new Font(Lib.APP_FONT, 9.00F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            this.cmdEntryDataGrid.DefaultCellStyle = defaultCellStyle;

            //-----------------------------------------------------
            // Commands List
            //-----------------------------------------------------
            //this.Font = new Font(Lib.APP_FONT, 9.00F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.cmdsListLabel.Font = new Font(Lib.APP_FONT, 8.00F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.cmdsListLabel.ForeColor = Color.Gold;
            this.cmdsListTextArea.Font = new Font(Lib.APP_FONT, 8.00F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));

            //-----------------------------------------------------
            // Footer 
            //-----------------------------------------------------
            this.footerPanel.Font = new Font(Lib.APP_FONT, 9.00F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.footerLabelProcessesValue.ForeColor = Color.LimeGreen;
            this.footerLabelCPUValue.ForeColor = Color.LimeGreen;
            this.footerLabelRAMValue.ForeColor = Color.LimeGreen;
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
            if (amount.Length == 0)
                return;

            double amountAsDouble;
            if (double.TryParse(amount, out amountAsDouble))
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
            if (x.Length == 0 || y.Length == 0)
                return;

            int xAsInt, yAsInt;
            if (int.TryParse(x, out xAsInt) && int.TryParse(y, out yAsInt))
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
            if (w.Length == 0 || h.Length == 0)
                return;

            int wAsInt, hAsInt;
            if (int.TryParse(w, out wAsInt) && int.TryParse(h, out hAsInt))
                setAppSize(wAsInt, hAsInt);
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
