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
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label0;
            System.Windows.Forms.Label label9;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SummaryPanel));
            this.Summary = new System.Windows.Forms.GroupBox();
            this.SummaryLayoutTable = new System.Windows.Forms.TableLayoutPanel();
            this.CurrentBalance = new MPFinance.Forms.Controls.MoneyBox();
            this.CreditsDebitsDiff = new MPFinance.Forms.Controls.MoneyBox();
            this.OpeningBalance = new MPFinance.Forms.Controls.MoneyBox();
            this.TotalCredits = new MPFinance.Forms.Controls.MoneyBox();
            this.TotalTransferOut = new MPFinance.Forms.Controls.MoneyBox();
            this.TotalDebits = new MPFinance.Forms.Controls.MoneyBox();
            this.TotalTransferIn = new MPFinance.Forms.Controls.MoneyBox();
            this.TransfersDiff = new MPFinance.Forms.Controls.MoneyBox();
            this.BalanceDiff = new MPFinance.Forms.Controls.MoneyBox();
            label10 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label0 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            this.Summary.SuspendLayout();
            this.SummaryLayoutTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // label10
            // 
            label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(62, 269);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(56, 13);
            label10.TabIndex = 25;
            label10.Text = "Difference";
            label10.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label8
            // 
            label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(29, 201);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(89, 13);
            label8.TabIndex = 21;
            label8.Text = "Opening Balance";
            label8.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label3
            // 
            label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(62, 169);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(56, 13);
            label3.TabIndex = 20;
            label3.Text = "Difference";
            label3.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label5
            // 
            label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(20, 137);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(98, 13);
            label5.TabIndex = 19;
            label5.Text = "Total Transfers Out";
            label5.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(28, 105);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(90, 13);
            label2.TabIndex = 18;
            label2.Text = "Total Transfers In";
            label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(62, 73);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(56, 13);
            label1.TabIndex = 6;
            label1.Text = "Difference";
            label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label4
            // 
            label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(54, 41);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(64, 13);
            label4.TabIndex = 5;
            label4.Text = "Total Debits";
            label4.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label0
            // 
            label0.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label0.AutoSize = true;
            label0.Location = new System.Drawing.Point(52, 9);
            label0.Name = "label0";
            label0.Size = new System.Drawing.Size(66, 13);
            label0.TabIndex = 1;
            label0.Text = "Total Credits";
            label0.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label9
            // 
            label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(35, 233);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(83, 13);
            label9.TabIndex = 28;
            label9.Text = "Closing Balance";
            label9.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // Summary
            // 
            this.Summary.Controls.Add(this.SummaryLayoutTable);
            this.Summary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Summary.Location = new System.Drawing.Point(0, 0);
            this.Summary.Name = "Summary";
            this.Summary.Size = new System.Drawing.Size(249, 315);
            this.Summary.TabIndex = 10;
            this.Summary.TabStop = false;
            this.Summary.Text = "Summary";
            // 
            // SummaryLayoutTable
            // 
            this.SummaryLayoutTable.ColumnCount = 2;
            this.SummaryLayoutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SummaryLayoutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SummaryLayoutTable.Controls.Add(label10, 0, 8);
            this.SummaryLayoutTable.Controls.Add(label8, 0, 6);
            this.SummaryLayoutTable.Controls.Add(label3, 0, 5);
            this.SummaryLayoutTable.Controls.Add(label5, 0, 4);
            this.SummaryLayoutTable.Controls.Add(label2, 0, 3);
            this.SummaryLayoutTable.Controls.Add(this.CurrentBalance, 1, 7);
            this.SummaryLayoutTable.Controls.Add(this.CreditsDebitsDiff, 1, 2);
            this.SummaryLayoutTable.Controls.Add(label1, 0, 2);
            this.SummaryLayoutTable.Controls.Add(label4, 0, 1);
            this.SummaryLayoutTable.Controls.Add(label0, 0, 0);
            this.SummaryLayoutTable.Controls.Add(this.OpeningBalance, 1, 6);
            this.SummaryLayoutTable.Controls.Add(this.TotalCredits, 1, 0);
            this.SummaryLayoutTable.Controls.Add(this.TotalTransferOut, 1, 4);
            this.SummaryLayoutTable.Controls.Add(this.TotalDebits, 1, 1);
            this.SummaryLayoutTable.Controls.Add(this.TotalTransferIn, 1, 3);
            this.SummaryLayoutTable.Controls.Add(this.TransfersDiff, 1, 5);
            this.SummaryLayoutTable.Controls.Add(label9, 0, 7);
            this.SummaryLayoutTable.Controls.Add(this.BalanceDiff, 1, 8);
            this.SummaryLayoutTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SummaryLayoutTable.Location = new System.Drawing.Point(3, 16);
            this.SummaryLayoutTable.Name = "SummaryLayoutTable";
            this.SummaryLayoutTable.RowCount = 9;
            this.SummaryLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.SummaryLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.SummaryLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.SummaryLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.SummaryLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.SummaryLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.SummaryLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.SummaryLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.SummaryLayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.SummaryLayoutTable.Size = new System.Drawing.Size(243, 296);
            this.SummaryLayoutTable.TabIndex = 0;
            // 
            // CurrentBalance
            // 
            this.CurrentBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentBalance.BackColor = System.Drawing.SystemColors.Window;
            this.CurrentBalance.ForeColor = System.Drawing.Color.Black;
            this.CurrentBalance.Location = new System.Drawing.Point(124, 230);
            this.CurrentBalance.Name = "CurrentBalance";
            this.CurrentBalance.ReadOnly = true;
            this.CurrentBalance.Size = new System.Drawing.Size(116, 20);
            this.CurrentBalance.TabIndex = 16;
            this.CurrentBalance.Text = "$0.00";
            this.CurrentBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CurrentBalance.Value = ((MPersist.Core.MoneyType.Money)(resources.GetObject("CurrentBalance.Value")));
            // 
            // CreditsDebitsDiff
            // 
            this.CreditsDebitsDiff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CreditsDebitsDiff.BackColor = System.Drawing.SystemColors.Window;
            this.CreditsDebitsDiff.ForeColor = System.Drawing.Color.Black;
            this.CreditsDebitsDiff.Location = new System.Drawing.Point(124, 70);
            this.CreditsDebitsDiff.Name = "CreditsDebitsDiff";
            this.CreditsDebitsDiff.ReadOnly = true;
            this.CreditsDebitsDiff.Size = new System.Drawing.Size(116, 20);
            this.CreditsDebitsDiff.TabIndex = 17;
            this.CreditsDebitsDiff.Text = "$0.00";
            this.CreditsDebitsDiff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CreditsDebitsDiff.Value = ((MPersist.Core.MoneyType.Money)(resources.GetObject("CreditsDebitsDiff.Value")));
            // 
            // OpeningBalance
            // 
            this.OpeningBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.OpeningBalance.BackColor = System.Drawing.SystemColors.Window;
            this.OpeningBalance.ForeColor = System.Drawing.Color.Black;
            this.OpeningBalance.Location = new System.Drawing.Point(124, 198);
            this.OpeningBalance.Name = "OpeningBalance";
            this.OpeningBalance.ReadOnly = true;
            this.OpeningBalance.Size = new System.Drawing.Size(116, 20);
            this.OpeningBalance.TabIndex = 11;
            this.OpeningBalance.Text = "$0.00";
            this.OpeningBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.OpeningBalance.Value = ((MPersist.Core.MoneyType.Money)(resources.GetObject("OpeningBalance.Value")));
            // 
            // TotalCredits
            // 
            this.TotalCredits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalCredits.BackColor = System.Drawing.SystemColors.Window;
            this.TotalCredits.ForeColor = System.Drawing.Color.Black;
            this.TotalCredits.Location = new System.Drawing.Point(124, 6);
            this.TotalCredits.Name = "TotalCredits";
            this.TotalCredits.ReadOnly = true;
            this.TotalCredits.Size = new System.Drawing.Size(116, 20);
            this.TotalCredits.TabIndex = 6;
            this.TotalCredits.Text = "$0.00";
            this.TotalCredits.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TotalCredits.Value = ((MPersist.Core.MoneyType.Money)(resources.GetObject("TotalCredits.Value")));
            // 
            // TotalTransferOut
            // 
            this.TotalTransferOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalTransferOut.BackColor = System.Drawing.SystemColors.Window;
            this.TotalTransferOut.ForeColor = System.Drawing.Color.Black;
            this.TotalTransferOut.Location = new System.Drawing.Point(124, 134);
            this.TotalTransferOut.Name = "TotalTransferOut";
            this.TotalTransferOut.ReadOnly = true;
            this.TotalTransferOut.Size = new System.Drawing.Size(116, 20);
            this.TotalTransferOut.TabIndex = 9;
            this.TotalTransferOut.Text = "$0.00";
            this.TotalTransferOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TotalTransferOut.Value = ((MPersist.Core.MoneyType.Money)(resources.GetObject("TotalTransferOut.Value")));
            // 
            // TotalDebits
            // 
            this.TotalDebits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalDebits.BackColor = System.Drawing.SystemColors.Window;
            this.TotalDebits.ForeColor = System.Drawing.Color.Black;
            this.TotalDebits.Location = new System.Drawing.Point(124, 38);
            this.TotalDebits.Name = "TotalDebits";
            this.TotalDebits.ReadOnly = true;
            this.TotalDebits.Size = new System.Drawing.Size(116, 20);
            this.TotalDebits.TabIndex = 8;
            this.TotalDebits.Text = "$0.00";
            this.TotalDebits.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TotalDebits.Value = ((MPersist.Core.MoneyType.Money)(resources.GetObject("TotalDebits.Value")));
            // 
            // TotalTransferIn
            // 
            this.TotalTransferIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalTransferIn.BackColor = System.Drawing.SystemColors.Window;
            this.TotalTransferIn.ForeColor = System.Drawing.Color.Black;
            this.TotalTransferIn.Location = new System.Drawing.Point(124, 102);
            this.TotalTransferIn.Name = "TotalTransferIn";
            this.TotalTransferIn.ReadOnly = true;
            this.TotalTransferIn.Size = new System.Drawing.Size(116, 20);
            this.TotalTransferIn.TabIndex = 7;
            this.TotalTransferIn.Text = "$0.00";
            this.TotalTransferIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TotalTransferIn.Value = ((MPersist.Core.MoneyType.Money)(resources.GetObject("TotalTransferIn.Value")));
            // 
            // TransfersDiff
            // 
            this.TransfersDiff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TransfersDiff.BackColor = System.Drawing.SystemColors.Window;
            this.TransfersDiff.ForeColor = System.Drawing.Color.Black;
            this.TransfersDiff.Location = new System.Drawing.Point(124, 166);
            this.TransfersDiff.Name = "TransfersDiff";
            this.TransfersDiff.ReadOnly = true;
            this.TransfersDiff.Size = new System.Drawing.Size(116, 20);
            this.TransfersDiff.TabIndex = 10;
            this.TransfersDiff.Text = "$0.00";
            this.TransfersDiff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TransfersDiff.Value = ((MPersist.Core.MoneyType.Money)(resources.GetObject("TransfersDiff.Value")));
            // 
            // BalanceDiff
            // 
            this.BalanceDiff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BalanceDiff.BackColor = System.Drawing.SystemColors.Window;
            this.BalanceDiff.ForeColor = System.Drawing.Color.Black;
            this.BalanceDiff.Location = new System.Drawing.Point(124, 266);
            this.BalanceDiff.Name = "BalanceDiff";
            this.BalanceDiff.ReadOnly = true;
            this.BalanceDiff.Size = new System.Drawing.Size(116, 20);
            this.BalanceDiff.TabIndex = 24;
            this.BalanceDiff.Text = "$0.00";
            this.BalanceDiff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.BalanceDiff.Value = ((MPersist.Core.MoneyType.Money)(resources.GetObject("BalanceDiff.Value")));
            // 
            // SummaryPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Summary);
            this.Name = "SummaryPanel";
            this.Size = new System.Drawing.Size(249, 315);
            this.Summary.ResumeLayout(false);
            this.SummaryLayoutTable.ResumeLayout(false);
            this.SummaryLayoutTable.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Summary;
        private System.Windows.Forms.TableLayoutPanel SummaryLayoutTable;
        private Controls.MoneyBox CurrentBalance;
        private Controls.MoneyBox CreditsDebitsDiff;
        private Controls.MoneyBox OpeningBalance;
        private Controls.MoneyBox TotalCredits;
        private Controls.MoneyBox TotalTransferOut;
        private Controls.MoneyBox TotalDebits;
        private Controls.MoneyBox TotalTransferIn;
        private Controls.MoneyBox TransfersDiff;
        private Controls.MoneyBox BalanceDiff;
    }
}
