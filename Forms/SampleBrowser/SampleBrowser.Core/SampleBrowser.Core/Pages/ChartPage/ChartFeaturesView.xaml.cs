#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using Syncfusion.ListView.XForms;
using Xamarin.Forms;

namespace SampleBrowser.Core
{
	/// <summary>
	/// Content view for displaying featured samples list for Chart control.
	/// </summary>
	public partial class ChartFeaturesView : SampleView
	{
		int index;
		/// <summary>
		/// Initializes a new instance of the <see cref="ChartFeaturesView"/> class.
		/// </summary>
		public ChartFeaturesView(object featureSamples)
		{
			InitializeComponent();

            if (Device.RuntimePlatform == Device.UWP)
                listViewRow.Height = new GridLength(9, GridUnitType.Star);

			var samples = new ObservableCollection<SamplesModel>();
            var name = featureSamples as ObservableCollection<SamplesModel>;
			foreach (var item in name)
			{
				if (item.Category == "Features")
					samples.Add(item);
			}
			featuresLeftListView.ItemsSource = samples;
			featuresLeftListView.ItemTemplate = new DataTemplate(typeof(SamplesViewCell));
		}

		async void SamplesView_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
		{
            var sampleModel = e.ItemData as SamplesModel;
            index = featuresLeftListView.DataSource.DisplayItems.IndexOf(sampleModel);
			var page = new AllControlsSamplePage(sampleModel.EnableLoadingIndicator);
			page.Title = sampleModel.Name;

			if (Device.RuntimePlatform == "Android")
				await Navigation.PushAsync(page);

			page.LoadSample(featuresLeftListView.ItemsSource, sampleModel, "SfChart", index);

			if (Device.RuntimePlatform != "Android")
				await Navigation.PushAsync(page);
		}
	}
}