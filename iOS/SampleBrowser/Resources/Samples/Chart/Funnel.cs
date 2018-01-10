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

namespace SampleBrowser
{
	public class Funnel : SampleView
	{
		public Funnel ()
		{
			SFChart chart 					= new SFChart ();
			chart.Title.Text 				= new NSString ("Website Visitor");
			chart.Legend.Visible 			= true;
			ChartViewModel dataModel		= new ChartViewModel ();

			SFFunnelSeries series = new SFFunnelSeries();
			series.ItemsSource = dataModel.FunnelData;
			series.XBindingPath = "XValue";
			series.YBindingPath = "YValue";
			series.DataMarker.ShowLabel = true;
			series.LegendIcon = SFChartLegendIcon.Rectangle;
			series.ColorModel.Palette = SFChartColorPalette.TomatoSpectrum;
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