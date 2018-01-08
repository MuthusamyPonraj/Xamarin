#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;
using SampleBrowser.Core;

namespace SampleBrowser.SfChart
{
	public partial class StripLines : SampleView
	{
		public StripLines()
		{
			InitializeComponent();
			(Chart.SecondaryAxis as NumericalAxis).Minimum = 28;
			(Chart.SecondaryAxis as NumericalAxis).Maximum = 52;
		}
	}
}
