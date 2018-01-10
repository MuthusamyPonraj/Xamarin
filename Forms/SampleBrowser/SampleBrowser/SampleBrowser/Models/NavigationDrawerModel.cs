#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms.Internals;

namespace SampleBrowser
{
	public class NavigationDrawerModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		string appVersion;
		string appDesc;
		string appName;


		/// <summary>
		/// Gets Application version in MasterPage
		/// </summary>

		public string AppVersion
		{
			get
			{
				return appVersion;
			}
			set
			{
				appVersion = value;
				OnPropertyChanged("AppVersion");
			}
		}

		/// <summary>
		/// Gets Application Name
		/// </summary>

		public string AppName
		{
			get
			{
				return appName;
			}
			set
			{
				appName = value;
				OnPropertyChanged("AppName");
			}
		}

		/// <summary>
		/// Gets Application description in MasterPage
		/// </summary>

		public string AppDesc
		{
			get
			{
				return appDesc;
			}
			set
			{
				appDesc = value;
				OnPropertyChanged("AppDesc");
			}
		}

		public void OnPropertyChanged(string name)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(name));
		}
	}
}