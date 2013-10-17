using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MPersist.Core;
using MPersist.MoneyType;

namespace MPFinance.Controls
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
            Text = mValue_.ToString();
        }

        #endregion

        #region Override Methods

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);

            if (!ReadOnly)
            {
                if (!String.IsNullOrEmpty(Text))
                {
                    Value = new Money(Text);
                }
                else
                {
                    Value = new Money(0);
                }
                mFocused_ = false;                
            }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

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
            base.OnMouseUp(mevent);

            if (!ReadOnly && !mFocused_ && SelectionLength == 0)
            {
                Text = Text.Replace("$", "");
                mFocused_ = true;
                SelectAll();
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            if (mValue_ != null && mValue_.lessThen(Money.ZERO))
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
            base.OnKeyPress(e);

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
