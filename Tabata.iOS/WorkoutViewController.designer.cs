// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System;
using System.CodeDom.Compiler;

namespace Tabata.iOS
{
	[Register ("WorkoutViewController")]
	partial class WorkoutViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField intervalText { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField restText { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton setOptionsButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField setsText { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton workoutButton { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (intervalText != null) {
				intervalText.Dispose ();
				intervalText = null;
			}
			if (restText != null) {
				restText.Dispose ();
				restText = null;
			}
			if (setOptionsButton != null) {
				setOptionsButton.Dispose ();
				setOptionsButton = null;
			}
			if (setsText != null) {
				setsText.Dispose ();
				setsText = null;
			}
			if (workoutButton != null) {
				workoutButton.Dispose ();
				workoutButton = null;
			}
		}
	}
}
