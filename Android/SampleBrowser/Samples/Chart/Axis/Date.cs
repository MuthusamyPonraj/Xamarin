#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.Content;
using Android.OS;
using Android.App;
using Com.Syncfusion.Charts;
using Com.Syncfusion.Charts.Enums;
using Android.Graphics;
using Android.Views;

namespace SampleBrowser
{
    public class Date : SamplePage
    {
       public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context); ;
            chart.SetBackgroundColor(Color.White);
            chart.Title.Text = "Average Sales Comparison";
            chart.Title.TextSize = 15;

            DateTimeAxis dateTimeAxis = new DateTimeAxis();
            dateTimeAxis.Title.Text = "Sales Across Years";
            dateTimeAxis.LabelRotationAngle  =-45;
            dateTimeAxis.LabelStyle.LabelFormat = "MM/yyyy";
            dateTimeAxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
            chart.PrimaryAxis = dateTimeAxis;

            var numericalAxis = new NumericalAxis();
            numericalAxis.Title.Text = "Sales Amount in millions (USD)";
            numericalAxis.Minimum = 0;
            numericalAxis.Maximum = 100;
            numericalAxis.Interval = 10;
            numericalAxis.LabelStyle.LabelFormat = "$##.##";
            chart.SecondaryAxis = numericalAxis;

            LineSeries lineSeries = new LineSeries();
			lineSeries.ItemsSource = Data.GetDateTimeValue();
			lineSeries.XBindingPath = "XValue";
			lineSeries.YBindingPath = "YValue";
            lineSeries.TooltipEnabled = true;
            chart.Series.Add(lineSeries);
            return chart;
        }
    }
}