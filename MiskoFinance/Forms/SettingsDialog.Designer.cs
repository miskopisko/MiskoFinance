using System;
namespace MiskoFinance.Forms
{
	partial class SettingsDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(Boolean disposing)
        {
            if(disposing && (components != null))
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsDialog));
        	this.mLastNameLbl = new System.Windows.Forms.Label();
        	this.mUsernameLbl_ = new System.Windows.Forms.Label();
        	this.mPassword1Lbl_ = new System.Windows.Forms.Label();
        	this.mEmailLbl_ = new System.Windows.Forms.Label();
        	this.mFirstNameLbl_ = new System.Windows.Forms.Label();
        	this.mGenderLbl_ = new System.Windows.Forms.Label();
        	this.mRowsLbl_ = new System.Windows.Forms.Label();
        	this.mBirthdayLbl_ = new System.Windows.Forms.Label();
        	this.mPassword2Lbl_ = new System.Windows.Forms.Label();
        	this.mPassword2_ = new System.Windows.Forms.TextBox();
        	this.mGender_ = new System.Windows.Forms.ComboBox();
        	this.mEmail_ = new System.Windows.Forms.TextBox();
        	this.mLastName_ = new System.Windows.Forms.TextBox();
        	this.mFirstName_ = new System.Windows.Forms.TextBox();
        	this.mPassword1_ = new System.Windows.Forms.TextBox();
        	this.mUsername_ = new System.Windows.Forms.TextBox();
        	this.mBirthday_ = new System.Windows.Forms.DateTimePicker();
        	this.mRowPerPage_ = new System.Windows.Forms.NumericUpDown();
        	this.mSettingsTableLayoutPanel_ = new System.Windows.Forms.TableLayoutPanel();
        	this.mFlowLayoutPanel_ = new System.Windows.Forms.FlowLayoutPanel();
        	this.mZeroEqallLbl_ = new System.Windows.Forms.Label();
        	this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        	this.mOK_ = new System.Windows.Forms.Button();
        	this.mCancel_ = new System.Windows.Forms.Button();
        	((System.ComponentModel.ISupportInitialize)(this.mRowPerPage_)).BeginInit();
        	this.mSettingsTableLayoutPanel_.SuspendLayout();
        	this.mFlowLayoutPanel_.SuspendLayout();
        	this.tableLayoutPanel1.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// mLastNameLbl
        	// 
        	this.mLastNameLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mLastNameLbl.AutoSize = true;
        	this.mLastNameLbl.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
        	this.mLastNameLbl.Location = new System.Drawing.Point(3, 110);
        	this.mLastNameLbl.Name = "mLastNameLbl";
        	this.mLastNameLbl.Size = new System.Drawing.Size(67, 13);
        	this.mLastNameLbl.TabIndex = 0;
        	this.mLastNameLbl.Text = "Last Name:";
        	this.mLastNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// mUsernameLbl_
        	// 
        	this.mUsernameLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mUsernameLbl_.AutoSize = true;
        	this.mUsernameLbl_.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
        	this.mUsernameLbl_.Location = new System.Drawing.Point(3, 6);
        	this.mUsernameLbl_.Name = "mUsernameLbl_";
        	this.mUsernameLbl_.Size = new System.Drawing.Size(67, 13);
        	this.mUsernameLbl_.TabIndex = 1;
        	this.mUsernameLbl_.Text = "Username:";
        	this.mUsernameLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// mPassword1Lbl_
        	// 
        	this.mPassword1Lbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mPassword1Lbl_.AutoSize = true;
        	this.mPassword1Lbl_.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
        	this.mPassword1Lbl_.Location = new System.Drawing.Point(3, 32);
        	this.mPassword1Lbl_.Name = "mPassword1Lbl_";
        	this.mPassword1Lbl_.Size = new System.Drawing.Size(67, 13);
        	this.mPassword1Lbl_.TabIndex = 2;
        	this.mPassword1Lbl_.Text = "Password:";
        	this.mPassword1Lbl_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// mEmailLbl_
        	// 
        	this.mEmailLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mEmailLbl_.AutoSize = true;
        	this.mEmailLbl_.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
        	this.mEmailLbl_.Location = new System.Drawing.Point(3, 136);
        	this.mEmailLbl_.Name = "mEmailLbl_";
        	this.mEmailLbl_.Size = new System.Drawing.Size(67, 13);
        	this.mEmailLbl_.TabIndex = 3;
        	this.mEmailLbl_.Text = "Email:";
        	this.mEmailLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// mFirstNameLbl_
        	// 
        	this.mFirstNameLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mFirstNameLbl_.AutoSize = true;
        	this.mFirstNameLbl_.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
        	this.mFirstNameLbl_.Location = new System.Drawing.Point(3, 84);
        	this.mFirstNameLbl_.Name = "mFirstNameLbl_";
        	this.mFirstNameLbl_.Size = new System.Drawing.Size(67, 13);
        	this.mFirstNameLbl_.TabIndex = 4;
        	this.mFirstNameLbl_.Text = "First Name:";
        	this.mFirstNameLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// mGenderLbl_
        	// 
        	this.mGenderLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mGenderLbl_.AutoSize = true;
        	this.mGenderLbl_.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
        	this.mGenderLbl_.Location = new System.Drawing.Point(3, 163);
        	this.mGenderLbl_.Name = "mGenderLbl_";
        	this.mGenderLbl_.Size = new System.Drawing.Size(67, 13);
        	this.mGenderLbl_.TabIndex = 5;
        	this.mGenderLbl_.Text = "Gender:";
        	this.mGenderLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// mRowsLbl_
        	// 
        	this.mRowsLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mRowsLbl_.AutoSize = true;
        	this.mRowsLbl_.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
        	this.mRowsLbl_.Location = new System.Drawing.Point(3, 218);
        	this.mRowsLbl_.Name = "mRowsLbl_";
        	this.mRowsLbl_.Size = new System.Drawing.Size(67, 13);
        	this.mRowsLbl_.TabIndex = 7;
        	this.mRowsLbl_.Text = "Rows/Page:";
        	this.mRowsLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// mBirthdayLbl_
        	// 
        	this.mBirthdayLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mBirthdayLbl_.AutoSize = true;
        	this.mBirthdayLbl_.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
        	this.mBirthdayLbl_.Location = new System.Drawing.Point(3, 189);
        	this.mBirthdayLbl_.Name = "mBirthdayLbl_";
        	this.mBirthdayLbl_.Size = new System.Drawing.Size(67, 13);
        	this.mBirthdayLbl_.TabIndex = 6;
        	this.mBirthdayLbl_.Text = "Birthday:";
        	this.mBirthdayLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// mPassword2Lbl_
        	// 
        	this.mPassword2Lbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mPassword2Lbl_.AutoSize = true;
        	this.mPassword2Lbl_.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
        	this.mPassword2Lbl_.Location = new System.Drawing.Point(3, 58);
        	this.mPassword2Lbl_.Name = "mPassword2Lbl_";
        	this.mPassword2Lbl_.Size = new System.Drawing.Size(67, 13);
        	this.mPassword2Lbl_.TabIndex = 19;
        	this.mPassword2Lbl_.Text = "Repeat:";
        	this.mPassword2Lbl_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// mPassword2_
        	// 
        	this.mPassword2_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mPassword2_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.mPassword2_.Location = new System.Drawing.Point(76, 55);
        	this.mPassword2_.Name = "mPassword2_";
        	this.mPassword2_.PasswordChar = '*';
        	this.mPassword2_.Size = new System.Drawing.Size(194, 20);
        	this.mPassword2_.TabIndex = 3;
        	// 
        	// mGender_
        	// 
        	this.mGender_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mGender_.DisplayMember = "Description";
        	this.mGender_.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.mGender_.FormattingEnabled = true;
        	this.mGender_.Location = new System.Drawing.Point(76, 159);
        	this.mGender_.Name = "mGender_";
        	this.mGender_.Size = new System.Drawing.Size(194, 21);
        	this.mGender_.TabIndex = 7;
        	this.mGender_.ValueMember = "Value";
        	// 
        	// mEmail_
        	// 
        	this.mEmail_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mEmail_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.mEmail_.Location = new System.Drawing.Point(76, 133);
        	this.mEmail_.Name = "mEmail_";
        	this.mEmail_.Size = new System.Drawing.Size(194, 20);
        	this.mEmail_.TabIndex = 6;
        	// 
        	// mLastName_
        	// 
        	this.mLastName_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mLastName_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.mLastName_.Location = new System.Drawing.Point(76, 107);
        	this.mLastName_.Name = "mLastName_";
        	this.mLastName_.Size = new System.Drawing.Size(194, 20);
        	this.mLastName_.TabIndex = 5;
        	// 
        	// mFirstName_
        	// 
        	this.mFirstName_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mFirstName_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.mFirstName_.Location = new System.Drawing.Point(76, 81);
        	this.mFirstName_.Name = "mFirstName_";
        	this.mFirstName_.Size = new System.Drawing.Size(194, 20);
        	this.mFirstName_.TabIndex = 4;
        	// 
        	// mPassword1_
        	// 
        	this.mPassword1_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mPassword1_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.mPassword1_.Location = new System.Drawing.Point(76, 29);
        	this.mPassword1_.Name = "mPassword1_";
        	this.mPassword1_.PasswordChar = '*';
        	this.mPassword1_.Size = new System.Drawing.Size(194, 20);
        	this.mPassword1_.TabIndex = 2;
        	// 
        	// mUsername_
        	// 
        	this.mUsername_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mUsername_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.mUsername_.Enabled = false;
        	this.mUsername_.Location = new System.Drawing.Point(76, 3);
        	this.mUsername_.Name = "mUsername_";
        	this.mUsername_.ReadOnly = true;
        	this.mUsername_.Size = new System.Drawing.Size(194, 20);
        	this.mUsername_.TabIndex = 1;
        	// 
        	// mBirthday_
        	// 
        	this.mBirthday_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mBirthday_.CustomFormat = "MMMM dd, yyyy";
        	this.mBirthday_.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        	this.mBirthday_.Location = new System.Drawing.Point(76, 186);
        	this.mBirthday_.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
        	this.mBirthday_.Name = "mBirthday_";
        	this.mBirthday_.Size = new System.Drawing.Size(194, 20);
        	this.mBirthday_.TabIndex = 8;
        	// 
        	// mRowPerPage_
        	// 
        	this.mRowPerPage_.AutoSize = true;
        	this.mRowPerPage_.Dock = System.Windows.Forms.DockStyle.Left;
        	this.mRowPerPage_.Location = new System.Drawing.Point(3, 3);
        	this.mRowPerPage_.Name = "mRowPerPage_";
        	this.mRowPerPage_.Size = new System.Drawing.Size(41, 20);
        	this.mRowPerPage_.TabIndex = 9;
        	this.mRowPerPage_.Value = new decimal(new int[] {
			15,
			0,
			0,
			0});
        	// 
        	// mSettingsTableLayoutPanel_
        	// 
        	this.mSettingsTableLayoutPanel_.AutoSize = true;
        	this.mSettingsTableLayoutPanel_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        	this.mSettingsTableLayoutPanel_.ColumnCount = 2;
        	this.mSettingsTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        	this.mSettingsTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
        	this.mSettingsTableLayoutPanel_.Controls.Add(this.mRowsLbl_, 0, 8);
        	this.mSettingsTableLayoutPanel_.Controls.Add(this.mPassword2Lbl_, 0, 2);
        	this.mSettingsTableLayoutPanel_.Controls.Add(this.mBirthdayLbl_, 0, 7);
        	this.mSettingsTableLayoutPanel_.Controls.Add(this.mUsernameLbl_, 0, 0);
        	this.mSettingsTableLayoutPanel_.Controls.Add(this.mBirthday_, 1, 7);
        	this.mSettingsTableLayoutPanel_.Controls.Add(this.mGenderLbl_, 0, 6);
        	this.mSettingsTableLayoutPanel_.Controls.Add(this.mUsername_, 1, 0);
        	this.mSettingsTableLayoutPanel_.Controls.Add(this.mGender_, 1, 6);
        	this.mSettingsTableLayoutPanel_.Controls.Add(this.mEmailLbl_, 0, 5);
        	this.mSettingsTableLayoutPanel_.Controls.Add(this.mFirstNameLbl_, 0, 3);
        	this.mSettingsTableLayoutPanel_.Controls.Add(this.mLastNameLbl, 0, 4);
        	this.mSettingsTableLayoutPanel_.Controls.Add(this.mEmail_, 1, 5);
        	this.mSettingsTableLayoutPanel_.Controls.Add(this.mPassword1_, 1, 1);
        	this.mSettingsTableLayoutPanel_.Controls.Add(this.mPassword2_, 1, 2);
        	this.mSettingsTableLayoutPanel_.Controls.Add(this.mPassword1Lbl_, 0, 1);
        	this.mSettingsTableLayoutPanel_.Controls.Add(this.mLastName_, 1, 4);
        	this.mSettingsTableLayoutPanel_.Controls.Add(this.mFirstName_, 1, 3);
        	this.mSettingsTableLayoutPanel_.Controls.Add(this.mFlowLayoutPanel_, 1, 8);
        	this.mSettingsTableLayoutPanel_.Controls.Add(this.tableLayoutPanel1, 1, 9);
        	this.mSettingsTableLayoutPanel_.Location = new System.Drawing.Point(0, 0);
        	this.mSettingsTableLayoutPanel_.Name = "mSettingsTableLayoutPanel_";
        	this.mSettingsTableLayoutPanel_.RowCount = 10;
        	this.mSettingsTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mSettingsTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mSettingsTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mSettingsTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mSettingsTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mSettingsTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mSettingsTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mSettingsTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mSettingsTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mSettingsTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mSettingsTableLayoutPanel_.Size = new System.Drawing.Size(273, 276);
        	this.mSettingsTableLayoutPanel_.TabIndex = 1;
        	// 
        	// mFlowLayoutPanel_
        	// 
        	this.mFlowLayoutPanel_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mFlowLayoutPanel_.AutoSize = true;
        	this.mFlowLayoutPanel_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        	this.mFlowLayoutPanel_.Controls.Add(this.mRowPerPage_);
        	this.mFlowLayoutPanel_.Controls.Add(this.mZeroEqallLbl_);
        	this.mFlowLayoutPanel_.Location = new System.Drawing.Point(76, 212);
        	this.mFlowLayoutPanel_.Name = "mFlowLayoutPanel_";
        	this.mFlowLayoutPanel_.Size = new System.Drawing.Size(194, 26);
        	this.mFlowLayoutPanel_.TabIndex = 20;
        	// 
        	// mZeroEqallLbl_
        	// 
        	this.mZeroEqallLbl_.AutoSize = true;
        	this.mZeroEqallLbl_.Dock = System.Windows.Forms.DockStyle.Left;
        	this.mZeroEqallLbl_.Location = new System.Drawing.Point(50, 0);
        	this.mZeroEqallLbl_.Name = "mZeroEqallLbl_";
        	this.mZeroEqallLbl_.Size = new System.Drawing.Size(39, 26);
        	this.mZeroEqallLbl_.TabIndex = 10;
        	this.mZeroEqallLbl_.Text = "0 = All ";
        	this.mZeroEqallLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// tableLayoutPanel1
        	// 
        	this.tableLayoutPanel1.AutoSize = true;
        	this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        	this.tableLayoutPanel1.ColumnCount = 2;
        	this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        	this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        	this.tableLayoutPanel1.Controls.Add(this.mOK_, 0, 0);
        	this.tableLayoutPanel1.Controls.Add(this.mCancel_, 1, 0);
        	this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
        	this.tableLayoutPanel1.Location = new System.Drawing.Point(108, 244);
        	this.tableLayoutPanel1.Name = "tableLayoutPanel1";
        	this.tableLayoutPanel1.RowCount = 1;
        	this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        	this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
        	this.tableLayoutPanel1.Size = new System.Drawing.Size(162, 29);
        	this.tableLayoutPanel1.TabIndex = 21;
        	// 
        	// mOK_
        	// 
        	this.mOK_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mOK_.Location = new System.Drawing.Point(3, 3);
        	this.mOK_.Name = "mOK_";
        	this.mOK_.Size = new System.Drawing.Size(75, 23);
        	this.mOK_.TabIndex = 0;
        	this.mOK_.Text = "OK";
        	this.mOK_.UseVisualStyleBackColor = true;
        	this.mOK_.Click += new System.EventHandler(this.mOK__Click);
        	// 
        	// mCancel_
        	// 
        	this.mCancel_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mCancel_.Location = new System.Drawing.Point(84, 3);
        	this.mCancel_.Name = "mCancel_";
        	this.mCancel_.Size = new System.Drawing.Size(75, 23);
        	this.mCancel_.TabIndex = 1;
        	this.mCancel_.Text = "Cancel";
        	this.mCancel_.UseVisualStyleBackColor = true;
        	this.mCancel_.Click += new System.EventHandler(this.mCancel__Click);
        	// 
        	// SettingsDialog
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.AutoSize = true;
        	this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        	this.ClientSize = new System.Drawing.Size(342, 340);
        	this.Controls.Add(this.mSettingsTableLayoutPanel_);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.MaximizeBox = false;
        	this.MinimizeBox = false;
        	this.Name = "SettingsDialog";
        	this.ShowInTaskbar = false;
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        	this.Text = "Settings";
        	((System.ComponentModel.ISupportInitialize)(this.mRowPerPage_)).EndInit();
        	this.mSettingsTableLayoutPanel_.ResumeLayout(false);
        	this.mSettingsTableLayoutPanel_.PerformLayout();
        	this.mFlowLayoutPanel_.ResumeLayout(false);
        	this.mFlowLayoutPanel_.PerformLayout();
        	this.tableLayoutPanel1.ResumeLayout(false);
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox mGender_;
        private System.Windows.Forms.TextBox mEmail_;
        private System.Windows.Forms.TextBox mLastName_;
        private System.Windows.Forms.TextBox mFirstName_;
        private System.Windows.Forms.TextBox mPassword1_;
        private System.Windows.Forms.TextBox mUsername_;
        private System.Windows.Forms.DateTimePicker mBirthday_;
        private System.Windows.Forms.TextBox mPassword2_;
        private System.Windows.Forms.NumericUpDown mRowPerPage_;
        private System.Windows.Forms.Label mLastNameLbl;
        private System.Windows.Forms.Label mUsernameLbl_;
        private System.Windows.Forms.Label mPassword1Lbl_;
        private System.Windows.Forms.Label mEmailLbl_;
        private System.Windows.Forms.Label mFirstNameLbl_;
        private System.Windows.Forms.Label mGenderLbl_;
        private System.Windows.Forms.Label mRowsLbl_;
        private System.Windows.Forms.Label mBirthdayLbl_;
        private System.Windows.Forms.Label mPassword2Lbl_;
        private System.Windows.Forms.TableLayoutPanel mSettingsTableLayoutPanel_;
        private System.Windows.Forms.FlowLayoutPanel mFlowLayoutPanel_;
        private System.Windows.Forms.Label mZeroEqallLbl_;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button mOK_;
        private System.Windows.Forms.Button mCancel_;
    }
}