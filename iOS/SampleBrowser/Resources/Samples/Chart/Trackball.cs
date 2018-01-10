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
using Foundation;
using UIKit;
using CoreGraphics;

#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using nint = System.Int32;
using nuint = System.Int32;
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
#endif
namespace SampleBrowser
{
	public class Trackball : SampleView
	{
		UILabel label;
		SFChart chart; 
		public Trackball ()
		{
			chart 					        	= new SFChart ();
			SFCategoryAxis primaryAxis     	    = new SFCategoryAxis ();
			primaryAxis.ShowMajorGridLines      = false;
			primaryAxis.PlotOffset = 7;
			chart.PrimaryAxis 					= primaryAxis;
			SFNumericalAxis secondaryAxis 		= new SFNumericalAxis ();
			secondaryAxis.MajorTickStyle.LineSize = 0;
			secondaryAxis.AxisLineStyle.LineWidth = 0;
			chart.SecondaryAxis 				= secondaryAxis;
			ChartViewModel dataModel			= new ChartViewModel ();

			SFLineSeries series1 = new SFLineSeries();
			series1.ItemsSource = dataModel.LineSeries1;
			series1.XBindingPath = "XValue";
			series1.YBindingPath = "YValue";
			series1.EnableTooltip = true;
			series1.Label = "Germany";
			series1.LegendIcon = SFChartLegendIcon.Rectangle;
			series1.EnableAnimation = true;
			series1.DataMarker.ShowMarker = true;
			series1.DataMarker.MarkerWidth = 5;
			series1.DataMarker.MarkerHeight = 5;
			series1.DataMarker.MarkerBorderColor = UIColor.White;
			series1.DataMarker.MarkerBorderWidth = 1;
			series1.DataMarker.MarkerColor = UIColor.Orange;
			series1.Color = UIColor.Orange;
			series1.LineWidth = 3;
			chart.Series.Add(series1);

			SFLineSeries series2 = new SFLineSeries();
			series2.ItemsSource = dataModel.LineSeries2;
			series2.XBindingPath = "XValue";
			series2.YBindingPath = "YValue";
			series2.EnableTooltip = true;
			series2.Label = "England";
			series2.LegendIcon = SFChartLegendIcon.Rectangle;
			series2.EnableAnimation = true;
			series2.DataMarker.ShowMarker = true;
			series2.DataMarker.MarkerWidth = 5;
			series2.DataMarker.MarkerHeight = 5;
			series2.DataMarker.MarkerBorderColor = UIColor.White;
			series2.DataMarker.MarkerBorderWidth = 1;
			series2.DataMarker.MarkerColor = UIColor.FromRGB(113.0f / 255.0f, 170.0f / 255.0f, 175.0f / 255.0f);
			series2.Color = UIColor.FromRGB(113.0f / 255.0f, 170.0f / 255.0f, 175.0f / 255.0f);
			series2.LineWidth = 3;
			chart.Series.Add(series2);

			SFLineSeries series3 = new SFLineSeries();
			series3.ItemsSource = dataModel.LineSeries3;
			series3.XBindingPath = "XValue";
			series3.YBindingPath = "YValue";
			series3.EnableTooltip = true;
			series3.Label = "France";
			series3.LegendIcon = SFChartLegendIcon.Rectangle;
			series3.EnableAnimation = true;
			series3.DataMarker.ShowMarker = true;
			series3.DataMarker.MarkerWidth = 5;
			series3.DataMarker.MarkerHeight = 5;
			series3.DataMarker.MarkerBorderColor = UIColor.White;
			series3.DataMarker.MarkerBorderWidth = 1;
			series3.LineWidth = 3;
			series3.DataMarker.MarkerColor = UIColor.FromRGB(196.0f / 255.0f, 193.0f / 255.0f, 83.0f / 255.0f);
			series3.Color = UIColor.FromRGB(196.0f / 255.0f, 193.0f / 255.0f, 83.0f / 255.0f);
			chart.Series.Add(series3);

			label 					= new UILabel ();
			label.Text 				= "Press and hold to enable trackball";
			label.Font				= UIFont.FromName("Helvetica", 12f);
			label.TextAlignment 	= UITextAlignment.Center;
			label.LineBreakMode 	= UILineBreakMode.WordWrap;
			label.Lines 			= 2; 

			label.BackgroundColor	= UIColor.FromRGB (249, 249, 249);
			label.TextColor 		= UIColor.FromRGB (79, 86, 91);

			CALayer topLine			= new CALayer ();
			topLine.Frame 			= new CGRect (0, 0, UIScreen.MainScreen.ApplicationFrame.Width , 0.5);
			topLine.BackgroundColor	= UIColor.FromRGB (178, 178, 178).CGColor;
			label.Layer.AddSublayer (topLine);

			chart.Legend.Visible = true;

			CustomTrackballBehavior track = new CustomTrackballBehavior();
			track.MarkerStyle.Color = UIColor.White;
			track.MarkerStyle.Height = 5;
			track.MarkerStyle.Width = 5;
			track.MarkerStyle.BorderWidth = 2;
			chart.AddChartBehavior (track);

			this.AddSubview (chart);
			this.AddSubview (label);
		}

		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				if (view == chart)
					chart.Frame = new CGRect (0, 0, Frame.Width, Frame.Height-48);
				else if (view == label)
					label.Frame = new CGRect (0, Frame.Height-32, Frame.Width, 40);
				else
					view.Frame = Bounds;
			}
			base.LayoutSubviews ();
		}
	}

	public class CustomTrackballBehavior : SFChartTrackballBehavior
	{
		public override UIView ViewForTrackballLabel(SFChartPointInfo pointInfo)
		{
			pointInfo.MarkerStyle.BorderColor = pointInfo.Series.Color;

			UIView customView = new UIView();
			customView.Frame = new CGRect(0, 0, 80, 30);

			UIImageView imageView = new UIImageView();
			imageView.Frame = new CGRect(0, 0, 30, 30);
			imageView.Image = UIImage.FromBundle("Images/eficon.png");

			UILabel xLabel = new UILabel();
			xLabel.Frame = new CGRect(37, 0, 50, 15);
			xLabel.TextColor = UIColor.White;
			xLabel.Font = UIFont.FromName("HelveticaNeue-BoldItalic", 13f);
			xLabel.Text = (pointInfo.Data as ChartDataModel).XValue.ToString() + "%";

			UILabel yLabel = new UILabel();
			yLabel.Frame = new CGRect(37, 15, 50, 15);
			yLabel.TextColor = UIColor.White;
			yLabel.Font = UIFont.FromName("Helvetica", 8f);
			yLabel.Text = "Efficiency";

			customView.AddSubview(imageView);
			customView.AddSubview(xLabel);
			customView.AddSubview(yLabel);

			return customView;
		}
	}
}




