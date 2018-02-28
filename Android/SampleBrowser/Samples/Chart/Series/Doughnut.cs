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
    public class Doughnut : SamplePage
    {
       public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context);;
            chart.Title.Text = "Project Cost Breakdown";
            chart.Title.TextSize = 15;
            chart.SetBackgroundColor(Color.White);
            chart.Legend.Visibility = Visibility.Visible;
			chart.Legend.DockPosition = ChartDock.Bottom;
			chart.Legend.ToggleSeriesVisibility = true;
			chart.Legend.OverflowMode = ChartLegendOverflowMode.Wrap;
			chart.Legend.IconHeight = 14;
			chart.Legend.IconWidth = 14;

            DoughnutSeries doughnutSeries = new DoughnutSeries();
            doughnutSeries.ColorModel.ColorPalette = ChartColorPalette.Natural;
            doughnutSeries.ExplodableOnTouch = true;
            doughnutSeries.DataMarker.LabelContent = LabelContent.Percentage;
			doughnutSeries.ItemsSource = MainPage.GetDoughnutData();
			doughnutSeries.XBindingPath = "XValue";
			doughnutSeries.YBindingPath = "YValue";
            doughnutSeries.DataMarker.ShowLabel = true;
            doughnutSeries.EnableAnimation = true;
            chart.Series.Add(doughnutSeries);
            return chart;
        }
    }
}