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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsDialog));
        	this.label1 = new System.Windows.Forms.Label();
        	this.label2 = new System.Windows.Forms.Label();
        	this.label3 = new System.Windows.Forms.Label();
        	this.label4 = new System.Windows.Forms.Label();
        	this.label5 = new System.Windows.Forms.Label();
        	this.label6 = new System.Windows.Forms.Label();
        	this.label8 = new System.Windows.Forms.Label();
        	this.label7 = new System.Windows.Forms.Label();
        	this.label10 = new System.Windows.Forms.Label();
        	this.mSettingsTable_ = new System.Windows.Forms.TableLayoutPanel();
        	this.mPassword2_ = new System.Windows.Forms.TextBox();
        	this.mGender_ = new System.Windows.Forms.ComboBox();
        	this.mEmail_ = new System.Windows.Forms.TextBox();
        	this.mLastName_ = new System.Windows.Forms.TextBox();
        	this.mFirstName_ = new System.Windows.Forms.TextBox();
        	this.mPassword1_ = new System.Windows.Forms.TextBox();
        	this.mUsername_ = new System.Windows.Forms.TextBox();
        	this.mBirthday_ = new System.Windows.Forms.DateTimePicker();
        	this.mRowPerPage_ = new System.Windows.Forms.NumericUpDown();
        	this.mOKBtn_ = new System.Windows.Forms.Button();
        	this.mCancelBtn_ = new System.Windows.Forms.Button();
        	this.mMainTableLayoutPanel_ = new System.Windows.Forms.TableLayoutPanel();
        	this.mButtonFlowLayoutPanel_ = new System.Windows.Forms.FlowLayoutPanel();
        	this.mSettingsTable_.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.mRowPerPage_)).BeginInit();
        	this.mMainTableLayoutPanel_.SuspendLayout();
        	this.mButtonFlowLayoutPanel_.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// label1
        	// 
        	this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.label1.AutoSize = true;
        	this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
        	this.label1.Location = new System.Drawing.Point(3, 173);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(84, 13);
        	this.label1.TabIndex = 0;
        	this.label1.Text = "Last Name:";
        	this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// label2
        	// 
        	this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.label2.AutoSize = true;
        	this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
        	this.label2.Location = new System.Drawing.Point(3, 13);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(84, 13);
        	this.label2.TabIndex = 1;
        	this.label2.Text = "Username:";
        	this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// label3
        	// 
        	this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.label3.AutoSize = true;
        	this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
        	this.label3.Location = new System.Drawing.Point(3, 53);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(84, 13);
        	this.label3.TabIndex = 2;
        	this.label3.Text = "Password:";
        	this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// label4
        	// 
        	this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.label4.AutoSize = true;
        	this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
        	this.label4.Location = new System.Drawing.Point(3, 213);
        	this.label4.Name = "label4";
        	this.label4.Size = new System.Drawing.Size(84, 13);
        	this.label4.TabIndex = 3;
        	this.label4.Text = "Email:";
        	this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// label5
        	// 
        	this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.label5.AutoSize = true;
        	this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
        	this.label5.Location = new System.Drawing.Point(3, 133);
        	this.label5.Name = "label5";
        	this.label5.Size = new System.Drawing.Size(84, 13);
        	this.label5.TabIndex = 4;
        	this.label5.Text = "First Name:";
        	this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// label6
        	// 
        	this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.label6.AutoSize = true;
        	this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
        	this.label6.Location = new System.Drawing.Point(3, 254);
        	this.label6.Name = "label6";
        	this.label6.Size = new System.Drawing.Size(84, 13);
        	this.label6.TabIndex = 5;
        	this.label6.Text = "Gender:";
        	this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// label8
        	// 
        	this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.label8.AutoSize = true;
        	this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
        	this.label8.Location = new System.Drawing.Point(3, 334);
        	this.label8.Name = "label8";
        	this.label8.Size = new System.Drawing.Size(84, 13);
        	this.label8.TabIndex = 7;
        	this.label8.Text = "Rows Per Page:";
        	this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// label7
        	// 
        	this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.label7.AutoSize = true;
        	this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
        	this.label7.Location = new System.Drawing.Point(3, 294);
        	this.label7.Name = "label7";
        	this.label7.Size = new System.Drawing.Size(84, 13);
        	this.label7.TabIndex = 6;
        	this.label7.Text = "Birthday:";
        	this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// label10
        	// 
        	this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.label10.AutoSize = true;
        	this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
        	this.label10.Location = new System.Drawing.Point(3, 93);
        	this.label10.Name = "label10";
        	this.label10.Size = new System.Drawing.Size(84, 13);
        	this.label10.TabIndex = 19;
        	this.label10.Text = "Repeat:";
        	this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// mSettingsTable_
        	// 
        	this.mSettingsTable_.AutoSize = true;
        	this.mSettingsTable_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        	this.mSettingsTable_.ColumnCount = 2;
        	this.mSettingsTable_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        	this.mSettingsTable_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        	this.mSettingsTable_.Controls.Add(this.label10, 0, 2);
        	this.mSettingsTable_.Controls.Add(this.mPassword2_, 1, 2);
        	this.mSettingsTable_.Controls.Add(this.label8, 0, 8);
        	this.mSettingsTable_.Controls.Add(this.label7, 0, 7);
        	this.mSettingsTable_.Controls.Add(this.label6, 0, 6);
        	this.mSettingsTable_.Controls.Add(this.label5, 0, 3);
        	this.mSettingsTable_.Controls.Add(this.label4, 0, 5);
        	this.mSettingsTable_.Controls.Add(this.label3, 0, 1);
        	this.mSettingsTable_.Controls.Add(this.label2, 0, 0);
        	this.mSettingsTable_.Controls.Add(this.label1, 0, 4);
        	this.mSettingsTable_.Controls.Add(this.mGender_, 1, 6);
        	this.mSettingsTable_.Controls.Add(this.mEmail_, 1, 5);
        	this.mSettingsTable_.Controls.Add(this.mLastName_, 1, 4);
        	this.mSettingsTable_.Controls.Add(this.mFirstName_, 1, 3);
        	this.mSettingsTable_.Controls.Add(this.mPassword1_, 1, 1);
        	this.mSettingsTable_.Controls.Add(this.mUsername_, 1, 0);
        	this.mSettingsTable_.Controls.Add(this.mBirthday_, 1, 7);
        	this.mSettingsTable_.Controls.Add(this.mRowPerPage_, 1, 8);
        	this.mSettingsTable_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mSettingsTable_.Location = new System.Drawing.Point(3, 3);
        	this.mSettingsTable_.Name = "mSettingsTable_";
        	this.mSettingsTable_.RowCount = 9;
        	this.mSettingsTable_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mSettingsTable_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mSettingsTable_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mSettingsTable_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mSettingsTable_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mSettingsTable_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mSettingsTable_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mSettingsTable_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mSettingsTable_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mSettingsTable_.Size = new System.Drawing.Size(349, 361);
        	this.mSettingsTable_.TabIndex = 0;
        	// 
        	// mPassword2_
        	// 
        	this.mPassword2_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mPassword2_.Location = new System.Drawing.Point(93, 90);
        	this.mPassword2_.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
        	this.mPassword2_.Name = "mPassword2_";
        	this.mPassword2_.PasswordChar = '*';
        	this.mPassword2_.Size = new System.Drawing.Size(253, 20);
        	this.mPassword2_.TabIndex = 3;
        	// 
        	// mGender_
        	// 
        	this.mGender_.DisplayMember = "Description";
        	this.mGender_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mGender_.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.mGender_.FormattingEnabled = true;
        	this.mGender_.Location = new System.Drawing.Point(93, 250);
        	this.mGender_.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
        	this.mGender_.Name = "mGender_";
        	this.mGender_.Size = new System.Drawing.Size(253, 21);
        	this.mGender_.TabIndex = 7;
        	this.mGender_.ValueMember = "Value";
        	// 
        	// mEmail_
        	// 
        	this.mEmail_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mEmail_.Location = new System.Drawing.Point(93, 210);
        	this.mEmail_.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
        	this.mEmail_.Name = "mEmail_";
        	this.mEmail_.Size = new System.Drawing.Size(253, 20);
        	this.mEmail_.TabIndex = 6;
        	// 
        	// mLastName_
        	// 
        	this.mLastName_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mLastName_.Location = new System.Drawing.Point(93, 170);
        	this.mLastName_.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
        	this.mLastName_.Name = "mLastName_";
        	this.mLastName_.Size = new System.Drawing.Size(253, 20);
        	this.mLastName_.TabIndex = 5;
        	// 
        	// mFirstName_
        	// 
        	this.mFirstName_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mFirstName_.Location = new System.Drawing.Point(93, 130);
        	this.mFirstName_.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
        	this.mFirstName_.Name = "mFirstName_";
        	this.mFirstName_.Size = new System.Drawing.Size(253, 20);
        	this.mFirstName_.TabIndex = 4;
        	// 
        	// mPassword1_
        	// 
        	this.mPassword1_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mPassword1_.Location = new System.Drawing.Point(93, 50);
        	this.mPassword1_.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
        	this.mPassword1_.Name = "mPassword1_";
        	this.mPassword1_.PasswordChar = '*';
        	this.mPassword1_.Size = new System.Drawing.Size(253, 20);
        	this.mPassword1_.TabIndex = 2;
        	// 
        	// mUsername_
        	// 
        	this.mUsername_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mUsername_.Enabled = false;
        	this.mUsername_.Location = new System.Drawing.Point(93, 10);
        	this.mUsername_.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
        	this.mUsername_.Name = "mUsername_";
        	this.mUsername_.ReadOnly = true;
        	this.mUsername_.Size = new System.Drawing.Size(253, 20);
        	this.mUsername_.TabIndex = 1;
        	// 
        	// mBirthday_
        	// 
        	this.mBirthday_.CustomFormat = "MMMM dd, yyyy";
        	this.mBirthday_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mBirthday_.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        	this.mBirthday_.Location = new System.Drawing.Point(93, 291);
        	this.mBirthday_.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
        	this.mBirthday_.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
        	this.mBirthday_.Name = "mBirthday_";
        	this.mBirthday_.ShowUpDown = true;
        	this.mBirthday_.Size = new System.Drawing.Size(253, 20);
        	this.mBirthday_.TabIndex = 8;
        	// 
        	// mRowPerPage_
        	// 
        	this.mRowPerPage_.AutoSize = true;
        	this.mRowPerPage_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mRowPerPage_.Location = new System.Drawing.Point(93, 331);
        	this.mRowPerPage_.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
        	this.mRowPerPage_.Name = "mRowPerPage_";
        	this.mRowPerPage_.Size = new System.Drawing.Size(253, 20);
        	this.mRowPerPage_.TabIndex = 9;
        	this.mRowPerPage_.Value = new decimal(new int[] {
			15,
			0,
			0,
			0});
        	// 
        	// mOKBtn_
        	// 
        	this.mOKBtn_.Location = new System.Drawing.Point(190, 3);
        	this.mOKBtn_.Name = "mOKBtn_";
        	this.mOKBtn_.Size = new System.Drawing.Size(75, 23);
        	this.mOKBtn_.TabIndex = 12;
        	this.mOKBtn_.Text = "OK";
        	this.mOKBtn_.UseVisualStyleBackColor = true;
        	this.mOKBtn_.Click += new System.EventHandler(this.mOKBtn__Click);
        	// 
        	// mCancelBtn_
        	// 
        	this.mCancelBtn_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        	this.mCancelBtn_.Location = new System.Drawing.Point(271, 3);
        	this.mCancelBtn_.Name = "mCancelBtn_";
        	this.mCancelBtn_.Size = new System.Drawing.Size(75, 23);
        	this.mCancelBtn_.TabIndex = 11;
        	this.mCancelBtn_.Text = "Cancel";
        	this.mCancelBtn_.UseVisualStyleBackColor = true;
        	this.mCancelBtn_.Click += new System.EventHandler(this.mCancelBtn__Click);
        	// 
        	// mMainTableLayoutPanel_
        	// 
        	this.mMainTableLayoutPanel_.AutoSize = true;
        	this.mMainTableLayoutPanel_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        	this.mMainTableLayoutPanel_.ColumnCount = 1;
        	this.mMainTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        	this.mMainTableLayoutPanel_.Controls.Add(this.mSettingsTable_, 0, 0);
        	this.mMainTableLayoutPanel_.Controls.Add(this.mButtonFlowLayoutPanel_, 0, 1);
        	this.mMainTableLayoutPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mMainTableLayoutPanel_.Location = new System.Drawing.Point(0, 0);
        	this.mMainTableLayoutPanel_.Name = "mMainTableLayoutPanel_";
        	this.mMainTableLayoutPanel_.RowCount = 2;
        	this.mMainTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mMainTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mMainTableLayoutPanel_.Size = new System.Drawing.Size(352, 404);
        	this.mMainTableLayoutPanel_.TabIndex = 1;
        	// 
        	// mButtonFlowLayoutPanel_
        	// 
        	this.mButtonFlowLayoutPanel_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mButtonFlowLayoutPanel_.AutoSize = true;
        	this.mButtonFlowLayoutPanel_.Controls.Add(this.mCancelBtn_);
        	this.mButtonFlowLayoutPanel_.Controls.Add(this.mOKBtn_);
        	this.mButtonFlowLayoutPanel_.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
        	this.mButtonFlowLayoutPanel_.Location = new System.Drawing.Point(3, 371);
        	this.mButtonFlowLayoutPanel_.Name = "mButtonFlowLayoutPanel_";
        	this.mButtonFlowLayoutPanel_.Size = new System.Drawing.Size(349, 29);
        	this.mButtonFlowLayoutPanel_.TabIndex = 0;
        	// 
        	// SettingsDialog
        	// 
        	this.AcceptButton = this.mOKBtn_;
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.AutoSize = true;
        	this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        	this.CancelButton = this.mCancelBtn_;
        	this.ClientSize = new System.Drawing.Size(352, 404);
        	this.Controls.Add(this.mMainTableLayoutPanel_);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.MaximizeBox = false;
        	this.MinimizeBox = false;
        	this.Name = "SettingsDialog";
        	this.ShowInTaskbar = false;
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Settings";
        	this.mSettingsTable_.ResumeLayout(false);
        	this.mSettingsTable_.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.mRowPerPage_)).EndInit();
        	this.mMainTableLayoutPanel_.ResumeLayout(false);
        	this.mMainTableLayoutPanel_.PerformLayout();
        	this.mButtonFlowLayoutPanel_.ResumeLayout(false);
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mSettingsTable_;
        private System.Windows.Forms.ComboBox mGender_;
        private System.Windows.Forms.TextBox mEmail_;
        private System.Windows.Forms.TextBox mLastName_;
        private System.Windows.Forms.TextBox mFirstName_;
        private System.Windows.Forms.TextBox mPassword1_;
        private System.Windows.Forms.TextBox mUsername_;
        private System.Windows.Forms.DateTimePicker mBirthday_;
        private System.Windows.Forms.TextBox mPassword2_;
        private System.Windows.Forms.Button mOKBtn_;
        private System.Windows.Forms.Button mCancelBtn_;
        private System.Windows.Forms.NumericUpDown mRowPerPage_;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TableLayoutPanel mMainTableLayoutPanel_;
        private System.Windows.Forms.FlowLayoutPanel mButtonFlowLayoutPanel_;
    }
}