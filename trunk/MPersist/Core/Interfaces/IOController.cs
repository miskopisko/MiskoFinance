using System;
using System.Windows.Forms;

namespace MPersist.Core.Interfaces
{
    public interface IOController
    {
        Int32 RowsPerPage { get; }

        ConnectionSettings ConnectionSettings { get; }

        void MessageReceived(String message);

        void MessageSent(String message);

        DialogResult Error(ErrorMessage message);

        DialogResult Confirm(ErrorMessage message);

        DialogResult Warning(ErrorMessage message);

        DialogResult Info(ErrorMessage message);
    }
}
