using MPersist.Core.Debug;
using System;
using System.Windows.Forms;

namespace MPersist.Core.Interfaces
{
    public interface IOController
    {
        void MessageReceived(String message);

        void MessageSent(String message);

        void Debug(MessageTiming timing);

        DialogResult Error(ErrorMessage message);

        DialogResult Confirm(ErrorMessage message);

        DialogResult Warning(ErrorMessage message);

        DialogResult Info(ErrorMessage message);
    }
}
