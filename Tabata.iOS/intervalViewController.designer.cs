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
	[Register ("intervalViewController")]
	partial class intervalViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel currentStateLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel setsLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel timeLeftLabel { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (currentStateLabel != null) {
				currentStateLabel.Dispose ();
				currentStateLabel = null;
			}
			if (setsLabel != null) {
				setsLabel.Dispose ();
				setsLabel = null;
			}
			if (timeLeftLabel != null) {
				timeLeftLabel.Dispose ();
				timeLeftLabel = null;
			}
		}
	}
}
