using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using BasicScanner;
using BasicScanner.iOS;
using UIKit;

[assembly: ExportRenderer(typeof(NativeListView), typeof(NativeiOSListViewRenderer))]
namespace BasicScanner.iOS
{
	public class NativeiOSListViewRenderer : ListViewRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e)
		{
			base.OnElementChanged(e);

			if (this.Control != null)
			{
				this.Control.TableFooterView = new UIView();
			}


		}
	}
}