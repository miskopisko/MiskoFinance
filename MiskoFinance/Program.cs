using System;
using System.Threading;
using System.Windows.Forms;
using log4net;
using log4net.Config;
using MiskoFinance.Forms;
using MiskoFinance.Properties;
using MiskoPersist.Core;
using MiskoPersist.Data.Viewed;
using MiskoPersist.Enums;
using MiskoPersist.Message.Requests;

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
			Application.ApplicationExit += Application_ApplicationExit;
			
			// Configure the logger
			XmlConfigurator.Configure();
			
			// Setup server parameters from the settings file
			SetServerParameters();
			
			// Set server event handlers
			Server.MessageSent += MiskoFinanceMain.Instance.MessageSent;
			Server.MessageReceived += MiskoFinanceMain.Instance.MessageReceived;
			Server.Status += MiskoFinanceMain.Instance.ServerStatus;
			Server.Error += MiskoFinanceMain.Instance.Error;
			Server.Warning += MiskoFinanceMain.Instance.Warning;
			Server.Info += MiskoFinanceMain.Instance.Info;
			Server.Confirm += MiskoFinanceMain.Instance.Confirm;
			
			// Run the application
			Application.Run(MiskoFinanceMain.Instance);
		}

		private static void Application_ApplicationExit(Object sender, EventArgs e)
		{
			if (MiskoFinanceMain.Instance.Operator.IsSet)
			{
				Server.SendRequest(new LogoffRQ());
			}
		}
		
		private static void ThreadException(Object sender, ThreadExceptionEventArgs e)
		{
            Log.Error(e.Exception.ToString());			
			MiskoFinanceMain.Instance.Error(new ErrorMessage(e.Exception));
		}
		
		public static void SetServerParameters()
		{
			DatabaseConnections.Clear();

			// Set server properties
			Server.Location = MiskoEnum.Parse<ServerLocation>(Settings.Default.ServerLocation);
			Server.SerializationType = MiskoEnum.Parse<SerializationType>(Settings.Default.SerializationType);
			Server.Host = Settings.Default.Hostname;
			Server.Port = Settings.Default.Port;
			Server.Script = Settings.Default.Script;
			Server.UseSSL = Settings.Default.UseSSL;
			Server.WriteMessagesToLog = Settings.Default.WriteMessagesToLog;
			
			// Add a database connection for local server
			if (Server.Location.Equals(ServerLocation.Local))
			{
				DatabaseConnections.AddSqliteConnection(Settings.Default.LocalDatabase);
			}
			
			if (Server.Location.Equals(ServerLocation.Local))
			{
				MiskoFinanceMain.Instance.ConnectedTo = Settings.Default.LocalDatabase;
			}
			else if (Server.Location.Equals(ServerLocation.Online))
			{
				MiskoFinanceMain.Instance.ConnectedTo = Settings.Default.Hostname;
			}
		}
	}
}
