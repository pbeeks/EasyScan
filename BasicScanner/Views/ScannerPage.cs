using System;
using ZXing.Net.Mobile.Forms;
using Xamarin.Forms;
using Acr.UserDialogs;
using System.Resources;
using System.Reflection;

namespace BasicScanner
{
	public class ScannerPage : ContentPage
	{
		ZXingScannerView zxing;
		ZXingDefaultOverlay overlay;
		private INavigation _nav;
		private User _currUser;
		ResourceManager _resmgr;

		public ScannerPage(INavigation nav)
		{
			_resmgr = new ResourceManager("BasicScanner.Resources.AppResources", typeof(TranslateExtension).GetTypeInfo().Assembly);
			_currUser = App.PubUser;
			_nav = nav;
			Title = _resmgr.GetString("ScanLabel");
			zxing = new ZXingScannerView()
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			zxing.OnScanResult += (result) =>
			   Device.BeginInvokeOnMainThread(async () =>
			  {
				  // Stop analysis until we navigate away so we don't keep reading barcodes
				  zxing.IsAnalyzing = false;
				  zxing.IsScanning = false;
#if __ANDROID__
   			 // Initialize the scanner first so it can track the current context
   			 MobileBarcodeScanner.Initialize (Application);
#endif

				  if (result != null)
				  {
					  var answer = await UserDialogs.Instance.ConfirmAsync("Would you like to track this barcode?", "Barcode found!", "Yes", "No");
					  if (answer == true)
					  {
						  DateTime dt = DateTime.Now;
						  var newScan = new ScanResult();
						  newScan.DT = dt;
						  newScan.Format = result.BarcodeFormat.ToString();
						  newScan.UserID = _currUser.ID;
						  newScan.Content = result.Text;
						  App.Database.InsertScanResult(newScan);
					  }
				  }
				  await _nav.PopAsync();
			  });

			overlay = new ZXingDefaultOverlay
			{
				TopText = "Hold your phone up to the barcode",
				BottomText = "Scanning will happen automatically",
			};

			var grid = new Grid
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};
			grid.Children.Add(zxing);
			grid.Children.Add(overlay);

			// The root page of your application
			Content = grid;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			zxing.IsScanning = true;
		}

		protected override void OnDisappearing()
		{
			zxing.IsScanning = false;

			base.OnDisappearing();
		}

	}
}