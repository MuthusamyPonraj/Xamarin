#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Charts;
using Android.Graphics;

namespace SampleBrowser
{
    class AxisCrossing: SamplePage
    {
        public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context);

            chart.SetBackgroundColor(Color.White);
            chart.Title.Text = "Profit/loss percentage comparison";

            CategoryAxis primaryAxis = new CategoryAxis();
            primaryAxis.CrossesAt = 0;
            primaryAxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
            primaryAxis.Interval = 2;
            primaryAxis.Name = "XAxis";
            primaryAxis.CrossingAxisName = "YAxis";
            chart.PrimaryAxis = primaryAxis;

            NumericalAxis secondaryAxis = new NumericalAxis();
            secondaryAxis.Maximum = -100;
            secondaryAxis.Minimum = 100;
            secondaryAxis.Interval = 20;
            secondaryAxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
            secondaryAxis.Name = "YAxis";
            secondaryAxis.CrossingAxisName = "XAxis";
            secondaryAxis.LabelCreated += SecondaryAxis_LabelCreated;
            chart.SecondaryAxis = secondaryAxis;

            BubbleSeries bubbleSeries = new BubbleSeries
            {
                Name = "series1",
                ItemsSource = Data.CrossingData(),
                XBindingPath = "XValue",
                YBindingPath = "YValue",
                Size = "Size",
                Alpha = 0.5f,
                TooltipEnabled = true,
            };
            bubbleSeries.ColorModel.ColorPalette = ChartColorPalette.Pineapple;
            ChartZoomPanBehavior zoomPanBehavior = new ChartZoomPanBehavior();
            chart.Behaviors.Add(zoomPanBehavior);
            chart.Series.Add(bubbleSeries);
            chart.SecondaryAxis.CrossesAt = 8;

            return chart;

        }
         void SecondaryAxis_LabelCreated(object sender, ChartAxis.LabelCreatedEventArgs e)
        {
            e.AxisLabel.LabelContent = e.AxisLabel.LabelContent + "%";
        }

    }
}