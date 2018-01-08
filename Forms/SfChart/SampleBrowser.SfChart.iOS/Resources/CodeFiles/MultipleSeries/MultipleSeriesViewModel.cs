#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;

namespace SampleBrowser.SfChart
{
	public class MultipleSeriesViewModel
	{
		Random random = new Random();

		public ObservableCollection<ChartDataModel> MultipleSeriesData1 { get; set; }

		public ObservableCollection<ChartDataModel> MultipleSeriesData2 { get; set; }

		public ObservableCollection<ChartDataModel> PieData { get; set; }

		public MultipleSeriesViewModel()
		{

			MultipleSeriesData1 = new ObservableCollection<ChartDataModel>();

			for (var i = 1; i <= 12; i++)
			{
				MultipleSeriesData1.Add(new ChartDataModel(new DateTime(2014, i, 1), random.Next(10, 100)));
			}

			MultipleSeriesData2 = new ObservableCollection<ChartDataModel>();

			for (var i = 1; i <= 12; i++)
			{
				MultipleSeriesData2.Add(new ChartDataModel(new DateTime(2014, i, 1), random.Next(10, 100)));
			}


            PieData = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel(new DateTime(2014, 1, 1), 48),
				new ChartDataModel(new DateTime(2014, 2, 1), 38),
				new ChartDataModel(new DateTime(2014, 3, 1), 28),
				new ChartDataModel(new DateTime(2014, 4, 1), 33),
				new ChartDataModel(new DateTime(2014, 5, 1), 25),
				new ChartDataModel(new DateTime(2014, 6, 1), 34)
			};
		}
	}
}