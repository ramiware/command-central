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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommandCentral.CC_UI
{
    public partial class CommandCentralWindow : Form
    {

        private CommandProcessor cmdProc;
        private CommandBuffer cmdBuffer;

        /// <summary>
        /// 
        /// </summary>
        public CommandCentralWindow()
        {

            // Initailize UI
            Application.EnableVisualStyles();
            InitializeComponent();

            // Grid
            InitializeDataGrid();
            //this.cmdEntryDataGrid.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            // Custom UI
            InitializeCustomInterface();

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


        }

        /// <summary>
        /// Initialize first row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommandCentralWindow_Shown(object sender, EventArgs e)
        {
            initFirstRow();
        }
        private void initFirstRow()
        {
            // INITIALIZE THE FIRST ROW
            createNewRow(CommandProcessor.ReturnType.InfoMsg, Lib.FIRST_LINE_VALUE);
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
        private void createNewRow(CommandProcessor.ReturnType runCmdReturnType, string newRowValue = "")
        {
            // --------------------------------------
            // Format row we are leaving
            // --------------------------------------
            if (this.cmdEntryDataGrid.RowCount > 0)
            {
                this.cmdEntryDataGrid.CurrentCell = this.cmdEntryDataGrid.Rows[cmdEntryDataGrid.RowCount - 1].Cells[CommandGridAttributes.Columns.COL_COMMAND];

                if (runCmdReturnType.Equals(CommandProcessor.ReturnType.ErrorMsg))
                    this.cmdEntryDataGrid.CurrentCell.Style.ForeColor = Color.Gray;
                if (runCmdReturnType.Equals(CommandProcessor.ReturnType.InfoMsg))
                    this.cmdEntryDataGrid.CurrentCell.Style.ForeColor = Color.Gold;
                if (runCmdReturnType.Equals(CommandProcessor.ReturnType.ExecMsg))
                    this.cmdEntryDataGrid.CurrentCell.Style.ForeColor = Color.LimeGreen;

            }

            // --------------------------------------
            // Add new row
            // --------------------------------------
            int newRowID;
            this.cmdEntryDataGrid.Rows.Add();
            newRowID = cmdEntryDataGrid.RowCount - 1;

            if (runCmdReturnType.Equals(CommandProcessor.ReturnType.ErrorMsg) || 
                runCmdReturnType.Equals(CommandProcessor.ReturnType.InfoMsg) ||
                runCmdReturnType.Equals(CommandProcessor.ReturnType.ExecMsg))
                this.cmdEntryDataGrid.Rows[newRowID].Cells[CommandGridAttributes.Columns.COL_MARGIN].Value = CommandGridAttributes.MARGIN_CHAR_MESSAGE;
            else
                this.cmdEntryDataGrid.Rows[newRowID].Cells[CommandGridAttributes.Columns.COL_MARGIN].Value = CommandGridAttributes.MARGIN_CHAR_DEFAULT;

            // --------------------------------------
            // Set newRowValue - single line
            // --------------------------------------
            if (!newRowValue.Contains(Lib.NL))
            {
                this.cmdEntryDataGrid.CurrentCell = this.cmdEntryDataGrid.Rows[newRowID].Cells[CommandGridAttributes.Columns.COL_COMMAND];
                this.cmdEntryDataGrid.CurrentCell.Value = newRowValue;

                // Handle FIRST_LINE_VALUE - Color code
                if (newRowValue.Equals(Lib.FIRST_LINE_VALUE))
                    this.cmdEntryDataGrid.CurrentCell.Style.ForeColor = Color.LimeGreen;
            }

            // --------------------------------------
            // Set newRowValue - multi line
            // --------------------------------------
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
        /// Main Key press handler
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


            // HANDLE ENTER KEY (Process cmd)
            if (keyData.Equals(Keys.Enter))
            {
                // Get cell value
                String cmdName = (this.cmdEntryDataGrid.CurrentCell.EditedFormattedValue == null) ? "" : this.cmdEntryDataGrid.CurrentCell.EditedFormattedValue.ToString();

                // Add to buffer
                if (cmdName.Length > 0)
                    cmdBuffer.addEntry(cmdName);

                // Execute Command
                string runCmdReturnString = "";
                CommandProcessor.ReturnType runCmdReturnType;
                cmdProc.executeCmd(new CommandObject(cmdName), out runCmdReturnType, out runCmdReturnString);
                createNewRow(runCmdReturnType, runCmdReturnString);
       
                return true;
            }

            // HANDLE UP/DOWN ARROW KEYS (Buffer)
            if (keyData.Equals(Keys.Up) || keyData.Equals(Keys.Down))
            {
                if (keyData.Equals(Keys.Up))
                {
                    this.cmdEntryDataGrid.CurrentCell.Value = cmdBuffer.getPreviousEntry();
                    MessageBox.Show("Figure out how to display value. Currently it will show if you hit enter");
                }
                else if (keyData.Equals(Keys.Down))
                {
                    this.cmdEntryDataGrid.CurrentCell.Value = cmdBuffer.getNextEntry();
                }
                
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #region UI SETUP  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// Sets up the datagrid
        /// </summary>
        private void InitializeDataGrid()
        {
            // Setting up datagrid
            // ROW TEMPLATE
            DataGridViewRow templateRow = new DataGridViewRow();
            templateRow.Height = CommandGridAttributes.ROW_HEIGHT;
            this.cmdEntryDataGrid.RowTemplate = templateRow;

            // ADD COLUMNS
            DataGridViewTextBoxColumn marginColumn = new DataGridViewTextBoxColumn();
            marginColumn.Width = 10;
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
            defaultCellStyle.Font = new Font(Lib.APP_FONT, 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            this.cmdEntryDataGrid.DefaultCellStyle = defaultCellStyle;
        }

        /// <summary>
        /// Customizes the interface based on the settings in the user registry
        /// </summary>
        private void InitializeCustomInterface()
        {
            this.Font = new Font(Lib.APP_FONT, 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.cmdsListLabel.Font = new Font(Lib.APP_FONT, 8.00F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.cmdsListLabel.ForeColor = Color.Gold;
            this.cmdsListTextArea.Font = new Font(Lib.APP_FONT, 8.00F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));

            AppRegistry oAppReg = new AppRegistry();

            this.setAppColours(oAppReg.getKeyValue(AppRegistry.CCKeys.BackColor), oAppReg.getKeyValue(AppRegistry.CCKeys.ForeColor));
            this.setAppTransparency(oAppReg.getKeyValue(AppRegistry.CCKeys.Transparency));
            this.setAppTopMost(oAppReg.getKeyValue(AppRegistry.CCKeys.TopMost));
            this.setAppStartPosition(oAppReg.getKeyValue(AppRegistry.CCKeys.LocX), oAppReg.getKeyValue(AppRegistry.CCKeys.LocY));
            this.setAppSize(oAppReg.getKeyValue(AppRegistry.CCKeys.Width), oAppReg.getKeyValue(AppRegistry.CCKeys.Height));
        }


        /// <summary>
        /// Sets the background and text colours
        /// </summary>
        /// <param name="bgColourAsString"></param>
        /// <param name="txtColourAsString"></param>
        private void setAppColours(string bgColourAsString, string txtColourAsString)
        {
            if (bgColourAsString.Length == 0 || txtColourAsString.Length == 0)
                return;

            Color bgColour = new Color();
            Color textColour = new Color();

            bgColour = Color.FromName(bgColourAsString);
            textColour = Color.FromName(txtColourAsString);

            // FORM
            this.BackColor = bgColour;
            this.ForeColor = textColour;

            // DATAGRIDVIEW MAIN
            this.cmdEntryDataGrid.BackgroundColor = bgColour;
            this.cmdEntryDataGrid.ForeColor = textColour;
            DataGridViewCellStyle defaultStyle = new DataGridViewCellStyle();
            defaultStyle.BackColor = bgColour;
            defaultStyle.ForeColor = textColour;
            this.cmdEntryDataGrid.DefaultCellStyle = defaultStyle;

            // COMMAND LIST DISPLAY
            this.cmdsListPanel.BackColor = bgColour;
            this.cmdsListPanel.ForeColor = textColour;
            this.cmdsListTextArea.BackColor = bgColour;
            this.cmdsListTextArea.ForeColor = textColour;
            this.cmdsListLabel.BackColor = bgColour;
            this.cmdsListLabel.ForeColor = textColour;

            // VERSION LABEL
            this.headerLabel.BackColor = bgColour;
            this.headerLabel.ForeColor = textColour;
        }

        /// <summary>
        /// Sets the form transparency
        /// </summary>
        /// <param name="amount"></param>
        private void setAppTransparency(double amount)
        {
            this.Opacity = amount;
        }
        private void setAppTransparency(string amount)
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
        private void setAppTopMost(string option)
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
            this.Width = w;
            this.Height = h;
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

        
        #region MOUSE HANDLERS >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
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

        #endregion



    }
}
