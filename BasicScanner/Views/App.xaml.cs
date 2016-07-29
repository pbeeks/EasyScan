using Xamarin.Forms;
using System;
using System.Reflection;

namespace BasicScanner
{
	public partial class App : Application
	{
		static ScannerDatabase database;
		public static User PubUser { get; set; }

		public App()
		{

			InitializeComponent();


			#region Expiramental
			System.Diagnostics.Debug.WriteLine("===============");
			var assembly = typeof(App).GetTypeInfo().Assembly;
			foreach (var res in assembly.GetManifestResourceNames())
				System.Diagnostics.Debug.WriteLine("found resource: " + res);


			if (Device.OS != TargetPlatform.WinPhone)
			{
				DependencyService.Get<ILocalize>().SetLocale();
				//Resx.AppResources.Culture = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
			}
			#endregion

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

