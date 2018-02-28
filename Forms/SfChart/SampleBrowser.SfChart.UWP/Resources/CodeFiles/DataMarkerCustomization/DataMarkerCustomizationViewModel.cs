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
	public class DataMarkerCustomizationViewModel
	{
		public ObservableCollection<ChartDataModel> DataMarkerData1 { get; set; }

        public ObservableCollection<ChartDataModel> DataMarkerData2 { get; set; }

        public DataMarkerCustomizationViewModel()
		{
			DataMarkerData2 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("2001", 38),
				new ChartDataModel("2002", 44),
				new ChartDataModel("2003", 47),
				new ChartDataModel("2004", 37),
				new ChartDataModel("2005", 42),
			};

            DataMarkerData1 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("2001", 59),
                new ChartDataModel("2002", 55),
                new ChartDataModel("2003", 57),
                new ChartDataModel("2004", 71),
                new ChartDataModel("2005", 66),
            };
        }
	}
}