#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using CoreGraphics;
using UIKit;

namespace SampleBrowser.Core.iOS
{
    public static class CoreSampleBrowser
    {
        public static void Init(object res, object application)
        {
			double statusBarHeight, navBarHeight;

            CGRect screen = (CGRect)res;
            statusBarHeight = (nfloat)application;

            navBarHeight = new CustomNavigationPageRenderer().NavigationBar.Frame.Height;

            SampleBrowser.StatusBarHeight = statusBarHeight;
            SampleBrowser.NavigationBarHeight = navBarHeight;
            SampleBrowser.ScreenWidth = screen.Width;
            SampleBrowser.ScreenHeight = screen.Height - (statusBarHeight + navBarHeight);
        }
    }
}