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
}
