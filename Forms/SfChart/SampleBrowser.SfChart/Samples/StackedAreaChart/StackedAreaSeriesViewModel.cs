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
	public class StackedAreaSeriesViewModel
	{
		public ObservableCollection<ChartDataModel> StackedAreaData1 { get; set; }

		public ObservableCollection<ChartDataModel> StackedAreaData2 { get; set; }

		public ObservableCollection<ChartDataModel> StackedAreaData3 { get; set; }

		public ObservableCollection<ChartDataModel> StackedAreaData4 { get; set; }

		public StackedAreaSeriesViewModel()
		{
			StackedAreaData1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2002", 6),
				new ChartDataModel("2003", 7.5),
				new ChartDataModel("2004", 6),
				new ChartDataModel("2005", 6.5),
				new ChartDataModel("2006", 7.4),
				new ChartDataModel("2007", 7.9),
				new ChartDataModel("2008", 7.5),
				new ChartDataModel("2009", 8.5),
				new ChartDataModel("2010", 4.8),
				new ChartDataModel("2011", 9.3)
			};
			StackedAreaData2 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2002", 3.5),
				new ChartDataModel("2003", 4.9),
				new ChartDataModel("2004", 3.7),
				new ChartDataModel("2005", 7.5),
				new ChartDataModel("2006", 4.8),
				new ChartDataModel("2007", 2.6),
				new ChartDataModel("2008", 4.7),
				new ChartDataModel("2009", 3.7),
				new ChartDataModel("2010", 3.5),
				new ChartDataModel("2011", 3.6)
			};
			StackedAreaData3 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2002", 8.1),
				new ChartDataModel("2003", 8.8),
				new ChartDataModel("2004", 6.7),
				new ChartDataModel("2005", 6.4),
				new ChartDataModel("2006", 4.0),
				new ChartDataModel("2007", 4.8),
				new ChartDataModel("2008", 7.4),
				new ChartDataModel("2009", 3.5),
				new ChartDataModel("2010", 8.3),
				new ChartDataModel("2011", 4.7)
			};
			StackedAreaData4 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2002", 2.5),
				new ChartDataModel("2003", 6.1),
				new ChartDataModel("2004", 6.2),
				new ChartDataModel("2005", 1.8),
				new ChartDataModel("2006", 4.0),
				new ChartDataModel("2007", 6.5),
				new ChartDataModel("2008", 6.7),
				new ChartDataModel("2009", 7.2),
				new ChartDataModel("2010", 8.4),
				new ChartDataModel("2011", 6.9)
			};
		}
	}
}
