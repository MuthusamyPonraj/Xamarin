#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

using Xamarin.Forms;
using Syncfusion.SfDataGrid.XForms.iOS;
using Syncfusion.SfSchedule.XForms.iOS;
using Syncfusion.SfChart.XForms.iOS.Renderers;

namespace PatientMonitor.iOS
{
    [Register ("AppDelegate")]
    public partial class AppDelegate : 
    global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate // superclass new in 1.3
    {
        public override bool FinishedLaunching (UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init ();
            SfDataGridRenderer.Init();
            new SfScheduleRenderer (); 
            new SfChartRenderer ();
            LoadApplication (new PatientMonitor.App ());  // method is new in 1.3

            return base.FinishedLaunching (app, options);
        }
    }
}
