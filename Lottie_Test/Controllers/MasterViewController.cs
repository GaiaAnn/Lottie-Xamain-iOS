using Foundation;
using System;
using UIKit;
using TableCell;
using System.Collections.Generic;
using Lottie_Test.Services;
using Lottie_Test.Common;
using CoreAnimation;
using System.Linq;

namespace Lottie_Test
{
	public partial class MasterViewController : UITableViewController
	{
		DataSource dataSource;
		//public static List<Animal.Info> animals = new List<Animal.Info>();
		public static List<CellContent.Info> animals = new List<CellContent.Info>();


		protected MasterViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public async override void ViewDidLoad()
		{
			base.ViewDidLoad();
            //Initial View
            var DetailVC = this.Storyboard.InstantiateViewController("DetailViewController");
            var detailView = DetailVC.View;
			UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes()
			{
                TextColor = UIColor.Brown,
                TextShadowColor = UIColor.Black
			});
            //Nav Button Color
            this.NavigationController.NavigationBar.TintColor = new UIColor(138f / 255f, 63f / 255f, 67f / 255f, 1);
			//Nav Background Color
            this.NavigationController.NavigationBar.BarTintColor = new UIColor(252f / 255f, 241f / 255f, 189f / 255f, 1);

			Title = NSBundle.MainBundle.LocalizedString("Partner List", "Partner List");
			// Perform any additional setup after loading the view, typically from a nib.
			NavigationItem.LeftBarButtonItem = EditButtonItem;
			var addButton = new UIBarButtonItem(UIBarButtonSystemItem.Add, AddNewItem);
			addButton.AccessibilityLabel = "addButton";
			NavigationItem.RightBarButtonItem = addButton;

			//Prepare Animals Info for tableview source
			animals = await ApiService.LoadAnimalData();
			TableView.RegisterNibForCellReuse(UINib.FromName("CardCell", null), "CardCell");

			TableView.Source = dataSource = new DataSource(this);
		}

		public override void ViewWillAppear(bool animated)
		{
			ClearsSelectionOnViewWillAppear = SplitViewController.Collapsed;
			Variables.ViewWillAppear = true;
			base.ViewWillAppear(animated);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		void AddNewItem(object sender, EventArgs args)
		{
			var num = (animals.Count + 1).ToString();
			CellContent.Info item = new CellContent.Info
			{
				_id = num,
				Name = "小美人魚QQ" + num,
				Variety = "小美人魚" + num
			};
			dataSource.Animal.Insert(0, item);

			using (var indexPath = NSIndexPath.FromRowSection(0, 0))
				TableView.InsertRows(new[] { indexPath }, UITableViewRowAnimation.Automatic);
		}

		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier == "showDetail")
			{
				var controller = (DetailViewController)((UINavigationController)segue.DestinationViewController).TopViewController;
				var indexPath = TableView.IndexPathForSelectedRow;
				var item = dataSource.Animal[indexPath.Row];

				controller.SetDetailItem(item);
				controller.NavigationItem.LeftBarButtonItem = SplitViewController.DisplayModeButtonItem;
				controller.NavigationItem.LeftItemsSupplementBackButton = true;

			}
		}

		class DataSource : UITableViewSource
		{
			static readonly NSString CellIdentifier = new NSString("CardCell");
			readonly MasterViewController controller;
			public DataSource(MasterViewController controller)
			{
				this.controller = controller;
			}

			public IList<CellContent.Info> Animal
			{
				get { return animals; }
			}

			// Customize the number of sections in the table view.
			public override nint NumberOfSections(UITableView tableView)
			{
				return 1;
			}

			public override nint RowsInSection(UITableView tableview, nint section)
			{
				return animals.Count;
			}

			public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
			{
				this.controller.PerformSegue("showDetail", null);
			}

			// Customize the appearance of table view cells.
			public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
			{
                var row = indexPath.Row;
                //Set Row Heigh
				tableView.RowHeight = 130;
				tableView.SeparatorColor = UIColor.FromRGB(235, 235, 241);//.Clear; //235 235 241
				var cell = tableView.DequeueReusableCell(CellIdentifier, indexPath) as CardCell;
                animals[row].Name = animals[row].Name == "" ?"請幫我取個名字":animals[row].Name;
                //置換代表圖片
                cell.SetTypeImage(animals[row].Type);
                //loading 自己的圖片
				cell.UpdateCell(animals, indexPath.Row);
				return cell;
			}

			public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
			{
				// Return false if you do not want the specified item to be editable.
				return true;
			}

			public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
			{
				if (editingStyle == UITableViewCellEditingStyle.Delete)
				{
					// Delete the row from the data source.
					animals.RemoveAt(indexPath.Row);
					//objects.RemoveAt(indexPath.Row);
					controller.TableView.DeleteRows(new[] { indexPath }, UITableViewRowAnimation.Fade);
				}
				else if (editingStyle == UITableViewCellEditingStyle.Insert)
				{
					// Create a new instance of the appropriate class, insert it into the array, and add a new row to the table view.
				}
			}

			public override void WillDisplay(UITableView tableView, UITableViewCell cell, NSIndexPath indexPath)
			{
				#region Set animation when Display Data
				if (!Variables.ViewWillAppear)
				{
					//1. Set the initial state of the cell
					cell.Alpha = 0;
					var transform = CATransform3D.MakeTranslation(-250, 20, 0);
					cell.Layer.Transform = transform;


					//2. UIView animation method to change to the final state of the cell
					UIView.Animate(0.5, () =>
					{
						cell.Alpha = 1;
						cell.Layer.Transform = CATransform3D.Identity;

					});
				}
				if (indexPath.Row == tableView.IndexPathsForVisibleRows[tableView.IndexPathsForVisibleRows.Length - 1].LongRow)
				{
					var lastrow = tableView.IndexPathsForVisibleRows[tableView.IndexPathsForVisibleRows.Length - 1].LongRow;
					Variables.ViewWillAppear = false;
				}
				#endregion

			}


		}
	}
}
