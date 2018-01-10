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
    public class Numerical : SamplePage
    {
       public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context); ;
            chart.SetBackgroundColor(Color.White);
            chart.Title.Text = "Average Temperature Analysis";
            chart.Title.TextSize = 15;

            CategoryAxis categoryAxis = new CategoryAxis();
            categoryAxis.Title.Text = "Year";
            categoryAxis.LabelPlacement = LabelPlacement.BetweenTicks;
            chart.PrimaryAxis = categoryAxis;

            var numericalAxis = new NumericalAxis();
            numericalAxis.Title.Text = "Temperature in Celsius";
            numericalAxis.Minimum = 0;
            numericalAxis.Maximum = 100;
            numericalAxis.Interval = 10;
            chart.SecondaryAxis = numericalAxis;

            ColumnSeries columnSeries = new ColumnSeries();
            columnSeries.ColorModel.ColorPalette = ChartColorPalette.Metro;
			columnSeries.ItemsSource = MainPage.GetNumericalData();
			columnSeries.XBindingPath = "XValue";
			columnSeries.YBindingPath = "YValue";
            columnSeries.TooltipEnabled = true;
            chart.Series.Add(columnSeries);
            return chart;
        }
    }
}