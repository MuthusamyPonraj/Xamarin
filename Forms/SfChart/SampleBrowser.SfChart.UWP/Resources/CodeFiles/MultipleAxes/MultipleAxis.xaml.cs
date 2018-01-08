#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfChart.XForms;

namespace SampleBrowser.SfChart
{
	public partial class MultipleAxes : SampleView
	{
		public MultipleAxes()
		{
			InitializeComponent();
			(Chart.SecondaryAxis as NumericalAxis).Interval = 2;

			((Chart.Series[1] as FastLineSeries).YAxis as NumericalAxis).Maximum = 80;
			((Chart.Series[1] as FastLineSeries).YAxis as NumericalAxis).Minimum = 0;
			((Chart.Series[1] as FastLineSeries).YAxis as NumericalAxis).Interval = 5;
			((Chart.Series[1] as FastLineSeries).YAxis as NumericalAxis).OpposedPosition = true;
		}
	}
}