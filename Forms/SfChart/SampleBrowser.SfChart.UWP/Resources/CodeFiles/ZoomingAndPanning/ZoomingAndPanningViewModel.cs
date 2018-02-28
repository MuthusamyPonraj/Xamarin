#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;

namespace SampleBrowser.SfChart
{
    public class ZoomingAndPanningViewModel
    {
        Random Random = new Random();

        public ObservableCollection<ChartDataModel> ScatterDataZoomPan
        {
            get; set;
        }

        public ZoomingAndPanningViewModel()
        {
            ScatterDataZoomPan = new ObservableCollection<ChartDataModel>();
            {
                for (int i = 0; i < 100; i++)
                {
                    double x = Random.NextDouble() * 100;
                    double y = Random.NextDouble() * 500;
                    double randomDouble = Random.NextDouble();
                    if (randomDouble >= .25 && randomDouble < .5)
                    {
                        x *= -1;
                    }
                    else if (randomDouble >= .5 && randomDouble < .75)
                    {
                        y *= -1;
                    }
                    else if (randomDouble > .75)
                    {
                        x *= -1;
                        y *= -1;
                    }
                    ScatterDataZoomPan.Add(new ChartDataModel(300 + (x * (Random.NextDouble() + 0.12)),
                            150 + (y * (Random.NextDouble() + 0.12))));
                }
            }
        }
    }
}