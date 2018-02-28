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
    public class StepArea : SamplePage
    {
        SfChart chart;
        public override View GetSampleContent(Context context)
        {
            chart = new SfChart(context);
            chart.Title.Text = "Electricity Production";
            chart.Title.TextSize = 15;
            chart.SetBackgroundColor(Color.White);
            chart.ColorModel.ColorPalette = ChartColorPalette.Natural;

            chart.Legend.Visibility = Visibility.Visible;
            chart.Legend.IconHeight = 14;
            chart.Legend.IconWidth = 14;
            chart.Legend.DockPosition = ChartDock.Bottom;
            chart.Legend.ToggleSeriesVisibility = true;

            NumericalAxis categoryaxis = new NumericalAxis();
            categoryaxis.Title.Text = "Year";
            categoryaxis.MajorTickStyle.TickSize = 8;
            categoryaxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
            chart.PrimaryAxis = categoryaxis;

            NumericalAxis numericalaxis = new NumericalAxis();
            numericalaxis.Title.Text = "Production (kWh)";
            numericalaxis.Minimum = 0;
            numericalaxis.Maximum = 100;
            numericalaxis.Interval = 20;
            numericalaxis.LabelStyle.LabelFormat = "#'%'";
            numericalaxis.LineStyle.StrokeWidth = 0;
            numericalaxis.MajorTickStyle.StrokeWidth = 0;
            chart.SecondaryAxis = numericalaxis;

            StepAreaSeries stepAreaSeries1 = new StepAreaSeries();
            stepAreaSeries1.ItemsSource = MainPage.GetStepAreaData1();
            stepAreaSeries1.XBindingPath = "XValue";
            stepAreaSeries1.YBindingPath = "YValue";
            stepAreaSeries1.Label = "Company A";
            stepAreaSeries1.TooltipEnabled = true;
            stepAreaSeries1.EnableAnimation = true;

            StepAreaSeries stepAreaSeries2 = new StepAreaSeries();
            stepAreaSeries2.ItemsSource = MainPage.GetStepAreaData2();
            stepAreaSeries2.XBindingPath = "XValue";
            stepAreaSeries2.YBindingPath = "YValue";
            stepAreaSeries2.Label = "Company B";
            stepAreaSeries2.TooltipEnabled = true;
            stepAreaSeries2.EnableAnimation = true;

            chart.Series.Add(stepAreaSeries1);
            chart.Series.Add(stepAreaSeries2);

            return chart;
        }
    }
}