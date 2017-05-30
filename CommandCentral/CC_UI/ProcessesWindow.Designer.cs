namespace CommandCentral.CC_UI
{
    partial class ProcessesWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.processesDataGrid = new System.Windows.Forms.DataGridView();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.footerLabelProcessesValue = new System.Windows.Forms.Label();
            this.footerLabelProcessesTitle = new System.Windows.Forms.Label();
            this.footerLabelRAMValue = new System.Windows.Forms.Label();
            this.footerLabelRAMTitle = new System.Windows.Forms.Label();
            this.footerLabelCPUValue = new System.Windows.Forms.Label();
            this.footerLabelCPUTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.processesDataGrid)).BeginInit();
            this.footerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // processesDataGrid
            // 
            this.processesDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.processesDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.processesDataGrid.BackgroundColor = System.Drawing.Color.Black;
            this.processesDataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.processesDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.processesDataGrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.processesDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.processesDataGrid.GridColor = System.Drawing.Color.Black;
            this.processesDataGrid.Location = new System.Drawing.Point(0, 0);
            this.processesDataGrid.MultiSelect = false;
            this.processesDataGrid.Name = "processesDataGrid";
            this.processesDataGrid.ReadOnly = true;
            this.processesDataGrid.RowHeadersVisible = false;
            this.processesDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.processesDataGrid.Size = new System.Drawing.Size(372, 465);
            this.processesDataGrid.TabIndex = 0;
            this.processesDataGrid.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.processesDataGrid_CellMouseDown);
            // 
            // footerPanel
            // 
            this.footerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.footerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.footerPanel.Controls.Add(this.footerLabelProcessesValue);
            this.footerPanel.Controls.Add(this.footerLabelProcessesTitle);
            this.footerPanel.Controls.Add(this.footerLabelRAMValue);
            this.footerPanel.Controls.Add(this.footerLabelRAMTitle);
            this.footerPanel.Controls.Add(this.footerLabelCPUValue);
            this.footerPanel.Controls.Add(this.footerLabelCPUTitle);
            this.footerPanel.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.footerPanel.ForeColor = System.Drawing.Color.White;
            this.footerPanel.Location = new System.Drawing.Point(0, 463);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(372, 23);
            this.footerPanel.TabIndex = 101;
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
            // ProcessesWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 486);
            this.Controls.Add(this.footerPanel);
            this.Controls.Add(this.processesDataGrid);
            this.MinimumSize = new System.Drawing.Size(388, 459);
            this.Name = "ProcessesWindow";
            this.ShowIcon = false;
            this.Text = "Processes";
            ((System.ComponentModel.ISupportInitialize)(this.processesDataGrid)).EndInit();
            this.footerPanel.ResumeLayout(false);
            this.footerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView processesDataGrid;
        private System.Windows.Forms.Panel footerPanel;
        private System.Windows.Forms.Label footerLabelProcessesValue;
        private System.Windows.Forms.Label footerLabelProcessesTitle;
        private System.Windows.Forms.Label footerLabelRAMValue;
        private System.Windows.Forms.Label footerLabelRAMTitle;
        private System.Windows.Forms.Label footerLabelCPUValue;
        private System.Windows.Forms.Label footerLabelCPUTitle;
    }
}