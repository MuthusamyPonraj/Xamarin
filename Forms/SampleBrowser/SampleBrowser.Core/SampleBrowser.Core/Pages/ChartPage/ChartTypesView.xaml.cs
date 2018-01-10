#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace SampleBrowser.Core
{
	/// <summary>
	/// Content view for displaying various Types of Chart control.
	/// </summary>
	public partial class ChartTypesView : SampleView
	{
		Type previousSample;
		double samplesHeight = 1, typesListHeight, optionsHeight;
		ToolbarItem setButton;
        ChartSamplesPage chartSamplePage;

        string selectedSample;
        internal string SelectedSample
        {
            get
            {
                return selectedSample;
            }
            set
            {
                selectedSample = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChartTypesView"/> class.
        /// </summary>
		public ChartTypesView(object typeSamples,ToolbarItem settingsButton, ChartSamplesPage chartSamplePage)
		{
			InitializeComponent();
            this.chartSamplePage = chartSamplePage;
            if (Device.RuntimePlatform == Device.UWP)
            {
                chartTypesListView.ItemTemplate = new LabelColorSelector();
                if (Device.Idiom == TargetIdiom.Desktop)
                {
                    propertiesHeaderRow.Height = new GridLength(1, GridUnitType.Star);
                    propertiesContentRow.Height = new GridLength(9, GridUnitType.Star);

                    titleCol.Width = new GridLength(10, GridUnitType.Star);
                    closeButtonCol.Width = new GridLength(0, GridUnitType.Star);
                }
                else
                {
                    AbsoluteLayout.SetLayoutBounds(propertiesView, new Rectangle(1, 2, 1, 0.5));
                    propertiesHeaderRow.Height = new GridLength(2, GridUnitType.Star);
                    propertiesContentRow.Height = new GridLength(8, GridUnitType.Star);

                    titleCol.Width = new GridLength(8, GridUnitType.Star);
                    closeButtonCol.Width = new GridLength(0, GridUnitType.Star);
                }
                    typesListRow.Height = new GridLength(9, GridUnitType.Star);
                    typesSampleRow.Height = new GridLength(1, GridUnitType.Star);
                }              

            if (Device.RuntimePlatform != Device.UWP)
            {
                if (Device.Idiom == TargetIdiom.Tablet)
                {
                    chartTypesListView.Padding = new Thickness(0, 2, 0, 2);
                    typesListHeight = 70;
                }
                else
                {
                    chartTypesListView.Padding = new Thickness(0, 5, 0, 5);
                    typesListHeight = 62;
                }
                typesSampleRow.Height = new GridLength(1, GridUnitType.Star);
                typesListRow.Height = typesListHeight;

                optionsHeight = (float)(0.5 * samplesHeight);
                propertiesView.HeightRequest = optionsHeight;

                if (Device.Idiom == TargetIdiom.Tablet)
                {
                    propertiesHeaderRow.Height = 0.13 * optionsHeight;
                    propertiesContentRow.Height = 0.87 * optionsHeight;
                }
                else if (Device.Idiom == TargetIdiom.Phone)
                {
                    propertiesHeaderRow.Height = 0.23 * optionsHeight;
                    propertiesContentRow.Height = 0.77 * optionsHeight;
                }
            }
            setButton = settingsButton;
			if (typeSamples != null)
			{
				var samples = new ObservableCollection<SamplesModel>();
                var name = typeSamples as ObservableCollection<SamplesModel>;
				foreach (var item in name)
				{
					if (item.Category == "Types")
						samples.Add(item);
				}
				chartTypesListView.ItemsSource = samples;
                chartTypesListView.SelectedItem = samples[0];
                var type = DependencyService.Get<ISampleBrowserService>().GetAssembliesType("SampleBrowser.SfChart", samples[0].Name);
                selectedSample = samples[0].Name;
				previousSample = type;
                if (type != null)
                {
                    var instance = AllControlsSamplePage.CreateInstance(type);
                    SetRowColumn(instance);
                    chartTypesGrid.Children.Add(instance);
                    if (instance.PropertyView != null)
                    {
                        this.chartSamplePage.IsPropertyWindowVisible = true;
                        settingsButton.Icon = "Option.png";
                        propertiesContent.Content = instance.PropertyView;
                        settingsButton.Clicked -= OptionsButton_Clicked;
                        settingsButton.Clicked += OptionsButton_Clicked;
                    }
                    else
                    {
                        this.chartSamplePage.IsPropertyWindowVisible = false;
                        settingsButton.Icon = "";
                    }
                }
			}
			if (chartTypesListView != null)
			{
				chartTypesListView.ItemTapped += ChartTypesListView_ItemTapped;
			}
		}

		void ChartTypesListView_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
		{
            if (isSettingsOpen)
                ClosePropertiesView();

			if (e.ItemData != null)
			{
				var currentSample = (e.ItemData as SamplesModel);
				if (previousSample.Name != currentSample.Name)
				{
					foreach (var child in chartTypesGrid.Children.Reverse())
					{
						var childTypeName = child.GetType().Name;
                        if (childTypeName == previousSample.Name)
                        {
                            (child as SampleView).OnDisappearing();
                            chartTypesGrid.Children.Remove(child);
                        }
					}

                    var type = DependencyService.Get<ISampleBrowserService>().GetAssembliesType("SampleBrowser.SfChart", currentSample.Name);
                    selectedSample = currentSample.Name;
					if (type != null)
					{
						previousSample = type;
                        var instance = AllControlsSamplePage.CreateInstance(type);
						SetRowColumn(instance);
						chartTypesGrid.Children.Add(instance);
                        (instance as SampleView).OnAppearing();

						if (instance.PropertyView != null)
						{
                            this.chartSamplePage.IsPropertyWindowVisible = true;
                            setButton.Icon = "Option.png";
                            setButton.Clicked -= OptionsButton_Clicked;
                            setButton.Clicked += OptionsButton_Clicked;
							propertiesContent.Content = instance.PropertyView;
                            isSettingsOpen = false;
                        }
						else
                        {
                            this.chartSamplePage.IsPropertyWindowVisible = false;
                            setButton.Icon = "";
						}
					}
				}
			}
			if (chartTypesListView != null)
			{
				var index = chartTypesListView.DataSource.DisplayItems.IndexOf(e.ItemData);
			}
		}


        bool isSettingsOpen;
        void OptionsButton_Clicked(object sender, EventArgs e)
		{
            if (isSettingsOpen)
            {
                isSettingsOpen = false;
                ClosePropertiesView();
            }
            else
            {
                isSettingsOpen = true;
                OpenPropertiesView();
            }
        }

		void PropertiesClosebutton_Clicked(object sender, EventArgs e)
		{
            ClosePropertiesView();
            isSettingsOpen = false;
        }

        void OpenPropertiesView()
        {
            stackLayout.BackgroundColor = Color.FromHex("007DE6");
            closeButton.BackgroundColor = Color.FromHex("007DE6");

            if (Device.RuntimePlatform == Device.UWP)
            {
                if (Device.Idiom == TargetIdiom.Desktop)
                    AbsoluteLayout.SetLayoutBounds(propertiesView, new Rectangle(1, 0, 0.25, 1));
                else if (Device.Idiom == TargetIdiom.Phone)
                {
                    AbsoluteLayout.SetLayoutBounds(propertiesView, new Rectangle(1, 1, 1, 0.5));
                    chartTypesGrid.Opacity = 0.5;
                }
                if (!absoluteLay.Children.Contains(propertiesView))
                    absoluteLay.Children.Add(propertiesView);
            }
            else
            {
                propertiesView.TranslateTo(0, -propertiesView.Height, 400, Easing.Linear);
                chartTypesGrid.Opacity = 0.5;
            }
		}

        protected override void OnSizeAllocated(double width, double height)
        {
            if (width > 0 && height > 0)
            {
                samplesHeight = height;

                optionsHeight = (float)(0.5 * samplesHeight);
                propertiesView.HeightRequest = optionsHeight;

                if (Device.Idiom != TargetIdiom.Desktop)
                {
                    if (Device.Idiom == TargetIdiom.Tablet)
                    {
                        propertiesHeaderRow.Height = 0.13 * optionsHeight;
                        propertiesContentRow.Height = 0.87 * optionsHeight;
                    }
                    else if (Device.Idiom == TargetIdiom.Phone)
                    {
                        propertiesHeaderRow.Height = 0.23 * optionsHeight;
                        propertiesContentRow.Height = 0.77 * optionsHeight;
                    }

                    titleCol.Width = 1 * width;
                    closeButtonCol.Width = 0 * width;
                }
            }
            base.OnSizeAllocated(width, height);
        }


        internal void ClosePropertiesView()
        {
            if (Device.RuntimePlatform == Device.UWP)
            {
                if (absoluteLay.Children.Contains(propertiesView))
                    absoluteLay.Children.Remove(propertiesView);
                if(Device.Idiom == TargetIdiom.Phone)
                    chartTypesGrid.Opacity = 1;
            }
            else
            {
                propertiesView.TranslateTo(0, (propertiesView.Height), 400, Easing.Linear);
                chartTypesGrid.Opacity = 1;
            }
        }

		void SetRowColumn(SampleView view)
		{
			if (Device.RuntimePlatform == Device.UWP)
			{
				Grid.SetRow(view, 1);
				Grid.SetRow(chartTypesListView, 0);
			}
			else
			{
				Grid.SetRow(view, 0);
				Grid.SetRow(chartTypesListView, 1);
			}
		}

		/// <summary>
		/// Used for returning ChartTypesGrid
		/// </summary>
		public Grid ChartTypesGrid
		{
			get
			{
				return chartTypesGrid;
			}
		}

        public void RefreshListView()
        {
            int index = 0;
            if (chartTypesListView.SelectedItem != null)
                index = chartTypesListView.DataSource.DisplayItems.IndexOf(chartTypesListView.SelectedItem);
            chartTypesListView.LayoutManager.ScrollToRowIndex(index, true);
        }

		/// <summary>
		/// Used for returning row in which types list added.
		/// </summary>
		public RowDefinition TypesListRow
		{
			get
			{
				return typesListRow;
			}
		}
	}
}