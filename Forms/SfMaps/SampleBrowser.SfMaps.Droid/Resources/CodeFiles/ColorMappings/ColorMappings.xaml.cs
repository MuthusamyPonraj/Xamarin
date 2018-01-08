#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
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
    public partial class ColorMappings : SampleView
    {
        public ColorMappings()
        {
            InitializeComponent();
            this.BindingContext = this;
            ColorMappingsViewModel viewmodel = new ColorMappingsViewModel();
            this.Map.Layers[0].ItemsSource = viewmodel.GetDataSource();
            this.Map.Layers[0].LegendSettings.IconSize = new Size(15, 15);
            if ((Device.Idiom == TargetIdiom.Tablet || Device.Idiom == TargetIdiom.Desktop) && Device.OS == TargetPlatform.Windows)
            {
                this.Map.Layers[0].LegendSettings.LegendPosition = new Point(400, 500);
            }

            this.Map.Layers[0].ShapeSelected += (object data) => {

                AgricultureData dat = data as AgricultureData;
                if (dat != null)
                {
                    Toast.IsVisible = true;
                    State = countryLabel.Text = dat.Name;
                    Type = populationLabel.Text = dat.Type;

                    Device.StartTimer(new TimeSpan(0, 0, 3), () =>
                    {
                        Toast.IsVisible = false;
                        return false;
                    });
                }
            };

        }

        private string state;

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
    }
}
