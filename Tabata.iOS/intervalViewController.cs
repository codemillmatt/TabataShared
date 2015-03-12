using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System;
using System.CodeDom.Compiler;
using System.Timers;

namespace Tabata.iOS
{
	partial class intervalViewController : UIViewController
	{
		public Tabata.Shared.TabataWorkout CurrentTabata {
			get;
			set;
		}
			
		public intervalViewController (IntPtr handle) : base (handle)
		{

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Initialize the UI
			timeLeftLabel.Text = this.CurrentTabata.WorkInterval.ToString ();
			currentStateLabel.Text = "Exercise!";

			setsLabel.Text = string.Format ("1 of {0} sets", this.CurrentTabata.NumberOfSets);

			// Start the Tabata
			CurrentTabata.StartTabata (DisplayWorkTimeRemaining, DisplayRestTimeRemaining, SwitchViews, FinishedTabata);
		}
				
		private void DisplayWorkTimeRemaining(string timeLeft)
		{
			InvokeOnMainThread (() => {
				timeLeftLabel.Text = timeLeft;
			});
		}

		private void DisplayRestTimeRemaining(string timeLeft)
		{
			InvokeOnMainThread (() => {
				timeLeftLabel.Text = timeLeft;
			});
		}

		private void SwitchViews(bool showWork, int numberOfCompletedSets)
		{
			InvokeOnMainThread (() => {
				if (showWork) {
					currentStateLabel.Text = "Exercise!";
					timeLeftLabel.Text = this.CurrentTabata.WorkInterval.ToString ();
					setsLabel.Text = string.Format ("{0} of {1} sets", numberOfCompletedSets, this.CurrentTabata.NumberOfSets);
				} else {
					currentStateLabel.Text = "Rest";
					timeLeftLabel.Text = this.CurrentTabata.RestInterval.ToString ();
				}
			});
		}
			
		private void FinishedTabata()
		{
			InvokeOnMainThread (() => {
				this.NavigationController.PopViewControllerAnimated (true);
			});				
		}
			
	}
}
