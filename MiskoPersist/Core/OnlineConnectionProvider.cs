using System;
using MiskoPersist.Interfaces;
using MiskoPersist.Message.Request;
using MiskoPersist.Message.Response;

namespace MiskoPersist.Core
{
	public class OnlineConnectionProvider : ConnectionProvider
	{
		public OnlineConnectionProvider()
		{
		}

		#region ConnectionProvider implementation

		public ResponseMessage Send(RequestMessage request)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
