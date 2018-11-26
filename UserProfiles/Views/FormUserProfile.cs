﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UserProfiles.Model;

namespace UserProfiles
{
    public partial class FormUserProfile : Form
    {
        public IRepository Repository { get; set; }
        public int UserProfileId { get; set; } = 1;
        
        public FormUserProfile()
        { 
            
            InitializeComponent();
            PreLoadOperations();

         

            Repository = new UserProfileRepository();
            //var systems = repository.GetSystems();
            //var branches = repository.GetBranches();
            List<UserLevelCategory> categories = Repository.GetUserLevelCategories();
            UserProfile userProfile = Repository.GetUserProfile(UserProfileId);
            AggregationBindingList<UserProfileSystemSetting> userSystemSettings = Repository.GetSystemSettings(UserProfileId);

            bindingSourceUserProfileSystemSetting.DataSource = userSystemSettings;
            bindingSourceUserLevelCategory.DataSource = categories;
            bindingSourceUserProfile.DataSource = userProfile;
            //BindUserProfileFields(userProfile);
            if (userProfile.IsAdmin== true)
            {
                AdminUserModeOfOperation();
            }
            else
            {
                this.Enabled = false;
            }
                PostLoadOperations();
        }
        private void AdminUserModeOfOperation()
        {
            foreach(Control ctrl in this.Controls)
            {
                if (ctrl.GetType() == typeof(GroupBox))
                    if(ctrl.Text =="Actions")
                    {
                        buttonCancel.Enabled = false;
                        buttonSave.Enabled = false;
                        buttonDelete.Enabled = false;   
                    }
                else
                    {
                        ((GroupBox)ctrl).Enabled = false;
                    }
                if (ctrl.GetType() == typeof(Button))
                    ((Button)ctrl).Enabled= false;
                    
            }
        }

        private void PostLoadOperations()
        {
            //dataGridViewUserSettings.Height = dataGridViewUserSettings.Rows.GetRowsHeight(DataGridViewElementStates.None) + dataGridViewUserSettings.ColumnHeadersHeight + 2;
            //dataGridViewUserSettings.Width = dataGridViewUserSettings.Columns.GetColumnsWidth(DataGridViewElementStates.None) + dataGridViewUserSettings.RowHeadersWidth + 2;
        }

        private void BindUserProfileFields(UserProfile profile)
        {
            labelUserProfileId.Text = profile.Id.ToString();
            textBoxUserDomainName.Text = profile.DomainName;
            textBoxUserEmailAddress.Text = profile.MailAddress;
            textBoxUserFullName.Text = profile.Name;
            checkBoxIsUserAdmin.Checked = profile.IsAdmin;
        }

        void DataGridViewUserSettings_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (this.dataGridViewUserSettings.CurrentCell.ColumnIndex == this.categoryDataGridViewComboBoxColumn.Index)
            {
                BindingSource bindingSource = this.dataGridViewUserSettings.DataSource as BindingSource;
                UserProfileSystemSetting setting = bindingSource.Current as UserProfileSystemSetting;
                BindingList<UserLevelCategory> bindingList = GetSystemCategories(setting);

                DataGridViewComboBoxEditingControl comboBox = e.Control as DataGridViewComboBoxEditingControl;
                comboBox.DataSource = bindingList;
                comboBox.SelectedValue = setting.Category.Id;
                //comboBox.Data
                comboBox.SelectionChangeCommitted -= this.comboBox_SelectionChangeCommitted;
                comboBox.SelectionChangeCommitted += this.comboBox_SelectionChangeCommitted;
            }
        }

        private void comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.dataGridViewUserSettings.EndEdit();
        }

        private BindingList<UserLevelCategory> GetSystemCategories(UserProfileSystemSetting setting)
        {
            var bindingList = new BindingList<UserLevelCategory>();
            var categories = bindingSourceUserLevelCategory.DataSource as List<UserLevelCategory>;
            var filteredCategories = categories.Where(c => c.LocalSystemId == setting.LocalSystem.Id).ToList();
            filteredCategories.ForEach(fc => bindingList.Add(fc));
            return bindingList;
        }

        /*
        private void dataGridViewUserSettings_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        */
        private void PreLoadOperations()
        {
            this.dataGridViewUserSettings.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(DataGridViewUserSettings_EditingControlShowing);
            this.localSystemDataGridViewTextBoxColumn.DataPropertyName = "LocalSystem->Name";
            this.categoryDataGridViewComboBoxColumn.DataPropertyName = "Category->Id";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
            bindingSourceUserProfile.Clear();
            bindingSourceUserProfileSystemSetting.Clear();
            UserProfile userProfile = Repository.GetUserProfile(UserProfileId);
            AggregationBindingList<UserProfileSystemSetting> userSystemSettings = Repository.GetSystemSettings(UserProfileId);

            bindingSourceUserProfileSystemSetting.DataSource = userSystemSettings;
            bindingSourceUserProfile.DataSource = userProfile;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           Repository.DeleteUserDetails(UserProfileId);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var upObject = new UserProfile
            {
                DomainName = textBoxUserDomainName.Text,
                IsAdmin = checkBoxIsUserAdmin.Checked,
                MailAddress = textBoxUserEmailAddress.Text,
                Name = textBoxUserFullName.Text
            };

            //dataGridViewUserSettings.EndEdit();
            var userSystemSettings = bindingSourceUserProfileSystemSetting.DataSource as AggregationBindingList<UserProfileSystemSetting>;
            Repository.UpdateUserSystemSettings(userSystemSettings);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.GetType() == typeof(GroupBox))
                {
                    ctrl.Enabled = true;
                    buttonCancel.Enabled = true;
                    buttonSave.Enabled = true;
                    buttonDelete.Enabled = true;
                }
            }
        }
    }
}
