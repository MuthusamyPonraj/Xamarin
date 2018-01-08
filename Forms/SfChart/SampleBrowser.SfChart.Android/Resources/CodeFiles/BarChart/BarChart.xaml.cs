#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;

namespace SampleBrowser.SfChart
{
	public partial class BarChart : SampleView
	{
		public BarChart()
		{
			InitializeComponent();

            if (Device.OS == TargetPlatform.iOS)
            {
                DataMarkerLabelStyle style = new DataMarkerLabelStyle();
                style.Margin = new Thickness(3, 2, 3, 2);
                barSeries1.DataMarker.LabelStyle = style;

		barSeries2.DataMarker.LabelStyle = style;
            }
            
        }
    }
}