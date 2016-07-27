using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace BasicScanner
{
	public partial class HistoryDetailsPage : ContentPage
	{
		public HistoryDetailsPage(ScanResult Info)
		{
			this.BindingContext = new HistoryDetailPageViewModel(Info, this.Navigation);
			InitializeComponent(); 
		}
	}
}

