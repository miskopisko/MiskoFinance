using MPersist.Core;
using MPFinance.Core.OFX;
using System;
using System.IO;
using System.Windows.Forms;
using MPFinance.Core.Data.Stored;
using System.Reflection;
using MPersist.Core.Enums;
using MPFinance.Core.Data.Viewed;

namespace MPFinance.Forms
{
    public partial class MPFinanceMain : Form
    {
        private readonly Session session;
        private readonly User user;

        public MPFinanceMain(Session s, User u)
        {
            session = s;
            user = u;

            InitializeComponent();            

            AccountHeader.Text = user.LastName + ", " + user.FirstName;

            Accounts accounts = new Accounts();
            accounts.fetchByUser(session, user);

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
            if(!e.Node.Name.Equals("Accounts", StringComparison.OrdinalIgnoreCase))
            {
                Account account = new Account();
                account.fetchById(session, Convert.ToInt64(e.Node.Name));

                transactionsGridView.SetDataSource(VwTransactions.fetchAllByAccount(session, account));
            }
        }

        private void ImportTxns_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog().Equals(DialogResult.OK))
            {
                OfxDocument document = new OfxDocument(new FileStream(openFileDialog.FileName, FileMode.Open));

                Account account = Account.GetInstanceByComposite(session, user, document.AccountType, document.BankID, document.AccountID);

                if (!account.IsSet)
                {
                    account.AccountNumber = document.AccountID;
                    account.AccountType = document.AccountType;
                    account.BankNumber = document.BankID;
                    account.User = user;
                    account.IsSet = true;
                    account.Save(session);              

                    session.Error(GetType(), MethodInfo.GetCurrentMethod(), ErrorLevel.Warning, "New account added");
                }

                foreach (Transaction txn in document.Transactions)
                {
                    txn.Account = account;
                }

                document.Transactions.Save(session);

                transactionsGridView.DataSource = VwTransactions.fetchAllByAccount(session, account);

                int i = 1;
            }            
        }

        private void vwTransactionsBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
