#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Charts;
using Com.Syncfusion.Charts.Enums;
using Com.Syncfusion.Navigationdrawer;

namespace SampleBrowser
{
    public class Bar : SamplePage
    {
        SfChart chart;
        BarSeries barseries;
        BarSeries barseries1;
        TextView spacingValue;
        TextView columnWidthValue;
        TextView cornerRadiusValue;
        public override View GetSampleContent(Context context)
        {
            chart = new SfChart(context);
            chart.Title.Text = "Unemployment Rate (%)";
            chart.Title.TextSize = 15;
            chart.SetBackgroundColor(Color.White);
            chart.Legend.Visibility = Visibility.Visible;
            chart.Legend.DockPosition = ChartDock.Bottom;
            chart.Legend.ToggleSeriesVisibility = true;
            chart.ColorModel.ColorPalette = ChartColorPalette.TomatoSpectrum;

            NumericalAxis categoryaxis = new NumericalAxis();
            categoryaxis.Minimum = 2005;
            categoryaxis.Maximum = 2012;
            categoryaxis.Interval = 1;
            categoryaxis.Title.Text = "Years";
            chart.PrimaryAxis = categoryaxis;

            NumericalAxis numericalaxis = new NumericalAxis();
            numericalaxis.Minimum = 3;
            numericalaxis.Maximum = 12;
            numericalaxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
            numericalaxis.Interval = 1;
            numericalaxis.Title.Text = "Percentage";
            chart.SecondaryAxis = numericalaxis;

            barseries = new BarSeries();
			barseries.ItemsSource = MainPage.GetBarData1();
			barseries.XBindingPath = "XValue";
			barseries.YBindingPath = "YValue";
            barseries.Label = "India";
            barseries.LegendIcon = ChartLegendIcon.Rectangle;
            barseries.DataMarker.ShowLabel = true;
            barseries.EnableAnimation = true;

            barseries1 = new BarSeries();
			barseries1.ItemsSource = MainPage.GetBarData2();
			barseries1.XBindingPath = "XValue";
			barseries1.YBindingPath = "YValue";
            barseries1.Label = "US";
            barseries1.LegendIcon = ChartLegendIcon.Rectangle;
            barseries1.DataMarker.ShowLabel = true;
            barseries1.EnableAnimation = true;

            chart.Series.Add(barseries);
            chart.Series.Add(barseries1);

            return chart;
        }
        public override View GetPropertyWindowLayout(Android.Content.Context context)
        {
            /**
     * Property Window
     * */
            int width = (context.Resources.DisplayMetrics.WidthPixels) / 2;
            LinearLayout propertylayout = new LinearLayout(context); //= new LinearLayout(context);
            propertylayout.Orientation = Android.Widget.Orientation.Vertical;

            LinearLayout.LayoutParams layoutParams1 = new LinearLayout.LayoutParams(
                width * 2, 5);

            layoutParams1.SetMargins(0, 20, 0, 0);

            spacingValue = new TextView(context);
            spacingValue.Text = "Spacing : 0.0";
            spacingValue.SetPadding(5, 20, 0, 20);

            columnWidthValue = new TextView(context);
            columnWidthValue.Text = "Width : 0.8";
            columnWidthValue.SetPadding(5, 20, 0, 20);

            cornerRadiusValue = new TextView(context);
            cornerRadiusValue.Text = "Corner Radious : 0";
            cornerRadiusValue.SetPadding(5,20,0,20);

            SeekBar spacing = new SeekBar(context);
            spacing.Max = 10;

            SeekBar columnWidth = new SeekBar(context);
            columnWidth.Max = 10;
            columnWidth.Progress = 8;

            SeekBar cornerRadius = new SeekBar(context);
            cornerRadius.Max = 15;
            cornerRadius.Progress = 0;

            spacing.ProgressChanged += Spacing_ProgressChanged;

            columnWidth.ProgressChanged += ColumnWidth_ProgressChanged;

            cornerRadius.ProgressChanged += CornerRadius_ProgressChanged;

            propertylayout.AddView(columnWidthValue);
            propertylayout.AddView(columnWidth);
            propertylayout.AddView(spacingValue);
            propertylayout.AddView(spacing);
            propertylayout.AddView(cornerRadiusValue);
            propertylayout.AddView(cornerRadius);
            SeparatorView separate = new SeparatorView(context, width * 2);
            separate.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 5);
            propertylayout.AddView(separate, layoutParams1);

            return propertylayout;
        }

        private void CornerRadius_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            double cornerRadious = 0;
            cornerRadious = (int)e.Progress;
            barseries.CornerRadius = new ChartCornerRadius(cornerRadious, cornerRadious, 0, 0);
            barseries1.CornerRadius = new ChartCornerRadius(cornerRadious, cornerRadious, 0, 0);
            cornerRadiusValue.Text = "Corner Radious : " + cornerRadious;
        }

        private void Spacing_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            float spacing = 0;
            spacing = (int)e.Progress;
            barseries.Spacing = spacing / 10;
            barseries1.Spacing = spacing / 10;
            spacingValue.Text = "Spacing : " + spacing / 10;
        }

        private void ColumnWidth_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            float columnWidth = 0;
            columnWidth = (int)e.Progress;
            barseries.Width = columnWidth / 10;
            barseries1.Width = columnWidth / 10;
            columnWidthValue.Text = "Width : " + columnWidth / 10;
        }
    }
}