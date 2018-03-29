// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Lottie_Test
{
    [Register ("LoginViewController")]
    partial class LoginViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        Facebook.LoginKit.LoginButton LoginBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIWebView LoginGifWebView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ProfileName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView SearchBackgroundView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (LoginBtn != null) {
                LoginBtn.Dispose ();
                LoginBtn = null;
            }

            if (LoginGifWebView != null) {
                LoginGifWebView.Dispose ();
                LoginGifWebView = null;
            }

            if (ProfileName != null) {
                ProfileName.Dispose ();
                ProfileName = null;
            }

            if (SearchBackgroundView != null) {
                SearchBackgroundView.Dispose ();
                SearchBackgroundView = null;
            }
        }
    }
}