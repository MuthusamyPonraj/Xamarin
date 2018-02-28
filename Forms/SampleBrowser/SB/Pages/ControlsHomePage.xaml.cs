#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Linq;
using SampleBrowser.Core;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Syncfusion.DataSource;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Syncfusion.DataSource.Extensions;
using System;

namespace SampleBrowser
{
    public partial class ControlsHomePage : ContentPage
    {
        #region fields

        private Label loadingLabel;

        private bool isListItemClicked;

        private ControlPageViewModel viewModel;

        private string searchText = string.Empty;

        #endregion

        #region ctor

        public ControlsHomePage()
        {
            InitializeComponent();

            viewModel = new ControlPageViewModel();
            controlsList.ItemsSource = viewModel.ControlsList;
            if (Device.RuntimePlatform == Device.Android)
                searchBarRowDef.Height = 0.07 * Core.SampleBrowser.ScreenHeight;

			var SortImageTapped = new TapGestureRecognizer() { Command = new Command(SortImage_Tapped) };
			sortGrid.GestureRecognizers.Add(SortImageTapped);

			TemplateSelector.GroupingEnabled = false;
            searchBar.TextChanged += (sender, e) =>
            {
                var text = ((SearchBar)sender).Text;
                searchText = RemoveSpaces(text);
                if (!string.IsNullOrEmpty(text))
                {
                    TemplateSelector.GroupingEnabled = true;
					if (controlsList.ItemsSource != SortItemsSource())
						controlsList.ItemsSource = SortItemsSource();

                    PopulateFilteredControls();
                }
                else
                {
					controlsList.DataSource.GroupDescriptors.Clear();
                    TemplateSelector.GroupingEnabled = false;
					controlsList.ItemsSource = SortItemsSource();
                    controlsList.DataSource.RefreshFilter();
                }
            };

            loadingLabel = new Label { Text = "Loading Samples...", VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };
        }

        #endregion

        #region methods

        private async void AllControlsListView_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            if (isListItemClicked)
            {
                return;
            }

            isListItemClicked = true;
            var controlModel = e.ItemData as ControlModel;

            if (controlModel != null)
            {
                var samplesData = controlModel.Samples;
                string controlName = controlModel.Title, assemblyName = null;
                assemblyName = "SampleBrowser." + controlModel.ControlName;
                var page = Core.SampleBrowser.GetSamplesPage(samplesData, assemblyName, controlModel.ControlName);

                if (Device.RuntimePlatform == "Android")
                {
                    var content = page.Content;
                    page.Content = loadingLabel;
                    await Navigation.PushAsync(page);
                    page.Content = content;
                }
                else
                {
                    await Navigation.PushAsync(page);
                }
            }
            else
            {
                var sampleModel = e.ItemData as SampleModel;
                if(sampleModel != null)
                {
                    var index = 0;
                    ContentPage samplePage;
                    var controlName = sampleModel.Control;
                    controlModel = viewModel.ControlsList.FirstOrDefault(model => model.ControlName == controlName);
                    if (controlModel != null)
                        index = controlModel.Samples.IndexOf(sampleModel);
                    
                    var sampleList = controlModel.Samples;
                    if(controlName == "SfChart")
                        samplePage = new ChartSamplesPage(sampleList, index);
                    else
                        samplePage = new AllControlsSamplePage(null, sampleList, controlName, index);

                    if (Device.RuntimePlatform == "Android")
                    {
                        var content = samplePage.Content;
                        samplePage.Content = loadingLabel;
                        await Navigation.PushAsync(samplePage);
                        samplePage.Content = content;
                    }
                    else
                    {
                        await Navigation.PushAsync(samplePage);
                    }
                }
            }

            isListItemClicked = false;
        }

        private void PopulateFilteredControls()
        {
            if (controlsList.DataSource != null)
            {
                controlsList.DataSource.Filter = FilterControls;
                controlsList.DataSource.RefreshFilter();

                if (controlsList.DataSource.GroupDescriptors.Count == 0)
                    controlsList.DataSource.GroupDescriptors.Add(new GroupDescriptor { PropertyName = "Type" });
            }

            controlsList.RefreshView();
        }

