namespace CommandCentral.CC_UI
{
    partial class CommandCentralWindow
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommandCentralWindow));
            this.headerLabel = new System.Windows.Forms.Label();
            this.cmdsListPanel = new System.Windows.Forms.Panel();
            this.cmdsListTextArea = new System.Windows.Forms.TextBox();
            this.cmdsListLabel = new System.Windows.Forms.Label();
            this.cmdEntryDataGrid = new System.Windows.Forms.DataGridView();
            this.panelMainArea = new System.Windows.Forms.Panel();
            this.ccContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.commandsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdsListPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdEntryDataGrid)).BeginInit();
            this.panelMainArea.SuspendLayout();
            this.ccContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerLabel.Location = new System.Drawing.Point(0, 0);
            this.headerLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(396, 19);
            this.headerLabel.TabIndex = 99;
            this.headerLabel.Text = "Copyright (c) 2005 - 2016 RamiWare. All rights reserved.";
            // 
            // cmdsListPanel
            // 
            this.cmdsListPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdsListPanel.BackColor = System.Drawing.Color.Black;
            this.cmdsListPanel.Controls.Add(this.cmdsListTextArea);
            this.cmdsListPanel.Controls.Add(this.cmdsListLabel);
            this.cmdsListPanel.Location = new System.Drawing.Point(299, 3);
            this.cmdsListPanel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmdsListPanel.Name = "cmdsListPanel";
            this.cmdsListPanel.Size = new System.Drawing.Size(92, 341);
            this.cmdsListPanel.TabIndex = 2;
            // 
            // cmdsListTextArea
            // 
            this.cmdsListTextArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdsListTextArea.BackColor = System.Drawing.Color.Black;
            this.cmdsListTextArea.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cmdsListTextArea.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cmdsListTextArea.ForeColor = System.Drawing.Color.White;
            this.cmdsListTextArea.Location = new System.Drawing.Point(0, 19);
            this.cmdsListTextArea.Margin = new System.Windows.Forms.Padding(1);
            this.cmdsListTextArea.Multiline = true;
            this.cmdsListTextArea.Name = "cmdsListTextArea";
            this.cmdsListTextArea.ReadOnly = true;
            this.cmdsListTextArea.ShortcutsEnabled = false;
            this.cmdsListTextArea.Size = new System.Drawing.Size(91, 311);
            this.cmdsListTextArea.TabIndex = 99;
            this.cmdsListTextArea.TabStop = false;
            this.cmdsListTextArea.Enter += new System.EventHandler(this.cmdsListTextArea_Enter);
            // 
            // cmdsListLabel
            // 
            this.cmdsListLabel.BackColor = System.Drawing.Color.Black;
            this.cmdsListLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdsListLabel.Location = new System.Drawing.Point(0, 0);
            this.cmdsListLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cmdsListLabel.Name = "cmdsListLabel";
            this.cmdsListLabel.Size = new System.Drawing.Size(92, 18);
            this.cmdsListLabel.TabIndex = 99;
            this.cmdsListLabel.Text = "COMMANDS LIST";
            // 
            // cmdEntryDataGrid
            // 
            this.cmdEntryDataGrid.AllowUserToAddRows = false;
            this.cmdEntryDataGrid.AllowUserToDeleteRows = false;
            this.cmdEntryDataGrid.AllowUserToResizeColumns = false;
            this.cmdEntryDataGrid.AllowUserToResizeRows = false;
            this.cmdEntryDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdEntryDataGrid.BackgroundColor = System.Drawing.Color.Black;
            this.cmdEntryDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cmdEntryDataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.cmdEntryDataGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.cmdEntryDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cmdEntryDataGrid.ColumnHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.cmdEntryDataGrid.DefaultCellStyle = dataGridViewCellStyle6;
            this.cmdEntryDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.cmdEntryDataGrid.GridColor = System.Drawing.Color.Yellow;
            this.cmdEntryDataGrid.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmdEntryDataGrid.Location = new System.Drawing.Point(0, 0);
            this.cmdEntryDataGrid.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmdEntryDataGrid.MultiSelect = false;
            this.cmdEntryDataGrid.Name = "cmdEntryDataGrid";
            this.cmdEntryDataGrid.RowHeadersVisible = false;
            this.cmdEntryDataGrid.RowTemplate.Height = 23;
            this.cmdEntryDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.cmdEntryDataGrid.Size = new System.Drawing.Size(298, 342);
            this.cmdEntryDataGrid.TabIndex = 0;
            this.cmdEntryDataGrid.TabStop = false;
            this.cmdEntryDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cmdEntryDataGrid_CellClick);
            // 
            // panelMainArea
            // 
            this.panelMainArea.BackColor = System.Drawing.Color.Black;
            this.panelMainArea.Controls.Add(this.cmdEntryDataGrid);
            this.panelMainArea.Controls.Add(this.cmdsListPanel);
            this.panelMainArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainArea.Location = new System.Drawing.Point(0, 19);
            this.panelMainArea.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelMainArea.Name = "panelMainArea";
            this.panelMainArea.Size = new System.Drawing.Size(396, 342);
            this.panelMainArea.TabIndex = 100;
            // 
            // ccContextMenuStrip
            // 
            this.ccContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commandsMenuItem,
            this.customizeMenuItem,
            this.exitMenuItem});
            this.ccContextMenuStrip.Name = "cmdBoxMenu";
            this.ccContextMenuStrip.Size = new System.Drawing.Size(137, 70);
            // 
            // commandsMenuItem
            // 
            this.commandsMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("commandsMenuItem.Image")));
            this.commandsMenuItem.Name = "commandsMenuItem";
            this.commandsMenuItem.Size = new System.Drawing.Size(136, 22);
            this.commandsMenuItem.Text = "Commands";
            this.commandsMenuItem.Click += new System.EventHandler(this.commandsMenuItem_Click);
            // 
            // customizeMenuItem
            // 
            this.customizeMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("customizeMenuItem.Image")));
            this.customizeMenuItem.Name = "customizeMenuItem";
            this.customizeMenuItem.Size = new System.Drawing.Size(136, 22);
            this.customizeMenuItem.Text = "Customize";
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitMenuItem.Image")));
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(136, 22);
            this.exitMenuItem.Text = "Exit";
            // 
            // CommandCentralWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(396, 361);
            this.Controls.Add(this.panelMainArea);
            this.Controls.Add(this.headerLabel);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MinimumSize = new System.Drawing.Size(412, 399);
            this.Name = "CommandCentralWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Command Central 4.0";
            this.Shown += new System.EventHandler(this.CommandCentralWindow_Shown);
            this.cmdsListPanel.ResumeLayout(false);
            this.cmdsListPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdEntryDataGrid)).EndInit();
            this.panelMainArea.ResumeLayout(false);
            this.ccContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Panel cmdsListPanel;
        private System.Windows.Forms.Label cmdsListLabel;
        private System.Windows.Forms.TextBox cmdsListTextArea;
        private System.Windows.Forms.DataGridView cmdEntryDataGrid;
        private System.Windows.Forms.Panel panelMainArea;
        private System.Windows.Forms.ContextMenuStrip ccContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem commandsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customizeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
    }
}

