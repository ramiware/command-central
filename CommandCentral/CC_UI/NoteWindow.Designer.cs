namespace CommandCentral.CC_UI
{
    partial class NoteWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteWindow));
            this.richTextBoxNotes = new System.Windows.Forms.RichTextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.buttonDiscard = new System.Windows.Forms.Button();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBoxNotes
            // 
            this.richTextBoxNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxNotes.BackColor = System.Drawing.Color.Black;
            this.richTextBoxNotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxNotes.ForeColor = System.Drawing.Color.Yellow;
            this.richTextBoxNotes.Location = new System.Drawing.Point(8, 10);
            this.richTextBoxNotes.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.richTextBoxNotes.Name = "richTextBoxNotes";
            this.richTextBoxNotes.Size = new System.Drawing.Size(358, 287);
            this.richTextBoxNotes.TabIndex = 0;
            this.richTextBoxNotes.Text = "";
            // 
            // buttonSave
            // 
            this.buttonSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSave.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Location = new System.Drawing.Point(0, 0);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(376, 22);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // panelFooter
            // 
            this.panelFooter.Controls.Add(this.buttonDiscard);
            this.panelFooter.Controls.Add(this.buttonSave);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 297);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(376, 48);
            this.panelFooter.TabIndex = 2;
            // 
            // buttonDiscard
            // 
            this.buttonDiscard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDiscard.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonDiscard.FlatAppearance.BorderSize = 0;
            this.buttonDiscard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.buttonDiscard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDiscard.Location = new System.Drawing.Point(0, 26);
            this.buttonDiscard.Name = "buttonDiscard";
            this.buttonDiscard.Size = new System.Drawing.Size(376, 22);
            this.buttonDiscard.TabIndex = 2;
            this.buttonDiscard.Text = "Discard";
            this.buttonDiscard.UseVisualStyleBackColor = true;
            this.buttonDiscard.Click += new System.EventHandler(this.buttonDiscard_Click);
            // 
            // NoteWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(376, 345);
            this.Controls.Add(this.richTextBoxNotes);
            this.Controls.Add(this.panelFooter);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(150, 150);
            this.Name = "NoteWindow";
            this.Opacity = 0.8D;
            this.Text = "Note Window";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NoteWindow_FormClosing);
            this.Shown += new System.EventHandler(this.NoteWindow_Shown);
            this.LocationChanged += new System.EventHandler(this.NoteWindow_LocationChanged);
            this.SizeChanged += new System.EventHandler(this.NoteWindow_SizeChanged);
            this.panelFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxNotes;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Button buttonDiscard;


    }
}