#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
    public class Spline : SamplePage
    {
        public override View GetSampleContent(Context context)
        {

            var chart = new SfChart(context);
            chart.SetBackgroundColor(Color.White);
            chart.Title.Text = "Climate Graph";
            chart.Title.TextSize = 15;
            chart.SetBackgroundColor(Color.White);
            chart.Legend.DockPosition = ChartDock.Bottom;
			chart.Legend.IconHeight = 14;
			chart.Legend.IconWidth = 14;
            chart.Legend.Visibility = Visibility.Visible;
            chart.Legend.ToggleSeriesVisibility = true;
            chart.ColorModel.ColorPalette = ChartColorPalette.Natural;

            CategoryAxis categoryaxis = new CategoryAxis();
 	        categoryaxis.LabelPlacement = LabelPlacement.BetweenTicks;
            categoryaxis.Title.Text = "Month";
            categoryaxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
            chart.PrimaryAxis = categoryaxis;

            NumericalAxis numericalaxis = new NumericalAxis();
            numericalaxis.Minimum = -5;
            numericalaxis.Maximum = 35;
            numericalaxis.Interval = 5;
			numericalaxis.Title.Text = "Temperature (celsius)";
            chart.SecondaryAxis = numericalaxis;

            SplineSeries splineSeries1 = new SplineSeries();
			splineSeries1.ItemsSource = MainPage.GetSplineData1();
			splineSeries1.XBindingPath = "XValue";
			splineSeries1.YBindingPath = "YValue";
            splineSeries1.Label = "London";
            splineSeries1.DataMarker.ShowMarker = true;
            splineSeries1.TooltipEnabled = true;
            splineSeries1.StrokeWidth = 3;

            SplineSeries splineSeries2 = new SplineSeries();
			splineSeries2.ItemsSource = MainPage.GetSplineData2();
			splineSeries2.XBindingPath = "XValue";
			splineSeries2.YBindingPath = "YValue";
            splineSeries2.Label = "France";
            splineSeries2.DataMarker.ShowMarker = true;
            splineSeries2.TooltipEnabled = true;
            splineSeries2.StrokeWidth = 3;

            splineSeries1.EnableAnimation = true;
            splineSeries2.EnableAnimation = true;
			
            chart.Series.Add(splineSeries1);
            chart.Series.Add(splineSeries2);
            return chart;
        }
    }
}