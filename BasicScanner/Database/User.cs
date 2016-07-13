using System;
using SQLite;

namespace BasicScanner
{
	public class User
	{
		public User()
		{
		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public string username { get; set; }

		public string password { get; set; }
	}
}

