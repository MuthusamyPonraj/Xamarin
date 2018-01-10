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
    public class ImagePathConverter : IValueConverter
    {

        public static string GetImageSource(string resourceName)
        {
            var coll = resourceName.Split('.');
            if (coll.Length == 0)
                throw new ArgumentException("The provided resource name is invalid. Example, SampleBrowser.SfChart.Button.png");
            var assemblyName = coll[0] + "." + coll[1] + ".UWP";
            var assetName = coll[2] + "." + coll[3];
            if (Device.RuntimePlatform != Device.UWP || SampleBrowser.IsIndividualSB)
                return assetName;
            return assemblyName + "\\" + assetName;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null)
                return GetImageSource(parameter.ToString());
            return GetImageSource(value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}