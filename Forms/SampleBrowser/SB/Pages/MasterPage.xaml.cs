#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
        #region ctor

        public MasterPage()
		{
			InitializeComponent();

            var actualHeight = Core.SampleBrowser.ScreenHeight;
            var headerHeight = (float)(0.6 * actualHeight);
			grid.HeightRequest = headerHeight;
			listView.HeightRequest = (float)(actualHeight - headerHeight);
            
            NavigationPage.SetHasNavigationBar(this, false);

            stackLayout.BindingContext = viewModel.AppDetails;

			listView.ItemsSource = viewModel.AppLinks;

			listView.ItemTapped += ListView_ItemTapped;

			appLogo.Source = ImageSource.FromFile("synclogo.png");
		}

        #endregion

        #region methods

        private void ListView_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            var linkModel = e.ItemData as NavigationLinkModel;
            if (linkModel != null && linkModel.LinkURL != string.Empty)
            {
                Device.OpenUri(new Uri(linkModel.LinkURL));
            }
        }

        #endregion
    }
}