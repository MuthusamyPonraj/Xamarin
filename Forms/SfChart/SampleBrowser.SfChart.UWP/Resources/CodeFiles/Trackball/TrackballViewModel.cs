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
    class TrackballViewModel
    {

        public ObservableCollection<ChartDataModel> LineSeries1 { get; set; }

        public ObservableCollection<ChartDataModel> LineSeries2 { get; set; }

        public ObservableCollection<ChartDataModel> LineSeries3 { get; set; }

        public TrackballViewModel()
        {

            LineSeries1 = new ObservableCollection<ChartDataModel>();
            LineSeries1.Add(new ChartDataModel("2005", 31));
            LineSeries1.Add(new ChartDataModel("2006", 28));
            LineSeries1.Add(new ChartDataModel("2007", 30));
            LineSeries1.Add(new ChartDataModel("2008", 36));
            LineSeries1.Add(new ChartDataModel("2009", 36));
            LineSeries1.Add(new ChartDataModel("2010", 39));

            LineSeries2 = new ObservableCollection<ChartDataModel>();
            LineSeries2.Add(new ChartDataModel("2005", 36));
            LineSeries2.Add(new ChartDataModel("2006", 32));
            LineSeries2.Add(new ChartDataModel("2007", 34));
            LineSeries2.Add(new ChartDataModel("2008", 41));
            LineSeries2.Add(new ChartDataModel("2009", 42));
            LineSeries2.Add(new ChartDataModel("2010", 42));

            LineSeries3 = new ObservableCollection<ChartDataModel>();
            LineSeries3.Add(new ChartDataModel("2005", 39));
            LineSeries3.Add(new ChartDataModel("2006", 36));
            LineSeries3.Add(new ChartDataModel("2007", 40));
            LineSeries3.Add(new ChartDataModel("2008", 44));
            LineSeries3.Add(new ChartDataModel("2009", 45));
            LineSeries3.Add(new ChartDataModel("2010", 48));

        }
    }
}
