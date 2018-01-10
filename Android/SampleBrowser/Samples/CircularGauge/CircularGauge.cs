#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
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
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Gauges.SfCircularGauge;
using System.Collections.ObjectModel;
using Android.Graphics;
using Com.Syncfusion.Gauges.SfCircularGauge.Enums;
using Android.Renderscripts;

namespace SampleBrowser
{
    public class CircularGauge: SamplePage
    {
        SfCircularGauge circularGauge;
        TickSetting majorTickstings;
        NeedlePointer needlePointer;
        RangePointer rangePointer;
        RangePointer rangePointer1;
        CircularScale circularScale;

		double value;

        public override View GetSampleContent (Context con)
		{
            circularGauge = new SfCircularGauge(con);

            ObservableCollection<CircularScale> _circularScales = new ObservableCollection<CircularScale>();
            ObservableCollection<CircularPointer> _circularPointers = new ObservableCollection<CircularPointer>();
            ObservableCollection<Header> _gaugeHeaders = new ObservableCollection<Header>();
            // adding  new CircularScale
            circularScale = new CircularScale();
            circularScale.StartValue = 0;
            circularScale.EndValue = 100;
            circularScale.StartAngle = 130;
            circularScale.SweepAngle = 280;
            circularScale.ShowRim = false;
            circularScale.MinorTicksPerInterval = 0;
			circularScale.LabelOffset = 0.8;
            circularScale.RadiusFactor = 1;
            circularScale.LabelTextSize = 18;

            //adding major ticks
            majorTickstings = new TickSetting();
            majorTickstings.Color = Color.ParseColor("#444444");
            majorTickstings.Size = 15;
			majorTickstings.Offset = 0.97;
            circularScale.MajorTickSettings = majorTickstings;

            //adding minor ticks
            TickSetting minorTickstings = new TickSetting();
            minorTickstings.Color = Color.Gray;
            circularScale.MinorTickSettings = minorTickstings;

            // adding needle Pointer
            needlePointer = new NeedlePointer();
            needlePointer.Value = 60;
            needlePointer.KnobColor = Color.ParseColor("#2BBFB8");
            needlePointer.KnobRadius = 20;
            needlePointer.Type = NeedleType.Bar;
            needlePointer.LengthFactor = 0.8;
            needlePointer.Width = 3;
            needlePointer.Color = Color.Gray;
            _circularPointers.Add(needlePointer);

            // adding range Pointer
            rangePointer = new RangePointer();
			rangePointer.Value = 60;
			rangePointer.Offset = 1;
            rangePointer.Color = Color.ParseColor("#2BBFB8");
            rangePointer.Width = 10;
            rangePointer.EnableAnimation = false;
            _circularPointers.Add(rangePointer);

            rangePointer1 = new RangePointer();
            rangePointer1.RangeStart = 60;
            rangePointer1.Value = 100;
            rangePointer1.Offset = 1;
            rangePointer1.Color = Color.ParseColor("#D14646");
            rangePointer1.Width = 10;
            rangePointer1.EnableAnimation = false;
            _circularPointers.Add(rangePointer1);

            circularScale.CircularPointers = _circularPointers;
            _circularScales.Add(circularScale);

            //adding header
            Header circularGaugeHeader = new Header();
            circularGaugeHeader.Text = "Speedometer";
            circularGaugeHeader.TextColor = Color.Gray;
            circularGaugeHeader.Position = new PointF((float)0.5, (float)0.7);
            circularGaugeHeader.TextSize = 20;
            _gaugeHeaders.Add(circularGaugeHeader);
            circularGauge.Headers = _gaugeHeaders;
            circularGauge.CircularScales = _circularScales;
            circularGauge.SetBackgroundColor(Color.White);

            LinearLayout linearLayout = new LinearLayout(con);
            linearLayout.AddView(circularGauge);
            linearLayout.SetPadding(30, 30, 30, 30);
            linearLayout.SetBackgroundColor(Color.White);
            return linearLayout;
		}

        public override View GetPropertyWindowLayout(Android.Content.Context context)
        {
            TextView pointervalue = new TextView(context);
            pointervalue.Text = "Change Pointer Value";
            pointervalue.Typeface = Typeface.DefaultBold;
            pointervalue.SetTextColor(Color.ParseColor("#262626"));
            pointervalue.TextSize = 20;

            SeekBar pointerSeek = new SeekBar(context);
            pointerSeek.Max = 100;
            pointerSeek.Progress = 60;
            pointerSeek.ProgressChanged += pointerSeek_ProgressChanged;

            LinearLayout optionsPage = new LinearLayout(context);

            optionsPage.Orientation = Orientation.Vertical;
            optionsPage.AddView(pointervalue); 
            optionsPage.AddView(pointerSeek);
            
            optionsPage.SetPadding(10,10,10,10);
            optionsPage.SetBackgroundColor(Color.White);
            return optionsPage;
        }

        void pointerSeek_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
			value = e.Progress;
            value = e.Progress;
		}

        public override void OnApplyChanges()
        {
            base.OnApplyChanges();
			needlePointer.Value = value;
		}
	}
}
