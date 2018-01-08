#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms.Internals;

namespace SampleBrowser
{
	public class NavigationLinkModel : INotifyPropertyChanged
	{
		private string linkText;
		private string linkURL;
		private string linkIcons;


		/// <summary>
		/// Gets Icons for links in Master Page
		/// </summary>

		public string LinkIcons
		{
			get { return linkIcons; }
			set
			{
				linkIcons = value;
				OnPropertyChanged("LinkIcons");
			}
		}


		/// <summary>
		/// Gets text displayed for Links in Master Page
		/// </summary>

		public string LinkText
		{
			get { return linkText; }
			set
			{
				linkText = value;
				OnPropertyChanged("LinkText");
			}
		}


        /// <summary>
        /// Gets URl for links in Master Page
        /// </summary>

		public string LinkURL
		{
			get { return linkURL; }
			set
			{
				linkURL = value;
				OnPropertyChanged("LinkURL");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged(string name)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(name));
		}
	}
}