using System;
using System.Threading;
using System.Windows.Forms;
using log4net;
using MiskoFinance.Properties;
using MiskoPersist.Core;
using MiskoPersist.Enums;
using log4net.Config;
using MiskoFinance.Forms;
using MiskoPersist.Data.Viewed;
using MiskoPersist.Serialization;

namespace MiskoFinance
{
    public class Program
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(Program));
		
		[STAThread]
		public static void Main()
		{
			// Set application parameters
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(true);
			Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
			Application.ThreadException += ThreadException;
			
			// Configure the logger
			XmlConfigurator.Configure();
			
			// Set server event handlers
			Server.MessageSent += MiskoFinanceMain.Instance.MessageSent;
			Server.MessageReceived += MiskoFinanceMain.Instance.MessageReceived;
			Server.Status += MiskoFinanceMain.Instance.Status;
			Server.Error += MiskoFinanceMain.Instance.Error;
			Server.Warning += MiskoFinanceMain.Instance.Warning;
			Server.Info += MiskoFinanceMain.Instance.Info;
			Server.Confirm += MiskoFinanceMain.Instance.Confirm;
			
			// Setup server parameters from the settings file
			SetServerParameters();
			
			// Run the application
			Application.Run(MiskoFinanceMain.Instance);
		}
		
		private static void ThreadException(Object sender, ThreadExceptionEventArgs e)
		{
            Log.Error(e.Exception.ToString());			
			MiskoFinanceMain.Instance.Error(new ErrorMessage(e.Exception));
		}
		
		public static void SetServerParameters()
		{
			DatabaseConnections.Connections.Clear();

			// Set server properties
			Server.Location = MiskoEnum.Parse<ServerLocation>(Settings.Default.ServerLocation);
			Server.SerializationType = MiskoEnum.Parse<SerializationType>(Settings.Default.SerializationType);
			Server.Host = Settings.Default.Hostname;
			Server.Port = (short)Settings.Default.Port;
			Server.Script = Settings.Default.Script;
			Server.UseSSL = Settings.Default.UseSSL;
			Server.WriteMessagesToLog = Settings.Default.WriteMessagesToLog;
			
			// Add a database connection for local server
			if (Server.Location.Equals(ServerLocation.Local))
			{
				DatabaseConnections.AddSqliteConnection(Settings.Default.LocalDatabase);
			}
		}
	}
}
