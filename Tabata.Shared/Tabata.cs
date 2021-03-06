﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Timers;

namespace Tabata.Shared
{
	public class Tabata
	{
		Timer _workTimer;
		Timer _restTimer;

		int _currentWorkSecond;
		int _currentRestSecond;
		int _currentSet;

		#region Properties 

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
			
		#endregion

		public Tabata ()
		{
			
		}

		public Tabata (int workInterval, int restInterval, int numberOfSets)
		{
			this.WorkInterval = workInterval;
			this.RestInterval = restInterval;
			this.NumberOfSets = numberOfSets;

			_currentSet = 1;
		}

		public void StartTabata(Action<string> workUpdate, Action<string> restUpdate, Action<bool, int> switchState, Action finishedUpdate)
		{
			_workTimer = new Timer (1000);
			_restTimer = new Timer (1000);

			_currentWorkSecond = this.WorkInterval;

			_workTimer.Elapsed += (object sender, ElapsedEventArgs e) => {
				_currentWorkSecond -= 1;

				// Update the display
				workUpdate(_currentWorkSecond.ToString());

				if (_currentWorkSecond == 0)
				{
					_workTimer.Stop();
					_currentRestSecond = this.RestInterval;

					switchState(false, _currentSet);

					_restTimer.Start();
				}					
			};

			_restTimer.Elapsed += (object sender, ElapsedEventArgs e) => {
				_currentRestSecond -= 1;

				restUpdate(_currentRestSecond.ToString());

				if (_currentRestSecond == 0) {
					_restTimer.Stop();
					_currentSet += 1;

					if (_currentSet > this.NumberOfSets)
					{
						SaveTabata();

						finishedUpdate();
					}
					else {
						_restTimer.Stop();
						_currentWorkSecond = this.WorkInterval;

						switchState(true, _currentSet);

						_workTimer.Start();
					}
				}
			};

			_workTimer.Start ();
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
			fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),"data.csv");
			//fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments, "data.csv"));
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
			fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "data.csv");
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

