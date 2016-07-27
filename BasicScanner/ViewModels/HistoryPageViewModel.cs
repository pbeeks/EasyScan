using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;

namespace BasicScanner
{
	public class HistoryPageViewModel : BaseViewModel
	{
		#region Properties
		private ObservableCollection<ScanResult> _scanList;
		public ObservableCollection<ScanResult> ScanList
		{
			get
			{
				return _scanList;
			}
			set
			{
				if (_scanList != value)
				{
					_scanList = value;
					OnPropertyChanged();
				}
			}
		}
		#endregion

		#region Variables
		public INavigation Navigation { get; set; }
		private User _user;
		public Command _deleteHistoryItem;
		#endregion

		#region Methods
		public HistoryPageViewModel(INavigation iNav)
		{
			_user = App.PubUser;
			Navigation = iNav;
		}

		//Mothod to assign the user's ScanResults to the ListView's IEnumerable
		public void GetData()
		{
			 ScanList = new ObservableCollection<ScanResult>(App.Database.GetResults(_user).ToList());
		}

		//Remove ScanResult from the database
		public void RemoveHistoryItem(ScanResult sender)
		{
			App.Database.RemoveScanResult(sender);
			ScanList.Remove(sender);
		}
		#endregion
	}
}


