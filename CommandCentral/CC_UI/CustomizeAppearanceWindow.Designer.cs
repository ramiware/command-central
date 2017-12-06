namespace CommandCentral.CC_UI
{
    partial class CustomizeAppearanceWindow
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
            this.colourBox = new System.Windows.Forms.GroupBox();
            this.topMostComboBox = new System.Windows.Forms.ComboBox();
            this.topMostLabel = new System.Windows.Forms.Label();
            this.transparencyUserValue = new System.Windows.Forms.NumericUpDown();
            this.transparencyLabel = new System.Windows.Forms.Label();
            this.applyButton = new System.Windows.Forms.Button();
            this.instructLabel = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colourBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transparencyUserValue)).BeginInit();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(244, 152);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 10;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // colourBox
            // 
            this.colourBox.Controls.Add(this.topMostComboBox);
            this.colourBox.Controls.Add(this.topMostLabel);
            this.colourBox.Controls.Add(this.transparencyUserValue);
            this.colourBox.Controls.Add(this.transparencyLabel);
            this.colourBox.Location = new System.Drawing.Point(16, 47);
            this.colourBox.Name = "colourBox";
            this.colourBox.Size = new System.Drawing.Size(303, 99);
            this.colourBox.TabIndex = 8;
            this.colourBox.TabStop = false;
            this.colourBox.Text = "Settings";
            // 
            // topMostComboBox
            // 
            this.topMostComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.topMostComboBox.FormattingEnabled = true;
            this.topMostComboBox.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.topMostComboBox.Location = new System.Drawing.Point(159, 48);
            this.topMostComboBox.Name = "topMostComboBox";
            this.topMostComboBox.Size = new System.Drawing.Size(121, 21);
            this.topMostComboBox.TabIndex = 10;
            this.topMostComboBox.SelectedIndexChanged += new System.EventHandler(this.topMostComboBox_SelectedIndexChanged);
            // 
            // topMostLabel
            // 
            this.topMostLabel.AutoSize = true;
            this.topMostLabel.Location = new System.Drawing.Point(156, 32);
            this.topMostLabel.Name = "topMostLabel";
            this.topMostLabel.Size = new System.Drawing.Size(55, 13);
            this.topMostLabel.TabIndex = 9;
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
            this.transparencyUserValue.Location = new System.Drawing.Point(15, 48);
            this.transparencyUserValue.Maximum = new decimal(new int[] {
            95,
            0,
            0,
            0});
            this.transparencyUserValue.Name = "transparencyUserValue";
            this.transparencyUserValue.ReadOnly = true;
            this.transparencyUserValue.Size = new System.Drawing.Size(120, 20);
            this.transparencyUserValue.TabIndex = 8;
            this.transparencyUserValue.ValueChanged += new System.EventHandler(this.transparencyUserValue_ValueChanged);
            // 
            // transparencyLabel
            // 
            this.transparencyLabel.AutoSize = true;
            this.transparencyLabel.Location = new System.Drawing.Point(11, 32);
            this.transparencyLabel.Name = "transparencyLabel";
            this.transparencyLabel.Size = new System.Drawing.Size(75, 13);
            this.transparencyLabel.TabIndex = 7;
            this.transparencyLabel.Text = "Transparency:";
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(163, 152);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 9;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // instructLabel
            // 
            this.instructLabel.AutoSize = true;
            this.instructLabel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.instructLabel.Location = new System.Drawing.Point(13, 21);
            this.instructLabel.Name = "instructLabel";
            this.instructLabel.Size = new System.Drawing.Size(256, 13);
            this.instructLabel.TabIndex = 7;
            this.instructLabel.Text = "Make your selections, and click Apply when finished.";
            // 
            // CustomizeAppearanceWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 188);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.colourBox);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.instructLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomizeAppearanceWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customize Appearance";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CustomizeAppearanceWindow_FormClosing);
            this.Shown += new System.EventHandler(this.CustomizeAppearanceWindow_Shown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CustomizeAppearanceWindow_KeyPress);
            this.colourBox.ResumeLayout(false);
            this.colourBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transparencyUserValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.GroupBox colourBox;
        private System.Windows.Forms.NumericUpDown transparencyUserValue;
        private System.Windows.Forms.Label transparencyLabel;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Label instructLabel;
        private System.Windows.Forms.ComboBox topMostComboBox;
        private System.Windows.Forms.Label topMostLabel;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}