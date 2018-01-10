#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SampleBrowser.SfChart
{
	public partial class PieChart : SampleView
	{
		public PieChart()
		{
			InitializeComponent();
			if (!(Device.OS == TargetPlatform.Android || Device.OS == TargetPlatform.iOS))
			{
				Chart.Series[0].AnimationDuration = 2;
                (Chart.Series[0] as PieSeries).StartAngle = 0;
                (Chart.Series[0] as PieSeries).EndAngle = 360;
            }

            if (Device.OS == TargetPlatform.Windows || Device.OS == TargetPlatform.iOS ||
               Device.OS == TargetPlatform.WinPhone)
            {
                DataMarkerLabelStyle style = new DataMarkerLabelStyle();
                style.Margin = new Thickness(3,2,3,2);
                dataMarker.LabelStyle = style;
            }
        }
    }
}
