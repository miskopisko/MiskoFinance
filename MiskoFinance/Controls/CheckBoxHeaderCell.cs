using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using MiskoPersist.Core;

namespace MiskoFinance.Controls
{
	public partial class CheckBoxHeaderCell : DataGridViewColumnHeaderCell
	{
		private static Logger Log = Logger.GetInstance(typeof(CheckBoxHeaderCell));

		#region Delegate Functions

		public delegate void CheckBoxClickedHandler(Object sender, CheckBoxHeaderCellClickedArgs args);
		public event CheckBoxClickedHandler OnCheckBoxClicked;		

		#endregion

		#region Fields

		private String mText_ = "";
		private CheckBoxState mState_ = CheckBoxState.UncheckedNormal;
		private Point mCheckBoxLocation_;
		private Point mCellLocation_ = new Point();
		private Size mCheckBoxSize_;
		private Boolean mChecked_ = false;
		private Boolean mEnabled_ = true;

		#endregion

		#region Properties

		public Boolean Enabled { get { return mEnabled_; } set { mEnabled_ = value; } }
		public Boolean Checked { get { return mChecked_; } set { mChecked_ = value; } }

		#endregion

		#region Constructors

		public CheckBoxHeaderCell()
		{
		}

		public CheckBoxHeaderCell(String text)
		{
			mText_ = text;
		}

		#endregion        

		#region Override Methods

		protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, Int32 rowIndex, DataGridViewElementStates dataGridViewElementState, Object value, Object formattedValue, String errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
		{
			base.Paint(graphics, clipBounds, cellBounds, rowIndex, dataGridViewElementState, value, "      " + mText_, errorText, cellStyle, advancedBorderStyle, paintParts);

			Point p = new Point();
			Size s = CheckBoxRenderer.GetGlyphSize(graphics, CheckBoxState.UncheckedNormal);
			p.X = cellBounds.Location.X + (cellBounds.Width / 2) - (s.Width / 2) - 25;
			p.Y = cellBounds.Location.Y + (cellBounds.Height / 2) - (s.Height / 2);
			mCellLocation_ = cellBounds.Location;
			mCheckBoxLocation_ = p;
			mCheckBoxSize_ = s;

			if (mChecked_ && mEnabled_)
			{
				mState_ = CheckBoxState.CheckedNormal;
			}
			else if (!mChecked_ && mEnabled_)
			{
				mState_ = CheckBoxState.UncheckedNormal;
			}
			else
			{
				mState_ = CheckBoxState.UncheckedDisabled;
				mChecked_ = false;
			}

			CheckBoxRenderer.DrawCheckBox(graphics, mCheckBoxLocation_, mState_);
		}

		protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
		{
			Point p = new Point(e.X + mCellLocation_.X, e.Y + mCellLocation_.Y);
			if (p.X >= mCheckBoxLocation_.X && p.X <= mCheckBoxLocation_.X + mCheckBoxSize_.Width && p.Y >= mCheckBoxLocation_.Y && p.Y <= mCheckBoxLocation_.Y + mCheckBoxSize_.Height)
			{
				mChecked_ = !mChecked_;
				if (OnCheckBoxClicked != null)
				{
					OnCheckBoxClicked(this, new CheckBoxHeaderCellClickedArgs() { Checked = mChecked_ });
					DataGridView.InvalidateCell(this);
				}
			}
			base.OnMouseClick(e);
		}

		#endregion
	}

	public sealed class CheckBoxHeaderCellClickedArgs : EventArgs
	{

		public Boolean Checked
		{
			get;
			set;
		}

	}
}
