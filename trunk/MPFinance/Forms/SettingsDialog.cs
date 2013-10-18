using System;
using System.Windows.Forms;
using MPersist.Core;
using MPersist.Enums;
using MPersist.Message.Response;
using MPFinance.Properties;
using MPFinanceCore.Data.Viewed;
using MPFinanceCore.Enums;
using MPFinanceCore.Message.Requests;
using MPFinanceCore.Message.Responses;

namespace MPFinance.Forms
{
    public partial class SettingsDialog : Form
    {
        private static Logger Log = Logger.GetInstance(typeof(SettingsDialog));

        #region Variable Declarations

        private VwOperator mOperator_;

        #endregion

        #region Parameters

        public VwOperator Operator { get { return mOperator_; } }

        #endregion

        #region Constructors

        public SettingsDialog(VwOperator o)
        {
            mOperator_ = o;

            InitializeComponent();

            mGender_.DataSource = Gender.Elements;
            mDefaultDatasource_.DataSource = new ConnectionType[] { ConnectionType.NULL, ConnectionType.SQLite, ConnectionType.MySql, ConnectionType.Oracle };
        }

        #endregion

        #region Override Methods

        protected override void OnLoad(EventArgs e)
        {
            if (mOperator_.OperatorId == null || mOperator_.OperatorId.IsNotSet)
            {
                Text = "Create new user";
                mUsername_.Enabled = true;
                mUsername_.ReadOnly = false;
            }            

            mUsername_.Text = mOperator_.Username;
            mPassword1_.Text = mOperator_.Password;
            mPassword2_.Text = mOperator_.Password;
            mFirstName_.Text = mOperator_.FirstName;
            mLastName_.Text = mOperator_.LastName;
            mEmail_.Text = mOperator_.Email;
            mGender_.SelectedItem = mOperator_.Gender;
            mBirthday_.Value = mOperator_.Birthday > mBirthday_.MinDate ? mOperator_.Birthday : mBirthday_.MinDate;

            mRowPerPage_.Value = Settings.Default.RowsPerPage;
            mDefaultDatasource_.SelectedItem = ConnectionType.GetElement(Settings.Default.DefaultDatasource);
            mDefaultUsername_.Checked = Settings.Default.DefaultUsername.Equals(mOperator_.Username);
        }

        #endregion

        #region Private Methods

        private void TestConnectionSuccess(ResponseMessage response)
        {
            //ConnectionSettings.Connections.Remove(ConnectionSettings.GetConnectionSettings("TEST"));
        }

        private void TestConnectionError(ResponseMessage response)
        {
            //ConnectionSettings.Connections.Remove(ConnectionSettings.GetConnectionSettings("TEST"));

            throw new MPException("Connection failed");
        }

        private void UpdateOperatorSuccess(ResponseMessage response)
        {
            mOperator_ = ((UpdateOperatorRS)response).Operator;

            if (mDefaultUsername_.Checked)
            {
                Settings.Default.DefaultUsername = mUsername_.Text.Trim();
            }

            Settings.Default.RowsPerPage = (Int32)mRowPerPage_.Value;
            Settings.Default.DefaultDatasource = (Int64)mDefaultDatasource_.SelectedValue;
            Settings.Default.Save();

            DialogResult = DialogResult.OK;
            Dispose();
        }

        #endregion

        #region Public Methods



        #endregion

        #region Event Listenners

        private void mOKBtn__Click(object sender, EventArgs e)
        {
            mOperator_.Username = mUsername_.Text.Trim();
            mOperator_.FirstName = mFirstName_.Text.Trim();
            mOperator_.LastName = mLastName_.Text.Trim();
            mOperator_.Email = mEmail_.Text.Trim();
            mOperator_.Birthday = mBirthday_.Value;
            mOperator_.Gender = (Gender)mGender_.SelectedItem;

            UpdateOperatorRQ request = new UpdateOperatorRQ();
            request.Operator = mOperator_;
            request.Password1 = mPassword1_.Text;
            request.Password2 = mPassword2_.Text;
            IOController.SendRequest(request, UpdateOperatorSuccess);
        }

        private void mCancelBtn__Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Dispose();
        }

        private void mTestOracle__Click(object sender, EventArgs e)
        {
            //ConnectionSettings.AddOracleConnection("TEST", mOracleHost_.Text.Trim(), Decimal.ToInt32(mOraclePort_.Value), mOracleDatabase_.Text.Trim(), mOracleUsername_.Text.Trim(), mOraclePassword_.Text.Trim());

            TestConnectionRQ request = new TestConnectionRQ();
            request.Connection = "TEST";
            IOController.SendRequest(request, TestConnectionSuccess, TestConnectionError);
        }

        private void mTestMySql__Click(object sender, EventArgs e)
        {
            //ConnectionSettings.AddMySqlConnection("TEST", mMySqlHost_.Text.Trim(), mMySqlDatabase_.Text.Trim(), mMySqlUsername_.Text.Trim(), mMySqlPassword_.Text.Trim());
            
            TestConnectionRQ request = new TestConnectionRQ();
            request.Connection = "TEST";
            IOController.SendRequest(request, TestConnectionSuccess, TestConnectionError);
        }

        private void mTestSqlite__Click(object sender, EventArgs e)
        {
            //ConnectionSettings.AddSqliteConnection("TEST", mSqliteDatasource_.Text.Trim());

            TestConnectionRQ request = new TestConnectionRQ();
            request.Connection = "TEST";
            IOController.SendRequest(request, TestConnectionSuccess, TestConnectionError);
        }

        private void mFileDialog__Click(object sender, EventArgs e)
        {
            if(mOpenFileDialog_.ShowDialog(this) == DialogResult.OK)
            {
                mSqliteDatasource_.Text = mOpenFileDialog_.FileName;
            }
        }

        #endregion
    }
}
