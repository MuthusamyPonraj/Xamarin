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
using Com.Syncfusion.Charts.Enums;

namespace SampleBrowser
{
    public class DataMarkerCustomization : SamplePage
    {
        SfChart chart;
        BarSeries barSeries;
        float density;

        public override View GetSampleContent(Context context)
        {
            chart = new SfChart(context);
            chart.SetBackgroundColor(Color.White);
            density = context.Resources.DisplayMetrics.Density;
            CategoryAxis categoryaxis = new CategoryAxis();
            chart.PrimaryAxis = categoryaxis;

            NumericalAxis numericalaxis = new NumericalAxis();
            numericalaxis.Minimum = 0;
            numericalaxis.Maximum = 100;
            numericalaxis.Interval = 50;
            chart.SecondaryAxis = numericalaxis;

            barSeries = new BarSeries();
            barSeries.DataMarker.ShowLabel = true;
            barSeries.Color = Color.Rgb(231, 87, 89);
            barSeries.DataMarkerLabelCreated += BarSeries_DataMarkerLabelCreated;
			barSeries.ItemsSource = MainPage.GetDataMarkerData();
			barSeries.XBindingPath = "XValue";
            barSeries.YBindingPath = "YValue";
            chart.Series.Add(barSeries);
            barSeries.EnableAnimation = true;
            return chart;
        }

        private void BarSeries_DataMarkerLabelCreated(object sender, ChartSeries.DataMarkerLabelCreatedEventArgs e)
        {
            LinearLayout layout = new LinearLayout(chart.Context);

            TextView text = new TextView(chart.Context);
            ImageView image = new ImageView(chart.Context);
            image.LayoutParameters = new ViewGroup.LayoutParams(new LinearLayout.LayoutParams((int)(20 * density), (int)(20 *density)));

            text.Text = e.P0.Label + "%";

            if (Convert.ToDouble(e.P0.Label) < 50)
            {
                text.SetTextColor(Color.Red);
                image.SetImageResource(Resource.Drawable.Down);
            }
            else {
                text.SetTextColor(Color.Green);
                image.SetImageResource(Resource.Drawable.Up);
            }

            layout.AddView(text);
            layout.AddView(image);
            e.P0.View = layout;
        }
    }
}