using Foundation;
using System;
using UIKit;
using Facebook.LoginKit;
using System.Collections.Generic;
using Facebook.CoreKit;
using CoreGraphics;
using System.Drawing;
using Lottie_Test.Component;
using Airbnb.Lottie;
using System.Threading.Tasks;

namespace Lottie_Test
{
    public partial class LoginViewController : UIViewController
    {
        public LoginViewController (IntPtr handle) : base (handle)
        {
        }

        AccessToken token = AccessToken.CurrentAccessToken;
        Profile currentProfile = Profile.CurrentProfile;
		ProfilePictureView pictureView;
		UILabel nameLabel;
		LoadingOverlay loadingView = new LoadingOverlay(UIScreen.MainScreen.Bounds);

		public override void ViewDidLoad()
		{

			base.ViewDidLoad();
			//Show Gif from webview
			LoginGifWebView.LoadRequest(new NSUrlRequest(new NSUrl(Common.Variables.ImgUrl)));
			UIImageView welcomeView = new UIImageView();
			welcomeView.Frame = LoginGifWebView.Frame;
			welcomeView.Image = Common.Common.FromUrl(Common.Variables.ImgUrl);
			welcomeView.ContentMode = UIViewContentMode.ScaleAspectFit;
			LoginGifWebView.AddSubview(welcomeView);
			View.AddSubview(loadingView);
            UITask();


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


		}

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
		}
        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
			loadingView.Hide();

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

        public bool GetLoginStatus(AccessToken token){
            if (token != null)
                return true;
            else
                return false;
        }

        public void FBLoginButtonSetting()
        {
			UIApplication.SharedApplication.BeginInvokeOnMainThread(() =>
			{

				#region loginButton Setting
				var facebookLoginButtonText = new NSAttributedString("以FB登入並繼續");

				LoginBtn.SetAttributedTitle(facebookLoginButtonText, UIControlState.Normal);
				LoginBtn.LoginBehavior = LoginBehavior.Native;
				LoginBtn.ReadPermissions = Common.Variables.FBPermissions.ToArray();
				if (token != null)
				{
					LoginBtn.SetAttributedTitle(new NSAttributedString("登出"), UIControlState.Normal);
					ProfileName.Text = "Hi! " + currentProfile.Name + " 大美女";
				}

				#endregion

				// The user image profile is set automatically once is logged in
				pictureView = new ProfilePictureView(new CGRect(50, 50, 220, 220));

				// Create the label that will hold user's facebook name
				nameLabel = new UILabel(new RectangleF(20, 319, 280, 21))
				{
					TextAlignment = UITextAlignment.Center,
					BackgroundColor = UIColor.Clear
				};
				loadingView.Hide();

			});
      

			// Handle actions once the user is logged in
			LoginBtn.Completed += (sender, e) =>
			{
				var SplitVC = this.Storyboard.InstantiateViewController("SplitViewController");
				var listView = SplitVC.View;
				if (e.Error != null)
				{
					// Handle if there was an error
				}

				if (e.Result.IsCancelled)
				{
					// Handle if the user cancelled the login request
				}
                View.AddSubview(loadingView);
				// Handle your successful login
				token = AccessToken.CurrentAccessToken;
				if (token != null)
				{
					LoginBtn.SetAttributedTitle(new NSAttributedString("登出"), UIControlState.Normal);
					SplitVC.ModalTransitionStyle = UIModalTransitionStyle.FlipHorizontal;
					this.PresentViewController(SplitVC, true, null);
				}
			};

			// Handle actions once the user is logged out
			LoginBtn.LoggedOut += (sender, e) =>
			{
				// Handle your logout
				token = AccessToken.CurrentAccessToken;
				if (token == null)
				{
					LoginBtn.SetAttributedTitle(new NSAttributedString("以FB進行登入"), UIControlState.Normal);
				}

			};


		}

        public System.Threading.Tasks.Task UITask()
        {
			var SplitVC = this.Storyboard.InstantiateViewController("SplitViewController");
            var view = SplitVC.View;

			var UiTask = System.Threading.Tasks.Task.Factory.StartNew(() =>
			{
				UIApplication.SharedApplication.BeginInvokeOnMainThread(() =>
				{

					//Set picture background
					SearchBackgroundView.BackgroundColor = UIColor.Clear;
					////Show Gif from webview
					//LoginGifWebView.LoadRequest(new NSUrlRequest(new NSUrl(Common.Variables.ImgUrl)));
				});
			});
			
            UiTask.ContinueWith((antecendent) =>
			{
				bool IsLogin = GetLoginStatus(token);

				if (!IsLogin)
				{
					FBLoginButtonSetting();
				}
				else
				{

					UIApplication.SharedApplication.BeginInvokeOnMainThread(() =>
					{
					SplitVC.ModalTransitionStyle = UIModalTransitionStyle.FlipHorizontal;
					this.PresentViewController(SplitVC, true, null);
					Console.WriteLine("Interactive Notification Setting finish");
					});
				}

			}, TaskContinuationOptions.AttachedToParent);
            return UiTask;
        }
		

	}
}
