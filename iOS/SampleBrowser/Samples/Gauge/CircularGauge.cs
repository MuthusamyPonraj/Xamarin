#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfGauge.iOS;

#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;
using System.Drawing;
using System.Collections.ObjectModel;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using CGRect = System.Drawing.RectangleF;
using CGPoint = System.Drawing.PointF;
using CGSize = System.Drawing.SizeF;
using nfloat = System.Single;
using System.Drawing;
#endif

namespace SampleBrowser
{
	public class CircularGauge : SampleView
	{

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}
			

		#region View lifecycle
		SFCircularGauge gauge;
		SFCircularScale scale;
		SFNeedlePointer needlePointer;
		SFRangePointer rangePointer, rangePointer1;
		UISlider slider;
		UIView option = new UIView();

		public CircularGauge () 
		{

			gauge = new SFCircularGauge ();
			gauge.Scales.Add (new SFCircularScale ());
			ObservableCollection<SFCircularScale> scales = new ObservableCollection<SFCircularScale>();

			scale = new SFCircularScale();
			scale.StartValue = 0;
			scale.EndValue = 100;
			scale.Interval = 10;
			scale.StartAngle = 34;
			scale.SweepAngle = 325;
			scale.ShowTicks = true;
			scale.ShowLabels = true;
			scale.ShowRim = false;

			scale.LabelColor = UIColor.Gray;
			scale.LabelOffset = 0.8f;
			scale.MinorTicksPerInterval = 0;
			ObservableCollection<SFCircularPointer> pointers = new ObservableCollection<SFCircularPointer>();

		    needlePointer = new SFNeedlePointer();
			needlePointer.Value = 60;
			needlePointer.Color = UIColor.Gray;
			needlePointer.KnobRadius = 12;
			needlePointer.KnobColor = UIColor.FromRGB(43, 191, 184);
			needlePointer.Width = 3;
			needlePointer.LengthFactor = 0.8f;
			//	needlePointer.PointerType = SFCiruclarGaugePointerType.SFCiruclarGaugePointerTypeBar;
            
			rangePointer = new SFRangePointer();
			rangePointer.Value = 60;
			rangePointer.Color = UIColor.FromRGB(43, 191, 184);
			rangePointer.Width = 5;
			rangePointer.EnableAnimation = false;

			rangePointer1 = new SFRangePointer();
			rangePointer1.RangeStart = 60;
			rangePointer1.Value = 100;
			rangePointer1.Color = UIColor.FromRGB((byte)209,(byte)70,(byte)70);
			rangePointer1.Width = 5;
			rangePointer1.EnableAnimation = false;

			pointers.Add(needlePointer);
			pointers.Add(rangePointer);
			pointers.Add(rangePointer1);

			SFTickSettings minor = new SFTickSettings();
			minor.Size = 4;
			minor.Color = UIColor.FromRGB(68, 68, 68);
			minor.Width = 3;
			scale.MinorTickSettings = minor;

			SFTickSettings major = new SFTickSettings();
			major.Size = 12;
			//major.Offset = 0.01f;
			major.Color = UIColor.FromRGB(68,68,68);
			major.Width = 2;
			scale.MajorTickSettings = major;
			scale.Pointers = pointers;


			SFGaugeHeader header = new SFGaugeHeader();
			header.Text = (NSString)"Speedometer";
			header.Position = new CGPoint (0.5f, 0.6f);
			header.TextColor = UIColor.Gray;
			if (Utility.IsIpad)
			{
				header.TextStyle = UIFont.SystemFontOfSize(18);
				scale.LabelFont = UIFont.SystemFontOfSize(14);

			}
			scales.Add(scale);
			gauge.Scales = scales;
		    gauge.Headers.Add(header);
			this.AddSubview (gauge);
			CreateOptionView();
			this.OptionView = option;

		}
			
		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				view.Frame = Bounds;
			}
if (Utility.IsIpad)
			{
				gauge.Frame = new CGRect(50, 50, (float)this.Frame.Width - 100, (float)this.Frame.Height - 100);
			}
			else {
				gauge.Frame = new CGRect(10, 10, (float)this.Frame.Width-20, (float)this.Frame.Height-20);
			}
			base.LayoutSubviews ();
		}
			
		private void CreateOptionView()
		{
			slider = new UISlider();
			slider.Frame = new CGRect(5, 50, 320, 60);
			slider.MinValue = 0f;
			slider.MaxValue = 100f;
			slider.Value = 60f;
			slider.ValueChanged+= (object sender, EventArgs e) => 
			{
				needlePointer.Value=slider.Value;
			};

			UISlider slider2 = new UISlider();
			slider2.Frame = new CGRect(5, 155, 320, 60);
			slider2.MinValue = 0f;
			slider2.MaxValue = 0.8f;
			slider2.Value = 0.01f;
			slider2.ValueChanged+= (object sender, EventArgs e) => 
			{
				scale.MajorTickSettings.Offset=slider2.Value;
			};

			UISlider slider3 = new UISlider();
			slider3.Frame = new CGRect(5, 260, 320, 60);
			slider3.MinValue = 0f;
			slider3.MaxValue = 0.8f;
			slider3.Value = 0.05f;
			slider3.ValueChanged+= (object sender, EventArgs e) => 
			{
				scale.LabelOffset=slider3.Value;
			};

			UILabel text1 = new UILabel ();
			text1.Text = "Change Pointer Value";
			text1.TextAlignment = UITextAlignment.Left;
			text1.TextColor = UIColor.Black;
			text1.Frame = new CGRect (10,25, 320,40);
			text1.Font=UIFont.FromName("Helvetica", 14f);

			UILabel text2 = new UILabel ();
			text2.Text = "Change Tick Offset";
			text2.TextAlignment = UITextAlignment.Left;
			text2.TextColor = UIColor.Black;
			text2.Frame = new CGRect (10,130,320,40);
			text2.Font=UIFont.FromName("Helvetica", 14f);


			UILabel text5 = new UILabel ();
			text5.Text = "Change Label Offset";
			text5.TextAlignment = UITextAlignment.Left;
			text5.TextColor = UIColor.Black;
			text5.Frame = new CGRect (10,230,320,40);
			text5.Font=UIFont.FromName("Helvetica", 14f);


			this.option.AddSubview (text1);
			this.option.AddSubview (text2);
			this.option.AddSubview (text5);
			this.option.AddSubview (slider);
			this.option.AddSubview (slider2);
			this.option.AddSubview (slider3);

		}

		#endregion
	}
}


