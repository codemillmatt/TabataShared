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

		Timer _workTimer;
		int _currentWorkSecond;

		Timer _restTimer;
		int _currentRestSecond;

		int _currentSet;

		public intervalViewController (IntPtr handle) : base (handle)
		{

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			timeLeftLabel.Text = this.CurrentTabata.WorkInterval.ToString ();
			currentStateLabel.Text = "Exercise!";

			_currentWorkSecond = this.CurrentTabata.WorkInterval;

			// Setup the timers
			_workTimer = new Timer (1000);
			_workTimer.Elapsed += workTimerElapsed;

			_restTimer = new Timer (1000);
			_restTimer.Elapsed += restTimerElapsed;

			_currentSet = 1;
			setsLabel.Text = string.Format ("{0} of {1} sets", _currentSet, this.CurrentTabata.NumberOfSets);

			// Fire off the work timer
			_workTimer.Start ();
		}

		private void workTimerElapsed(object sender, ElapsedEventArgs e)
		{		
			InvokeOnMainThread (() => {
				_currentWorkSecond -= 1;

				timeLeftLabel.Text = _currentWorkSecond.ToString ();

				if (_currentWorkSecond == 0) {
					_workTimer.Stop ();
					currentStateLabel.Text = "Rest";
					_currentRestSecond = this.CurrentTabata.RestInterval;
					timeLeftLabel.Text = _currentRestSecond.ToString ();

					_restTimer.Start ();
				}
			});
		}

		private void restTimerElapsed(object sender, ElapsedEventArgs e)
		{
			InvokeOnMainThread (() => {
				_currentRestSecond -= 1;

				timeLeftLabel.Text = _currentRestSecond.ToString ();

				if (_currentRestSecond == 0) {
					_restTimer.Stop ();

					_currentSet += 1;

					// check to see if we're at our last set
					if (_currentSet > this.CurrentTabata.NumberOfSets) {
						// Save the tabata
						this.CurrentTabata.SaveTabata ();

						this.NavigationController.PopViewControllerAnimated (true);
					} else {
						_restTimer.Stop ();
						currentStateLabel.Text = "Exercise!";
						_currentWorkSecond = this.CurrentTabata.WorkInterval;
						timeLeftLabel.Text = _currentWorkSecond.ToString ();

						setsLabel.Text = string.Format ("{0} of {1} sets", _currentSet, this.CurrentTabata.NumberOfSets);

						_workTimer.Start ();
					}
				}
			});
		}
	}
}
