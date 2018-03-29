using System;
using UIKit;
using Airbnb.Lottie;
using CoreGraphics;

namespace Lottie_Test
{
	public partial class ViewController : UIViewController
	{
		LOTAnimationView animation = LOTAnimationView.AnimationNamed("xamarin_logo_2");

		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public  override void  ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			animation.Frame = this.View.Bounds;
			animation.ContentMode = UIViewContentMode.ScaleAspectFit;
			this.View.AddSubview(animation);
			animation.PlayWithCompletion((animationFinished) => {
				// Do Something
				//Dialog.ShowAlert("LottieTest", "HBD", "OK");
				var launchVC = new LaunchAnimationController();
				var launchView = launchVC.View;
				var loginVC = Storyboard.InstantiateViewController("LoginViewController") as LoginViewController;
				var loginView = loginVC.View;
				this.PresentViewController(loginVC, false, null);
			});


		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
		public override void ViewWillLayoutSubviews()
		{
			base.ViewWillLayoutSubviews();

			CGRect b = this.View.Bounds;

			//this.animation.Frame = new CGRect(0, 0, b.Size.Width,b.Size.Width);
			//animation.ContentMode = UIViewContentMode.ScaleAspectFit;
		}
	}
}
