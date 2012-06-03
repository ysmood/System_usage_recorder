using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;


namespace System_usage_recorder
{
	[RunInstaller(true)]
	public partial class ProjectInstaller : System.Configuration.Install.Installer
	{
		public ProjectInstaller()
		{
			InitializeComponent();
		}
	}
}
