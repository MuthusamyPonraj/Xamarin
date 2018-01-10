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
     [Activity(Label = "Stacked Columns")]		
    public class StackingColumn : SamplePage
    {
       public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context); ;
            chart.Title.Text = "Most Popular Search Engines";
            chart.SetBackgroundColor(Color.White);
            chart.Legend.Visibility = Visibility.Visible;
            chart.Legend.ToggleSeriesVisibility = true;
            chart.Legend.DockPosition = ChartDock.Bottom;

            CategoryAxis PrimaryAxis = new CategoryAxis();
            PrimaryAxis.Title.Text = "Month";
            PrimaryAxis.LabelPlacement = LabelPlacement.BetweenTicks;
            chart.PrimaryAxis = PrimaryAxis;

            NumericalAxis numericalAxis = new NumericalAxis();
            numericalAxis.Title.Text = "Number of visitors in Millions";
            numericalAxis.Minimum = 0;
            numericalAxis.Maximum = 1800;
            numericalAxis.Interval = 200;
            chart.SecondaryAxis = numericalAxis;

            StackingColumnSeries stackingColumnSeries = new StackingColumnSeries();
            stackingColumnSeries.LegendIcon = ChartLegendIcon.Rectangle;
            stackingColumnSeries.Label = "Google";
			stackingColumnSeries.ItemsSource = MainPage.GetStackedColumnData1();
			stackingColumnSeries.XBindingPath = "XValue";
			stackingColumnSeries.YBindingPath = "YValue";

            StackingColumnSeries stackingColumnSeries1 = new StackingColumnSeries();
            stackingColumnSeries1.Label = "Bing";
            stackingColumnSeries1.LegendIcon =  ChartLegendIcon.Rectangle;
			stackingColumnSeries1.ItemsSource = MainPage.GetStackedColumnData2();
			stackingColumnSeries1.XBindingPath = "XValue";
			stackingColumnSeries1.YBindingPath = "YValue";

            StackingColumnSeries stackingColumnSeries2 = new StackingColumnSeries();
            stackingColumnSeries2.LegendIcon = ChartLegendIcon.Rectangle;
            stackingColumnSeries2.Label = "Yahoo";
			stackingColumnSeries2.ItemsSource = MainPage.GetStackedColumnData3();
			stackingColumnSeries2.XBindingPath = "XValue";
			stackingColumnSeries2.YBindingPath = "YValue";

			StackingColumnSeries stackingColumnSeries3 = new StackingColumnSeries();
            stackingColumnSeries3.Label = "Ask";
            stackingColumnSeries3.LegendIcon = ChartLegendIcon.Rectangle;
			stackingColumnSeries3.ItemsSource = MainPage.GetStackedColumnData4();
			stackingColumnSeries3.XBindingPath = "XValue";
			stackingColumnSeries3.YBindingPath = "YValue";


			chart.Series.Add(stackingColumnSeries);
            chart.Series.Add(stackingColumnSeries1);
            chart.Series.Add(stackingColumnSeries2);
            chart.Series.Add(stackingColumnSeries3);

            stackingColumnSeries.TooltipEnabled = true;
            stackingColumnSeries1.TooltipEnabled = true;
            stackingColumnSeries2.TooltipEnabled = true;
            stackingColumnSeries3.TooltipEnabled = true;
			
            stackingColumnSeries.EnableAnimation = true;
            stackingColumnSeries1.EnableAnimation = true;
            stackingColumnSeries2.EnableAnimation = true;
            stackingColumnSeries3.EnableAnimation = true;

            return chart;
        }
    }
}