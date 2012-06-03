using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.IO;

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
			StreamWriter sw = new StreamWriter(@"D:\system_usage.txt", true);
			sw.WriteLine("Start: " + DateTime.Now.ToString());
			sw.Close();
		}

		protected override void OnStop()
		{
			StreamWriter sw = new StreamWriter(@"D:\system_usage.txt", true);
			sw.WriteLine("Close: " + DateTime.Now.ToString());
			sw.Close();
		}
	}
}
