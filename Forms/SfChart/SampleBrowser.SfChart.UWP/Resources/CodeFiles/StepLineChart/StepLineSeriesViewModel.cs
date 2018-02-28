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
	public class StepLineSeriesViewModel
	{
		public ObservableCollection<ChartDataModel> StepLineData1 { get; set; }

		public ObservableCollection<ChartDataModel> StepLineData2 { get; set; }

		
		public StepLineSeriesViewModel()
		{
			StepLineData1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel(2005, 62),
                new ChartDataModel(2006, 50),
				new ChartDataModel(2007, 62),
				new ChartDataModel(2008, 78),
				new ChartDataModel(2009, 60),
				new ChartDataModel(2010, 75),
                new ChartDataModel(2011, 85),
			};
			StepLineData2 = new ObservableCollection<ChartDataModel>
			{
                new ChartDataModel(2005, 32),
                new ChartDataModel(2006, 20),
                new ChartDataModel(2007, 32),
                new ChartDataModel(2008, 40),
                new ChartDataModel(2009, 30),
                new ChartDataModel(2010, 45),
                new ChartDataModel(2011, 55),
			};
			
		}
	}
}