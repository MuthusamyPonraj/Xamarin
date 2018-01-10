#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
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
using System.Collections.Generic;

namespace SampleBrowser
{
    public class MultipleAxis : SamplePage
    {
       public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context);;
            chart.SetBackgroundColor(Color.White);
            chart.Legend.ToggleSeriesVisibility = true;
            chart.Legend.Visibility = Visibility.Visible;

            var primary = new CategoryAxis();
            primary.Title.Text = "Year";
            primary.Title.TextColor = Color.Black;
            primary.LabelPlacement = LabelPlacement.BetweenTicks;
            chart.PrimaryAxis = primary;

            var secondaryAxis = new NumericalAxis()
            {
                Interval = 2,
                ShowMajorGridLines = false
            };

            secondaryAxis.Title.Text = "Revenue (in millions)";
            secondaryAxis.LabelStyle.LabelFormat = "$####";
            chart.SecondaryAxis = secondaryAxis;

            var datas = new List<DataPoint>();
            datas.Add(new DataPoint("2010", 20));
            datas.Add(new DataPoint("2011", 21));
            datas.Add(new DataPoint("2012", 22.5));
            datas.Add(new DataPoint("2013", 26));
            datas.Add(new DataPoint("2014", 27));

            var datas1 = new List<DataPoint>();
            datas1.Add(new DataPoint("2010", 6));
            datas1.Add(new DataPoint("2011", 15));
            datas1.Add(new DataPoint("2012", 35));
            datas1.Add(new DataPoint("2013", 65));
            datas1.Add(new DataPoint("2014", 75));

            chart.Series.Add(new ColumnSeries()
            {
                Label = "Revenue",
				ItemsSource = datas,
				XBindingPath = "XValue",
				YBindingPath = "YValue",
                TooltipEnabled = true,
                EnableAnimation = true,
            });

            var lineSeries = new FastLineSeries()
            {
                Label = "Customers",
				ItemsSource = datas1,
				XBindingPath = "XValue",
				YBindingPath = "YValue",
                AnimationEnabled = true,
                YAxis = new NumericalAxis()
                {
                    OpposedPosition = true,
                    Minimum = 0,
                    Maximum = 80,
                    Interval = 5,
                    ShowMajorGridLines = false,
                }
            };
            chart.Series.Add(lineSeries);
            lineSeries.YAxis.Title.Text = "Number of Customers";
            lineSeries.TooltipEnabled = true;
            return chart;
        }
    }
}