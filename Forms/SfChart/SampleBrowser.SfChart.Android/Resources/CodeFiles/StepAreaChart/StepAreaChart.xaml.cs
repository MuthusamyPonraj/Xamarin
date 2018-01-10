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
	public partial class StepAreaChart : SampleView
	{
		public StepAreaChart()
		{
			InitializeComponent();

			numericalAxis.LabelCreated += NumericalAxis_LabelCreated;
		}

		private void NumericalAxis_LabelCreated(object sender, ChartAxisLabelEventArgs e)
		{
			e.LabelContent = e.LabelContent + "B";
		}
	}
}