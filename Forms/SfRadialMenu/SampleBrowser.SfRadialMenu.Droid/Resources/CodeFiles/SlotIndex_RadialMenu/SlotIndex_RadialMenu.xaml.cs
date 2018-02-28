#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using SampleBrowser.Core;
using System.Globalization;

namespace SampleBrowser.SfRadialMenu
{
	public partial class SlotIndex_RadialMenu : SampleView
	{
		double height, width;
		public SlotIndex_RadialMenu()
		{
			InitializeComponent();

            if (Device.OS == TargetPlatform.Android)
            {
                height = Core.SampleBrowser.ScreenHeight / 5.1;
                width = Core.SampleBrowser.ScreenWidth / 2 - radial_Menu.CenterButtonRadius * 1.5;
            }
            else if (Device.OS == TargetPlatform.iOS)
            {
                height = Core.SampleBrowser.ScreenHeight / 6 + radial_Menu.CenterButtonRadius;
                width = Core.SampleBrowser.ScreenWidth / 2 - radial_Menu.CenterButtonRadius * 2;
            }
            //else if (Device.OS == TargetPlatform.Windows)
            //{
            //    height = App.ScreenHeight / 5.1;
            //    width = App.ScreenWidth / 2 - radial_Menu.CenterButtonRadius * 1.5;
            //    facebook.Margin = new Thickness(0, 3, 0, 0);
            //    twitter.Margin = new Thickness(0, 3, 0, 0);
            //    google.Margin = new Thickness(0, 3, 0, 0);
            //    if (Device.Idiom == TargetIdiom.Phone)
            //    {
            //        radial_Menu.RimRadius = 130.0;
            //    }
            //}
            
            TapGestureRecognizer facebook_Tap = new TapGestureRecognizer();
			facebook_Tap.Tapped += async (object sender, EventArgs e) =>
			{
				radial_Menu.Close();
				var alertResult = await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Alert", "Are you sure you want to share this page in your Facebook account?", null, "OK");

			};
			facebook.GestureRecognizers.Add(facebook_Tap);
            TapGestureRecognizer google_Tap = new TapGestureRecognizer();
			google_Tap.Tapped += async (object sender, EventArgs e) =>
			{
				radial_Menu.Close();
				var alertResult = await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Alert", "Are you sure you want to share this page in your Google Plus account?", null, "OK");

			};
			google.GestureRecognizers.Add(google_Tap);

			TapGestureRecognizer twitter_Tap = new TapGestureRecognizer();
			twitter_Tap.Tapped += async (object sender, EventArgs e) =>
			{
				radial_Menu.Close();
				var alertResult = await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Alert", "Are you sure you want to share this page in your Twitter account?", null, "OK");

			};
			twitter.GestureRecognizers.Add(twitter_Tap);

			TapGestureRecognizer linkedIn_Tap = new TapGestureRecognizer();
			linkedIn_Tap.Tapped += async (object sender, EventArgs e) =>
			{
				radial_Menu.Close();
				var alertResult = await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Alert", "Are you sure you want to share this page in your LinkedIn account?", null, "OK");

			};
			linkedIn.GestureRecognizers.Add(linkedIn_Tap);
            this.SizeChanged += SlotIndex_RadialMenu_SizeChanged;
		}

        private void SlotIndex_RadialMenu_SizeChanged(object sender, EventArgs e)
        {
            if (Device.OS == TargetPlatform.Windows)
            {
                height = this.Height / 5.1;
                width = this.Width / 2 - radial_Menu.CenterButtonRadius * 1.5;
                facebook.Margin = new Thickness(0, 3, 0, 0);
                twitter.Margin = new Thickness(0, 3, 0, 0);
                google.Margin = new Thickness(0, 3, 0, 0);
                if (Device.Idiom == TargetIdiom.Phone)
                {
                    radial_Menu.RimRadius = 150.0;
                }
            }
            radial_Menu.Point = new Point(width, height);
        }

        public override void OnDisappearing()
        {
            if (Device.OS == TargetPlatform.Windows)
            {
                radial_Menu.Dispose();
            }
            base.OnDisappearing();
        }
    }
    public class SlotIndexFontConversion : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (Device.OS == TargetPlatform.Android)
            {
                if (parameter != null && parameter is string)
                    return "radialmenu_socialicons.ttf#" + parameter.ToString();
                else
                    return "radialmenu_socialicons.ttf";
            }
            else if (Device.OS == TargetPlatform.iOS)
            {
                
                    return "Social";
               
            }
            else
            {
                if (Core.SampleBrowser.IsIndividualSB)
                {
                    return "radialmenu_socialicons.ttf#Social_Icons";
                }
                else
                {
                    return "SampleBrowser.SfRadialMenu.UWP\\radialmenu_socialicons.ttf#Social_Icons";
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}