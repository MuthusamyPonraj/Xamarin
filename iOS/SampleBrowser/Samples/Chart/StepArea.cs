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
using nint = System.Int32;
using nuint = System.Int32;
#endif

namespace SampleBrowser
{
	public class StepArea : SampleView
	{
		public StepArea ()
		{
			SFChart chart 						= new SFChart ();
			chart.Title.Text 					= new NSString ("Electricity Production");
			SFNumericalAxis primaryAxis 		= new SFNumericalAxis ();
			primaryAxis.Title.Text				= new NSString ("Year");
			primaryAxis.Interval 				= new NSNumber (1);
			chart.PrimaryAxis 					= primaryAxis;
			SFNumericalAxis secondaryAxis 		= new SFNumericalAxis ();
			secondaryAxis.Title.Text			= new NSString ("Production(kWh)");
			chart.SecondaryAxis 				= secondaryAxis;
			ChartViewModel dataModel			= new ChartViewModel ();

			SFStepAreaSeries series1 = new SFStepAreaSeries();
			series1.ItemsSource = dataModel.StepLineData1;
			series1.XBindingPath = "XValue";
			series1.YBindingPath = "YValue";
			series1.EnableTooltip = true;
			series1.Alpha = 0.5f;
			series1.Label = "India";
			series1.LegendIcon = SFChartLegendIcon.Rectangle;
			series1.EnableAnimation = true;
			chart.Series.Add(series1);

			SFStepAreaSeries series2 = new SFStepAreaSeries();
			series2.ItemsSource = dataModel.StepLineData2;
			series2.XBindingPath = "XValue";
			series2.YBindingPath = "YValue";
			series2.EnableTooltip = true;
			series2.Alpha = 0.5f;
			series2.Label = "USA";
			series2.LegendIcon = SFChartLegendIcon.Rectangle;
			series2.EnableAnimation = true;
			chart.Series.Add(series2);

			SFStepAreaSeries series3 = new SFStepAreaSeries();
			series3.ItemsSource = dataModel.StepLineData3;
			series3.XBindingPath = "XValue";
			series3.YBindingPath = "YValue";
			series3.EnableTooltip = true;
			series3.Alpha = 0.5f;
			series3.Label = "UK";
			series3.LegendIcon = SFChartLegendIcon.Rectangle;
			series3.EnableAnimation = true;
			chart.Series.Add(series3);

			chart.ColorModel.Palette 			= SFChartColorPalette.TomatoSpectrum;
			chart.SecondaryAxis.Minimum 		= new NSNumber(390);
			chart.SecondaryAxis.Maximum 		= new NSNumber(600);
			chart.Legend.Visible 				= true;
			chart.Legend.DockPosition			= SFChartLegendPosition.Bottom;
			chart.AddChartBehavior(new SFChartZoomPanBehavior());
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