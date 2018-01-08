#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.SfNumericUpDown;
using SampleBrowser.SfNumericUpDown.UWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(CustomSlider), typeof(CustomSliderRenderer))]
namespace SampleBrowser.SfNumericUpDown.UWP
{
    public class CustomSliderRenderer:SliderRenderer
    {
        public CustomSliderRenderer()
        {
            Loaded += CustomSliderRenderer_Loaded;
        }

        private void CustomSliderRenderer_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
           
            Control.IsThumbToolTipEnabled = false;
        }
    }
}
