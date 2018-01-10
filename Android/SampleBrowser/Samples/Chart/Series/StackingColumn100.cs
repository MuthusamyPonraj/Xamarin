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
    public class StackingColumn100 : SamplePage
    {
        public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context); ;
            chart.Title.Text = "Gross Domestic Product Growth";
            chart.Title.TextSize = 15;
            chart.SetBackgroundColor(Color.White);
            chart.Legend.Visibility = Visibility.Visible;
            chart.Legend.ToggleSeriesVisibility = true;
            chart.Legend.DockPosition = ChartDock.Bottom;

            CategoryAxis PrimaryAxis = new CategoryAxis();
            PrimaryAxis.Title.Text = "Month";
            PrimaryAxis.LabelPlacement = LabelPlacement.BetweenTicks;
            chart.PrimaryAxis = PrimaryAxis;

            NumericalAxis numericalAxis = new NumericalAxis();
            numericalAxis.Title.Text = "GDP (%) Per Annum";
            numericalAxis.Minimum = 0;
            numericalAxis.Maximum = 100;
            numericalAxis.Interval = 10;
            chart.SecondaryAxis = numericalAxis;

            StackingColumn100Series stackingColumn100Series1 = new StackingColumn100Series();
            stackingColumn100Series1.LegendIcon = ChartLegendIcon.Rectangle;
            stackingColumn100Series1.Label = "US";
			stackingColumn100Series1.ItemsSource = MainPage.GetStackedColumnData1();
			stackingColumn100Series1.XBindingPath = "XValue";
			stackingColumn100Series1.YBindingPath = "YValue";

            StackingColumn100Series stackingColumn100Series2 = new StackingColumn100Series();
            stackingColumn100Series2.Label = "India";
            stackingColumn100Series2.LegendIcon = ChartLegendIcon.Rectangle;
            stackingColumn100Series2.ItemsSource = MainPage.GetStackedColumnData2();
            stackingColumn100Series2.XBindingPath = "XValue";
            stackingColumn100Series2.YBindingPath = "YValue";

            StackingColumn100Series stackingColumn100Series3 = new StackingColumn100Series();
            stackingColumn100Series3.LegendIcon = ChartLegendIcon.Rectangle;
            stackingColumn100Series3.Label = "China";
			stackingColumn100Series3.ItemsSource = MainPage.GetStackedColumnData3();
			stackingColumn100Series3.XBindingPath = "XValue";
			stackingColumn100Series3.YBindingPath = "YValue";

            StackingColumn100Series stackingColumn100Series4 = new StackingColumn100Series();
            stackingColumn100Series4.Label = "Canada";
            stackingColumn100Series4.LegendIcon = ChartLegendIcon.Rectangle;
			stackingColumn100Series4.ItemsSource = MainPage.GetStackedColumnData4();
			stackingColumn100Series4.XBindingPath = "XValue";
			stackingColumn100Series4.YBindingPath = "YValue";

            chart.Series.Add(stackingColumn100Series1);
            chart.Series.Add(stackingColumn100Series2);
            chart.Series.Add(stackingColumn100Series3);
            chart.Series.Add(stackingColumn100Series4);

            stackingColumn100Series1.TooltipEnabled = true;
            stackingColumn100Series2.TooltipEnabled = true;
            stackingColumn100Series3.TooltipEnabled = true;
            stackingColumn100Series4.TooltipEnabled = true;
			
            stackingColumn100Series1.EnableAnimation = true;
            stackingColumn100Series2.EnableAnimation = true;
            stackingColumn100Series3.EnableAnimation = true;
            stackingColumn100Series4.EnableAnimation = true;

            return chart;
        }
    }
}
