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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblFormheader = new System.Windows.Forms.Label();
            this.labelTextUserProfileId = new System.Windows.Forms.Label();
            this.labelTextUserAdmin = new System.Windows.Forms.Label();
            this.labelTextEmailAddress = new System.Windows.Forms.Label();
            this.labelTextUserName = new System.Windows.Forms.Label();
            this.textBoxUserEmailAddress = new System.Windows.Forms.TextBox();
            this.bindingSourceUserProfile = new System.Windows.Forms.BindingSource(this.components);
            this.textBoxUserFullName = new System.Windows.Forms.TextBox();
            this.textBoxUserDomainName = new System.Windows.Forms.TextBox();
            this.checkBoxIsUserAdmin = new System.Windows.Forms.CheckBox();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelUserProfileId = new System.Windows.Forms.Label();
            this.groupBoxProfileFields = new System.Windows.Forms.GroupBox();
            this.groupBoxUserAccess = new System.Windows.Forms.GroupBox();
            this.dataGridViewUserSettings = new System.Windows.Forms.DataGridView();
            this.localSystemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.branchLNDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.branchBRDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.branchPRDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.branchDFDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.categoryDataGridViewComboBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bindingSourceUserLevelCategory = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceUserProfileSystemSetting = new System.Windows.Forms.BindingSource(this.components);
            this.groupBoxActions = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUserProfile)).BeginInit();
            this.groupBoxProfileFields.SuspendLayout();
            this.groupBoxUserAccess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUserLevelCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUserProfileSystemSetting)).BeginInit();
            this.groupBoxActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFormheader
            // 
            this.lblFormheader.AutoSize = true;
            this.lblFormheader.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormheader.Location = new System.Drawing.Point(16, 31);
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
            this.labelTextUserProfileId.Location = new System.Drawing.Point(24, 62);
            this.labelTextUserProfileId.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelTextUserProfileId.Name = "labelTextUserProfileId";
            this.labelTextUserProfileId.Size = new System.Drawing.Size(199, 37);
            this.labelTextUserProfileId.TabIndex = 1;
            this.labelTextUserProfileId.Text = "User Profile Id:";
            // 
            // labelTextUserAdmin
            // 
            this.labelTextUserAdmin.AutoSize = true;
            this.labelTextUserAdmin.Location = new System.Drawing.Point(24, 267);
            this.labelTextUserAdmin.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelTextUserAdmin.Name = "labelTextUserAdmin";
            this.labelTextUserAdmin.Size = new System.Drawing.Size(168, 37);
            this.labelTextUserAdmin.TabIndex = 4;
            this.labelTextUserAdmin.Text = "User Admin:";
            // 
            // labelTextEmailAddress
            // 
            this.labelTextEmailAddress.AutoSize = true;
            this.labelTextEmailAddress.Location = new System.Drawing.Point(24, 198);
            this.labelTextEmailAddress.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelTextEmailAddress.Name = "labelTextEmailAddress";
            this.labelTextEmailAddress.Size = new System.Drawing.Size(206, 37);
            this.labelTextEmailAddress.TabIndex = 5;
            this.labelTextEmailAddress.Text = "E-mail Address:";
            // 
            // labelTextUserName
            // 
            this.labelTextUserName.AutoSize = true;
            this.labelTextUserName.Location = new System.Drawing.Point(24, 124);
            this.labelTextUserName.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelTextUserName.Name = "labelTextUserName";
            this.labelTextUserName.Size = new System.Drawing.Size(160, 37);
            this.labelTextUserName.TabIndex = 6;
            this.labelTextUserName.Text = "User Name:";
            // 
            // textBoxUserEmailAddress
            // 
            this.textBoxUserEmailAddress.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceUserProfile, "MailAddress", true));
            this.textBoxUserEmailAddress.Location = new System.Drawing.Point(320, 181);
            this.textBoxUserEmailAddress.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.textBoxUserEmailAddress.Name = "textBoxUserEmailAddress";
            this.textBoxUserEmailAddress.Size = new System.Drawing.Size(831, 44);
            this.textBoxUserEmailAddress.TabIndex = 17;
            // 
            // bindingSourceUserProfile
            // 
            this.bindingSourceUserProfile.DataSource = typeof(UserProfiles.Model.UserProfile);
            // 
            // textBoxUserFullName
            // 
            this.textBoxUserFullName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceUserProfile, "Account", true));
            this.textBoxUserFullName.Location = new System.Drawing.Point(603, 112);
            this.textBoxUserFullName.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.textBoxUserFullName.Name = "textBoxUserFullName";
            this.textBoxUserFullName.Size = new System.Drawing.Size(548, 44);
            this.textBoxUserFullName.TabIndex = 18;
            // 
            // textBoxUserDomainName
            // 
            this.textBoxUserDomainName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceUserProfile, "DomainName", true));
            this.textBoxUserDomainName.Location = new System.Drawing.Point(320, 112);
            this.textBoxUserDomainName.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.textBoxUserDomainName.Name = "textBoxUserDomainName";
            this.textBoxUserDomainName.Size = new System.Drawing.Size(260, 44);
            this.textBoxUserDomainName.TabIndex = 19;
            // 
            // checkBoxIsUserAdmin
            // 
            this.checkBoxIsUserAdmin.AutoSize = true;
            this.checkBoxIsUserAdmin.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSourceUserProfile, "IsAdmin", true));
            this.checkBoxIsUserAdmin.Location = new System.Drawing.Point(320, 267);
            this.checkBoxIsUserAdmin.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.checkBoxIsUserAdmin.Name = "checkBoxIsUserAdmin";
            this.checkBoxIsUserAdmin.Size = new System.Drawing.Size(34, 33);
            this.checkBoxIsUserAdmin.TabIndex = 20;
            this.checkBoxIsUserAdmin.UseVisualStyleBackColor = true;
            // 
            // buttonEdit
            // 
            this.buttonEdit.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.bindingSourceUserProfile, "IsAdmin", true));
            this.buttonEdit.Location = new System.Drawing.Point(11, 57);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(243, 55);
            this.buttonEdit.TabIndex = 33;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(296, 57);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(243, 55);
            this.buttonSave.TabIndex = 34;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(576, 57);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(243, 55);
            this.buttonDelete.TabIndex = 35;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(861, 57);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(243, 55);
            this.buttonCancel.TabIndex = 36;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(1149, 57);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(243, 55);
            this.buttonClose.TabIndex = 37;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // labelUserProfileId
            // 
            this.labelUserProfileId.AutoSize = true;
            this.labelUserProfileId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceUserProfile, "Id", true));
            this.labelUserProfileId.Location = new System.Drawing.Point(315, 62);
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
            this.groupBoxProfileFields.Location = new System.Drawing.Point(24, 100);
            this.groupBoxProfileFields.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxProfileFields.Name = "groupBoxProfileFields";
            this.groupBoxProfileFields.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.groupBoxUserAccess.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxUserAccess.Name = "groupBoxUserAccess";
            this.groupBoxUserAccess.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxUserAccess.Size = new System.Drawing.Size(1901, 742);
            this.groupBoxUserAccess.TabIndex = 42;
            this.groupBoxUserAccess.TabStop = false;
            this.groupBoxUserAccess.Text = "User Access";
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
            this.dataGridViewUserSettings.DataSource = this.bindingSourceUserProfileSystemSetting;
            this.dataGridViewUserSettings.Location = new System.Drawing.Point(16, 52);
            this.dataGridViewUserSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewUserSettings.Name = "dataGridViewUserSettings";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewUserSettings.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewUserSettings.Size = new System.Drawing.Size(1872, 665);
            this.dataGridViewUserSettings.TabIndex = 38;
            // 
            // localSystemDataGridViewTextBoxColumn
            // 
            this.localSystemDataGridViewTextBoxColumn.DataPropertyName = "LocalSystem";
            this.localSystemDataGridViewTextBoxColumn.HeaderText = "System";
            this.localSystemDataGridViewTextBoxColumn.Name = "localSystemDataGridViewTextBoxColumn";
            this.localSystemDataGridViewTextBoxColumn.ReadOnly = true;
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
            this.branchDFDataGridViewCheckBoxColumn.DataPropertyName = "IsBranchDfActive";
            this.branchDFDataGridViewCheckBoxColumn.HeaderText = "DF";
            this.branchDFDataGridViewCheckBoxColumn.Name = "branchDFDataGridViewCheckBoxColumn";
            this.branchDFDataGridViewCheckBoxColumn.Width = 50;
            // 
            // categoryDataGridViewComboBoxColumn
            // 
            this.categoryDataGridViewComboBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.categoryDataGridViewComboBoxColumn.DataPropertyName = "Category";
            this.categoryDataGridViewComboBoxColumn.DataSource = this.bindingSourceUserLevelCategory;
            this.categoryDataGridViewComboBoxColumn.DisplayMember = "Name";
            this.categoryDataGridViewComboBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.categoryDataGridViewComboBoxColumn.HeaderText = "Permission";
            this.categoryDataGridViewComboBoxColumn.Name = "categoryDataGridViewComboBoxColumn";
            this.categoryDataGridViewComboBoxColumn.ValueMember = "Id";
            // 
            // bindingSourceUserLevelCategory
            // 
            this.bindingSourceUserLevelCategory.DataSource = typeof(UserProfiles.Model.UserLevelCategory);
            // 
            // bindingSourceUserProfileSystemSetting
            // 
            this.bindingSourceUserProfileSystemSetting.DataSource = typeof(UserProfiles.Model.UserProfileSystemSetting);
            // 
            // groupBoxActions
            // 
            this.groupBoxActions.Controls.Add(this.buttonEdit);
            this.groupBoxActions.Controls.Add(this.buttonSave);
            this.groupBoxActions.Controls.Add(this.buttonClose);
            this.groupBoxActions.Controls.Add(this.buttonDelete);
            this.groupBoxActions.Controls.Add(this.buttonCancel);
            this.groupBoxActions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxActions.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxActions.Location = new System.Drawing.Point(29, 1202);
            this.groupBoxActions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxActions.Name = "groupBoxActions";
            this.groupBoxActions.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxActions.Size = new System.Drawing.Size(1901, 141);
            this.groupBoxActions.TabIndex = 43;
            this.groupBoxActions.TabStop = false;
            this.groupBoxActions.Text = "Actions";
            // 
            // FormUserProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1968, 1366);
            this.Controls.Add(this.groupBoxActions);
            this.Controls.Add(this.groupBoxProfileFields);
            this.Controls.Add(this.lblFormheader);
            this.Controls.Add(this.groupBoxUserAccess);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "FormUserProfile";
            this.Text = "User Profile Entry Form";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUserProfile)).EndInit();
            this.groupBoxProfileFields.ResumeLayout(false);
            this.groupBoxProfileFields.PerformLayout();
            this.groupBoxUserAccess.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUserLevelCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUserProfileSystemSetting)).EndInit();
            this.groupBoxActions.ResumeLayout(false);
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
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelUserProfileId;
        private System.Windows.Forms.BindingSource bindingSourceUserProfileSystemSetting;
        private System.Windows.Forms.BindingSource bindingSourceUserLevelCategory;
        private System.Windows.Forms.GroupBox groupBoxProfileFields;
        private System.Windows.Forms.GroupBox groupBoxUserAccess;
        private System.Windows.Forms.GroupBox groupBoxActions;
        private System.Windows.Forms.DataGridView dataGridViewUserSettings;
        private System.Windows.Forms.BindingSource bindingSourceUserProfile;
        private System.Windows.Forms.DataGridViewTextBoxColumn localSystemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn branchLNDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn branchBRDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn branchPRDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn branchDFDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn categoryDataGridViewComboBoxColumn;
    }
}

