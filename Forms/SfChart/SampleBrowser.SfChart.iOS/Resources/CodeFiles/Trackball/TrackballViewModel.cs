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
    class TrackballViewModel
    {

        public ObservableCollection<ChartDataModel> LineSeries1 { get; set; }

        public ObservableCollection<ChartDataModel> LineSeries2 { get; set; }

        public ObservableCollection<ChartDataModel> LineSeries3 { get; set; }

        public TrackballViewModel()
        {

            LineSeries1 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel(2005, 70),
                new ChartDataModel(2006, 75),
                new ChartDataModel(2007, 82),
                new ChartDataModel(2008, 84),
                new ChartDataModel(2009, 88),
                new ChartDataModel(2010, 96)
            };

            LineSeries2 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel(2005, 43),
                new ChartDataModel(2006, 48),
                new ChartDataModel(2007, 55),
                new ChartDataModel(2008, 57),
                new ChartDataModel(2009, 61),
                new ChartDataModel(2010, 69)
            };
            LineSeries3 = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel(2005, 15),
                new ChartDataModel(2006, 20),
                new ChartDataModel(2007, 27),
                new ChartDataModel(2008, 29),
                new ChartDataModel(2009, 33),
                new ChartDataModel(2010, 41)
            };
        }
    }
}
