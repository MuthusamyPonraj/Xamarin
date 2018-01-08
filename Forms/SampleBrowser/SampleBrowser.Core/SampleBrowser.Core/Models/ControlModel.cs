#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using System.ComponentModel;
    
namespace SampleBrowser.Core
{
	/// <summary>
	/// Model file which has Control Details.
	/// </summary>
    public class ControlModel : INotifyPropertyChanged
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="ControlModel"/> class.
        /// </summary>
        public ControlModel()
        {
            Samples = new ObservableCollection<SamplesModel>();
        }

		string imageId;
		string title;
		string description;
		string updateType;
		int samplesCount;
        string controlName;

        /// <summary>
        /// Gets list of Samples in the control.
        /// </summary>
        public ObservableCollection<SamplesModel> Samples 
		{ 
			get; 
			set; 
		}

		/// <summary>
		/// Gets Samples Count in Control.
		/// </summary>
		public int SamplesCount
		{
			get { return samplesCount; }
			set
			{
				samplesCount = value;
				OnPropertyChanged("SamplesCount");
			}
		}

		/// <summary>
		/// Gets Controls Images in ControlsHomePage
		/// </summary>
		public string ImageId
		{
			get { return imageId; }
			set
			{
				imageId = value;
				OnPropertyChanged("ImageId");
			}
		}

		/// <summary>
		/// Gets Control Title to be displayed in ControlsHomePage
		/// </summary>
		public string Title
		{
			get { return title; }
			set
			{
				title = value;
				OnPropertyChanged("ControlsName");
			}
		}

		/// <summary>
		/// Gets Control Description in ControlsHomePage
		/// </summary>
		public string Description
		{
			get { return description; }
			set
			{
				description = value;
				OnPropertyChanged("Description");
			}
		}

		/// <summary>
		/// Gets Control Update type for Controls in SamplesListPage
		/// </summary>
		/// <value>Set true for any of these attributes "IsPreview" or "IsNew" or "IsUpdated" value.</value>
		public string UpdateType
		{
			get { return updateType; }
			set
			{
				updateType = value;
				OnPropertyChanged("ControlsUpdateType");
			}
		}
		
        /// <summary>
		/// Gets Controls Name in ControlsHomePage
		/// </summary>
		public string ControlName
		{
			get { return controlName; }
			set
			{
				controlName = value;
				OnPropertyChanged("ControlName");
			}
		}

		string[] tags;

		/// <summary>
		/// PropertyChanged Event.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets Control search tags in SamplesListPage
        /// </summary>
        public string[] Tags
		{
			get { return tags; }
			set
			{
				tags = value;
				OnPropertyChanged("Tags");
			}
		}

		void OnPropertyChanged(string name)
		{
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
	}
}