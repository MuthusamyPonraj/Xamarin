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
	public class BarSeriesViewModel
	{
		public ObservableCollection<ChartDataModel> BarData1 { get; set; }

		public ObservableCollection<ChartDataModel> BarData2 { get; set; }

		public BarSeriesViewModel()
		{
			BarData1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2007", 24),
				new ChartDataModel("2008", 28),
				new ChartDataModel("2009", 20),
				new ChartDataModel("2010", 23),
			
			};

			BarData2 = new ObservableCollection<ChartDataModel>
			{
                new ChartDataModel("2007", 9),
                new ChartDataModel("2008", 14),
                new ChartDataModel("2009", 8),
                new ChartDataModel("2010", 16),
			};
		}
	}
}