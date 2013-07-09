using MPersist.Core;
using MPersist.Core.Message.Response;
using MPFinance.Core.Message.Requests;
using MPFinance.Core.Message.Responses;
using MPFinance.Core.OFX;
using MPFinance.Forms.Panels;
using MPFinance.Resources;
using System.Drawing;
using System.Windows.Forms;

namespace MPFinance.Forms
{
    public partial class ImportNewTransactionsDialog : Form
    {
        private static Logger Log = Logger.GetInstance(typeof(ImportNewTransactionsDialog));

        #region Variable Declarations

        private ChooseAccountPanel mChooseAccountPanel_;
        private ChooseTransactionsPanel mChooseTransactionsPanel_;
        private OfxDocument mDocument_;

        #endregion

        #region Properties

        public ChooseAccountPanel ChooseAccountPanel { get { return mChooseAccountPanel_; } }
        public ChooseTransactionsPanel ChooseTransactionsPanel { get { return mChooseTransactionsPanel_; } }
        public OfxDocument OFXDocument { get { return mDocument_; } }

        #endregion

        #region Constructor

        public ImportNewTransactionsDialog(OfxDocument document)
        {
            mDocument_ = document;           

            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;

            InitializeComponent();
        }        

        #endregion

        #region Override Methods

        protected override void OnLoad(System.EventArgs e)
        {
            mChooseAccountPanel_ = new ChooseAccountPanel(this);
            mChooseTransactionsPanel_ = new ChooseTransactionsPanel();

            mChooseAccountPanel_.OnCompletedWork += mChooseAccountPanel__OnCompletedWork;

            tableLayoutPanel.Controls.Add(mChooseAccountPanel_, 0, 0);
            tableLayoutPanel.Controls.Add(mChooseTransactionsPanel_, 0, 0);

            backBtn.Visible = false;
            nextBtn.Visible = true;
            importBtn.Visible = false;

            mChooseAccountPanel_.Visible = true;
            mChooseTransactionsPanel_.Visible = false;

            Text = Strings.strChooseAnAccount;

            RepositionWindow();
        }

        #endregion

        #region Public Methods

        

        #endregion

        #region Private Methods

        private void CheckDuplicateTxnsSuccess(AbstractResponse Response)
        {
            Text = Strings.strChooseTxnsToAdd;

            mChooseAccountPanel_.Visible = false;
            mChooseTransactionsPanel_.Visible = true;

            backBtn.Visible = true;
            backBtn.Enabled = true;
            nextBtn.Visible = false;
            nextBtn.Enabled = false;
            importBtn.Visible = true;
            importBtn.Enabled = true;

            RepositionWindow();

            mChooseTransactionsPanel_.importedTransactionsGridView.DataSource = ((CheckDuplicateTxnsRS)Response).Txns;
        }

        private void ImportTxnsSuccess(AbstractResponse Response)
        {
            Dispose();
        }

        private void RepositionWindow()
        {
            if (Owner != null && StartPosition == FormStartPosition.Manual)
            {
                int offset = Owner.OwnedForms.Length * 38;  // approx. 10mm
                Point p = new Point(Owner.Left + Owner.Width / 2 - Width / 2 + offset, Owner.Top + Owner.Height / 2 - Height / 2 + offset);
                Location = p;
            }
        }

        #endregion

        #region Event Listenners

        private void mChooseAccountPanel__OnCompletedWork()
        {
            Text = Strings.strCheckingForDuplicateTxns;

            nextBtn.Enabled = false;

            CheckDuplicateTxnsRQ request = new CheckDuplicateTxnsRQ();
            request.Account = mChooseAccountPanel_.Account;
            request.OfxDucument = mDocument_;
            MessageProcessor.SendRequest(request, CheckDuplicateTxnsSuccess);            
        }

        private void nextBtn_Click(object sender, System.EventArgs e)
        {
            mChooseAccountPanel_.GetAccount();
        }

        private void importBtn_Click(object sender, System.EventArgs e)
        {
            ImportTxnsRQ request = new ImportTxnsRQ();
            request.Account = ChooseAccountPanel.Account;
            request.VwTxns = mChooseTransactionsPanel_.importedTransactionsGridView.GetSelected();
            MessageProcessor.SendRequest(request, ImportTxnsSuccess);
        }

        private void backBtn_Click(object sender, System.EventArgs e)
        {
            Text = Strings.strChooseAnAccount;

            mChooseAccountPanel_.Visible = true;
            mChooseTransactionsPanel_.Visible = false;

            backBtn.Visible = false;
            backBtn.Enabled = false;
            nextBtn.Visible = true;
            nextBtn.Enabled = true;
            importBtn.Visible = false;
            importBtn.Enabled = false;

            RepositionWindow();
        }

        #endregion
    }
}
