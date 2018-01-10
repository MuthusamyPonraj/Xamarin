#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.Content.Res;

namespace SampleBrowser.Core.Droid
{
    public static class CoreSampleBrowser
    {
        public static void Init(Resources resources, object application)
        {
            double statusBarHeight, navbarheight, width, height;

            if (resources != null)
            {
                int navigationResID = resources.GetIdentifier("navigation_bar_height", "dimen", "android");
                if (navigationResID > 0)
                    navbarheight = (resources.GetDimensionPixelSize(navigationResID) / resources.DisplayMetrics.Density);
                else
                    navbarheight = 0;

                int statusResID = resources.GetIdentifier("status_bar_height", "dimen", "android");
                if (statusResID > 0)
                    statusBarHeight = (resources.GetDimensionPixelSize(statusResID) / resources.DisplayMetrics.Density);
                else
                    statusBarHeight = 0;

                width = resources.DisplayMetrics.WidthPixels / resources.DisplayMetrics.Density;
                height = resources.DisplayMetrics.HeightPixels / resources.DisplayMetrics.Density;

                Core.SampleBrowser.StatusBarHeight = statusBarHeight;
                Core.SampleBrowser.NavigationBarHeight = navbarheight;
                Core.SampleBrowser.ScreenWidth = width;
                Core.SampleBrowser.ScreenHeight = height - (statusBarHeight + navbarheight);
                Core.SampleBrowser.Density = resources.DisplayMetrics.Density;
            }
        }
    }
}
