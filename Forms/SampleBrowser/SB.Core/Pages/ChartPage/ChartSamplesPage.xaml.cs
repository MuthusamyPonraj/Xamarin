#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace SampleBrowser.Core
{
    /// <summary>
    /// Content page for displaying ChartSamplesPage
    /// </summary>
    public partial class ChartSamplesPage : ContentPage
    {
        #region fields

        private ChartSampleView typesView, featuresView, selectedView;

        private ToolbarItem settingsButton, codeViewerButton;

        private ObservableCollection<SampleModel> chartTypeSamples, chartFeatureSamples;

        private bool isPropertyWindowVisible;

        #endregion

        #region ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="ChartSamplesPage"/> class.
        /// </summary>
        public ChartSamplesPage(object chartSamples, int index)
        {
            InitializeComponent();

            Title = "Chart";

            codeViewerButton = new ToolbarItem()
            {
                Order = ToolbarItemOrder.Primary,
                Priority = 1
            };

            codeViewerButton.Clicked += CodeViewerButton_Clicked;
            if (chartSamples != null)
            {
                chartTypeSamples = new ObservableCollection<SampleModel>();
                chartFeatureSamples = new ObservableCollection<SampleModel>();

                ObservableCollection<SampleModel> samples = chartSamples as ObservableCollection<SampleModel>;

                foreach (var item in samples)
                {
                    if (item.Category == "Types")
                        chartTypeSamples.Add(item);
                    else
                        chartFeatureSamples.Add(item);
                }
            }

            settingsButton = new ToolbarItem
            {
                Order = ToolbarItemOrder.Primary,
                Priority = 0
            };

            if (Device.RuntimePlatform == Device.UWP)
            {
                codeViewerButton.Text = "View Code";
                settingsButton.Text = "Settings";
            }

            int typeViewScrollIndex = 0, featuresViewScrollIndex = 0;
            if (index >= chartTypeSamples.Count)
            {
                IsTypeView = false;
                featuresViewScrollIndex = index - chartTypeSamples.Count;
            }
            else
            {
                IsTypeView = true;
                typeViewScrollIndex = index;
            }

            typesView = new ChartSampleView(chartTypeSamples, settingsButton, this, typeViewScrollIndex);
            featuresView = new ChartSampleView(chartFeatureSamples, settingsButton, this, featuresViewScrollIndex);

            UpdateToobarButtons();
            if (index >= chartTypeSamples.Count)
            {
                UpdateSettingIcon(chartFeatureSamples[featuresViewScrollIndex].Name);
                UpdateFeatureTabBoxView();
                selectedView = featuresView;
                AddView(featuresView, 0, 1);
            }
            else
            {
                UpdateSettingIcon(chartTypeSamples[typeViewScrollIndex].Name);
                UpdateTypeTabBoxView();
                selectedView = typesView;
                AddView(typesView, 0, 1);
            }

            if (Device.RuntimePlatform == Device.UWP)
            {
                settingsButton.Icon = SampleBrowser.IsIndividualSB ? "SampleBrowser.Core.UWP/Option.png" : "Option.png";
                codeViewerButton.Icon = SampleBrowser.IsIndividualSB ? "SampleBrowser.Core.UWP/viewcode.png" : "viewcode.png";
            }
            else
            {
                codeViewerButton.Icon = "viewcode.png";
                settingsButton.Icon = "Option.png";
            }
        }

        #endregion

        #region properties

        internal bool IsPropertyWindowVisible
        {
            get { return isPropertyWindowVisible; }

            set
            {
                isPropertyWindowVisible = value;
                OnPropertyWindowChanged();
            }
        }

        internal bool IsTypeView { get; set; }

        #endregion

        #region methods

        protected override void OnDisappearing()
        {
            typesView.OnDisappearing();
            base.OnDisappearing();
        }

        protected override void OnAppearing()
        {
            typesView.OnAppearing();
            base.OnAppearing();
        }

        private void OnPropertyWindowChanged()
        {
            if (IsPropertyWindowVisible)
            {
                if (!ToolbarItems.Contains(settingsButton))
                    ToolbarItems.Add(settingsButton);
            }
            else
                ToolbarItems.Remove(settingsButton);
        }

        private void CodeViewerButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CodeViewerPage("SfChart", selectedView.SelectedSample, selectedView.SelectedSample));
        }

        private void TypesButton_Clicked(object sender, EventArgs e)
        {
            if (typesBorderBox.Height == 5) return;

            IsTypeView = true;
            UpdateToobarButtons();
            UpdateTypeTabBoxView();
            UpdateSettingIcon(null);
            selectedView = typesView;

            RemoveView(featuresView);
            AddView(typesView, 0, 1);
        }

        private void FeaturesButton_Clicked(object sender, EventArgs e)
        {
            if (featuresBorderBox.Height == 5) return;

            IsTypeView = false;
            typesView.OnDisappearing();
            UpdateToobarButtons();
            UpdateFeatureTabBoxView();
            UpdateSettingIcon(null);
            selectedView = featuresView;

            RemoveView(typesView);
            AddView(featuresView, 0, 1);
        }

        private void UpdateSettingIcon(string sample)
        {
            var sampleName = string.IsNullOrEmpty(sample) ? IsTypeView ? typesView.SelectedSample : featuresView.SelectedSample : sample;
            var type = DependencyService.Get<ISampleBrowserService>().GetAssembliesType("SampleBrowser.SfChart", sampleName);
            var instance = AllControlsSamplePage.CreateInstance(type);

            if (instance.PropertyView != null)
            {
                IsPropertyWindowVisible = true;
                settingsButton.Icon = "Option.png";
            }
            else
            {
                IsPropertyWindowVisible = false;
                settingsButton.Icon = string.Empty;
            }
        }

        private void UpdateToobarButtons()
        {
            if (!ToolbarItems.Contains(codeViewerButton))
                ToolbarItems.Add(codeViewerButton);

            if (!ToolbarItems.Contains(settingsButton))
                ToolbarItems.Add(settingsButton);

            UpdateTypeTabBoxView();
        }

        private void UpdateTypeTabBoxView()
        {
            typesBorderBox.HeightRequest = 5;
            featuresBorderBox.HeightRequest = 0;
            typesButton.HeightRequest = typesButtonStack.HeightRequest - typesBorderBox.HeightRequest;
            featuresButton.HeightRequest = featuresButtonStack.HeightRequest;
        }

        private void UpdateFeatureTabBoxView()
        {
            typesBorderBox.HeightRequest = 0;
            featuresBorderBox.HeightRequest = 5;
            featuresButton.HeightRequest = featuresButtonStack.HeightRequest - featuresBorderBox.HeightRequest;
            typesButton.HeightRequest = typesButtonStack.HeightRequest;
        }

        private void AddView(SampleView view, int column, int row)
        {
            if (view != null)
            {
                tabbedGrid.Children.Add(view, column, row);
                Grid.SetColumnSpan(view, 3);
            }
        }

        private void RemoveView(SampleView view)
        {
            if (view != null)
                tabbedGrid.Children.Remove(view);
        }

        #endregion
    }

    /// <summary>
    /// Extension of <see cref="Button"/>.
    /// </summary>
    public class ButtonExt : Button
    {
    }
}