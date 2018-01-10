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
	public class PolarSeriesViewModel
	{
		public ObservableCollection<ChartDataModel> PolarData1 { get; set; }

		public ObservableCollection<ChartDataModel> PolarData2 { get; set; }

		public ObservableCollection<ChartDataModel> PolarData3 { get; set; }

		public PolarSeriesViewModel()
		{
			PolarData1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("N", 80),
				new ChartDataModel("NE", 85),
				new ChartDataModel("E", 78),
				new ChartDataModel("SE", 90),
				new ChartDataModel("S", 78),
				new ChartDataModel("SW", 83),
				new ChartDataModel("W", 79),
				new ChartDataModel("NW", 88)

			};

			PolarData2 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("N", 63),
				new ChartDataModel("NE", 70),
				new ChartDataModel("E", 45),
				new ChartDataModel("SE", 70),
				new ChartDataModel("S", 47),
				new ChartDataModel("SW", 65),
				new ChartDataModel("W", 58),
				new ChartDataModel("NW", 73)
			};

			PolarData3 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("N", 42),
				new ChartDataModel("NE", 40),
				new ChartDataModel("E", 25),
				new ChartDataModel("SE", 40),
				new ChartDataModel("S", 20),
				new ChartDataModel("SW", 45),
				new ChartDataModel("W", 40),
				new ChartDataModel("NW", 40)
			};
		}
	}
}