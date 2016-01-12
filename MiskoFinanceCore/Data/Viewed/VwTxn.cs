using System;
using MiskoFinanceCore.Data.Stored;
using MiskoFinanceCore.Enums;
using MiskoPersist.Attributes;
using MiskoPersist.Core;
using MiskoPersist.Data;
using MiskoPersist.MoneyType;

namespace MiskoFinanceCore.Data.Viewed
{
	public class VwTxn : AbstractViewedData
	{
		private static Logger Log = Logger.GetInstance(typeof(VwTxn));

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

		public Money Debit 
		{ 
			get
			{
				return DrCr.Equals(DrCr.Debit) ? Amount : Money.ZERO;
			}
		}
		
		public Money Credit 
		{ 
			get
			{
				return DrCr.Equals(DrCr.Credit) ? Amount : Money.ZERO;
			}
		}

		#endregion

		#region Constructors

		public VwTxn()
		{
		}

		public VwTxn(Session session, Persistence persistence) : base (session, persistence)
		{
		}

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
