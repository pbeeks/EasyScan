using System;
using System.Collections.Generic;
using Realms;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;
using System.Dynamic;
using Acr.UserDialogs;

namespace BasicScanner
{
	public partial class MasterPage : ContentPage
	{
		public MasterPage()
		{
			NavigationPage.SetBackButtonTitle(this, "Back");
			InitializeComponent();
			this.BindingContext = new MasterPageViewModel(this.Navigation);
		}


	}
}


