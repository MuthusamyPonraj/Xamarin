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
	public class DataPointSelectionViewModel
	{
		public ObservableCollection<ChartDataModel> SelectionData { get; set; }

		public DataPointSelectionViewModel()
		{
			SelectionData = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("Jan", 42),
				new ChartDataModel("Feb", 44),
				new ChartDataModel("Mar", 53),
				new ChartDataModel("Apr", 64),
				new ChartDataModel("May", 75),
				new ChartDataModel("Jun", 83)
			};
		}
	}
}