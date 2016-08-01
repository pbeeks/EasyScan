using System;
using SQLite;
namespace BasicScanner
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}

