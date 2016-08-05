using System;
using System.Collections.Generic;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace BasicScanner
{
	public partial class OptionsPage : ContentPage
	{
		
		public OptionsPage()
		{
			Title = "(options page codebehind)";
			this.BindingContext = new OptionsPageViewModel(this.Navigation);
			InitializeComponent();
		}

		public void Boom(object sender, EventArgs e) {
			var page = Application.Current.MainPage as RootPage;
			page.Detail = new NavigationPage(new HistoryPage());

		}
	}
}

