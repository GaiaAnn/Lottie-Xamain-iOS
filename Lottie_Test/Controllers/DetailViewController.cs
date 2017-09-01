using System;
using UIKit;
using TableCell;

namespace Lottie_Test
{
	public partial class DetailViewController : UIViewController
	{
		public CellContent.Info DetailItem { get; set; }

		protected DetailViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public void SetDetailItem(CellContent.Info newDetailItem)
		{
			if (DetailItem != newDetailItem)
			{
				DetailItem = newDetailItem;

				// Update the view
				ConfigureView();
			}
		}

		void ConfigureView()
		{
			// Update the user interface for the detail item
			if (IsViewLoaded && DetailItem != null)
			{
				if (DetailItem.ImageName != null)
				{
                    detailImageView.Image =Common.Common.FromUrl(DetailItem.ImageName);
				}
				detailDescriptionLabel.Text = DetailItem._id + DetailItem.Variety +
					"-" + DetailItem.Name + "\n 我很乖~帶我回家好嗎~";
			}
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			ConfigureView();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

