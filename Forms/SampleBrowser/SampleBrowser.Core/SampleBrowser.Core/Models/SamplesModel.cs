#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.Core
{
	/// <summary>
	/// Model for setting details for SamplesModel.
	/// </summary>
	public class SamplesModel : INotifyPropertyChanged
	{
		string title;
		string icon;
		string name;
		string updateType;
		string category;
        string description;
        Color textColor = Color.Black;

        public Color TextColor
        {
            get
            {
                return textColor;
            }
            set
            {
                textColor = value;
                OnPropertyChanged("TextColor");
            }
        }

		/// <summary>
		/// Gets Samples Category in SamplesListPage
		/// </summary>
		/// <value>This property takes either "Types" or "Features" as value.</value>
		public string Category
		{
			get
			{
				return category;
			}
			set
			{
				category = value;
				OnPropertyChanged("Category");
			}
		}

		/// <summary>
		/// Gets Samples Description in SamplesListPage
		/// </summary>
		public string Description
		{
			get
			{
				return description;
			}
			set
			{
				description = value;
				OnPropertyChanged("Description");
			}
		}

		/// <summary>
		/// Gets Samples Update type for Samples in SamplesListPage
		/// </summary>
		/// <value>Set true for any of these attributes "IsPreview" or "IsNew" or "IsUpdated" value.</value>
		public string UpdateType
		{
			get
			{
				return updateType;
			}
			set
			{
				updateType = value;
				OnPropertyChanged("UpdateType");
			}
		}

		/// <summary>
		/// Gets Samples Name for creating instance in SamplesListPage
		/// </summary>
		public string Name
		{
			get { return name; }
			set
			{
				name = value;
				OnPropertyChanged("Name");
			}
		}

		/// <summary>
		/// Gets Samples Icon in SamplesListPage
		/// </summary>
		public string Icon
		{
			get { return icon; }
			set
			{
				icon = value;
				OnPropertyChanged("Icon");
			}
		}

		/// <summary>
		/// Gets Samples Title to be displayed in SamplesListPage
		/// </summary>
		public string Title
		{
			get { return title; }
			set
			{
				title = value;
				OnPropertyChanged("Title");
			}
		}

		string imageSelected;

		/// <summary>
		/// Gets Samples Images on selected
		/// </summary>
		public string ImageSelected
		{
			get
			{
				return imageSelected;
			}
			set
			{
				imageSelected = value;
				OnPropertyChanged("ImageSelected");
			}
		}

        private bool enableLoadingIndicator;
        /// <summary>
        /// Gets or sets the sample view shows loading indicator or not.
        /// </summary>
        public bool EnableLoadingIndicator
        {
            get { return enableLoadingIndicator; }
            set
            {
                enableLoadingIndicator = value;
                OnPropertyChanged("EnableLoadingIndicator");
            }
        }

        /// <summary>
        /// Event to check property changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
		{
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
	}
}