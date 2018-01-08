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
	public class DataMarkerCustomizationViewModel
	{
		public ObservableCollection<ChartDataModel> DataMarkerData { get; set; }

		public DataMarkerCustomizationViewModel()
		{
			DataMarkerData = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2001", 59),
				new ChartDataModel("2002", 44),
				new ChartDataModel("2003", 47),
				new ChartDataModel("2004", 61),
				new ChartDataModel("2005", 76),
			};
		}
	}
}