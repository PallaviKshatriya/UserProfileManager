namespace UserProfiles
{
    partial class FormUserProfile
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
            this.components = new System.ComponentModel.Container();
            this.lblFormheader = new System.Windows.Forms.Label();
            this.labelTextUserProfileId = new System.Windows.Forms.Label();
            this.labelTextUserAdmin = new System.Windows.Forms.Label();
            this.labelTextEmailAddress = new System.Windows.Forms.Label();
            this.labelTextUserName = new System.Windows.Forms.Label();
            this.textBoxUserEmailAddress = new System.Windows.Forms.TextBox();
            this.textBoxUserFullName = new System.Windows.Forms.TextBox();
            this.textBoxUserDomainName = new System.Windows.Forms.TextBox();
            this.checkBoxIsUserAdmin = new System.Windows.Forms.CheckBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.labelUserProfileId = new System.Windows.Forms.Label();
            this.groupBoxProfileFields = new System.Windows.Forms.GroupBox();
            this.groupBoxUserAccess = new System.Windows.Forms.GroupBox();
            this.groupBoxActions = new System.Windows.Forms.GroupBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewUserSettings = new System.Windows.Forms.DataGridView();
            this.branchLNDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.branchBRDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.branchPRDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.branchDFDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localSystemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryDataGridViewComboBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.userLevelCategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userProfileSystemSettingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBoxProfileFields.SuspendLayout();
            this.groupBoxUserAccess.SuspendLayout();
            this.groupBoxActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userLevelCategoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userProfileSystemSettingBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFormheader
            // 
            this.lblFormheader.AutoSize = true;
            this.lblFormheader.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormheader.Location = new System.Drawing.Point(17, 30);
            this.lblFormheader.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblFormheader.Name = "lblFormheader";
            this.lblFormheader.Size = new System.Drawing.Size(348, 41);
            this.lblFormheader.TabIndex = 0;
            this.lblFormheader.Text = "User Profile Entry Form";
            this.lblFormheader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTextUserProfileId
            // 
            this.labelTextUserProfileId.AutoSize = true;
            this.labelTextUserProfileId.Location = new System.Drawing.Point(23, 61);
            this.labelTextUserProfileId.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelTextUserProfileId.Name = "labelTextUserProfileId";
            this.labelTextUserProfileId.Size = new System.Drawing.Size(199, 37);
            this.labelTextUserProfileId.TabIndex = 1;
            this.labelTextUserProfileId.Text = "User Profile Id:";
            // 
            // labelTextUserAdmin
            // 
            this.labelTextUserAdmin.AutoSize = true;
            this.labelTextUserAdmin.Location = new System.Drawing.Point(23, 268);
            this.labelTextUserAdmin.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelTextUserAdmin.Name = "labelTextUserAdmin";
            this.labelTextUserAdmin.Size = new System.Drawing.Size(168, 37);
            this.labelTextUserAdmin.TabIndex = 4;
            this.labelTextUserAdmin.Text = "User Admin:";
            // 
            // labelTextEmailAddress
            // 
            this.labelTextEmailAddress.AutoSize = true;
            this.labelTextEmailAddress.Location = new System.Drawing.Point(23, 197);
            this.labelTextEmailAddress.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelTextEmailAddress.Name = "labelTextEmailAddress";
            this.labelTextEmailAddress.Size = new System.Drawing.Size(206, 37);
            this.labelTextEmailAddress.TabIndex = 5;
            this.labelTextEmailAddress.Text = "E-mail Address:";
            // 
            // labelTextUserName
            // 
            this.labelTextUserName.AutoSize = true;
            this.labelTextUserName.Location = new System.Drawing.Point(23, 125);
            this.labelTextUserName.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelTextUserName.Name = "labelTextUserName";
            this.labelTextUserName.Size = new System.Drawing.Size(160, 37);
            this.labelTextUserName.TabIndex = 6;
            this.labelTextUserName.Text = "User Name:";
            // 
            // textBoxUserEmailAddress
            // 
            this.textBoxUserEmailAddress.Location = new System.Drawing.Point(319, 182);
            this.textBoxUserEmailAddress.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.textBoxUserEmailAddress.Name = "textBoxUserEmailAddress";
            this.textBoxUserEmailAddress.Size = new System.Drawing.Size(831, 44);
            this.textBoxUserEmailAddress.TabIndex = 17;
            // 
            // textBoxUserFullName
            // 
            this.textBoxUserFullName.Location = new System.Drawing.Point(602, 111);
            this.textBoxUserFullName.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.textBoxUserFullName.Name = "textBoxUserFullName";
            this.textBoxUserFullName.Size = new System.Drawing.Size(548, 44);
            this.textBoxUserFullName.TabIndex = 18;
            // 
            // textBoxUserDomainName
            // 
            this.textBoxUserDomainName.Location = new System.Drawing.Point(319, 111);
            this.textBoxUserDomainName.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.textBoxUserDomainName.Name = "textBoxUserDomainName";
            this.textBoxUserDomainName.Size = new System.Drawing.Size(260, 44);
            this.textBoxUserDomainName.TabIndex = 19;
            // 
            // checkBoxIsUserAdmin
            // 
            this.checkBoxIsUserAdmin.AutoSize = true;
            this.checkBoxIsUserAdmin.Location = new System.Drawing.Point(319, 268);
            this.checkBoxIsUserAdmin.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.checkBoxIsUserAdmin.Name = "checkBoxIsUserAdmin";
            this.checkBoxIsUserAdmin.Size = new System.Drawing.Size(34, 33);
            this.checkBoxIsUserAdmin.TabIndex = 20;
            this.checkBoxIsUserAdmin.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(11, 57);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(243, 55);
            this.btnEdit.TabIndex = 33;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(297, 57);
            this.btnSave.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(243, 55);
            this.btnSave.TabIndex = 34;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(577, 57);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(243, 55);
            this.btnDelete.TabIndex = 35;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(861, 57);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(243, 55);
            this.btnCancel.TabIndex = 36;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1149, 57);
            this.btnClose.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(243, 55);
            this.btnClose.TabIndex = 37;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // labelUserProfileId
            // 
            this.labelUserProfileId.AutoSize = true;
            this.labelUserProfileId.Location = new System.Drawing.Point(316, 61);
            this.labelUserProfileId.Name = "labelUserProfileId";
            this.labelUserProfileId.Size = new System.Drawing.Size(207, 37);
            this.labelUserProfileId.TabIndex = 39;
            this.labelUserProfileId.Text = "<UserProfileId>";
            // 
            // groupBoxProfileFields
            // 
            this.groupBoxProfileFields.Controls.Add(this.labelTextUserProfileId);
            this.groupBoxProfileFields.Controls.Add(this.labelUserProfileId);
            this.groupBoxProfileFields.Controls.Add(this.labelTextUserAdmin);
            this.groupBoxProfileFields.Controls.Add(this.labelTextEmailAddress);
            this.groupBoxProfileFields.Controls.Add(this.labelTextUserName);
            this.groupBoxProfileFields.Controls.Add(this.textBoxUserEmailAddress);
            this.groupBoxProfileFields.Controls.Add(this.textBoxUserFullName);
            this.groupBoxProfileFields.Controls.Add(this.textBoxUserDomainName);
            this.groupBoxProfileFields.Controls.Add(this.checkBoxIsUserAdmin);
            this.groupBoxProfileFields.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxProfileFields.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxProfileFields.Location = new System.Drawing.Point(24, 99);
            this.groupBoxProfileFields.Name = "groupBoxProfileFields";
            this.groupBoxProfileFields.Size = new System.Drawing.Size(1901, 327);
            this.groupBoxProfileFields.TabIndex = 41;
            this.groupBoxProfileFields.TabStop = false;
            this.groupBoxProfileFields.Text = "User Profile";
            // 
            // groupBoxUserAccess
            // 
            this.groupBoxUserAccess.Controls.Add(this.dataGridViewUserSettings);
            this.groupBoxUserAccess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxUserAccess.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxUserAccess.Location = new System.Drawing.Point(24, 455);
            this.groupBoxUserAccess.Name = "groupBoxUserAccess";
            this.groupBoxUserAccess.Size = new System.Drawing.Size(1901, 474);
            this.groupBoxUserAccess.TabIndex = 42;
            this.groupBoxUserAccess.TabStop = false;
            this.groupBoxUserAccess.Text = "User Access";
            // 
            // groupBoxActions
            // 
            this.groupBoxActions.Controls.Add(this.btnEdit);
            this.groupBoxActions.Controls.Add(this.btnSave);
            this.groupBoxActions.Controls.Add(this.btnClose);
            this.groupBoxActions.Controls.Add(this.btnDelete);
            this.groupBoxActions.Controls.Add(this.btnCancel);
            this.groupBoxActions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxActions.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxActions.Location = new System.Drawing.Point(24, 961);
            this.groupBoxActions.Name = "groupBoxActions";
            this.groupBoxActions.Size = new System.Drawing.Size(1901, 140);
            this.groupBoxActions.TabIndex = 43;
            this.groupBoxActions.TabStop = false;
            this.groupBoxActions.Text = "Actions";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "LocalSystem";
            this.dataGridViewTextBoxColumn1.HeaderText = "System";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewUserSettings
            // 
            this.dataGridViewUserSettings.AllowUserToAddRows = false;
            this.dataGridViewUserSettings.AllowUserToDeleteRows = false;
            this.dataGridViewUserSettings.AutoGenerateColumns = false;
            this.dataGridViewUserSettings.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridViewUserSettings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.localSystemDataGridViewTextBoxColumn,
            this.branchLNDataGridViewCheckBoxColumn,
            this.branchBRDataGridViewCheckBoxColumn,
            this.branchPRDataGridViewCheckBoxColumn,
            this.branchDFDataGridViewCheckBoxColumn,
            this.categoryDataGridViewComboBoxColumn});
            this.dataGridViewUserSettings.DataSource = this.userProfileSystemSettingBindingSource;
            this.dataGridViewUserSettings.Location = new System.Drawing.Point(6, 52);
            this.dataGridViewUserSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewUserSettings.Name = "dataGridViewUserSettings";
            this.dataGridViewUserSettings.RowTemplate.Height = 40;
            this.dataGridViewUserSettings.Size = new System.Drawing.Size(1873, 389);
            this.dataGridViewUserSettings.TabIndex = 38;
            // 
            // branchLNDataGridViewCheckBoxColumn
            // 
            this.branchLNDataGridViewCheckBoxColumn.DataPropertyName = "IsBranchLnActive";
            this.branchLNDataGridViewCheckBoxColumn.HeaderText = "LN";
            this.branchLNDataGridViewCheckBoxColumn.Name = "branchLNDataGridViewCheckBoxColumn";
            this.branchLNDataGridViewCheckBoxColumn.Width = 50;
            // 
            // branchBRDataGridViewCheckBoxColumn
            // 
            this.branchBRDataGridViewCheckBoxColumn.DataPropertyName = "IsBranchBrActive";
            this.branchBRDataGridViewCheckBoxColumn.HeaderText = "BR";
            this.branchBRDataGridViewCheckBoxColumn.Name = "branchBRDataGridViewCheckBoxColumn";
            this.branchBRDataGridViewCheckBoxColumn.Width = 50;
            // 
            // branchPRDataGridViewCheckBoxColumn
            // 
            this.branchPRDataGridViewCheckBoxColumn.DataPropertyName = "IsBranchPrActive";
            this.branchPRDataGridViewCheckBoxColumn.HeaderText = "PR";
            this.branchPRDataGridViewCheckBoxColumn.Name = "branchPRDataGridViewCheckBoxColumn";
            this.branchPRDataGridViewCheckBoxColumn.Width = 50;
            // 
            // branchDFDataGridViewCheckBoxColumn
            // 
            this.branchDFDataGridViewCheckBoxColumn.DataPropertyName = "IsBranchPrActive";
            this.branchDFDataGridViewCheckBoxColumn.HeaderText = "DF";
            this.branchDFDataGridViewCheckBoxColumn.Name = "branchDFDataGridViewCheckBoxColumn";
            this.branchDFDataGridViewCheckBoxColumn.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "LocalSystem";
            this.dataGridViewTextBoxColumn2.HeaderText = "System";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // localSystemDataGridViewTextBoxColumn
            // 
            this.localSystemDataGridViewTextBoxColumn.DataPropertyName = "LocalSystem";
            this.localSystemDataGridViewTextBoxColumn.HeaderText = "System";
            this.localSystemDataGridViewTextBoxColumn.Name = "localSystemDataGridViewTextBoxColumn";
            this.localSystemDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // categoryDataGridViewComboBoxColumn
            // 
            this.categoryDataGridViewComboBoxColumn.DataPropertyName = "Category";
            this.categoryDataGridViewComboBoxColumn.DataSource = this.userLevelCategoryBindingSource;
            this.categoryDataGridViewComboBoxColumn.DisplayMember = "Name";
            this.categoryDataGridViewComboBoxColumn.HeaderText = "Permission";
            this.categoryDataGridViewComboBoxColumn.Name = "categoryDataGridViewComboBoxColumn";
            this.categoryDataGridViewComboBoxColumn.ValueMember = "Id";
            this.categoryDataGridViewComboBoxColumn.Width = 200;
            // 
            // userLevelCategoryBindingSource
            // 
            this.userLevelCategoryBindingSource.DataSource = typeof(UserProfiles.Model.UserLevelCategory);
            // 
            // userProfileSystemSettingBindingSource
            // 
            this.userProfileSystemSettingBindingSource.DataSource = typeof(UserProfiles.Model.UserProfileSystemSetting);
            // 
            // FormUserProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1974, 1136);
            this.Controls.Add(this.groupBoxActions);
            this.Controls.Add(this.groupBoxProfileFields);
            this.Controls.Add(this.lblFormheader);
            this.Controls.Add(this.groupBoxUserAccess);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "FormUserProfile";
            this.Text = "User Profile Entry Form";
            this.groupBoxProfileFields.ResumeLayout(false);
            this.groupBoxProfileFields.PerformLayout();
            this.groupBoxUserAccess.ResumeLayout(false);
            this.groupBoxActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userLevelCategoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userProfileSystemSettingBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFormheader;
        private System.Windows.Forms.Label labelTextUserProfileId;
        private System.Windows.Forms.Label labelTextUserAdmin;
        private System.Windows.Forms.Label labelTextEmailAddress;
        private System.Windows.Forms.Label labelTextUserName;
        private System.Windows.Forms.TextBox textBoxUserEmailAddress;
        private System.Windows.Forms.TextBox textBoxUserFullName;
        private System.Windows.Forms.TextBox textBoxUserDomainName;
        private System.Windows.Forms.CheckBox checkBoxIsUserAdmin;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label labelUserProfileId;
        private System.Windows.Forms.BindingSource userProfileSystemSettingBindingSource;
        private System.Windows.Forms.BindingSource userLevelCategoryBindingSource;
        private System.Windows.Forms.GroupBox groupBoxProfileFields;
        private System.Windows.Forms.GroupBox groupBoxUserAccess;
        private System.Windows.Forms.GroupBox groupBoxActions;
        private System.Windows.Forms.DataGridView dataGridViewUserSettings;
        private System.Windows.Forms.DataGridViewTextBoxColumn localSystemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn branchLNDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn branchBRDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn branchPRDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn branchDFDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn categoryDataGridViewComboBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}

