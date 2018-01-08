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

    internal class Bubble : SamplePage
    {
       public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context);;
            chart.Title.Text = "World Countries Details";
            chart.Title.TextSize = 15;

            NumericalAxis primaryAxis = new NumericalAxis();
            primaryAxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
            primaryAxis.Minimum = 50;
            primaryAxis.Maximum = 110;
            primaryAxis.Interval = 10;
            primaryAxis.Title.Text = "Literacy Rate";
            chart.PrimaryAxis = primaryAxis;

            NumericalAxis secondaryAxis = new NumericalAxis();
            secondaryAxis.Minimum = -2;
            secondaryAxis.Maximum = 16;
            secondaryAxis.Interval = 2;
            secondaryAxis.Title.Text = "GDP Growth Rate";
            chart.SecondaryAxis = secondaryAxis;

            var bubble = new BubbleSeries();           
            bubble.MinimumRadius = 5;
            bubble.MaximumRadius = 40;
            bubble.Alpha = 0.7f;
            bubble.ColorModel.ColorPalette = ChartColorPalette.Metro;
			bubble.ItemsSource = MainPage.GetBubbleData();
			bubble.XBindingPath = "XValue";
			bubble.YBindingPath = "YValue";
            bubble.EnableAnimation = true;
            chart.Series.Add(bubble);

            bubble.TooltipEnabled = true;
            return chart;
        }
    }
}