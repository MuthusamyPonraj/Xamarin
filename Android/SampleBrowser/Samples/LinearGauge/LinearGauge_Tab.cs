#region Copyright Syncfusion Inc. 2001 - 2017
// Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
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
using Android.Util;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Gauges.SfLinearGauge;
using System.Collections.ObjectModel;
using Android.Graphics;

namespace SampleBrowser
{
	public class LinearGauge_Tab : SamplePage
	{
       /*********************************
        **Local Variable Inizialisation**
        *********************************/
        public static int pointervalue=80;
        LinearLayout mainLayout, mainLinearGaugeLayout;
        public static int barvalue=80;
        SfLinearGauge linearGauge;
        Context con;
        int totalHeight;

        public override View GetSampleContent (Context con1)
		{
            con = con1;
			linearGauge = new SfLinearGauge (con);
			ObservableCollection<LinearScale> scales = new ObservableCollection<LinearScale> ();
			ObservableCollection<LinearPointer> pointers = new ObservableCollection<LinearPointer> ();
			ObservableCollection<LinearRange> ranges = new ObservableCollection<LinearRange> ();
            totalHeight = (con.Resources.DisplayMetrics.HeightPixels);

            //linearGauge
            linearGauge.SetX (0);
			linearGauge.SetY (0);
			linearGauge.SetBackgroundColor (Color.Rgb (255, 255, 255));
			linearGauge.SetOrientation (SfLinearGauge.Orientation.Vertical);

            // outerScale
            LinearScale outerScale = new LinearScale ();
			outerScale.Minimum = 0;
			outerScale.Maximum = 100;
			outerScale.ScaleBarSize = 60;
			outerScale.ScaleBarLength = 100;
			outerScale.Interval = 20;
			outerScale.ScaleBarColor = Color.ParseColor ("#FAECEC");
			outerScale.MinorTicksPerInterval = 2;
			outerScale.LabelFontSize = 17;
			outerScale.LabelColor = Color.ParseColor ("#545454");
			outerScale.LabelPostfix = "%";

            //outerScale_majorTicksSettings
            LinearTickSettings outerScale_majorTicksSettings = new LinearTickSettings ();
			outerScale_majorTicksSettings.Color = Color.ParseColor ("#AFAFAF");//
			outerScale_majorTicksSettings.Length = 20;
			outerScale_majorTicksSettings.StrokeWidth = 5;
			outerScale_majorTicksSettings.Offset = 0;
			outerScale.MajorTickSettings = outerScale_majorTicksSettings;

            //outerScale_minorTicksSettings
            LinearTickSettings outerScale_minorTicksSettings = new LinearTickSettings ();
			outerScale_minorTicksSettings.Color = Color.ParseColor ("#AFAFAF");
			outerScale_minorTicksSettings.Length = 10;
			outerScale_minorTicksSettings.StrokeWidth = 5;
			outerScale_minorTicksSettings.Offset = 0;
			outerScale.MinorTickSettings = outerScale_minorTicksSettings;

            //outerScale_needlePointer
            SymbolPointer outerScale_needlePointer = new SymbolPointer ();
			outerScale_needlePointer.Value = pointervalue;
			outerScale_needlePointer.StrokeWidth = 0;
			outerScale_needlePointer.Offset = 0.1f;
			outerScale_needlePointer.Color = Color.ParseColor ("#414D4F");
			pointers.Add (outerScale_needlePointer);

            //rangePointer
            BarPointer rangePointer = new BarPointer ();
			rangePointer.Value = barvalue;
			rangePointer.Color = Color.ParseColor ("#CE4545");//
			rangePointer.StrokeWidth = 20;
			pointers.Add (rangePointer);
			outerScale.Pointers = pointers;

			//lower ranges
			LinearRange lowerRange = new LinearRange ();
			lowerRange.StartWidth = 30;
			lowerRange.EndWidth = 30;
			lowerRange.Color = Color.ParseColor ("#67d6db");
			lowerRange.StartValue = 0;
			lowerRange.EndValue = 50;
			lowerRange.Offset = -.3;
			ranges.Add (lowerRange);
			
            //higher ranges
			LinearRange higherRange = new LinearRange ();
			higherRange.StartWidth = 30;
			higherRange.EndWidth = 30;
			higherRange.Color = Color.ParseColor ("#32B8C6");
			higherRange.StartValue = 50;
			higherRange.EndValue = 100;
			higherRange.Offset = -.3;
			ranges.Add (higherRange);

			outerScale.Ranges = ranges;
			scales.Add (outerScale);
			linearGauge.Scales = scales;

            //Layout
            MemoryTextLayout();       
            DescriptionLayout();

            return mainLayout;
        }

        private void MemoryTextLayout()
        {
            //MemoryUsage Text
            TextView memoryUsage = new TextView(con);
            memoryUsage.Text = "Memory Usage";
            memoryUsage.TextSize = 20;
            memoryUsage.SetTextColor(Color.ParseColor("#CE4545"));
            
            //Main Gauge Layout
            mainLinearGaugeLayout = new LinearLayout(con);
            mainLinearGaugeLayout.Orientation = Android.Widget.Orientation.Vertical;
            mainLinearGaugeLayout.SetBackgroundColor(Color.Rgb(255, 255, 255));
            mainLinearGaugeLayout.SetGravity((GravityFlags)17);
            mainLinearGaugeLayout.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.7), GravityFlags.Center);

            //spaceText
            TextView spaceText1 = new TextView(con);
            spaceText1.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 40, GravityFlags.Center);

            //Linear Gauge Layout
            LinearLayout linearGaugeLayout = new LinearLayout(con);
            linearGaugeLayout.AddView(memoryUsage);
            linearGaugeLayout.SetGravity((GravityFlags)17);
            linearGaugeLayout.SetBackgroundColor(Color.Rgb(255, 255, 255));
            mainLinearGaugeLayout.AddView(linearGaugeLayout);
            mainLinearGaugeLayout.AddView(spaceText1);
            mainLinearGaugeLayout.AddView(linearGauge);
        }
        
        private void DescriptionLayout()
        {
            //spaceText
            TextView spaceText2 = new TextView(con);
            spaceText2.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 40, GravityFlags.Center);

            //desLabel
            TextView desLabel = new TextView(con);
            desLabel.SetPadding(0, 0, 0, 5);
            desLabel.Text = " Description";
            desLabel.TextSize = 16;

            //descriptionText
            TextView descriptionText = new TextView(con);
            descriptionText.SetPadding(0, 10, 0, 0);
            descriptionText.Text = " Linear Gauge displays a range of values graphically along the linear scale";
            descriptionText.TextSize = 16;

            //spaceText
            TextView spaceText3 = new TextView(con);
            spaceText3.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 40, GravityFlags.Center);

            //mainLayout
            mainLayout = new LinearLayout(con);
            mainLayout.Orientation = Android.Widget.Orientation.Vertical;
            mainLayout.AddView(spaceText2);
            mainLayout.AddView(desLabel);
            mainLayout.AddView(descriptionText);
            mainLayout.AddView(spaceText3);
            mainLayout.AddView(mainLinearGaugeLayout);
        }
	}
}

