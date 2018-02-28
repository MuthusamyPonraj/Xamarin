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
using Syncfusion.ListView.XForms;
using Xamarin.Forms;

namespace SampleBrowser.Core
{
    /// <summary>
    /// ContentPage for displaying all samples of Control.
    /// </summary>
    public partial class AllControlsSamplePage : ContentPage
	{
        #region fields

        private Type previousSample;

		private double samplesHeight, listViewHeight, optionsHeight;

		private bool moreThanOneSample;

		private int scrollToIndex;

		private string sampleName, contName, currentSampleName;

        private ToolbarItem settingsButton;

        private View content;

        private bool isSettingsOpen;

        #endregion

        #region ctor

        public AllControlsSamplePage()
        {

        }

        public AllControlsSamplePage(bool showLoadingIndicator)
        {
            InitializeComponent();

            UpdateCloseIconSize();

            SwapContent(showLoadingIndicator);
        }

        public AllControlsSamplePage(object control, object samples, string controlName, int index)
        {
            InitializeComponent();

            UpdateCloseIconSize();

            SwapContent(false);

            LoadSample(control, samples, controlName, index);
        }

        #endregion

        #region events

        /// <summary>
        /// Triggered when loading a sample.
        /// </summary>
        public static event EventHandler<SampleLoadedEventArgs> SampleLoaded;

        #endregion

        #region properties

        public ContentView PropertiesView 
        {
            get { return propertyView; }
        }

        private SfListView List
        {
            get { return horizontalListView; }
        }

        private ObservableCollection<SampleModel> Samples { get; set; }

        #endregion

        #region methods

        public void LoadSample(object controlModel, object sampleCollection, string controlName, int index)
		{
            scrollToIndex = index;
            settingsButton = new ToolbarItem
            {
                StyleId = "OptionsButton",
                Order = ToolbarItemOrder.Primary,
                Priority = 0
            };

            if (Device.RuntimePlatform == Device.UWP)
                settingsButton.Text = "Settings";

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

            settingsButton.Clicked += OptionsButton_Clicked;

			if (sampleCollection != null)
			{
			    var collection = sampleCollection as ObservableCollection<SampleModel>;
                if (collection != null)
				{
                    Samples = collection;
                    var controlDetails = controlModel as ControlModel;
				    var samples = collection;
                    var defaltSample = samples[index].Name;
                    Type sampleType;
                    if (controlDetails != null)
                    {
                        sampleType = DependencyService.Get<ISampleBrowserService>().GetAssembliesType("SampleBrowser." + controlDetails.Title, defaltSample);
                        contName = controlDetails.Title;
                    }
                    else
                    {
                        sampleType = DependencyService.Get<ISampleBrowserService>().GetAssembliesType("SampleBrowser." + controlName, defaltSample);
                        contName = controlName;
					}

                    sampleName = defaltSample;

                    if (sampleType != null)
                    {
                        currentSampleName = samples[index].Name;
                        Title = samples[index].Title;
                        previousSample = sampleType;

                        var instance = CreateInstance(sampleType);
                        SetRowColumn(instance);

                        if (instance.PropertyView != null)
                        {
                            if (!ToolbarItems.Contains(settingsButton))
                                ToolbarItems.Add(settingsButton);

                            if (Device.RuntimePlatform != Device.UWP)
                                absoluteLayout.Children.Add(propertyView);

                            propertyContent.Content = instance.PropertyView;
                        }
                        else
                        {
                            if (ToolbarItems.Contains(settingsButton))
                                ToolbarItems.Remove(settingsButton);

                            absoluteLayout.Children.Remove(propertyView);
                        }

                        contentGrid.Children.Add(instance);
                        var samplesCount = samples.Count;
                        if (samplesCount <= 1)
                        {
                            moreThanOneSample = true;
                            contentGrid.Children.Remove(horizontalListView);
                        }
                        else
                        {
                            horizontalListView.ItemsSource = Samples;
                            horizontalListView.SelectedItem = Samples[index];
                        }
                    }
                }
				else
                {
                    var samplesModel = sampleCollection as SampleModel;
                    if (samplesModel != null)
                    {
                        if (controlModel != null)
                            horizontalListView.ItemsSource = controlModel;

                        horizontalListView.SelectedItem = sampleCollection;
                        var sampleDetails = samplesModel;
                        sampleName = sampleDetails.Name;

                        if (controlName != null)
                            contName = controlName;

                        var sampleType =
                            DependencyService.Get<ISampleBrowserService>()
                                .GetAssembliesType("SampleBrowser." + controlName, sampleName);
                        if (sampleType != null)
                        {
                            currentSampleName = sampleDetails.Name;
                            Title = sampleDetails.Title;
                            previousSample = sampleType;

                            var instance = CreateInstance(sampleType);
                            SetRowColumn(instance);
                            contentGrid.Children.Add(instance);

                            if (instance.PropertyView != null)
                            {
                                if (!ToolbarItems.Contains(settingsButton))
                                    ToolbarItems.Add(settingsButton);

                                propertyContent.Content = instance.PropertyView;

                                if (Device.RuntimePlatform != Device.UWP)
                                    absoluteLayout.Children.Add(propertyView);
                            }
                            else
                            {
                                if (ToolbarItems.Contains(settingsButton))
                                    ToolbarItems.Remove(settingsButton);

                                absoluteLayout.Children.Remove(propertyView);
                            }
                        }
                    }
                }
			}

			if (horizontalListView != null)
			{
				horizontalListView.ItemTapped += HorizontalSampleListView_ItemTapped;
			}

			if (Device.RuntimePlatform == "Android")
				Content = content;
		}

