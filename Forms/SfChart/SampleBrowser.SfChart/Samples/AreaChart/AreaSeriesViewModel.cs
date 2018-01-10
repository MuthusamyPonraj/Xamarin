#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;

namespace SampleBrowser.SfChart
{
	public class AreaSeriesViewModel
	{
		public ObservableCollection<ChartDataModel> AreaData1 { get; set; }

        public ObservableCollection<ChartDataModel> AreaData2 { get; set; }

		public ObservableCollection<ChartDataModel> AreaData3 { get; set; }

		public AreaSeriesViewModel()
		{
			AreaData1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel(1900, 4.0),
				new ChartDataModel(1920, 3.0),
				new ChartDataModel(1940, 3.8),
				new ChartDataModel(1960, 3.4),
				new ChartDataModel(1980, 3.2),
				new ChartDataModel(2000, 3.9),
			};
			AreaData2 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel(1900, 2.6),
				new ChartDataModel(1920, 2.8),
				new ChartDataModel(1940, 2.6),
				new ChartDataModel(1960, 3.0),
				new ChartDataModel(1980, 3.6),
				new ChartDataModel(2000, 3.0)
			};
			AreaData3 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel(1900, 2.8),
				new ChartDataModel(1920, 2.5),
				new ChartDataModel(1940, 2.8),
				new ChartDataModel(1960, 3.0),
				new ChartDataModel(1980, 2.9),
				new ChartDataModel(2000, 2.0)
			};
		}
	}
}
