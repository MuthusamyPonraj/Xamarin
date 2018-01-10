#region Copyright Syncfusion Inc. 2001 - 2017
// Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Xamarin.Forms;
using System.Globalization;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfDataGrid
{
    [Preserve(AllMembers = true)]
    internal class StyleConverterforQS2 : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			double _value = (double)value;
            if (_value < 3500 && _value > 2000)
                return Color.White;
            else if (_value < 5000 && _value > 1000)
                return Color.FromHex("#3498DB");
            else
                return Color.FromHex("#5DADE2");
        }

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
    [Preserve(AllMembers = true)]
    internal class StyleConverterforQS3 : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			double _value = (double)value;
            if (_value < 3500 && _value > 2000)
                return Color.White;
            else if (_value < 5000 && _value > 1000)
                return Color.FromHex("#F8C471");
            else
                return Color.FromHex("#F5B041");
        }

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
    [Preserve(AllMembers = true)]
    internal class StyleConverterforQS4 : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			double _value = (double)value;
            if (_value < 3500 && _value > 2000)
                return Color.White;
            else if (_value < 5000 && _value > 1000)
                return Color.FromHex("#AF7AC5");
            else
                return Color.FromHex("#9B59B6");
        }

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
    [Preserve(AllMembers = true)]
    internal class StyleConverterforQS1 : IValueConverter
	{

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double _value = (double)value;
            if (_value < 3500 && _value > 2000)
                return Color.White;
            else if (_value < 5000 && _value > 1000)
                return Color.FromHex("#45B39D");
            else return Color.FromHex("#16A085");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

	[ContentProperty ("Source")]
    [Preserve(AllMembers = true)]
    public class ImageResourceExtension : IMarkupExtension
	{
		public string Source { get; set; }

		public object ProvideValue (IServiceProvider serviceProvider)
		{
			if (Source == null)
				return null;

			// Do your translation lookup here, using whatever method you require
			var imageSource = ImageSource.FromResource(Source);

			return imageSource;
		}
	}
    [Preserve(AllMembers = true)]
    public class ImageConverter:IValueConverter
	{
		private double? data;

		#region IValueConverter implementation

		public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
		{
			data = value as double?;
			if (data != null && data > 0)
				return ImageSource.FromResource("SampleBrowser.SfDataGrid.Icons.DataGrid.GreenUp.png");
			else
				return ImageSource.FromResource("SampleBrowser.SfDataGrid.Icons.DataGrid.RedDown.png");
		}
		public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
		{
			return data;
		}

		#endregion
		
	}
    [Preserve(AllMembers = true)]
    public class CellTemplateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;   
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
    [Preserve(AllMembers = true)]
    internal class ForegroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double _value = (double)value;
            if (_value < 3500 && _value > 2000)
                return Color.Black;
            else if (_value < 5000 && _value > 1000)
                return Color.White;
            else return Color.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }

}

