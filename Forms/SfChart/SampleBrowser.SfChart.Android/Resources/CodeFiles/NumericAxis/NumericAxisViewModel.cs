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
	public class NumericAxisViewModel
	{
		public ObservableCollection<ChartDataModel> NumericData { get; set; }

		public NumericAxisViewModel()
		{
			NumericData = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel(2001, 75),
				new ChartDataModel(2002, 90),
				new ChartDataModel(2003, 85),
				new ChartDataModel(2004, 70),
				new ChartDataModel(2005, 55),
				new ChartDataModel(2006, 65),
			};
		}
	}
}
