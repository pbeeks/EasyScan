using Xamarin.Forms;

namespace BasicScanner
{
	public partial class MasterPage : ContentPage
	{
		public MasterPage()
		{
			NavigationPage.SetBackButtonTitle(this, "Back");
			InitializeComponent();
			this.BindingContext = new MasterPageViewModel(this.Navigation);
		}


	}
}


