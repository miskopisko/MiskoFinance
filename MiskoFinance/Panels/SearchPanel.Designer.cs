/*
 * Created by SharpDevelop.
 * User: mpiskuric
 * Date: 08/05/2015
 * Time: 4:10 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MiskoFinance.Panels
{
	partial class SearchPanel
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button mSearch_;
		private System.Windows.Forms.Label mCategoryLbl_;
		private System.Windows.Forms.ComboBox mCategories_;
		private System.Windows.Forms.TextBox mDescription_;
		private System.Windows.Forms.Label mDescriptionLbl_;
		private System.Windows.Forms.DateTimePicker mToDate_;
		private System.Windows.Forms.DateTimePicker mFromDate_;
		private System.Windows.Forms.Label mFromLbl_;
		private System.Windows.Forms.Label mToLbl_;
		private System.Windows.Forms.ComboBox mAccounts_;
		private System.Windows.Forms.TableLayoutPanel mTableLayoutPanel_;
		private System.Windows.Forms.Button mMore_;
		
		/// <summary>
		/// Disposes resources used by the control.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.mSearch_ = new System.Windows.Forms.Button();
			this.mCategories_ = new System.Windows.Forms.ComboBox();
			this.mCategoryLbl_ = new System.Windows.Forms.Label();
			this.mDescription_ = new System.Windows.Forms.TextBox();
			this.mDescriptionLbl_ = new System.Windows.Forms.Label();
			this.mToDate_ = new System.Windows.Forms.DateTimePicker();
			this.mFromDate_ = new System.Windows.Forms.DateTimePicker();
			this.mFromLbl_ = new System.Windows.Forms.Label();
			this.mToLbl_ = new System.Windows.Forms.Label();
			this.mAccounts_ = new System.Windows.Forms.ComboBox();
			this.mTableLayoutPanel_ = new System.Windows.Forms.TableLayoutPanel();
			this.mMore_ = new System.Windows.Forms.Button();
			this.mTableLayoutPanel_.SuspendLayout();
			this.SuspendLayout();
			// 
			// mSearch_
			// 
			this.mSearch_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mSearch_.Location = new System.Drawing.Point(1039, 3);
			this.mSearch_.Name = "mSearch_";
			this.mSearch_.Size = new System.Drawing.Size(79, 23);
			this.mSearch_.TabIndex = 0;
			this.mSearch_.Text = "Search";
			this.mSearch_.UseVisualStyleBackColor = true;
			// 
			// mCategories_
			// 
			this.mCategories_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mCategories_.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.mCategories_.FormattingEnabled = true;
			this.mCategories_.Location = new System.Drawing.Point(833, 4);
			this.mCategories_.Name = "mCategories_";
			this.mCategories_.Size = new System.Drawing.Size(200, 21);
			this.mCategories_.TabIndex = 2;
			// 
			// mCategoryLbl_
			// 
			this.mCategoryLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mCategoryLbl_.AutoSize = true;
			this.mCategoryLbl_.Location = new System.Drawing.Point(778, 8);
			this.mCategoryLbl_.Name = "mCategoryLbl_";
			this.mCategoryLbl_.Size = new System.Drawing.Size(49, 13);
			this.mCategoryLbl_.TabIndex = 1;
			this.mCategoryLbl_.Text = "Category";
			this.mCategoryLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// mDescription_
			// 
			this.mDescription_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mDescription_.Location = new System.Drawing.Point(599, 4);
			this.mDescription_.Name = "mDescription_";
			this.mDescription_.Size = new System.Drawing.Size(173, 20);
			this.mDescription_.TabIndex = 3;
			// 
			// mDescriptionLbl_
			// 
			this.mDescriptionLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mDescriptionLbl_.AutoSize = true;
			this.mDescriptionLbl_.Location = new System.Drawing.Point(533, 8);
			this.mDescriptionLbl_.Name = "mDescriptionLbl_";
			this.mDescriptionLbl_.Size = new System.Drawing.Size(60, 13);
			this.mDescriptionLbl_.TabIndex = 4;
			this.mDescriptionLbl_.Text = "Description";
			this.mDescriptionLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// mToDate_
			// 
			this.mToDate_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mToDate_.CustomFormat = "MMM dd, yyyy";
			this.mToDate_.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.mToDate_.Location = new System.Drawing.Point(402, 4);
			this.mToDate_.Name = "mToDate_";
			this.mToDate_.Size = new System.Drawing.Size(125, 20);
			this.mToDate_.TabIndex = 5;
			// 
			// mFromDate_
			// 
			this.mFromDate_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mFromDate_.CustomFormat = "MMM dd, yyyy";
			this.mFromDate_.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.mFromDate_.Location = new System.Drawing.Point(245, 4);
			this.mFromDate_.Name = "mFromDate_";
			this.mFromDate_.Size = new System.Drawing.Size(125, 20);
			this.mFromDate_.TabIndex = 6;
			// 
			// mFromLbl_
			// 
			this.mFromLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mFromLbl_.AutoSize = true;
			this.mFromLbl_.Location = new System.Drawing.Point(209, 8);
			this.mFromLbl_.Name = "mFromLbl_";
			this.mFromLbl_.Size = new System.Drawing.Size(30, 13);
			this.mFromLbl_.TabIndex = 7;
			this.mFromLbl_.Text = "From";
			this.mFromLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// mToLbl_
			// 
			this.mToLbl_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mToLbl_.AutoSize = true;
			this.mToLbl_.Location = new System.Drawing.Point(376, 8);
			this.mToLbl_.Name = "mToLbl_";
			this.mToLbl_.Size = new System.Drawing.Size(20, 13);
			this.mToLbl_.TabIndex = 8;
			this.mToLbl_.Text = "To";
			this.mToLbl_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// mAccounts_
			// 
			this.mAccounts_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mAccounts_.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.mAccounts_.FormattingEnabled = true;
			this.mAccounts_.Location = new System.Drawing.Point(3, 4);
			this.mAccounts_.Name = "mAccounts_";
			this.mAccounts_.Size = new System.Drawing.Size(200, 21);
			this.mAccounts_.TabIndex = 9;
			// 
			// mTableLayoutPanel_
			// 
			this.mTableLayoutPanel_.AutoSize = true;
			this.mTableLayoutPanel_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.mTableLayoutPanel_.ColumnCount = 11;
			this.mTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mTableLayoutPanel_.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.mTableLayoutPanel_.Controls.Add(this.mSearch_, 9, 0);
			this.mTableLayoutPanel_.Controls.Add(this.mAccounts_, 0, 0);
			this.mTableLayoutPanel_.Controls.Add(this.mCategories_, 8, 0);
			this.mTableLayoutPanel_.Controls.Add(this.mFromLbl_, 1, 0);
			this.mTableLayoutPanel_.Controls.Add(this.mCategoryLbl_, 7, 0);
			this.mTableLayoutPanel_.Controls.Add(this.mFromDate_, 2, 0);
			this.mTableLayoutPanel_.Controls.Add(this.mDescription_, 6, 0);
			this.mTableLayoutPanel_.Controls.Add(this.mToLbl_, 3, 0);
			this.mTableLayoutPanel_.Controls.Add(this.mDescriptionLbl_, 5, 0);
			this.mTableLayoutPanel_.Controls.Add(this.mToDate_, 4, 0);
			this.mTableLayoutPanel_.Controls.Add(this.mMore_, 10, 0);
			this.mTableLayoutPanel_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mTableLayoutPanel_.Location = new System.Drawing.Point(0, 0);
			this.mTableLayoutPanel_.Name = "mTableLayoutPanel_";
			this.mTableLayoutPanel_.RowCount = 1;
			this.mTableLayoutPanel_.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mTableLayoutPanel_.Size = new System.Drawing.Size(1202, 29);
			this.mTableLayoutPanel_.TabIndex = 2;
			// 
			// mMore_
			// 
			this.mMore_.Location = new System.Drawing.Point(1124, 3);
			this.mMore_.Name = "mMore_";
			this.mMore_.Size = new System.Drawing.Size(75, 23);
			this.mMore_.TabIndex = 10;
			this.mMore_.Text = "More";
			this.mMore_.UseVisualStyleBackColor = true;
			// 
			// SearchPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.mTableLayoutPanel_);
			this.Name = "SearchPanel";
			this.Size = new System.Drawing.Size(1202, 29);
			this.mTableLayoutPanel_.ResumeLayout(false);
			this.mTableLayoutPanel_.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
