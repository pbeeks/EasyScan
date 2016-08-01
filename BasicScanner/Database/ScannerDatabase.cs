using System;
using SQLite;
using Xamarin.Forms;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using Acr.UserDialogs;
using System.ComponentModel;

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

		public IEnumerable<ScanResult> GetResults(User user)
		{
			return (from i in database.Table<ScanResult>() select i).Where(p => p.UserID == user.ID);
		}

		public User CheckCredentials(string userParam, string passParam)
		{
			return (database.Table<User>().Where(u => (u.username == userParam) && (u.password == passParam))).FirstOrDefault();
		}

		public void InsertUser(User user)
		{
			database.Insert(user);
		}

		public User GetUserByName(int userID)
		{
			return (database.Table<User>().Where(u => u.ID == userID).FirstOrDefault());
		}

		public void InsertScanResult(ScanResult newScan)
		{
			database.Insert(newScan);
		}

		public bool CheckUser(string user)
		{
			var check = database.Table<User>().Where(u => u.username == user).FirstOrDefault();
			if (check != null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool RemoveScanResult(ScanResult result)
		{
			database.Delete<ScanResult>(result.ScanID);
			return true;
		}
	}
}

