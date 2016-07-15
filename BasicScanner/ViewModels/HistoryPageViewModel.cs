using System.Collections.Generic;
using Xamarin.Forms;

namespace BasicScanner
{
	public class HistoryPageViewModel
	{
		#region Variables
		public IEnumerable<ScanResult> ScanList { get; set; }
		public INavigation Navigation { get; set; }
		private User _user;
		#endregion

		#region Methods
		public HistoryPageViewModel(INavigation iNav)
		{
			_user = App.pubUser;
			Navigation = iNav;
		}

		//Mothod to assign the user's ScanResults to the ListView's IEnumerable
		public void GetData()
		{
			ScanList = App.Database.GetResults(_user);
		}
		#endregion
	}
}


