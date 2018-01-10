#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleBrowser.SfChart
{
    class TooltipViewModel
    {
        public ObservableCollection<ChartDataModel> TooltipData { get; set; }

        public TooltipViewModel()
        {
            TooltipData = new ObservableCollection<ChartDataModel>();
            TooltipData.Add(new ChartDataModel("2007", 1.61));
            TooltipData.Add(new ChartDataModel("2008", 2.34));
            TooltipData.Add(new ChartDataModel("2009", 2.16));
            TooltipData.Add(new ChartDataModel("2010", 2.1));
            TooltipData.Add(new ChartDataModel("2011", 1.61));
            TooltipData.Add(new ChartDataModel("2012", 2.05));
            TooltipData.Add(new ChartDataModel("2013", 2.5));
            TooltipData.Add(new ChartDataModel("2014", 2.21));
            TooltipData.Add(new ChartDataModel("2015", 2.34));
        }
    }
}