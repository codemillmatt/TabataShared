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

using Tabata.Shared;

namespace Tabata.Android
{
	public class TabataAdapter : global::Android.Widget.BaseAdapter<Tabata.Shared.Tabata>
	{
		AllTabatas items;
		Activity context;

		public TabataAdapter (Activity context, AllTabatas items) : base() 
		{
			this.context = context;
			this.items = items;
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override Tabata.Shared.Tabata this[int position] {  
			get { return items[position]; }
		}

		public override int Count {
			get { return items.Count; }
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView; // re-use an existing view, if one is available

			if (view == null) // otherwise create a new one
				view = context.LayoutInflater.Inflate(global::Android.Resource.Layout.SimpleListItem2, null);

			var currentTabata = items [position];

			view.FindViewById<TextView> (global::Android.Resource.Id.Text1).Text = currentTabata.TabataDate.ToShortDateString ();
			view.FindViewById<TextView> (global::Android.Resource.Id.Text2).Text = 
				string.Format ("{0} sets, {1} seconds work, {2} seconds rest", currentTabata.NumberOfSets, currentTabata.WorkInterval,
				currentTabata.RestInterval);

			return view;
		}
	}
}

