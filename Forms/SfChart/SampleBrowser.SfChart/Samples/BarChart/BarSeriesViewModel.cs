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
	public class BarSeriesViewModel
	{
		public ObservableCollection<ChartDataModel> BarData1 { get; set; }

		public ObservableCollection<ChartDataModel> BarData2 { get; set; }



		public BarSeriesViewModel()
		{
			BarData1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2006", 7.8),
				new ChartDataModel("2007", 7.2),
				new ChartDataModel("2008", 6.8),
				new ChartDataModel("2009", 10.7),
				new ChartDataModel("2010", 10.8),
				new ChartDataModel("2011", 9.8)
			};

			BarData2 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2006", 4.8),
				new ChartDataModel("2007", 4.6),
				new ChartDataModel("2008", 7.2),
				new ChartDataModel("2009", 9.3),
				new ChartDataModel("2010", 9.7),
				new ChartDataModel("2011", 9)
			};
		}
	}
}