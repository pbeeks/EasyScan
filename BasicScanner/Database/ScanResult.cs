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

		public DateTime DT { get; set; }

		public int UserID { get; set; }

		public string Format { get; set; }

		public string Content { get; set; }

	}
}

