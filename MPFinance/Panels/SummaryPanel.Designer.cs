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
            MPersist.MoneyType.Money money1 = new MPersist.MoneyType.Money();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SummaryPanel));
            MPersist.MoneyType.Money money2 = new MPersist.MoneyType.Money();
            MPersist.MoneyType.Money money3 = new MPersist.MoneyType.Money();
            MPersist.MoneyType.Money money4 = new MPersist.MoneyType.Money();
            MPersist.MoneyType.Money money5 = new MPersist.MoneyType.Money();
            MPersist.MoneyType.Money money6 = new MPersist.MoneyType.Money();
            MPersist.MoneyType.Money money7 = new MPersist.MoneyType.Money();
            MPersist.MoneyType.Money money8 = new MPersist.MoneyType.Money();
            MPersist.MoneyType.Money money9 = new MPersist.MoneyType.Money();
            MPersist.MoneyType.Money money10 = new MPersist.MoneyType.Money();
            MPersist.MoneyType.Money money11 = new MPersist.MoneyType.Money();
            MPersist.MoneyType.Money money12 = new MPersist.MoneyType.Money();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.mSummaryTableLayoutPanel_ = new System.Windows.Forms.TableLayoutPanel();
            this.mCreditsDebitsDiff_ = new MPFinance.Controls.MoneyBox();
            this.mTotalDebits_ = new MPFinance.Controls.MoneyBox();
            this.mTransfersDiff_ = new MPFinance.Controls.MoneyBox();
            this.mTotalCredits_ = new MPFinance.Controls.MoneyBox();
            this.mBalanceDiff_ = new MPFinance.Controls.MoneyBox();
            this.mCurrentBalance_ = new MPFinance.Controls.MoneyBox();
            this.mOpeningBalance_ = new MPFinance.Controls.MoneyBox();
            this.mSelectionBalanceDifference_ = new MPFinance.Controls.MoneyBox();
            this.mSelectionClosingBalance_ = new MPFinance.Controls.MoneyBox();
            this.mSelectionOpeningBalance_ = new MPFinance.Controls.MoneyBox();
            this.mTotalTransferIn_ = new MPFinance.Controls.MoneyBox();
            this.mTotalTransferOut_ = new MPFinance.Controls.MoneyBox();
            this.mSummaryTableLayoutPanel_.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.mSummaryTableLayoutPanel_.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 37);
            this.label1.TabIndex = 18;
            this.label1.Text = "Selection Summary";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.mSummaryTableLayoutPanel_.SetColumnSpan(this.label2, 2);
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 370);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(302, 37);
            this.label2.TabIndex = 19;
            this.label2.Text = "All Time Summary";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Total Credits";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Total Debits";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Difference";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Transfers In";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Transfers Out";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 234);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Difference";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 271);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "Opening Balance";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 308);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Closing Balance";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 345);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "Difference";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 419);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "Starting Balance";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 456);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "Current Balance";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 499);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 13);
            this.label14.TabIndex = 31;
            this.label14.Text = "Difference";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mSummaryTableLayoutPanel_
            // 
            this.mSummaryTableLayoutPanel_.ColumnCount = 2;
            this.mSummaryTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.mSummaryTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mSummaryTableLayoutPanel_.Controls.Add(this.mCreditsDebitsDiff_, 1, 3);
            this.mSummaryTableLayoutPanel_.Controls.Add(this.mTotalDebits_, 1, 2);
            this.mSummaryTableLayoutPanel_.Controls.Add(this.mTransfersDiff_, 1, 6);
            this.mSummaryTableLayoutPanel_.Controls.Add(this.mTotalCredits_, 1, 1);
            this.mSummaryTableLayoutPanel_.Controls.Add(this.mBalanceDiff_, 1, 13);
            this.mSummaryTableLayoutPanel_.Controls.Add(this.mCurrentBalance_, 1, 12);
            this.mSummaryTableLayoutPanel_.Controls.Add(this.mOpeningBalance_, 1, 11);
            this.mSummaryTableLayoutPanel_.Controls.Add(this.mSelectionBalanceDifference_, 1, 9);
            this.mSummaryTableLayoutPanel_.Controls.Add(this.mSelectionClosingBalance_, 1, 8);
            this.mSummaryTableLayoutPanel_.Controls.Add(this.mSelectionOpeningBalance_, 1, 7);
            this.mSummaryTableLayoutPanel_.Controls.Add(this.label1, 0, 0);
            this.mSummaryTableLayoutPanel_.Controls.Add(this.label2, 0, 10);
            this.mSummaryTableLayoutPanel_.Controls.Add(this.label3, 0, 1);
            this.mSummaryTableLayoutPanel_.Controls.Add(this.label4, 0, 2);
            this.mSummaryTableLayoutPanel_.Controls.Add(this.label5, 0, 3);
            this.mSummaryTableLayoutPanel_.Controls.Add(this.label6, 0, 4);
            this.mSummaryTableLayoutPanel_.Controls.Add(this.label7, 0, 5);
            this.mSummaryTableLayoutPanel_.Controls.Add(this.label8, 0, 6);
            this.mSummaryTableLayoutPanel_.Controls.Add(this.label9, 0, 7);
            this.mSummaryTableLayoutPanel_.Controls.Add(this.label10, 0, 8);
            this.mSummaryTableLayoutPanel_.Controls.Add(this.label11, 0, 9);
            this.mSummaryTableLayoutPanel_.Controls.Add(this.label12, 0, 11);
            this.mSummaryTableLayoutPanel_.Controls.Add(this.label13, 0, 12);
            this.mSummaryTableLayoutPanel_.Controls.Add(this.label14, 0, 13);
            this.mSummaryTableLayoutPanel_.Controls.Add(this.mTotalTransferIn_, 1, 4);
            this.mSummaryTableLayoutPanel_.Controls.Add(this.mTotalTransferOut_, 1, 5);
            this.mSummaryTableLayoutPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mSummaryTableLayoutPanel_.Location = new System.Drawing.Point(0, 0);
            this.mSummaryTableLayoutPanel_.Name = "mSummaryTableLayoutPanel_";
            this.mSummaryTableLayoutPanel_.RowCount = 14;
            this.mSummaryTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142859F));
            this.mSummaryTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142859F));
            this.mSummaryTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142859F));
            this.mSummaryTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142859F));
            this.mSummaryTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142859F));
            this.mSummaryTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142859F));
            this.mSummaryTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142859F));
            this.mSummaryTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142859F));
            this.mSummaryTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142859F));
            this.mSummaryTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142859F));
            this.mSummaryTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142859F));
            this.mSummaryTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142859F));
            this.mSummaryTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142859F));
            this.mSummaryTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142859F));
            this.mSummaryTableLayoutPanel_.Size = new System.Drawing.Size(308, 530);
            this.mSummaryTableLayoutPanel_.TabIndex = 19;
            // 
            // mCreditsDebitsDiff_
            // 
            this.mCreditsDebitsDiff_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mCreditsDebitsDiff_.BackColor = System.Drawing.SystemColors.Window;
            this.mCreditsDebitsDiff_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mCreditsDebitsDiff_.ForeColor = System.Drawing.Color.Black;
            this.mCreditsDebitsDiff_.Location = new System.Drawing.Point(98, 119);
            this.mCreditsDebitsDiff_.Name = "mCreditsDebitsDiff_";
            this.mCreditsDebitsDiff_.ReadOnly = true;
            this.mCreditsDebitsDiff_.Size = new System.Drawing.Size(207, 20);
            this.mCreditsDebitsDiff_.TabIndex = 4;
            this.mCreditsDebitsDiff_.Text = "$0.00";
            this.mCreditsDebitsDiff_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            money1.Currency = ((MPersist.MoneyType.Currency)(resources.GetObject("money1.Currency")));
            this.mCreditsDebitsDiff_.Value = money1;
            // 
            // mTotalDebits_
            // 
            this.mTotalDebits_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mTotalDebits_.BackColor = System.Drawing.SystemColors.Window;
            this.mTotalDebits_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mTotalDebits_.ForeColor = System.Drawing.Color.Black;
            this.mTotalDebits_.Location = new System.Drawing.Point(98, 82);
            this.mTotalDebits_.Name = "mTotalDebits_";
            this.mTotalDebits_.ReadOnly = true;
            this.mTotalDebits_.Size = new System.Drawing.Size(207, 20);
            this.mTotalDebits_.TabIndex = 5;
            this.mTotalDebits_.Text = "$0.00";
            this.mTotalDebits_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            money2.Currency = ((MPersist.MoneyType.Currency)(resources.GetObject("money2.Currency")));
            this.mTotalDebits_.Value = money2;
            // 
            // mTransfersDiff_
            // 
            this.mTransfersDiff_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mTransfersDiff_.BackColor = System.Drawing.SystemColors.Window;
            this.mTransfersDiff_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mTransfersDiff_.ForeColor = System.Drawing.Color.Black;
            this.mTransfersDiff_.Location = new System.Drawing.Point(98, 230);
            this.mTransfersDiff_.Name = "mTransfersDiff_";
            this.mTransfersDiff_.ReadOnly = true;
            this.mTransfersDiff_.Size = new System.Drawing.Size(207, 20);
            this.mTransfersDiff_.TabIndex = 1;
            this.mTransfersDiff_.Text = "$0.00";
            this.mTransfersDiff_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            money3.Currency = ((MPersist.MoneyType.Currency)(resources.GetObject("money3.Currency")));
            this.mTransfersDiff_.Value = money3;
            // 
            // mTotalCredits_
            // 
            this.mTotalCredits_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mTotalCredits_.BackColor = System.Drawing.SystemColors.Window;
            this.mTotalCredits_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mTotalCredits_.ForeColor = System.Drawing.Color.Black;
            this.mTotalCredits_.Location = new System.Drawing.Point(98, 45);
            this.mTotalCredits_.Name = "mTotalCredits_";
            this.mTotalCredits_.ReadOnly = true;
            this.mTotalCredits_.Size = new System.Drawing.Size(207, 20);
            this.mTotalCredits_.TabIndex = 6;
            this.mTotalCredits_.Text = "$0.00";
            this.mTotalCredits_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            money4.Currency = ((MPersist.MoneyType.Currency)(resources.GetObject("money4.Currency")));
            this.mTotalCredits_.Value = money4;
            // 
            // mBalanceDiff_
            // 
            this.mBalanceDiff_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mBalanceDiff_.BackColor = System.Drawing.SystemColors.Window;
            this.mBalanceDiff_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mBalanceDiff_.ForeColor = System.Drawing.Color.Black;
            this.mBalanceDiff_.Location = new System.Drawing.Point(98, 495);
            this.mBalanceDiff_.Name = "mBalanceDiff_";
            this.mBalanceDiff_.ReadOnly = true;
            this.mBalanceDiff_.Size = new System.Drawing.Size(207, 20);
            this.mBalanceDiff_.TabIndex = 0;
            this.mBalanceDiff_.Text = "$0.00";
            this.mBalanceDiff_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            money5.Currency = ((MPersist.MoneyType.Currency)(resources.GetObject("money5.Currency")));
            this.mBalanceDiff_.Value = money5;
            // 
            // mCurrentBalance_
            // 
            this.mCurrentBalance_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mCurrentBalance_.BackColor = System.Drawing.SystemColors.Window;
            this.mCurrentBalance_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mCurrentBalance_.ForeColor = System.Drawing.Color.Black;
            this.mCurrentBalance_.Location = new System.Drawing.Point(98, 452);
            this.mCurrentBalance_.Name = "mCurrentBalance_";
            this.mCurrentBalance_.ReadOnly = true;
            this.mCurrentBalance_.Size = new System.Drawing.Size(207, 20);
            this.mCurrentBalance_.TabIndex = 5;
            this.mCurrentBalance_.Text = "$0.00";
            this.mCurrentBalance_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            money6.Currency = ((MPersist.MoneyType.Currency)(resources.GetObject("money6.Currency")));
            this.mCurrentBalance_.Value = money6;
            // 
            // mOpeningBalance_
            // 
            this.mOpeningBalance_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mOpeningBalance_.BackColor = System.Drawing.SystemColors.Window;
            this.mOpeningBalance_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mOpeningBalance_.ForeColor = System.Drawing.Color.Black;
            this.mOpeningBalance_.Location = new System.Drawing.Point(98, 415);
            this.mOpeningBalance_.Name = "mOpeningBalance_";
            this.mOpeningBalance_.ReadOnly = true;
            this.mOpeningBalance_.Size = new System.Drawing.Size(207, 20);
            this.mOpeningBalance_.TabIndex = 4;
            this.mOpeningBalance_.Text = "$0.00";
            this.mOpeningBalance_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            money7.Currency = ((MPersist.MoneyType.Currency)(resources.GetObject("money7.Currency")));
            this.mOpeningBalance_.Value = money7;
            // 
            // mSelectionBalanceDifference_
            // 
            this.mSelectionBalanceDifference_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mSelectionBalanceDifference_.BackColor = System.Drawing.SystemColors.Window;
            this.mSelectionBalanceDifference_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mSelectionBalanceDifference_.ForeColor = System.Drawing.Color.Black;
            this.mSelectionBalanceDifference_.Location = new System.Drawing.Point(98, 341);
            this.mSelectionBalanceDifference_.Name = "mSelectionBalanceDifference_";
            this.mSelectionBalanceDifference_.ReadOnly = true;
            this.mSelectionBalanceDifference_.Size = new System.Drawing.Size(207, 20);
            this.mSelectionBalanceDifference_.TabIndex = 17;
            this.mSelectionBalanceDifference_.Text = "$0.00";
            this.mSelectionBalanceDifference_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            money8.Currency = ((MPersist.MoneyType.Currency)(resources.GetObject("money8.Currency")));
            this.mSelectionBalanceDifference_.Value = money8;
            // 
            // mSelectionClosingBalance_
            // 
            this.mSelectionClosingBalance_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mSelectionClosingBalance_.BackColor = System.Drawing.SystemColors.Window;
            this.mSelectionClosingBalance_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mSelectionClosingBalance_.ForeColor = System.Drawing.Color.Black;
            this.mSelectionClosingBalance_.Location = new System.Drawing.Point(98, 304);
            this.mSelectionClosingBalance_.Name = "mSelectionClosingBalance_";
            this.mSelectionClosingBalance_.ReadOnly = true;
            this.mSelectionClosingBalance_.Size = new System.Drawing.Size(207, 20);
            this.mSelectionClosingBalance_.TabIndex = 16;
            this.mSelectionClosingBalance_.Text = "$0.00";
            this.mSelectionClosingBalance_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            money9.Currency = ((MPersist.MoneyType.Currency)(resources.GetObject("money9.Currency")));
            this.mSelectionClosingBalance_.Value = money9;
            // 
            // mSelectionOpeningBalance_
            // 
            this.mSelectionOpeningBalance_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mSelectionOpeningBalance_.BackColor = System.Drawing.SystemColors.Window;
            this.mSelectionOpeningBalance_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mSelectionOpeningBalance_.ForeColor = System.Drawing.Color.Black;
            this.mSelectionOpeningBalance_.Location = new System.Drawing.Point(98, 267);
            this.mSelectionOpeningBalance_.Name = "mSelectionOpeningBalance_";
            this.mSelectionOpeningBalance_.ReadOnly = true;
            this.mSelectionOpeningBalance_.Size = new System.Drawing.Size(207, 20);
            this.mSelectionOpeningBalance_.TabIndex = 15;
            this.mSelectionOpeningBalance_.Text = "$0.00";
            this.mSelectionOpeningBalance_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            money10.Currency = ((MPersist.MoneyType.Currency)(resources.GetObject("money10.Currency")));
            this.mSelectionOpeningBalance_.Value = money10;
            // 
            // mTotalTransferIn_
            // 
            this.mTotalTransferIn_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mTotalTransferIn_.BackColor = System.Drawing.SystemColors.Window;
            this.mTotalTransferIn_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mTotalTransferIn_.ForeColor = System.Drawing.Color.Black;
            this.mTotalTransferIn_.Location = new System.Drawing.Point(98, 156);
            this.mTotalTransferIn_.Name = "mTotalTransferIn_";
            this.mTotalTransferIn_.ReadOnly = true;
            this.mTotalTransferIn_.Size = new System.Drawing.Size(207, 20);
            this.mTotalTransferIn_.TabIndex = 3;
            this.mTotalTransferIn_.Text = "$0.00";
            this.mTotalTransferIn_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            money11.Currency = ((MPersist.MoneyType.Currency)(resources.GetObject("money11.Currency")));
            this.mTotalTransferIn_.Value = money11;
            // 
            // mTotalTransferOut_
            // 
            this.mTotalTransferOut_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mTotalTransferOut_.BackColor = System.Drawing.SystemColors.Window;
            this.mTotalTransferOut_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mTotalTransferOut_.ForeColor = System.Drawing.Color.Black;
            this.mTotalTransferOut_.Location = new System.Drawing.Point(98, 193);
            this.mTotalTransferOut_.Name = "mTotalTransferOut_";
            this.mTotalTransferOut_.ReadOnly = true;
            this.mTotalTransferOut_.Size = new System.Drawing.Size(207, 20);
            this.mTotalTransferOut_.TabIndex = 2;
            this.mTotalTransferOut_.Text = "$0.00";
            this.mTotalTransferOut_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            money12.Currency = ((MPersist.MoneyType.Currency)(resources.GetObject("money12.Currency")));
            this.mTotalTransferOut_.Value = money12;
            // 
            // SummaryPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.Controls.Add(this.mSummaryTableLayoutPanel_);
            this.Name = "SummaryPanel";
            this.Size = new System.Drawing.Size(308, 530);
            this.mSummaryTableLayoutPanel_.ResumeLayout(false);
            this.mSummaryTableLayoutPanel_.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
    }
}
