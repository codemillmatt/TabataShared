using System;
using System.IO;

namespace Tabata.Shared
{
	public partial class TabataWorkout
	{
		public string GetFileName()
		{
			return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),"data.csv");
		}
	}

	public partial class AllTabatas
	{
		public string GetFileName()
		{
			return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),"data.csv");
		}
	}
}

