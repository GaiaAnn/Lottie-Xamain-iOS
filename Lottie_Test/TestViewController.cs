using Foundation;
using System;
using UIKit;
using Lottie_Test.Component;

namespace Lottie_Test
{
    public partial class TestViewController : UIViewController
    {
        public TestViewController (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
			var loadingView = new LoadingOverlay(UIScreen.MainScreen.Bounds);
			View.AddSubview(loadingView);
        }
    }
}