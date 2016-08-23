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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommandCentralWindow));
            this.headerLabel = new System.Windows.Forms.Label();
            this.cmdsListPanel = new System.Windows.Forms.Panel();
            this.cmdsListTextArea = new System.Windows.Forms.TextBox();
            this.cmdsListLabel = new System.Windows.Forms.Label();
            this.cmdEntryDataGrid = new System.Windows.Forms.DataGridView();
            this.panelMainArea = new System.Windows.Forms.Panel();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.footerLabelRAMValue = new System.Windows.Forms.Label();
            this.footerLabelRAMTitle = new System.Windows.Forms.Label();
            this.footerLabelCPUValue = new System.Windows.Forms.Label();
            this.footerLabelCPUTitle = new System.Windows.Forms.Label();
            this.ccContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.commandsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.footerLabelProcessesValue = new System.Windows.Forms.Label();
            this.footerLabelProcessesTitle = new System.Windows.Forms.Label();
            this.cmdsListPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdEntryDataGrid)).BeginInit();
            this.panelMainArea.SuspendLayout();
            this.footerPanel.SuspendLayout();
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
            this.cmdsListPanel.Size = new System.Drawing.Size(92, 310);
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
            this.cmdsListTextArea.Size = new System.Drawing.Size(91, 280);
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.cmdEntryDataGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.cmdEntryDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.cmdEntryDataGrid.GridColor = System.Drawing.Color.Yellow;
            this.cmdEntryDataGrid.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmdEntryDataGrid.Location = new System.Drawing.Point(0, 0);
            this.cmdEntryDataGrid.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmdEntryDataGrid.MultiSelect = false;
            this.cmdEntryDataGrid.Name = "cmdEntryDataGrid";
            this.cmdEntryDataGrid.RowHeadersVisible = false;
            this.cmdEntryDataGrid.RowTemplate.Height = 23;
            this.cmdEntryDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.cmdEntryDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.cmdEntryDataGrid.Size = new System.Drawing.Size(298, 313);
            this.cmdEntryDataGrid.TabIndex = 0;
            this.cmdEntryDataGrid.TabStop = false;
            this.cmdEntryDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cmdEntryDataGrid_CellClick);
            this.cmdEntryDataGrid.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.cmdEntryDataGrid_CellEnter);
            // 
            // panelMainArea
            // 
            this.panelMainArea.BackColor = System.Drawing.Color.Black;
            this.panelMainArea.Controls.Add(this.footerPanel);
            this.panelMainArea.Controls.Add(this.cmdsListPanel);
            this.panelMainArea.Controls.Add(this.cmdEntryDataGrid);
            this.panelMainArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainArea.Location = new System.Drawing.Point(0, 19);
            this.panelMainArea.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelMainArea.Name = "panelMainArea";
            this.panelMainArea.Size = new System.Drawing.Size(396, 342);
            this.panelMainArea.TabIndex = 100;
            // 
            // footerPanel
            // 
            this.footerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.footerPanel.Controls.Add(this.footerLabelProcessesValue);
            this.footerPanel.Controls.Add(this.footerLabelProcessesTitle);
            this.footerPanel.Controls.Add(this.footerLabelRAMValue);
            this.footerPanel.Controls.Add(this.footerLabelRAMTitle);
            this.footerPanel.Controls.Add(this.footerLabelCPUValue);
            this.footerPanel.Controls.Add(this.footerLabelCPUTitle);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 319);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(396, 23);
            this.footerPanel.TabIndex = 100;
            // 
            // footerLabelRAMValue
            // 
            this.footerLabelRAMValue.Location = new System.Drawing.Point(323, 5);
            this.footerLabelRAMValue.Name = "footerLabelRAMValue";
            this.footerLabelRAMValue.Size = new System.Drawing.Size(61, 13);
            this.footerLabelRAMValue.TabIndex = 3;
            this.footerLabelRAMValue.Text = "10.36 GB";
            // 
            // footerLabelRAMTitle
            // 
            this.footerLabelRAMTitle.AutoSize = true;
            this.footerLabelRAMTitle.Location = new System.Drawing.Point(217, 5);
            this.footerLabelRAMTitle.Name = "footerLabelRAMTitle";
            this.footerLabelRAMTitle.Size = new System.Drawing.Size(109, 13);
            this.footerLabelRAMTitle.TabIndex = 2;
            this.footerLabelRAMTitle.Text = "Available Memory:";
            // 
            // footerLabelCPUValue
            // 
            this.footerLabelCPUValue.Location = new System.Drawing.Point(176, 5);
            this.footerLabelCPUValue.Name = "footerLabelCPUValue";
            this.footerLabelCPUValue.Size = new System.Drawing.Size(35, 13);
            this.footerLabelCPUValue.TabIndex = 1;
            this.footerLabelCPUValue.Text = "100%";
            // 
            // footerLabelCPUTitle
            // 
            this.footerLabelCPUTitle.AutoSize = true;
            this.footerLabelCPUTitle.Location = new System.Drawing.Point(112, 5);
            this.footerLabelCPUTitle.Name = "footerLabelCPUTitle";
            this.footerLabelCPUTitle.Size = new System.Drawing.Size(67, 13);
            this.footerLabelCPUTitle.TabIndex = 0;
            this.footerLabelCPUTitle.Text = "CPU Usage:";
            // 
            // ccContextMenuStrip
            // 
            this.ccContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commandsMenuItem,
            this.customizeMenuItem,
            this.exitMenuItem});
            this.ccContextMenuStrip.Name = "cmdBoxMenu";
            this.ccContextMenuStrip.Size = new System.Drawing.Size(153, 92);
            // 
            // commandsMenuItem
            // 
            this.commandsMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("commandsMenuItem.Image")));
            this.commandsMenuItem.Name = "commandsMenuItem";
            this.commandsMenuItem.Size = new System.Drawing.Size(152, 22);
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
            this.exitMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // footerLabelProcessesValue
            // 
            this.footerLabelProcessesValue.Location = new System.Drawing.Point(70, 5);
            this.footerLabelProcessesValue.Name = "footerLabelProcessesValue";
            this.footerLabelProcessesValue.Size = new System.Drawing.Size(30, 13);
            this.footerLabelProcessesValue.TabIndex = 5;
            this.footerLabelProcessesValue.Text = "100";
            // 
            // footerLabelProcessesTitle
            // 
            this.footerLabelProcessesTitle.AutoSize = true;
            this.footerLabelProcessesTitle.Location = new System.Drawing.Point(6, 5);
            this.footerLabelProcessesTitle.Name = "footerLabelProcessesTitle";
            this.footerLabelProcessesTitle.Size = new System.Drawing.Size(67, 13);
            this.footerLabelProcessesTitle.TabIndex = 4;
            this.footerLabelProcessesTitle.Text = "Processes:";
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
            this.footerPanel.ResumeLayout(false);
            this.footerPanel.PerformLayout();
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
        private System.Windows.Forms.Panel footerPanel;
        private System.Windows.Forms.Label footerLabelRAMValue;
        private System.Windows.Forms.Label footerLabelRAMTitle;
        private System.Windows.Forms.Label footerLabelCPUValue;
        private System.Windows.Forms.Label footerLabelCPUTitle;
        private System.Windows.Forms.Label footerLabelProcessesValue;
        private System.Windows.Forms.Label footerLabelProcessesTitle;
    }
}

