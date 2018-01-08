#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Reflection.Emit;
using Android.App;
using Android.Graphics;
using Android.OS;
using Com.Syncfusion.Charts;
using Android.Views;
using Android.Content;
using Android.Widget;
using System.Collections.Generic;
using System;
using Com.Syncfusion.Charts.Enums;

namespace SampleBrowser
{
    public class Line : SamplePage
    {
        SfChart chart;

        public override View GetSampleContent(Context context)
        {
            chart = new SfChart(context);
            chart.Title.Text = "Efficiency of oil fired power production";
            chart.Title.TextSize = 15;
            chart.SetBackgroundColor(Color.White);

            chart.Legend.Visibility = Visibility.Visible;
            chart.Legend.DockPosition = ChartDock.Bottom;
            chart.Legend.ToggleSeriesVisibility = true;
            
            CategoryAxis categoryaxis = new CategoryAxis();
	        categoryaxis.LabelPlacement = LabelPlacement.BetweenTicks;
            categoryaxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
            categoryaxis.Title.Text = "Year";
            chart.PrimaryAxis = categoryaxis;

            NumericalAxis numericalaxis = new NumericalAxis();
            numericalaxis.Minimum = 25;
            numericalaxis.Maximum = 50;
            numericalaxis.Interval = 5;
            numericalaxis.Title.Text = "Efficiency (%)";
            chart.SecondaryAxis = numericalaxis;

            LineSeries lineSeries1 = new LineSeries();
			lineSeries1.ItemsSource = MainPage.GetLineData1();
			lineSeries1.XBindingPath = "XValue";
			lineSeries1.YBindingPath = "YValue";
            lineSeries1.DataMarker.ShowMarker = true;
            lineSeries1.DataMarker.MarkerColor = Color.ParseColor("#FEBE17");
            lineSeries1.DataMarker.MarkerStrokeColor = Color.ParseColor("#FEBE17");            
            lineSeries1.Label = "India";
            lineSeries1.LegendIcon = ChartLegendIcon.Rectangle;
            lineSeries1.StrokeWidth = 3;
            lineSeries1.TooltipEnabled = true;

            LineSeries lineSeries2 = new LineSeries();
			lineSeries2.ItemsSource = MainPage.GetLineData2();
			lineSeries2.XBindingPath = "XValue";
			lineSeries2.YBindingPath = "YValue";
            lineSeries2.Label = "Germany";
            lineSeries2.DataMarker.ShowMarker = true;
            lineSeries2.DataMarker.MarkerColor = Color.ParseColor("#4F4838");
            lineSeries2.DataMarker.MarkerStrokeColor = Color.ParseColor("#4F4838");            
            lineSeries2.LegendIcon = ChartLegendIcon.Rectangle;
            lineSeries2.StrokeWidth = 3;
            lineSeries2.TooltipEnabled = true;
			
            lineSeries1.EnableAnimation = true;
            lineSeries2.EnableAnimation = true;

            chart.Series.Add(lineSeries1);
            chart.Series.Add(lineSeries2);
            return chart;
        }
    }
}