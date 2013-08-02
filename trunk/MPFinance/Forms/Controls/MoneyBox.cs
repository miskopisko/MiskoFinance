using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MPersist.Core;
using MPersist.Core.MoneyType;

namespace MPFinance.Forms.Controls
{
    public partial class MoneyBox : TextBox
    {
        private static Logger Log = Logger.GetInstance(typeof(TransactionsGridView));

        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);

        #region Fields

        private Money mValue_ = new Money(0);
        private Boolean mFocused_ = false;        

        #endregion

        #region Properties

        public Money Value 
        {
            get 
            {
                mValue_ = new Money(Text.Replace("$", ""));
                return mValue_;
            }
            set 
            {
                mValue_ = value;
                if (mValue_ == null)
                {
                    mValue_ = new Money(0);
                }
                Text = mValue_.ToString();
            }
        }

        #endregion

        #region Constructor

        public MoneyBox()
        {
            InitializeComponent();
            TextAlign = HorizontalAlignment.Right;
            Text = mValue_.ToString();
        }

        #endregion

        #region Override Methods

        protected override void OnLeave(EventArgs e)
        {
            if (!ReadOnly)
            {
                mFocused_ = false;
                Value = new Money(Text);
            }

            base.OnLeave(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            if (!ReadOnly)
            {
                if (MouseButtons == MouseButtons.None)
                {
                    Text = Text.Replace("$", "");                    
                    mFocused_ = true;
                    SelectAll();
                }
            }
            else
            {
                HideCaret(Handle);
            }
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            if (!ReadOnly && !mFocused_ && SelectionLength == 0)
            {
                Text = Text.Replace("$", "");
                mFocused_ = true;
                SelectAll();
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (mValue_ != null && mValue_.lessThen(Money.Zero))
            {
                ForeColor = Color.Red;
            }
            else
            {
                ForeColor = Color.Black;
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (!ReadOnly)
            {
                if (Char.IsDigit(e.KeyChar) || e.KeyChar.Equals('-') || e.KeyChar.Equals('.') || e.KeyChar.Equals('\b'))
                {
                    if (e.KeyChar.Equals('-') && SelectionStart != 0)
                    {
                        e.Handled = true;
                    }

                    if (Regex.IsMatch(Text, @"\.\d\d") && SelectionStart > Text.LastIndexOf('.') && !e.KeyChar.Equals('\b'))
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        #endregion
    }
}
