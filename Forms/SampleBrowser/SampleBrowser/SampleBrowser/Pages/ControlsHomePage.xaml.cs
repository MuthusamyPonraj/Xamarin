#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Linq;
using SampleBrowser.Core;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser
{
	public partial class ControlsHomePage : ContentPage
    {
        Label loadingLabel;

        public StackLayout SearchBarStack { get { return searchBarGrid; } }
        public ControlsHomePage()
        {
            InitializeComponent();

            if (Device.RuntimePlatform == Device.Android ||Device.RuntimePlatform == Device.iOS)
            {
                searchBarGrid.Margin = new Thickness(0.002 * Core.SampleBrowser.ScreenHeight);
                searchBarGrid.WidthRequest = Core.SampleBrowser.ScreenWidth;
                navigationBarRow.Height = 0.08 * Core.SampleBrowser.ScreenHeight;
                allControlsListViewRow.Height = 0.92 * Core.SampleBrowser.ScreenHeight;
            }

            searchBar.TextChanged += (object sender, TextChangedEventArgs e) =>
            {
               var text = ((SearchBar)sender).Text;
               if (e.NewTextValue != "")
               {
                   PopulateFilteredControls();
               }
               else
               {
                   controlsList.DataSource.RefreshFilter();
               }
           };

            loadingLabel = new Label { Text = "Loading Samples...", VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };
        }

		bool isListItemClicked;

        async void AllControlsListView_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
			if (isListItemClicked) return;
			isListItemClicked = true;

            var controlName = (e.ItemData as ControlModel).Title;
            string assemblyName = null;

            if (controlName != null)
            {
                var controlsData = e.ItemData as ControlModel;
                var samplesData = controlsData.Samples;
                assemblyName = "SampleBrowser." + controlsData.ControlName;
				var page = Core.SampleBrowser.GetSamplesPage(samplesData, assemblyName, controlsData.ControlName, controlsData.Title);

                if (Device.RuntimePlatform == "Android")
                {
                    var content = page.Content;
                    page.Content = loadingLabel;
                    await Navigation.PushAsync(page);
                    page.Content = content;
                }
                else
                    await Navigation.PushAsync(page);
            }
			isListItemClicked = false;
        }

		void PopulateFilteredControls()
		{
			if (controlsList.DataSource != null)
			{
				controlsList.DataSource.Filter = FilterControls;
				controlsList.DataSource.RefreshFilter();
			}
			controlsList.RefreshView();
		}

		string RemoveSpaces(string searchText)
		{
			return new string(searchText.ToCharArray().Where(c => !Char.IsWhiteSpace(c)).ToArray()).ToLower();
		}

		bool FilterControls(object obj)
		{
			if (searchBar == null || searchBar.Text == null)
				return true;

			var control = obj as ControlModel;
			string searchText = RemoveSpaces(searchBar.Text);
			string controlName = RemoveSpaces(control.Title);
			bool hasSearchText = false;
			if (control.Title.ToLower().Contains(searchBar.Text.ToLower()))
				return true;
			if (control.Tags != null && control != null)
			{
				foreach (string item in control.Tags)
				{
					string tags = RemoveSpaces(item);
					if (tags.ToLower().Contains(searchBar.Text.ToLower()))
						hasSearchText = true;
				}
			}
			return hasSearchText;
		}

        protected override void OnSizeAllocated(double width, double height)
        {            
            base.OnSizeAllocated(width, height);
            if (Device.RuntimePlatform == Device.UWP)
            {
                if (Device.Idiom == TargetIdiom.Phone)
                {
                    searchBarGrid.HeightRequest = 0.1 * height;
                    navigationBarRow.Height = 0.1 * height;
                    allControlsListViewRow.Height = 0.9 * height;
                    searchBarGrid.WidthRequest = width;
                }
                else
                {
                    searchBarGrid.Margin = new Thickness(0, 0, 30, 0);
                    searchBarGrid.WidthRequest = 0.2 * width;
                    searchBarGrid.HeightRequest = 0.05 * height;
                    navigationBarRow.Height = 0.07 * height;
                    allControlsListViewRow.Height = height;                    
                }
            }
        }
    }
}