#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Globalization;
using Xamarin.Forms;

namespace SampleBrowser.Core
{
    /// <summary>
    /// Converter for changing background color of Sample Label on selection.
    /// </summary>
    public class SelectionColorConverter : IValueConverter
    {
        /// <summary>
        /// Method used for conversion
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
                return Color.FromHex("#007ED6");
            else
                return Color.Black;
        }

        /// <summary>
        /// Method used for reverse conversion.
        /// </summary>
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Color.Black;
        }
    }

    /// <summary>
    /// Converter for changing Image of Chart Types Samples on selection.
    /// </summary>
    public class SelectionImageConverter : IValueConverter
    {
        /// <summary>
        /// Method used for conversion
        /// </summary>
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value is string)
                return ChangeImageName(value as string);

            return null;
        }

        /// <summary>
        /// Method used for reverse conversion.
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Color.Black;
        }

        string ChangeImageName(string str)
        {
            int i = str.LastIndexOf('.');
            string imageName = i < 0 ? str : str.Substring(0, i),
            imageExtension = i < 0 ? "" : str.Substring(i + 1);
            return imageName + "_selected." + imageExtension;
        }
    }

    /// <summary>
    /// Converter for changing Image of Chart Types Samples on selection.
    /// </summary>
    public class UpdateTypeImage : IValueConverter
    {
        /// <summary>
        /// Method used for conversion.
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string x = "";
            if (value != null && value is string)
            {
                if (value.ToString() == "Tags/updated.png")
                    x = "Tags/x_update.png";
                else if (value.ToString() == "Tags/newimage.png" || value.ToString() == "Tags/preview.png")
                    x = "Tags/x_new.png";
                else
                    x = "";
            }
            return x as object;
        }

        /// <summary>
        /// Method used for reverse conversion.
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }

    /// <summary>
    /// Converter for SamplesCount Property in SamplesModel.
    /// </summary>
    public class SamplesCountConverter : IValueConverter
    {
        /// <summary>
        /// Method used for conversion
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string samplesCount = "";
            if (value != null && value is int)
            {
                if ((int)value == 1)
                    samplesCount = "1 Sample";
                else
                    samplesCount = value + " Samples";
            }
            return samplesCount as object;
        }

        /// <summary>
        /// Method used for reverse conversion
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}