using System;
using System.Collections.Generic;
using Realms;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;
using Acr.UserDialogs;
using ZXing.Mobile;

namespace BasicScanner
{
	public class HistoryPageViewModel
	{
		public IEnumerable<ScanResult> ScanList { get; set; }
		public INavigation Navigation { get; set; }
		private User _user;

		// Populates the HistoryPage listview
		public HistoryPageViewModel(INavigation iNav)
		{
			_user = App.pubUser;
			Navigation = iNav;


		}

		public void GetData()
		{
			ScanList = App.Database.GetResults(_user);
		}
	}
}


