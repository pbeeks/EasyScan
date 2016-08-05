using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace BasicScanner
{
	public partial class RootPage : MasterDetailPage
	{
		public RootPage()
		{
			Detail = new NavigationPage(new MasterPage())
			{
				BarBackgroundColor = Color.FromHex("#ff1a1a"),
				BarTextColor = Color.FromHex("#ffffff")
			};
			Master = new OptionsPage()
			{
				Icon = "burg.png",
				Title = "menu",
				BackgroundColor = Color.FromHex("ff1a1a")
			};
		}

	}
}

