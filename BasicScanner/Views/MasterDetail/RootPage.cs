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
			NavigationPage.SetHasNavigationBar(this, false);
			Detail = new NavigationPage(new MasterPage());
			Master = new OptionsPage()
			{
				Icon = "burg.png",
				Title = "menu",
				BackgroundColor = Color.FromHex("d3d3d3")
			};
		}

	}
}

