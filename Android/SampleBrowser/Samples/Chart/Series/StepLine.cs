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
using Com.Syncfusion.Charts.Enums;
using Android.Graphics;

namespace SampleBrowser
{
    public class StepLine : SamplePage
    {
        SfChart chart;
        public override View GetSampleContent(Context context)
        {
            chart = new SfChart(context);
            chart.Title.Text = "CO-2 Intensity Analysis";
            chart.Title.TextSize = 15;
            chart.SetBackgroundColor(Color.White);

            chart.Legend.Visibility = Visibility.Visible;
            chart.Legend.DockPosition = ChartDock.Bottom;
            chart.Legend.ToggleSeriesVisibility = true;

            NumericalAxis categoryaxis = new NumericalAxis();
            categoryaxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
            categoryaxis.Minimum = 2005;
            categoryaxis.Maximum = 2012;
            categoryaxis.Interval = 1;
            categoryaxis.Title.Text = "Year";
            chart.PrimaryAxis = categoryaxis;

            NumericalAxis numericalaxis = new NumericalAxis();
            numericalaxis.Minimum = 390;
            numericalaxis.Maximum = 600;
            numericalaxis.Interval = 30;
            numericalaxis.Title.Text = "Intensity (g/KWh)";
            chart.SecondaryAxis = numericalaxis;

            StepLineSeries stepLineSeries1 = new StepLineSeries();
			stepLineSeries1.ItemsSource = MainPage.GetStepLineData1();
			stepLineSeries1.XBindingPath = "XValue";
			stepLineSeries1.YBindingPath = "YValue";
            stepLineSeries1.Label = "US";
            stepLineSeries1.DataMarker.ShowMarker = true;
            stepLineSeries1.DataMarker.MarkerColor = Color.ParseColor("#FEBE17");
            stepLineSeries1.DataMarker.MarkerStrokeColor = Color.ParseColor("#FEBE17");
            stepLineSeries1.LegendIcon = ChartLegendIcon.Rectangle;
            stepLineSeries1.StrokeWidth = 3;
            stepLineSeries1.TooltipEnabled = true;

            StepLineSeries stepLineSeries2 = new StepLineSeries();
			stepLineSeries2.ItemsSource = MainPage.GetStepLineData2();
			stepLineSeries2.XBindingPath = "XValue";
			stepLineSeries2.YBindingPath = "YValue";
            stepLineSeries2.Label = "Korea";
            stepLineSeries2.DataMarker.ShowMarker = true;
            stepLineSeries2.DataMarker.MarkerColor = Color.ParseColor("#4F4838");
            stepLineSeries2.DataMarker.MarkerStrokeColor = Color.ParseColor("#4F4838");
            stepLineSeries2.LegendIcon = ChartLegendIcon.Rectangle;
            stepLineSeries2.StrokeWidth = 3;
            stepLineSeries2.TooltipEnabled = true;

            StepLineSeries stepLineSeries3 = new StepLineSeries();
			stepLineSeries3.ItemsSource = MainPage.GetStepLineData3();
			stepLineSeries3.XBindingPath = "XValue";
			stepLineSeries3.YBindingPath = "YValue";
            stepLineSeries3.Label = "Japan";
            stepLineSeries3.DataMarker.ShowMarker = true;
            stepLineSeries3.DataMarker.MarkerColor = Color.ParseColor("#C15146");
            stepLineSeries3.DataMarker.MarkerStrokeColor = Color.ParseColor("#C15146");
            stepLineSeries3.LegendIcon = ChartLegendIcon.Rectangle;
            stepLineSeries3.StrokeWidth = 3;
            stepLineSeries3.TooltipEnabled = true;

            stepLineSeries1.EnableAnimation = true;
		    stepLineSeries2.EnableAnimation = true;
			stepLineSeries3.EnableAnimation = true;
			
            chart.Series.Add(stepLineSeries1);
            chart.Series.Add(stepLineSeries2);
            chart.Series.Add(stepLineSeries3);
            return chart;
        }
    }
}