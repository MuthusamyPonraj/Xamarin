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
using SampleBrowser.SfNumericUpDown.Samples.NumericUpDown;

namespace SampleBrowser.SfNumericUpDown
{
    public partial class NumericUpDown : SampleView
    {
        public NumericUpDown()
        {
            InitializeComponent();
            
            NumericUpDown_Default autocomplete = new NumericUpDown_Default();
            this.Content = autocomplete.getContent();
            this.PropertyView = autocomplete.getPropertyView();
            if (Device.Idiom == TargetIdiom.Phone || Device.OS == TargetPlatform.Windows)
            {
                NumericUpDown_Default updown = new NumericUpDown_Default();
                this.Content = updown.getContent();
                this.PropertyView = updown.getPropertyView();


            }
            else if (Device.Idiom == TargetIdiom.Tablet)
            {
                NumericUpDown_Tablet  updownTab = new NumericUpDown_Tablet();
                this.Content = updownTab.getContent();
                this.PropertyView = updownTab.getPropertyView();
            }
		}
    }
}