        private void UpdateCloseIconSize()
        {
            if (Device.RuntimePlatform == Device.UWP && Device.Idiom != TargetIdiom.Phone)
            {
                closeButton.MinimumHeightRequest = 10;
                closeButton.MinimumWidthRequest = 10;
                closeButton.HeightRequest = 40;
                closeButton.WidthRequest = 40;
                closeButton.Margin = new Thickness(0, 0, 5, 0);
            }
        }

        /// <summary>
        /// Event hooked when ListView Item Tapped.
        /// </summary>
        private void HorizontalSampleListView_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            if (horizontalListView != null)
            {
                var index = horizontalListView.DataSource.DisplayItems.IndexOf(e.ItemData);
                horizontalListView.LayoutManager.ScrollToRowIndex(index - 1, true);
            }

            if (e.ItemData != null)
            {
                var currentSample = e.ItemData as SampleModel;
				if (previousSample.Name != currentSample.Name)
				{
					if (contentGrid != null)
					{
						foreach (var child in contentGrid.Children.Reverse())
						{
							var childTypeName = child.GetType().Name;
							if (childTypeName == previousSample.Name)
							{
                                (child as SampleView)?.OnDisappearing();
								contentGrid.Children.Remove(child);
                            }
						}
					}

                    Type type = DependencyService.Get<ISampleBrowserService>().GetAssembliesType("SampleBrowser." + contName, currentSample.Name);
                    if (type != null)
					{
						previousSample = type;
                        var instance = CreateInstance(type);

						if (instance.PropertyView != null)
						{
                            if (!ToolbarItems.Contains(settingsButton))
                                ToolbarItems.Add(settingsButton);

                            isSettingsOpen = false;
                            if (Device.RuntimePlatform != Device.UWP)
                                absoluteLayout.Children.Add(propertyView);

                            propertyContent.Content = instance.PropertyView;
                        }
                        else
						{
                            if (ToolbarItems.Contains(settingsButton))
                                ToolbarItems.Remove(settingsButton);

                            absoluteLayout.Children.Remove(propertyView);
                        }

                        SetRowColumn(instance);
                        contentGrid.Children.Add(instance);
                        instance.OnAppearing();
					}

                    currentSampleName = currentSample.Name;
                    Title = currentSample.Title;
				}
            }
        }

        /// <summary>
        /// Method called when Options Button clicked.
        /// </summary>
        public void OptionsButton_Clicked(object sender, EventArgs e)
        {
            if (isSettingsOpen)
            {
                isSettingsOpen = false;
                ClosePropertiesView();
            }
            else
            {
                OpenPropertiesView();
                isSettingsOpen = true;
            }
        }

        /// <summary>
        /// Method called when Properties Close Button clicked.
        /// </summary>
        public void PropertiesCloseButton_Clicked(object sender, EventArgs e)
        {
            ClosePropertiesView();
            isSettingsOpen = false;
        }

        /// <summary>
        /// Method Called when properties view is opened.
        /// </summary>
        public void OpenPropertiesView()
        {
            if (Device.RuntimePlatform == Device.UWP)
            {
                if (Device.Idiom == TargetIdiom.Desktop)
                    AbsoluteLayout.SetLayoutBounds(propertyView, new Rectangle(1, 0, 0.275, 1));
                else if (Device.Idiom == TargetIdiom.Phone)
                {
                    AbsoluteLayout.SetLayoutBounds(propertyView, new Rectangle(1, 1, 1, 0.5));
                    contentGrid.Opacity = 0.5;
                }

                if (!absoluteLayout.Children.Contains(propertyView))
                    absoluteLayout.Children.Add(propertyView);
            }
            else
            {
                propertyView.TranslateTo(0, -propertyView.Height, 400, Easing.Linear);
                contentGrid.Opacity = 0.5;
            }
        }

