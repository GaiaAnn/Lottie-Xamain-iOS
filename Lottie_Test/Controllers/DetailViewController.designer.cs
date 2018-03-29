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
    [Register ("DetailViewController")]
    partial class DetailViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView detailImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lbLocation { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lbName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lbNote { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView sexImg { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (detailImageView != null) {
                detailImageView.Dispose ();
                detailImageView = null;
            }

            if (lbLocation != null) {
                lbLocation.Dispose ();
                lbLocation = null;
            }

            if (lbName != null) {
                lbName.Dispose ();
                lbName = null;
            }

            if (lbNote != null) {
                lbNote.Dispose ();
                lbNote = null;
            }

            if (sexImg != null) {
                sexImg.Dispose ();
                sexImg = null;
            }
        }
    }
}