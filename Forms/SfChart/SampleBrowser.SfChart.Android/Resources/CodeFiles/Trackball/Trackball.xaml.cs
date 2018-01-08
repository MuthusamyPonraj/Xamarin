#region Copyright Syncfusion Inc. 2001 - 2017
// Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
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
			ser1.ItemsSource = data.LineSeries1;
			ser2.ItemsSource = data.LineSeries2;
			ser3.ItemsSource = data.LineSeries3;

			secondaryAxis.MajorTickStyle.TickSize = 0;
			secondaryAxis.AxisLineStyle.StrokeWidth = 0;
			secondaryAxis.Maximum = 50;
			secondaryAxis.Minimum = 25;

			ser1.Color = Color.FromRgb(253, 128, 35);
			ser2.Color = Color.FromRgb(115, 170, 174);
			ser3.Color = Color.FromRgb(195, 192, 91);

			labelDisplayMode.SelectedIndex = 1;
          
            labelDisplayMode.SelectedIndexChanged += labelDisplayMode_SelectedIndexChanged;

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