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
   // [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BubbleVisualization : SampleView
    {
        public BubbleVisualization()
        {
            InitializeComponent();

            BubbleVisualizationViewModel viewmodel = new BubbleVisualizationViewModel();
            this.sfmap.Layers[0].ItemsSource = viewmodel.GetDataSource();
            this.sfmap.Layers[0].ShapeSettings.ColorMappings.Clear();
        }
    }
}
