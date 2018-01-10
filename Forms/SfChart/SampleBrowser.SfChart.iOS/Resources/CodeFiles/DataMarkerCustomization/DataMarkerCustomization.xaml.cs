#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using System;
using Xamarin.Forms;

namespace SampleBrowser.SfChart
{
	public partial class DataMarkerCustomization : SampleView
	{
		public DataMarkerCustomization()
		{
			InitializeComponent();
			columnSeries1.Color = Color.FromRgb(231, 87, 89);
		}
	}

	public class ColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (System.Convert.ToDouble(value) < 50)
				return Color.Red;
			else
				return Color.Lime;
		}
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return value;
		}

	}

	public class ChartImageConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
		    if (System.Convert.ToDouble(value) < 50)
		        return ImagePathConverter.GetImageSource("SampleBrowser.SfChart.Down.png");
                   
			else
				return ImagePathConverter.GetImageSource("SampleBrowser.SfChart.Up.png");
		}
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return value;
		}
	}
}