using System;
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
        public FormUserProfile()
        {
            InitializeComponent();
            RegisterCustomColumns();

            int userProfileId = 1;

            var repository = new UserProfileRepository();
            //var systems = repository.GetSystems();
            //var branches = repository.GetBranches();
            var categories = repository.GetUserLevelCategories();
            var userProfile = repository.GetUserProfile(userProfileId);
            var userSystemSettings = repository.GetSystemSettings(userProfileId);

            userProfileSystemSettingBindingSource.DataSource = userSystemSettings;
            userLevelCategoryBindingSource.DataSource = categories;
            BindUserProfileFields(userProfile);

            PostLoad();
        }

        private void PostLoad()
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
            var categories = userLevelCategoryBindingSource.DataSource as List<UserLevelCategory>;
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
        private void RegisterCustomColumns()
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
            this.Refresh();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //DataTable changedRows = CT(dataGridViewUserSettings.DataSource, DataTable).GetChanges(DataRowState.Modified).Rows
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
        }
    }
}
