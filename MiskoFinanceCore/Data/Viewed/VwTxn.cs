using System;
using log4net;
using MiskoFinanceCore.Data.Stored;
using MiskoFinanceCore.Enums;
using MiskoPersist.Attributes;
using MiskoPersist.Core;
using MiskoPersist.Data.Viewed;
using MiskoPersist.MoneyType;

namespace MiskoFinanceCore.Data.Viewed
{
	public class VwTxn : ViewedData
	{
		private static ILog Log = LogManager.GetLogger(typeof(VwTxn));

		#region Fields

		

		#endregion

		#region Viewed Properties

		[Viewed]
		public PrimaryKey TxnId { get; set; }
		[Viewed]
		public PrimaryKey OperatorId { get; set; }
		[Viewed]
		public PrimaryKey AccountId { get; set; }
		[Viewed]
		public Money Amount { get; set; }
		[Viewed]
		public String Account { get; set; }
		[Viewed]
		public DateTime DatePosted { get ; set; }
		[Viewed]
		public String Description { get; set; }
		[Viewed]
		public DrCr DrCr { get; set; }
		[Viewed]
		public PrimaryKey Category { get; set; }        
		[Viewed]
		public Boolean Transfer { get; set; }
		[Viewed]
		public Boolean OneTime { get; set; }
		[Viewed]
		public String HashCode { get; set; }

		#endregion

		#region Other Properties

		public Money? Debit 
		{ 
			get
			{
				return DrCr.Equals(DrCr.Debit) ? (Money?)Amount : null;
			}
		}
		
		public Money? Credit 
		{ 
			get
			{
				return DrCr.Equals(DrCr.Credit) ? (Money?)Amount : null;
			}
		}
		
		public CategoryType CategoryType
		{
			get
			{
				if(DrCr.Equals(DrCr.Credit) && !Transfer && !OneTime)
				{
					return CategoryType.Income;
				}
				if(DrCr.Equals(DrCr.Debit) && !Transfer && !OneTime)
				{
					return CategoryType.Expense;
				}
				if(Transfer && !OneTime)
				{
					return CategoryType.Transfer;
				}
				if (!Transfer && OneTime)
				{
					return CategoryType.OneTime;
				}
				return CategoryType.NULL;
			}
		}

		#endregion

		#region Constructors

		

		#endregion

		#region Override Methods

		

		#endregion

		#region Private Methods



		#endregion

		#region Public Methods

		public void Update(Session session)
		{
			Txn txn = new Txn();
			txn.FetchById(session, TxnId);

			txn.OneTime = OneTime;
			txn.Transfer = Transfer;
			txn.Category = Category;
			txn.Save(session);
		}

		#endregion
	}
}
