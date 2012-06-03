using System;
using System.IO;
using System.Reflection;
using System.ServiceProcess;
using System.Threading;

namespace System_usage_recorder
{
	public partial class Main : ServiceBase
	{
		public Main()
		{
			InitializeComponent();
		}

		protected override void OnStart(string[] args)
		{
			// Record by every 10min.
			new Timer(
				new TimerCallback(Record),
				null,
				TimeSpan.FromMinutes(0),
				TimeSpan.FromMinutes(10)
			);
		}

		protected override void OnStop()
		{
		}

		private void Record(object state)
		{
			try
			{
				try
				{
					string app_path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
					string log_path = Path.Combine(app_path, "system_usage.txt");

					StreamWriter sw = new StreamWriter(log_path, true);
					sw.WriteLine(DateTime.Now.ToString("u"));
					sw.Close();
				}
				catch (Exception ex)
				{
					string app_path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
					string log_path = Path.Combine(app_path, "error.txt");
					StreamWriter sw = new StreamWriter(log_path, true);
					sw.WriteLine(ex.Message + '\n' + ex.StackTrace);
					sw.Close();
				}
			}
			catch { };
		}
	}
}
