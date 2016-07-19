using Xamarin.Forms;
using Acr.UserDialogs;
using System;
using System.Windows.Input;
using System.Threading.Tasks;

namespace BasicScanner
{
	public class LoginPageViewModel : BaseViewModel
	{
		#region Variables
		private INavigation _nav;
		private Command _loginCommand;
		#endregion

		#region Properties
		private string _userParam;
		public string UserParam
		{
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
		public string PassParam
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
		#endregion


		#region Methods
		public LoginPageViewModel(INavigation navigation)
		{
			_nav = navigation;
		}

		//Method to check if username and password pass the criteria
		public bool CanLogIn()
		{
			if (String.IsNullOrEmpty(UserParam) || String.IsNullOrEmpty(PassParam))
			{
				return false;
			}
			else if (UserParam.Length < 6 || PassParam.Length < 6)
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
			App.PubUser = user;
			App.Current.MainPage = new NavigationPage(new RootPage());
		}

		public async void NewUser()
		{
			// Give the user opportunity to create a new user
			await UserDialogs.Instance.AlertAsync(new AlertConfig
			{
				Title = "User not found, create user " + UserParam + "?",
			});

			User loginUser = new User();
			loginUser.username = UserParam;
			loginUser.password = PassParam;
			App.Database.InsertUser(loginUser);

			// Show successful login
			UserDialogs.Instance.SuccessToast("User created", null, 3000);
			PostLogin(loginUser);
		}
		#endregion

		#region Commands
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
		#endregion


		#region Tasks
		// Task to login the user
		public async Task Login()
		{
			var checkUser = App.Database.CheckUser(UserParam);
			// Username not in DB
			if (checkUser == false)
			{
				NewUser();
			}
			// Username used, password doesn't match
			else
			{
				var loginUser = App.Database.CheckCredentials(UserParam, PassParam);
				if (loginUser == null)
				{
					// Show login failure
					UserDialogs.Instance.ErrorToast("Login failed", "Username or password incorrect", 3000);
				}
				//Username and password match
				else {
					PostLogin(loginUser);
				}
			}
		}
		#endregion
	}
}

