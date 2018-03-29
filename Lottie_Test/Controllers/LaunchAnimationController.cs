using System;
using Airbnb.Lottie;
using Foundation;
using UIKit;
using WebKit;
using System.Diagnostics;
using Facebook.LoginKit;
using Facebook.CoreKit;
using System.Collections.Generic;
using System.Drawing;
using CoreGraphics;
using Lottie_Test.Component;

namespace Lottie_Test
{
	public partial class LaunchAnimationController : UIViewController
	{
		public LaunchAnimationController() : base()
		{
		}
		WKWebView WKWebView;

		string imgurl = "https://cdn.dribbble.com/users/729829/screenshots/3017703/galshir-dog-vs-cat-dribbble.gif";
		// To see the full list of permissions, visit the following link:
		// https://developers.facebook.com/docs/facebook-login/permissions/v2.3

		// This permission is set by default, even if you don't add it, but FB recommends to add it anyway
		List<string> readPermissions = new List<string> { "public_profile" };

		LoginButton loginView;
		ProfilePictureView pictureView;
		UILabel nameLabel;

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			

			// Perform any additional setup after loading the view, typically from a nib.
			// If was send true to Profile.EnableUpdatesOnAccessTokenChange method
			// this notification will be called after the user is logged in and
			// after the AccessToken is gotten
			Profile.Notifications.ObserveDidChange((sender, e) => {

				if (e.NewProfile == null)
					return;

				nameLabel.Text = e.NewProfile.Name;
			});

			// Set the Read and Publish permissions you want to get
			loginView = new LoginButton(new CGRect(51, 0, 218, 46))
			{
				LoginBehavior = LoginBehavior.Native,
				ReadPermissions = readPermissions.ToArray()
			};

			// Handle actions once the user is logged in
			loginView.Completed += (sender, e) => {
				if (e.Error != null)
				{
					// Handle if there was an error
				}

				if (e.Result.IsCancelled)
				{
					// Handle if the user cancelled the login request
				}

				// Handle your successful login
			};

			// Handle actions once the user is logged out
			loginView.LoggedOut += (sender, e) => {
				// Handle your logout
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
			View.AddSubview(loginView);
			//View.AddSubview(pictureView);
			//View.AddSubview(nameLabel);


			var userController = new WKUserContentController();

			           var config = new WKWebViewConfiguration
			           {
			           	UserContentController = userController,
			           	//WebsiteDataStore = WKWebsiteDataStore.NonPersistentDataStore
			           };
			           WKWebView = new WKWebView(View.Bounds,config);
			           //View.AddSubview(WKWebView);
					  View.AddSubviews(WKWebView,loginView);

					  WKWebView.LoadRequest(new NSUrlRequest(new NSUrl(imgurl)));
			          WKWebView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
			           //Webview.ScalesPageToFit = true;

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewWillAppear(bool animated)
		{
			//base.ViewWillAppear(animated);
			//LOTAnimationView animation = LOTAnimationView.AnimationNamed("LottieLogo1");
			//this.View.AddSubview(animation);
			//animation.PlayWithCompletion((animationFinished) =>
			//{
			//	// Do Something
			//	//Dialog.ShowAlert("LottieTest", "LottieLogo1", "OK");
			//	//this.DismissViewController(true,null);
			//});
		}
	}
}

