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
	public class ColumnSeriesViewModel
	{

		public ObservableCollection<ChartDataModel> ColumnData1 { get; set; }

		public ObservableCollection<ChartDataModel> ColumnData2 { get; set; }

		public ObservableCollection<ChartDataModel> ColumnData3 { get; set; }

		public ColumnSeriesViewModel()
		{
			ColumnData1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("USA", 50),
				new ChartDataModel("China", 40),
				new ChartDataModel("Japan", 70),
				new ChartDataModel("Australia", 60),
				new ChartDataModel("France", 50)
		   };
			ColumnData2 = new ObservableCollection<ChartDataModel>
			{
				 new ChartDataModel("USA", 70),
				new ChartDataModel("China", 60),
				new ChartDataModel("Japan", 60),
				new ChartDataModel("Australia", 56),
				new ChartDataModel("France", 45)
			};
			ColumnData3 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("USA", 45),
				new ChartDataModel("China", 55),
				new ChartDataModel("Japan", 50),
				new ChartDataModel("Australia", 40),
				new ChartDataModel("France", 35)
			};
		}
	}
}