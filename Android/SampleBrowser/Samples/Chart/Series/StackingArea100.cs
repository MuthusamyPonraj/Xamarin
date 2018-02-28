#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
    public class StackingArea100 : SamplePage
    {

        private SfChart chart;

        public override View GetSampleContent(Context context)
        {
            chart = new SfChart(context); ;
            chart.Title.Text = "Annual Temperature Comparison";
            chart.Title.TextSize = 15;
            chart.SetBackgroundColor(Color.White);
            chart.Legend.Visibility = Visibility.Visible;
            chart.Legend.ToggleSeriesVisibility = true;
            chart.Legend.DockPosition = ChartDock.Bottom;
			chart.Legend.IconHeight = 14;
			chart.Legend.IconWidth = 14;
            chart.ColorModel.ColorPalette = ChartColorPalette.Natural;

            CategoryAxis PrimaryAxis = new CategoryAxis();
            PrimaryAxis.Title.Text = "Year";
            PrimaryAxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
            chart.PrimaryAxis = PrimaryAxis;

            NumericalAxis numericalAxis = new NumericalAxis();
            numericalAxis.Title.Text = "Temperature (%)";
            numericalAxis.Minimum = 0;
            numericalAxis.Maximum = 100;
            numericalAxis.Interval = 10;
            chart.SecondaryAxis = numericalAxis;

            StackingArea100Series stackingArea100Series1 = new StackingArea100Series();
			stackingArea100Series1.EnableAnimation = true;
			stackingArea100Series1.ItemsSource = MainPage.GetStackedArea100Data1();
			stackingArea100Series1.XBindingPath = "XValue";
			stackingArea100Series1.YBindingPath = "YValue";
            stackingArea100Series1.Label = "USA";
            chart.Series.Add(stackingArea100Series1);

            StackingArea100Series stackingArea100Series2 = new StackingArea100Series();
			stackingArea100Series2.EnableAnimation = true;
			stackingArea100Series2.ItemsSource = MainPage.GetStackedArea100Data2();
			stackingArea100Series2.XBindingPath = "XValue";
			stackingArea100Series2.YBindingPath = "YValue";
            stackingArea100Series2.Label = "India";
            chart.Series.Add(stackingArea100Series2);

            StackingArea100Series stackingArea100Series3 = new StackingArea100Series();
			stackingArea100Series3.EnableAnimation = true;
			stackingArea100Series3.ItemsSource = MainPage.GetStackedArea100Data3();
			stackingArea100Series3.XBindingPath = "XValue";
			stackingArea100Series3.YBindingPath = "YValue";
            stackingArea100Series3.Label = "Canada";
            chart.Series.Add(stackingArea100Series3);

            StackingArea100Series stackingArea100Series4 = new StackingArea100Series();
			stackingArea100Series4.EnableAnimation = true;
			stackingArea100Series4.ItemsSource = MainPage.GetStackedArea100Data4();
			stackingArea100Series4.XBindingPath = "XValue";
			stackingArea100Series4.YBindingPath = "YValue";
            stackingArea100Series4.Label = "China";
            chart.Series.Add(stackingArea100Series4);

            stackingArea100Series1.TooltipEnabled = true;
            stackingArea100Series2.TooltipEnabled = true;
            stackingArea100Series3.TooltipEnabled = true;
            stackingArea100Series4.TooltipEnabled = true;
			
            stackingArea100Series1.EnableAnimation = true;
            stackingArea100Series2.EnableAnimation = true;
            stackingArea100Series3.EnableAnimation = true;
            stackingArea100Series4.EnableAnimation = true;

           return chart;
        }
    }
}