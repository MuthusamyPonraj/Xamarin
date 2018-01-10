#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.App;
using Android.Content;
using Android.OS;
using Android.Graphics;
using Com.Syncfusion.Charts;
using Com.Syncfusion.Charts.Enums;
using Android.Views;

namespace SampleBrowser
{
    public class StackingArea : SamplePage
    {
          private SfChart chart;

        public override View GetSampleContent(Context context)
        {
            chart = new SfChart(context); ;
            chart.Title.Text = "Industrial Production Growth";
            chart.Title.TextSize = 15;
            chart.SetBackgroundColor(Color.White);
            chart.Legend.Visibility = Visibility.Visible;
            chart.Legend.ToggleSeriesVisibility = true;
            chart.Legend.DockPosition = ChartDock.Bottom;

            CategoryAxis PrimaryAxis = new CategoryAxis();
            PrimaryAxis.Title.Text = "Year";
            PrimaryAxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
            PrimaryAxis.ShowMajorGridLines = false;
            chart.PrimaryAxis = PrimaryAxis;

            NumericalAxis numericalAxis = new NumericalAxis();
            numericalAxis.Title.Text = "Production (%)";
            numericalAxis.Minimum = 0;
            numericalAxis.Maximum = 30;
            numericalAxis.Interval = 5;
            chart.SecondaryAxis = numericalAxis;

            StackingAreaSeries stackingAreaSeries = new StackingAreaSeries();
			stackingAreaSeries.ItemsSource = MainPage.GetStackedAreaData1();
			stackingAreaSeries.XBindingPath = "XValue";
			stackingAreaSeries.YBindingPath = "YValue";
            stackingAreaSeries.Alpha = 0.5f;
            stackingAreaSeries.LegendIcon = ChartLegendIcon.Rectangle;
            stackingAreaSeries.Label = "US";
            chart.Series.Add(stackingAreaSeries);

            StackingAreaSeries stackingAreaSeries1 = new StackingAreaSeries();
			stackingAreaSeries1.ItemsSource = MainPage.GetStackedAreaData2();
			stackingAreaSeries1.XBindingPath = "XValue";
			stackingAreaSeries1.YBindingPath = "YValue";
            stackingAreaSeries1.Alpha = 0.5f;
            stackingAreaSeries1.Label = "Indonesia";
            stackingAreaSeries1.LegendIcon = ChartLegendIcon.Rectangle;
            chart.Series.Add(stackingAreaSeries1);

            StackingAreaSeries stackingAreaSeries2 = new StackingAreaSeries();
			stackingAreaSeries2.ItemsSource = MainPage.GetStackedAreaData3();
			stackingAreaSeries2.XBindingPath = "XValue";
			stackingAreaSeries2.YBindingPath = "YValue";
            stackingAreaSeries2.LegendIcon = ChartLegendIcon.Rectangle;
            stackingAreaSeries2.Label = "Russia";
            stackingAreaSeries2.Alpha = 0.5f;
            chart.Series.Add(stackingAreaSeries2);

            StackingAreaSeries stackingAreaSeries3 = new StackingAreaSeries();
			stackingAreaSeries3.ItemsSource = MainPage.GetStackedAreaData4();
			stackingAreaSeries3.XBindingPath = "XValue";
			stackingAreaSeries3.YBindingPath = "YValue";
            stackingAreaSeries3.Label = "Bangladesh";
            stackingAreaSeries3.LegendIcon = ChartLegendIcon.Rectangle;
            stackingAreaSeries3.Alpha = 0.5f;
            chart.Series.Add(stackingAreaSeries3);

            stackingAreaSeries.TooltipEnabled = true; 
            stackingAreaSeries1.TooltipEnabled = true;
            stackingAreaSeries2.TooltipEnabled = true;
            stackingAreaSeries3.TooltipEnabled = true;
			
            stackingAreaSeries.EnableAnimation = true; 
            stackingAreaSeries1.EnableAnimation = true;
            stackingAreaSeries2.EnableAnimation = true;
            stackingAreaSeries3.EnableAnimation = true;
			
            return chart;
        }
    }
}