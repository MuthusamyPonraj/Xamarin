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
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfLinearGauge
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LinearGaugeSample : SampleView
    {
        public LinearGaugeSample()
        {
            InitializeComponent();
            if (Device.Idiom == TargetIdiom.Phone || Device.OS == TargetPlatform.Windows)
            {
                LinearGauge_Default autocomplete = new LinearGauge_Default();
                this.Content = autocomplete.getContent();


            }
            else if (Device.Idiom == TargetIdiom.Tablet)
            {
                LinearGauge_Tablet autocompleteTab = new LinearGauge_Tablet();
                this.Content = autocompleteTab.getContent();
            }
        }
    }
}
