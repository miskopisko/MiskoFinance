namespace MPFinance.Forms.Panels
{
    partial class ChooseAccountPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseAccountPanel));
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            this.mMainTable_ = new System.Windows.Forms.TableLayoutPanel();
            this.mExistingAccounts_ = new System.Windows.Forms.CheckedListBox();
            this.mExistingAccount_ = new System.Windows.Forms.RadioButton();
            this.mCreateNewAccount_ = new System.Windows.Forms.RadioButton();
            this.mFieldsTable_ = new System.Windows.Forms.TableLayoutPanel();
            this.mNickname_ = new System.Windows.Forms.TextBox();
            this.mAccountNumber_ = new System.Windows.Forms.TextBox();
            this.mBankName_ = new System.Windows.Forms.TextBox();
            this.mAccountType_ = new System.Windows.Forms.ComboBox();
            this.mOpeningBalance_ = new MPFinance.Forms.Controls.MoneyBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            this.mMainTable_.SuspendLayout();
            this.mFieldsTable_.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // mMainTable_
            // 
            resources.ApplyResources(this.mMainTable_, "mMainTable_");
            this.mMainTable_.Controls.Add(this.mExistingAccounts_, 0, 1);
            this.mMainTable_.Controls.Add(this.mExistingAccount_, 0, 0);
            this.mMainTable_.Controls.Add(this.mCreateNewAccount_, 1, 0);
            this.mMainTable_.Controls.Add(this.mFieldsTable_, 1, 1);
            this.mMainTable_.Name = "mMainTable_";
            // 
            // mExistingAccounts_
            // 
            this.mExistingAccounts_.CheckOnClick = true;
            resources.ApplyResources(this.mExistingAccounts_, "mExistingAccounts_");
            this.mExistingAccounts_.FormattingEnabled = true;
            this.mExistingAccounts_.Name = "mExistingAccounts_";
            this.mExistingAccounts_.Sorted = true;
            this.mExistingAccounts_.ThreeDCheckBoxes = true;
            // 
            // mExistingAccount_
            // 
            resources.ApplyResources(this.mExistingAccount_, "mExistingAccount_");
            this.mExistingAccount_.Name = "mExistingAccount_";
            this.mExistingAccount_.TabStop = true;
            this.mExistingAccount_.UseVisualStyleBackColor = true;
            this.mExistingAccount_.CheckedChanged += new System.EventHandler(this.existingAccount_CheckedChanged);
            // 
            // mCreateNewAccount_
            // 
            resources.ApplyResources(this.mCreateNewAccount_, "mCreateNewAccount_");
            this.mCreateNewAccount_.Name = "mCreateNewAccount_";
            this.mCreateNewAccount_.TabStop = true;
            this.mCreateNewAccount_.UseVisualStyleBackColor = true;
            this.mCreateNewAccount_.CheckedChanged += new System.EventHandler(this.createNewAccount_CheckedChanged);
            // 
            // mFieldsTable_
            // 
            resources.ApplyResources(this.mFieldsTable_, "mFieldsTable_");
            this.mFieldsTable_.Controls.Add(label5, 0, 4);
            this.mFieldsTable_.Controls.Add(label4, 0, 3);
            this.mFieldsTable_.Controls.Add(this.mNickname_, 1, 3);
            this.mFieldsTable_.Controls.Add(label3, 0, 2);
            this.mFieldsTable_.Controls.Add(label2, 0, 1);
            this.mFieldsTable_.Controls.Add(this.mAccountNumber_, 1, 1);
            this.mFieldsTable_.Controls.Add(label1, 0, 0);
            this.mFieldsTable_.Controls.Add(this.mBankName_, 1, 0);
            this.mFieldsTable_.Controls.Add(this.mAccountType_, 1, 2);
            this.mFieldsTable_.Controls.Add(this.mOpeningBalance_, 1, 4);
            this.mFieldsTable_.Name = "mFieldsTable_";
            // 
            // mNickname_
            // 
            resources.ApplyResources(this.mNickname_, "mNickname_");
            this.mNickname_.Name = "mNickname_";
            // 
            // mAccountNumber_
            // 
            resources.ApplyResources(this.mAccountNumber_, "mAccountNumber_");
            this.mAccountNumber_.Name = "mAccountNumber_";
            // 
            // mBankName_
            // 
            resources.ApplyResources(this.mBankName_, "mBankName_");
            this.mBankName_.Name = "mBankName_";
            // 
            // mAccountType_
            // 
            resources.ApplyResources(this.mAccountType_, "mAccountType_");
            this.mAccountType_.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mAccountType_.FormattingEnabled = true;
            this.mAccountType_.Name = "mAccountType_";
            // 
            // mOpeningBalance_
            // 
            resources.ApplyResources(this.mOpeningBalance_, "mOpeningBalance_");
            this.mOpeningBalance_.ForeColor = System.Drawing.Color.Black;
            this.mOpeningBalance_.Name = "mOpeningBalance_";
            this.mOpeningBalance_.Value = ((MPersist.Core.MoneyType.Money)(resources.GetObject("mOpeningBalance_.Value")));
            // 
            // ChooseAccountPanel
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mMainTable_);
            this.Name = "ChooseAccountPanel";
            this.mMainTable_.ResumeLayout(false);
            this.mMainTable_.PerformLayout();
            this.mFieldsTable_.ResumeLayout(false);
            this.mFieldsTable_.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mMainTable_;
        public System.Windows.Forms.CheckedListBox mExistingAccounts_;
        public System.Windows.Forms.RadioButton mExistingAccount_;
        public System.Windows.Forms.RadioButton mCreateNewAccount_;
        public System.Windows.Forms.TableLayoutPanel mFieldsTable_;
        public System.Windows.Forms.TextBox mNickname_;
        public System.Windows.Forms.TextBox mAccountNumber_;
        public System.Windows.Forms.TextBox mBankName_;
        public System.Windows.Forms.ComboBox mAccountType_;
        public Controls.MoneyBox mOpeningBalance_;
    }
}