        /// <summary>
        /// Method Called when properties view is closed.
        /// </summary>
        private void ClosePropertiesView()
        {
            if (Device.RuntimePlatform == Device.UWP)
            {
                if (absoluteLayout.Children.Contains(propertyView))
                    absoluteLayout.Children.Remove(propertyView);

                if (Device.Idiom == TargetIdiom.Phone)
                    contentGrid.Opacity = 1;
            }
            else
            {
                propertyView.TranslateTo(0, propertyView.Height, 400, Easing.Linear);
                contentGrid.Opacity = 1;
            }
        }

        internal static SampleView CreateInstance(Type sampleType)
        {
            if (sampleType != null)
            {
                SampleLoaded?.Invoke(null, new SampleLoadedEventArgs(sampleType.FullName));

                return Activator.CreateInstance(sampleType) as SampleView;
            }

            return null;
        }

        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            Device.BeginInvokeOnMainThread(() =>
            {
                if (isSettingsOpen)
                {
                    isSettingsOpen = false;
                    ClosePropertiesView();
                    return;
                }
                else
                {
                    this.Navigation.PopAsync();
                }
            });

            return true;
        }

        /// <summary>
        /// Method for calculating Screen Height and Width.
        /// </summary>
        protected override void OnSizeAllocated(double width, double height)
        {
            if (width > 0 && height > 0)
            {
                var isUWPDesktop = Device.RuntimePlatform == Device.UWP && Device.Idiom != TargetIdiom.Phone;
                var boxViewHeight = isUWPDesktop ? 0 : 1;
                samplesHeight = height;

                listViewHeight = isUWPDesktop ? (!moreThanOneSample ? 0.92 * height : height)
                    : (!moreThanOneSample ? Device.Idiom == TargetIdiom.Tablet ? 65f : 55f : 0);

                boxRowDef.Height = boxViewHeight;
                listViewRowDef.Height = listViewHeight;
                sampleRowDef.Height = height - listViewHeight;

                optionsHeight = (float)(0.5 * height);
                propertyView.HeightRequest = optionsHeight;
            }

            base.OnSizeAllocated(width, height);
        }

        protected override void OnAppearing()
        {
            foreach (var child in contentGrid.Children)
            {
                (child as SampleView)?.OnAppearing();
            }

            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            foreach (var child in contentGrid.Children.Reverse())
            {
                (child as SampleView)?.OnDisappearing();
            }

            base.OnDisappearing();
        }

        private void SwapContent(bool showLoadingIndicator)
        {
            if (Device.RuntimePlatform == "Android")
            {
                content = Content;
                if (showLoadingIndicator)
                    Content = new Label { Text = "Loading Sample...", VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };
            }
        }

        private void CodeViewerButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CodeViewerPage(contName, currentSampleName, Title));
        }

        private void HorizontalSampleListView_Loaded(object sender, ListViewLoadedEventArgs e)
		{
			horizontalListView.LayoutManager.ScrollToRowIndex(scrollToIndex - 1, true);
		}

        private void SetRowColumn(SampleView view)
        {
			if (view != null && horizontalListView != null)
			{
				if (Device.RuntimePlatform == Device.UWP && Device.Idiom != TargetIdiom.Phone)
				{
					Grid.SetRow(view, 2);
					Grid.SetRow(horizontalListView, 0);
				}
				else
				{
					Grid.SetRow(view, 0);
					Grid.SetRow(horizontalListView, 2);
				}
            }
        }

        #region SampleLoadedEventArgs

        /// <summary>
        /// Event argument for sample loaded event.
        /// </summary>
        public class SampleLoadedEventArgs : EventArgs
		{
            #region ctor

            /// <summary>
            /// Event hooked when Samples Loaded in HockeyApp Integration.
            /// </summary>
            public SampleLoadedEventArgs(string sampleName)
			{
				SampleName = sampleName;
			}

            #endregion

            #region properties

            /// <summary>
            /// Gets or sets SampleName.
            /// </summary>
            public string SampleName { get; set; }

            #endregion
        }

        #endregion

        #endregion
    }
}