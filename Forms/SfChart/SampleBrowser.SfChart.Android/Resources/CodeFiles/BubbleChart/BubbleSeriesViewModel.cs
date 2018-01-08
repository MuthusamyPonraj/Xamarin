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
	public class BubbleSeriesViewModel
	{
		public ObservableCollection<ChartDataModel> BubbleData { get; set; }

		public BubbleSeriesViewModel()
		{
			BubbleData = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel(92.2, 7.8, 0.47),
				new ChartDataModel(74, 6.5, 0.241),
				new ChartDataModel(90.4, 6.0, 0.238),
				new ChartDataModel(99.4, 2.2, 0.312),
				new ChartDataModel(88.6, 1.3, 0.197),
				new ChartDataModel(54.9, 3.7, 0.177),
				new ChartDataModel(99, 0.7, 0.0818),
				new ChartDataModel(72, 2.0, 0.0826),
				new ChartDataModel(99.6, 3.4, 0.143),
				new ChartDataModel(99, 0.2, 0.128),
				new ChartDataModel(86.1, 4.0, 0.115),
				new ChartDataModel(92.6, 6.6, 0.096),
				new ChartDataModel(61.3, 14.5, 0.162),
				new ChartDataModel(56.8, 6.1, 0.151)
			};
		}
	}
}