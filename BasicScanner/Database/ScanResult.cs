using System;
using SQLite;
namespace BasicScanner
{
	public class ScanResult
	{
		public ScanResult()
		{
		}

		public string Date { get; set; }

		public string Time { get; set; }

		public int UserID { get; set; }

		public string Format { get; set; }

		public string Content { get; set; }

	}
}

