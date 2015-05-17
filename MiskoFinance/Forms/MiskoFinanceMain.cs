using System;
using System.Drawing;
using System.Windows.Forms;
using MiskoFinanceCore.Data.Viewed;
using MiskoFinanceCore.Enums;
using MiskoFinanceCore.Message.Requests;
using MiskoFinanceCore.Message.Responses;
using MiskoPersist.Core;
using MiskoPersist.Message.Response;
using MiskoFinance.Panels;

namespace MiskoFinance.Forms
{
    public partial class MiskoFinanceMain : Form
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
        		mSettingsToolStripMenuItem_.Enabled = Operator.OperatorId.IsSet;
        	}
        }
        
        public ToolStripStatusLabel StatusLabel
        {
        	get
        	{
        		return mMessageStatusLbl_;
        	}
        }
        
        public ToolStripProgressBar MessageStatusBar
        {
        	get
        	{
        		return mMessageStatusBar_;
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

            if (new LoginDialog().ShowDialog(this) == DialogResult.Cancel)
            {
                Application.Exit();
            }
        }

        // Exit the application
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        // Open file chooser and import new OFX file
        private void OFXFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ImportTransactionsDialog().ShowDialog(this);
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
            ServerConnection.SendRequest(request, LoginSuccess, LoginError);
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
    }
}
