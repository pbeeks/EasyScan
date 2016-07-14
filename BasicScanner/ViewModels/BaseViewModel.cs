using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BasicScanner
{
	public class BaseViewModel : INotifyPropertyChanged
	{

		public event PropertyChangedEventHandler PropertyChanged;

		public BaseViewModel()
		{

		}

		public void OnPropertyChanged([CallerMemberName]string name = "")
		{
			var changed = PropertyChanged;
			if (changed == null)
				return;
			changed(this, new PropertyChangedEventArgs(name));
		}
	}
}

