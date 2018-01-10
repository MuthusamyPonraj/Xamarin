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
	public class StackedArea100SeriesViewModel
	{
		public ObservableCollection<ChartDataModel> StackedArea100Data1 { get; set; }

		public ObservableCollection<ChartDataModel> StackedArea100Data2 { get; set; }

		public ObservableCollection<ChartDataModel> StackedArea100Data3 { get; set; }


		public ObservableCollection<ChartDataModel> StackedArea100Data4 { get; set; }

		public StackedArea100SeriesViewModel()
		{
			StackedArea100Data1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2006", 34),
				new ChartDataModel("2007", 20),
				new ChartDataModel("2008", 40),
				new ChartDataModel("2009", 51),
				new ChartDataModel("2010", 26),
				new ChartDataModel("2011", 37),
				new ChartDataModel("2012", 54),
				new ChartDataModel("2013", 44),
				new ChartDataModel("2014", 48)
			};
			StackedArea100Data2 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2006", 51),
				new ChartDataModel("2007", 26),
				new ChartDataModel("2008", 37),
				new ChartDataModel("2009", 51),
				new ChartDataModel("2010", 26),
				new ChartDataModel("2011", 37),
				new ChartDataModel("2012", 43),
				new ChartDataModel("2013", 23),
				new ChartDataModel("2014", 55)
			};
			StackedArea100Data3 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2006", 14),
				new ChartDataModel("2007", 34),
				new ChartDataModel("2008", 73),
				new ChartDataModel("2009", 51),
				new ChartDataModel("2010", 26),
				new ChartDataModel("2011", 37),
				new ChartDataModel("2012", 12),
				new ChartDataModel("2013", 16),
				new ChartDataModel("2014", 34)
			};
			StackedArea100Data4 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2006", 37),
				new ChartDataModel("2007", 16),
				new ChartDataModel("2008", 53),
				new ChartDataModel("2009", 51),
				new ChartDataModel("2010", 26),
				new ChartDataModel("2011", 37),
				new ChartDataModel("2012", 54),
				new ChartDataModel("2013", 44),
				new ChartDataModel("2014", 23)
			};
		}
	}
}