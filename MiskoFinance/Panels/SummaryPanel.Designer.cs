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
        	MiskoPersist.MoneyType.Money money1 = new MiskoPersist.MoneyType.Money();
        	MiskoPersist.MoneyType.Money money2 = new MiskoPersist.MoneyType.Money();
        	MiskoPersist.MoneyType.Money money3 = new MiskoPersist.MoneyType.Money();
        	MiskoPersist.MoneyType.Money money4 = new MiskoPersist.MoneyType.Money();
        	MiskoPersist.MoneyType.Money money5 = new MiskoPersist.MoneyType.Money();
        	MiskoPersist.MoneyType.Money money6 = new MiskoPersist.MoneyType.Money();
        	MiskoPersist.MoneyType.Money money7 = new MiskoPersist.MoneyType.Money();
        	MiskoPersist.MoneyType.Money money8 = new MiskoPersist.MoneyType.Money();
        	MiskoPersist.MoneyType.Money money9 = new MiskoPersist.MoneyType.Money();
        	MiskoPersist.MoneyType.Money money10 = new MiskoPersist.MoneyType.Money();
        	MiskoPersist.MoneyType.Money money11 = new MiskoPersist.MoneyType.Money();
        	MiskoPersist.MoneyType.Money money12 = new MiskoPersist.MoneyType.Money();
        	this.mTotalDebitsLbl_ = new System.Windows.Forms.Label();
        	this.mCreditsDebitsDifferenceLbl_ = new System.Windows.Forms.Label();
        	this.mTransferInLbl_ = new System.Windows.Forms.Label();
        	this.mTransferOutLbl_ = new System.Windows.Forms.Label();
        	this.mTransfersDifferenceLbl_ = new System.Windows.Forms.Label();
        	this.mSelectionOpeningBalanceLbl_ = new System.Windows.Forms.Label();
        	this.mSelectionClosingBalanceLbl_ = new System.Windows.Forms.Label();
        	this.mSelectionDifferenceLbl_ = new System.Windows.Forms.Label();
        	this.mAllTimeStartingBalanceLbl_ = new System.Windows.Forms.Label();
        	this.mAllTimeCurrentBalanceLbl_ = new System.Windows.Forms.Label();
        	this.mAllTimeDifferenceLbl_ = new System.Windows.Forms.Label();
        	this.mSummaryTableLayoutPanel_ = new System.Windows.Forms.TableLayoutPanel();
        	this.mTotalCredits_ = new MiskoFinance.Controls.MoneyBox();
        	this.mTotalCreditsLbl_ = new System.Windows.Forms.Label();
        	this.mTotalDebits_ = new MiskoFinance.Controls.MoneyBox();
        	this.mCreditsDebitsDiff_ = new MiskoFinance.Controls.MoneyBox();
        	this.mTotalTransferIn_ = new MiskoFinance.Controls.MoneyBox();
        	this.mTotalTransferOut_ = new MiskoFinance.Controls.MoneyBox();
        	this.mTransfersDiff_ = new MiskoFinance.Controls.MoneyBox();
        	this.mSelectionOpeningBalance_ = new MiskoFinance.Controls.MoneyBox();
        	this.mSelectionClosingBalance_ = new MiskoFinance.Controls.MoneyBox();
        	this.mSelectionBalanceDifference_ = new MiskoFinance.Controls.MoneyBox();
        	this.mOpeningBalance_ = new MiskoFinance.Controls.MoneyBox();
        	this.mCurrentBalance_ = new MiskoFinance.Controls.MoneyBox();
        	this.mBalanceDiff_ = new MiskoFinance.Controls.MoneyBox();
        	this.mSummaryTableLayoutPanel_.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// mTotalDebitsLbl_
        	// 
        	this.mTotalDebitsLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mTotalDebitsLbl_.AutoSize = true;
        	this.mTotalDebitsLbl_.Location = new System.Drawing.Point(3, 32);
        	this.mTotalDebitsLbl_.Name = "mTotalDebitsLbl_";
        	this.mTotalDebitsLbl_.Size = new System.Drawing.Size(66, 13);
        	this.mTotalDebitsLbl_.TabIndex = 21;
        	this.mTotalDebitsLbl_.Text = "Total Debits";
        	this.mTotalDebitsLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// mCreditsDebitsDifferenceLbl_
        	// 
        	this.mCreditsDebitsDifferenceLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mCreditsDebitsDifferenceLbl_.AutoSize = true;
        	this.mCreditsDebitsDifferenceLbl_.Location = new System.Drawing.Point(3, 58);
        	this.mCreditsDebitsDifferenceLbl_.Name = "mCreditsDebitsDifferenceLbl_";
        	this.mCreditsDebitsDifferenceLbl_.Size = new System.Drawing.Size(66, 13);
        	this.mCreditsDebitsDifferenceLbl_.TabIndex = 22;
        	this.mCreditsDebitsDifferenceLbl_.Text = "Difference";
        	this.mCreditsDebitsDifferenceLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// mTransferInLbl_
        	// 
        	this.mTransferInLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mTransferInLbl_.AutoSize = true;
        	this.mTransferInLbl_.Location = new System.Drawing.Point(206, 6);
        	this.mTransferInLbl_.Name = "mTransferInLbl_";
        	this.mTransferInLbl_.Size = new System.Drawing.Size(71, 13);
        	this.mTransferInLbl_.TabIndex = 23;
        	this.mTransferInLbl_.Text = "Transfers In";
        	this.mTransferInLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// mTransferOutLbl_
        	// 
        	this.mTransferOutLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mTransferOutLbl_.AutoSize = true;
        	this.mTransferOutLbl_.Location = new System.Drawing.Point(206, 32);
        	this.mTransferOutLbl_.Name = "mTransferOutLbl_";
        	this.mTransferOutLbl_.Size = new System.Drawing.Size(71, 13);
        	this.mTransferOutLbl_.TabIndex = 24;
        	this.mTransferOutLbl_.Text = "Transfers Out";
        	this.mTransferOutLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// mTransfersDifferenceLbl_
        	// 
        	this.mTransfersDifferenceLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mTransfersDifferenceLbl_.AutoSize = true;
        	this.mTransfersDifferenceLbl_.Location = new System.Drawing.Point(206, 58);
        	this.mTransfersDifferenceLbl_.Name = "mTransfersDifferenceLbl_";
        	this.mTransfersDifferenceLbl_.Size = new System.Drawing.Size(71, 13);
        	this.mTransfersDifferenceLbl_.TabIndex = 25;
        	this.mTransfersDifferenceLbl_.Text = "Difference";
        	this.mTransfersDifferenceLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// mSelectionOpeningBalanceLbl_
        	// 
        	this.mSelectionOpeningBalanceLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mSelectionOpeningBalanceLbl_.AutoSize = true;
        	this.mSelectionOpeningBalanceLbl_.Location = new System.Drawing.Point(414, 6);
        	this.mSelectionOpeningBalanceLbl_.Name = "mSelectionOpeningBalanceLbl_";
        	this.mSelectionOpeningBalanceLbl_.Size = new System.Drawing.Size(89, 13);
        	this.mSelectionOpeningBalanceLbl_.TabIndex = 26;
        	this.mSelectionOpeningBalanceLbl_.Text = "Opening Balance";
        	this.mSelectionOpeningBalanceLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// mSelectionClosingBalanceLbl_
        	// 
        	this.mSelectionClosingBalanceLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mSelectionClosingBalanceLbl_.AutoSize = true;
        	this.mSelectionClosingBalanceLbl_.Location = new System.Drawing.Point(414, 32);
        	this.mSelectionClosingBalanceLbl_.Name = "mSelectionClosingBalanceLbl_";
        	this.mSelectionClosingBalanceLbl_.Size = new System.Drawing.Size(89, 13);
        	this.mSelectionClosingBalanceLbl_.TabIndex = 27;
        	this.mSelectionClosingBalanceLbl_.Text = "Closing Balance";
        	this.mSelectionClosingBalanceLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// mSelectionDifferenceLbl_
        	// 
        	this.mSelectionDifferenceLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mSelectionDifferenceLbl_.AutoSize = true;
        	this.mSelectionDifferenceLbl_.Location = new System.Drawing.Point(414, 58);
        	this.mSelectionDifferenceLbl_.Name = "mSelectionDifferenceLbl_";
        	this.mSelectionDifferenceLbl_.Size = new System.Drawing.Size(89, 13);
        	this.mSelectionDifferenceLbl_.TabIndex = 28;
        	this.mSelectionDifferenceLbl_.Text = "Difference";
        	this.mSelectionDifferenceLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// mAllTimeStartingBalanceLbl_
        	// 
        	this.mAllTimeStartingBalanceLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mAllTimeStartingBalanceLbl_.AutoSize = true;
        	this.mAllTimeStartingBalanceLbl_.Location = new System.Drawing.Point(640, 6);
        	this.mAllTimeStartingBalanceLbl_.Name = "mAllTimeStartingBalanceLbl_";
        	this.mAllTimeStartingBalanceLbl_.Size = new System.Drawing.Size(85, 13);
        	this.mAllTimeStartingBalanceLbl_.TabIndex = 29;
        	this.mAllTimeStartingBalanceLbl_.Text = "Starting Balance";
        	this.mAllTimeStartingBalanceLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// mAllTimeCurrentBalanceLbl_
        	// 
        	this.mAllTimeCurrentBalanceLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mAllTimeCurrentBalanceLbl_.AutoSize = true;
        	this.mAllTimeCurrentBalanceLbl_.Location = new System.Drawing.Point(640, 32);
        	this.mAllTimeCurrentBalanceLbl_.Name = "mAllTimeCurrentBalanceLbl_";
        	this.mAllTimeCurrentBalanceLbl_.Size = new System.Drawing.Size(85, 13);
        	this.mAllTimeCurrentBalanceLbl_.TabIndex = 30;
        	this.mAllTimeCurrentBalanceLbl_.Text = "Current Balance";
        	this.mAllTimeCurrentBalanceLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// mAllTimeDifferenceLbl_
        	// 
        	this.mAllTimeDifferenceLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mAllTimeDifferenceLbl_.AutoSize = true;
        	this.mAllTimeDifferenceLbl_.Location = new System.Drawing.Point(640, 58);
        	this.mAllTimeDifferenceLbl_.Name = "mAllTimeDifferenceLbl_";
        	this.mAllTimeDifferenceLbl_.Size = new System.Drawing.Size(85, 13);
        	this.mAllTimeDifferenceLbl_.TabIndex = 31;
        	this.mAllTimeDifferenceLbl_.Text = "Difference";
        	this.mAllTimeDifferenceLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// mSummaryTableLayoutPanel_
        	// 
        	this.mSummaryTableLayoutPanel_.AutoSize = true;
        	this.mSummaryTableLayoutPanel_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        	this.mSummaryTableLayoutPanel_.ColumnCount = 8;
        	this.mSummaryTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        	this.mSummaryTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        	this.mSummaryTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        	this.mSummaryTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        	this.mSummaryTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        	this.mSummaryTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        	this.mSummaryTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        	this.mSummaryTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        	this.mSummaryTableLayoutPanel_.Controls.Add(this.mTotalCredits_, 1, 0);
        	this.mSummaryTableLayoutPanel_.Controls.Add(this.mTotalCreditsLbl_, 0, 0);
        	this.mSummaryTableLayoutPanel_.Controls.Add(this.mTotalDebitsLbl_, 0, 1);
        	this.mSummaryTableLayoutPanel_.Controls.Add(this.mTotalDebits_, 1, 1);
        	this.mSummaryTableLayoutPanel_.Controls.Add(this.mCreditsDebitsDifferenceLbl_, 0, 2);
        	this.mSummaryTableLayoutPanel_.Controls.Add(this.mCreditsDebitsDiff_, 1, 2);
        	this.mSummaryTableLayoutPanel_.Controls.Add(this.mTransferInLbl_, 2, 0);
        	this.mSummaryTableLayoutPanel_.Controls.Add(this.mTransferOutLbl_, 2, 1);
        	this.mSummaryTableLayoutPanel_.Controls.Add(this.mTransfersDifferenceLbl_, 2, 2);
        	this.mSummaryTableLayoutPanel_.Controls.Add(this.mTotalTransferIn_, 3, 0);
        	this.mSummaryTableLayoutPanel_.Controls.Add(this.mTotalTransferOut_, 3, 1);
        	this.mSummaryTableLayoutPanel_.Controls.Add(this.mTransfersDiff_, 3, 2);
        	this.mSummaryTableLayoutPanel_.Controls.Add(this.mSelectionOpeningBalanceLbl_, 4, 0);
        	this.mSummaryTableLayoutPanel_.Controls.Add(this.mSelectionClosingBalanceLbl_, 4, 1);
        	this.mSummaryTableLayoutPanel_.Controls.Add(this.mSelectionDifferenceLbl_, 4, 2);
        	this.mSummaryTableLayoutPanel_.Controls.Add(this.mSelectionOpeningBalance_, 5, 0);
        	this.mSummaryTableLayoutPanel_.Controls.Add(this.mSelectionClosingBalance_, 5, 1);
        	this.mSummaryTableLayoutPanel_.Controls.Add(this.mSelectionBalanceDifference_, 5, 2);
        	this.mSummaryTableLayoutPanel_.Controls.Add(this.mAllTimeStartingBalanceLbl_, 6, 0);
        	this.mSummaryTableLayoutPanel_.Controls.Add(this.mOpeningBalance_, 7, 0);
        	this.mSummaryTableLayoutPanel_.Controls.Add(this.mCurrentBalance_, 7, 1);
        	this.mSummaryTableLayoutPanel_.Controls.Add(this.mBalanceDiff_, 7, 2);
        	this.mSummaryTableLayoutPanel_.Controls.Add(this.mAllTimeCurrentBalanceLbl_, 6, 1);
        	this.mSummaryTableLayoutPanel_.Controls.Add(this.mAllTimeDifferenceLbl_, 6, 2);
        	this.mSummaryTableLayoutPanel_.Location = new System.Drawing.Point(0, 0);
        	this.mSummaryTableLayoutPanel_.Name = "mSummaryTableLayoutPanel_";
        	this.mSummaryTableLayoutPanel_.RowCount = 3;
        	this.mSummaryTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mSummaryTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mSummaryTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
        	this.mSummaryTableLayoutPanel_.Size = new System.Drawing.Size(859, 78);
        	this.mSummaryTableLayoutPanel_.TabIndex = 19;
        	// 
        	// mTotalCredits_
        	// 
        	this.mTotalCredits_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mTotalCredits_.BackColor = System.Drawing.SystemColors.Window;
        	this.mTotalCredits_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
        	this.mTotalCredits_.ForeColor = System.Drawing.Color.Black;
        	this.mTotalCredits_.Location = new System.Drawing.Point(75, 3);
        	this.mTotalCredits_.Name = "mTotalCredits_";
        	this.mTotalCredits_.ReadOnly = true;
        	this.mTotalCredits_.Size = new System.Drawing.Size(125, 20);
        	this.mTotalCredits_.TabIndex = 6;
        	this.mTotalCredits_.Text = "$0.00";
        	this.mTotalCredits_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        	money1.Value = new decimal(new int[] {
			0,
			0,
			0,
			0});
        	this.mTotalCredits_.Value = money1;
        	// 
        	// mTotalCreditsLbl_
        	// 
        	this.mTotalCreditsLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mTotalCreditsLbl_.AutoSize = true;
        	this.mTotalCreditsLbl_.Location = new System.Drawing.Point(3, 6);
        	this.mTotalCreditsLbl_.Name = "mTotalCreditsLbl_";
        	this.mTotalCreditsLbl_.Size = new System.Drawing.Size(66, 13);
        	this.mTotalCreditsLbl_.TabIndex = 20;
        	this.mTotalCreditsLbl_.Text = "Total Credits";
        	this.mTotalCreditsLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// mTotalDebits_
        	// 
        	this.mTotalDebits_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mTotalDebits_.BackColor = System.Drawing.SystemColors.Window;
        	this.mTotalDebits_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
        	this.mTotalDebits_.ForeColor = System.Drawing.Color.Black;
        	this.mTotalDebits_.Location = new System.Drawing.Point(75, 29);
        	this.mTotalDebits_.Name = "mTotalDebits_";
        	this.mTotalDebits_.ReadOnly = true;
        	this.mTotalDebits_.Size = new System.Drawing.Size(125, 20);
        	this.mTotalDebits_.TabIndex = 5;
        	this.mTotalDebits_.Text = "$0.00";
        	this.mTotalDebits_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        	money2.Value = new decimal(new int[] {
			0,
			0,
			0,
			0});
        	this.mTotalDebits_.Value = money2;
        	// 
        	// mCreditsDebitsDiff_
        	// 
        	this.mCreditsDebitsDiff_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mCreditsDebitsDiff_.BackColor = System.Drawing.SystemColors.Window;
        	this.mCreditsDebitsDiff_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
        	this.mCreditsDebitsDiff_.ForeColor = System.Drawing.Color.Black;
        	this.mCreditsDebitsDiff_.Location = new System.Drawing.Point(75, 55);
        	this.mCreditsDebitsDiff_.Name = "mCreditsDebitsDiff_";
        	this.mCreditsDebitsDiff_.ReadOnly = true;
        	this.mCreditsDebitsDiff_.Size = new System.Drawing.Size(125, 20);
        	this.mCreditsDebitsDiff_.TabIndex = 4;
        	this.mCreditsDebitsDiff_.Text = "$0.00";
        	this.mCreditsDebitsDiff_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        	money3.Value = new decimal(new int[] {
			0,
			0,
			0,
			0});
        	this.mCreditsDebitsDiff_.Value = money3;
        	// 
        	// mTotalTransferIn_
        	// 
        	this.mTotalTransferIn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mTotalTransferIn_.BackColor = System.Drawing.SystemColors.Window;
        	this.mTotalTransferIn_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
        	this.mTotalTransferIn_.ForeColor = System.Drawing.Color.Black;
        	this.mTotalTransferIn_.Location = new System.Drawing.Point(283, 3);
        	this.mTotalTransferIn_.Name = "mTotalTransferIn_";
        	this.mTotalTransferIn_.ReadOnly = true;
        	this.mTotalTransferIn_.Size = new System.Drawing.Size(125, 20);
        	this.mTotalTransferIn_.TabIndex = 3;
        	this.mTotalTransferIn_.Text = "$0.00";
        	this.mTotalTransferIn_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        	money4.Value = new decimal(new int[] {
			0,
			0,
			0,
			0});
        	this.mTotalTransferIn_.Value = money4;
        	// 
        	// mTotalTransferOut_
        	// 
        	this.mTotalTransferOut_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mTotalTransferOut_.BackColor = System.Drawing.SystemColors.Window;
        	this.mTotalTransferOut_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
        	this.mTotalTransferOut_.ForeColor = System.Drawing.Color.Black;
        	this.mTotalTransferOut_.Location = new System.Drawing.Point(283, 29);
        	this.mTotalTransferOut_.Name = "mTotalTransferOut_";
        	this.mTotalTransferOut_.ReadOnly = true;
        	this.mTotalTransferOut_.Size = new System.Drawing.Size(125, 20);
        	this.mTotalTransferOut_.TabIndex = 2;
        	this.mTotalTransferOut_.Text = "$0.00";
        	this.mTotalTransferOut_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        	money5.Value = new decimal(new int[] {
			0,
			0,
			0,
			0});
        	this.mTotalTransferOut_.Value = money5;
        	// 
        	// mTransfersDiff_
        	// 
        	this.mTransfersDiff_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mTransfersDiff_.BackColor = System.Drawing.SystemColors.Window;
        	this.mTransfersDiff_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
        	this.mTransfersDiff_.ForeColor = System.Drawing.Color.Black;
        	this.mTransfersDiff_.Location = new System.Drawing.Point(283, 55);
        	this.mTransfersDiff_.Name = "mTransfersDiff_";
        	this.mTransfersDiff_.ReadOnly = true;
        	this.mTransfersDiff_.Size = new System.Drawing.Size(125, 20);
        	this.mTransfersDiff_.TabIndex = 1;
        	this.mTransfersDiff_.Text = "$0.00";
        	this.mTransfersDiff_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        	money6.Value = new decimal(new int[] {
			0,
			0,
			0,
			0});
        	this.mTransfersDiff_.Value = money6;
        	// 
        	// mSelectionOpeningBalance_
        	// 
        	this.mSelectionOpeningBalance_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mSelectionOpeningBalance_.BackColor = System.Drawing.SystemColors.Window;
        	this.mSelectionOpeningBalance_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
        	this.mSelectionOpeningBalance_.ForeColor = System.Drawing.Color.Black;
        	this.mSelectionOpeningBalance_.Location = new System.Drawing.Point(509, 3);
        	this.mSelectionOpeningBalance_.Name = "mSelectionOpeningBalance_";
        	this.mSelectionOpeningBalance_.ReadOnly = true;
        	this.mSelectionOpeningBalance_.Size = new System.Drawing.Size(125, 20);
        	this.mSelectionOpeningBalance_.TabIndex = 15;
        	this.mSelectionOpeningBalance_.Text = "$0.00";
        	this.mSelectionOpeningBalance_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        	money7.Value = new decimal(new int[] {
			0,
			0,
			0,
			0});
        	this.mSelectionOpeningBalance_.Value = money7;
        	// 
        	// mSelectionClosingBalance_
        	// 
        	this.mSelectionClosingBalance_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mSelectionClosingBalance_.BackColor = System.Drawing.SystemColors.Window;
        	this.mSelectionClosingBalance_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
        	this.mSelectionClosingBalance_.ForeColor = System.Drawing.Color.Black;
        	this.mSelectionClosingBalance_.Location = new System.Drawing.Point(509, 29);
        	this.mSelectionClosingBalance_.Name = "mSelectionClosingBalance_";
        	this.mSelectionClosingBalance_.ReadOnly = true;
        	this.mSelectionClosingBalance_.Size = new System.Drawing.Size(125, 20);
        	this.mSelectionClosingBalance_.TabIndex = 16;
        	this.mSelectionClosingBalance_.Text = "$0.00";
        	this.mSelectionClosingBalance_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        	money8.Value = new decimal(new int[] {
			0,
			0,
			0,
			0});
        	this.mSelectionClosingBalance_.Value = money8;
        	// 
        	// mSelectionBalanceDifference_
        	// 
        	this.mSelectionBalanceDifference_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mSelectionBalanceDifference_.BackColor = System.Drawing.SystemColors.Window;
        	this.mSelectionBalanceDifference_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
        	this.mSelectionBalanceDifference_.ForeColor = System.Drawing.Color.Black;
        	this.mSelectionBalanceDifference_.Location = new System.Drawing.Point(509, 55);
        	this.mSelectionBalanceDifference_.Name = "mSelectionBalanceDifference_";
        	this.mSelectionBalanceDifference_.ReadOnly = true;
        	this.mSelectionBalanceDifference_.Size = new System.Drawing.Size(125, 20);
        	this.mSelectionBalanceDifference_.TabIndex = 17;
        	this.mSelectionBalanceDifference_.Text = "$0.00";
        	this.mSelectionBalanceDifference_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        	money9.Value = new decimal(new int[] {
			0,
			0,
			0,
			0});
        	this.mSelectionBalanceDifference_.Value = money9;
        	// 
        	// mOpeningBalance_
        	// 
        	this.mOpeningBalance_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mOpeningBalance_.BackColor = System.Drawing.SystemColors.Window;
        	this.mOpeningBalance_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
        	this.mOpeningBalance_.ForeColor = System.Drawing.Color.Black;
        	this.mOpeningBalance_.Location = new System.Drawing.Point(731, 3);
        	this.mOpeningBalance_.Name = "mOpeningBalance_";
        	this.mOpeningBalance_.ReadOnly = true;
        	this.mOpeningBalance_.Size = new System.Drawing.Size(125, 20);
        	this.mOpeningBalance_.TabIndex = 4;
        	this.mOpeningBalance_.Text = "$0.00";
        	this.mOpeningBalance_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        	money10.Value = new decimal(new int[] {
			0,
			0,
			0,
			0});
        	this.mOpeningBalance_.Value = money10;
        	// 
        	// mCurrentBalance_
        	// 
        	this.mCurrentBalance_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mCurrentBalance_.BackColor = System.Drawing.SystemColors.Window;
        	this.mCurrentBalance_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
        	this.mCurrentBalance_.ForeColor = System.Drawing.Color.Black;
        	this.mCurrentBalance_.Location = new System.Drawing.Point(731, 29);
        	this.mCurrentBalance_.Name = "mCurrentBalance_";
        	this.mCurrentBalance_.ReadOnly = true;
        	this.mCurrentBalance_.Size = new System.Drawing.Size(125, 20);
        	this.mCurrentBalance_.TabIndex = 5;
        	this.mCurrentBalance_.Text = "$0.00";
        	this.mCurrentBalance_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        	money11.Value = new decimal(new int[] {
			0,
			0,
			0,
			0});
        	this.mCurrentBalance_.Value = money11;
        	// 
        	// mBalanceDiff_
        	// 
        	this.mBalanceDiff_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.mBalanceDiff_.BackColor = System.Drawing.SystemColors.Window;
        	this.mBalanceDiff_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
        	this.mBalanceDiff_.ForeColor = System.Drawing.Color.Black;
        	this.mBalanceDiff_.Location = new System.Drawing.Point(731, 55);
        	this.mBalanceDiff_.Name = "mBalanceDiff_";
        	this.mBalanceDiff_.ReadOnly = true;
        	this.mBalanceDiff_.Size = new System.Drawing.Size(125, 20);
        	this.mBalanceDiff_.TabIndex = 0;
        	this.mBalanceDiff_.Text = "$0.00";
        	this.mBalanceDiff_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        	money12.Value = new decimal(new int[] {
			0,
			0,
			0,
			0});
        	this.mBalanceDiff_.Value = money12;
        	// 
        	// SummaryPanel
        	// 
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        	this.AutoSize = true;
        	this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        	this.Controls.Add(this.mSummaryTableLayoutPanel_);
        	this.Name = "SummaryPanel";
        	this.Size = new System.Drawing.Size(862, 81);
        	this.mSummaryTableLayoutPanel_.ResumeLayout(false);
        	this.mSummaryTableLayoutPanel_.PerformLayout();
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }

        #endregion

        private Controls.MoneyBox mTotalCredits_;
        private Controls.MoneyBox mTotalDebits_;
        private Controls.MoneyBox mCreditsDebitsDiff_;
        private Controls.MoneyBox mTotalTransferIn_;
        private Controls.MoneyBox mTotalTransferOut_;
        private Controls.MoneyBox mTransfersDiff_;
        private Controls.MoneyBox mBalanceDiff_;
        private Controls.MoneyBox mOpeningBalance_;
        private Controls.MoneyBox mCurrentBalance_;
        private Controls.MoneyBox mSelectionOpeningBalance_;
        private Controls.MoneyBox mSelectionClosingBalance_;
        private Controls.MoneyBox mSelectionBalanceDifference_;
        private System.Windows.Forms.TableLayoutPanel mSummaryTableLayoutPanel_;
        private System.Windows.Forms.Label mTotalCreditsLbl_;
        private System.Windows.Forms.Label mTotalDebitsLbl_;
        private System.Windows.Forms.Label mCreditsDebitsDifferenceLbl_;
        private System.Windows.Forms.Label mTransferInLbl_;
        private System.Windows.Forms.Label mTransferOutLbl_;
        private System.Windows.Forms.Label mTransfersDifferenceLbl_;
        private System.Windows.Forms.Label mSelectionOpeningBalanceLbl_;
        private System.Windows.Forms.Label mSelectionClosingBalanceLbl_;
        private System.Windows.Forms.Label mSelectionDifferenceLbl_;
        private System.Windows.Forms.Label mAllTimeStartingBalanceLbl_;
        private System.Windows.Forms.Label mAllTimeCurrentBalanceLbl_;
        private System.Windows.Forms.Label mAllTimeDifferenceLbl_;
    }
}
