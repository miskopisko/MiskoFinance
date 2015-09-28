using System;
using System.Windows.Forms;
using MiskoFinance.Properties;
using MiskoFinanceCore.Data.Viewed;
using MiskoFinanceCore.Enums;
using MiskoFinanceCore.Message.Requests;
using MiskoPersist.Core;
using MiskoPersist.Message.Response;

namespace MiskoFinance.Forms
{
    public partial class SettingsDialog : Form
    {
        private static Logger Log = Logger.GetInstance(typeof(SettingsDialog));

        #region Fields

        private VwOperator mOperator_;

        #endregion

        #region Parameters

        public VwOperator Operator 
        { 
        	get 
        	{ 
        		return mOperator_; 
        	} 
        }

        #endregion

        #region Constructors

        public SettingsDialog(VwOperator o)
        {
        	InitializeComponent();
            
        	mGender_.DataSource = Gender.Elements;
        	
        	mOperator_ = (VwOperator)o.Clone();
            
            mUsername_.DataBindings.Add("Text", mOperator_, "Username", true, DataSourceUpdateMode.OnPropertyChanged);
            mFirstName_.DataBindings.Add("Text", mOperator_, "FirstName", true, DataSourceUpdateMode.OnPropertyChanged);
            mLastName_.DataBindings.Add("Text", mOperator_, "LastName", true, DataSourceUpdateMode.OnPropertyChanged);
            mEmail_.DataBindings.Add("Text", mOperator_, "Email", true, DataSourceUpdateMode.OnPropertyChanged);
            mGender_.DataBindings.Add("SelectedItem", mOperator_, "Gender", true, DataSourceUpdateMode.OnPropertyChanged);
            mBirthday_.DataBindings.Add("Value", mOperator_, "Birthday", true, DataSourceUpdateMode.OnPropertyChanged, mBirthday_.MinDate);
        }

        #endregion

        #region Override Methods

        protected override void OnLoad(EventArgs e)
        {
            if (mOperator_ == null || mOperator_.IsNotSet)
            {
                Text = "Create new user";
                mUsername_.Enabled = true;
                mUsername_.ReadOnly = false;
            }            

            mRowPerPage_.Value = Settings.Default.RowsPerPage;
            
            CenterToParent();
        }

        #endregion

        #region Private Methods

        private void UpdateOperatorSuccess(ResponseMessage response)
        {
            Settings.Default.RowsPerPage = (Int32)mRowPerPage_.Value;
            Settings.Default.Save();

            DialogResult = DialogResult.OK;
            Dispose();
        }
        
        private void UpdateOperatorError(ResponseMessage response)
        {
        	Enabled = true;
        }

        #endregion

        #region Public Methods



        #endregion

        #region Event Listenners

        private void mOK__Click(Object sender, EventArgs e)
        {
            Enabled = false;

            UpdateOperatorRQ request = new UpdateOperatorRQ();
            request.Operator = mOperator_;
            request.Password1 = mPassword1_.Text;
            request.Password2 = mPassword2_.Text;
            ServerConnection.SendRequest(request, UpdateOperatorSuccess, UpdateOperatorError);
        }

        private void mCancel__Click(Object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Dispose();
        }

        #endregion
    }
}
