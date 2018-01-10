#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Xamarin.Forms;

namespace SampleBrowser
{
	public partial class MasterPage : ContentPage
	{
		public MasterPage()
		{
			InitializeComponent();

            if (Device.RuntimePlatform == Device.UWP)
            {
                borderRow.Height = new GridLength(0.2, GridUnitType.Star);
                appVersRow.Height = new GridLength(0.8, GridUnitType.Star);
                appLogoRow.Height = new GridLength(3, GridUnitType.Star);
                appDescRow.Height = new GridLength(6, GridUnitType.Star);
            }

            var headerHeight = (float)(0.6 * Core.SampleBrowser.ScreenHeight);
			navigationHeader.HeightRequest = headerHeight;
			listView.HeightRequest = (float)(Core.SampleBrowser.ScreenHeight - headerHeight);

            if (Device.RuntimePlatform != Device.UWP)
			{
				appVersRow.Height = 0.07 * headerHeight;
				appDescRow.Height = 0.40 * headerHeight;
				appLogo.Margin = new Thickness(0, 0, 0, 0.03 * Core.SampleBrowser.ScreenHeight);
				appLogoRow.Height = 0.5 * headerHeight;
				borderRow.Height = 5;
			}

            NavigationPage.SetHasNavigationBar(this, false);

			navigationDrawer.BindingContext = viewModel.AppDetails;

			listView.ItemsSource = viewModel.AppLinks;

			listView.ItemTapped += ListView_ItemTapped;

			appLogo.Source = ImageSource.FromFile("synclogo.png");
		}

        void ListView_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            if ((e.ItemData as NavigationLinkModel).LinkURL != String.Empty)
            {
                Device.OpenUri(new Uri((e.ItemData as NavigationLinkModel).LinkURL));
            }
        }
    }
}