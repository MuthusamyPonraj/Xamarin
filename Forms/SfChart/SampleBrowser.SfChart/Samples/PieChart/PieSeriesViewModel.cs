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
	public class PieSeriesViewModel
	{
		public ObservableCollection<ChartDataModel> PieSeriesData { get; set; }

		public PieSeriesViewModel()
		{
			PieSeriesData = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("Other personal", 94658),
				new ChartDataModel("Medical care", 9090),
				new ChartDataModel("Housing", 2577),
		   };
		}
	}
}
