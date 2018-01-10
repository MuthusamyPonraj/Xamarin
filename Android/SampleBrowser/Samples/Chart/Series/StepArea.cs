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
    public class StepArea : SamplePage
    {
        SfChart chart;
        public override View GetSampleContent(Context context)
        {
            chart = new SfChart(context);
            chart.Title.Text = "Electricity Production";
            chart.Title.TextSize = 15;
            chart.SetBackgroundColor(Color.White);

            chart.Legend.Visibility = Visibility.Visible;
            chart.Legend.DockPosition = ChartDock.Bottom;
            chart.Legend.ToggleSeriesVisibility = true;

            NumericalAxis categoryaxis = new NumericalAxis();
            categoryaxis.Title.Text = "Year";
            categoryaxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
            chart.PrimaryAxis = categoryaxis;

            NumericalAxis numericalaxis = new NumericalAxis();
            numericalaxis.Maximum = 700;
            numericalaxis.Interval = 50;
            numericalaxis.Title.Text = "Production (billion kWh)";
            chart.SecondaryAxis = numericalaxis;
            numericalaxis.LabelCreated += Numericalaxis_LabelCreated;
            
            StepAreaSeries stepAreaSeries1 = new StepAreaSeries();
			stepAreaSeries1.ItemsSource = MainPage.GetStepAreaData1();
			stepAreaSeries1.XBindingPath = "XValue";
			stepAreaSeries1.YBindingPath = "YValue";
            stepAreaSeries1.Alpha = 0.5f;
            stepAreaSeries1.Label = "Brazil";
            stepAreaSeries1.LegendIcon = ChartLegendIcon.Rectangle;
            stepAreaSeries1.Color = Color.ParseColor("#69D2E7");
            stepAreaSeries1.TooltipEnabled = true;            
            stepAreaSeries1.EnableAnimation = true;
            stepAreaSeries1.DataMarker.ShowMarker = true;
            stepAreaSeries1.DataMarker.MarkerColor = Color.ParseColor("#69D2E7");
            stepAreaSeries1.DataMarker.MarkerStrokeWidth = 2;
            stepAreaSeries1.DataMarker.MarkerStrokeColor = Color.White;

            chart.Series.Add(stepAreaSeries1);
            
            return chart;
        }

        private void Numericalaxis_LabelCreated(object sender, ChartAxis.LabelCreatedEventArgs e)
        {
            e.P1.LabelContent = e.P1.LabelContent + "B";
        }
    }
}