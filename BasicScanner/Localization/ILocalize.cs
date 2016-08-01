using System;
using System.Globalization;


namespace BasicScanner
{

	public interface ILocalize
	{
		CultureInfo GetCurrentCultureInfo();

		void SetLocale();
	}
}