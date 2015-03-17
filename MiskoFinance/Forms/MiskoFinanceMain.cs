using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using MiskoFinanceCore.Data.Viewed;
using MiskoFinanceCore.Enums;
using MiskoFinanceCore.Message.Requests;
using MiskoFinanceCore.Message.Responses;
using MiskoFinanceCore.Resources;
using MiskoPersist.Core;
using MiskoPersist.Data;
using MiskoPersist.Interfaces;
using MiskoPersist.Message.Request;
using MiskoPersist.Message.Response;
using MiskoFinance.Panels;
using MiskoFinance.Properties;

namespace MiskoFinance.Forms
{
    public partial class MiskoFinanceMain : Form, IOController
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
        			MessageProcessor.IOController = mInstance_;
            		Application.ThreadException += mInstance_.ExceptionHandler;
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

        #endregion

        #region Constructor

        public MiskoFinanceMain()
        {
            InitializeComponent();
            
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
            MessageProcessor.SendRequest(request, LoginSuccess, LoginError);
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
        	MiskoFinanceMain.Instance.Error("Cannot log in");
        	
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
        
        #region IOController Methods
        
        public Int32 RowsPerPage 
        { 
        	get 
        	{ 
        		return 10; 
        	} 
        }
        
        public void Status(String message)
        {
        	mMessageStatusLbl_.Text = message;
        	Application.DoEvents();
        }
        
        public void ExceptionHandler(Object sender, ThreadExceptionEventArgs e)
        {
            Exception ex = e.Exception;
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            Error(ex.Message);
        }

        public void Debug(Object obj)
        {
            if (obj is AbstractData)
            {
                String xml = AbstractData.Serialize((AbstractData)obj);

                Trace.WriteLine(xml);

                AbstractData deSerialized = AbstractData.Deserialize(xml, obj.GetType());

                String xml2 = AbstractData.Serialize(deSerialized);

                if (!xml.Equals(xml2))
                {
                    System.IO.File.WriteAllText(@"D:\TEMP\OriginalXML.txt", xml);
                    System.IO.File.WriteAllText(@"D:\TEMP\DeserializedXML.txt", xml2);

                    Process pr = new Process();
                    pr.StartInfo.FileName = @"C:\Program Files (x86)\Beyond Compare 3\BCompare.exe";
                    pr.StartInfo.Arguments = '\u0022' + @"D:\TEMP\OriginalXML.txt" + '\u0022' + " " + '\u0022' + @"D:\TEMP\DeserializedXML.txt" + '\u0022';
                    pr.Start();

                    return;
                }

                return;
            }
        }       

        public void MessageReceived()
        {
            mMessageStatusBar_.Increment(-10);            
            Application.DoEvents();
        }

        public void MessageSent()
        {
            mMessageStatusBar_.Increment(10);
            Application.DoEvents();
        }

        public void Error(String message)
        {
            Invoke(new MethodInvoker(delegate { MessageBox.Show(this, message.ToString(), Strings.strError, MessageBoxButtons.OK, MessageBoxIcon.Error); }));
        }

        public void Warning(String message)
        {
            Invoke(new MethodInvoker(delegate { MessageBox.Show(this, message.ToString(), Strings.strWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning); }));
        }

        public void Info(String message)
        {
            Invoke(new MethodInvoker(delegate { MessageBox.Show(this, message.ToString(), Strings.strInfo, MessageBoxButtons.OK, MessageBoxIcon.Information); }));
        }

        public bool Confirm(String message)
        {
            DialogResult result = DialogResult.None;
            Invoke(new MethodInvoker(delegate { result = MessageBox.Show(this, message.ToString(), Strings.strConfirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question); }));
            return result.Equals(DialogResult.Yes);
        }

        #endregion
    }
}
