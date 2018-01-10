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
using System.Reflection;
using System.Text;
using Syncfusion.ListView.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.Core
{
	/// <summary>
    /// ContentPage for displaying all samples of Control.
    /// </summary>
    public partial class AllControlsSamplePage : ContentPage
	{
        Type previousSample;
		double samplesHeight, listViewHeight, optionsHeight;
		bool hasOneSample;
		int scrollToIndex;
		string sampleName,contName,currentSampleName;
        ToolbarItem settingsButton;
        ObservableCollection<SamplesModel> Samples { get; set; }
        public ContentView PropertiesView 
        {
            get
            {
                return propertiesView;
            }
        }
        SfListView List { get { return horizontalSampleListView; } }
        View content;

		public AllControlsSamplePage(bool showLoadingIndicator)
		{
			InitializeComponent();

            SwapContent(showLoadingIndicator);
		}

		public AllControlsSamplePage(object control, object sample, string controlName, int index)
		{
			InitializeComponent();

			SwapContent(false);

			LoadSample(control, sample, controlName, index);
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

        public void LoadSample(object control,object sample,string controlName,int index)
		{
            if (Device.Idiom == TargetIdiom.Desktop)
            {
                propertiesHeaderRow.Height = new GridLength(1, GridUnitType.Star);
                propertiesContentRow.Height = new GridLength(9, GridUnitType.Star);
                titleCol.Width = new GridLength(10, GridUnitType.Star);
                closeButtonCol.Width = new GridLength(0, GridUnitType.Star);
            }

            scrollToIndex = index;
            settingsButton = new ToolbarItem
            {
                StyleId = "OptionsButton",
                Order = ToolbarItemOrder.Primary,
                Priority = 0,
            };

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

			if (sample != null)
			{
                if (sample is ObservableCollection<SamplesModel>)
				{
                    Samples = sample as ObservableCollection<SamplesModel>;
                    var controlDetails = (control as ControlModel);
                    var samples = sample as ObservableCollection<SamplesModel>;
                    var defaltSample = samples[0].Name;
                    Type sampleType = null;
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
                        currentSampleName = samples[0].Name;
                        Title = samples[0].Title;
                        previousSample = sampleType;
                        var instance = CreateInstance(sampleType);
                        SetRowColumn(instance);
                        if (instance.PropertyView != null)
                        {
                            if (!ToolbarItems.Contains(settingsButton))
                                ToolbarItems.Add(settingsButton);
                            if (Device.RuntimePlatform != Device.UWP)
                                absoluteLay.Children.Add(propertiesView);
                            propertiesContent.Content = instance.PropertyView;
                        }
                        else
                        {
                            if (ToolbarItems.Contains(settingsButton))
                                ToolbarItems.Remove(settingsButton);
                            absoluteLay.Children.Remove(propertiesView);
                        }
                        samplesGrid.Children.Add(instance);
                        
                        var samplesCount = samples.Count;
                        if (samplesCount <= 1)
                        {
                            hasOneSample = true;
                            samplesGrid.Children.Remove(horizontalSampleListView);
                        }
                        else
                        {
                            horizontalSampleListView.ItemsSource = Samples;
                            horizontalSampleListView.SelectedItem = Samples[0];
                        }
                    }
                }
				else if (sample is SamplesModel)
				{
                    if (control != null)
						horizontalSampleListView.ItemsSource = control;
                    horizontalSampleListView.SelectedItem = sample;
                    if (sample != null)
					{
						var sampleDetails = (sample as SamplesModel);
						sampleName = sampleDetails.Name;
						if (controlName != null)
							contName = controlName;
                        Type sampleType= DependencyService.Get<ISampleBrowserService>().GetAssembliesType("SampleBrowser." + controlName, sampleName);

                        if (sampleType != null)
                        {
                            currentSampleName = sampleDetails.Name;
                            Title = sampleDetails.Title;
							previousSample = sampleType;

                            var instance = CreateInstance(sampleType);
							SetRowColumn(instance);
							samplesGrid.Children.Add(instance);
                            if (instance.PropertyView != null)
                            {
                                if (!ToolbarItems.Contains(settingsButton))
                                    ToolbarItems.Add(settingsButton);
                                propertiesContent.Content = instance.PropertyView;
                                if (Device.RuntimePlatform != Device.UWP)
                                    absoluteLay.Children.Add(propertiesView);
                            }
                            else
                            {
                                if (ToolbarItems.Contains(settingsButton))
                                    ToolbarItems.Remove(settingsButton);
                                absoluteLay.Children.Remove(propertiesView);
                            }
						}
					}
				}
			}

			if (horizontalSampleListView != null)
			{
				horizontalSampleListView.ItemTapped += HorizontalSampleListView_ItemTapped;
			}

			if (Device.RuntimePlatform == "Android")
				Content = content;
		}

        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            Device.BeginInvokeOnMainThread(async () =>
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

        void CodeViewerButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CodeviewerPage(contName, currentSampleName, Title));
        }

        /// <summary>
        /// Event hooked when ListView Item Tapped.
        /// </summary>
        public void HorizontalSampleListView_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            if (horizontalSampleListView != null)
            {
                var index = horizontalSampleListView.DataSource.DisplayItems.IndexOf(e.ItemData);
                horizontalSampleListView.LayoutManager.ScrollToRowIndex(index - 1, true);
            }

            if (e.ItemData != null)
            {
                var currentSample = (e.ItemData as SamplesModel);
				if (previousSample.Name != currentSample.Name)
				{
					if (samplesGrid != null)
					{
						foreach (var child in samplesGrid.Children.Reverse())
						{
							var childTypeName = child.GetType().Name;
							if (childTypeName == previousSample.Name)
							{
                                (child as SampleView).OnDisappearing();
								samplesGrid.Children.Remove(child);
                                var view = child as SampleView;
							    if (view != null)
							        view.OnDisappearing();
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
                                absoluteLay.Children.Add(propertiesView);
                            propertiesContent.Content = instance.PropertyView;
                        }
                        else
						{
                            if (ToolbarItems.Contains(settingsButton))
                                ToolbarItems.Remove(settingsButton);
                            absoluteLay.Children.Remove(propertiesView);

                        }

                        SetRowColumn(instance);
                        samplesGrid.Children.Add(instance);
                        (instance as SampleView).OnAppearing();
					}
                    currentSampleName = currentSample.Name;
                    Title = currentSample.Title;
				}
            }
        }

        void HorizontalSampleListView_Loaded(object sender, ListViewLoadedEventArgs e)
		{
			horizontalSampleListView.LayoutManager.ScrollToRowIndex(scrollToIndex - 1, true);
		}

        bool isSettingsOpen;

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
        public void PropertiesClosebutton_Clicked(object sender, EventArgs e)
		{
			ClosePropertiesView();
            isSettingsOpen = false;
        }

        /// <summary>
        /// Method Called when properties view is opened.
        /// </summary>
        public void OpenPropertiesView()
        {
            stackLayout.BackgroundColor = Color.FromHex("007DE6");
            closeButton.BackgroundColor = Color.FromHex("007DE6");

            if (Device.RuntimePlatform == Device.UWP)
            {
                if (Device.Idiom == TargetIdiom.Desktop)
                    AbsoluteLayout.SetLayoutBounds(propertiesView, new Rectangle(1, 0, 0.275, 1));
                else if (Device.Idiom == TargetIdiom.Phone)
                {
                    AbsoluteLayout.SetLayoutBounds(propertiesView, new Rectangle(1, 1, 1, 0.5));
                    samplesGrid.Opacity = 0.5;
                }
                if (!absoluteLay.Children.Contains(propertiesView))
                    absoluteLay.Children.Add(propertiesView);
            }
            else
            {
                propertiesView.TranslateTo(0, -propertiesView.Height, 400, Easing.Linear);
                samplesGrid.Opacity = 0.5;
            }
        }

        /// <summary>
        /// Method Called when properties view is closed.
        /// </summary>
        public void ClosePropertiesView()
        {
            if (Device.RuntimePlatform == Device.UWP)
            {
                if (absoluteLay.Children.Contains(propertiesView))
                    absoluteLay.Children.Remove(propertiesView);
                if (Device.Idiom == TargetIdiom.Phone)
                    samplesGrid.Opacity = 1;
            }
            else
            {
                propertiesView.TranslateTo(0, (propertiesView.Height), 400, Easing.Linear);
                samplesGrid.Opacity = 1;
            }
        }

        void SetRowColumn(SampleView view)
        {
			if (view != null && horizontalSampleListView != null)
			{
				if (Device.RuntimePlatform == Device.UWP)
				{
					Grid.SetRow(view, 1);
					Grid.SetRow(horizontalSampleListView, 0);
				}
				else
				{
					Grid.SetRow(view, 0);
					Grid.SetRow(horizontalSampleListView, 1);
				}
            }
        }

		/// <summary>
		/// Method for calculating Screen Height and Width.
		/// </summary>
		protected override void OnSizeAllocated(double width, double height)
		{
			if (width > 0 && height > 0)
			{
                samplesHeight = height;

                if (Device.RuntimePlatform == Device.UWP)
                {
                    if (!hasOneSample)
                    {
                        if (Device.Idiom == TargetIdiom.Desktop)
                        {
                            listViewHeight = 0.92 * height;
                            horizontalSampleListView.ItemSize = 200;
                        }
                        else
                        {
                            listViewHeight = 0.93 * height;
                        }
                        horizontalSampleListView.BackgroundColor = Color.FromHex("#343435");
                        
                    }
                    else
                        listViewHeight = height;
                }
                else
                {
                    if (!hasOneSample)
                    {
                        if (Device.Idiom == TargetIdiom.Tablet)
                            listViewHeight = (float)(0.06 * height);
                        else
                            listViewHeight = (float)(0.1 * samplesHeight);
                    }
                    else
                        listViewHeight = 0;
                }
                horListViewRow.Height = listViewHeight;
				samplesRow.Height = height - listViewHeight;

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

        /// <summary>
        /// Triggered when loading a sample.
        /// </summary>
        public static event EventHandler<SampleLoadedEventArgs> SampleLoaded;

        /// <summary>
        /// Event argument for sample loaded event.
        /// </summary>
        public class SampleLoadedEventArgs : EventArgs
		{
            /// <summary>
            /// Get or Set SampleName.
            /// </summary>
            public string SampleName { get; set; }

            /// <summary>
            /// Event hooked when Samples Loaded in HockeyApp Integration.
            /// </summary>
            public SampleLoadedEventArgs(string sampleName)
			{
				SampleName = sampleName;
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

        protected override void OnDisappearing()
        {
            foreach (var child in samplesGrid.Children.Reverse())
            {
                if (child is SampleView)
                    (child as SampleView).OnDisappearing();
            }
            base.OnDisappearing();
        }

        protected override void OnAppearing()
        {
            foreach (var samples in samplesGrid.Children)
            {
                if (samples is SampleView)
                    (samples as SampleView).OnAppearing();
            }
            base.OnAppearing();
        }
    }
}