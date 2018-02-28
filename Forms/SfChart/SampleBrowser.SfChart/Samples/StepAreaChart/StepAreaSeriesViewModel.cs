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
	public class StepAreaSeriesViewModel
	{
		public ObservableCollection<ChartDataModel> StepAreaData1 { get; set; }

        public ObservableCollection<ChartDataModel> StepAreaData2 { get; set; }

		public StepAreaSeriesViewModel()
		{
			StepAreaData1 = new ObservableCollection<ChartDataModel>
			{
                new ChartDataModel(2000, 40),
                new ChartDataModel(2001, 60),
                new ChartDataModel(2002, 50),
                new ChartDataModel(2003, 55),
                new ChartDataModel(2004, 75),
                new ChartDataModel(2005, 80)
			};

            StepAreaData2 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel(2000, 20),
                new ChartDataModel(2001, 40),
                new ChartDataModel(2002, 30),
                new ChartDataModel(2003, 45),
                new ChartDataModel(2004, 55),
                new ChartDataModel(2005, 60)
            };
		}
	}
}