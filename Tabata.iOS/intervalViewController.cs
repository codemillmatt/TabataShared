using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System;
using System.CodeDom.Compiler;
using System.Timers;

namespace Tabata.iOS
{
	partial class intervalViewController : UIViewController
	{
		public Tabata.Shared.Tabata CurrentTabata {
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
				// Save the tabats
				this.CurrentTabata.SaveTabata ();

				this.NavigationController.PopViewControllerAnimated (true);
			});				
		}

//		private void workTimerElapsed(object sender, ElapsedEventArgs e)
//		{		
//			InvokeOnMainThread (() => {
//				_currentWorkSecond -= 1;
//
//				timeLeftLabel.Text = _currentWorkSecond.ToString ();
//
//				if (_currentWorkSecond == 0) {
//					_workTimer.Stop ();
//					currentStateLabel.Text = "Rest";
//					_currentRestSecond = this.CurrentTabata.RestInterval;
//					timeLeftLabel.Text = _currentRestSecond.ToString ();
//
//					this.CurrentTabata.StartTabata(this.DisplaySomething);
//
//					//_restTimer.Start ();
//				}
//			});
//		}

//		private void restTimerElapsed(object sender, ElapsedEventArgs e)
//		{
//			InvokeOnMainThread (() => {
//				_currentRestSecond -= 1;
//
//				timeLeftLabel.Text = _currentRestSecond.ToString ();
//
//				if (_currentRestSecond == 0) {
//					_restTimer.Stop ();
//
//					_currentSet += 1;
//
//					// check to see if we're at our last set
//					if (_currentSet > this.CurrentTabata.NumberOfSets) {
//						// Save the tabata
//						this.CurrentTabata.SaveTabata ();
//
//						this.NavigationController.PopViewControllerAnimated (true);
//					} else {
//						_restTimer.Stop ();
//						currentStateLabel.Text = "Exercise!";
//						_currentWorkSecond = this.CurrentTabata.WorkInterval;
//						timeLeftLabel.Text = _currentWorkSecond.ToString ();
//
//						setsLabel.Text = string.Format ("{0} of {1} sets", _currentSet, this.CurrentTabata.NumberOfSets);
//
//						_workTimer.Start ();
//					}
//				}
//			});
//		}
	}
}
