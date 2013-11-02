using System;
using System.Diagnostics;
using System.Windows.Forms;
using MPersist.Core;
using MPersist.Data;
using MPersist.Enums;
using MPFinance.Forms;
using MPFinance.Properties;
using MPFinanceCore.Resources;

namespace MPFinance
{
    class Program : IOController
    {
        public Program()
        {            
        }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            IOController.Instance = new Program();
            
            //IOController.Instance.ServerType = ServerType.Online;
            //IOController.Instance.Host = "localhost";
            //IOController.Instance.Port = 33333;
            //IOController.Instance.Script = "/Service.asmx/Process";

            IOController.Instance.ServerConnections.Add(ServerConnection.GetSqliteConnection(@"..\..\..\MPersist_DB.sqlite3"));
            //IOController.Instance.AddConnection(ConnectionSettings.GetOracleConnection("192.168.0.111", 1521, "xe", "MPersist", "MPersist"));
            //IOController.Instance.AddConnection(ConnectionSettings.GetMySqlConnection("piskuric.ca", "miskop_mpfinance", "miskop_mpfinance", "B2FkUh4ct2OZ"));

            Application.Run(MPFinanceMain.Instance);
        }

        #region IOController Methods

        public override void Debug(Object obj)
        {
            if (obj is AbstractData)
            {
                String xml = AbstractData.Serialize((AbstractData)obj);

                Trace.WriteLine(xml);

                AbstractData deSerialized = AbstractData.Deserialize(xml, obj.GetType());

                String xml2 = AbstractData.Serialize(deSerialized);

                if (!xml.Equals(xml2))
                {
                    System.IO.File.WriteAllText(@"D:\TEMP\OriginalXML.txt", xml);
                    System.IO.File.WriteAllText(@"D:\TEMP\DeserializedXML.txt", xml2);

                    Process pr = new Process();
                    pr.StartInfo.FileName = @"C:\Program Files (x86)\Beyond Compare 3\BCompare.exe";
                    pr.StartInfo.Arguments = '\u0022' + @"D:\TEMP\OriginalXML.txt" + '\u0022' + " " + '\u0022' + @"D:\TEMP\DeserializedXML.txt" + '\u0022';
                    pr.Start();

                    return;
                }

                return;
            }
        }

        public override void MessageStatus(String status)
        {
            MPFinanceMain.Instance.mMessageStatusLbl_.Text = status;
            Application.DoEvents();
        }

        public override void MessageReceived()
        {
            MPFinanceMain.Instance.mMessageStatusBar_.Increment(-10);
            Application.DoEvents();
        }

        public override void MessageSent()
        {
            MPFinanceMain.Instance.mMessageStatusBar_.Increment(10);
            Application.DoEvents();
        }

        public override void Error(String message)
        {
            MessageStatus("Error!");
            MessageBox.Show(MPFinanceMain.Instance, message.ToString(), Strings.strError, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public override void Warning(String message)
        {
            MessageStatus("Warning!");
            MessageBox.Show(MPFinanceMain.Instance, message.ToString(), Strings.strWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public override void Info(String message)
        {
            MessageStatus("Info!");
            MessageBox.Show(MPFinanceMain.Instance, message.ToString(), Strings.strInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public override bool Confirm(String message)
        {
            MessageStatus("Confirm?");
            return MessageBox.Show(MPFinanceMain.Instance, message.ToString(), Strings.strConfirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        #endregion
    }
}
