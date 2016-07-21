using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;

namespace BasicScanner
{
	public class MasterPageViewModel : BaseViewModel
	{
		#region Variables
		private INavigation _nav;
		private Command _scanCommand;
		private User _currUser;
		#endregion

		#region Properties
		private string _count;
		public string Count
		{
			get
			{
				return _count;
			}
			set
			{
				if (_count != value)
				{
					_count = value;
					OnPropertyChanged();
				}
			}
		}

		private string _lastScan;
		public string LastScan
		{
			get
			{
				return _lastScan;
			}
			set
			{
				if (_lastScan != value)
				{
					_lastScan = value;
					OnPropertyChanged();
				}
			}
		}
		#endregion

		#region Methods
		public MasterPageViewModel(INavigation navigation)
		{
			_nav = navigation;
			_currUser = App.PubUser;
		}

		public void Update()
		{
			Count = "Scans: " + App.Database.GetResults(_currUser).Count().ToString();
			LastScan = "Last scan: " + App.Database.GetResults(_currUser).Last().Date.ToString() + " " + App.Database.GetResults(_currUser).Last().Time.ToString();
		}
		#endregion


		#region Commands
		// Method for what heppens when the scan button is clicked 
		// Scans the barcode, prompts a message, and adds it to the database
		public ICommand ScanCommand
		{
			get
			{
				if (_scanCommand == null)
				{
					_scanCommand = new Command(async () => await RunScan());
				}
				return _scanCommand;
			}
		}
		#endregion

		#region Tasks
		// Method to actually scan the barcode
		async Task RunScan()
		{
			await _nav.PushAsync(new ScannerPage(_nav));
		}
		#endregion
	}
}