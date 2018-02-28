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
	public class StackedBar100SeriesViewModel
	{
		public ObservableCollection<ChartDataModel> StackedBar100Data1 { get; set; }

		public ObservableCollection<ChartDataModel> StackedBar100Data2 { get; set; }

		public ObservableCollection<ChartDataModel> StackedBar100Data3 { get; set; }

		public ObservableCollection<ChartDataModel> StackedBar100Data4 { get; set; }

		public StackedBar100SeriesViewModel()
		{
			StackedBar100Data1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel(2007, 453),
				new ChartDataModel(2008, 354),
				new ChartDataModel(2009, 282),
				new ChartDataModel(2010, 321),
				new ChartDataModel(2011, 333)

			};
			StackedBar100Data2 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel(2007, 876),
				new ChartDataModel(2008, 564),
				new ChartDataModel(2009, 242),
				new ChartDataModel(2010, 121),
				new ChartDataModel(2011, 343)
			};
			StackedBar100Data3 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel(2007, 356),
				new ChartDataModel(2008, 876),
				new ChartDataModel(2009, 898),
				new ChartDataModel(2010, 567),
				new ChartDataModel(2011, 456)
			};
			StackedBar100Data4 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel(2007, 122),
				new ChartDataModel(2008, 444),
				new ChartDataModel(2009, 222),
				new ChartDataModel(2010, 231),
				new ChartDataModel(2011, 122)
			};
		}
	}
}