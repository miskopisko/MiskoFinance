using MPersist.Core.Debug;
using System;
using System.Threading;
using System.Windows.Forms;

namespace MPersist.Core.Interfaces
{
    public interface IOController
    {       
        Int32 RowsPerPage { get; }

        void MessageReceived(String message);

        void MessageSent(String message);

        void Debug(MessageTiming timing);

        void ExceptionHandler(Object sender, ThreadExceptionEventArgs e);

        DialogResult Error(ErrorMessage message);

        DialogResult Confirm(ErrorMessage message);

        DialogResult Warning(ErrorMessage message);

        DialogResult Info(ErrorMessage message);
    }
}
