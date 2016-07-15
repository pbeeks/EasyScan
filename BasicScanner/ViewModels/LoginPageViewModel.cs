using Xamarin.Forms;
using Acr.UserDialogs;
using System;
using System.Windows.Input;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BasicScanner
{
	public class LoginPageViewModel: BaseViewModel
	{
		private string _userParam;
		public string userParam { 
			get
			{
				return _userParam;
			}
			set
			{
				if (_userParam != value)
				{
					_userParam = value;
					OnPropertyChanged();
					_loginCommand.ChangeCanExecute();
				}
			}
		}


		private string _passParam;
		public string passParam
		{
			get
			{
				return _passParam;
			}
			set
			{
				if (_passParam != value)
				{
					_passParam = value;
					OnPropertyChanged();
					_loginCommand.ChangeCanExecute();
				}
			}
		}


		private INavigation _nav;

		public LoginPageViewModel(INavigation navigation)
		{
			_nav = navigation;
		}

		public Command _loginCommand;
		public ICommand LoginCommand
		{
			get
			{
				if (_loginCommand == null)
				{
					_loginCommand = new Command(async () => await Login(), CanLogIn);
				}
				return _loginCommand;
			}
		}

		// Method to login the user
		public async Task Login()
		{

			var currentUser = App.Database.GetUser(userParam, passParam);
			if (currentUser == null)
			{
				// Give the user opportunity to create a new user
				var answer = await UserDialogs.Instance.ConfirmAsync("User not found, create user " + userParam + "?", "Cancel", "Create");
				if (answer == true)
				{
					User loginUser = new User();
					loginUser.username = userParam;
					loginUser.password = passParam;
					App.Database.InsertUser(loginUser);

					// Show successful login
					UserDialogs.Instance.SuccessToast("User created", null, 3000);
					PostLogin(loginUser);
				}
			}
			else
			{
				// Check if the username & password match
				User loginUser = App.Database.GetUser(userParam, passParam);
				if (loginUser == null)
				{
					// Show login failure
					UserDialogs.Instance.ErrorToast("Login failed", "Username or password incorrect", 3000);
				}
				PostLogin(loginUser);
			}
		}

		//Method to check if username and password pass the criteria
		public bool CanLogIn()
		{
			if (String.IsNullOrEmpty(userParam) || String.IsNullOrEmpty(passParam))
			{
				return false;
			}
			else if (userParam.Length < 6 || passParam.Length < 6)
			{
				return false;
			}
			else {
				return true;
			}
		}

		//Method to assign properties for persistent user login
		public void PostLogin(User user)
		{
			App.Current.Properties["IsLoggedIn"] = true;
			App.Current.Properties["LoggedInUser"] = user.ID;
			App.Current.SavePropertiesAsync();
			App.pubUser = user;
			App.Current.MainPage = new NavigationPage(new RootPage());
		}
	}
}

