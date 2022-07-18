using CommandCentral.CC_Common;
using CommandCentral.CC_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CommandCentral.CC_UI
{
    public partial class NoteWindow : Form
    {
        private Frame cFrame;

        private NoteFile noteFile;

        /// <summary>
        /// 
        /// </summary>
        public NoteWindow(NoteFile noteFile = null)
        {
            InitializeComponent();
            InitializeUI();

            // Set NoteFile attributes to NoteWindow
            if (noteFile != null)
            {
                this.noteFile = noteFile;
                foreach (String line in noteFile.contents)
                {
                    this.richTextBoxNotes.Text += line;
                    this.richTextBoxNotes.Text += "\n";
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitializeUI()
        {
            richTextBoxNotes.BackColor = this.BackColor;
            richTextBoxNotes.ForeColor = Lib.DEFAULT_PRIMARY_COLOR;
            richTextBoxNotes.SelectionBackColor = Color.FromArgb(60, 60, 60);
            richTextBoxNotes.Font = new Font(Lib.DEFAULT_APP_FONT, 9.00F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
        }

        /// <summary>
        /// Save this note
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to save this note?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result.Equals(DialogResult.No))
                return;

            if (result.Equals(DialogResult.Yes))
            {
                NoteLib notelib = new NoteLib();
                String noteText = this.richTextBoxNotes.Text;
                bool saveResult = (this.noteFile == null) ? notelib.saveNote(noteText) : notelib.saveNote(noteText, this.noteFile.filename);
                if (saveResult)
                {
                    MessageBox.Show("Note saved", "Note", MessageBoxButtons.OK);
                    this.richTextBoxNotes.Focus();
                }
            }
        }

        /// <summary>
        /// Discard/delete this note
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDiscard_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to discard this note?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result.Equals(DialogResult.No))
                return;

            if (result.Equals(DialogResult.Yes))
            {
                NoteLib notelib = new NoteLib();
                bool discardResult = notelib.discardNote(this.noteFile.filename);
                if (discardResult)
                {
                    MessageBox.Show("Note deleted", "Note", MessageBoxButtons.OK);
                    this.Close();
                }
            }
        }




        #region FRAME LOGIC  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NoteWindow_Shown(object sender, EventArgs e)
        {
            generateFrame();
        }

        // Create frame
        private void generateFrame()
        {
            Point defaultPoint = new Point(this.Location.X, this.Location.Y);

            cFrame = new Frame(this);
            cFrame.Show();

            this.Location = defaultPoint;
        }

        // Mirror movements to frame
        private void NoteWindow_LocationChanged(object sender, EventArgs e)
        {
            if (cFrame == null) return;
            cFrame.Location = new Point(this.Location.X, this.Location.Y);
        }
        // Mirror size changes to frame
        private void NoteWindow_SizeChanged(object sender, EventArgs e)
        {
            if (cFrame == null) return;
            cFrame.Size = new Size(this.Width, this.Height);
        }


        private void NoteWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            cFrame.Dispose();
        }
        #endregion

    }
}
