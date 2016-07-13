using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using Realms;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace BasicScanner
{
	public class MasterPageViewModel 
	{
		private User _currUser;
		private INavigation _nav;

		public MasterPageViewModel(INavigation navigation)
		{
			_nav = navigation;
			_currUser = App.pubUser;
		}


		// Method for what heppens when the scan button is clicked 
		// Scans the barcode, prompts a message, and adds it to the database
		public Command _scanCommand;
		public ICommand ScanCommand
		{
			get
			{
				if (_scanCommand == null)
				{
					_scanCommand = new Command(async () => await RunScan());
				}
				return _scanCommand;
			}
		}

		// Method to actually scan the barcode
		async Task RunScan()
		{
			await _nav.PushAsync(new ScannerPage(_nav));
		}
	}
}