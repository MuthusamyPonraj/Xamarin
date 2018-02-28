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
	public class PieSeriesViewModel
	{
		public ObservableCollection<ChartDataModel> PieSeriesData { get; set; }

		public PieSeriesViewModel()
		{
			PieSeriesData = new ObservableCollection<ChartDataModel>
			{
                new ChartDataModel("Chrome", 37),
                new ChartDataModel("UC Browser", 17),
                new ChartDataModel("iPhone", 19),
                new ChartDataModel("Others", 8),
                new ChartDataModel("Opera", 11),
                new ChartDataModel("Android", 12),
		   };
		}
	}
}
