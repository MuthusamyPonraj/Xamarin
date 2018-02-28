#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;

namespace SampleBrowser.SfChart
{
	public class AreaSeriesViewModel
	{
		public ObservableCollection<ChartDataModel> AreaData1 { get; set; }

        public ObservableCollection<ChartDataModel> AreaData2 { get; set; }

		public ObservableCollection<ChartDataModel> AreaData3 { get; set; }

		public AreaSeriesViewModel()
		{
			AreaData2 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel(2005, 3.5),
                new ChartDataModel(2006, 3.7),
                new ChartDataModel(2007, 3.6),
                new ChartDataModel(2008, 4.0),
                new ChartDataModel(2009, 3.5),
                new ChartDataModel(2010, 4.0),
                new ChartDataModel(2011, 4.3)
			};
			AreaData1 = new ObservableCollection<ChartDataModel>
			{
                new ChartDataModel(2005, 4.8),
                new ChartDataModel(2006, 5.1),
                new ChartDataModel(2007, 5.0),
                new ChartDataModel(2008, 6.0),
                new ChartDataModel(2009, 5.0),
                new ChartDataModel(2010, 6.0),
                new ChartDataModel(2011, 5.6)
			};
			
		}
	}
}
