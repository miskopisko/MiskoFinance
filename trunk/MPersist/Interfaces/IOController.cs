using System;
using System.Threading;

namespace MPersist.Interfaces
{
    public interface IOController
    {
        Int32 RowsPerPage { get; }

        void Debug(Object obj);
        
        void Status(String message);

        void MessageReceived();

        void MessageSent();

        void ExceptionHandler(Object sender, ThreadExceptionEventArgs e);

        void Error(String message);

        void Warning(String message);

        void Info(String message);

        Boolean Confirm(String message);
    }
}
