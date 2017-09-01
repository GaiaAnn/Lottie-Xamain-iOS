using System;
using Foundation;
using UIKit;

namespace Lottie_Test.Common
{
	public class Common
	{
		public Common()
		{
		}
		public static UIImage FromUrl(string uri)
		{
			using (var url = new NSUrl(uri))
			using (var data = NSData.FromUrl(url))
				return UIImage.LoadFromData(data);
		}
	}
}

