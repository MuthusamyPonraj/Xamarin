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
    public class StripLines : SamplePage
    {
        public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context); ;
            chart.SetBackgroundColor(Color.White);
            chart.Title.Text = "Average temperature for the year 2014";
            chart.Title.TextSize = 15;
            chart.Title.SetPadding(0, 0, 0, 15);
            
            NumericalStripLine numericalStripLines1 = new NumericalStripLine();
            numericalStripLines1.Start = 28;
            numericalStripLines1.Width = 8;
            numericalStripLines1.Text = "Low Temperature";
            numericalStripLines1.FillColor = Color.ParseColor("#C8D16D");
   
            NumericalStripLine numericalStripLines2 = new NumericalStripLine();
            numericalStripLines2.Start = 36;
            numericalStripLines2.Width = 8;
            numericalStripLines2.Text = "Average Temperature";
            numericalStripLines2.FillColor = Color.ParseColor("#F4C762");

            NumericalStripLine numericalStripLines3 = new NumericalStripLine();
            numericalStripLines3.Start = 44;
            numericalStripLines3.Width = 8;
            numericalStripLines3.Text = "High Temperature";
            numericalStripLines3.FillColor = Color.ParseColor("#EF7878");
  
            NumericalAxis numericalAxis = new NumericalAxis() { Minimum = 28, Maximum = 52};
            numericalAxis.Title.Text = "Temperature in celsius";

            numericalAxis.StripLines.Add(numericalStripLines1);
            numericalAxis.StripLines.Add(numericalStripLines2);
            numericalAxis.StripLines.Add(numericalStripLines3);

            chart.PrimaryAxis = new CategoryAxis();
            (chart.PrimaryAxis as CategoryAxis).LabelPlacement = LabelPlacement.BetweenTicks;
            chart.PrimaryAxis.Title.Text = "Month";
            chart.SecondaryAxis = numericalAxis;

            var areaSeries = new SplineSeries
            {
                StrokeWidth = 3,
				ItemsSource = MainPage.GetStripLineData(),
				XBindingPath = "XValue",
				YBindingPath = "YValue",
                Color = Color.ParseColor("#2F4F4F")
            };

            chart.Series.Add(areaSeries);

            areaSeries.TooltipEnabled = true;
            return chart;
        }
    }
}