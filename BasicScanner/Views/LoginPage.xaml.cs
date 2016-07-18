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
