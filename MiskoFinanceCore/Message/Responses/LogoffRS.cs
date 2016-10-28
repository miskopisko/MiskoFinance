using log4net;
using MiskoPersist.Message.Responses;

namespace MiskoFinanceCore.Message.Responses
{
	public class LogoffRS : ResponseMessage
	{
		private static ILog Log = LogManager.GetLogger(typeof(LogoffRS));
	}
}
