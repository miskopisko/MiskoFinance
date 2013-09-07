using System;
using System.Threading;
using MPersist.Message.Request;
using MPersist.Message.Response;

namespace MPersist.Interfaces
{
    public interface IOController
    {       
        Int32 RowsPerPage { get; }

        void MessageReceived(ResponseMessage response, String message);

        void MessageSent(RequestMessage request, String message);

        void ExceptionHandler(Object sender, ThreadExceptionEventArgs e);

        void Error(String message);

        void Warning(String message);

        void Info(String message);

        Boolean Confirm(String message);
    }
}
