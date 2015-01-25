
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
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView (Resource.Layout.WorkoutLayout);

			var extras = Intent.Extras.GetIntegerArrayList ("tabata_info");


		}
	}
}

