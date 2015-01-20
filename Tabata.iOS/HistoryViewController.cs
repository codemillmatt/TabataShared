using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System;
using System.CodeDom.Compiler;

namespace Tabata.iOS
{
	partial class historyViewController : UITableViewController
	{
		Tabata.Shared.AllTabatas _allTabatas;

		public historyViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			_allTabatas = new Tabata.Shared.AllTabatas ();

			_allTabatas.PopulateTabatas ();

			this.TableView.Source = new TabataSource (_allTabatas);
		}
	}

	public class TabataSource : UITableViewSource
	{
		string _cellIdentifer = "cell";
		Tabata.Shared.AllTabatas _allTabatas;

		public TabataSource (Tabata.Shared.AllTabatas tabatas)
		{
			_allTabatas = tabatas;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return _allTabatas.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell (_cellIdentifer);

			if (cell == null) {
				cell = new UITableViewCell (UITableViewCellStyle.Subtitle, _cellIdentifer);
			}

			var currentTabata = _allTabatas [indexPath.Row] as Tabata.Shared.Tabata;

			cell.TextLabel.Text = string.Format ("{0} - {1} sets",
				currentTabata.TabataDate.ToShortDateString (), currentTabata.NumberOfSets);

			cell.DetailTextLabel.Text = string.Format ("{0} sec work, {1} sec rest", currentTabata.WorkInterval,
				currentTabata.RestInterval);

			return cell;
		}
	}
}
