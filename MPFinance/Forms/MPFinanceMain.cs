using System;
using System.Threading;
using System.Windows.Forms;
using MPersist.Core;
using MPersist.Data;
using MPersist.Debug;
using MPersist.Interfaces;
using MPersist.Message.Response;
using MPFinance.Properties;
using MPFinanceCore.Data.Viewed;
using MPFinanceCore.Enums;
using MPFinanceCore.Message.Requests;
using MPFinanceCore.Message.Responses;
using MPFinanceCore.Resources;

namespace MPFinance.Forms
{
    public partial class MPFinanceMain : Form, IOController
    {   
        private static Logger Log = Logger.GetInstance(typeof(MPFinanceMain));

        #region Fields

        private static MPFinanceMain mInstance_;

        private VwOperator mOperator_;
        
        #endregion

        #region Properties

        public static MPFinanceMain Instance
        {
            get
            {
                if (mInstance_ == null)
                {
                    mInstance_ = new MPFinanceMain();                    
                }
                return mInstance_;
            }
        }

        public VwOperator Operator { get { return mOperator_; } set { SetOperator(value); } }
        public VwBankAccount BankAccount { get { return (VwBankAccount)mAccountsList_.SelectedItem; } }
        public VwSummary Summary { set { mSummaryPanel_.Update(value); } }

        #endregion

        #region Constructor

        public MPFinanceMain()
        {
            InitializeComponent();
            MessageProcessor.IOController = this;
            Application.ThreadException += ExceptionHandler;
        }        

        #endregion

        #region Event Listenners

        // Change users, show the login dialog
        private void mLogoutToolStripMenuItem__Click(object sender, EventArgs e)
        {
            mOperator_ = null;
            mAccountsList_.DataSource = null;
            mAccountsList_.Refresh();

            mTransactionsPanel_.Reset();

            if (new LoginDialog().ShowDialog(this) == DialogResult.Cancel)
            {
                Application.Exit();
            }
        }

        // the operators bank accounts have changed; refresh the list
        private void Operator_BankAccountsChanged()
        {
            VwBankAccounts bankAccounts = new VwBankAccounts();
            bankAccounts.Add(new VwBankAccount { Nickname = "All" });
            bankAccounts.AddRange(Operator.BankAccounts);
            mAccountsList_.DataSource = bankAccounts;
            mAccountsList_.Refresh();
        }

        // Exit the application
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        // User picked new account from list; refresh txns
        private void AccountsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            mTransactionsPanel_.GetTxns(new Page(1));
        }

        // Open file chooser and import new OFX file
        private void OFXFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ImportNewTransactionsDialog().ShowDialog(this);
        }

        // Show the edit account dialog
        private void accountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new EditAccountsDialog().ShowDialog(this);
        }

        // Show the about dialog
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutDialog().ShowDialog(this);
        }

        // Show settings dialog
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsDialog settings = new SettingsDialog(Operator);
            if (settings.ShowDialog(this) == DialogResult.OK)
            {
                Operator = settings.Operator;
            }
        }

        // Show Edit Categorie Dialog
        private void catagoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new EditCategoriesDialog().ShowDialog(this);
        }

        #endregion

        #region Override Methods

        protected override void OnLoad(EventArgs e)
        {
            LoginRQ request = new LoginRQ();
            request.Username = "miskopisko";
            request.Password = "secret";
            MessageProcessor.SendRequest(request, LoginSuccess, LoginError);
        }

        #endregion

        #region Private Methods

        private void LoginSuccess(ResponseMessage response)
        {
            SetOperator(((LoginRS)response).Operator);
        }

        private void LoginError(ResponseMessage response)
        {
            UpdateOperatorRQ request = new UpdateOperatorRQ();
            request.Operator = new VwOperator();
            request.Operator.Username = "miskopisko";
            request.Password1 = "secret";
            request.Password2 = "secret";
            request.Operator.FirstName = "Michael";
            request.Operator.LastName = "Piskuric";
            request.Operator.Email = "michael@piskuric.ca";
            request.Operator.Gender = Gender.Male;
            request.Operator.Birthday = new DateTime(1982, 05, 15);
            MessageProcessor.SendRequest(request, UpdateOperatorSuccess, UpdateOperatorError);
        }

        private void UpdateOperatorSuccess(ResponseMessage response)
        {
            SetOperator(((UpdateOperatorRS)response).Operator);
        }

        private void UpdateOperatorError(ResponseMessage response)
        {
            Application.Exit();
        }

        #endregion

        #region Public Methods

        public void SetOperator(VwOperator o)
        {
            mOperator_ = o;

            if (mOperator_ != null && mOperator_.OperatorId.IsSet)
            {
                mOperator_.BankAccountsChanged += Operator_BankAccountsChanged;
                mOperator_.CategoriesChanged += mTransactionsPanel_.Operator_CategoriesChanged;

                mOperator_.Refresh();
                mSettingsToolStripMenuItem_.Enabled = true;
            }
        }

        #endregion

        #region IOController Implementation

        public Int32 RowsPerPage { get { return Settings.Default.RowsPerPage; } }

        public void ExceptionHandler(Object sender, ThreadExceptionEventArgs e)
        {
            Error(e.Exception.InnerException.Message);
        }

        public void Error(String message)
        {
            Invoke(new MethodInvoker(delegate { MessageBox.Show(this, message.ToString(), Strings.strError, MessageBoxButtons.OK, MessageBoxIcon.Error); }));
        }

        public Boolean Confirm(String message)
        {
            Func<DialogResult> showMsg = () => MessageBox.Show(this, message.ToString(), Strings.strConfirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            DialogResult result = (DialogResult)Invoke(showMsg);

            return result.Equals(DialogResult.Yes);
        }

        public void Warning(String message)
        {
            Invoke(new MethodInvoker(delegate { MessageBox.Show(this, message.ToString(), Strings.strWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning); }));
        }

        public void Info(String message)
        {
            Invoke(new MethodInvoker(delegate { MessageBox.Show(this, message.ToString(), Strings.strInfo, MessageBoxButtons.OK, MessageBoxIcon.Information); }));
        }

        public void MessageReceived(String message)
        {
            mMessageStatusLbl_.Text = message;
            mMessageStatusBar_.Increment(-10);
            Application.DoEvents();
        }

        public void MessageSent(String message)
        {
            mMessageStatusLbl_.Text = message;
            mMessageStatusBar_.Increment(10);
            Application.DoEvents();
        }

        public void Debug(MessageTiming timing)
        {
        }

        #endregion
    }
}
