using CommandCentral.CC_CoreObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommandCentral.CC_UI
{
    public partial class CommandManagerWindow : Form
    {
        private CommandCentralWindow oParentForm;
        private ECommandsList oCmdsList;


        /// <summary>
        /// Constructor
        /// </summary>
        public CommandManagerWindow(CommandCentralWindow parentWindow)
        {
            InitializeComponent();

            // Setup objects
            oCmdsList = new ECommandsList();
            oParentForm = parentWindow;

            // Setup UI
            this.loadCmdList();

        }

        /// <summary>
        /// Set focus to CmdNameTextBox when form is first shown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommandManagerWindow_Shown(object sender, EventArgs e)
        {
            this.addTab_CmdNameTextBox.Focus();
        }


        /// <summary>
        /// Loads Internal Commands List onto interface listboxes
        /// </summary>
        private void loadCmdList()
        {
            this.editTab_CmdListBox.Items.Clear();
            this.removeTab_CmdListBox.Items.Clear();

            List<ECommand> cmdsList = oCmdsList.getCommandsList();
            if (cmdsList.Count == 0)
                return;

            cmdsList.Sort();

            int i = 0;
            for (i = 0; i < cmdsList.Count; i++)
            {
                editTab_CmdListBox.Items.Add(cmdsList[i].CmdName);
                removeTab_CmdListBox.Items.Add(cmdsList[i].CmdName);
            }

            // Setting first item as default.
            this.editTab_CmdListBox.SelectedItem = this.editTab_CmdListBox.Items[0];
            this.removeTab_CmdListBox.SelectedItem = this.removeTab_CmdListBox.Items[0];

            // Refresh ParentWindow list
            oParentForm.refreshCommandsList();
        }


        /// <summary>
        /// Adds a new command
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addTab_AddButton_Click(object sender, EventArgs e)
        {
            string name = this.addTab_CmdNameTextBox.Text;
            string command = this.addTab_RunCmdTextBox.Text;

            if (name.Length == 0 || command.Length == 0)
                return;

            bool result = oCmdsList.addCmd(new ECommand(name, command));

            // IF failed to add
            if (!result)
            {
                MessageBox.Show("Command cannot be added.\nA command with the same name may already exist.", "New Command", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // REFRESHING
            this.addTab_CmdNameTextBox.Clear();
            this.addTab_RunCmdTextBox.Clear();

            this.loadCmdList();
            MessageBox.Show("Command created successfully.", "New Command", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        /// <summary>
        /// Open File Dialog. Set selection to textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addTab_BrowseFileButton_Click(object sender, EventArgs e)
        {
            DialogResult fileResult = this.openFileAdd.ShowDialog();

            if (fileResult.Equals(DialogResult.OK))
            {
                this.addTab_RunCmdTextBox.Text = this.openFileAdd.FileName.ToString();
                this.addTab_AddButton.Focus();
            }

        }

        /// <summary>
        /// Open Folder Dialog. Set selection to textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addTab_BrowseFolderButton_Click(object sender, EventArgs e)
        {
            folderBrowser.ShowDialog();

            if (folderBrowser.SelectedPath.Length > 0)
            {
                this.addTab_RunCmdTextBox.Text = folderBrowser.SelectedPath;
                this.addTab_AddButton.Focus();
            }
        }


        /// <summary>
        /// Sets the RunCmd of the selected CmdName in the RunCmdTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeTab_CmdListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCmdName = this.removeTab_CmdListBox.SelectedItem.ToString();
            ECommand selectedCommand = new ECommand(selectedCmdName);

            this.removeTab_RunCmdTextBox.Text = selectedCommand.RunCmd;
        }

        /// <summary>
        /// Removes the selected Cmd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeTab_RemoveButton_Click(object sender, EventArgs e)
        {
            ECommand remCmd = new ECommand(this.removeTab_CmdListBox.SelectedItem.ToString());
            oCmdsList.removeCmd(remCmd);

            // REFRESHING
            this.removeTab_RunCmdTextBox.Clear();

            this.loadCmdList();
            MessageBox.Show("Command removed successfully.", "Command Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }





        /***********************************************************************
         * Loads requested command in textbox
         ***********************************************************************/
        private void editTab_CmdListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cmdTextBox.Text = oCmdsList.getProfileString("[COMMANDS]", this.cmdListBox.SelectedItem.ToString());
        }


        /***********************************************************************
         * Saves the new command
         ***********************************************************************/
        private void editTab_SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                //oCmdsList.setProfileString("[COMMANDS]", this.cmdListBox.SelectedItem.ToString(), cmdTextBox.Text);
                MessageBox.Show("Changes saved successfully.", "Command Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Unable to save changes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        /***********************************************************************
         * Open File Dialog. (EDIT)
         ***********************************************************************/
        private void editTab_BrowseFileButton_Click(object sender, EventArgs e)
        {
            DialogResult fileResult = this.openFileEdit.ShowDialog();

            if (fileResult.ToString() == "OK")
                this.editTab_RunCmdTextBox.Text = this.openFileEdit.FileName.ToString();
        }
        /***********************************************************************
         * Open Folder Dialog. (EDIT)
         ***********************************************************************/
        private void editTab_BrowseFolderButton_Click(object sender, EventArgs e)
        {
            folderBrowser.ShowDialog();

            String selectedFolder = folderBrowser.SelectedPath;

            if (selectedFolder.Length > 0)
                this.editTab_RunCmdTextBox.Text = selectedFolder;
        }

  





        /***********************************************************************
         * TEXT BOX HANDLERS (NO BLANKS)
         ***********************************************************************/
        private void editTab_RunCmdTextBox_TextChanged(object sender, EventArgs e)
        {
            if (editTab_RunCmdTextBox.Text.Length < 1)
                editTab_SaveButton.Enabled = false;
            else if (editTab_RunCmdTextBox.Text.Length > 0)
                editTab_SaveButton.Enabled = true;
        }
        private void addTab_CmdNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (addTab_CmdNameTextBox.Text.Length < 1)
                addTab_AddButton.Enabled = false;
            else if ((addTab_CmdNameTextBox.Text.Length > 0) && (addTab_RunCmdTextBox.Text.Length > 0))
                addTab_AddButton.Enabled = true;
        }
        private void addTab_RunCmdTextBox_TextChanged(object sender, EventArgs e)
        {
            if (addTab_RunCmdTextBox.Text.Length < 1)
                addTab_AddButton.Enabled = false;
            else if ((addTab_RunCmdTextBox.Text.Length > 0) && (addTab_CmdNameTextBox.Text.Length > 0))
                addTab_AddButton.Enabled = true;
        }

        /***********************************************************************
         * Close Button Handler
         ***********************************************************************/
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        /***********************************************************************
         * KeyPress Handler (Escape Key)
         ***********************************************************************/
        private void cmdControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                this.Hide();
        }

        /***********************************************************************
         * Shortcuts Handler (ALT + A, E, R) to display Tabs
         ***********************************************************************/
        private void addToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            cmdTabControl.SelectTab(0);
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cmdTabControl.SelectTab(1);
        }
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cmdTabControl.SelectTab(2);
        }

 
    }
}
