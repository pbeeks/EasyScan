using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BasicScanner
{
	public partial class LoginPage : ContentPage
	{
		private LoginPageViewModel _loginPageVM;

		public LoginPage()
		{
			NavigationPage.SetHasNavigationBar(this, false);
			this.BindingContext = _loginPageVM;
			InitializeComponent();
		}

		public void LoginClicked(object sender, EventArgs e) {
			string username = null;
			string password = null;
			_loginPageVM = new LoginPageViewModel();
			username = usernameBox.Text;
			password = passwordBox.Text;
			_loginPageVM.Login(username, password);
		}

		public void OnComplete(object sender, EventArgs e) {
			if (usernameBox.Text.Length > 5 && passwordBox.Text.Length > 5) {
				loginButton.IsEnabled = true;
			}
		}
	}
}

