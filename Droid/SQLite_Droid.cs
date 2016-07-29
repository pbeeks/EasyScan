using System;
using System.IO;
using BasicScanner.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Droid))]

namespace BasicScanner.Droid
{
	public class SQLite_Droid : ISQLite
	{
		public SQLite_Droid() { }
		public SQLite.SQLiteConnection GetConnection()
		{
			var sqliteFilename = "BasicScannerSQLite.db3";
			var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
			var path = Path.Combine(documentsPath, sqliteFilename);
			// Create the connection
			var conn = new SQLite.SQLiteConnection(path);
			// Return the database connection
			return conn;
		}
	}
}