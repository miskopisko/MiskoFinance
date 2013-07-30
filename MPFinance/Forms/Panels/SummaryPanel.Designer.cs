namespace MPFinance.Forms.Panels
{
    partial class SummaryPanel
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
            System.Windows.Forms.Label label0;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label3;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SummaryPanel));
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label10;
            this.mSummaryLayoutTable_ = new System.Windows.Forms.TableLayoutPanel();
            this.mSummaryBox_ = new System.Windows.Forms.GroupBox();
            this.mSummaryTable_ = new System.Windows.Forms.TableLayoutPanel();
            this.TotalCredits = new MPFinance.Forms.Controls.MoneyBox();
            this.TotalDebits = new MPFinance.Forms.Controls.MoneyBox();
            this.CreditsDebitsDiff = new MPFinance.Forms.Controls.MoneyBox();
            this.TotalTransferIn = new MPFinance.Forms.Controls.MoneyBox();
            this.TotalTransferOut = new MPFinance.Forms.Controls.MoneyBox();
            this.TransfersDiff = new MPFinance.Forms.Controls.MoneyBox();
            this.mAllTimeGroupBox_ = new System.Windows.Forms.GroupBox();
            this.mAllTimeTableLayout_ = new System.Windows.Forms.TableLayoutPanel();
            this.OpeningBalance = new MPFinance.Forms.Controls.MoneyBox();
            this.CurrentBalance = new MPFinance.Forms.Controls.MoneyBox();
            this.BalanceDiff = new MPFinance.Forms.Controls.MoneyBox();
            label0 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            this.mSummaryLayoutTable_.SuspendLayout();
            this.mSummaryBox_.SuspendLayout();
            this.mSummaryTable_.SuspendLayout();
            this.mAllTimeGroupBox_.SuspendLayout();
            this.mAllTimeTableLayout_.SuspendLayout();
            this.SuspendLayout();
            // 
            // mSummaryLayoutTable_
            // 
            this.mSummaryLayoutTable_.ColumnCount = 1;
            this.mSummaryLayoutTable_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mSummaryLayoutTable_.Controls.Add(this.mSummaryBox_, 0, 0);
            this.mSummaryLayoutTable_.Controls.Add(this.mAllTimeGroupBox_, 0, 1);
            this.mSummaryLayoutTable_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mSummaryLayoutTable_.Location = new System.Drawing.Point(0, 0);
            this.mSummaryLayoutTable_.Name = "mSummaryLayoutTable_";
            this.mSummaryLayoutTable_.RowCount = 2;
            this.mSummaryLayoutTable_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.mSummaryLayoutTable_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.mSummaryLayoutTable_.Size = new System.Drawing.Size(224, 340);
            this.mSummaryLayoutTable_.TabIndex = 12;
            // 
            // mSummaryBox_
            // 
            this.mSummaryBox_.Controls.Add(this.mSummaryTable_);
            this.mSummaryBox_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mSummaryBox_.Location = new System.Drawing.Point(3, 3);
            this.mSummaryBox_.Name = "mSummaryBox_";
            this.mSummaryBox_.Size = new System.Drawing.Size(218, 198);
            this.mSummaryBox_.TabIndex = 0;
            this.mSummaryBox_.TabStop = false;
            this.mSummaryBox_.Text = "Summary";
            // 
            // mSummaryTable_
            // 
            this.mSummaryTable_.ColumnCount = 2;
            this.mSummaryTable_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mSummaryTable_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mSummaryTable_.Controls.Add(label3, 0, 5);
            this.mSummaryTable_.Controls.Add(label0, 0, 0);
            this.mSummaryTable_.Controls.Add(label4, 0, 1);
            this.mSummaryTable_.Controls.Add(label1, 0, 2);
            this.mSummaryTable_.Controls.Add(label2, 0, 3);
            this.mSummaryTable_.Controls.Add(label5, 0, 4);
            this.mSummaryTable_.Controls.Add(this.TotalCredits, 1, 0);
            this.mSummaryTable_.Controls.Add(this.TotalDebits, 1, 1);
            this.mSummaryTable_.Controls.Add(this.CreditsDebitsDiff, 1, 2);
            this.mSummaryTable_.Controls.Add(this.TotalTransferIn, 1, 3);
            this.mSummaryTable_.Controls.Add(this.TotalTransferOut, 1, 4);
            this.mSummaryTable_.Controls.Add(this.TransfersDiff, 1, 5);
            this.mSummaryTable_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mSummaryTable_.Location = new System.Drawing.Point(3, 16);
            this.mSummaryTable_.Name = "mSummaryTable_";
            this.mSummaryTable_.RowCount = 6;
            this.mSummaryTable_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.mSummaryTable_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.mSummaryTable_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.mSummaryTable_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.mSummaryTable_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.mSummaryTable_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.mSummaryTable_.Size = new System.Drawing.Size(212, 179);
            this.mSummaryTable_.TabIndex = 0;
            // 
            // label0
            // 
            label0.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label0.AutoSize = true;
            label0.Location = new System.Drawing.Point(37, 8);
            label0.Name = "label0";
            label0.Size = new System.Drawing.Size(66, 13);
            label0.TabIndex = 2;
            label0.Text = "Total Credits";
            label0.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label4
            // 
            label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(39, 37);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(64, 13);
            label4.TabIndex = 6;
            label4.Text = "Total Debits";
            label4.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(47, 66);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(56, 13);
            label1.TabIndex = 7;
            label1.Text = "Difference";
            label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(13, 95);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(90, 13);
            label2.TabIndex = 19;
            label2.Text = "Total Transfers In";
            label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label5
            // 
            label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(5, 124);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(98, 13);
            label5.TabIndex = 20;
            label5.Text = "Total Transfers Out";
            label5.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label3
            // 
            label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(47, 155);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(56, 13);
            label3.TabIndex = 21;
            label3.Text = "Difference";
            label3.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // TotalCredits
            // 
            this.TotalCredits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalCredits.BackColor = System.Drawing.SystemColors.Window;
            this.TotalCredits.ForeColor = System.Drawing.Color.Black;
            this.TotalCredits.Location = new System.Drawing.Point(109, 4);
            this.TotalCredits.Name = "TotalCredits";
            this.TotalCredits.ReadOnly = true;
            this.TotalCredits.Size = new System.Drawing.Size(100, 20);
            this.TotalCredits.TabIndex = 22;
            this.TotalCredits.Text = "$0.00";
            this.TotalCredits.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TotalCredits.Value = ((MPersist.Core.MoneyType.Money)(resources.GetObject("TotalCredits.Value")));
            // 
            // TotalDebits
            // 
            this.TotalDebits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalDebits.BackColor = System.Drawing.SystemColors.Window;
            this.TotalDebits.ForeColor = System.Drawing.Color.Black;
            this.TotalDebits.Location = new System.Drawing.Point(109, 33);
            this.TotalDebits.Name = "TotalDebits";
            this.TotalDebits.ReadOnly = true;
            this.TotalDebits.Size = new System.Drawing.Size(100, 20);
            this.TotalDebits.TabIndex = 23;
            this.TotalDebits.Text = "$0.00";
            this.TotalDebits.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TotalDebits.Value = ((MPersist.Core.MoneyType.Money)(resources.GetObject("TotalDebits.Value")));
            // 
            // CreditsDebitsDiff
            // 
            this.CreditsDebitsDiff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CreditsDebitsDiff.BackColor = System.Drawing.SystemColors.Window;
            this.CreditsDebitsDiff.ForeColor = System.Drawing.Color.Black;
            this.CreditsDebitsDiff.Location = new System.Drawing.Point(109, 62);
            this.CreditsDebitsDiff.Name = "CreditsDebitsDiff";
            this.CreditsDebitsDiff.ReadOnly = true;
            this.CreditsDebitsDiff.Size = new System.Drawing.Size(100, 20);
            this.CreditsDebitsDiff.TabIndex = 24;
            this.CreditsDebitsDiff.Text = "$0.00";
            this.CreditsDebitsDiff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CreditsDebitsDiff.Value = ((MPersist.Core.MoneyType.Money)(resources.GetObject("CreditsDebitsDiff.Value")));
            // 
            // TotalTransferIn
            // 
            this.TotalTransferIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalTransferIn.BackColor = System.Drawing.SystemColors.Window;
            this.TotalTransferIn.ForeColor = System.Drawing.Color.Black;
            this.TotalTransferIn.Location = new System.Drawing.Point(109, 91);
            this.TotalTransferIn.Name = "TotalTransferIn";
            this.TotalTransferIn.ReadOnly = true;
            this.TotalTransferIn.Size = new System.Drawing.Size(100, 20);
            this.TotalTransferIn.TabIndex = 25;
            this.TotalTransferIn.Text = "$0.00";
            this.TotalTransferIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TotalTransferIn.Value = ((MPersist.Core.MoneyType.Money)(resources.GetObject("TotalTransferIn.Value")));
            // 
            // TotalTransferOut
            // 
            this.TotalTransferOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalTransferOut.BackColor = System.Drawing.SystemColors.Window;
            this.TotalTransferOut.ForeColor = System.Drawing.Color.Black;
            this.TotalTransferOut.Location = new System.Drawing.Point(109, 120);
            this.TotalTransferOut.Name = "TotalTransferOut";
            this.TotalTransferOut.ReadOnly = true;
            this.TotalTransferOut.Size = new System.Drawing.Size(100, 20);
            this.TotalTransferOut.TabIndex = 26;
            this.TotalTransferOut.Text = "$0.00";
            this.TotalTransferOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TotalTransferOut.Value = ((MPersist.Core.MoneyType.Money)(resources.GetObject("TotalTransferOut.Value")));
            // 
            // TransfersDiff
            // 
            this.TransfersDiff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TransfersDiff.BackColor = System.Drawing.SystemColors.Window;
            this.TransfersDiff.ForeColor = System.Drawing.Color.Black;
            this.TransfersDiff.Location = new System.Drawing.Point(109, 152);
            this.TransfersDiff.Name = "TransfersDiff";
            this.TransfersDiff.ReadOnly = true;
            this.TransfersDiff.Size = new System.Drawing.Size(100, 20);
            this.TransfersDiff.TabIndex = 27;
            this.TransfersDiff.Text = "$0.00";
            this.TransfersDiff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TransfersDiff.Value = ((MPersist.Core.MoneyType.Money)(resources.GetObject("TransfersDiff.Value")));
            // 
            // mAllTimeGroupBox_
            // 
            this.mAllTimeGroupBox_.Controls.Add(this.mAllTimeTableLayout_);
            this.mAllTimeGroupBox_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mAllTimeGroupBox_.Location = new System.Drawing.Point(3, 207);
            this.mAllTimeGroupBox_.Name = "mAllTimeGroupBox_";
            this.mAllTimeGroupBox_.Size = new System.Drawing.Size(218, 130);
            this.mAllTimeGroupBox_.TabIndex = 1;
            this.mAllTimeGroupBox_.TabStop = false;
            this.mAllTimeGroupBox_.Text = "All Time";
            // 
            // mAllTimeTableLayout_
            // 
            this.mAllTimeTableLayout_.ColumnCount = 2;
            this.mAllTimeTableLayout_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mAllTimeTableLayout_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mAllTimeTableLayout_.Controls.Add(this.BalanceDiff, 1, 2);
            this.mAllTimeTableLayout_.Controls.Add(label10, 0, 2);
            this.mAllTimeTableLayout_.Controls.Add(label8, 0, 0);
            this.mAllTimeTableLayout_.Controls.Add(label9, 0, 1);
            this.mAllTimeTableLayout_.Controls.Add(this.OpeningBalance, 1, 0);
            this.mAllTimeTableLayout_.Controls.Add(this.CurrentBalance, 1, 1);
            this.mAllTimeTableLayout_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mAllTimeTableLayout_.Location = new System.Drawing.Point(3, 16);
            this.mAllTimeTableLayout_.Name = "mAllTimeTableLayout_";
            this.mAllTimeTableLayout_.RowCount = 3;
            this.mAllTimeTableLayout_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.mAllTimeTableLayout_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.mAllTimeTableLayout_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.mAllTimeTableLayout_.Size = new System.Drawing.Size(212, 111);
            this.mAllTimeTableLayout_.TabIndex = 0;
            // 
            // label8
            // 
            label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(18, 11);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(85, 13);
            label8.TabIndex = 31;
            label8.Text = "Starting Balance";
            label8.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label9
            // 
            label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(20, 47);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(83, 13);
            label9.TabIndex = 32;
            label9.Text = "Current Balance";
            label9.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label10
            // 
            label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(47, 85);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(56, 13);
            label10.TabIndex = 33;
            label10.Text = "Difference";
            label10.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // OpeningBalance
            // 
            this.OpeningBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.OpeningBalance.BackColor = System.Drawing.SystemColors.Window;
            this.OpeningBalance.ForeColor = System.Drawing.Color.Black;
            this.OpeningBalance.Location = new System.Drawing.Point(109, 8);
            this.OpeningBalance.Name = "OpeningBalance";
            this.OpeningBalance.ReadOnly = true;
            this.OpeningBalance.Size = new System.Drawing.Size(100, 20);
            this.OpeningBalance.TabIndex = 34;
            this.OpeningBalance.Text = "$0.00";
            this.OpeningBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.OpeningBalance.Value = ((MPersist.Core.MoneyType.Money)(resources.GetObject("OpeningBalance.Value")));
            // 
            // CurrentBalance
            // 
            this.CurrentBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentBalance.BackColor = System.Drawing.SystemColors.Window;
            this.CurrentBalance.ForeColor = System.Drawing.Color.Black;
            this.CurrentBalance.Location = new System.Drawing.Point(109, 44);
            this.CurrentBalance.Name = "CurrentBalance";
            this.CurrentBalance.ReadOnly = true;
            this.CurrentBalance.Size = new System.Drawing.Size(100, 20);
            this.CurrentBalance.TabIndex = 35;
            this.CurrentBalance.Text = "$0.00";
            this.CurrentBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CurrentBalance.Value = ((MPersist.Core.MoneyType.Money)(resources.GetObject("CurrentBalance.Value")));
            // 
            // BalanceDiff
            // 
            this.BalanceDiff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BalanceDiff.BackColor = System.Drawing.SystemColors.Window;
            this.BalanceDiff.ForeColor = System.Drawing.Color.Black;
            this.BalanceDiff.Location = new System.Drawing.Point(109, 81);
            this.BalanceDiff.Name = "BalanceDiff";
            this.BalanceDiff.ReadOnly = true;
            this.BalanceDiff.Size = new System.Drawing.Size(100, 20);
            this.BalanceDiff.TabIndex = 36;
            this.BalanceDiff.Text = "$0.00";
            this.BalanceDiff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.BalanceDiff.Value = ((MPersist.Core.MoneyType.Money)(resources.GetObject("BalanceDiff.Value")));
            // 
            // SummaryPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mSummaryLayoutTable_);
            this.Name = "SummaryPanel";
            this.Size = new System.Drawing.Size(224, 340);
            this.mSummaryLayoutTable_.ResumeLayout(false);
            this.mSummaryBox_.ResumeLayout(false);
            this.mSummaryTable_.ResumeLayout(false);
            this.mSummaryTable_.PerformLayout();
            this.mAllTimeGroupBox_.ResumeLayout(false);
            this.mAllTimeTableLayout_.ResumeLayout(false);
            this.mAllTimeTableLayout_.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mSummaryLayoutTable_;
        private System.Windows.Forms.GroupBox mSummaryBox_;
        private System.Windows.Forms.TableLayoutPanel mSummaryTable_;
        private Controls.MoneyBox TotalCredits;
        private Controls.MoneyBox TotalDebits;
        private Controls.MoneyBox CreditsDebitsDiff;
        private Controls.MoneyBox TotalTransferIn;
        private Controls.MoneyBox TotalTransferOut;
        private Controls.MoneyBox TransfersDiff;
        private System.Windows.Forms.GroupBox mAllTimeGroupBox_;
        private System.Windows.Forms.TableLayoutPanel mAllTimeTableLayout_;
        private Controls.MoneyBox BalanceDiff;
        private Controls.MoneyBox OpeningBalance;
        private Controls.MoneyBox CurrentBalance;
    }
}
