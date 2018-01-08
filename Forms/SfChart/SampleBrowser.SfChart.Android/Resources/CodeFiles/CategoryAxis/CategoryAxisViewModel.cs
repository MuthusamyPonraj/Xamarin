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
	public class CategoryAxisViewModel
	{
        public ObservableCollection<ChartDataModel> CategoryData { get; set; }
		
		public CategoryAxisViewModel()
		{

			CategoryData = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("Product A", 10),
				new ChartDataModel("Product B", 30),
				new ChartDataModel("Product C", 15),
				new ChartDataModel("Product D", 65),
				new ChartDataModel("Product E", 90),
				new ChartDataModel("Product F", 85),
			};
		}
	}
}
