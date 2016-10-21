using log4net;
using MiskoFinanceCore.Data.Viewed;
using MiskoFinanceCore.Message.Requests;
using MiskoFinanceCore.Message.Responses;
using MiskoPersist.Core;
using MiskoPersist.Message;

namespace MiskoFinanceCore.Message
{
	public class MiskoFinanceLogon : Logon
	{
		private static ILog Log = LogManager.GetLogger(typeof(Logon));

		#region Properties

		public new MiskoFinanceLogonRQ Request { get { return (MiskoFinanceLogonRQ)base.Request; } }
		public new MiskoFinanceLogonRS Response  { get { return (MiskoFinanceLogonRS)base.Response; } }

		#endregion

		public MiskoFinanceLogon(MiskoFinanceLogonRQ request, MiskoFinanceLogonRS response) : base(request, response)
		{
		}

		public override void Execute(Session session)
		{
			base.Execute(session);
			
			Response.Operator = new VwOperator();
			Response.Operator.OperatorId = mOperator_.Id; 
			Response.Operator.Fetch(session, true);
		}
	}
}
