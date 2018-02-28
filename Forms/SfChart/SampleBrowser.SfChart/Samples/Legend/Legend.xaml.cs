#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.ComponentModel;
using System.Globalization;
using Xamarin.Forms;

namespace SampleBrowser.SfChart
{
    public partial class Legend : SampleBrowser.Core.SampleView
	{
		public Legend()
		{
			InitializeComponent();

            if (Device.RuntimePlatform == Device.UWP)
            {
                if (Device.RuntimePlatform != Device.WinPhone)
                {
                    chart.Legend.DockPosition = Syncfusion.SfChart.XForms.LegendPlacement.Right;
                    chart.Margin = new Thickness(200, 0, 200, 0);
                    chart.Legend.MaxWidth = 200;
                }
            }
        }
	}

	public class BoolToFontAttributesConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if ((bool)value)
				return FontAttributes.Bold;
			return FontAttributes.None;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
            return null;
		}
	}

}