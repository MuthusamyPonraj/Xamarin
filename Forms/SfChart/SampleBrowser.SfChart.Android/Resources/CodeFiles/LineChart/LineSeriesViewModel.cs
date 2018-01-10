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
	public class LineSeriesViewModel
	{

		public ObservableCollection<ChartDataModel> LineData1 { get; set; }

		public ObservableCollection<ChartDataModel> LineData2 { get; set; }
		public LineSeriesViewModel()
		{
			LineData1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2005", 31),
				new ChartDataModel("2006", 28),
				new ChartDataModel("2007", 30),
				new ChartDataModel("2008", 36),
				new ChartDataModel("2009", 36),
				new ChartDataModel("2010", 39),
				new ChartDataModel("2011", 37)
			};

			LineData2 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2005", 39),
				new ChartDataModel("2006", 36),
				new ChartDataModel("2007", 40),
				new ChartDataModel("2008", 44),
				new ChartDataModel("2009", 45),
				new ChartDataModel("2010", 48),
				new ChartDataModel("2011", 46)
			};
		}
	}
}