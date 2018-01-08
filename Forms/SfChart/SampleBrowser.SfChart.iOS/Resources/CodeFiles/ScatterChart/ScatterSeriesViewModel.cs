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
	public class ScatterSeriesViewModel
	{
		public ObservableCollection<ChartDataModel> ScatterData { get; set; }

		Random random = new Random();

		public ScatterSeriesViewModel()
		{
			ScatterData = new ObservableCollection<ChartDataModel>();
			{
				for (int i = 0; i < 100; i++)
				{
					double x = random.NextDouble() * 100;
					double y = random.NextDouble() * 500;
					double randomDouble = random.NextDouble();
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
					ScatterData.Add(new ChartDataModel(300 + (x * (random.NextDouble() + 0.12)),
							100 + (y * (random.NextDouble() + 0.12))));
				}
			}
		}
	}
}