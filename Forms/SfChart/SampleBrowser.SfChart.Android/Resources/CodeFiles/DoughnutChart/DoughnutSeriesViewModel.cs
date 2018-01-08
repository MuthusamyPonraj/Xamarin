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
	public class DoughnutSeriesViewModel
	{
		public ObservableCollection<ChartDataModel> DoughnutSeriesData { get; set; }

		public DoughnutSeriesViewModel()
		{
			DoughnutSeriesData = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("Labour", 28),
				new ChartDataModel("Legal", 10),
				new ChartDataModel("Production", 20),
				new ChartDataModel("License", 15),
				new ChartDataModel("Facilities", 23),
				new ChartDataModel("Taxes", 17),
				new ChartDataModel("Insurance", 12)
		   };
		}
	}
}