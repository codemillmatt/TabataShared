using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace Tabata.Android
{
	[Activity (Label = "Tabata.Android", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Grab the workout button
			Button workout = FindViewById<Button> (Resource.Id.workout);

			workout.Click += (object sender, EventArgs e) => {
				var intent = new Intent(this, typeof(WorkoutActivity));
							
				TextView workoutTime = FindViewById<TextView>(Resource.Id.workTime);
				TextView restTime = FindViewById<TextView>(Resource.Id.restTime);
				TextView numOfSets = FindViewById<TextView>(Resource.Id.numberOfSets);

				intent.PutExtra("workout_time", int.Parse(workoutTime.Text));
				intent.PutExtra("rest_time", int.Parse(restTime.Text));
				intent.PutExtra("number_sets", int.Parse(numOfSets.Text));

				StartActivity(intent);
			};

			Button history = FindViewById<Button> (Resource.Id.viewHistory);

			history.Click += (object sender, EventArgs e) => {
				var intent = new Intent(this, typeof(OldTabatas));

				StartActivity(intent);
			};
		}
	}
}


