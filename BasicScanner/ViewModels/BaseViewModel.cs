using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BasicScanner
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		#region Events
		//Generic ViewModel to implement INotifyPropertyChanged interface to eliminate redundancies 
		public event PropertyChangedEventHandler PropertyChanged;
		#endregion



		#region Methods
		public void OnPropertyChanged([CallerMemberName] string name = "")
		{
			var handler = PropertyChanged;
			if (handler == null)
				return;
			handler(this, new PropertyChangedEventArgs(name));
		}
		#endregion
	}
}

