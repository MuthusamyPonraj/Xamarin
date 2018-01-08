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
	public class StackedColumn100SeriesViewModel
	{

		public ObservableCollection<ChartDataModel> StackedColumnData1 { get; set; }

		public ObservableCollection<ChartDataModel> StackedColumnData2 { get; set; }

		public ObservableCollection<ChartDataModel> StackedColumnData3 { get; set; }

		public ObservableCollection<ChartDataModel> StackedColumnData4 { get; set; }

		public StackedColumn100SeriesViewModel()
		{
			StackedColumnData1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("Jan", 900),
				new ChartDataModel("Feb", 820),
				new ChartDataModel("Mar", 880),
				new ChartDataModel("Apr", 725),
				new ChartDataModel("May", 765),
				new ChartDataModel("Jun", 679)
			};
			StackedColumnData2 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("Jan", 190),
				new ChartDataModel("Feb", 226),
				new ChartDataModel("Mar", 194),
				new ChartDataModel("Apr", 250),
				new ChartDataModel("May", 222),
				new ChartDataModel("Jun", 181)
			};
			StackedColumnData3 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("Jan", 250),
				new ChartDataModel("Feb", 145),
				new ChartDataModel("Mar", 190),
				new ChartDataModel("Apr", 220),
				new ChartDataModel("May", 225),
				new ChartDataModel("Jun", 135)
			};
			StackedColumnData4 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("Jan", 150),
				new ChartDataModel("Feb", 120),
				new ChartDataModel("Mar", 115),
				new ChartDataModel("Apr", 125),
				new ChartDataModel("May", 132),
				new ChartDataModel("Jun", 137)
			};
		}
	}
}