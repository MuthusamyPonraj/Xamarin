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
	public class PyramidSeriesViewModel
	{
		public ObservableCollection<ChartDataModel> PyramidData { get; set; }

		public PyramidSeriesViewModel()
		{           
			PyramidData = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("Germany", 30),
				new ChartDataModel("Argentina", 17),
				new ChartDataModel("South Africa", 18),
				new ChartDataModel("Indonesia", 23),
				new ChartDataModel("United States", 35),
				new ChartDataModel("South Korea", 28),
				new ChartDataModel("United Kingdom", 24)
		   };
		}

    }
}