#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfSunburstChart
{
   [Preserve(AllMembers = true)]
	public class SunburstViewModel
	{
		public ObservableCollection<SunburstModel> Data { get; set; }

		public ObservableCollection<SunburstModel> Data1 { get; set; }

        public SunburstViewModel()
        {
            Data = new ObservableCollection<SunburstModel>();
                       

            Data.Add(new SunburstModel() { Quarter = "Q1", Month = "Jan", Sales = 11 });
            Data.Add(new SunburstModel() { Quarter = "Q1", Month = "Feb", Sales = 8 });
            Data.Add(new SunburstModel() { Quarter = "Q1", Month = "Mar", Sales = 5 });

            Data.Add(new SunburstModel() { Quarter = "Q2", Month = "Apr", Sales = 13 });
            Data.Add(new SunburstModel() { Quarter = "Q2", Month = "May", Sales = 12 });
            Data.Add(new SunburstModel() { Quarter = "Q2", Month = "Jun", Sales = 17 });

            Data.Add(new SunburstModel() { Quarter = "Q3", Month = "Jul", Sales = 5 });
            Data.Add(new SunburstModel() { Quarter = "Q3", Month = "Aug", Sales = 4 });
            Data.Add(new SunburstModel() { Quarter = "Q3", Month = "Sep", Sales = 5 });
           

            Data.Add(new SunburstModel() { Quarter = "Q4", Month = "Oct", Sales = 7 });
            Data.Add(new SunburstModel() { Quarter = "Q4", Month = "Nov", Sales = 18 });
            Data.Add(new SunburstModel() { Quarter = "Q4", Month = "Dec", Week = "W1", Sales = 5 });
            Data.Add(new SunburstModel() { Quarter = "Q4", Month = "Dec", Week = "W2", Sales = 5 });
            Data.Add(new SunburstModel() { Quarter = "Q4", Month = "Dec", Week = "W3", Sales = 5 });
            Data.Add(new SunburstModel() { Quarter = "Q4", Month = "Dec", Week = "W4", Sales = 5 });
        }
	}
}
