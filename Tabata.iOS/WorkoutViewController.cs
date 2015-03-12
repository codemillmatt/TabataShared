using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System;
using System.CodeDom.Compiler;

namespace Tabata.iOS
{
	partial class WorkoutViewController : UIViewController
	{
		public WorkoutViewController (IntPtr handle) : base (handle)
		{

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			setOptionsButton.TouchUpInside += (object sender, EventArgs e) => {
				if (setsText.IsFirstResponder)
					setsText.ResignFirstResponder();
				else if (intervalText.IsFirstResponder)
					intervalText.ResignFirstResponder();
				else if (restText.IsFirstResponder)
					restText.ResignFirstResponder();
			};
				
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue (segue, sender);

			var intervalVC = segue.DestinationViewController as intervalViewController;

			if (intervalVC != null)
				intervalVC.CurrentTabata = CreateTabata ();
		}

		public Tabata.Shared.TabataWorkout CreateTabata()
		{
			var newTabata = new Tabata.Shared.TabataWorkout (int.Parse (intervalText.Text),
				                int.Parse (restText.Text), int.Parse (setsText.Text));
				
			return newTabata;
		}
	}
}
