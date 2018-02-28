#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
				new ChartDataModel("USA", 46),
				new ChartDataModel("China", 37),
				new ChartDataModel("Japan", 39),
				
		   };
			ColumnData2 = new ObservableCollection<ChartDataModel>
			{
				 new ChartDataModel("USA", 27),
				new ChartDataModel("China", 23),
				new ChartDataModel("Japan", 17),
				
			};
            ColumnData3 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("USA", 36),
                new ChartDataModel("China", 33),
                new ChartDataModel("Japan", 30),
            };
		}
	}
}