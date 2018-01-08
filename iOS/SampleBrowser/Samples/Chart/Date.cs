#region Copyright Syncfusion Inc. 2001 - 2017
// Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfChart.iOS;

#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;

#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using nint	 = System.Int32;
using nuint	 = System.Int32;
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
#endif

using System.Drawing;

namespace SampleBrowser
{
	public class DateTimeAxis : SampleView
	{
		public DateTimeAxis ()
		{
			SFChart chart 						= new SFChart ();
			chart.Title.Text					= (NSString)"Average Sales Comparison";
			SFDateTimeAxis dateTimeAxis 		= new SFDateTimeAxis ();
			dateTimeAxis.EdgeLabelsDrawingMode  = SFChartAxisEdgeLabelsDrawingMode.Hide;
			dateTimeAxis.IntervalType 			= SFChartDateTimeIntervalType.Years;
			dateTimeAxis.Interval 				= new NSNumber(1);

			NSDateFormatter formatter			= new NSDateFormatter ();
			formatter.DateFormat				= "MM/yyyy";

			dateTimeAxis.LabelStyle.LabelFormatter	= formatter;
			dateTimeAxis.LabelRotationAngle			= -60;

			chart.PrimaryAxis 					= dateTimeAxis;
			chart.PrimaryAxis.Title.Text    	= new NSString ("Sales Across Years");

			chart.SecondaryAxis 				= new SFNumericalAxis ();
			chart.SecondaryAxis.Minimum 		= new NSNumber(0);
			chart.SecondaryAxis.Maximum 		= new NSNumber(100);
			chart.SecondaryAxis.Interval 		= new NSNumber(10);
			chart.SecondaryAxis.Title.Text 		= new NSString ("Sales Amount in Millions (USD)");

			NSNumberFormatter numberFormatter 	= new NSNumberFormatter ();
			numberFormatter.NumberStyle 		= NSNumberFormatterStyle.Currency;
			numberFormatter.MinimumFractionDigits	= 0;

			chart.SecondaryAxis.LabelStyle.LabelFormatter  = numberFormatter;

			ChartViewModel dataModel 		= new ChartViewModel ();

			SFLineSeries series = new SFLineSeries();
			series.ItemsSource = dataModel.DateTimeData;
			series.XBindingPath = "XValue";
			series.YBindingPath = "YValue";
			series.EnableTooltip = true;
			series.EnableAnimation = true;
			chart.Series.Add(series);

			this.AddSubview(chart);
		}

		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				view.Frame = Bounds;
			}
			base.LayoutSubviews ();
		}

	}
}

