using System;
using Realms;
using System.ServiceModel.Security;
using System.Collections.Generic;
using ZXing.Net.Mobile.Forms;

namespace BasicScanner
{
	public class RealmDB
	{
		public RealmDB()
		{
		}

		public class User : RealmObject { 
			[ObjectId]
			public string username { get; set; }

			public string password { get; set; }
		
		}

		public class ScanResult : RealmObject { 
			 
			public string Date { get; set; }

			public string Time { get; set; }

			public User Owner { get; set; }

			public string Format { get; set; }

			public string Content { get; set; }

		}
	}
}

