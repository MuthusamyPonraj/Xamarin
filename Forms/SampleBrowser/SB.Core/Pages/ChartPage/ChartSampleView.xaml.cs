#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
	public partial class ChartSampleView : SampleView
	{
        #region fields

        private Type previousSample;

        private double samplesHeight = 1, optionsHeight;

        private ToolbarItem settingsButton;

        private ChartSamplesPage chartSamplePage;

        private string selectedSample;

        private bool isSettingsOpen;

        private SampleModel prevSelectedItem;

        #endregion

        #region ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="ChartSampleView"/> class.
        /// </summary>
        public ChartSampleView(object sampleList, ToolbarItem settingsBtn, ChartSamplesPage chartSamplePage, int index)
        {
            InitializeComponent();
            this.chartSamplePage = chartSamplePage;
            if (Device.RuntimePlatform == Device.UWP && Device.Idiom != TargetIdiom.Phone)
            {
                listView.ItemTemplate = new LabelColorSelector();
                closeButton.MinimumHeightRequest = 10;
                closeButton.MinimumWidthRequest = 10;
                closeButton.HeightRequest = 40;
                closeButton.WidthRequest = 40;
                closeButton.Margin = new Thickness(0, 0, 5, 0);
				boxRowDef.Height = 0;
            }
			else
				boxRowDef.Height = 1;

            if (Device.Idiom == TargetIdiom.Phone)
            {
                optionsHeight = (float)(0.5 * samplesHeight);
                propertyView.HeightRequest = optionsHeight;
            }

            settingsButton = settingsBtn;
            if (sampleList != null)
            {
                var samples = sampleList as ObservableCollection<SampleModel>;
                var type = DependencyService.Get<ISampleBrowserService>().GetAssembliesType("SampleBrowser.SfChart", samples[index].Name);

                listView.ItemsSource = samples;
                listView.SelectedItem = samples[index];
                selectedSample = samples[index].Name;
                previousSample = type;

                listView.BackgroundColor = Device.Idiom == TargetIdiom.Desktop ? Color.FromHex("343435") : Color.FromHex("F2F2F2");

                if (type != null)
                {
                    var instance = AllControlsSamplePage.CreateInstance(type);
                    SetRowColumn(instance);
                    chartTypesGrid.Children.Add(instance);
                    if (instance.PropertyView != null)
                    {
                        this.chartSamplePage.IsPropertyWindowVisible = true;
                        settingsButton.Icon = "Option.png";
                        propertyContent.Content = instance.PropertyView;
                        settingsButton.Clicked -= OptionsButton_Clicked;
                        settingsButton.Clicked += OptionsButton_Clicked;
                    }
                    else
                    {
                        this.chartSamplePage.IsPropertyWindowVisible = false;
                        settingsButton.Icon = string.Empty;
                    }
                }
            }

            if (listView != null)
            {
                listView.ItemTapped += ListView_ItemTapped;
            }
        }
        
        #endregion

        #region properties

        /// <summary>
        /// Gets the ChartTypesGrid
        /// </summary>
        public Grid ChartTypesGrid
        {
            get
            {
                return chartTypesGrid;
            }
        }

        /// <summary>
        /// Gets the row in which types list added.
        /// </summary>
        public RowDefinition TypesListRow
        {
            get
            {
                return typesListRow;
            }
        }

        internal string SelectedSample
        {
            get { return selectedSample; }

            set
            {
                selectedSample = value;
            }
        }

        #endregion

        #region methods

        public void RefreshListView()
        {
            int index = 0;
            if (listView.SelectedItem != null)
                index = listView.DataSource.DisplayItems.IndexOf(listView.SelectedItem);
            listView.LayoutManager.ScrollToRowIndex(index, true);
        }

        internal void ClosePropertyView()
        {
            if (Device.RuntimePlatform == Device.UWP)
            {
                if (absoluteLay.Children.Contains(propertyView))
                    absoluteLay.Children.Remove(propertyView);
                if (Device.Idiom == TargetIdiom.Phone)
                    chartTypesGrid.Opacity = 1;
            }
            else
            {
                propertyView.TranslateTo(0, propertyView.Height, 400, Easing.Linear);
                chartTypesGrid.Opacity = 1;
            }
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            if (width > 0 && height > 0)
            {
                samplesHeight = height;

                optionsHeight = (float)(0.5 * samplesHeight);
                propertyView.HeightRequest = optionsHeight;
            }

            base.OnSizeAllocated(width, height);
        }
        
        private void ListView_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
		{
            if (prevSelectedItem != null && prevSelectedItem == e.ItemData) return;

            prevSelectedItem = e.ItemData as SampleModel;

            if (isSettingsOpen)
                ClosePropertyView();

			if (e.ItemData != null)
			{
				var currentSample = e.ItemData as SampleModel;
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
                            settingsButton.Icon = "Option.png";
                            settingsButton.Clicked -= OptionsButton_Clicked;
                            settingsButton.Clicked += OptionsButton_Clicked;
							propertyContent.Content = instance.PropertyView;
                            isSettingsOpen = false;
                        }
						else
                        {
                            this.chartSamplePage.IsPropertyWindowVisible = false;
                            settingsButton.Icon = string.Empty;
						}
					}
				}
			}
		}

        private void OptionsButton_Clicked(object sender, EventArgs e)
		{
            if (isSettingsOpen)
            {
                isSettingsOpen = false;
                ClosePropertyView();
            }
            else
            {
                isSettingsOpen = true;
                OpenPropertyView();
            }
        }

        private void PropertyViewCloseButton_Clicked(object sender, EventArgs e)
		{
            ClosePropertyView();
            isSettingsOpen = false;
        }

        private void OpenPropertyView()
        {
            if (Device.RuntimePlatform == Device.UWP)
            {
                if (Device.Idiom == TargetIdiom.Desktop)
                    AbsoluteLayout.SetLayoutBounds(propertyView, new Rectangle(1, 0, 0.25, 1));
                else if (Device.Idiom == TargetIdiom.Phone)
                {
                    AbsoluteLayout.SetLayoutBounds(propertyView, new Rectangle(1, 1, 1, 0.5));
                    chartTypesGrid.Opacity = 0.5;
                }

                if (!absoluteLay.Children.Contains(propertyView))
                    absoluteLay.Children.Add(propertyView);
            }
            else
            {
                propertyView.TranslateTo(0, -propertyView.Height, 400, Easing.Linear);
                chartTypesGrid.Opacity = 0.5;
            }
		}

        private void SetRowColumn(SampleView view)
		{
			if (Device.RuntimePlatform == Device.UWP && Device.Idiom != TargetIdiom.Phone)
			{
				Grid.SetRow(view, 2);
				Grid.SetRow(listView, 0);
			}
			else
			{
				Grid.SetRow(view, 0);
				Grid.SetRow(listView, 2);
			}
		}

        #endregion
    }
}