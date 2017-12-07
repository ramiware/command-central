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
            this.topMostComboBox = new System.Windows.Forms.ComboBox();
            this.topMostLabel = new System.Windows.Forms.Label();
            this.transparencyUserValue = new System.Windows.Forms.NumericUpDown();
            this.transparencyLabel = new System.Windows.Forms.Label();
            this.applyButton = new System.Windows.Forms.Button();
            this.instructLabel = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.custTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.transparencyUserValue)).BeginInit();
            this.custTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(253, 153);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 10;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // topMostComboBox
            // 
            this.topMostComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.topMostComboBox.FormattingEnabled = true;
            this.topMostComboBox.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.topMostComboBox.Location = new System.Drawing.Point(167, 66);
            this.topMostComboBox.Name = "topMostComboBox";
            this.topMostComboBox.Size = new System.Drawing.Size(121, 21);
            this.topMostComboBox.TabIndex = 10;
            this.topMostComboBox.SelectedIndexChanged += new System.EventHandler(this.topMostComboBox_SelectedIndexChanged);
            // 
            // topMostLabel
            // 
            this.topMostLabel.AutoSize = true;
            this.topMostLabel.Location = new System.Drawing.Point(164, 50);
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
            this.transparencyUserValue.Location = new System.Drawing.Point(23, 66);
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
            this.transparencyLabel.Location = new System.Drawing.Point(19, 50);
            this.transparencyLabel.Name = "transparencyLabel";
            this.transparencyLabel.Size = new System.Drawing.Size(75, 13);
            this.transparencyLabel.TabIndex = 7;
            this.transparencyLabel.Text = "Transparency:";
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(172, 153);
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
            this.instructLabel.Location = new System.Drawing.Point(19, 24);
            this.instructLabel.Name = "instructLabel";
            this.instructLabel.Size = new System.Drawing.Size(256, 13);
            this.instructLabel.TabIndex = 7;
            this.instructLabel.Text = "Make your selections, and click Apply when finished.";
            // 
            // custTabControl
            // 
            this.custTabControl.Controls.Add(this.tabPage1);
            this.custTabControl.Location = new System.Drawing.Point(12, 12);
            this.custTabControl.Name = "custTabControl";
            this.custTabControl.SelectedIndex = 0;
            this.custTabControl.Size = new System.Drawing.Size(316, 135);
            this.custTabControl.TabIndex = 11;
            this.custTabControl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CustomizeAppearanceWindow_KeyPress);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.topMostComboBox);
            this.tabPage1.Controls.Add(this.instructLabel);
            this.tabPage1.Controls.Add(this.topMostLabel);
            this.tabPage1.Controls.Add(this.transparencyUserValue);
            this.tabPage1.Controls.Add(this.transparencyLabel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(308, 109);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // CustomizeAppearanceWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 185);
            this.Controls.Add(this.custTabControl);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.closeButton);
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
            ((System.ComponentModel.ISupportInitialize)(this.transparencyUserValue)).EndInit();
            this.custTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.NumericUpDown transparencyUserValue;
        private System.Windows.Forms.Label transparencyLabel;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Label instructLabel;
        private System.Windows.Forms.ComboBox topMostComboBox;
        private System.Windows.Forms.Label topMostLabel;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TabControl custTabControl;
        private System.Windows.Forms.TabPage tabPage1;
    }
}