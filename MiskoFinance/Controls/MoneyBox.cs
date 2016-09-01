using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MiskoPersist.MoneyType;

namespace MiskoFinance.Controls
{
	public partial class MoneyBox : TextBox
    {
        [DllImport("user32.dll")]
        static extern Boolean HideCaret(IntPtr hWnd);

        #region Fields

        private Money mValue_ = Money.ZERO;
        private Boolean mFocused_ = false;        

        #endregion

        #region Properties

        public Money? Value 
        {
            get 
            {
            	mValue_ = !String.IsNullOrEmpty(Text) ? new Money(Text.Replace("$", "")) : Money.ZERO;
                return mValue_;
            }
            set 
            {
                mValue_ = value ?? Money.ZERO;
                Text = mValue_.ToString();
            }
        }
        
        #endregion

        #region Constructor

        public MoneyBox()
        {
            InitializeComponent();
            Text = Value.ToString();
        }

        #endregion

        #region Override Methods
        
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			
			if(ReadOnly)
			{
				Cursor = Cursors.Default;
			}
		}

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);

            if (!ReadOnly)
            {
				Value = !String.IsNullOrEmpty(Text) ? new Money(Text.Replace("$", "")) : Money.ZERO;
				
                mFocused_ = false;                
            }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            if (!ReadOnly)
            {
                if(MouseButtons == MouseButtons.None)
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
            
            if(ReadOnly)
            {
            	SelectionLength = 0;
            }

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

            if(mValue_ < Money.ZERO)
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
                if(Char.IsDigit(e.KeyChar) || e.KeyChar.Equals('-') || e.KeyChar.Equals('.') || e.KeyChar.Equals('\b'))
                {
                    if(e.KeyChar.Equals('-') && SelectionStart != 0)
                    {
                        e.Handled = true;
                    }

                    if(Regex.IsMatch(Text, @"\.\d\d") && SelectionStart > Text.LastIndexOf('.') && !e.KeyChar.Equals('\b'))
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
        
		protected override void OnMouseHover(EventArgs e)
		{
			base.OnMouseHover(e);
			
			if(ReadOnly)
			{
				Cursor = Cursors.Default;
			}
		}
        
		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
			
			if(ReadOnly)
			{
				SelectionLength = 0;
			}
		}
		
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			
			if(ReadOnly)
			{
				SelectionLength = 0;
			}
		}

        #endregion
    }
}
