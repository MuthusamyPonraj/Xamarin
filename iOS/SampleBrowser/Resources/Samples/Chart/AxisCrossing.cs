#region Copyright Syncfusion Inc. 2001 - 2017
// Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
using CoreAnimation;


#endregion
using System;
using Syncfusion.SfChart.iOS;


#if __UNIFIED__
using CoreGraphics;
using Foundation;
using UIKit;

#else
using MonoTouch.Foundation;
using MonoTouch.CoreGraphics;
using MonoTouch.UIKit;
using nint   = System.Int32;
using nuint  = System.Int32;
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
#endif

using System.Threading.Tasks;

namespace SampleBrowser
{
    public class AxisCrossing : SampleView
    {
        public AxisCrossing()
        {
            SFChart chart = new SFChart();
            chart.Title.Text = new NSString("Profit / loss percentage comparison");

            SFDateTimeAxis primaryAxis = new SFDateTimeAxis();
            primaryAxis.CrossesAt = 0;
            primaryAxis.EdgeLabelsDrawingMode = SFChartAxisEdgeLabelsDrawingMode.Shift;
            primaryAxis.RangePadding = SFChartDateTimePadding.Round;
            primaryAxis.Name = new NSString("XAxis");
            primaryAxis.CrossingAxisName = "YAxis";
            chart.PrimaryAxis = primaryAxis;

            SFNumericalAxis secondaryAxis = new SFNumericalAxis();
            secondaryAxis.Maximum = new NSNumber(-100);
            secondaryAxis.Minimum = new NSNumber(100);
            secondaryAxis.Interval = new NSNumber(20);
            secondaryAxis.CrossesAt = new DateTime(2003, 1, 1);
            secondaryAxis.EdgeLabelsDrawingMode = SFChartAxisEdgeLabelsDrawingMode.Shift;
            secondaryAxis.Name = new NSString("YAxis");
            secondaryAxis.CrossingAxisName = "XAxis";
            chart.SecondaryAxis = secondaryAxis;

            ChartViewModel dataModel = new ChartViewModel();


            SFBubbleSeries series = new SFBubbleSeries();
            series.ItemsSource = dataModel.AxisCrossingData;
            series.XBindingPath = "XValue";
            series.YBindingPath = "YValue";
            series.Size = "Size";
            series.ColorModel.Palette = SFChartColorPalette.Pineapple;
            series.EnableTooltip = true;

            chart.Series.Add(series);


            this.AddSubview(chart);
        }

        public override void LayoutSubviews()
        {
            foreach (var view in this.Subviews)
            {
                view.Frame = Bounds;
            }
            base.LayoutSubviews();
        }
    }
}
