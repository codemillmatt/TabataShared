using System;
using MonoTouch.Foundation;
using System.IO;
using MonoTouch.AudioToolbox;

namespace Tabata.Shared
{
	public partial class TabataWorkout
	{
		public string GetFileName()
		{
			var docPath = NSFileManager.DefaultManager.GetUrls(
				NSSearchPathDirectory.DocumentDirectory,
				NSSearchPathDomain.User)[0];

			return Path.Combine(docPath.Path, "data.csv");
		}	

		partial void BuzzPhone()
		{
			SystemSound.Vibrate.PlayAlertSound();
		}
	}
		
	public partial class AllTabatas
	{
		public string GetFileName()
		{
			var docPath = NSFileManager.DefaultManager.GetUrls(
				NSSearchPathDirectory.DocumentDirectory,
				NSSearchPathDomain.User)[0];

			return Path.Combine(docPath.Path, "data.csv");
		}
	}
}

