using System.Linq;
using Xamarin.Forms;

namespace BasicScanner
{
	public partial class MasterPage : ContentPage
	{
		private User _currUser;
		private MasterPageViewModel _view;
		public MasterPage()
		{
			_currUser = App.PubUser;
			NavigationPage.SetBackButtonTitle(this, "Back");
			InitializeComponent();
			_view = new MasterPageViewModel(this.Navigation);
			this.BindingContext = _view;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			_view.Update();
		}
	}
}


