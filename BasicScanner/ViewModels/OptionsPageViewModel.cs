using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using Realms;
using Xamarin.Forms;

namespace BasicScanner
{
	public class OptionsPageViewModel
	{
		private User _currUser;
		private INavigation _nav;

		public OptionsPageViewModel(INavigation navigation)
		{
			_nav = navigation;
			_currUser = App.pubUser;
		}

		public Command _historyCommand;
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

		async Task HistoryTask()
		{
			await _nav.PushAsync(new HistoryPage()
			{
				Title = "History"
			});
		}

		public Command _logoutCommand;
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
	}
}


