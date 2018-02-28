#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
        #region fields

        private string imageId;

		private string title;

		private string description;

		private string updateType;

		private int samplesCount;

        private string controlName;

        private string[] tags;

        #endregion

        #region ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="ControlModel"/> class.
        /// </summary>
        public ControlModel()
        {
            Samples = new ObservableCollection<SampleModel>();
        }

        #endregion

        #region events

        /// <summary>
        /// PropertyChanged Event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region properties

        /// <summary>
        /// Gets or sets list of Samples in the control.
        /// </summary>
        public ObservableCollection<SampleModel> Samples 
		{ 
			get; 
			set; 
		}

        /// <summary>
        /// Gets or sets Samples Count in Control.
        /// </summary>
        public int SamplesCount
		{
			get
            {
                return samplesCount;
            }

			set
			{
				samplesCount = value;
				OnPropertyChanged("SamplesCount");
			}
		}

        /// <summary>
        /// Gets or sets Controls Images in ControlsHomePage
        /// </summary>
        public string ImageId
		{
			get
            {
                return imageId;
            }

			set
			{
				imageId = value;
				OnPropertyChanged("ImageId");
			}
		}

        /// <summary>
        /// Gets or sets Control Title to be displayed in ControlsHomePage
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
				OnPropertyChanged("ControlsName");
			}
		}

        /// <summary>
        /// Gets or sets Control Description in ControlsHomePage
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
        /// Gets or sets Control Update type for Controls in SamplesListPage
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
				OnPropertyChanged("ControlsUpdateType");
			}
		}

        /// <summary>
        /// Gets or sets Controls Name in ControlsHomePage
        /// </summary>
        public string ControlName
		{
			get
            {
                return controlName;
            }

			set
			{
				controlName = value;
				OnPropertyChanged("ControlName");
			}
		}

        /// <summary>
        /// Gets or sets Control search tags in SamplesListPage
        /// </summary>
        public string[] Tags
		{
			get
            {
                return tags;
            }

			set
			{
				tags = value;
				OnPropertyChanged("Tags");
			}
		}

        public string Type { get; set; } = "Controls";

        #endregion

        #region methods

        private void OnPropertyChanged(string name)
		{
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}