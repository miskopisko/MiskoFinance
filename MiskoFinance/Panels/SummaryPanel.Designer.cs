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
            if(disposing && (components != null))
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
            this.mSelectionOpeningBalanceLbl_ = new System.Windows.Forms.Label();
            this.mSelectionClosingBalanceLbl_ = new System.Windows.Forms.Label();
            this.mSelectionDifferenceLbl_ = new System.Windows.Forms.Label();
            this.mSummaryTableLayoutPanel_ = new System.Windows.Forms.TableLayoutPanel();
            this.mSelectionBalanceDifference_ = new MiskoFinance.Controls.MoneyBox();
            this.mSelectionClosingBalance_ = new MiskoFinance.Controls.MoneyBox();
            this.mSelectionOpeningBalance_ = new MiskoFinance.Controls.MoneyBox();
            this.mSelectionBalanceLbl_ = new System.Windows.Forms.Label();
            this.mSummaryTableLayoutPanel_.SuspendLayout();
            this.SuspendLayout();
            // 
            // mSelectionOpeningBalanceLbl_
            // 
            this.mSelectionOpeningBalanceLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mSelectionOpeningBalanceLbl_.AutoSize = true;
            this.mSelectionOpeningBalanceLbl_.Location = new System.Drawing.Point(3, 20);
            this.mSelectionOpeningBalanceLbl_.Name = "mSelectionOpeningBalanceLbl_";
            this.mSelectionOpeningBalanceLbl_.Size = new System.Drawing.Size(73, 17);
            this.mSelectionOpeningBalanceLbl_.TabIndex = 26;
            this.mSelectionOpeningBalanceLbl_.Text = "Opening";
            this.mSelectionOpeningBalanceLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mSelectionClosingBalanceLbl_
            // 
            this.mSelectionClosingBalanceLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mSelectionClosingBalanceLbl_.AutoSize = true;
            this.mSelectionClosingBalanceLbl_.Location = new System.Drawing.Point(3, 43);
            this.mSelectionClosingBalanceLbl_.Name = "mSelectionClosingBalanceLbl_";
            this.mSelectionClosingBalanceLbl_.Size = new System.Drawing.Size(73, 17);
            this.mSelectionClosingBalanceLbl_.TabIndex = 27;
            this.mSelectionClosingBalanceLbl_.Text = "Closing";
            this.mSelectionClosingBalanceLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mSelectionDifferenceLbl_
            // 
            this.mSelectionDifferenceLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mSelectionDifferenceLbl_.AutoSize = true;
            this.mSelectionDifferenceLbl_.Location = new System.Drawing.Point(3, 66);
            this.mSelectionDifferenceLbl_.Name = "mSelectionDifferenceLbl_";
            this.mSelectionDifferenceLbl_.Size = new System.Drawing.Size(73, 17);
            this.mSelectionDifferenceLbl_.TabIndex = 28;
            this.mSelectionDifferenceLbl_.Text = "Difference";
            this.mSelectionDifferenceLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mSummaryTableLayoutPanel_
            // 
            this.mSummaryTableLayoutPanel_.AutoSize = true;
            this.mSummaryTableLayoutPanel_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mSummaryTableLayoutPanel_.ColumnCount = 2;
            this.mSummaryTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.mSummaryTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.mSummaryTableLayoutPanel_.Controls.Add(this.mSelectionDifferenceLbl_, 0, 3);
            this.mSummaryTableLayoutPanel_.Controls.Add(this.mSelectionBalanceDifference_, 1, 3);
            this.mSummaryTableLayoutPanel_.Controls.Add(this.mSelectionClosingBalance_, 1, 2);
            this.mSummaryTableLayoutPanel_.Controls.Add(this.mSelectionClosingBalanceLbl_, 0, 2);
            this.mSummaryTableLayoutPanel_.Controls.Add(this.mSelectionOpeningBalance_, 1, 1);
            this.mSummaryTableLayoutPanel_.Controls.Add(this.mSelectionOpeningBalanceLbl_, 0, 1);
            this.mSummaryTableLayoutPanel_.Controls.Add(this.mSelectionBalanceLbl_, 0, 0);
            this.mSummaryTableLayoutPanel_.Location = new System.Drawing.Point(0, 0);
            this.mSummaryTableLayoutPanel_.Name = "mSummaryTableLayoutPanel_";
            this.mSummaryTableLayoutPanel_.RowCount = 4;
            this.mSummaryTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mSummaryTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mSummaryTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mSummaryTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mSummaryTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mSummaryTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mSummaryTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mSummaryTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mSummaryTableLayoutPanel_.Size = new System.Drawing.Size(204, 86);
            this.mSummaryTableLayoutPanel_.TabIndex = 19;
            // 
            // mSelectionBalanceDifference_
            // 
            this.mSelectionBalanceDifference_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mSelectionBalanceDifference_.BackColor = System.Drawing.SystemColors.Window;
            this.mSelectionBalanceDifference_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mSelectionBalanceDifference_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mSelectionBalanceDifference_.ForeColor = System.Drawing.Color.Black;
            this.mSelectionBalanceDifference_.Location = new System.Drawing.Point(79, 63);
            this.mSelectionBalanceDifference_.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.mSelectionBalanceDifference_.Name = "mSelectionBalanceDifference_";
            this.mSelectionBalanceDifference_.ReadOnly = true;
            this.mSelectionBalanceDifference_.Size = new System.Drawing.Size(125, 22);
            this.mSelectionBalanceDifference_.TabIndex = 17;
            this.mSelectionBalanceDifference_.Text = "$0.00";
            this.mSelectionBalanceDifference_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // mSelectionClosingBalance_
            // 
            this.mSelectionClosingBalance_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mSelectionClosingBalance_.BackColor = System.Drawing.SystemColors.Window;
            this.mSelectionClosingBalance_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mSelectionClosingBalance_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mSelectionClosingBalance_.ForeColor = System.Drawing.Color.Black;
            this.mSelectionClosingBalance_.Location = new System.Drawing.Point(79, 40);
            this.mSelectionClosingBalance_.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.mSelectionClosingBalance_.Name = "mSelectionClosingBalance_";
            this.mSelectionClosingBalance_.ReadOnly = true;
            this.mSelectionClosingBalance_.Size = new System.Drawing.Size(125, 22);
            this.mSelectionClosingBalance_.TabIndex = 16;
            this.mSelectionClosingBalance_.Text = "$0.00";
            this.mSelectionClosingBalance_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // mSelectionOpeningBalance_
            // 
            this.mSelectionOpeningBalance_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mSelectionOpeningBalance_.BackColor = System.Drawing.SystemColors.Window;
            this.mSelectionOpeningBalance_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mSelectionOpeningBalance_.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mSelectionOpeningBalance_.ForeColor = System.Drawing.Color.Black;
            this.mSelectionOpeningBalance_.Location = new System.Drawing.Point(79, 17);
            this.mSelectionOpeningBalance_.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.mSelectionOpeningBalance_.Name = "mSelectionOpeningBalance_";
            this.mSelectionOpeningBalance_.ReadOnly = true;
            this.mSelectionOpeningBalance_.Size = new System.Drawing.Size(125, 22);
            this.mSelectionOpeningBalance_.TabIndex = 15;
            this.mSelectionOpeningBalance_.Text = "$0.00";
            this.mSelectionOpeningBalance_.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // mSelectionBalanceLbl_
            // 
            this.mSelectionBalanceLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mSelectionBalanceLbl_.AutoSize = true;
            this.mSummaryTableLayoutPanel_.SetColumnSpan(this.mSelectionBalanceLbl_, 2);
            this.mSelectionBalanceLbl_.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mSelectionBalanceLbl_.Location = new System.Drawing.Point(3, 0);
            this.mSelectionBalanceLbl_.Name = "mSelectionBalanceLbl_";
            this.mSelectionBalanceLbl_.Size = new System.Drawing.Size(198, 17);
            this.mSelectionBalanceLbl_.TabIndex = 32;
            this.mSelectionBalanceLbl_.Text = "Selection Balance";
            // 
            // SummaryPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.mSummaryTableLayoutPanel_);
            this.Name = "SummaryPanel";
            this.Size = new System.Drawing.Size(207, 89);
            this.mSummaryTableLayoutPanel_.ResumeLayout(false);
            this.mSummaryTableLayoutPanel_.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Controls.MoneyBox mSelectionOpeningBalance_;
        private Controls.MoneyBox mSelectionClosingBalance_;
        private Controls.MoneyBox mSelectionBalanceDifference_;
        private System.Windows.Forms.TableLayoutPanel mSummaryTableLayoutPanel_;
        private System.Windows.Forms.Label mSelectionOpeningBalanceLbl_;
        private System.Windows.Forms.Label mSelectionClosingBalanceLbl_;
        private System.Windows.Forms.Label mSelectionDifferenceLbl_;
		private System.Windows.Forms.Label mSelectionBalanceLbl_;
	}
}
