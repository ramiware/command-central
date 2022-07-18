using CommandCentral.CC_Common;
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
    public partial class CommandCentralSettingsWindow : Form
    {
        //private AppRegistry appReg = new AppRegistry();
        private AppSettings oAppSettings = new AppSettings();
        private CommandCentralWindow oParentForm = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentWindow"></param>
        public CommandCentralSettingsWindow(CommandCentralWindow parentWindow)
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
            string transparencyValue = oAppSettings.getSettingValue(AppSettings.CCSettingKeys.Transparency);  //appReg.getKeyValue(AppRegistry.CCKeys.Transparency);
            this.transparencyUserValue.Value = (transparencyValue == "") ? 0 : int.Parse(transparencyValue);

            // TopMost display value
            string topMostValue = oAppSettings.getSettingValue(AppSettings.CCSettingKeys.TopMost); //appReg.getKeyValue(AppRegistry.CCKeys.TopMost);
            this.topMostComboBox.Text = (topMostValue == "") ? "No" : topMostValue;

            // CPU display values
            string cpuThresholdLevel1Value = oAppSettings.getSettingValue(AppSettings.CCSettingKeys.CPUThresholdLevel1);
            this.cpuThresholdLevel1Control.Value = (cpuThresholdLevel1Value == "") ? Lib.DEFAULT_CPU_THRESHOLD_WARNING_LEVEL1 : int.Parse(cpuThresholdLevel1Value);

            string cpuThresholdLevel2Value = oAppSettings.getSettingValue(AppSettings.CCSettingKeys.CPUThresholdLevel2);
            this.cpuThresholdLevel2Control.Value = (cpuThresholdLevel2Value == "") ? Lib.DEFAULT_CPU_THRESHOLD_WARNING_LEVEL2 : int.Parse(cpuThresholdLevel2Value);

            // RAM display values
            string ramThresholdLevel1Value = oAppSettings.getSettingValue(AppSettings.CCSettingKeys.RAMThresholdLevel1);
            this.ramThresholdLevel1Control.Value = (ramThresholdLevel1Value == "") ? decimal.Parse(Lib.DEFAULT_RAM_THRESHOLD_WARNING_LEVEL1.ToString()) : decimal.Parse(ramThresholdLevel1Value);

            string ramThresholdLevel2Value = oAppSettings.getSettingValue(AppSettings.CCSettingKeys.RAMThresholdLevel2);
            this.ramThresholdLevel2Control.Value = (ramThresholdLevel2Value == "") ? decimal.Parse(Lib.DEFAULT_RAM_THRESHOLD_WARNING_LEVEL2.ToString()) : decimal.Parse(ramThresholdLevel2Value);

            // Focus
            this.transparencyUserValue.Focus();
        }

        /// <summary>
        /// Check for unsaved changes
        /// </summary>
        private void checkForUnsavedChanges()
        {
            // Transparency
            string savedTransparencyValue = oAppSettings.getSettingValue(AppSettings.CCSettingKeys.Transparency);   //appReg.getKeyValue(AppRegistry.CCKeys.Transparency);
            string screenTransparencyValue = this.transparencyUserValue.Value.ToString();

            // TopMost
            string savedTopMostValue = oAppSettings.getSettingValue(AppSettings.CCSettingKeys.TopMost);//appReg.getKeyValue(AppRegistry.CCKeys.TopMost);
            string screenTopMostValue = this.topMostComboBox.Text;

            // CPU Levels
            string savedCpuThresholdLevel1Value = oAppSettings.getSettingValue(AppSettings.CCSettingKeys.CPUThresholdLevel1);
            string savedCpuThresholdLevel2Value = oAppSettings.getSettingValue(AppSettings.CCSettingKeys.CPUThresholdLevel2);
            string screenCpuThresholdLevel1Value = this.cpuThresholdLevel1Control.Value.ToString();
            string screenCpuThresholdLevel2Value = this.cpuThresholdLevel2Control.Value.ToString();

            // RAM Levels
            string savedRamThresholdLevel1Value = oAppSettings.getSettingValue(AppSettings.CCSettingKeys.RAMThresholdLevel1);
            string savedRamThresholdLevel2Value = oAppSettings.getSettingValue(AppSettings.CCSettingKeys.RAMThresholdLevel2);
            string screenRamThresholdLevel1Value = this.ramThresholdLevel1Control.Value.ToString();
            string screenRamThresholdLevel2Value = this.ramThresholdLevel2Control.Value.ToString();

            if (!savedTransparencyValue.Equals(screenTransparencyValue) || !savedTopMostValue.Equals(screenTopMostValue) ||
                !savedCpuThresholdLevel1Value.Equals(screenCpuThresholdLevel1Value) || !savedCpuThresholdLevel2Value.Equals(screenCpuThresholdLevel2Value) ||
                !savedRamThresholdLevel1Value.Equals(screenRamThresholdLevel1Value) || !savedRamThresholdLevel2Value.Equals(screenRamThresholdLevel2Value))
            {
                DialogResult result = MessageBox.Show("You have unsaved changes. Do you want to save them?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result.Equals(DialogResult.Yes))
                {
                    performSave();
                    this.Close();
                }
            }

            oParentForm.setCCSettings(true, true, false, false);
        }

        /// <summary>
        /// Save screen settings to registry and refresh UI
        /// </summary>
        private void performSave()
        {
            //AppRegistry appReg = new AppRegistry();
            AppSettings oAppSettings = new AppSettings();

            // Transparency
            string transparencyValue = this.transparencyUserValue.Value.ToString();
            oAppSettings.setSettingsValue(AppSettings.CCSettingKeys.Transparency, transparencyValue);
            //appReg.setKeyValue(AppRegistry.CCKeys.Transparency, transparencyValue);

            // TopMost
            string topMostValue = (topMostComboBox.SelectedItem == null) ? "" : topMostComboBox.SelectedItem.ToString();
            oAppSettings.setSettingsValue(AppSettings.CCSettingKeys.TopMost, topMostValue);
            //appReg.setKeyValue(AppRegistry.CCKeys.TopMost, topMostValue);

            // CPU Levels
            string cpuThresholdLevel1Value = cpuThresholdLevel1Control.Value.ToString();
            oAppSettings.setSettingsValue(AppSettings.CCSettingKeys.CPUThresholdLevel1, cpuThresholdLevel1Value);

            string cpuThresholdLevel2Value = cpuThresholdLevel2Control.Value.ToString();
            oAppSettings.setSettingsValue(AppSettings.CCSettingKeys.CPUThresholdLevel2, cpuThresholdLevel2Value);

            // RAM Levels
            string ramThresholdLevel1Value = ramThresholdLevel1Control.Value.ToString();
            oAppSettings.setSettingsValue(AppSettings.CCSettingKeys.RAMThresholdLevel1, ramThresholdLevel1Value);

            string ramThresholdLevel2Value = ramThresholdLevel2Control.Value.ToString();
            oAppSettings.setSettingsValue(AppSettings.CCSettingKeys.RAMThresholdLevel2, ramThresholdLevel2Value);


            oParentForm.setCCSettings();
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
        /// Save button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            performSave();
        }

        #endregion

        #region WINDOW BEHAVIOUR HANDLERS

        private void CommandCentralSettingsWindow_Shown(object sender, EventArgs e)
        {
            InitializeUI();
        }

        private void CommandCentralSettingsWindow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                this.Close();
        }


        private void CommandCentralSettingsWindow_FormClosing(object sender, FormClosingEventArgs e)
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
 