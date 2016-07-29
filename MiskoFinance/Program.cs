using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using log4net;
using Message;
using MiskoPersist.Core;
using MiskoPersist.Data;
using MiskoPersist.Enums;
using MiskoPersist.Serialization;
using log4net.Config;
using MiskoFinance.Forms;
using MiskoFinance.Properties;

namespace MiskoFinance
{
	public class Program
	{
		private static ILog Log = LogManager.GetLogger(typeof(Program));
		
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
			Log.Error(e.Exception.StackTrace);
			
			Exception ex = e.Exception;
			while (ex.InnerException != null)
			{
				ex = ex.InnerException;
			}
			
			MiskoFinanceMain.Instance.Error(new ErrorMessage(ex));
		}
		
		public static void SetServerParameters()
		{
			DatabaseConnections.Connections.Clear();

			// Set server properties
			Server.Location = ServerLocation.GetElement(Settings.Default.ServerLocation);
			Server.SerializationType = SerializationType.GetElement(Settings.Default.SerializationType);
			Server.Host = Settings.Default.Hostname;
			Server.Port = Settings.Default.Port;
			Server.Script = Settings.Default.Script;
			Server.UseSSL = Settings.Default.UseSSL;
			
			// Add a database connection for local server
			if (Server.Location.Equals(ServerLocation.Local))
			{
				DatabaseConnections.AddSqliteConnection(Settings.Default.LocalDatabase);
			}
		}
	}
}
