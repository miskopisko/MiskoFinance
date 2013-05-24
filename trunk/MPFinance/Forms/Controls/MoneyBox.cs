using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MPersist.Core.MoneyType;

namespace MPFinance.Forms.Controls
{
    public partial class MoneyBox : TextBox
    {
        #region Variable Declarations

        private Money mValue_ = null;

        #endregion

        #region Properties

        public Money Value 
        {
            get 
            {
                if (String.IsNullOrEmpty(Text))
                {
                    return null;
                }
                else
                {
                    return new Money(Convert.ToDecimal(Text.Replace("$", "")));
                }
            }
            set 
            {
                mValue_ = value;
                if (mValue_ != null)
                {
                    Text = mValue_.ToString();
                }
            }
        }

        #endregion

        public MoneyBox()
        {
            InitializeComponent();
            TextAlign = HorizontalAlignment.Right;
        }

        protected override void OnLostFocus(EventArgs e)
        {
            if (!ReadOnly)
            {
                mValue_ = null;
                if(!String.IsNullOrEmpty(Text))
                {
                    mValue_ = new Money(Convert.ToDecimal(Text));
                }

                if (Text.Length > 0)
                {
                    Text = mValue_.ToString();
                }
            }

            base.OnLostFocus(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            if (!ReadOnly)
            {
                Text = Text.Replace("$", "");
                Select(0, Text.Length);                
            }

            base.OnGotFocus(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (mValue_ != null && mValue_.lessThen(Money.Zero))
            {
                if (ReadOnly)
                {
                    ReadOnly = false;
                    ForeColor = Color.Red;
                    ReadOnly = true;
                }
                else
                {
                    ForeColor = Color.Red;
                }
            }
            else
            {
                if (ReadOnly)
                {
                    ReadOnly = false;
                    ForeColor = Color.Black;
                    ReadOnly = true;
                }
                else
                {
                    ForeColor = Color.Black;
                }
            }

            base.OnTextChanged(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar.Equals('-') || e.KeyChar.Equals('.') || e.KeyChar.Equals('\b'))
            {
                if (e.KeyChar.Equals('-') && SelectionStart != 0)
                {
                    e.Handled = true;
                }

                if (Regex.IsMatch(Text, @"\.\d\d") && SelectionStart > Text.LastIndexOf('.'))
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
            }

            base.OnKeyPress(e);
        }
    }
}
