namespace MPFinance.Panels
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
            this.label0 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.mSummaryLayoutTable_ = new System.Windows.Forms.TableLayoutPanel();
            this.mAllTimeGroupBox_ = new System.Windows.Forms.GroupBox();
            this.mAllTimeTableLayout_ = new System.Windows.Forms.TableLayoutPanel();
            this.mBalanceDiff_ = new MPFinance.Controls.MoneyBox();
            this.mOpeningBalance_ = new MPFinance.Controls.MoneyBox();
            this.mCurrentBalance_ = new MPFinance.Controls.MoneyBox();
            this.mSummaryBox_ = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mTransfersDiff_ = new MPFinance.Controls.MoneyBox();
            this.mTotalTransferOut_ = new MPFinance.Controls.MoneyBox();
            this.mTotalTransferIn_ = new MPFinance.Controls.MoneyBox();
            this.mCreditsDebitsDiff_ = new MPFinance.Controls.MoneyBox();
            this.mTotalDebits_ = new MPFinance.Controls.MoneyBox();
            this.mTotalCredits_ = new MPFinance.Controls.MoneyBox();
            this.mSelectionOpeningBalance_ = new MPFinance.Controls.MoneyBox();
            this.mSelectionClosingBalance_ = new MPFinance.Controls.MoneyBox();
            this.mselectionBalanceDifference_ = new MPFinance.Controls.MoneyBox();
            this.mSummaryLayoutTable_.SuspendLayout();
            this.mAllTimeGroupBox_.SuspendLayout();
            this.mAllTimeTableLayout_.SuspendLayout();
            this.mSummaryBox_.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label0
            // 
            this.label0.Name = "label0";
            // 
            // label4
            // 
            this.label4.Name = "label4";
            // 
            // label1
            // 
            this.label1.Name = "label1";
            // 
            // label2
            // 
            this.label2.Name = "label2";
            // 
            // label5
            // 
            this.label5.Name = "label5";
            // 
            // label3
            // 
            this.label3.Name = "label3";
            // 
            // label8
            // 
            this.label8.Name = "label8";
            // 
            // label9
            // 
            this.label9.Name = "label9";
            // 
            // label10
            // 
            this.label10.Name = "label10";
            // 
            // label6
            // 
            this.label6.Name = "label6";
            // 
            // label7
            // 
            this.label7.Name = "label7";
            // 
            // label11
            // 
            this.label11.Name = "label11";
            // 
            // mSummaryLayoutTable_
            // 
            this.mSummaryLayoutTable_.Controls.Add(this.mAllTimeGroupBox_, 0, 1);
            this.mSummaryLayoutTable_.Controls.Add(this.mSummaryBox_, 0, 0);
            this.mSummaryLayoutTable_.Name = "mSummaryLayoutTable_";
            // 
            // mAllTimeGroupBox_
            // 
            this.mAllTimeGroupBox_.Controls.Add(this.mAllTimeTableLayout_);
            this.mAllTimeGroupBox_.Name = "mAllTimeGroupBox_";
            this.mAllTimeGroupBox_.TabStop = false;
            // 
            // mAllTimeTableLayout_
            // 
            this.mAllTimeTableLayout_.Controls.Add(this.mBalanceDiff_, 1, 2);
            this.mAllTimeTableLayout_.Controls.Add(this.label10, 0, 2);
            this.mAllTimeTableLayout_.Controls.Add(this.label8, 0, 0);
            this.mAllTimeTableLayout_.Controls.Add(this.label9, 0, 1);
            this.mAllTimeTableLayout_.Controls.Add(this.mOpeningBalance_, 1, 0);
            this.mAllTimeTableLayout_.Controls.Add(this.mCurrentBalance_, 1, 1);
            this.mAllTimeTableLayout_.Name = "mAllTimeTableLayout_";
            // 
            // mBalanceDiff_
            // 
            this.mBalanceDiff_.BackColor = System.Drawing.SystemColors.Window;
            this.mBalanceDiff_.ForeColor = System.Drawing.Color.Black;
            this.mBalanceDiff_.Name = "mBalanceDiff_";
            this.mBalanceDiff_.ReadOnly = true;
            // 
            // mOpeningBalance_
            // 
            this.mOpeningBalance_.BackColor = System.Drawing.SystemColors.Window;
            this.mOpeningBalance_.ForeColor = System.Drawing.Color.Black;
            this.mOpeningBalance_.Name = "mOpeningBalance_";
            this.mOpeningBalance_.ReadOnly = true;
            // 
            // mCurrentBalance_
            // 
            this.mCurrentBalance_.BackColor = System.Drawing.SystemColors.Window;
            this.mCurrentBalance_.ForeColor = System.Drawing.Color.Black;
            this.mCurrentBalance_.Name = "mCurrentBalance_";
            this.mCurrentBalance_.ReadOnly = true;
            // 
            // mSummaryBox_
            // 
            this.mSummaryBox_.Controls.Add(this.tableLayoutPanel1);
            this.mSummaryBox_.Name = "mSummaryBox_";
            this.mSummaryBox_.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.mTransfersDiff_, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.mTotalTransferOut_, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.mTotalTransferIn_, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.mCreditsDebitsDiff_, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.mTotalDebits_, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.mTotalCredits_, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label0, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.mSelectionOpeningBalance_, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.mSelectionClosingBalance_, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.mselectionBalanceDifference_, 1, 8);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // mTransfersDiff_
            // 
            this.mTransfersDiff_.BackColor = System.Drawing.SystemColors.Window;
            this.mTransfersDiff_.ForeColor = System.Drawing.Color.Black;
            this.mTransfersDiff_.Name = "mTransfersDiff_";
            this.mTransfersDiff_.ReadOnly = true;
            // 
            // mTotalTransferOut_
            // 
            this.mTotalTransferOut_.BackColor = System.Drawing.SystemColors.Window;
            this.mTotalTransferOut_.ForeColor = System.Drawing.Color.Black;
            this.mTotalTransferOut_.Name = "mTotalTransferOut_";
            this.mTotalTransferOut_.ReadOnly = true;
            // 
            // mTotalTransferIn_
            // 
            this.mTotalTransferIn_.BackColor = System.Drawing.SystemColors.Window;
            this.mTotalTransferIn_.ForeColor = System.Drawing.Color.Black;
            this.mTotalTransferIn_.Name = "mTotalTransferIn_";
            this.mTotalTransferIn_.ReadOnly = true;
            // 
            // mCreditsDebitsDiff_
            // 
            this.mCreditsDebitsDiff_.BackColor = System.Drawing.SystemColors.Window;
            this.mCreditsDebitsDiff_.ForeColor = System.Drawing.Color.Black;
            this.mCreditsDebitsDiff_.Name = "mCreditsDebitsDiff_";
            this.mCreditsDebitsDiff_.ReadOnly = true;
            // 
            // mTotalDebits_
            // 
            this.mTotalDebits_.BackColor = System.Drawing.SystemColors.Window;
            this.mTotalDebits_.ForeColor = System.Drawing.Color.Black;
            this.mTotalDebits_.Name = "mTotalDebits_";
            this.mTotalDebits_.ReadOnly = true;
            // 
            // mTotalCredits_
            // 
            this.mTotalCredits_.BackColor = System.Drawing.SystemColors.Window;
            this.mTotalCredits_.ForeColor = System.Drawing.Color.Black;
            this.mTotalCredits_.Name = "mTotalCredits_";
            this.mTotalCredits_.ReadOnly = true;
            // 
            // mSelectionOpeningBalance_
            // 
            this.mSelectionOpeningBalance_.BackColor = System.Drawing.SystemColors.Window;
            this.mSelectionOpeningBalance_.ForeColor = System.Drawing.Color.Black;
            this.mSelectionOpeningBalance_.Name = "mSelectionOpeningBalance_";
            this.mSelectionOpeningBalance_.ReadOnly = true;
            // 
            // mSelectionClosingBalance_
            // 
            this.mSelectionClosingBalance_.BackColor = System.Drawing.SystemColors.Window;
            this.mSelectionClosingBalance_.ForeColor = System.Drawing.Color.Black;
            this.mSelectionClosingBalance_.Name = "mSelectionClosingBalance_";
            this.mSelectionClosingBalance_.ReadOnly = true;
            // 
            // mselectionBalanceDifference_
            // 
            this.mselectionBalanceDifference_.BackColor = System.Drawing.SystemColors.Window;
            this.mselectionBalanceDifference_.ForeColor = System.Drawing.Color.Black;
            this.mselectionBalanceDifference_.Name = "mselectionBalanceDifference_";
            this.mselectionBalanceDifference_.ReadOnly = true;
            // 
            // SummaryPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mSummaryLayoutTable_);
            this.Name = "SummaryPanel";
            this.mSummaryLayoutTable_.ResumeLayout(false);
            this.mAllTimeGroupBox_.ResumeLayout(false);
            this.mAllTimeTableLayout_.ResumeLayout(false);
            this.mAllTimeTableLayout_.PerformLayout();
            this.mSummaryBox_.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mSummaryLayoutTable_;
        private System.Windows.Forms.GroupBox mSummaryBox_;
        private Controls.MoneyBox mTotalCredits_;
        private Controls.MoneyBox mTotalDebits_;
        private Controls.MoneyBox mCreditsDebitsDiff_;
        private Controls.MoneyBox mTotalTransferIn_;
        private Controls.MoneyBox mTotalTransferOut_;
        private Controls.MoneyBox mTransfersDiff_;
        private System.Windows.Forms.GroupBox mAllTimeGroupBox_;
        private System.Windows.Forms.TableLayoutPanel mAllTimeTableLayout_;
        private Controls.MoneyBox mBalanceDiff_;
        private Controls.MoneyBox mOpeningBalance_;
        private Controls.MoneyBox mCurrentBalance_;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Controls.MoneyBox mSelectionOpeningBalance_;
        private Controls.MoneyBox mSelectionClosingBalance_;
        private Controls.MoneyBox mselectionBalanceDifference_;
        private System.Windows.Forms.Label label0;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
    }
}
