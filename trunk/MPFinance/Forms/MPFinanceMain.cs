using MPersist.Core;
using MPFinance.Core.Data;
using MPFinance.Core.OFX;
using MPFinance.Security;
using System;
using System.IO;
using System.Windows.Forms;

namespace MPFinance.Forms
{
    public partial class MPFinanceMain : Form
    {
        private Session session_;
        private Operator operator_;

        public MPFinanceMain(Session session, Operator o)
        {
            

            InitializeComponent();

            session_ = session;
            operator_ = o;

            AccountHeader.Text = o.Client.LastName + ", " + o.Client.FirstName;

            Accounts accounts = new Accounts();
            accounts.fetchByClient(session_, o.Client);

            foreach (Account a in accounts)
            {
                AccountsView.Nodes[0].Nodes.Add(a.Id.ToString(), a.AccountType.ToString());
            }

            AccountsView.ExpandAll();

        }
        
        private void MPFinanceMain_Load(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void AccountsView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int i = 1;
        }

        private void ImportTxns_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            OfxDocument document = new OfxDocument(session_, operator_.Client, new FileStream(openFileDialog.FileName, FileMode.Open));





            TransactionsView.DataSource = document.Account.GetTransactions(session_);;
        }
    }
}
