using System;
using UIKit;
using TableCell;
using CoreGraphics;
using System.Drawing;
using Foundation;
using CoreText;

namespace Lottie_Test
{
	public partial class DetailViewController : UIViewController
	{
		public CellContent.Info DetailItem { get; set; }
		private string[] locations = {"臺北市動物之家", "台北市動物保護處", "台灣防止虐待動物協會",
					"臺北市流浪貓保護協會", "台北市愛兔協會]"};
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
					ImageViewStyleSetting();
					detailImageView.Image =Common.Common.FromUrl(DetailItem.ImageName);
				}
                Title = NSBundle.MainBundle.LocalizedString("No. " + DetailItem._id, DetailItem._id);
				//detailDescriptionLabel.Text = DetailItem._id + DetailItem.Variety +
					//"-" + DetailItem.Name + "\n 我很乖~帶我回家好嗎~";
                lbName.Text = DetailItem.Name == "" ? "我需要一個新名字" : DetailItem.Name ;
                lbNote.Text = DetailItem.Note == "" ? "無特殊備註一定很乖" : DetailItem.Note;
                string ImgPath = DetailItem.Sex == "雄" ? "boy.png" : "girl.png";
                sexImg.Image = UIImage.FromFile(ImgPath);


                var attr = new CTStringAttributes()// CTStringAttributes()
                {
                    UnderlineStyle = CTUnderlineStyle.Double,
                };
                lbLocation.AttributedText = new NSMutableAttributedString(DetailItem.Resettlement, attr);
				string urlLocation = "";
				for (int i = 0; i < locations.Length; i++)
				{
					if (DetailItem.Resettlement.Contains(locations[i]))
					{
						if (i == 0)
						{
							lbLocation.Text = DetailItem.Resettlement.Replace(" ", "\n");
							urlLocation = DetailItem.Resettlement.Split()[0];
						}
						else
						{
							urlLocation = locations[i];
							lbLocation.Text = locations[i];
						}
					}
					else
					{
						lbLocation.Text = DetailItem.Resettlement;
						urlLocation = DetailItem.Resettlement;
					}
					break;
				}

				UITapGestureRecognizer tgrLabel = new UITapGestureRecognizer(() => {
					var uri = new Uri("http://maps.apple.com/?q="+urlLocation);
					var mapUrl = new NSUrl(uri.GetComponents(UriComponents.HttpRequestUrl, UriFormat.UriEscaped));
					//NSUrl mapUrl = NSUrl.FromString("http://maps.apple.com/?q="+urlLocation);
                    UIApplicationOpenUrlOptions option = new UIApplicationOpenUrlOptions()
                    {
                        OpenInPlace = true
                    };
					UIApplication.SharedApplication.OpenUrl(mapUrl, option, null);
                });
				lbLocation.AddGestureRecognizer(tgrLabel);
				lbLocation.UserInteractionEnabled = true;

                //var attributedString = new NSAttributedString("Hello, world",
			   
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
        public void ImageViewStyleSetting()
        {
			detailImageView.Layer.ShadowRadius = 10f;
            detailImageView.Layer.ShadowColor = UIColor.Brown.ColorWithAlpha(0.5f).CGColor;
			detailImageView.Layer.ShadowOpacity = 1f;
			detailImageView.Layer.ShadowOffset = new CGSize(6.0f, 6.0f);
			detailImageView.Layer.CornerRadius = 10.0f;
			detailImageView.Layer.MasksToBounds = false;

            var blur = UIBlurEffect.FromStyle(UIBlurEffectStyle.Light);
            var blurView = new UIVisualEffectView(blur)
            {
                Frame = this.View.Frame,// blurBackground.Frame, //new RectangleF(0, 0, (float)this.View.Frame.Width, 400)
                //Alpha = 0.8f
            };
			//View.Add(blurView);
            UIImageView blurImage = new UIImageView()
            {
                Image = Common.Common.FromUrl(DetailItem.ImageName),
                Frame = this.View.Frame,// blurBackground.Frame,
                Alpha = 0.8f
            };
            //blurBackground.BackgroundColor = new UIColor(250f / 255f, 187f / 255f, 108f / 255f, 85f);
            //View.AddSubviews(blurView);
            detailImageView.Layer.ZPosition = 1;
            //UIApplication.SharedApplication.KeyWindow.BringSubviewToFront(detailImageView);

        }
	}
}

