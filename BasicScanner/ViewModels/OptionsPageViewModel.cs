using System.Reflection;
using System.Resources;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace BasicScanner
{
	public class OptionsPageViewModel
	{
		#region Variables
		private INavigation _nav;
		private Command _historyCommand;
		private Command _logoutCommand;
		private Command _mainPageCommand;
		private User _currUser;
		private ResourceManager _resmgr;
		#endregion

		#region Methods
		public OptionsPageViewModel(INavigation navigation)
		{
			_resmgr = new ResourceManager("BasicScanner.Resources.AppResources", typeof(TranslateExtension).GetTypeInfo().Assembly);
			_nav = navigation;
			_currUser = App.PubUser;
		}
		#endregion

		#region Commands
		public ICommand LogoutCommand
		{
			get
			{
				if (_logoutCommand == null)
				{
					_logoutCommand = new Command(async () => await LogoutTask());
				}
				return _logoutCommand;
			}
		}

		public ICommand HistoryCommand
		{
			get
			{
				if (_historyCommand == null)
				{
					_historyCommand = new Command(async () => await HistoryTask());
				}
				return _historyCommand;
			}
		}

		public ICommand MainPageCommand
		{
			get
			{
				if (_mainPageCommand == null)
				{
					_mainPageCommand = new Command(async () => await MainPageTask());
				}
				return _mainPageCommand;
			}
		}
		#endregion

		#region Tasks
		async Task HistoryTask()
		{
			var page = Application.Current.MainPage as RootPage;
			page.Detail = new NavigationPage(new HistoryPage())
			{
				BarBackgroundColor = Color.FromHex("#ff1a1a"),
				BarTextColor = Color.FromHex("#ffffff")
			};
		}

		//Task to log out and set the properties to diable the persisting user
		async Task LogoutTask()
		{
			string _logoutQuestion = _resmgr.GetString("LogOutQuestion");
			string _logOut = _resmgr.GetString("LogOutLabel");
			string _yes = _resmgr.GetString("Yes");
			string _no = _resmgr.GetString("No");
			bool result = await UserDialogs.Instance.ConfirmAsync(_logoutQuestion, _logOut,_yes, _no);
			if (result == true)
			{
				App.Current.Properties["IsLoggedIn"] = false;
				App.Current.Properties["loggedInUser"] = "";
				await App.Current.SavePropertiesAsync();
				App.Current.MainPage = new LoginPage();
			}
		}

		async Task MainPageTask()
		{
			var page = Application.Current.MainPage as RootPage;
			page.Detail = new NavigationPage(new MasterPage())
				{
				BarBackgroundColor = Color.FromHex("#ff1a1a"),
				BarTextColor = Color.FromHex("#ffffff")
			};
		}
		#endregion 
	}
}


