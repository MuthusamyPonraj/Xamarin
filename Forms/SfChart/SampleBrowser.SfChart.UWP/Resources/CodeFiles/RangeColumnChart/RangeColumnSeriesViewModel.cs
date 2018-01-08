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
	public class RangeColumnSeriesViewModel
	{
		public ObservableCollection<RangeSeriesBaseModel> RangeColumnData1 { get; set; }

		public ObservableCollection<RangeSeriesBaseModel> RangeColumnData2 { get; set; }

		public RangeColumnSeriesViewModel()
		{
			RangeColumnData1 = new ObservableCollection<RangeSeriesBaseModel>
			{
				new RangeSeriesBaseModel("Jan", 6.1, 0.7),
				new RangeSeriesBaseModel("Mar", 8.5, 1.9),
				new RangeSeriesBaseModel("May", 14.4, 5.7),
				new RangeSeriesBaseModel("Jul", 19.2, 10.6),
				new RangeSeriesBaseModel("Sep", 16.1, 8.5),
				new RangeSeriesBaseModel("Nov", 6.9, 1.5)
			};
			RangeColumnData2 = new ObservableCollection<RangeSeriesBaseModel>
			{
				new RangeSeriesBaseModel("Jan", 7.7, 1.7),
				new RangeSeriesBaseModel("Mar", 7.5, 1.2),
				new RangeSeriesBaseModel("May", 11.4, 4.7),
				new RangeSeriesBaseModel("Jul", 17.2, 9.6),
				new RangeSeriesBaseModel("Sep", 15.1, 7.5),
				new RangeSeriesBaseModel("Nov", 7.9, 1.2)
			};
		}
	}
}