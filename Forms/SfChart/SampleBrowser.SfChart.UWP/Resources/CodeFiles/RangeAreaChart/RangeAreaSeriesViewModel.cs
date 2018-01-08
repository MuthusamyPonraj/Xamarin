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
	public class RangeAreaSeriesViewModel
	{
		public ObservableCollection<RangeSeriesBaseModel> RangeAreaData { get; set; }

		public ObservableCollection<RangeSeriesBaseModel> RangeAreaData1 { get; set; }

		public RangeAreaSeriesViewModel()
		{
			RangeAreaData = new ObservableCollection<RangeSeriesBaseModel>
			{
				new RangeSeriesBaseModel("Jan/10", 45, 32),
				new RangeSeriesBaseModel("Feb/10", 48, 34),
				new RangeSeriesBaseModel("Mar/10", 46, 32),
				new RangeSeriesBaseModel("Apr/10", 48, 36),
				new RangeSeriesBaseModel("May/10", 46, 32),
				new RangeSeriesBaseModel("Jun/10", 49, 34)
			};

			RangeAreaData1 = new ObservableCollection<RangeSeriesBaseModel>
			{
				new RangeSeriesBaseModel("Jan/10", 30, 18),
				new RangeSeriesBaseModel("Feb/10", 24, 12),
				new RangeSeriesBaseModel("Mar/10", 29, 15),
				new RangeSeriesBaseModel("Apr/10", 24, 10),
				new RangeSeriesBaseModel("May/10", 30, 18),
				new RangeSeriesBaseModel("Jun/10", 24, 10)
			};
		}
	}
}