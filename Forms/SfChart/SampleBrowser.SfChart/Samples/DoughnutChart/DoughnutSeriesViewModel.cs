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
				new ChartDataModel("License", 10),
				new ChartDataModel("Facilities", 12),
				new ChartDataModel("Taxes", 18),
				new ChartDataModel("Insurance", 12)
		   };
		}
	}
}