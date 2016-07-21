using System;
using SQLite;
namespace BasicScanner
{
	public class ScanResult
	{
		public ScanResult()
		{
		}

		[PrimaryKey, AutoIncrement]
		public int ScanID { get; set; }

		public string Date { get; set; }

		public string Time { get; set; }

		public int UserID { get; set; }

		public string Format { get; set; }

		public string Content { get; set; }

	}
}

