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

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Charts;
using Android.Graphics;
using Com.Syncfusion.Charts.Enums;

namespace SampleBrowser
{
    internal class Scatter : SamplePage
    {
        public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context); ;
            chart.Title.Text = "World Countries Details";
            chart.Title.TextSize = 15;
            chart.SetBackgroundColor(Color.White);

            chart.PrimaryAxis = new NumericalAxis();
            chart.PrimaryAxis.ShowMajorGridLines = false;
            chart.PrimaryAxis.Title.Text = "Literacy Rate";

            chart.SecondaryAxis = new NumericalAxis();
            chart.SecondaryAxis.ShowMajorGridLines = false;
            chart.SecondaryAxis.Title.Text = "GDP Growth Rate";

            ScatterSeries scatter = new ScatterSeries();
            scatter.Alpha = 0.7f;
			scatter.ItemsSource = MainPage.GetScatterData();
			scatter.XBindingPath = "XValue";
			scatter.YBindingPath = "YValue";
            scatter.EnableAnimation = true;
            chart.Series.Add(scatter);
            return chart;
        }
    }
}