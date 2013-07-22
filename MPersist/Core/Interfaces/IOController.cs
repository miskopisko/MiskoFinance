using System;
using System.Threading;
using System.Windows.Forms;
using MPersist.Core.Debug;

namespace MPersist.Core.Interfaces
{
    public interface IOController
    {       
        Int32 RowsPerPage { get; }

        void MessageReceived(String message);

        void MessageSent(String message);

        void Debug(MessageTiming timing);

        void ExceptionHandler(Object sender, ThreadExceptionEventArgs e);

        DialogResult Error(String message);

        DialogResult Confirm(String message);

        DialogResult Warning(String message);

        DialogResult Info(String message);
    }
}
