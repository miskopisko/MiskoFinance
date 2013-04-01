using System;
using System.Windows.Forms;
using MPersist.Security;
using MPersist.Core;
using MPersist.Resources.Enums;

namespace MPFinance
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            
            OperatorProfile profile = OperatorProfile.GetInstance(new Session(SessionType.MySql, null), 1);
        }
    }
}
