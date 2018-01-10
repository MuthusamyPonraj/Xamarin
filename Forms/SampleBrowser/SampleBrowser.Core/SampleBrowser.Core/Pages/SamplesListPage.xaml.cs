#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using System.Diagnostics;
using Syncfusion.ListView.XForms;
using Xamarin.Forms;

namespace SampleBrowser.Core
{
	/// <summary>
	/// Content page for displaying Samples List Page
	/// </summary>
	public partial class SamplesListPage : ContentPage
	{
		string controlName;

		/// <summary>
		/// Initializes a new instance of the <see cref="SamplesListPage"/> class.
		/// </summary>
		public SamplesListPage(object samples,string control)
		{
			InitializeComponent();

			if (samples != null)
			{
                var samplesList = (samples as ObservableCollection<SamplesModel>);
                Title = control;
				controlName = Title;
				samplesListView.ItemsSource = samplesList;
				samplesListView.ItemTemplate = new DataTemplate(typeof(SamplesViewCell));
			}
		}

		async void SamplesListView_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
		{
			int i = samplesListView.DataSource.DisplayItems.IndexOf(e.ItemData);
			if (samplesListView.ItemsSource != null)
			{
                var sampleModel = e.ItemData as SamplesModel;
                var page = new AllControlsSamplePage(sampleModel.EnableLoadingIndicator) { Title = sampleModel.Name };

				if (Device.RuntimePlatform == "Android")
					await Navigation.PushAsync(page);
				page.LoadSample(samplesListView.ItemsSource, sampleModel, controlName, i);
				if (Device.RuntimePlatform != "Android")
					await Navigation.PushAsync(page);
			}
		}
	}
}