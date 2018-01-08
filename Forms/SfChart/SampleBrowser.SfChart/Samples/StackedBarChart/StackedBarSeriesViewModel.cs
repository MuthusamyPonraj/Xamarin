#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;

namespace SampleBrowser.SfChart
{
	public class StackedBarSeriesViewModel
	{
		public ObservableCollection<ChartDataModel> StackedBarData1 { get; set; }

		public ObservableCollection<ChartDataModel> StackedBarData2 { get; set; }

		public ObservableCollection<ChartDataModel> StackedBarData3 { get; set; }

		public StackedBarSeriesViewModel()
		{
			StackedBarData1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("Jan", 6),
				new ChartDataModel("Feb", 8),
				new ChartDataModel("Mar", 12),
				new ChartDataModel("Apr", 15.5),
				new ChartDataModel("May", 20),
				new ChartDataModel("Jun", 24),
				new ChartDataModel("Jul", 28),
				new ChartDataModel("Aug", 32),
				new ChartDataModel("Sep", 33),
				new ChartDataModel("Oct", 35),
				new ChartDataModel("Nov", 40),
				new ChartDataModel("Dec", 42)
		   };
			StackedBarData2 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("Jan", 6),
				new ChartDataModel("Feb", 8),
				new ChartDataModel("Mar", 12),
				new ChartDataModel("Apr", 15.5),
				new ChartDataModel("May", 20),
				new ChartDataModel("Jun", 24),
				new ChartDataModel("Jul", 28),
				new ChartDataModel("Aug", 32),
				new ChartDataModel("Sep", 33),
				new ChartDataModel("Oct", 35),
				new ChartDataModel("Nov", 40),
				new ChartDataModel("Dec", 42)
			};
			StackedBarData3 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("Jan", -1),
				new ChartDataModel("Feb", -1.5),
				new ChartDataModel("Mar", -2),
				new ChartDataModel("Apr", -2.5),
				new ChartDataModel("May", -3),
				new ChartDataModel("Jun", -3.5),
				new ChartDataModel("Jul", -4),
				new ChartDataModel("Aug", -4.5),
				new ChartDataModel("Sep", -5),
				new ChartDataModel("Oct", -5.5),
				new ChartDataModel("Nov", -6),
				new ChartDataModel("Dec", -6.5)
			};
		}
	}
}