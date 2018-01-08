#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Xamarin.Forms;
using Syncfusion.ListView.XForms;
using System.Linq;
using System.Collections.ObjectModel;

namespace SampleBrowser.Core
{
    /// <summary>
    /// Content page for displaying ChartSamplesPage
    /// </summary>
    partial class ChartSamplesPage : ContentPage
    {
        ChartTypesView typesView;
        ChartFeaturesView featuresView;
        ToolbarItem settingsButton, codeViewerButton;
        ObservableCollection<SamplesModel> chartTypes, chartFeatures;

        bool isPropertyWindowVisible;

        internal bool IsPropertyWindowVisible
        {
            get
            {
                return isPropertyWindowVisible;
            }
            set
            {
                isPropertyWindowVisible = value;
                OnPropertyWindowChanged();
            }
        }

        void OnPropertyWindowChanged()
        {
            if (IsPropertyWindowVisible)
            {
                if (!(ToolbarItems.Contains(settingsButton)))
                    ToolbarItems.Add(settingsButton);
            }
            else
                ToolbarItems.Remove(settingsButton);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChartSamplesPage"/> class.
        /// </summary>
        public ChartSamplesPage(object chartSamples)
        {
            InitializeComponent();

            codeViewerButton = new ToolbarItem()
            {
                Order = ToolbarItemOrder.Primary,
                Priority = 0,
            };

            codeViewerButton.Clicked += CodeViewerButton_Clicked;
            if (chartSamples != null)
            {
                chartTypes = new ObservableCollection<SamplesModel>();
                chartFeatures = new ObservableCollection<SamplesModel>();

                ObservableCollection<SamplesModel> samples = chartSamples as ObservableCollection<SamplesModel>;

                foreach (var item in samples)
                {
                    if (item.Category == "Types")
                        chartTypes.Add(item);
                    else
                        chartFeatures.Add(item);
                }
            }

            settingsButton = new ToolbarItem
            {
                Order = ToolbarItemOrder.Primary,
                Priority = 0,
            };

            typesView = new ChartTypesView(chartTypes, settingsButton, this);
            featuresView = new ChartFeaturesView(chartFeatures);

            if (Device.RuntimePlatform == Device.UWP)
            {
                if (Device.Idiom == TargetIdiom.Desktop)
                {
                    typesButCol.Width = new GridLength(2, GridUnitType.Star);
                    featuresButCol.Width = new GridLength(2, GridUnitType.Star);
                    desktopCol.Width = new GridLength(6, GridUnitType.Star);
                }
                else
                {
                    typesButCol.Width = new GridLength(5, GridUnitType.Star);
                    featuresButCol.Width = new GridLength(5, GridUnitType.Star);
                }

                typesButton.Text = "Chart Types";
                featuresButton.Text = "Chart Features";
            }
            Title = "Chart";

            AddView(typesView, 0, 1);

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

            UpdateTypesButton();
        }

        void CodeViewerButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CodeviewerPage("SfChart", typesView.SelectedSample, typesView.SelectedSample));
        }

        void TypesButton_Clicked(object sender, EventArgs e)
        {
            UpdateTypesButton();

            RemoveView(featuresView);

            AddView(typesView, 0, 1);
            typesView.RefreshListView();
        }

        void FeaturesButton_Clicked(object sender, EventArgs e)
        {
            typesView.OnDisappearing();

            UpdateFeaturesButton();

            RemoveView(typesView);

            AddView(featuresView, 0, 1);

        }

        void UpdateTypesButton()
        {
            if (!ToolbarItems.Contains(codeViewerButton))
                ToolbarItems.Add(codeViewerButton);

            if (ToolbarItems.Contains(settingsButton))
                ToolbarItems.Add(settingsButton);
            typesBorderBox.HeightRequest = 5;
            featuresBorderBox.HeightRequest = 0;
            typesButton.HeightRequest = typesButtonStack.HeightRequest - typesBorderBox.HeightRequest;
            featuresButton.HeightRequest = featuresButtonStack.HeightRequest;
        }

        void UpdateFeaturesButton()
        {
            typesView.ClosePropertiesView();

            if (ToolbarItems.Contains(codeViewerButton))
                ToolbarItems.Remove(codeViewerButton);

            if (ToolbarItems.Contains(settingsButton))
                ToolbarItems.Remove(settingsButton);
            typesBorderBox.HeightRequest = 0;
            featuresBorderBox.HeightRequest = 5;
            featuresButton.HeightRequest = featuresButtonStack.HeightRequest - featuresBorderBox.HeightRequest;
            typesButton.HeightRequest = typesButtonStack.HeightRequest;
        }

        void AddView(SampleView view, int column, int row)
        {
            if (view != null)
            {
                tabbedGrid.Children.Add(view, column, row);
                Grid.SetColumnSpan(view, 3);
            }
        }

        void RemoveView(SampleView view)
        {
            if (view != null)
                tabbedGrid.Children.Remove(view);
        }
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
    }
    /// <summary>
    /// Extension of <see cref="Button"/>.
    /// </summary>
    public class ButtonExt : Button
    {

    }
}