using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using MiskoFinanceCore.Data.Viewed;
using MiskoFinanceCore.Message.Requests;
using MiskoFinanceCore.Message.Responses;
using MiskoFinanceCore.Resources;
using MiskoPersist.Core;
using MiskoPersist.Enums;
using MiskoPersist.Interfaces;
using MiskoPersist.Message.Response;
using MiskoPersist.Tools;
using MiskoFinance.Panels;
using MiskoFinance.Properties;

namespace MiskoFinance.Forms
{
    public partial class MiskoFinanceMain : Form, IOController
    {
        private static Logger Log = Logger.GetInstance(typeof(MiskoFinanceMain));

        #region Fields
        
        private static MiskoFinanceMain mInstance_;  
        
        private VwOperator mOperator_ = new VwOperator();

        #endregion

        #region Properties
        
        public static MiskoFinanceMain Instance
        {
        	get
        	{
        		if(mInstance_ == null)
        		{
        			mInstance_ = new MiskoFinanceMain();
        			ServerConnection.IOController = mInstance_;
        		}
                return mInstance_;
        	}
        }
        
        public SummaryPanel SummaryPanel
        {
        	get
        	{
        		return mSummaryPanel_;
        	}
        }
        
        public SearchPanel SearchPanel
        {
        	get
        	{
        		return mSearchPanel_;
        	}
        }
        
        public TransactionsPanel TransactionsPanel
        {
        	get
        	{
        		return mTransactionsPanel_;
        	}
        }
        
        public VwOperator Operator 
        { 
        	get
        	{
        		return mOperator_;
        	}
        	set
        	{
        		mOperator_ = value ?? new VwOperator();
        		SearchPanel.Accounts = Operator.BankAccounts.getAllAccounts();
        		SearchPanel.Categories = Operator.Categories.getAllCategories();
        		mLogoutToolStripMenuItem_.Enabled = Operator.IsSet;
        		mSettingsToolStripMenuItem_.Enabled = Operator.IsSet;
        		mAccountsToolStripMenuItem_.Enabled = Operator.IsSet;
        		mCatagoriesToolStripMenuItem_.Enabled = Operator.IsSet;
        		mImportToolStripMenuItem_.Enabled = Operator.IsSet;
        		
        		MiskoFinanceMain.Instance.TransactionsPanel.Search();
        	}
        }

        #endregion

        #region Constructor

        public MiskoFinanceMain()
        {
            InitializeComponent();
            
            Size size = Screen.FromControl(this).Bounds.Size;
            if(size.Height <= 1024 || size.Width <= 1280)
            {
            	WindowState = FormWindowState.Maximized;
            }
        }

        #endregion

        #region Event Listenners

        // Change users, show the login dialog
        private void mLogoutToolStripMenuItem__Click(object sender, EventArgs e)
        {
        	Operator = null;
            SummaryPanel.Summary = null;
            TransactionsPanel.Clear();

            new LoginDialog().ShowDialog(this);
        }

        // Exit the application
        private void mExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        // Open file chooser and import new OFX file
        private void mOFXFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ImportTransactionsDialog().ShowDialog(this);
        }

        // Show the edit account dialog
        private void mAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new EditAccountsDialog().ShowDialog(this);
        }

        // Show the about dialog
        private void mAboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutDialog().ShowDialog(this);
        }

        // Show settings dialog
        private void mSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsDialog settings = new SettingsDialog(Operator);
            
            if (settings.ShowDialog(this) == DialogResult.OK)
            {
                Operator = settings.Operator;
            }
        }

        // Show Edit Categorie Dialog
        private void mCatagoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new EditCategoriesDialog().ShowDialog(this);
        }
		
        #endregion

        #region Override Methods
        
		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			
			#if (DEBUG)
				LoginRQ request = new LoginRQ();
            	request.Username = "miskopisko";
            	request.Password = Utils.GenerateHash("secret");
            	ServerConnection.SendRequest(request, LoginSuccess, LoginError);
			#else
				new LoginDialog().ShowDialog(this);
			#endif
		}
        
		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			base.OnFormClosing(e);
			
			Application.Exit();
		}

        #endregion

        #region Private Methods

        private void LoginSuccess(ResponseMessage response)
        {
        	Operator = ((LoginRS)response).Operator;
        }

        private void LoginError(ResponseMessage response)
        {
        	new LoginDialog().ShowDialog(this);
        }

        private void UpdateOperatorSuccess(ResponseMessage response)
        {
        	Operator = ((UpdateOperatorRS)response).Operator;
        }
        
        #endregion

        #region Public Methods


        #endregion

		#region IOController implementation

		public void Status(MessageStatus status)
		{
			mMessageStatusLbl_.Text = status.ToString();
		}

		public void MessageReceived()
		{			
			mMessageStatusBar_.Increment(-mMessageStatusBar_.Step);
		}

		public void MessageSent()
		{
			mMessageStatusBar_.Increment(mMessageStatusBar_.Step);
		}

		public void Exception(object sender, System.Threading.ThreadExceptionEventArgs e)
		{
			Exception ex = e.Exception;
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            
            #if DEBUG
            	Debug.WriteLine(ex.StackTrace);
			#endif
            
			Error(new ErrorMessage(ex));
		}

		public void Error(ErrorMessage message)
		{
			MessageBox.Show(this, message.Message, ErrorStrings.errError, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public void Warning(ErrorMessage message)
		{
			MessageBox.Show(this, message.Message, WarningStrings.warnWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

		public void Info(ErrorMessage message)
		{
			MessageBox.Show(this, message.Message, WarningStrings.infoInformation, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		public bool Confirm(ErrorMessage message)
		{
			DialogResult result = MessageBox.Show(this, message.Message, ConfirmStrings.conConfirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			return result.Equals(DialogResult.Yes);
		}

		public int RowsPerPage 
		{
			get 
			{
				return Settings.Default.RowsPerPage;
			}
		}

		public DataSource DataSource 
		{
			get 
			{
				return DataSource.Local;
			}
		}

		#endregion
    }
}
