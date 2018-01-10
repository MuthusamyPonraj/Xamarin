#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfGauge.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfLinearGauge
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LinearGauge_Tablet : SampleView
    {
        public LinearGauge_Tablet()
        {
            InitializeComponent();

            ObservableCollection<LinearScale> scales = new ObservableCollection<LinearScale>();
            LinearScale scale = new LinearScale();
            scale.MinimumValue = 0;
            scale.MaximumValue = 100;
            scale.Interval = 20;
            scale.ScaleBarLength = 100;
            scale.ScaleBarColor = Color.FromRgb(250, 236, 236);
            scale.LabelColor = Color.FromRgb(84, 84, 84);
            scale.LabelPostfix = "%";
            scale.MinorTicksPerInterval = 1;
            scale.ScaleBarSize = 13;
            scale.ScalePosition = ScalePosition.BackWard;

            //Major Ticks setting
            LinearTickSettings major = new LinearTickSettings();
            major.Length = 10;
            major.Color = Color.FromRgb(175, 175, 175);
            major.Thickness = 1;
            scale.MajorTickSettings = major;

            //Minor Ticks setting
            LinearTickSettings minor = new LinearTickSettings();
            minor.Length = 10;
            minor.Color = Color.FromRgb(175, 175, 175);
            minor.Thickness = 1;
            scale.MinorTickSettings = minor;

            List<LinearPointer> pointers = new List<LinearPointer>();
            //SymbolPointer
            SymbolPointer symbolPointer = new SymbolPointer();
            symbolPointer.Value = 50;
            symbolPointer.Offset = 0.05;
            symbolPointer.Thickness = 3;
            symbolPointer.Color = Color.FromRgb(65, 77, 79);

            //BarPointer
            BarPointer rangePointer = new BarPointer();
            rangePointer.Value = 50;
            rangePointer.Color = Color.FromRgb(206, 69, 69);
            if (Device.Idiom == TargetIdiom.Phone)
                rangePointer.Thickness = 30;

            rangePointer.Thickness = 10;
            pointers.Add(symbolPointer);
            pointers.Add(rangePointer);
            scale.Pointers = pointers;

            //Range
            LinearRange symbolRange = new LinearRange();
            symbolRange.StartValue = 0;
            symbolRange.EndValue = 50;
            symbolRange.Color = Color.FromRgb(234, 248, 249);
            symbolRange.StartWidth = 10;
            symbolRange.EndWidth = 10;
            if (Device.OS == TargetPlatform.Windows)
                symbolRange.Offset = -0.07;
            else
                symbolRange.Offset = -0.17;

            scale.Ranges.Add(symbolRange);

            //Range
            LinearRange pointerRange = new LinearRange();
            pointerRange.StartValue = 50;
            pointerRange.EndValue = 100;
            pointerRange.Color = Color.FromRgb(50, 184, 198);
            pointerRange.StartWidth = 10;
            pointerRange.EndWidth = 10;
            if (Device.OS == TargetPlatform.Windows)
            {
                pointerRange.Offset = -0.07;
                if (Device.Idiom == TargetIdiom.Tablet)
                    gettingStarted.FontSize = 25;
            }
            else
                pointerRange.Offset = -0.17;

            scale.Ranges.Add(pointerRange);
            scales.Add(scale);
            linearGauge.BindingContext = scales;
        }
        public View getContent()
        {
            return this.Content;
        }
    }
}
