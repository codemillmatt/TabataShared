using System;
using System.IO;
using System.Collections.Generic;

namespace Tabata.Shared
{
	public class Tabata
	{
		public int RestInterval {
			get;
			set;
		}

		public int WorkInterval {
			get;
			set;
		}

		public int NumberOfSets {
			get;
			set;
		}
	
		public DateTime TabataDate {
			get;
			set;
		}

		public Tabata ()
		{
		}

		public void SaveTabata()
		{
			this.TabataDate = DateTime.Now;

			string fileName = string.Empty;

			#if __IOS__
				// Open the documents folder and write to the file
			var docPath = MonoTouch.Foundation.NSFileManager.DefaultManager.GetUrls(
				MonoTouch.Foundation.NSSearchPathDirectory.DocumentDirectory,
				MonoTouch.Foundation.NSSearchPathDomain.User)[0];

			fileName = Path.Combine(docPath.Path, "data.csv");

			#elif __ANDROID__
			fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments, "data.csv");
			#endif 

			if (File.Exists(fileName)) {
				File.AppendAllText(fileName, string.Format ("{0},{1},{2},{3},{4}", TabataDate.ToShortDateString (), 
					this.NumberOfSets, this.WorkInterval, this.RestInterval, Environment.NewLine));
			}
			else {
				File.WriteAllText (fileName, string.Format ("{0},{1},{2},{3},{4}", TabataDate.ToShortDateString (), 
					this.NumberOfSets, this.WorkInterval, this.RestInterval, Environment.NewLine));
			}
		}
	}

	public class AllTabatas : List<Tabata>
	{
		public void PopulateTabatas()
		{
			string fileName = string.Empty;

			#if __IOS__
			// Open the documents folder and write to the file
			var docPath = MonoTouch.Foundation.NSFileManager.DefaultManager.GetUrls(
				MonoTouch.Foundation.NSSearchPathDirectory.DocumentDirectory,
				MonoTouch.Foundation.NSSearchPathDomain.User)[0];

			fileName = Path.Combine(docPath.Path, "data.csv");

			#elif __ANDROID__
			fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments, "data.csv");
			#endif 

			if (File.Exists (fileName)) {
				var allLines = File.ReadAllLines (fileName);

				foreach (var line in allLines) {
					var individParts = line.Split(new Char[] { ',' });

					Tabata newTabata = new Tabata ();
					newTabata.TabataDate = DateTime.Parse (individParts [0]);
					newTabata.NumberOfSets = int.Parse (individParts [1]);
					newTabata.WorkInterval = int.Parse (individParts [2]);
					newTabata.RestInterval = int.Parse (individParts [3]);

					this.Add (newTabata);
				}
			} 
		}
	}
}

