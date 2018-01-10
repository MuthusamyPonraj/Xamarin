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

    public class SplineArea : SamplePage
    {
        public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context);
            chart.SetBackgroundColor(Color.White);
            chart.Title.Text = "Inflation Rate";
            chart.Title.TextSize = 15;
            chart.SetBackgroundColor(Color.White);
            chart.Legend.DockPosition = ChartDock.Bottom;
            chart.Legend.Visibility = Visibility.Visible;
            chart.Legend.ToggleSeriesVisibility = true;
            chart.ColorModel.ColorPalette = ChartColorPalette.TomatoSpectrum;

            CategoryAxis categoryaxis = new CategoryAxis();
            categoryaxis.Title.Text = "Year";
            categoryaxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
            chart.PrimaryAxis = categoryaxis;

            NumericalAxis numericalaxis = new NumericalAxis();
            numericalaxis.Minimum = 0;
            numericalaxis.Maximum = 4.5;
            numericalaxis.Interval = 0.5;
            numericalaxis.Title.Text = "Rate (%)";
            chart.SecondaryAxis = numericalaxis;

            var areaSeries1 = new SplineAreaSeries
            {
                Label = "US",
                LegendIcon = ChartLegendIcon.Rectangle,
				Alpha = 0.5f,
				ItemsSource = MainPage.GetSplineAreaData1(),
				XBindingPath = "XValue",
				YBindingPath = "YValue"
            };
            var areaSeries2= new SplineAreaSeries
            {
                Alpha = 0.5f,
                Label = "France",
                LegendIcon = ChartLegendIcon.Rectangle,
				ItemsSource = MainPage.GetSplineAreaData2(),
				XBindingPath = "XValue",
				YBindingPath = "YValue"
            };
            var areaSeries3 = new SplineAreaSeries
            {
                Alpha = 0.5f,
                Label = "Germany",
                LegendIcon = ChartLegendIcon.Rectangle,
				ItemsSource = MainPage.GetSplineAreaData3(),
				XBindingPath = "XValue",
				YBindingPath = "YValue"
            };

            chart.Series.Add(areaSeries1);
            chart.Series.Add(areaSeries2);
            chart.Series.Add(areaSeries3);

            areaSeries1.TooltipEnabled = true;
            areaSeries2.TooltipEnabled = true;
            areaSeries3.TooltipEnabled = true;
			
            areaSeries1.EnableAnimation = true;
            areaSeries2.EnableAnimation = true;
            areaSeries3.EnableAnimation = true;
			
            return chart;
        }
    }
}