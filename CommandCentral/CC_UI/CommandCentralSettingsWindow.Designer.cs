namespace CommandCentral.CC_UI
{
    partial class CommandCentralSettingsWindow
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
            this.closeButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.labelTitleAppearance = new System.Windows.Forms.Label();
            this.topMostComboBox = new System.Windows.Forms.ComboBox();
            this.instructLabel = new System.Windows.Forms.Label();
            this.topMostLabel = new System.Windows.Forms.Label();
            this.transparencyUserValue = new System.Windows.Forms.NumericUpDown();
            this.transparencyLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.ramThresholdLevel2Control = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.ramThresholdLevel1Control = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.cpuThresholdLevel2Control = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTitlePerformance = new System.Windows.Forms.Label();
            this.cpuThresholdLevel1Control = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.transparencyUserValue)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ramThresholdLevel2Control)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ramThresholdLevel1Control)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpuThresholdLevel2Control)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpuThresholdLevel1Control)).BeginInit();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(254, 295);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 10;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(173, 295);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // labelTitleAppearance
            // 
            this.labelTitleAppearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
            this.labelTitleAppearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleAppearance.ForeColor = System.Drawing.Color.White;
            this.labelTitleAppearance.Location = new System.Drawing.Point(1, 1);
            this.labelTitleAppearance.Name = "labelTitleAppearance";
            this.labelTitleAppearance.Size = new System.Drawing.Size(321, 21);
            this.labelTitleAppearance.TabIndex = 17;
            this.labelTitleAppearance.Text = "Appearance";
            this.labelTitleAppearance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // topMostComboBox
            // 
            this.topMostComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.topMostComboBox.FormattingEnabled = true;
            this.topMostComboBox.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.topMostComboBox.Location = new System.Drawing.Point(162, 47);
            this.topMostComboBox.Name = "topMostComboBox";
            this.topMostComboBox.Size = new System.Drawing.Size(121, 21);
            this.topMostComboBox.TabIndex = 16;
            this.topMostComboBox.SelectedValueChanged += new System.EventHandler(this.topMostComboBox_SelectedIndexChanged);
            // 
            // instructLabel
            // 
            this.instructLabel.AutoSize = true;
            this.instructLabel.ForeColor = System.Drawing.Color.White;
            this.instructLabel.Location = new System.Drawing.Point(6, 17);
            this.instructLabel.Name = "instructLabel";
            this.instructLabel.Size = new System.Drawing.Size(255, 13);
            this.instructLabel.TabIndex = 12;
            this.instructLabel.Text = "Make your selections, and click Save when finished.";
            // 
            // topMostLabel
            // 
            this.topMostLabel.AutoSize = true;
            this.topMostLabel.Location = new System.Drawing.Point(159, 31);
            this.topMostLabel.Name = "topMostLabel";
            this.topMostLabel.Size = new System.Drawing.Size(55, 13);
            this.topMostLabel.TabIndex = 15;
            this.topMostLabel.Text = "Top Most:";
            // 
            // transparencyUserValue
            // 
            this.transparencyUserValue.BackColor = System.Drawing.SystemColors.Window;
            this.transparencyUserValue.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.transparencyUserValue.Location = new System.Drawing.Point(18, 47);
            this.transparencyUserValue.Maximum = new decimal(new int[] {
            95,
            0,
            0,
            0});
            this.transparencyUserValue.Name = "transparencyUserValue";
            this.transparencyUserValue.ReadOnly = true;
            this.transparencyUserValue.Size = new System.Drawing.Size(120, 20);
            this.transparencyUserValue.TabIndex = 14;
            this.transparencyUserValue.ValueChanged += new System.EventHandler(this.transparencyUserValue_ValueChanged);
            // 
            // transparencyLabel
            // 
            this.transparencyLabel.AutoSize = true;
            this.transparencyLabel.Location = new System.Drawing.Point(14, 31);
            this.transparencyLabel.Name = "transparencyLabel";
            this.transparencyLabel.Size = new System.Drawing.Size(75, 13);
            this.transparencyLabel.TabIndex = 13;
            this.transparencyLabel.Text = "Transparency:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.transparencyLabel);
            this.panel1.Controls.Add(this.labelTitleAppearance);
            this.panel1.Controls.Add(this.transparencyUserValue);
            this.panel1.Controls.Add(this.topMostComboBox);
            this.panel1.Controls.Add(this.topMostLabel);
            this.panel1.Location = new System.Drawing.Point(7, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(325, 89);
            this.panel1.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.ramThresholdLevel2Control);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.ramThresholdLevel1Control);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cpuThresholdLevel2Control);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.labelTitlePerformance);
            this.panel2.Controls.Add(this.cpuThresholdLevel1Control);
            this.panel2.Location = new System.Drawing.Point(7, 140);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(325, 146);
            this.panel2.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(159, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "RAM Threshold Level2:";
            // 
            // ramThresholdLevel2Control
            // 
            this.ramThresholdLevel2Control.BackColor = System.Drawing.SystemColors.Window;
            this.ramThresholdLevel2Control.DecimalPlaces = 1;
            this.ramThresholdLevel2Control.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.ramThresholdLevel2Control.Location = new System.Drawing.Point(163, 101);
            this.ramThresholdLevel2Control.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.ramThresholdLevel2Control.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.ramThresholdLevel2Control.Name = "ramThresholdLevel2Control";
            this.ramThresholdLevel2Control.ReadOnly = true;
            this.ramThresholdLevel2Control.Size = new System.Drawing.Size(120, 20);
            this.ramThresholdLevel2Control.TabIndex = 23;
            this.ramThresholdLevel2Control.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "RAM Threshold Level1:";
            // 
            // ramThresholdLevel1Control
            // 
            this.ramThresholdLevel1Control.BackColor = System.Drawing.SystemColors.Window;
            this.ramThresholdLevel1Control.DecimalPlaces = 1;
            this.ramThresholdLevel1Control.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.ramThresholdLevel1Control.Location = new System.Drawing.Point(18, 101);
            this.ramThresholdLevel1Control.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.ramThresholdLevel1Control.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.ramThresholdLevel1Control.Name = "ramThresholdLevel1Control";
            this.ramThresholdLevel1Control.ReadOnly = true;
            this.ramThresholdLevel1Control.Size = new System.Drawing.Size(120, 20);
            this.ramThresholdLevel1Control.TabIndex = 21;
            this.ramThresholdLevel1Control.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "CPU Threshold Level2:";
            // 
            // cpuThresholdLevel2Control
            // 
            this.cpuThresholdLevel2Control.BackColor = System.Drawing.SystemColors.Window;
            this.cpuThresholdLevel2Control.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.cpuThresholdLevel2Control.Location = new System.Drawing.Point(163, 47);
            this.cpuThresholdLevel2Control.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.cpuThresholdLevel2Control.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.cpuThresholdLevel2Control.Name = "cpuThresholdLevel2Control";
            this.cpuThresholdLevel2Control.ReadOnly = true;
            this.cpuThresholdLevel2Control.Size = new System.Drawing.Size(120, 20);
            this.cpuThresholdLevel2Control.TabIndex = 19;
            this.cpuThresholdLevel2Control.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "CPU Threshold Level1:";
            // 
            // labelTitlePerformance
            // 
            this.labelTitlePerformance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
            this.labelTitlePerformance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitlePerformance.ForeColor = System.Drawing.Color.White;
            this.labelTitlePerformance.Location = new System.Drawing.Point(1, 1);
            this.labelTitlePerformance.Name = "labelTitlePerformance";
            this.labelTitlePerformance.Size = new System.Drawing.Size(321, 21);
            this.labelTitlePerformance.TabIndex = 17;
            this.labelTitlePerformance.Text = "Performance Monitoring Notification";
            this.labelTitlePerformance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cpuThresholdLevel1Control
            // 
            this.cpuThresholdLevel1Control.BackColor = System.Drawing.SystemColors.Window;
            this.cpuThresholdLevel1Control.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.cpuThresholdLevel1Control.Location = new System.Drawing.Point(18, 47);
            this.cpuThresholdLevel1Control.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.cpuThresholdLevel1Control.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.cpuThresholdLevel1Control.Name = "cpuThresholdLevel1Control";
            this.cpuThresholdLevel1Control.ReadOnly = true;
            this.cpuThresholdLevel1Control.Size = new System.Drawing.Size(120, 20);
            this.cpuThresholdLevel1Control.TabIndex = 14;
            this.cpuThresholdLevel1Control.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // CommandCentralSettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(338, 327);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.instructLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.closeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CommandCentralSettingsWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Command Central Settings Window";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CommandCentralSettingsWindow_FormClosing);
            this.Shown += new System.EventHandler(this.CommandCentralSettingsWindow_Shown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CommandCentralSettingsWindow_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.transparencyUserValue)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ramThresholdLevel2Control)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ramThresholdLevel1Control)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpuThresholdLevel2Control)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpuThresholdLevel1Control)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label labelTitleAppearance;
        private System.Windows.Forms.ComboBox topMostComboBox;
        private System.Windows.Forms.Label instructLabel;
        private System.Windows.Forms.Label topMostLabel;
        private System.Windows.Forms.NumericUpDown transparencyUserValue;
        private System.Windows.Forms.Label transparencyLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTitlePerformance;
        private System.Windows.Forms.NumericUpDown cpuThresholdLevel1Control;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown ramThresholdLevel2Control;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown ramThresholdLevel1Control;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown cpuThresholdLevel2Control;
    }
}