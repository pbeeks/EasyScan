using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace BasicScanner
{
	public class HistoryDetailPageViewModel
	{
		#region Variables
		public ScanResult HistoryData { get; set; }
		public string User { get; set; }
		public string Date { get; set; }
		public string Time { get; set; }
		public Image Barcode { get; set; }
		private INavigation _nav;
		#endregion

		#region Methods
		public HistoryDetailPageViewModel(ScanResult Info, INavigation iNav)
		{
			_nav = iNav;
			HistoryData = Info;
			Barcode = GetBarcode();
			User = App.PubUser.username;
			Time = HistoryData.DT.ToString("HH:mm");
			Date = HistoryData.DT.Date.ToString("dd/MM/yyyy");
		}

		// Method to generate the barcode image for the HistoryDetailsPage
		public Image GetBarcode()
		{
			ZXingBarcodeImageView barcode = new ZXingBarcodeImageView();

			// Switch statement for setting the barcode format
			string format = HistoryData.Format;
			switch (format)
			{
				case "All_1D":
					barcode.BarcodeFormat = ZXing.BarcodeFormat.All_1D;
					break;
				case "AZTEC":
					barcode.BarcodeFormat = ZXing.BarcodeFormat.AZTEC;
					break;
				case "CODABAR":
					barcode.BarcodeFormat = ZXing.BarcodeFormat.CODABAR;
					break;
				case "CODE_128":
					barcode.BarcodeFormat = ZXing.BarcodeFormat.CODE_128;
					break;
				case "CODE_39":
					barcode.BarcodeFormat = ZXing.BarcodeFormat.CODE_39;
					break;
				case "CODE_93":
					barcode.BarcodeFormat = ZXing.BarcodeFormat.CODE_93;
					break;
				case "DATA_MATRIX":
					barcode.BarcodeFormat = ZXing.BarcodeFormat.DATA_MATRIX;
					break;
				case "EAN_13":
					barcode.BarcodeFormat = ZXing.BarcodeFormat.EAN_13;
					break;
				case "EAN_8":
					barcode.BarcodeFormat = ZXing.BarcodeFormat.EAN_8;
					break;
				case "IMB":
					barcode.BarcodeFormat = ZXing.BarcodeFormat.IMB;
					break;
				case "ITF":
					barcode.BarcodeFormat = ZXing.BarcodeFormat.ITF;
					break;
				case "MAXICODE":
					barcode.BarcodeFormat = ZXing.BarcodeFormat.MAXICODE;
					break;
				case "MSI":
					barcode.BarcodeFormat = ZXing.BarcodeFormat.MSI;
					break;
				case "PDF_417":
					barcode.BarcodeFormat = ZXing.BarcodeFormat.PDF_417;
					break;
				case "PLESSEY":
					barcode.BarcodeFormat = ZXing.BarcodeFormat.PLESSEY;
					break;
				case "QR_CODE":
					barcode.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
					break;
				case "RSS_14":
					barcode.BarcodeFormat = ZXing.BarcodeFormat.RSS_14;
					break;
				case "RSS_EXPANDED":
					barcode.BarcodeFormat = ZXing.BarcodeFormat.RSS_EXPANDED;
					break;
				case "UPC_A":
					barcode.BarcodeFormat = ZXing.BarcodeFormat.UPC_A;
					break;
				case "UPC_E":
					barcode.BarcodeFormat = ZXing.BarcodeFormat.UPC_E;
					break;
				case "UPC_EAN_EXTENSION":
					barcode.BarcodeFormat = ZXing.BarcodeFormat.UPC_EAN_EXTENSION;
					break;
			}
			barcode.BarcodeOptions.Width = 400;
			barcode.BarcodeOptions.Height = 400;
			barcode.BarcodeOptions.Margin = 10;
			barcode.BarcodeValue = "Generated barcode";

			Image barcodeF = barcode as Image;
			return barcodeF;
		}
		#endregion

		#region Commands
		// Command to move a page back
		public Command _backCommand;
		public ICommand BackCommand
		{
			get
			{
				if (_backCommand == null)
				{
					_backCommand = new Command(async () => await RunBack());
				}
				return _backCommand;
			}
		}
		#endregion



		#region Tasks
		//Task to move a page back
		async Task RunBack()
		{
			await _nav.PopModalAsync();
		}
		#endregion
	}
}

