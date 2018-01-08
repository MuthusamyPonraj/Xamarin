#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using Syncfusion.SfSunburstChart.XForms;
using Xamarin.Forms;
using SampleBrowser.Core;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfSunburstChart
{
    [Preserve(AllMembers = true)]   
	public class Sunburst : SampleView
	{
		public Sunburst()
		{
            Syncfusion.SfSunburstChart.XForms.SfSunburstChart chart = new Syncfusion.SfSunburstChart.XForms.SfSunburstChart();

            chart.ValueMemberPath = "Sales";
            SunburstViewModel data = new SunburstViewModel();
            chart.ItemsSource = data.Data;
            chart.Radius = 0.95;
            chart.InnerRadius = 0.1;
            chart.Levels.Add(new SunburstHierarchicalLevel() { GroupMemberPath = "Quarter" });
            chart.Levels.Add(new SunburstHierarchicalLevel() { GroupMemberPath = "Month" });
            chart.Levels.Add(new SunburstHierarchicalLevel() { GroupMemberPath = "Week" });

            var title = new SunburstChartTitle();
            title.Text = "Sales Performance";

            var legend = new SunburstChartLegend();
            legend.IsVisible = true;
            legend.LegendPosition= SunburstDockPosition.Bottom;

            var dataLabel = new SunburstChartDataLabel();

            if (Device.Idiom == TargetIdiom.Tablet || Device.Idiom == TargetIdiom.Desktop)
            {
                title.FontSize = 18;
            }
            else
            {
                dataLabel.FontSize = 7;
            }

            dataLabel.ShowLabel = true;

            chart.Legend = legend;
            chart.Title = title;
            chart.DataLabel = dataLabel;
            chart.Margin = new Thickness(0, 10, 0, 10);

            Content = chart;
            
        }
	}
}