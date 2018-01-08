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
using Com.Syncfusion.Charts;
using Android.Graphics;
using Com.Syncfusion.Charts.Enums;

namespace SampleBrowser
{
    public class Pyramid : SamplePage
    {
        SfChart chart;
        List<String> overflowMode;
        public override View GetSampleContent(Context context)
        {
            chart = new SfChart(context);
            chart.Title.Text = "Sales Distribution of Cars by Region";
            chart.Title.TextSize = 15;
            chart.SetBackgroundColor(Color.White);
            chart.Legend.Visibility = Visibility.Visible;
            chart.Legend.DockPosition = ChartDock.Bottom;
            chart.Legend.ToggleSeriesVisibility = true;
            chart.Legend.OverflowMode = ChartLegendOverflowMode.Wrap;

            PyramidSeries pyramid = new PyramidSeries();
			pyramid.XBindingPath = "XValue";
			pyramid.YBindingPath = "YValue";
			pyramid.DataMarker.ShowLabel = true;
			pyramid.ItemsSource = MainPage.GetPyramidData();
            pyramid.LegendIcon = ChartLegendIcon.Rectangle;
            pyramid.ColorModel.ColorPalette = ChartColorPalette.Pineapple;
            pyramid.DataMarker.ShowLabel = true;
            pyramid.StrokeWidth = 1;
            pyramid.StrokeColor = Color.White;
            chart.Series.Add(pyramid);

            Spinner selectLabelMode = new Spinner(context, SpinnerMode.Dialog);
            overflowMode = new List<String>() { "Wrap", "Scroll" };

            ArrayAdapter<String> dataAdapter = new ArrayAdapter<String>
               (context, Android.Resource.Layout.SimpleSpinnerItem, overflowMode);
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleDropDownItem1Line);
            selectLabelMode.Adapter = dataAdapter;
            selectLabelMode.ItemSelected += SelectLabelMode_ItemSelected;

            LinearLayout linearLayout = new LinearLayout(context);
            linearLayout.SetPadding(20, 0, 20, 30);
            linearLayout.SetBackgroundColor(Color.Rgb(236, 235, 242));
            linearLayout.LayoutParameters = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent,
                LinearLayout.LayoutParams.WrapContent);
            linearLayout.Orientation = Orientation.Vertical;
            linearLayout.SetBackgroundColor(Color.White);

            linearLayout.AddView(selectLabelMode);
            linearLayout.AddView(chart);

            return linearLayout;
        }

        private void SelectLabelMode_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            String selectedItem = overflowMode[e.Position];
            if (selectedItem.Equals("Wrap"))
            {
                chart.Legend.OverflowMode = Com.Syncfusion.Charts.ChartLegendOverflowMode.Wrap;
            }
            else if (selectedItem.Equals("Scroll"))
            {
                chart.Legend.OverflowMode = Com.Syncfusion.Charts.ChartLegendOverflowMode.Scroll;
            }
        }
    }
}