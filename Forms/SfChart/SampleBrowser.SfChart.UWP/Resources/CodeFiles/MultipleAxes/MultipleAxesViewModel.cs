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
	public class MultipleAxesViewModel
	{
		public ObservableCollection<ChartDataModel> MultipleAxesData { get; set; }

		public ObservableCollection<ChartDataModel> datas1 { get; set; }

		public MultipleAxesViewModel()
		{
			MultipleAxesData = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2010", 20),
				new ChartDataModel("2011", 21),
				new ChartDataModel("2012", 22.5),
				new ChartDataModel("2013", 26),
				new ChartDataModel("2014", 27)
			};

			datas1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2010", 6),
				new ChartDataModel("2011", 15),
				new ChartDataModel("2012", 35),
				new ChartDataModel("2013", 65),
				new ChartDataModel("2014", 75)
			};
		}
	}
}