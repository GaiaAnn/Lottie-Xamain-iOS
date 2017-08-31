using Foundation;
using System;
using UIKit;
using Facebook.LoginKit;
using System.Collections.Generic;
using Facebook.CoreKit;
using CoreGraphics;
using System.Drawing;

namespace Lottie_Test
{
    public partial class LoginViewController : UIViewController
    {
        public LoginViewController (IntPtr handle) : base (handle)
        {
        }
		string imgurl = "https://cdn.dribbble.com/users/729829/screenshots/3017703/galshir-dog-vs-cat-dribbble.gif";
		List<string> readPermissions = new List<string> { "public_profile" };
        AccessToken tokenStatus = AccessToken.CurrentAccessToken;
        Profile currentProfile = Profile.CurrentProfile;
		ProfilePictureView pictureView;
		UILabel nameLabel;
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
            SearchBackgroundView.BackgroundColor = UIColor.Clear;
			// Perform any additional setup after loading the view, typically from a nib.
			LoginGifWebView.LoadRequest(new NSUrlRequest(new NSUrl(imgurl)));

			// Perform any additional setup after loading the view, typically from a nib.
			// If was send true to Profile.EnableUpdatesOnAccessTokenChange method
			// this notification will be called after the user is logged in and
			// after the AccessToken is gotten
			Profile.Notifications.ObserveDidChange((sender, e) => {

				if (e.NewProfile == null)
					return;
                if(e.NewProfile.Name == "賴柔安")     
                    ProfileName.Text = "Hi! " + e.NewProfile.Name +"大美女";
				nameLabel.Text = e.NewProfile.Name;
			});
			var facebookLoginButtonText = new NSAttributedString("以FB登入並繼續");

			// Set the Read and Publish permissions you want to get
			//LoginBtn = new LoginButton()
			//{
			//	LoginBehavior = LoginBehavior.SystemAccount,//LoginBehavior.Native,
			//	ReadPermissions = readPermissions.ToArray(),

			//};// FBloginButton;

			LoginBtn.SetAttributedTitle(facebookLoginButtonText, UIControlState.Normal);
			LoginBtn.LoginBehavior = LoginBehavior.Native;
                
            if (tokenStatus != null)
            {
                LoginBtn.SetAttributedTitle(new NSAttributedString("登出"), UIControlState.Normal);
                ProfileName.Text = "Hi! " +  currentProfile.Name +" 大美女";
            }

			// Handle actions once the user is logged in
			LoginBtn.Completed += (sender, e) => {
				if (e.Error != null)
				{
					// Handle if there was an error
				}

				if (e.Result.IsCancelled)
				{
					// Handle if the user cancelled the login request
				}
                tokenStatus = AccessToken.CurrentAccessToken;
                if (tokenStatus != null)
                {
                    LoginBtn.SetAttributedTitle(new NSAttributedString("登出"), UIControlState.Normal);
                }
				// Handle your successful login
			};

			// Handle actions once the user is logged out
			LoginBtn.LoggedOut += (sender, e) => {
				// Handle your logout
                 tokenStatus = AccessToken.CurrentAccessToken;
                if (tokenStatus == null)
                {
                    LoginBtn.SetAttributedTitle(new NSAttributedString("以FB進行登入"), UIControlState.Normal);
                }

			};

			// The user image profile is set automatically once is logged in
			pictureView = new ProfilePictureView(new CGRect(50, 50, 220, 220));

			// Create the label that will hold user's facebook name
			nameLabel = new UILabel(new RectangleF(20, 319, 280, 21))
			{
				TextAlignment = UITextAlignment.Center,
				BackgroundColor = UIColor.Clear
			};
			// Add views to main view
			//View.AddSubview(FBloginButton);
			//View.AddSubview(pictureView);
			//View.AddSubview(nameLabel);

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}
