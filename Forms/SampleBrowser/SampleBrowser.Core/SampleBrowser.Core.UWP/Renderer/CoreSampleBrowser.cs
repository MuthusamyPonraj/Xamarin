#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleBrowser.Core.UWP
{
    public static class CoreSampleBrowser
    {
        public static void Init(object res, object application)
        {
            Core.SampleBrowser.ScreenWidth = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds.Width;
            Core.SampleBrowser.ScreenHeight = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds.Height - ((double)application + 15);

        }
    }
}
