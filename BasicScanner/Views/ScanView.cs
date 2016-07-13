using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace BasicScanner
{
	public class ScanView : ContentPage
	{
		ZXingScannerPage scanPage;
		Button buttonScanDefaultOverlay;
		Button buttonScanCustomOverlay;
		Button buttonScanContinuously;
		Button buttonScanCustomPage;
		Button buttonGenerateBarcode;

		public ScanView() : base()
		{
			buttonScanCustomOverlay.Clicked += async delegate
			{
				// Create our custom overlay
				var customOverlay = new StackLayout
				{
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand
				};

				scanPage = new ZXingScannerPage(customOverlay: customOverlay);
				scanPage.OnScanResult += (result) =>
				{
					scanPage.IsScanning = false;

					Device.BeginInvokeOnMainThread(() =>
					{
						Navigation.PopAsync();
						DisplayAlert("Scanned Barcode", result.Text, "OK");
					});
				};
				await Navigation.PushAsync(scanPage);
			};

			var stack = new StackLayout();
			stack.Children.Add(buttonScanDefaultOverlay);
			stack.Children.Add(buttonScanCustomOverlay);
			stack.Children.Add(buttonScanContinuously);
			stack.Children.Add(buttonGenerateBarcode);

			Content = stack;
		}
	}
}