#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Com.Syncfusion.Charts;
using Com.Syncfusion.Charts.Enums;

namespace SampleBrowser
{
    public class Category : SamplePage
    {
       public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context);;
            chart.SetBackgroundColor(Color.White);
            chart.Title.Text = "Sales Comparison";
            chart.Title.TextSize = 15;

            CategoryAxis dateTimeAxis = new CategoryAxis();
            dateTimeAxis.Title.Text = "Sales Across Products";
            dateTimeAxis.LabelPlacement = LabelPlacement.BetweenTicks;
            chart.PrimaryAxis = dateTimeAxis;

            var numericalAxis = new NumericalAxis();
            numericalAxis.Title.Text = "Sales Amount in millions (USD)";
            numericalAxis.Minimum = 0;
            numericalAxis.Maximum = 100;
            numericalAxis.Interval = 10;
            numericalAxis.LabelStyle.LabelFormat = "$##.##";
            chart.SecondaryAxis = numericalAxis;

            LineSeries lineSeries = new LineSeries();
			lineSeries.ItemsSource = Data.GetCategoryData();
			lineSeries.XBindingPath = "XValue";
			lineSeries.YBindingPath = "YValue";
            lineSeries.TooltipEnabled = true;
            chart.Series.Add(lineSeries);            

            return chart;
        }
    }
}