#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Charts;
using Com.Syncfusion.Charts.Enums;
using Android.Graphics;

namespace SampleBrowser
{
    public class ZoomingandPanning : SamplePage
    {
       public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context); ;
            chart.Title.Text = "World Countries Details";
            chart.Title.TextSize = 15;
            chart.SetBackgroundColor(Color.White);

            chart.PrimaryAxis = new NumericalAxis();
            chart.PrimaryAxis.ShowMajorGridLines = false;
            chart.PrimaryAxis.Title.Text = "Literacy Rate";

            chart.SecondaryAxis = new NumericalAxis();
            chart.SecondaryAxis.ShowMajorGridLines = false;
            chart.SecondaryAxis.Title.Text = "GDP Growth Rate";

            ScatterSeries scatter = new ScatterSeries();
			scatter.ItemsSource = MainPage.GetScatterDataForZoomPan();
			scatter.XBindingPath = "XValue";
			scatter.YBindingPath = "YValue";
            scatter.EnableAnimation = true;
            chart.Series.Add(scatter);

            chart.Behaviors.Add(new ChartZoomPanBehavior {SelectionZoomingEnabled = true, SelectionRectStrokeWidth = 1});

           
            var label = new TextView(context);;
            label.SetPadding(5, 5, 5, 5);
            label.Text = "Pinch to zoom or double tap and drag to select a region to zoom in.";

            var layout = new LinearLayout(context){ Orientation = Android.Widget.Orientation.Vertical };

            var layoutLabel = new LinearLayout(context)
            {
                Orientation = Android.Widget.Orientation.Horizontal,
                LayoutParameters =
                    new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent)
            };

            layoutLabel.SetHorizontalGravity(GravityFlags.CenterHorizontal);
            layoutLabel.AddView(label);
            
            layout.AddView(layoutLabel);
            layout.AddView(chart);

            return layout;
        }

       public override void OnApplyChanges()
       {
           base.OnApplyChanges();
       }
    }
}