using Xamarin.Forms;
using Acr.UserDialogs;

namespace BasicScanner
{
	public class LoginPageViewModel
	{
		public LoginPageViewModel()
		{

		}

		// Method to login the user
		public async void Login(string userParam, string passParam)
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

