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
	public class SplineSeriesViewModel
	{

		public ObservableCollection<ChartDataModel> SplineData1 { get; set; }

		public ObservableCollection<ChartDataModel> SplineData2 { get; set; }

		public SplineSeriesViewModel()
		{
			SplineData1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("Jan", -1),
				new ChartDataModel("Feb", -1),
				new ChartDataModel("Mar", 2),
				new ChartDataModel("Apr", 8),
				new ChartDataModel("May", 13),
				new ChartDataModel("Jun", 18),
				new ChartDataModel("Jul", 21),
				new ChartDataModel("Aug", 20),
				new ChartDataModel("Sep", 16),
				new ChartDataModel("Oct", 10),
				new ChartDataModel("Nov", 4),
				new ChartDataModel("Dec", 0)
			};

			SplineData2 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("Jan", 7),
				new ChartDataModel("Feb", 8),
				new ChartDataModel("Mar", 12),
				new ChartDataModel("Apr", 19),
				new ChartDataModel("May", 25),
				new ChartDataModel("Jun", 29),
				new ChartDataModel("Jul", 31),
				new ChartDataModel("Aug", 30),
				new ChartDataModel("Sep", 26),
				new ChartDataModel("Oct", 20),
				new ChartDataModel("Nov", 14),
				new ChartDataModel("Dec", 8)
			};
		}
	}
}