        private string RemoveSpaces(string searchText)
        {
            return new string(searchText?.ToCharArray().Where(c => !char.IsWhiteSpace(c)).ToArray()).ToLower();
        }

        private bool FilterControls(object obj)
        {
            if (searchBar == null || searchBar.Text == null) return true;

            var controlModel = obj as ControlModel;
            if (controlModel != null)
            {
                var controlName = RemoveSpaces(controlModel.Title);
                if (controlName.Contains(searchText)) return true;

                if (controlModel.Tags != null && controlModel != null)
                {
                    foreach (string item in controlModel.Tags)
                    {
                        if (RemoveSpaces(item).Contains(searchText)) return true;
                    }
                }
            }
            else
            {
                var sampleModel = obj as SampleModel;
                if (sampleModel != null)
                {
                    var sampleName = RemoveSpaces(sampleModel.Title);
                    if (sampleName.Contains(searchText)) return true;

                    if (sampleModel.SearchTags != null)
                    {
                        foreach (var tag in sampleModel.SearchTags)
                        {
                            if (RemoveSpaces(tag).Contains(searchText)) return true;
                        }
                    }
                }
            }

            return false;
        }

        private void ControlsList_QueryItemSize(object sender, Syncfusion.ListView.XForms.QueryItemSizeEventArgs e)
        {
            if (!string.IsNullOrEmpty(searchBar.Text))
            {
                e.ItemSize = e.ItemData is ControlModel ? 70 : 50;
                controlsList.Padding = new Thickness(0, 0, 0, 0);
                controlsList.ItemSpacing = new Thickness(10, 3, 10, 0);
            }
            else
            {
                e.ItemSize = 95;
				controlsList.Padding = Device.RuntimePlatform == Device.Android ? new Thickness(0, 10, 0, 0) : new Thickness(0);
                controlsList.ItemSpacing = new Thickness(10, 0, 10, 10);
            }

            e.Handled = true;
        }

		private void SortImage_Tapped()
		{
			if (viewModel.SortOption == SortOption.Descending)
			{
				viewModel.SortOption = SortOption.None;
				sortImage.Source = ImageSource.FromFile("Ctrl_Sort_Icon.png");
			}
			else if (viewModel.SortOption == SortOption.None)
			{
				viewModel.SortOption = SortOption.Ascending;
				sortImage.Source = ImageSource.FromFile("Ctrl_Sort_Ascending.png");
			}
			else if (viewModel.SortOption == SortOption.Ascending)
			{
				viewModel.SortOption = SortOption.Descending;
				sortImage.Source = ImageSource.FromFile("Ctrl_Sort_Descending.png");
			}

			controlsList.ItemsSource = SortItemsSource();
			controlsList.RefreshView();
		}

		object SortItemsSource()
		{
			if (viewModel.SortOption == SortOption.Descending)
			{
				var controlList = viewModel.ControlsList.OrderByDescending(X => X.Title);

				if (!string.IsNullOrEmpty(searchBar.Text))
				{
					var sampleList = viewModel.SamplesList.OrderByDescending(X => X.Title);
					return new ObservableCollection<object>(controlList).Concat(new ObservableCollection<object>(sampleList));
				}
				else
					return new ObservableCollection<object>(controlList);
			}
			else if (viewModel.SortOption == SortOption.Ascending)
			{
				var controlList = viewModel.ControlsList.OrderBy(X => X.Title);

				if (!string.IsNullOrEmpty(searchBar.Text))
				{
					var sampleList = viewModel.SamplesList.OrderBy(X => X.Title);
					return new ObservableCollection<object>(controlList).Concat(new ObservableCollection<object>(sampleList));

				}
				else
					return new ObservableCollection<object>(controlList);
			}
			else
			{
				var controlList = viewModel.ControlsList;
				if (!string.IsNullOrEmpty(searchBar.Text))
				{
					var sampleList = viewModel.SamplesList;
					return new ObservableCollection<object>(controlList).Concat(new ObservableCollection<object>(sampleList));
				}
				else
					return new ObservableCollection<object>(controlList);
			}
		}

        #endregion
    }
}