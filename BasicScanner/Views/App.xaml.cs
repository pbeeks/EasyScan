using Xamarin.Forms;
using System;

namespace BasicScanner
{
	public partial class App : Application
	{
		static ScannerDatabase database;
		public static User PubUser { get; set; }

		public App()
		{
			InitializeComponent();
			var isLoggedIn = Properties.ContainsKey("IsLoggedIn") ? (bool)Properties["IsLoggedIn"] : false;

			int persistUser;
			if (Properties.ContainsKey("LoggedInUser"))
			{
				persistUser = Convert.ToInt32(App.Current.Properties["LoggedInUser"]);
			}
			else {
				persistUser = -1;
			}
			if (isLoggedIn == true)
			{
				PubUser = App.Database.GetUserByName(persistUser);

				MainPage = new NavigationPage(new RootPage());
			}
			else {
				MainPage = new LoginPage();
			}
		}

		public static ScannerDatabase Database { 
			get
			{
				if (database == null)
				{
					database = new ScannerDatabase();
				}
				return database;
			}
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

