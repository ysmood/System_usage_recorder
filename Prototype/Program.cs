using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Text;

namespace Prototype
{
	class Program
	{
		static void Main(string[] args)
		{
			Record(null, null);
		}

		private static void Record(object sender, System.Timers.ElapsedEventArgs e)
		{
			try
			{
				string app_path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
				try
				{
					string log_path = Path.Combine(app_path, "system_usage.txt");

					if (!File.Exists(log_path))
						File.Create(log_path).Close();

					StreamReader sr = new StreamReader(log_path);
					string log = sr.ReadToEnd();
					sr.Close();

					log = log.Remove(log.LastIndexOf("\r\n"));

					string last_line = log.Substring(log.LastIndexOf("\r\n"));

					log = log.Remove(log.LastIndexOf("\r\n"));

					log += last_line + "+\r\n";

					StreamWriter sw = new StreamWriter(log_path);
					sw.Write(log);
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
