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
	public class StepLineSeriesViewModel
	{
		public ObservableCollection<ChartDataModel> StepLineData1 { get; set; }

		public ObservableCollection<ChartDataModel> StepLineData2 { get; set; }

		public ObservableCollection<ChartDataModel> StepLineData3 { get; set; }

		public StepLineSeriesViewModel()
		{
			StepLineData1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel(2006, 463),
				new ChartDataModel(2007, 449),
				new ChartDataModel(2008, 458),
				new ChartDataModel(2009, 450),
				new ChartDataModel(2010, 425),
				new ChartDataModel(2011, 430),
			};
			StepLineData2 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel(2006, 519),
				new ChartDataModel(2007, 508),
				new ChartDataModel(2008, 502),
				new ChartDataModel(2009, 495),
				new ChartDataModel(2010, 485),
				new ChartDataModel(2011, 470),
			};
			StepLineData3 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel(2006, 570),
				new ChartDataModel(2007, 579),
				new ChartDataModel(2008, 563),
				new ChartDataModel(2009, 550),
				new ChartDataModel(2010, 545),
				new ChartDataModel(2011, 525),
			};
		}
	}
}