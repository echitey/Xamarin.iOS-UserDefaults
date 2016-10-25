using System;
using Foundation;
using UIKit;

namespace UserDefaults
{
	public partial class ViewController : UIViewController
	{
		private string CONF_EMAIL = "usermail";
		private string CONF_TOKEN = "usertoken";

		NSUserDefaults conf;
		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			conf = NSUserDefaults.StandardUserDefaults;

			update();

			btnSave.TouchUpInside += BtnSave_TouchUpInside;
			btnDelete.TouchUpInside += BtnDelete_TouchUpInside;

		}

		void BtnSave_TouchUpInside(object sender, EventArgs e)
		{
			if (txtEmail.Text != null)
				conf.SetString(txtEmail.Text, CONF_EMAIL);
			if (txtToken.Text != null)
				conf.SetString(txtToken.Text, CONF_TOKEN);
			conf.Synchronize();
			alertUser("The data was saved!");
			update();
		}

		void BtnDelete_TouchUpInside(object sender, EventArgs e)
		{
			conf.SetString(null, CONF_EMAIL);
			conf.SetString(null, CONF_TOKEN);
			conf.Synchronize();
			alertUser("The data was deleted!");
			update();
		}

		private void update() { 
			var userMail = conf.StringForKey(CONF_EMAIL);
			var userToken = conf.StringForKey(CONF_TOKEN);

			if (userMail != null)
				txtEmail.Text = userMail;
			if (userToken != null)
				txtToken.Text = userToken;
		}
		private void alertUser(string msg)
		{
			UIAlertView alert = new UIAlertView() { Message = msg };
			alert.AddButton("OK");
			alert.Show();
		}
		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}
