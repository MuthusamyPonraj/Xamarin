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
	public class StripLinesViewModel
	{
		public ObservableCollection<ChartDataModel> StripLineData { get; set; }

		public StripLinesViewModel()
		{

			StripLineData = new ObservableCollection<ChartDataModel>
			{
				 new ChartDataModel("Jan", 33),
				 new ChartDataModel("Feb", 37),
				 new ChartDataModel("Mar", 39),
				 new ChartDataModel("Apr", 43),
				 new ChartDataModel("May", 45),
				 new ChartDataModel("Jun", 43),
				 new ChartDataModel("Jul", 41),
				 new ChartDataModel("Aug", 40),
				 new ChartDataModel("Sep", 39),
				 new ChartDataModel("Oct", 39),
				 new ChartDataModel("Nov", 34),
				 new ChartDataModel("Dec", 33)
			};
		}
	}
}