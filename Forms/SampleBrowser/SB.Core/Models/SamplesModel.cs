#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
	public class SampleModel : INotifyPropertyChanged
	{
        #region fields

        private string title;

		private string icon;

		private string name;

		private string updateType;

		private string category;

        private string description;

        private string[] searchTags;

        private Color textColor = Color.Black;

        private string imageSelected;

        private bool enableLoadingIndicator;

        #endregion

        #region events

        /// <summary>
        /// Event to check property changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region properties

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
        /// Gets or sets Samples Category in SamplesListPage
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
        /// Gets or sets Samples Description in SamplesListPage
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
        /// Gets or sets Samples Update type for Samples in SamplesListPage
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
        /// Gets or sets Samples Name for creating instance in SamplesListPage
        /// </summary>
        public string Name
		{
			get
            {
                return name;
            }

			set
			{
				name = value;
				OnPropertyChanged("Name");
			}
		}

		/// <summary>
		/// Gets or sets Samples Icon in SamplesListPage
		/// </summary>
		public string Icon
		{
			get
            {
                return icon;
            }

			set
			{
				icon = value;
				OnPropertyChanged("Icon");
			}
		}

		/// <summary>
		/// Gets or sets Samples Title to be displayed in SamplesListPage
		/// </summary>
		public string Title
		{
			get
            {
                return title;
            }

			set
			{
				title = value;
				OnPropertyChanged("Title");
			}
		}

		/// <summary>
		/// Gets or sets Samples Images on selected
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

        /// <summary>
        /// Gets or sets a value indicating whether sample view shows loading indicator or not.
        /// </summary>
        public bool EnableLoadingIndicator
        {
            get
            {
                return enableLoadingIndicator;
            }

            set
            {
                enableLoadingIndicator = value;
                OnPropertyChanged("EnableLoadingIndicator");
            }
        }

        public string[] SearchTags
        {
            get
            {
                return searchTags;
            }

            set
            {
                searchTags = value;
                OnPropertyChanged("SearchTags");
            }
        }

        public string Type { get; set; } = "Samples";

        public string Control { get; set; }

        #endregion

        #region methods

        private void OnPropertyChanged(string propertyName)
		{
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}