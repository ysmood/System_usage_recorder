using System;
using System.IO;
using System.Reflection;
using System.ServiceProcess;

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
			Record(null, null);

			// Record by every 10min.
			timer = new System.Timers.Timer();
			timer.Interval = TimeSpan.FromMinutes(10).TotalMilliseconds;
			timer.Elapsed += new System.Timers.ElapsedEventHandler(Record);
			timer.Start();
		}

		protected override void OnStop()
		{
			timer.Stop();
		}

		private System.Timers.Timer timer;

		private void Record(object sender, System.Timers.ElapsedEventArgs e)
		{
			try
			{
				string app_path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
				try
				{
					string log_path = Path.Combine(app_path, "system_usage.txt");

					StreamWriter sw = new StreamWriter(log_path, true);
					sw.WriteLine(DateTime.Now.ToString("u"));
					sw.Close();
				}
				catch (Exception ex)
				{
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
