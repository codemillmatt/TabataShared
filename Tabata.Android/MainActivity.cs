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

				var workoutInfoArrayList = new List<int>();

				TextView workoutTime = FindViewById<TextView>(Resource.Id.workTime);
				TextView restTime = FindViewById<TextView>(Resource.Id.restTime);
				TextView numOfSets = FindViewById<TextView>(Resource.Id.numberOfSets);

				workoutInfoArrayList.Add(int.Parse(workoutTime.Text));
				workoutInfoArrayList.Add(int.Parse(restTime.Text));
				workoutInfoArrayList.Add(int.Parse(numOfSets.Text));

				intent.PutExtra("tabata_info", workoutInfoArrayList.ToArray());

				StartActivity(intent);
			};

			// Get our button from the layout resource,
			// and attach an event to it
			//Button button = FindViewById<Button> (Resource.Id.myButton);
			
//			button.Click += delegate {
//				button.Text = string.Format ("{0} clicks!", count++);
//			};
		}
	}
}


