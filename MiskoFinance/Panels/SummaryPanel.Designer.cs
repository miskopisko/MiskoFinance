using System;
namespace MiskoFinance.Panels
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
        protected override void Dispose(Boolean disposing)
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
			MiskoPersist.MoneyType.Money money1 = new MiskoPersist.MoneyType.Money();
			MiskoPersist.MoneyType.Money money2 = new MiskoPersist.MoneyType.Money();
			MiskoPersist.MoneyType.Money money3 = new MiskoPersist.MoneyType.Money();
			MiskoPersist.MoneyType.Money money4 = new MiskoPersist.MoneyType.Money();
			MiskoPersist.MoneyType.Money money5 = new MiskoPersist.MoneyType.Money();
			MiskoPersist.MoneyType.Money money6 = new MiskoPersist.MoneyType.Money();
			this.mSelectionOpeningBalanceLbl_ = new System.Windows.Forms.Label();
			this.mSelectionClosingBalanceLbl_ = new System.Windows.Forms.Label();
			this.mSelectionDifferenceLbl_ = new System.Windows.Forms.Label();
			this.mAllTimeStartingBalanceLbl_ = new System.Windows.Forms.Label();
			this.mAllTimeCurrentBalanceLbl_ = new System.Windows.Forms.Label();
			this.mAllTimeDifferenceLbl_ = new System.Windows.Forms.Label();
			this.mSummaryTableLayoutPanel_ = new System.Windows.Forms.TableLayoutPanel();
			this.mSelectionBalanceLbl_ = new System.Windows.Forms.Label();
			this.mAllTimeBalanceLbl_ = new System.Windows.Forms.Label();
			this.mBalanceDiff_ = new MiskoFinance.Controls.MoneyBox();
			this.mCurrentBalance_ = new MiskoFinance.Controls.MoneyBox();
			this.mOpeningBalance_ = new MiskoFinance.Controls.MoneyBox();
			this.mSelectionBalanceDifference_ = new MiskoFinance.Controls.MoneyBox();
			this.mSelectionClosingBalance_ = new MiskoFinance.Controls.MoneyBox();
			this.mSelectionOpeningBalance_ = new MiskoFinance.Controls.MoneyBox();
			this.mSummaryTableLayoutPanel_.SuspendLayout();
			this.SuspendLayout();
			// 
			// mSelectionOpeningBalanceLbl_
			// 
			this.mSelectionOpeningBalanceLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mSelectionOpeningBalanceLbl_.AutoSize = true;
			this.mSelectionOpeningBalanceLbl_.Location = new System.Drawing.Point(3, 17);
			this.mSelectionOpeningBalanceLbl_.Name = "mSelectionOpeningBalanceLbl_";
			this.mSelectionOpeningBalanceLbl_.Size = new System.Drawing.Size(56, 13);
			this.mSelectionOpeningBalanceLbl_.TabIndex = 26;
			this.mSelectionOpeningBalanceLbl_.Text = "Opening";
			this.mSelectionOpeningBalanceLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// mSelectionClosingBalanceLbl_
			// 
			this.mSelectionClosingBalanceLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mSelectionClosingBalanceLbl_.AutoSize = true;
			this.mSelectionClosingBalanceLbl_.Location = new System.Drawing.Point(3, 38);
			this.mSelectionClosingBalanceLbl_.Name = "mSelectionClosingBalanceLbl_";
			this.mSelectionClosingBalanceLbl_.Size = new System.Drawing.Size(56, 13);
			this.mSelectionClosingBalanceLbl_.TabIndex = 27;
			this.mSelectionClosingBalanceLbl_.Text = "Closing";
			this.mSelectionClosingBalanceLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// mSelectionDifferenceLbl_
			// 
			this.mSelectionDifferenceLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mSelectionDifferenceLbl_.AutoSize = true;
			this.mSelectionDifferenceLbl_.Location = new System.Drawing.Point(3, 59);
			this.mSelectionDifferenceLbl_.Name = "mSelectionDifferenceLbl_";
			this.mSelectionDifferenceLbl_.Size = new System.Drawing.Size(56, 13);
			this.mSelectionDifferenceLbl_.TabIndex = 28;
			this.mSelectionDifferenceLbl_.Text = "Difference";
			this.mSelectionDifferenceLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// mAllTimeStartingBalanceLbl_
			// 
			this.mAllTimeStartingBalanceLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mAllTimeStartingBalanceLbl_.AutoSize = true;
			this.mAllTimeStartingBalanceLbl_.Location = new System.Drawing.Point(3, 93);
			this.mAllTimeStartingBalanceLbl_.Name = "mAllTimeStartingBalanceLbl_";
			this.mAllTimeStartingBalanceLbl_.Size = new System.Drawing.Size(56, 13);
			this.mAllTimeStartingBalanceLbl_.TabIndex = 29;
			this.mAllTimeStartingBalanceLbl_.Text = "Opening";
			this.mAllTimeStartingBalanceLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// mAllTimeCurrentBalanceLbl_
			// 
			this.mAllTimeCurrentBalanceLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mAllTimeCurrentBalanceLbl_.AutoSize = true;
			this.mAllTimeCurrentBalanceLbl_.Location = new System.Drawing.Point(3, 114);
			this.mAllTimeCurrentBalanceLbl_.Name = "mAllTimeCurrentBalanceLbl_";
			this.mAllTimeCurrentBalanceLbl_.Size = new System.Drawing.Size(56, 13);
			this.mAllTimeCurrentBalanceLbl_.TabIndex = 30;
			this.mAllTimeCurrentBalanceLbl_.Text = "Closing";
			this.mAllTimeCurrentBalanceLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// mAllTimeDifferenceLbl_
			// 
			this.mAllTimeDifferenceLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mAllTimeDifferenceLbl_.AutoSize = true;
			this.mAllTimeDifferenceLbl_.Location = new System.Drawing.Point(3, 135);
			this.mAllTimeDifferenceLbl_.Name = "mAllTimeDifferenceLbl_";
			this.mAllTimeDifferenceLbl_.Size = new System.Drawing.Size(56, 13);
			this.mAllTimeDifferenceLbl_.TabIndex = 31;
			this.mAllTimeDifferenceLbl_.Text = "Difference";
			this.mAllTimeDifferenceLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// mSummaryTableLayoutPanel_
			// 
			this.mSummaryTableLayoutPanel_.AutoSize = true;
			this.mSummaryTableLayoutPanel_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.mSummaryTableLayoutPanel_.ColumnCount = 2;
			this.mSummaryTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mSummaryTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mSummaryTableLayoutPanel_.Controls.Add(this.mAllTimeBalanceLbl_, 0, 4);
			this.mSummaryTableLayoutPanel_.Controls.Add(this.mAllTimeDifferenceLbl_, 0, 7);
			this.mSummaryTableLayoutPanel_.Controls.Add(this.mAllTimeCurrentBalanceLbl_, 0, 6);
			this.mSummaryTableLayoutPanel_.Controls.Add(this.mAllTimeStartingBalanceLbl_, 0, 5);
			this.mSummaryTableLayoutPanel_.Controls.Add(this.mBalanceDiff_, 1, 7);
			this.mSummaryTableLayoutPanel_.Controls.Add(this.mCurrentBalance_, 1, 6);
			this.mSummaryTableLayoutPanel_.Controls.Add(this.mOpeningBalance_, 1, 5);
			this.mSummaryTableLayoutPanel_.Controls.Add(this.mSelectionDifferenceLbl_, 0, 3);
			this.mSummaryTableLayoutPanel_.Controls.Add(this.mSelectionBalanceDifference_, 1, 3);
			this.mSummaryTableLayoutPanel_.Controls.Add(this.mSelectionClosingBalance_, 1, 2);
			this.mSummaryTableLayoutPanel_.Controls.Add(this.mSelectionClosingBalanceLbl_, 0, 2);
			this.mSummaryTableLayoutPanel_.Controls.Add(this.mSelectionOpeningBalance_, 1, 1);
			this.mSummaryTableLayoutPanel_.Controls.Add(this.mSelectionOpeningBalanceLbl_, 0, 1);
			this.mSummaryTableLayoutPanel_.Controls.Add(this.mSelectionBalanceLbl_, 0, 0);
			this.mSummaryTableLayoutPanel_.Location = new System.Drawing.Point(0, 0);
			this.mSummaryTableLayoutPanel_.Name = "mSummaryTableLayoutPanel_";
			this.mSummaryTableLayoutPanel_.RowCount = 8;
			this.mSummaryTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mSummaryTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mSummaryTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mSummaryTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mSummaryTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mSummaryTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mSummaryTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mSummaryTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.mSummaryTableLayoutPanel_.Size = new System.Drawing.Size(187, 152);
			this.mSummaryTableLayoutPanel_.TabIndex = 19;
			// 
			// mSelectionBalanceLbl_
			// 
			this.mSelectionBalanceLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mSelectionBalanceLbl_.AutoSize = true;
			this.mSummaryTableLayoutPanel_.SetColumnSpan(this.mSelectionBalanceLbl_, 2);
			this.mSelectionBalanceLbl_.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mSelectionBalanceLbl_.Location = new System.Drawing.Point(3, 0);
			this.mSelectionBalanceLbl_.Name = "mSelectionBalanceLbl_";
			this.mSelectionBalanceLbl_.Size = new System.Drawing.Size(181, 13);
			this.mSelectionBalanceLbl_.TabIndex = 32;
			this.mSelectionBalanceLbl_.Text = "Selection Balance";
			// 
			// mAllTimeBalanceLbl_
			// 
			this.mAllTimeBalanceLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mAllTimeBalanceLbl_.AutoSize = true;
			this.mSummaryTableLayoutPanel_.SetColumnSpan(this.mAllTimeBalanceLbl_, 2);
			this.mAllTimeBalanceLbl_.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mAllTimeBalanceLbl_.Location = new System.Drawing.Point(3, 76);
			this.mAllTimeBalanceLbl_.Name = "mAllTimeBalanceLbl_";
			this.mAllTimeBalanceLbl_.Size = new System.Drawing.Size(181, 13);
			this.mAllTimeBalanceLbl_.TabIndex = 33;
			this.mAllTimeBalanceLbl_.Text = "All Time Balance";
			// 
			// mBalanceDiff_
			// 
			this.mBalanceDiff_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mBalanceDiff_.BackColor = System.Drawing.SystemColors.Window;
			this.mBalanceDiff_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mBalanceDiff_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.mBalanceDiff_.ForeColor = System.Drawing.Color.Black;
			this.mBalanceDiff_.Location = new System.Drawing.Point(62, 131);
			this.mBalanceDiff_.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
			this.mBalanceDiff_.Name = "mBalanceDiff_";
			this.mBalanceDiff_.ReadOnly = true;
			this.mBalanceDiff_.Size = new System.Drawing.Size(125, 20);
			this.mBalanceDiff_.TabIndex = 0;
			this.mBalanceDiff_.Text = "$0.00";
			this.mBalanceDiff_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.mBalanceDiff_.Value = money1;
			// 
			// mCurrentBalance_
			// 
			this.mCurrentBalance_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mCurrentBalance_.BackColor = System.Drawing.SystemColors.Window;
			this.mCurrentBalance_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mCurrentBalance_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.mCurrentBalance_.ForeColor = System.Drawing.Color.Black;
			this.mCurrentBalance_.Location = new System.Drawing.Point(62, 110);
			this.mCurrentBalance_.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
			this.mCurrentBalance_.Name = "mCurrentBalance_";
			this.mCurrentBalance_.ReadOnly = true;
			this.mCurrentBalance_.Size = new System.Drawing.Size(125, 20);
			this.mCurrentBalance_.TabIndex = 5;
			this.mCurrentBalance_.Text = "$0.00";
			this.mCurrentBalance_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.mCurrentBalance_.Value = money2;
			// 
			// mOpeningBalance_
			// 
			this.mOpeningBalance_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mOpeningBalance_.BackColor = System.Drawing.SystemColors.Window;
			this.mOpeningBalance_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mOpeningBalance_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.mOpeningBalance_.ForeColor = System.Drawing.Color.Black;
			this.mOpeningBalance_.Location = new System.Drawing.Point(62, 89);
			this.mOpeningBalance_.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
			this.mOpeningBalance_.Name = "mOpeningBalance_";
			this.mOpeningBalance_.ReadOnly = true;
			this.mOpeningBalance_.Size = new System.Drawing.Size(125, 20);
			this.mOpeningBalance_.TabIndex = 4;
			this.mOpeningBalance_.Text = "$0.00";
			this.mOpeningBalance_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.mOpeningBalance_.Value = money3;
			// 
			// mSelectionBalanceDifference_
			// 
			this.mSelectionBalanceDifference_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mSelectionBalanceDifference_.BackColor = System.Drawing.SystemColors.Window;
			this.mSelectionBalanceDifference_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mSelectionBalanceDifference_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.mSelectionBalanceDifference_.ForeColor = System.Drawing.Color.Black;
			this.mSelectionBalanceDifference_.Location = new System.Drawing.Point(62, 55);
			this.mSelectionBalanceDifference_.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
			this.mSelectionBalanceDifference_.Name = "mSelectionBalanceDifference_";
			this.mSelectionBalanceDifference_.ReadOnly = true;
			this.mSelectionBalanceDifference_.Size = new System.Drawing.Size(125, 20);
			this.mSelectionBalanceDifference_.TabIndex = 17;
			this.mSelectionBalanceDifference_.Text = "$0.00";
			this.mSelectionBalanceDifference_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.mSelectionBalanceDifference_.Value = money4;
			// 
			// mSelectionClosingBalance_
			// 
			this.mSelectionClosingBalance_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mSelectionClosingBalance_.BackColor = System.Drawing.SystemColors.Window;
			this.mSelectionClosingBalance_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mSelectionClosingBalance_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.mSelectionClosingBalance_.ForeColor = System.Drawing.Color.Black;
			this.mSelectionClosingBalance_.Location = new System.Drawing.Point(62, 34);
			this.mSelectionClosingBalance_.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
			this.mSelectionClosingBalance_.Name = "mSelectionClosingBalance_";
			this.mSelectionClosingBalance_.ReadOnly = true;
			this.mSelectionClosingBalance_.Size = new System.Drawing.Size(125, 20);
			this.mSelectionClosingBalance_.TabIndex = 16;
			this.mSelectionClosingBalance_.Text = "$0.00";
			this.mSelectionClosingBalance_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.mSelectionClosingBalance_.Value = money5;
			// 
			// mSelectionOpeningBalance_
			// 
			this.mSelectionOpeningBalance_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mSelectionOpeningBalance_.BackColor = System.Drawing.SystemColors.Window;
			this.mSelectionOpeningBalance_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mSelectionOpeningBalance_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.mSelectionOpeningBalance_.ForeColor = System.Drawing.Color.Black;
			this.mSelectionOpeningBalance_.Location = new System.Drawing.Point(62, 13);
			this.mSelectionOpeningBalance_.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
			this.mSelectionOpeningBalance_.Name = "mSelectionOpeningBalance_";
			this.mSelectionOpeningBalance_.ReadOnly = true;
			this.mSelectionOpeningBalance_.Size = new System.Drawing.Size(125, 20);
			this.mSelectionOpeningBalance_.TabIndex = 15;
			this.mSelectionOpeningBalance_.Text = "$0.00";
			this.mSelectionOpeningBalance_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.mSelectionOpeningBalance_.Value = money6;
			// 
			// SummaryPanel
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.mSummaryTableLayoutPanel_);
			this.Name = "SummaryPanel";
			this.Size = new System.Drawing.Size(190, 155);
			this.mSummaryTableLayoutPanel_.ResumeLayout(false);
			this.mSummaryTableLayoutPanel_.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private Controls.MoneyBox mBalanceDiff_;
        private Controls.MoneyBox mOpeningBalance_;
        private Controls.MoneyBox mCurrentBalance_;
        private Controls.MoneyBox mSelectionOpeningBalance_;
        private Controls.MoneyBox mSelectionClosingBalance_;
        private Controls.MoneyBox mSelectionBalanceDifference_;
        private System.Windows.Forms.TableLayoutPanel mSummaryTableLayoutPanel_;
        private System.Windows.Forms.Label mSelectionOpeningBalanceLbl_;
        private System.Windows.Forms.Label mSelectionClosingBalanceLbl_;
        private System.Windows.Forms.Label mSelectionDifferenceLbl_;
        private System.Windows.Forms.Label mAllTimeStartingBalanceLbl_;
        private System.Windows.Forms.Label mAllTimeCurrentBalanceLbl_;
        private System.Windows.Forms.Label mAllTimeDifferenceLbl_;
		private System.Windows.Forms.Label mAllTimeBalanceLbl_;
		private System.Windows.Forms.Label mSelectionBalanceLbl_;
	}
}
