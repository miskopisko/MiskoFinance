using System;
using System.Drawing;
using System.Windows.Forms;
using log4net;
using MiskoFinance.Panels;
using MiskoFinanceCore.Data.Viewed;
using MiskoFinanceCore.Message.Requests;
using MiskoFinanceCore.Message.Responses;
using MiskoFinanceCore.Resources;
using MiskoPersist.Core;
using MiskoPersist.Data;
using MiskoPersist.Data.Viewed;
using MiskoPersist.Enums;
using MiskoPersist.Message.Response;

namespace MiskoFinance.Forms
{
	public partial class MiskoFinanceMain : Form
	{
		private static ILog Log = LogManager.GetLogger(typeof(MiskoFinanceMain));

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
				SearchPanel.Accounts = Operator.BankAccounts;
				SearchPanel.Categories = Operator.Categories;
				mLogoutToolStripMenuItem_.Enabled = Operator.IsSet;
				mSettingsToolStripMenuItem_.Enabled = Operator.IsSet;
				mAccountsToolStripMenuItem_.Enabled = Operator.IsSet;
				mCatagoriesToolStripMenuItem_.Enabled = Operator.IsSet;
				mImportToolStripMenuItem_.Enabled = Operator.IsSet;
				
				if(Operator.IsSet)
				{
					MiskoFinanceMain.Instance.TransactionsPanel.Search();	
				}
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
		private void mLogoutToolStripMenuItem__Click(Object sender, EventArgs e)
		{
			Reset();
			new LoginDialog().ShowDialog(this);
		}

		// Exit the application
		private void mExitToolStripMenuItem_Click(Object sender, EventArgs e)
		{
			Dispose();
		}

		// Open file chooser and import new OFX file
		private void mOFXFileToolStripMenuItem_Click(Object sender, EventArgs e)
		{
			new ImportTransactionsDialog().ShowDialog(this);
		}

		// Show the edit account dialog
		private void mAccountsToolStripMenuItem_Click(Object sender, EventArgs e)
		{
			new EditAccountsDialog().ShowDialog(this);
		}

		// Show the about dialog
		private void mAboutToolStripMenuItem_Click(Object sender, EventArgs e)
		{
			new AboutDialog().ShowDialog(this);
		}

		// Show settings dialog
		private void mSettingsToolStripMenuItem_Click(Object sender, EventArgs e)
		{
			SettingsDialog settings = new SettingsDialog(mOperator_);
			
			if(settings.ShowDialog(this) == DialogResult.OK)
			{
				Operator = settings.Operator;
			}
		}

		// Show Edit Categorie Dialog
		private void mCatagoriesToolStripMenuItem_Click(Object sender, EventArgs e)
		{
			new EditCategoriesDialog().ShowDialog(this);
		}
		
		#endregion

		#region Override Methods
		
		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			
			#if(DEBUG)
				LoginRQ request = new LoginRQ();
				request.Username = "miskopisko";
				request.Password = "secret";
				Server.SendRequest(request, LoginSuccess, LoginError);
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
		
		private void Reset()
		{
			Operator = new VwOperator();
			SummaryPanel.Summary = new VwSummary();
			TransactionsPanel.Clear();
			SearchPanel.Reset();
			SearchPanel.Disable();
		}

		public void LoginSuccess(ResponseMessage response)
		{
			LoginRS rs = response as LoginRS;
			if(rs != null)
			{
				Operator = rs.Operator;	
			}
		}

		private void LoginError(ResponseMessage response)
		{
			new LoginDialog().ShowDialog(this);
		}

		private void UpdateOperatorSuccess(ResponseMessage response)
		{
			UpdateOperatorRS rs = response as UpdateOperatorRS;
			if(rs != null)
			{
				Operator = rs.Operator;	
			}			
		}
		
		#endregion

		#region Public Methods


		#endregion

		#region Server events

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

		public void Error(ErrorMessage message)
		{
			MessageBox.Show(this, message.ToString(), ErrorStrings.errError, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public void Warning(ErrorMessage message)
		{
			MessageBox.Show(this, message.ToString(), WarningStrings.warnWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

		public void Info(ErrorMessage message)
		{
			MessageBox.Show(this, message.ToString(), WarningStrings.infoInformation, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		public void Confirm(ErrorMessage message, ConfirmationEventArgs args)
		{
			DialogResult result = MessageBox.Show(this, message.ToString(), ConfirmStrings.conConfirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			args.Confirmed = result.Equals(DialogResult.Yes);
		}
		
		#endregion
	}
}
