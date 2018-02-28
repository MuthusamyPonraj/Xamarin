#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using SampleBrowser;
using SampleBrowser.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;

[assembly: ExportRenderer(typeof(SearchBarExt), typeof(CustomSearchRenderer))]
namespace SampleBrowser.Droid
{
	public class CustomSearchRenderer : SearchBarRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
		{
			base.OnElementChanged(e);

			int searchPlateId = Control.Context.Resources.GetIdentifier("android:id/search_plate", null, null);
			Control.FindViewById(searchPlateId).Background.SetColorFilter(Android.Graphics.Color.Black, PorterDuff.Mode.Multiply);
		}
	}
}
