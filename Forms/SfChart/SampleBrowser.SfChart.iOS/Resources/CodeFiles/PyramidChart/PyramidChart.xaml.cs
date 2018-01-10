#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SampleBrowser.SfChart
{
	public partial class PyramidChart : SampleView
	{
		public PyramidChart()
		{
			InitializeComponent();

            overflowMode.SelectedIndex = 0;
            overflowMode.SelectedIndexChanged += OverflowMode_SelectedIndexChanged;
        }

        private void OverflowMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (overflowMode.SelectedIndex)
            {
                case 0:
                    chart.Legend.OverflowMode = Syncfusion.SfChart.XForms.ChartLegendOverflowMode.Wrap;
                    break;
                case 1:
                    chart.Legend.OverflowMode = Syncfusion.SfChart.XForms.ChartLegendOverflowMode.Scroll;
                    break;
            }
        }
    }
}