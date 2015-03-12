
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;


namespace Tabata.Android
{
	[Activity (Label = "WorkoutActivity")]			
	public class WorkoutActivity : Activity
	{
		Tabata.Shared.TabataWorkout _currentTabata;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView (Resource.Layout.WorkoutLayout);

			// Pull the workout info out of the intent
			var workoutTime = Intent.GetIntExtra ("workout_time", 10);
			var restTime = Intent.GetIntExtra ("rest_time", 2);
			var numOfSets = Intent.GetIntExtra ("number_sets", 2);

			var setInfo = FindViewById<TextView> (Resource.Id.setInfo);
			var timeLeftLabel = FindViewById<TextView> (Resource.Id.timeLeft);

			// Create the tabata object
			_currentTabata = new Tabata.Shared.TabataWorkout (workoutTime, restTime, numOfSets);

			setInfo.Text = string.Format ("1 of {0} sets", _currentTabata.NumberOfSets);
			timeLeftLabel.Text = _currentTabata.WorkInterval.ToString ();

			// Start the tabata
			_currentTabata.StartTabata (UpdateTimeRemaining, UpdateRestTimeRemaining, SwitchWorkoutStates, FinishedTabata);
		}

		private void UpdateTimeRemaining(string time)
		{
			RunOnUiThread (() => {
				var timeLeftLabel = FindViewById<TextView> (Resource.Id.timeLeft);

				timeLeftLabel.Text = time;
			});
		}

		private void UpdateRestTimeRemaining(string time)
		{
			RunOnUiThread (() => {
				var timeLeftLabel = FindViewById<TextView> (Resource.Id.timeLeft);

				timeLeftLabel.Text = time;
			});
		}

		private void FinishedTabata()
		{
			RunOnUiThread (() => {
				var intent = new Intent (this, typeof(MainActivity));

				StartActivity (intent);
			});
		}

		private void SwitchWorkoutStates(bool isWorkoutState, int numberOfCompletedSets)
		{
			RunOnUiThread (() => {
				var workoutStateView = FindViewById<TextView> (Resource.Id.workoutState);
				var timeLeft = FindViewById<TextView> (Resource.Id.timeLeft);
				var setInfo = FindViewById<TextView> (Resource.Id.setInfo);

				if (isWorkoutState) {
					workoutStateView.Text = "Exercise!";
					timeLeft.Text = _currentTabata.WorkInterval.ToString ();
					setInfo.Text = string.Format ("{0} of {1} sets", numberOfCompletedSets, _currentTabata.NumberOfSets);
				} else {
					workoutStateView.Text = "Rest";
					timeLeft.Text = _currentTabata.RestInterval.ToString ();
				}
			});
		}
	}
}

