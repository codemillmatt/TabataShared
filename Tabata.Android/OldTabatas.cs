
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
	[Activity (Label = "Previous Tabatas")]			
	public class OldTabatas : ListActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			var allTabatas = new Tabata.Shared.AllTabatas ();
			allTabatas.PopulateTabatas ();

//			ListAdapter = new ArrayAdapter<Tabata.Shared.Tabata> (this, global::Android.Resource.Layout.SimpleListItem1,
//				allTabatas.ToArray ());

			ListAdapter = new TabataAdapter (this, allTabatas);
				
		}
	}
}

