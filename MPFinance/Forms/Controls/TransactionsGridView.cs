using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MPersist.Core.Data;
using MPFinance.Core.Data.Viewed;
using MPFinance.Core.Data.Stored;

namespace MPFinance.Forms.Controls
{
    public partial class TransactionsGridView : DataGridView
    {
        private DataGridViewTextBoxColumn Date = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn Description = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn Credit = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn Debit = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn Category = new DataGridViewTextBoxColumn();

        public TransactionsGridView()
        {
            AutoGenerateColumns = false;
            InitializeComponent();            
        }

        public void SetDataSource(VwTransactions data)
        {
            //Rows.Clear();
            DataSource = null;


            if (Columns.Count.Equals(0))
            {
                Date.ValueType = typeof(DateTime);
                Date.DataPropertyName = "DatePosted";
                Date.HeaderText = "Txn. Date";
                Date.Name = "Date";
                Date.DefaultCellStyle.Format = "MM/dd/yyyy";
                Date.Width = 90;

                Description.DataPropertyName = "Memo";
                Description.HeaderText = "Description";
                Description.Name = "Description";
                Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
                
                Credit.DataPropertyName = "Credit";
                Credit.HeaderText = "Credit";
                Credit.Name = "Credit";
                Credit.Width = 85;

                Debit.DataPropertyName = "Debit";
                Debit.HeaderText = "Debit";
                Debit.Name = "Debit";
                Debit.Width = 95;

                Category.DataPropertyName = "Category";
                Category.HeaderText = "Category";
                Category.Name = "Category";
                Category.Width = 90;

                Columns.AddRange(new DataGridViewColumn[] {
                                Date,
                                Description,
                                Credit,
                                Debit,
                                Category});
            }

            DataSource = data;

            //foreach (VwTransaction item in data)
            //{
                //Rows.Add(item.Date, item.Description, item.Credit, item.Debit, item.Category);
            //}
        }

        private void TransactionsGridView_Click(object sender, EventArgs e)
        {
            int i = 1;
        }
    }
}
