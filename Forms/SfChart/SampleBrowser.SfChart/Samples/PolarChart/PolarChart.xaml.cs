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
using Xamarin.Forms;
using Syncfusion.SfChart.XForms;

namespace SampleBrowser.SfChart
{
	public partial class PolarChart : SampleView
	{
		public PolarChart()
		{
			InitializeComponent();
            polarStartAngle.SelectedIndex = 0;
            polarStartAngle.SelectedIndexChanged += polarStartAngle_Changed;
		}

        void polarStartAngle_Changed(object sender ,EventArgs e)
        {
            switch (polarStartAngle.SelectedIndex)
			{
                case 0:
                    secondary.PolarAngle = ChartPolarAngle.Rotate0;
					break;
				case 1:
                    secondary.PolarAngle = ChartPolarAngle.Rotate90;
					break;
				case 2:
                    secondary.PolarAngle = ChartPolarAngle.Rotate180;
					break;
				case 3:
                    secondary.PolarAngle = ChartPolarAngle.Rotate270;
					break;
			}
        }
	}
}
