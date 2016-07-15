using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BasicScanner
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		//Generic ViewModel to implement INotifyPropertyChanged interface to eliminate redundancies 
		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged([CallerMemberName] string name = "")
		{
			var handler = PropertyChanged;
			if (handler == null)
				return;
			handler(this, new PropertyChangedEventArgs(name));
		}
	}
}

