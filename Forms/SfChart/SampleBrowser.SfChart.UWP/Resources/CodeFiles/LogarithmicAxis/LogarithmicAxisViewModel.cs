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
	public class LogarithmicAxisViewModel
	{
		public ObservableCollection<ChartDataModel> LogarithmicData { get; set; }

		public LogarithmicAxisViewModel()
		{
			LogarithmicData = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("1990", 80),
				new ChartDataModel("1991", 200),
				new ChartDataModel("1992", 400),
				new ChartDataModel("1993", 600),
				new ChartDataModel("1994", 900),
				new ChartDataModel("1995", 1400),
				new ChartDataModel("1996", 2000),
				new ChartDataModel("1997", 4000),
				new ChartDataModel("1998", 6000),
				new ChartDataModel("1999", 8000),
				new ChartDataModel("2000", 9000)
			};
		}
	}
}
