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
   public class Logarithmic : SamplePage
    {
       public override View GetSampleContent(Context context)
        {
	        var chart = new SfChart(context);
            chart.SetBackgroundColor(Color.White);
            chart.Title.Text = "Business Growth from 1990 to 2000";
            chart.Title.TextSize = 15;

            CategoryAxis categoryAxis= new CategoryAxis();
            categoryAxis.Title.Text = "Year";
            chart.PrimaryAxis = categoryAxis;
            chart.PrimaryAxis.Interval = 2;
            chart.PrimaryAxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;

	        LogarithmicAxis logAxis = new LogarithmicAxis();
            logAxis.ShowMinorGridLines = true;
            logAxis.MinorTicksPerInterval = 5;
            logAxis.Title.Text = "Profit";
            chart.SecondaryAxis = logAxis;
	    
	        LineSeries lineSeries = new LineSeries();
			lineSeries.ItemsSource = MainPage.GetLogarithmicData();
			lineSeries.XBindingPath = "XValue";
			lineSeries.YBindingPath = "YValue";
	        chart.Series.Add(lineSeries);

            lineSeries.TooltipEnabled = true;
		    return chart;
       }

    }
}