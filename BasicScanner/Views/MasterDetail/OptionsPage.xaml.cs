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
			this.BindingContext = new OptionsPageViewModel(this.Navigation);
			InitializeComponent();
		}
	}
}

