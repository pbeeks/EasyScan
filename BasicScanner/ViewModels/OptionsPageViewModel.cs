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
		private User _currUser;
		#endregion

		#region Methods
		public OptionsPageViewModel(INavigation navigation)
		{
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
		#endregion

		#region Tasks
		async Task HistoryTask()
		{
			await _nav.PushAsync(new HistoryPage()
			{
				Title = "History"
			});
		}

		//Task to log out and set the properties to diable the persisting user
		async Task LogoutTask()
		{
			bool result = await UserDialogs.Instance.ConfirmAsync("Are you sure you want to log out?", "Log out?", "Yes", "No");
			if (result == true)
			{
				App.Current.Properties["IsLoggedIn"] = false;
				App.Current.Properties["loggedInUser"] = "";
				await App.Current.SavePropertiesAsync();
				App.Current.MainPage = new LoginPage();
			}
		}
		#endregion
	}
}


