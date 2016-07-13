using System;
using SQLite;
using Xamarin.Forms;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using Acr.UserDialogs;

namespace BasicScanner
{
	public class ScannerDatabase
	{
		SQLiteConnection database;

		public ScannerDatabase()
		{
			database = DependencyService.Get<ISQLite>().GetConnection();
			database.CreateTable<User>();
			database.CreateTable<ScanResult>();
		}

		public IEnumerable<ScanResult> GetResults(User user) {
			return (from i in database.Table<ScanResult>() select i).Where(p => p.UserID == user.ID).ToList();
		}

		public User GetUser(string userParam, string passParam) {
			return (database.Table<User>().Where(u => (u.username == userParam) && (u.password == passParam))).FirstOrDefault();
		}

		public void InsertUser(User user) {
			database.Insert(user);
		}

		public User GetUserByName(int userID) {
			return (database.Table<User>().Where(u => u.ID == userID).FirstOrDefault());
		}

		public void InsertScanResult(ScanResult newScan) {
			database.Insert(newScan);
		}
	}
}

