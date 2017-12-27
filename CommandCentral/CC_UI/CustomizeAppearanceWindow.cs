using CommandCentral.CC_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommandCentral.CC_UI
{
    public partial class CustomizeAppearanceWindow : Form
    {
        private AppRegistry appReg = new AppRegistry();
        private CommandCentralWindow oParentForm = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentWindow"></param>
        public CustomizeAppearanceWindow(CommandCentralWindow parentWindow)
        {
            InitializeComponent();

            oParentForm = parentWindow;
        }

        #region CORE LOGIC  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        /// <summary>
        /// Set screen values equal to registry values
        /// </summary>
        private void InitializeUI()
        {
            // Transparency display value
            string transparencyValue = appReg.getKeyValue(AppRegistry.CCKeys.Transparency);
            this.transparencyUserValue.Value = (transparencyValue == "") ? 0 : int.Parse(transparencyValue);

            // TopMost display value
            string topMostValue = appReg.getKeyValue(AppRegistry.CCKeys.TopMost);
            this.topMostComboBox.Text = (topMostValue == "") ? "No" : topMostValue;

            this.transparencyUserValue.Focus();
        }

        /// <summary>
        /// Check for unsaved changes
        /// </summary>
        private void checkForUnsavedChanges()
        {
            // Transparency
            string regTransparencyValue = appReg.getKeyValue(AppRegistry.CCKeys.Transparency);
            string screenTransparencyValue = this.transparencyUserValue.Value.ToString();

            // TopMost
            string regTopMostValue = appReg.getKeyValue(AppRegistry.CCKeys.TopMost);
            string screenTopMostValue = this.topMostComboBox.Text;

            if (!regTransparencyValue.Equals(screenTransparencyValue) || !regTopMostValue.Equals(screenTopMostValue))
            {
                DialogResult result = MessageBox.Show("You have unsaved changes. Do you want to save them?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result.Equals(DialogResult.Yes))
                {
                    performSave();
                    this.Close();
                }
            }

            oParentForm.SetCustomUIAttributes(true, true, false, false);
        }

        /// <summary>
        /// Save screen settings to registry and refresh UI
        /// </summary>
        private void performSave()
        {
            AppRegistry appReg = new AppRegistry();

            // Transparency
            string transparencyValue = this.transparencyUserValue.Value.ToString();
            appReg.setKeyValue(AppRegistry.CCKeys.Transparency, transparencyValue);

            // TopMost
            string topMostValue = (topMostComboBox.SelectedItem == null) ? "" : topMostComboBox.SelectedItem.ToString();
            appReg.setKeyValue(AppRegistry.CCKeys.TopMost, topMostValue);

            oParentForm.SetCustomUIAttributes();
        }

        #endregion

        #region BUTTONS  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        /// <summary>
        /// Close button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Apply button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void applyButton_Click(object sender, EventArgs e)
        {
            performSave();
        }

        #endregion

        #region WINDOW BEHAVIOUR HANDLERS

        private void CustomizeAppearanceWindow_Shown(object sender, EventArgs e)
        {
            InitializeUI();
        }

        private void CustomizeAppearanceWindow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                this.Close();
        }


        private void CustomizeAppearanceWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            checkForUnsavedChanges();
        }

        #endregion

        #region UI CONTROLS HANDLERS  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        // TRANSPARENCY
        private void transparencyUserValue_ValueChanged(object sender, EventArgs e)
        {
            oParentForm.setAppTransparency(this.transparencyUserValue.Value.ToString());
        }

        // TOPMOST
        private void topMostComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            oParentForm.setAppTopMost(this.topMostComboBox.Text);
        }

        #endregion

        #region RETIRED

        //private void selectTextColourButton_Click(object sender, EventArgs e)
        //{
        //    DialogResult colorDialogResult = this.colorDialog1.ShowDialog(this);

        //    if (colorDialogResult.Equals(DialogResult.Cancel))
        //        return;

        //    string colorSelected = colorDialog1.Color.Name;
        //    oParentForm.setAppColours("", colorSelected);
        //}

        //private void selectBGColourButton_Click(object sender, EventArgs e)
        //{

        //    DialogResult colorSelected = this.colorDialog1.ShowDialog(this);

        //    colorSelected.ToString();
        //}

        #endregion


    }
}
 