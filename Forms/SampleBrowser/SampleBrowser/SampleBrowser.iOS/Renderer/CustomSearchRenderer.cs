#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Foundation;
using SampleBrowser;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SearchBarExt), typeof(CustomSearchRenderer))]

namespace SampleBrowser
{
    public class CustomSearchRenderer:SearchBarRenderer
    {
        public CustomSearchRenderer()
        {
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            Control.Layer.BorderWidth = 0;
            if (Device.Idiom != TargetIdiom.Tablet)
                Control.BarTintColor = UIColor.Clear;
            else
                Control.BarTintColor = UIColor.FromRGB(0, 135, 230);
            Control.SearchBarStyle = UISearchBarStyle.Prominent;
            UIBarButtonItem.AppearanceWhenContainedIn(typeof(UISearchBar)).SetTitleTextAttributes(new UITextAttributes() { TextColor = UIColor.White }, UIControlState.Normal);
            Control.BackgroundImage = new UIImage();
            Control.Placeholder = "Search Controls";
        }
    }
}