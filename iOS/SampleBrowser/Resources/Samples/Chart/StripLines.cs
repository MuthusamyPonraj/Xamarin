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
using nfloat = System.Single;
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
#endif

namespace SampleBrowser
{
	public class StripLines : SampleView
	{
		public StripLines ()
		{
			SFChart chart 						= new SFChart ();
			chart.Title.Text 			        = new NSString ("Average temperature for the year 2014");
			SFCategoryAxis primaryAxis 			= new SFCategoryAxis ();
			primaryAxis.LabelPlacement			= SFChartLabelPlacement.BetweenTicks;
			chart.PrimaryAxis 					= primaryAxis;
			chart.PrimaryAxis.Title.Text        = new NSString ("Months");
			SFNumericalAxis numeric				= new SFNumericalAxis ();
			numeric.Minimum 					= NSObject.FromObject(28);
			numeric.Maximum 					= NSObject.FromObject(52);
			numeric.Interval 					= NSObject.FromObject(2);
			numeric.Title.Text  				= new NSString ("Temperature in Celsius");
			SFChartNumericalStripLine strip1 	= new SFChartNumericalStripLine ();
			strip1.Start                        = 28;
			strip1.Width                        = 8;
			strip1.Text                         = new NSString("Low Temperature");
			strip1.BackgroundColor              = UIColor.FromRGBA((nfloat)0.7843,(nfloat)0.8196,(nfloat)0.4275,(nfloat)1.0);

			numeric.AddStripLine (strip1);

			SFChartNumericalStripLine strip2 	= new SFChartNumericalStripLine ();
			strip2.Start                        = 36;
			strip2.Width                        = 8;
			strip2.Text                         = new NSString("Average Temperature");
			strip2.BackgroundColor              = UIColor.FromRGBA((nfloat)0.9569,(nfloat)0.7804,(nfloat)0.3843,(nfloat)1.0);

			numeric.AddStripLine (strip2);

			SFChartNumericalStripLine strip3 	= new SFChartNumericalStripLine ();
			strip3.Start                        = 44;
			strip3.Width                        = 8;
			strip3.Text                         = new NSString("High Temperature");
			strip3.BackgroundColor              = UIColor.FromRGBA((nfloat)0.9373,(nfloat)0.4706,(nfloat)0.4706,(nfloat)1.0);

			numeric.AddStripLine (strip3);

			chart.SecondaryAxis 		        = numeric;
			ChartViewModel dataModel			= new ChartViewModel ();

			SFSplineSeries series = new SFSplineSeries();
			series.ItemsSource = dataModel.StripLineData;
			series.XBindingPath = "XValue";
			series.YBindingPath = "YValue";
			series.EnableTooltip = true;
			series.Color = UIColor.FromRGBA((nfloat)0.08235, (nfloat)0.2863, (nfloat)0.3098, (nfloat)1.0);
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