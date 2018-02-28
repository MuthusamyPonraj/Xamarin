#region Copyright Syncfusion Inc. 2001 - 2018
// Copyright Syncfusion Inc. 2001 - 2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;
using SampleBrowser.Core;

namespace SampleBrowser.SfChart
{
    public partial class Trackball : SampleView
    {
        public Trackball()
        {
            InitializeComponent();
            var data = new TrackballViewModel();
            lineSeries1.ItemsSource = data.LineSeries1;
            lineSeries2.ItemsSource = data.LineSeries2;
            lineSeries3.ItemsSource = data.LineSeries3;

            labelDisplayMode.SelectedIndex = 1;

            labelDisplayMode.SelectedIndexChanged += labelDisplayMode_SelectedIndexChanged;

            if(Device.RuntimePlatform == Device.UWP)
            {
                secondaryAxisLabelStyle.LabelFormat = "0'M '";
            }
            else
            {
                secondaryAxisLabelStyle.LabelFormat = "#'M '";
            }
        }

        void labelDisplayMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (labelDisplayMode.SelectedIndex)
            {
                case 0:
                    chartTrackball.LabelDisplayMode = TrackballLabelDisplayMode.NearestPoint;
                    break;
                case 1:
                    chartTrackball.LabelDisplayMode = TrackballLabelDisplayMode.FloatAllPoints;
                    break;
            }
        }
    }

    public class StringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.ToString() + "%";
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string Value = value.ToString();
            int result;
            if (int.TryParse(Value, out result))
                return result;
            return value;
        }

    }
}