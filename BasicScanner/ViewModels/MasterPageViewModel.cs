using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using BasicScanner.Localization;
using System.Resources;
using System.Reflection;

namespace BasicScanner
{
	public class MasterPageViewModel : BaseViewModel
	{
		#region Variables
		private INavigation _nav;
		private Command _scanCommand;
		private User _currUser;

        ResourceManager _resmgr;
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
			_currUser = App.PubUser;
			_nav = navigation;

            //var culture = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();

            _resmgr = new ResourceManager("BasicScanner.Resources.AppResources", typeof(TranslateExtension).GetTypeInfo().Assembly);
            //if (culture != null)
            //{
            //    AppResources.Culture = culture;
            //}

            //if (Device.OS != TargetPlatform.WinPhone)
            //{
            //    AppResources.Culture = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            //}
		}

		public void Update()
		{
			string scans;
			string date;
			string time;
			try
			{
				scans = App.Database.GetResults(_currUser).Count().ToString();
				date = App.Database.GetResults(_currUser).ToList().Last().Date.ToString();
				time = App.Database.GetResults(_currUser).ToList().Last().Time.ToString();
			}
			catch
			{
				scans = "0";
				date = "--";
				time = "--";
			}

            //Count = AppResources.ScansLabel + scans;
            //LastScan = AppResources.LastScanLabel + date + " " + time;

			Count = _resmgr.GetString("ScansLabel") + scans;
			LastScan = _resmgr.GetString("LastScanLabel") + date + " " + time;


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