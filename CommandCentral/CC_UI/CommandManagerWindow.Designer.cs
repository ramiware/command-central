namespace CommandCentral.CC_UI
{
    partial class CommandManagerWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            this.Hide();
            /*
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
            */
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.closeButton = new System.Windows.Forms.Button();
            this.cmdTabControl = new System.Windows.Forms.TabControl();
            this.addPage = new System.Windows.Forms.TabPage();
            this.addTab_BrowseFolderButton = new System.Windows.Forms.Button();
            this.addTab_BrowseFileButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.addTab_AddButton = new System.Windows.Forms.Button();
            this.addTab_RunCmdTextBox = new System.Windows.Forms.TextBox();
            this.addTab_CmdNameTextBox = new System.Windows.Forms.TextBox();
            this.addLabel = new System.Windows.Forms.Label();
            this.editPage = new System.Windows.Forms.TabPage();
            this.editTab_BrowseFolderButton = new System.Windows.Forms.Button();
            this.editTab_BrowseFileButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.editTab_SaveButton = new System.Windows.Forms.Button();
            this.instructLabel1 = new System.Windows.Forms.Label();
            this.editTab_RunCmdTextBox = new System.Windows.Forms.TextBox();
            this.editTab_CmdListBox = new System.Windows.Forms.ListBox();
            this.editLabel = new System.Windows.Forms.Label();
            this.removePage = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.removeTab_RemoveButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.removeTab_RunCmdTextBox = new System.Windows.Forms.TextBox();
            this.removeTab_CmdListBox = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.openFileEdit = new System.Windows.Forms.OpenFileDialog();
            this.openFileAdd = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.cmdMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdTabControl.SuspendLayout();
            this.addPage.SuspendLayout();
            this.editPage.SuspendLayout();
            this.removePage.SuspendLayout();
            this.cmdMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(368, 344);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 6;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // cmdTabControl
            // 
            this.cmdTabControl.Controls.Add(this.addPage);
            this.cmdTabControl.Controls.Add(this.editPage);
            this.cmdTabControl.Controls.Add(this.removePage);
            this.cmdTabControl.Location = new System.Drawing.Point(12, 12);
            this.cmdTabControl.Name = "cmdTabControl";
            this.cmdTabControl.SelectedIndex = 0;
            this.cmdTabControl.Size = new System.Drawing.Size(435, 326);
            this.cmdTabControl.TabIndex = 5;
            this.cmdTabControl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CommandManagerWindow_KeyPress);
            // 
            // addPage
            // 
            this.addPage.Controls.Add(this.addTab_BrowseFolderButton);
            this.addPage.Controls.Add(this.addTab_BrowseFileButton);
            this.addPage.Controls.Add(this.label5);
            this.addPage.Controls.Add(this.label4);
            this.addPage.Controls.Add(this.addTab_AddButton);
            this.addPage.Controls.Add(this.addTab_RunCmdTextBox);
            this.addPage.Controls.Add(this.addTab_CmdNameTextBox);
            this.addPage.Controls.Add(this.addLabel);
            this.addPage.Location = new System.Drawing.Point(4, 22);
            this.addPage.Name = "addPage";
            this.addPage.Padding = new System.Windows.Forms.Padding(3);
            this.addPage.Size = new System.Drawing.Size(427, 300);
            this.addPage.TabIndex = 1;
            this.addPage.Text = "Add";
            this.addPage.UseVisualStyleBackColor = true;
            // 
            // addTab_BrowseFolderButton
            // 
            this.addTab_BrowseFolderButton.Location = new System.Drawing.Point(90, 89);
            this.addTab_BrowseFolderButton.Name = "addTab_BrowseFolderButton";
            this.addTab_BrowseFolderButton.Size = new System.Drawing.Size(75, 23);
            this.addTab_BrowseFolderButton.TabIndex = 3;
            this.addTab_BrowseFolderButton.Text = "Folder...";
            this.addTab_BrowseFolderButton.UseVisualStyleBackColor = true;
            this.addTab_BrowseFolderButton.Click += new System.EventHandler(this.addTab_BrowseFolderButton_Click);
            // 
            // addTab_BrowseFileButton
            // 
            this.addTab_BrowseFileButton.Location = new System.Drawing.Point(9, 89);
            this.addTab_BrowseFileButton.Name = "addTab_BrowseFileButton";
            this.addTab_BrowseFileButton.Size = new System.Drawing.Size(75, 23);
            this.addTab_BrowseFileButton.TabIndex = 2;
            this.addTab_BrowseFileButton.Text = "File...";
            this.addTab_BrowseFileButton.UseVisualStyleBackColor = true;
            this.addTab_BrowseFileButton.Click += new System.EventHandler(this.addTab_BrowseFileButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(260, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Name (keyword that will launch the above command):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(318, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Command (Enter the full path of file or folder - exe, bat, folder, etc):";
            // 
            // addTab_AddButton
            // 
            this.addTab_AddButton.Enabled = false;
            this.addTab_AddButton.Location = new System.Drawing.Point(333, 178);
            this.addTab_AddButton.Name = "addTab_AddButton";
            this.addTab_AddButton.Size = new System.Drawing.Size(75, 23);
            this.addTab_AddButton.TabIndex = 5;
            this.addTab_AddButton.Text = "Add";
            this.addTab_AddButton.UseVisualStyleBackColor = true;
            this.addTab_AddButton.Click += new System.EventHandler(this.addTab_AddButton_Click);
            // 
            // addTab_RunCmdTextBox
            // 
            this.addTab_RunCmdTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addTab_RunCmdTextBox.Location = new System.Drawing.Point(9, 65);
            this.addTab_RunCmdTextBox.Name = "addTab_RunCmdTextBox";
            this.addTab_RunCmdTextBox.Size = new System.Drawing.Size(399, 18);
            this.addTab_RunCmdTextBox.TabIndex = 1;
            this.addTab_RunCmdTextBox.TextChanged += new System.EventHandler(this.addTab_RunCmdTextBox_TextChanged);
            // 
            // addTab_CmdNameTextBox
            // 
            this.addTab_CmdNameTextBox.Location = new System.Drawing.Point(9, 152);
            this.addTab_CmdNameTextBox.Name = "addTab_CmdNameTextBox";
            this.addTab_CmdNameTextBox.Size = new System.Drawing.Size(399, 20);
            this.addTab_CmdNameTextBox.TabIndex = 4;
            this.addTab_CmdNameTextBox.TextChanged += new System.EventHandler(this.addTab_CmdNameTextBox_TextChanged);
            // 
            // addLabel
            // 
            this.addLabel.AutoSize = true;
            this.addLabel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.addLabel.Location = new System.Drawing.Point(6, 15);
            this.addLabel.Name = "addLabel";
            this.addLabel.Size = new System.Drawing.Size(101, 13);
            this.addLabel.TabIndex = 0;
            this.addLabel.Text = "Add New Command";
            // 
            // editPage
            // 
            this.editPage.Controls.Add(this.editTab_BrowseFolderButton);
            this.editPage.Controls.Add(this.editTab_BrowseFileButton);
            this.editPage.Controls.Add(this.label3);
            this.editPage.Controls.Add(this.editTab_SaveButton);
            this.editPage.Controls.Add(this.instructLabel1);
            this.editPage.Controls.Add(this.editTab_RunCmdTextBox);
            this.editPage.Controls.Add(this.editTab_CmdListBox);
            this.editPage.Controls.Add(this.editLabel);
            this.editPage.Location = new System.Drawing.Point(4, 22);
            this.editPage.Name = "editPage";
            this.editPage.Padding = new System.Windows.Forms.Padding(3);
            this.editPage.Size = new System.Drawing.Size(427, 300);
            this.editPage.TabIndex = 0;
            this.editPage.Text = "Edit";
            this.editPage.UseVisualStyleBackColor = true;
            // 
            // editTab_BrowseFolderButton
            // 
            this.editTab_BrowseFolderButton.Location = new System.Drawing.Point(262, 105);
            this.editTab_BrowseFolderButton.Name = "editTab_BrowseFolderButton";
            this.editTab_BrowseFolderButton.Size = new System.Drawing.Size(75, 23);
            this.editTab_BrowseFolderButton.TabIndex = 4;
            this.editTab_BrowseFolderButton.Text = "Folder...";
            this.editTab_BrowseFolderButton.UseVisualStyleBackColor = true;
            this.editTab_BrowseFolderButton.Click += new System.EventHandler(this.editTab_BrowseFolderButton_Click);
            // 
            // editTab_BrowseFileButton
            // 
            this.editTab_BrowseFileButton.Location = new System.Drawing.Point(181, 105);
            this.editTab_BrowseFileButton.Name = "editTab_BrowseFileButton";
            this.editTab_BrowseFileButton.Size = new System.Drawing.Size(75, 23);
            this.editTab_BrowseFileButton.TabIndex = 3;
            this.editTab_BrowseFileButton.Text = "File...";
            this.editTab_BrowseFileButton.UseVisualStyleBackColor = true;
            this.editTab_BrowseFileButton.Click += new System.EventHandler(this.editTab_BrowseFileButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Command:";
            // 
            // editTab_SaveButton
            // 
            this.editTab_SaveButton.Location = new System.Drawing.Point(346, 105);
            this.editTab_SaveButton.Name = "editTab_SaveButton";
            this.editTab_SaveButton.Size = new System.Drawing.Size(75, 23);
            this.editTab_SaveButton.TabIndex = 5;
            this.editTab_SaveButton.Text = "Save";
            this.editTab_SaveButton.UseVisualStyleBackColor = true;
            this.editTab_SaveButton.Click += new System.EventHandler(this.editTab_SaveButton_Click);
            // 
            // instructLabel1
            // 
            this.instructLabel1.Location = new System.Drawing.Point(6, 31);
            this.instructLabel1.Margin = new System.Windows.Forms.Padding(3);
            this.instructLabel1.Name = "instructLabel1";
            this.instructLabel1.Size = new System.Drawing.Size(415, 31);
            this.instructLabel1.TabIndex = 3;
            this.instructLabel1.Text = "Click on the command you want to edit from the listbox.  Enter the new command in" +
    " the textbox below, and click Save.";
            // 
            // editTab_RunCmdTextBox
            // 
            this.editTab_RunCmdTextBox.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editTab_RunCmdTextBox.Location = new System.Drawing.Point(9, 81);
            this.editTab_RunCmdTextBox.Name = "editTab_RunCmdTextBox";
            this.editTab_RunCmdTextBox.Size = new System.Drawing.Size(412, 18);
            this.editTab_RunCmdTextBox.TabIndex = 2;
            this.editTab_RunCmdTextBox.TextChanged += new System.EventHandler(this.editTab_RunCmdTextBox_TextChanged);
            // 
            // editTab_CmdListBox
            // 
            this.editTab_CmdListBox.FormattingEnabled = true;
            this.editTab_CmdListBox.HorizontalScrollbar = true;
            this.editTab_CmdListBox.Location = new System.Drawing.Point(6, 145);
            this.editTab_CmdListBox.MultiColumn = true;
            this.editTab_CmdListBox.Name = "editTab_CmdListBox";
            this.editTab_CmdListBox.Size = new System.Drawing.Size(415, 147);
            this.editTab_CmdListBox.TabIndex = 1;
            this.editTab_CmdListBox.SelectedIndexChanged += new System.EventHandler(this.editTab_CmdListBox_SelectedIndexChanged);
            // 
            // editLabel
            // 
            this.editLabel.AutoSize = true;
            this.editLabel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.editLabel.Location = new System.Drawing.Point(6, 15);
            this.editLabel.Name = "editLabel";
            this.editLabel.Size = new System.Drawing.Size(126, 13);
            this.editLabel.TabIndex = 0;
            this.editLabel.Text = "Edit Available Commands";
            // 
            // removePage
            // 
            this.removePage.Controls.Add(this.label7);
            this.removePage.Controls.Add(this.removeTab_RemoveButton);
            this.removePage.Controls.Add(this.label10);
            this.removePage.Controls.Add(this.removeTab_RunCmdTextBox);
            this.removePage.Controls.Add(this.removeTab_CmdListBox);
            this.removePage.Controls.Add(this.label6);
            this.removePage.Location = new System.Drawing.Point(4, 22);
            this.removePage.Name = "removePage";
            this.removePage.Padding = new System.Windows.Forms.Padding(3);
            this.removePage.Size = new System.Drawing.Size(427, 300);
            this.removePage.TabIndex = 2;
            this.removePage.Text = "Remove";
            this.removePage.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Command:";
            // 
            // removeTab_RemoveButton
            // 
            this.removeTab_RemoveButton.Location = new System.Drawing.Point(346, 120);
            this.removeTab_RemoveButton.Name = "removeTab_RemoveButton";
            this.removeTab_RemoveButton.Size = new System.Drawing.Size(75, 23);
            this.removeTab_RemoveButton.TabIndex = 2;
            this.removeTab_RemoveButton.Text = "Remove";
            this.removeTab_RemoveButton.UseVisualStyleBackColor = true;
            this.removeTab_RemoveButton.Click += new System.EventHandler(this.removeTab_RemoveButton_Click);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(6, 31);
            this.label10.Margin = new System.Windows.Forms.Padding(3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(415, 39);
            this.label10.TabIndex = 8;
            this.label10.Text = "Click on the command you want to delete from the listbox.  Once you have verified" +
    " this is the command you want to remove, click Remove.";
            // 
            // removeTab_RunCmdTextBox
            // 
            this.removeTab_RunCmdTextBox.BackColor = System.Drawing.Color.LightGray;
            this.removeTab_RunCmdTextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.removeTab_RunCmdTextBox.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeTab_RunCmdTextBox.Location = new System.Drawing.Point(9, 96);
            this.removeTab_RunCmdTextBox.Name = "removeTab_RunCmdTextBox";
            this.removeTab_RunCmdTextBox.ReadOnly = true;
            this.removeTab_RunCmdTextBox.Size = new System.Drawing.Size(412, 18);
            this.removeTab_RunCmdTextBox.TabIndex = 2;
            this.removeTab_RunCmdTextBox.TabStop = false;
            // 
            // removeTab_CmdListBox
            // 
            this.removeTab_CmdListBox.FormattingEnabled = true;
            this.removeTab_CmdListBox.HorizontalScrollbar = true;
            this.removeTab_CmdListBox.Location = new System.Drawing.Point(9, 119);
            this.removeTab_CmdListBox.MultiColumn = true;
            this.removeTab_CmdListBox.Name = "removeTab_CmdListBox";
            this.removeTab_CmdListBox.Size = new System.Drawing.Size(331, 173);
            this.removeTab_CmdListBox.TabIndex = 1;
            this.removeTab_CmdListBox.SelectedIndexChanged += new System.EventHandler(this.removeTab_CmdListBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label6.Location = new System.Drawing.Point(6, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Remove a Command";
            // 
            // openFileAdd
            // 
            this.openFileAdd.Filter = "All files|*.*";
            // 
            // cmdMenu
            // 
            this.cmdMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.cmdMenu.Location = new System.Drawing.Point(0, 0);
            this.cmdMenu.Name = "cmdMenu";
            this.cmdMenu.Size = new System.Drawing.Size(356, 24);
            this.cmdMenu.TabIndex = 9;
            this.cmdMenu.Text = "menuStrip1";
            this.cmdMenu.Visible = false;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.editToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.addToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click_1);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.editToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // CommandManagerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 376);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.cmdTabControl);
            this.Controls.Add(this.cmdMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CommandManagerWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Command Manager";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.CommandManagerWindow_Shown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CommandManagerWindow_KeyPress);
            this.cmdTabControl.ResumeLayout(false);
            this.addPage.ResumeLayout(false);
            this.addPage.PerformLayout();
            this.editPage.ResumeLayout(false);
            this.editPage.PerformLayout();
            this.removePage.ResumeLayout(false);
            this.removePage.PerformLayout();
            this.cmdMenu.ResumeLayout(false);
            this.cmdMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.TabControl cmdTabControl;
        private System.Windows.Forms.TabPage editPage;
        private System.Windows.Forms.Button editTab_BrowseFileButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button editTab_SaveButton;
        private System.Windows.Forms.Label instructLabel1;
        private System.Windows.Forms.TextBox editTab_RunCmdTextBox;
        private System.Windows.Forms.ListBox editTab_CmdListBox;
        private System.Windows.Forms.Label editLabel;
        private System.Windows.Forms.TabPage addPage;
        private System.Windows.Forms.Button addTab_BrowseFileButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button addTab_AddButton;
        private System.Windows.Forms.TextBox addTab_RunCmdTextBox;
        private System.Windows.Forms.TextBox addTab_CmdNameTextBox;
        private System.Windows.Forms.Label addLabel;
        private System.Windows.Forms.TabPage removePage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button removeTab_RemoveButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox removeTab_RunCmdTextBox;
        private System.Windows.Forms.ListBox removeTab_CmdListBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog openFileEdit;
        private System.Windows.Forms.OpenFileDialog openFileAdd;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.Button addTab_BrowseFolderButton;
        private System.Windows.Forms.Button editTab_BrowseFolderButton;
        private System.Windows.Forms.MenuStrip cmdMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
    }
}