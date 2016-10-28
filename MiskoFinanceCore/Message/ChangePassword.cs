using log4net;
using MiskoFinanceCore.Message.Requests;
using MiskoFinanceCore.Message.Responses;
using MiskoPersist.Core;
using MiskoPersist.Data.Stored;
using MiskoPersist.Enums;
using MiskoPersist.Message;

namespace MiskoFinanceCore.Message
{
	public class ChangePassword : MessageWrapper
	{
		private static ILog Log = LogManager.GetLogger(typeof(ChangePassword));

		#region Properties

		public new ChangePasswordRQ Request { get { return (ChangePasswordRQ)base.Request; } }
		public new ChangePasswordRS Response { get { return (ChangePasswordRS)base.Response; } }

		#endregion

		public ChangePassword(ChangePasswordRQ request, ChangePasswordRS response) : base(request, response)
		{
		}

		public override void Execute(Session session)
		{
			Operator o = new Operator();
			o.FetchByUsername(session, Request.Username);
			
			if (!o.ValidatePassword(Request.OldPassword))
		    {
				session.Error(ErrorLevel.Error, "Invalid password.");
		    }
			
			o.SetPassword(session, Request.NewPassword, Request.ConfirmPassword);
			o.Save(session);
		}
	}
}
