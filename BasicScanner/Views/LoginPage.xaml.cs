using System;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;

namespace BasicScanner
{
	public partial class LoginPage : ContentPage
	{

		public LoginPage()
		{
			NavigationPage.SetHasNavigationBar(this, false);
			this.BindingContext = new LoginPageViewModel(this.Navigation);
			InitializeComponent();

		}
	}

	//Converter for password and username enrty boxes
	public class MultiTriggerConverter : IValueConverter
	{
		public object Convert(object value, Type targetType,
			object parameter, CultureInfo culture)
		{
			if ((int)value > 5) // length > 0 ?
				return true;            // some data has been entered
			else
				return false;           // input is empty
		}

		public object ConvertBack(object value, Type targetType,
			object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}

//public void LoginClicked(object sender, EventArgs e)
//{
//	string username = null;
//	string password = null;
//	_loginPageVM = new LoginPageViewModel();
//	username = usernameBox.Text;
//	password = passwordBox.Text;
//	_loginPageVM.Login(username, password);
//}

//public void OnComplete(object sender, EventArgs e) {
//	if (usernameBox.Text.Length > 5 && passwordBox.Text.Length > 5) {
//		loginButton.IsEnabled = true;
//	}
//}
