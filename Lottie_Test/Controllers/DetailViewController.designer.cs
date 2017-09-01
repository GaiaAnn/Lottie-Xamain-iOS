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
        UIKit.UILabel detailDescriptionLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView detailImageView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (detailDescriptionLabel != null) {
                detailDescriptionLabel.Dispose ();
                detailDescriptionLabel = null;
            }

            if (detailImageView != null) {
                detailImageView.Dispose ();
                detailImageView = null;
            }
        }
    }
}