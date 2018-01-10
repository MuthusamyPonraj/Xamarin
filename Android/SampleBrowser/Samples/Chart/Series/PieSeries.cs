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
    public class Pie : SamplePage
    {
        public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context);
            chart.Title.Text = "Expenditures";
            chart.Title.TextSize = 15;
            chart.SetBackgroundColor(Color.White);
            chart.Legend.Visibility = Visibility.Visible;

            PieSeries pieSeries = new PieSeries();
            pieSeries.DataMarker.LabelContent = LabelContent.Percentage;
			pieSeries.ItemsSource = MainPage.GetPieData();
			pieSeries.XBindingPath = "XValue";
			pieSeries.YBindingPath = "YValue";
            pieSeries.LegendIcon = ChartLegendIcon.Rectangle;
            pieSeries.DataMarkerPosition = CircularSeriesDataMarkerPosition.OutsideExtended;
            pieSeries.StartAngle = 55;
            pieSeries.SmartLabelsEnabled = true;
            pieSeries.EndAngle = 415;
            pieSeries.DataMarker.ShowLabel = true;
            pieSeries.ConnectorType = ConnectorType.Bezier;
            pieSeries.EnableAnimation = true;
            pieSeries.CircularCoefficient = 0.65f;
            pieSeries.StrokeWidth = 1;
            pieSeries.StrokeColor = Color.White;
            chart.Series.Add(pieSeries);
            return chart;
        }
    }
}