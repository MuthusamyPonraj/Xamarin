#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;

namespace SampleBrowser.SfChart
{
	public class StackedColumnSeriesViewModel
	{
		public ObservableCollection<ChartDataModel> StackedColumnData1 { get; set; }

		public ObservableCollection<ChartDataModel> StackedColumnData2 { get; set; }

		public ObservableCollection<ChartDataModel> StackedColumnData3 { get; set; }

		public ObservableCollection<ChartDataModel> StackedColumnData4 { get; set; }

		public StackedColumnSeriesViewModel()
		{
			StackedColumnData1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("Jan", 900),
				new ChartDataModel("Feb", 820),
				new ChartDataModel("Mar", 880),
				new ChartDataModel("Apr", 725)
			};
			StackedColumnData2 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("Jan", 190),
				new ChartDataModel("Feb", 226),
				new ChartDataModel("Mar", 194),
				new ChartDataModel("Apr", 250)
			};
			StackedColumnData3 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("Jan", 250),
				new ChartDataModel("Feb", 145),
				new ChartDataModel("Mar", 190),
				new ChartDataModel("Apr", 220)
			};
			StackedColumnData4 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("Jan", 150),
				new ChartDataModel("Feb", 120),
				new ChartDataModel("Mar", 115),
				new ChartDataModel("Apr", 125)
			};
		}
	}
}