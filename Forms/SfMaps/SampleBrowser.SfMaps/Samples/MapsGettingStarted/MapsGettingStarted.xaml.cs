#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfMaps.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfMaps
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapsGettingStarted : SampleView
    {
        public MapsGettingStarted()
        {
            InitializeComponent();

            this.Maps.Layers[0].ShapeSettings.ColorMappings.Clear();
            this.Maps.Layers[0].MarkerSelected += (MapMarker marker) =>
            {
                if (marker != null)
                {
                    Toast.IsVisible = true;
                    CustomMarker custommarker = (CustomMarker)marker;

                    countryLabel.Text = custommarker.Label;
                    populationLabel.Text = custommarker.Population.ToString();

                    Device.StartTimer(new TimeSpan(0, 0, 3), () =>
                    {
                        Toast.IsVisible = false;
                        return false;
                    });
                }

            };
        }
    }

    public class CustomMarker : MapMarker
    {
        public ImageSource ImageName { get; set; }
        public  String Population { get; set; }
        public CustomMarker()
        {
            ImageName = ImageSource.FromResource("SampleBrowser.SfMaps.Icons.pin.png");
        }
    }
}
