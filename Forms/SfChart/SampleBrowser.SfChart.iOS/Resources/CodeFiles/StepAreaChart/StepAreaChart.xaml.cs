#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;

namespace SampleBrowser.SfChart
{
	public partial class StepAreaChart : SampleView
	{
		public StepAreaChart()
		{
			InitializeComponent();

            if(Device.RuntimePlatform == Device.UWP)
            {
                secondaryAxisLabelSyle.LabelFormat = "0'%'";
            }
            else
            {
                secondaryAxisLabelSyle.LabelFormat = "#'%'";
            }
		}
	}
}