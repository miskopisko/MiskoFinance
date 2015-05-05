using System;
using System.Drawing;
using System.Windows.Forms;
using MiskoFinanceCore.Data.Viewed;
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
        
        public ListBox AccountsList
        {
        	get
        	{
        		return mAccountsList_;
        	}
        }
        
        public SummaryPanel SummaryPanel
        {
        	get
        	{
        		return mSummaryPanel_;
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
        	get; 
        	set;
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
            
            mAccountsList_.DataSourceChanged += accountList_DataSourceChanged;
        }

        #endregion

        #region Event Listenners

        // Change users, show the login dialog
        private void mLogoutToolStripMenuItem__Click(object sender, EventArgs e)
        {
            Operator = null;
            mAccountsList_.DataSource = null;
            mTransactionsPanel_.Categories = null;
            mSummaryPanel_.Summary = null;

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

        // User picked new account from list; refresh txns
        private void AccountsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            mTransactionsPanel_.GetTxns();
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
                mAccountsList_.DataSource = Operator.BankAccounts.getAllAccounts();
            }
        }

        // Show Edit Categorie Dialog
        private void catagoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new EditCategoriesDialog().ShowDialog(this);
        }

		private void accountList_DataSourceChanged(object sender, EventArgs e)
		{
			mAccountsList_.Refresh();
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
        	mAccountsList_.DataSource = Operator.BankAccounts.getAllAccounts();
        	mTransactionsPanel_.Categories = Operator.Categories.getAllCategories();
			mSettingsToolStripMenuItem_.Enabled = true;
        }

        private void LoginError(ResponseMessage response)
        {
        	throw new MiskoException("Cannot log in");
        	
        	/*
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
            MessageProcessor.SendRequest(request, UpdateOperatorSuccess);
            */
        }

        private void UpdateOperatorSuccess(ResponseMessage response)
        {
        	Operator = ((UpdateOperatorRS)response).Operator;
        	mAccountsList_.DataSource = Operator.BankAccounts.getAllAccounts();
			mSettingsToolStripMenuItem_.Enabled = true;
        }
        
        #endregion

        #region Public Methods


        #endregion
        
/*        #region IOController Methods
        
     

        public void Debug(Object obj)
        {
        	String serialized = AbstractData.SerializeJson(obj);

            Trace.WriteLine(serialized);

            Object deSerializedObj = AbstractData.DeserializeJson(serialized);

            String deSerialized = AbstractData.SerializeJson(deSerializedObj);

            if (!serialized.Equals(deSerialized))
            {
                System.IO.File.WriteAllText(@"D:\TEMP\OriginalXML.txt", serialized);
                System.IO.File.WriteAllText(@"D:\TEMP\DeserializedXML.txt", deSerialized);

                Process pr = new Process();
                pr.StartInfo.FileName = @"C:\Program Files (x86)\Beyond Compare 3\BCompare.exe";
                pr.StartInfo.Arguments = '\u0022' + @"D:\TEMP\OriginalXML.txt" + '\u0022' + " " + '\u0022' + @"D:\TEMP\DeserializedXML.txt" + '\u0022';
                pr.Start();
            }
        }       


        #endregion*/
    }
}
