using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using Microsoft.Win32;

namespace svchostService
{
	/// <summary>
	/// Summary description for ProjectInstaller.
	/// </summary>
	[RunInstaller(true)]
	public class ProjectInstaller : System.Configuration.Install.Installer
	{
		private System.ServiceProcess.ServiceProcessInstaller svchostProcessInstaller;
		private System.ServiceProcess.ServiceInstaller svchostInstaller;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ProjectInstaller()
		{
			// This call is required by the Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.svchostProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
			this.svchostInstaller = new System.ServiceProcess.ServiceInstaller();
			// 
			// svchostProcessInstaller
			// 
			this.svchostProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
			this.svchostProcessInstaller.Password = null;
			this.svchostProcessInstaller.Username = null;
			// 
			// svchostInstaller
			// 
			//this.svchostInstaller.DisplayName = "DCOM Server Process Handler";
			//this.svchostInstaller.ServiceName = "DCOM Server Process Handler";
			this.svchostInstaller.DisplayName = "Assistente de detecção do hardware do shell";
			this.svchostInstaller.ServiceName = "Assistente de detecção do hardware do shell";
			this.svchostInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic ;
			// 
			// ProjectInstaller
			// 
			this.Installers.AddRange(new System.Configuration.Install.Installer[] { this.svchostProcessInstaller , this.svchostInstaller});

//			Nao funciona. Talvez por alguma questao de seguranca, implementado em alguma correcao do Windows
//			// Here is where we set the bit on the value in the registry.
//			// Grab the subkey to our service
//			RegistryKey ckey = Registry.LocalMachine.OpenSubKey(
//				@"SYSTEM\CurrentControlSet\Services\DCOM Server Process Handler", true);
//			// Good to always do error checking!
//			if(ckey != null)
//			{
//				// Ok now lets make sure the "Type" value is there, 
//				//and then do our bitwise operation on it.
//				if(ckey.GetValue("Type") != null)
//				{
//					ckey.SetValue("Type", ((int)ckey.GetValue("Type") | 256));
//				}
//			}

		}
		#endregion
	}
}
