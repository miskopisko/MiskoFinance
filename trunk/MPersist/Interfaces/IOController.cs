using System;
using System.Threading;

namespace MPersist.Interfaces
{
    public interface IOController
    {
        Int32 RowsPerPage { get; }

        void MessageReceived(String message);

        void MessageSent(String message);

        void ExceptionHandler(Object sender, ThreadExceptionEventArgs e);

        void Error(String message);

        void Warning(String message);

        void Info(String message);

        Boolean Confirm(String message);
    }
}
