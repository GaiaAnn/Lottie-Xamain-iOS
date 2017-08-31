using System;
using System.Threading.Tasks;
using UIKit;

namespace Lottie_Test
{
	public class Dialog
	{

		public Dialog()
		{
		}
		public static Task<int> ShowAlert(string title, string message, params string[] buttons)
		{
			var tcs = new TaskCompletionSource<int>();
			var alert = new UIAlertView
			{
				Title = title,
				Message = message
			};
			foreach (var button in buttons)
				alert.AddButton(button);
			alert.Clicked += (s, e) => tcs.TrySetResult((int)e.ButtonIndex);

			alert.Show();
			return tcs.Task;
		}


	}
}
