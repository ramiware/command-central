﻿namespace CommandCentral.CC_UI
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommandCentralWindow));
            this.headerLabel = new System.Windows.Forms.Label();
            this.cmdsListPanel = new System.Windows.Forms.Panel();
            this.cmdsListLabel = new System.Windows.Forms.Label();
            this.cmdsListTextArea = new System.Windows.Forms.TextBox();
            this.cmdEntryDataGrid = new System.Windows.Forms.DataGridView();
            this.panelMainArea = new System.Windows.Forms.Panel();
            this.panelScannerDisplay = new System.Windows.Forms.Panel();
            this.labelUsername = new System.Windows.Forms.Label();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.footerLabelProcessesValue = new System.Windows.Forms.Label();
            this.footerLabelProcessesTitle = new System.Windows.Forms.Label();
            this.footerLabelRAMValue = new System.Windows.Forms.Label();
            this.footerLabelRAMTitle = new System.Windows.Forms.Label();
            this.footerLabelCPUValue = new System.Windows.Forms.Label();
            this.footerLabelCPUTitle = new System.Windows.Forms.Label();
            this.ccContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.commandsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.headerLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.Location = new System.Drawing.Point(0, 0);
            this.headerLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(534, 19);
            this.headerLabel.TabIndex = 99;
            this.headerLabel.Text = "Copyright (c) 2005 - 2017 Ramiware. All rights reserved.";
            // 
            // cmdsListPanel
            // 
            this.cmdsListPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdsListPanel.BackColor = System.Drawing.Color.Black;
            this.cmdsListPanel.Controls.Add(this.cmdsListLabel);
            this.cmdsListPanel.Controls.Add(this.cmdsListTextArea);
            this.cmdsListPanel.Location = new System.Drawing.Point(437, 3);
            this.cmdsListPanel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmdsListPanel.Name = "cmdsListPanel";
            this.cmdsListPanel.Size = new System.Drawing.Size(92, 401);
            this.cmdsListPanel.TabIndex = 2;
            // 
            // cmdsListLabel
            // 
            this.cmdsListLabel.BackColor = System.Drawing.Color.Black;
            this.cmdsListLabel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdsListLabel.Location = new System.Drawing.Point(0, 0);
            this.cmdsListLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cmdsListLabel.Name = "cmdsListLabel";
            this.cmdsListLabel.Size = new System.Drawing.Size(92, 18);
            this.cmdsListLabel.TabIndex = 99;
            this.cmdsListLabel.Text = "COMMANDS";
            // 
            // cmdsListTextArea
            // 
            this.cmdsListTextArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdsListTextArea.BackColor = System.Drawing.Color.Black;
            this.cmdsListTextArea.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cmdsListTextArea.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cmdsListTextArea.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdsListTextArea.ForeColor = System.Drawing.Color.White;
            this.cmdsListTextArea.Location = new System.Drawing.Point(0, 19);
            this.cmdsListTextArea.Margin = new System.Windows.Forms.Padding(1);
            this.cmdsListTextArea.Multiline = true;
            this.cmdsListTextArea.Name = "cmdsListTextArea";
            this.cmdsListTextArea.ReadOnly = true;
            this.cmdsListTextArea.ShortcutsEnabled = false;
            this.cmdsListTextArea.Size = new System.Drawing.Size(91, 361);
            this.cmdsListTextArea.TabIndex = 99;
            this.cmdsListTextArea.TabStop = false;
            this.cmdsListTextArea.Enter += new System.EventHandler(this.cmdsListTextArea_Enter);
            this.cmdsListTextArea.MouseLeave += new System.EventHandler(this.cmdsListTextArea_MouseLeave);
            this.cmdsListTextArea.MouseHover += new System.EventHandler(this.cmdsListTextArea_MouseHover);
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
            this.cmdEntryDataGrid.Cursor = System.Windows.Forms.Cursors.IBeam;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.cmdEntryDataGrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.cmdEntryDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.cmdEntryDataGrid.GridColor = System.Drawing.Color.Yellow;
            this.cmdEntryDataGrid.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmdEntryDataGrid.Location = new System.Drawing.Point(0, 22);
            this.cmdEntryDataGrid.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmdEntryDataGrid.MultiSelect = false;
            this.cmdEntryDataGrid.Name = "cmdEntryDataGrid";
            this.cmdEntryDataGrid.RowHeadersVisible = false;
            this.cmdEntryDataGrid.RowTemplate.Height = 23;
            this.cmdEntryDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.cmdEntryDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.cmdEntryDataGrid.Size = new System.Drawing.Size(436, 382);
            this.cmdEntryDataGrid.TabIndex = 0;
            this.cmdEntryDataGrid.TabStop = false;
            this.cmdEntryDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cmdEntryDataGrid_CellClick);
            this.cmdEntryDataGrid.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.cmdEntryDataGrid_CellEnter);
            // 
            // panelMainArea
            // 
            this.panelMainArea.BackColor = System.Drawing.Color.Black;
            this.panelMainArea.Controls.Add(this.panelScannerDisplay);
            this.panelMainArea.Controls.Add(this.labelUsername);
            this.panelMainArea.Controls.Add(this.footerPanel);
            this.panelMainArea.Controls.Add(this.cmdsListPanel);
            this.panelMainArea.Controls.Add(this.cmdEntryDataGrid);
            this.panelMainArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainArea.Location = new System.Drawing.Point(0, 19);
            this.panelMainArea.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelMainArea.Name = "panelMainArea";
            this.panelMainArea.Size = new System.Drawing.Size(534, 443);
            this.panelMainArea.TabIndex = 100;
            // 
            // panelScannerDisplay
            // 
            this.panelScannerDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelScannerDisplay.BackColor = System.Drawing.Color.Transparent;
            this.panelScannerDisplay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelScannerDisplay.BackgroundImage")));
            this.panelScannerDisplay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelScannerDisplay.Location = new System.Drawing.Point(0, 405);
            this.panelScannerDisplay.Name = "panelScannerDisplay";
            this.panelScannerDisplay.Size = new System.Drawing.Size(128, 15);
            this.panelScannerDisplay.TabIndex = 102;
            this.panelScannerDisplay.Visible = false;
            // 
            // labelUsername
            // 
            this.labelUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelUsername.BackColor = System.Drawing.Color.Black;
            this.labelUsername.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsername.Location = new System.Drawing.Point(0, 3);
            this.labelUsername.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.labelUsername.Size = new System.Drawing.Size(436, 18);
            this.labelUsername.TabIndex = 101;
            this.labelUsername.Text = "USERID";
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
            this.footerPanel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.footerPanel.Location = new System.Drawing.Point(0, 420);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(534, 23);
            this.footerPanel.TabIndex = 100;
            // 
            // footerLabelProcessesValue
            // 
            this.footerLabelProcessesValue.Location = new System.Drawing.Point(66, 4);
            this.footerLabelProcessesValue.Name = "footerLabelProcessesValue";
            this.footerLabelProcessesValue.Size = new System.Drawing.Size(30, 13);
            this.footerLabelProcessesValue.TabIndex = 5;
            this.footerLabelProcessesValue.Text = "100";
            this.footerLabelProcessesValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // footerLabelProcessesTitle
            // 
            this.footerLabelProcessesTitle.AutoSize = true;
            this.footerLabelProcessesTitle.Location = new System.Drawing.Point(6, 5);
            this.footerLabelProcessesTitle.Name = "footerLabelProcessesTitle";
            this.footerLabelProcessesTitle.Size = new System.Drawing.Size(58, 13);
            this.footerLabelProcessesTitle.TabIndex = 4;
            this.footerLabelProcessesTitle.Text = "Processes:";
            // 
            // footerLabelRAMValue
            // 
            this.footerLabelRAMValue.Location = new System.Drawing.Point(315, 4);
            this.footerLabelRAMValue.Name = "footerLabelRAMValue";
            this.footerLabelRAMValue.Size = new System.Drawing.Size(61, 13);
            this.footerLabelRAMValue.TabIndex = 3;
            this.footerLabelRAMValue.Text = "10.36 GB";
            this.footerLabelRAMValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // footerLabelRAMTitle
            // 
            this.footerLabelRAMTitle.AutoSize = true;
            this.footerLabelRAMTitle.Location = new System.Drawing.Point(217, 5);
            this.footerLabelRAMTitle.Name = "footerLabelRAMTitle";
            this.footerLabelRAMTitle.Size = new System.Drawing.Size(95, 13);
            this.footerLabelRAMTitle.TabIndex = 2;
            this.footerLabelRAMTitle.Text = "Available Memory:";
            // 
            // footerLabelCPUValue
            // 
            this.footerLabelCPUValue.ForeColor = System.Drawing.Color.White;
            this.footerLabelCPUValue.Location = new System.Drawing.Point(172, 4);
            this.footerLabelCPUValue.Name = "footerLabelCPUValue";
            this.footerLabelCPUValue.Size = new System.Drawing.Size(35, 13);
            this.footerLabelCPUValue.TabIndex = 1;
            this.footerLabelCPUValue.Text = "100%";
            this.footerLabelCPUValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // footerLabelCPUTitle
            // 
            this.footerLabelCPUTitle.AutoSize = true;
            this.footerLabelCPUTitle.Location = new System.Drawing.Point(112, 5);
            this.footerLabelCPUTitle.Name = "footerLabelCPUTitle";
            this.footerLabelCPUTitle.Size = new System.Drawing.Size(60, 13);
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
            this.customizeMenuItem.Click += new System.EventHandler(this.customizeMenuItem_Click);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitMenuItem.Image")));
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(136, 22);
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // CommandCentralWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(534, 462);
            this.Controls.Add(this.panelMainArea);
            this.Controls.Add(this.headerLabel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(412, 399);
            this.Name = "CommandCentralWindow";
            this.Opacity = 0.8D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CommandCentralWindow_FormClosing);
            this.Shown += new System.EventHandler(this.CommandCentralWindow_Shown);
            this.LocationChanged += new System.EventHandler(this.CommandCentralWindow_LocationChanged);
            this.SizeChanged += new System.EventHandler(this.CommandCentralWindow_SizeChanged);
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
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Panel panelScannerDisplay;
    }
}

