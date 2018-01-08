#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using System;
namespace SampleBrowser.SfChart
{
	public class DateTimeAxisViewModel
	{
		public ObservableCollection<ChartDataModel> DateTimeData { get; set; }

		public DateTimeAxisViewModel()
		{
			DateTimeData = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel(new DateTime(2014, 02, 1), 10),
				new ChartDataModel(new DateTime(2015, 03, 2), 30),
				new ChartDataModel(new DateTime(2016, 04, 3), 15),
				new ChartDataModel(new DateTime(2017, 05, 4), 65),
				new ChartDataModel(new DateTime(2018, 06, 5), 90),
				new ChartDataModel(new DateTime(2019, 07, 5), 85)
			};
		}
	}
}