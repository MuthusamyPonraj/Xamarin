#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.Util;
using System;
using Android.Views;


namespace SampleBrowser
{
    public class CalendarGettingStarted : SamplePage
    {
        CalendarGettingStarted_Mobile mobile;
        public CalendarGettingStarted()
        {

        }

        public override View GetSampleContent(Android.Content.Context con)
        {
            if (IsTabletDevice(con))
            {
                CalendarGettingStarted_Tab tab = new CalendarGettingStarted_Tab();
                return tab.GetSampleContent(con);
            }
            else
            {
                mobile = new CalendarGettingStarted_Mobile();
                return mobile.GetSampleContent(con);
            }
        }

        public override View GetPropertyWindowLayout(Android.Content.Context context)
        {
            if (IsTabletDevice(context))
            {
                return null;
            }
            else
            {
                return mobile.GetPropertyWindowLayout(context);
            }
        }

        public override void OnApplyChanges()
        {
            base.OnApplyChanges();
            mobile.OnApplyChanges();
        }
        public static bool IsTabletDevice(Android.Content.Context context)
        {
            try
            {
                DisplayMetrics displayMetrics = context.Resources.DisplayMetrics;
                float screenWidth = displayMetrics.WidthPixels / displayMetrics.Xdpi;
                float screenHeight = displayMetrics.HeightPixels / displayMetrics.Ydpi;
                double size = Java.Lang.Math.Sqrt(Math.Pow(screenWidth, 2) + Math.Pow(screenHeight, 2));
                return size >= 6;
            }
            catch
            {
                return false;
            }
        }
    }
}

