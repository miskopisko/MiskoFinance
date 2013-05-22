using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using MPersist.Core;

namespace MPFinance.Forms.Controls
{
    public partial class CheckBoxHeaderCell : DataGridViewColumnHeaderCell
    {
        private static readonly Logger Log = Logger.GetInstance(typeof(CheckBoxHeaderCell));

        #region Variable declarations

        private String Text_ = "";
        private CheckBoxState State_ = CheckBoxState.UncheckedNormal;
        private Point CheckBoxLocation_;
        private Point CellLocation_ = new Point();
        private Size CheckBoxSize_;
        private bool Checked_ = false;
        private bool Enabled_ = true;

        #endregion

        #region Properties

        public bool Enabled
        {
            get { return Enabled_; }
            set { Enabled_ = value; }
        }

        public bool Checked
        {
            get { return Checked_; }
            set { Checked_ = value; }
        }

        #endregion

        public CheckBoxHeaderCell()
        {
        }

        public CheckBoxHeaderCell(String text)
        {
            Text_ = text;
        }

        #region Delegate Functions

        public delegate void CheckBoxClickedHandler(bool state);
        public event CheckBoxClickedHandler OnCheckBoxClicked;

        #endregion

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates dataGridViewElementState, object value, object formattedValue, String errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, dataGridViewElementState, value, "      " + Text_, errorText, cellStyle, advancedBorderStyle, paintParts);

            Point p = new Point();
            Size s = CheckBoxRenderer.GetGlyphSize(graphics, CheckBoxState.UncheckedNormal);
            p.X = cellBounds.Location.X + (cellBounds.Width / 2) - (s.Width / 2) - 25;
            p.Y = cellBounds.Location.Y + (cellBounds.Height / 2) - (s.Height / 2);
            CellLocation_ = cellBounds.Location;
            CheckBoxLocation_ = p;
            CheckBoxSize_ = s;

            if (Checked_ && Enabled_)
            {
                State_ = CheckBoxState.CheckedNormal;
            }
            else if (!Checked_ && Enabled_)
            {
                State_ = CheckBoxState.UncheckedNormal;
            }
            else
            {
                State_ = CheckBoxState.UncheckedDisabled;
                Checked_ = false;
            }

            CheckBoxRenderer.DrawCheckBox(graphics, CheckBoxLocation_, State_);
        }

        protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
        {
            Point p = new Point(e.X + CellLocation_.X, e.Y + CellLocation_.Y);
            if (p.X >= CheckBoxLocation_.X && p.X <= CheckBoxLocation_.X + CheckBoxSize_.Width && p.Y >= CheckBoxLocation_.Y && p.Y <= CheckBoxLocation_.Y + CheckBoxSize_.Height)
            {
                Checked_ = !Checked_;
                if (OnCheckBoxClicked != null)
                {
                    OnCheckBoxClicked(Checked_);
                    DataGridView.InvalidateCell(this);
                }
            }
            base.OnMouseClick(e);
        }
    }
}
