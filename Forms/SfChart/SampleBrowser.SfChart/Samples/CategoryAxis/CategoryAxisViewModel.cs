#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace SampleBrowser.SfChart
{
	public class CategoryAxisViewModel
	{
        public ObservableCollection<ChartDataModel> CategoryData { get; set; }

        public CategoryAxisViewModel()
		{

			CategoryData = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel("BGD", 87),
				new ChartDataModel("BTN", 70),
				new ChartDataModel("NPL", 82),
				new ChartDataModel("THA", 75),
				new ChartDataModel("MYS", 90)
			};
		}
	}
}
