#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.Graphics;
using Com.Syncfusion.Charts;
using Java.Util;
using System;
using System.Collections.Generic;

namespace SampleBrowser
{
	public class DataPoint
	{
		public DataPoint(object xVal, double yVal)
		{
			XValue = xVal;
			YValue = yVal;
		}

		public DataPoint(object xVal, double high, double low)
		{
			XValue = xVal;
			YValue = High = high;
			Size = Low = low;
		}

		public DataPoint(object xVal, double open, double high, double low, double close)
		{
			XValue = xVal;
			Open = open;
			High = high;
			Low = low;
			Close = close;
		}

		public DataPoint(object xVal, double open, double high, double low, double close, double volume)
		{
			XValue = xVal;
			Open = open;
			High = high;
			Low = low;
			Close = close;
			Volume = volume;
		}

		public object XValue { get; set; }

		public double YValue { get; set; }

		public double Size { get; set; }

		public double High { get; set; }

		public double Low { get; set; }

		public double Open { get; set; }

		public double Close { get; set; }

		public double Volume { get; set; }
	}

	public class MainPage
	{
		public static List<DataPoint> GetAreaData()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("2010", 45));
			datas.Add(new DataPoint("2011", 56));
			datas.Add(new DataPoint("2012", 23));
			datas.Add(new DataPoint("2013", 43));
			datas.Add(new DataPoint("2014", Double.NaN));
			datas.Add(new DataPoint("2015", 54));
			datas.Add(new DataPoint("2016", 43));
			datas.Add(new DataPoint("2017", 23));
			datas.Add(new DataPoint("2018", 34));
			return datas;
		}

		public static List<DataPoint> GetDataMarkerData()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("2001", 59));
			datas.Add(new DataPoint("2002", 44));
			datas.Add(new DataPoint("2003", 47));
			datas.Add(new DataPoint("2004", 61));
			datas.Add(new DataPoint("2005", 76));
			return datas;
		}

		public static List<DataPoint> GetStepAreaData1()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint(2006, 400));
			datas.Add(new DataPoint(2007, 480));
			datas.Add(new DataPoint(2008, 460));
			datas.Add(new DataPoint(2009, 520));
			datas.Add(new DataPoint(2010, 450));
			datas.Add(new DataPoint(2011, 450));
			return datas;
		}

		public static List<DataPoint> GetStepAreaData2()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint(2006, 519));
			datas.Add(new DataPoint(2007, 508));
			datas.Add(new DataPoint(2008, 502));
			datas.Add(new DataPoint(2009, 495));
			datas.Add(new DataPoint(2010, 485));
			datas.Add(new DataPoint(2011, 470));
			return datas;
		}

		public static List<DataPoint> GetStepAreaData3()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint(2006, 463));
			datas.Add(new DataPoint(2007, 449));
			datas.Add(new DataPoint(2008, 458));
			datas.Add(new DataPoint(2009, 450));
			datas.Add(new DataPoint(2010, 435));
			datas.Add(new DataPoint(2011, 420));
			return datas;
		}

		public static List<DataPoint> GetStripLineData()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("Jan", 33));
			datas.Add(new DataPoint("Feb", 37));
			datas.Add(new DataPoint("Mar", 39));
			datas.Add(new DataPoint("Apr", 43));
			datas.Add(new DataPoint("May", 45));
			datas.Add(new DataPoint("Jun", 43));
			datas.Add(new DataPoint("Jul", 41));
			datas.Add(new DataPoint("Aug", 40));
			datas.Add(new DataPoint("Sep", 39));
			datas.Add(new DataPoint("Oct", 39));
			datas.Add(new DataPoint("Nov", 34));
			datas.Add(new DataPoint("Dec", 33));
			return datas;
		}

		public static List<DataPoint> GetData1()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("2010", 45));
			datas.Add(new DataPoint("2011", 89));
			datas.Add(new DataPoint("2012", 23));
			datas.Add(new DataPoint("2013", 43));
			datas.Add(new DataPoint("2014", 54));
			return datas;
		}
		public static List<DataPoint> GetLogarithmicData()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("1990", 80));
			datas.Add(new DataPoint("1991", 200));
			datas.Add(new DataPoint("1992", 400));
			datas.Add(new DataPoint("1993", 600));
			datas.Add(new DataPoint("1994", 900));
			datas.Add(new DataPoint("1995", 1400));
			datas.Add(new DataPoint("1996", 2000));
			datas.Add(new DataPoint("1997", 4000));
			datas.Add(new DataPoint("1998", 6000));
			datas.Add(new DataPoint("1999", 8000));
			datas.Add(new DataPoint("2000", 9000));
			return datas;
		}
		public static List<DataPoint> GetLineData1()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("2005", 31));
			datas.Add(new DataPoint("2006", 28));
			datas.Add(new DataPoint("2007", 30));
			datas.Add(new DataPoint("2008", 36));
			datas.Add(new DataPoint("2009", 36));
			datas.Add(new DataPoint("2010", 39));
			datas.Add(new DataPoint("2011", 37));
			return datas;
		}
		public static List<DataPoint> GetLineData2()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("2005", 39));
			datas.Add(new DataPoint("2006", 36));
			datas.Add(new DataPoint("2007", 40));
			datas.Add(new DataPoint("2008", 44));
			datas.Add(new DataPoint("2009", 45));
			datas.Add(new DataPoint("2010", 48));
			datas.Add(new DataPoint("2011", 46));
			return datas;
		}
		public static List<DataPoint> GetColumnData1()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("USA", 50));
			datas.Add(new DataPoint("China", 40));
			datas.Add(new DataPoint("Japan", 70));
			datas.Add(new DataPoint("Australia", 60));
			datas.Add(new DataPoint("France", 50));
			return datas;
		}
		public static List<DataPoint> GetColumnData2()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("USA", 70));
			datas.Add(new DataPoint("China", 60));
			datas.Add(new DataPoint("Japan", 60));
			datas.Add(new DataPoint("Australia", 56));
			datas.Add(new DataPoint("France", 45));
			return datas;
		}
		public static List<DataPoint> GetColumnData3()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("USA", 45));
			datas.Add(new DataPoint("China", 55));
			datas.Add(new DataPoint("Japan", 50));
			datas.Add(new DataPoint("Australia", 40));
			datas.Add(new DataPoint("France", 35));
			return datas;
		}
		public static List<DataPoint> GetBarData1()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint(2006, 7.8));
			datas.Add(new DataPoint(2007, 7.2));
			datas.Add(new DataPoint(2008, 6.8));
			datas.Add(new DataPoint(2009, 10.7));
			datas.Add(new DataPoint(2010, 10.8));
			datas.Add(new DataPoint(2011, 9.8));
			return datas;
		}
		public static List<DataPoint> GetBarData2()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint(2006, 4.8));
			datas.Add(new DataPoint(2007, 4.6));
			datas.Add(new DataPoint(2008, 7.2));
			datas.Add(new DataPoint(2009, 9.3));
			datas.Add(new DataPoint(2010, 9.7));
			datas.Add(new DataPoint(2011, 9.0));
			return datas;
		}
		public static List<DataPoint> GetAreaData1()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint(1900, 4.0));
			datas.Add(new DataPoint(1920, 3.0));
			datas.Add(new DataPoint(1940, 3.8));
			datas.Add(new DataPoint(1960, 3.4));
			datas.Add(new DataPoint(1980, 3.2));
			datas.Add(new DataPoint(2000, 3.9));
			return datas;
		}

		public static List<DataPoint> GetAreaData2()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint(1900, 2.6));
			datas.Add(new DataPoint(1920, 2.8));
			datas.Add(new DataPoint(1940, 2.6));
			datas.Add(new DataPoint(1960, 3.0));
			datas.Add(new DataPoint(1980, 3.6));
			datas.Add(new DataPoint(2000, 3.0));
			return datas;
		}

		public static List<DataPoint> GetAreaData3()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint(1900, 2.8));
			datas.Add(new DataPoint(1920, 2.5));
			datas.Add(new DataPoint(1940, 2.8));
			datas.Add(new DataPoint(1960, 3.0));
			datas.Add(new DataPoint(1980, 2.9));
			datas.Add(new DataPoint(2000, 2.0));
			return datas;
		}
		public static List<DataPoint> GetSplineAreaData1()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint(2002, 2.2));
			datas.Add(new DataPoint(2003, 3.4));
			datas.Add(new DataPoint(2004, 2.8));
			datas.Add(new DataPoint(2005, 1.6));
			datas.Add(new DataPoint(2006, 2.3));
			datas.Add(new DataPoint(2007, 2.5));
			datas.Add(new DataPoint(2008, 2.9));
			datas.Add(new DataPoint(2009, 3.8));
			datas.Add(new DataPoint(2010, 1.4));
			datas.Add(new DataPoint(2011, 3.1));
			return datas;
		}

		public static List<DataPoint> GetSplineAreaData2()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint(2002, 2.0));
			datas.Add(new DataPoint(2003, 1.7));
			datas.Add(new DataPoint(2004, 1.8));
			datas.Add(new DataPoint(2005, 2.1));
			datas.Add(new DataPoint(2006, 2.3));
			datas.Add(new DataPoint(2007, 1.7));
			datas.Add(new DataPoint(2008, 1.5));
			datas.Add(new DataPoint(2009, 2.8));
			datas.Add(new DataPoint(2010, 1.5));
			datas.Add(new DataPoint(2011, 2.3));
			return datas;
		}

		public static List<DataPoint> GetSplineAreaData3()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint(2002, 0.8));
			datas.Add(new DataPoint(2003, 1.3));
			datas.Add(new DataPoint(2004, 1.1));
			datas.Add(new DataPoint(2005, 1.6));
			datas.Add(new DataPoint(2006, 2.0));
			datas.Add(new DataPoint(2007, 1.7));
			datas.Add(new DataPoint(2008, 2.3));
			datas.Add(new DataPoint(2009, 2.7));
			datas.Add(new DataPoint(2010, 1.1));
			datas.Add(new DataPoint(2011, 2.3));
			return datas;
		}
		public static List<DataPoint> GetSplineData1()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("Jan", -1));
			datas.Add(new DataPoint("Feb", -1));
			datas.Add(new DataPoint("Mar", 2));
			datas.Add(new DataPoint("Apr", 8));
			datas.Add(new DataPoint("May", 13));
			datas.Add(new DataPoint("Jun", 18));
			datas.Add(new DataPoint("Jul", 21));
			datas.Add(new DataPoint("Aug", 20));
			datas.Add(new DataPoint("Sep", 16));
			datas.Add(new DataPoint("Oct", 10));
			datas.Add(new DataPoint("Nov", 4));
			datas.Add(new DataPoint("Dec", 0));
			return datas;
		}
		public static List<DataPoint> GetSplineData2()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("Jan", 7));
			datas.Add(new DataPoint("Feb", 8));
			datas.Add(new DataPoint("Mar", 12));
			datas.Add(new DataPoint("Apr", 19));
			datas.Add(new DataPoint("May", 25));
			datas.Add(new DataPoint("Jun", 29));
			datas.Add(new DataPoint("Jul", 31));
			datas.Add(new DataPoint("Aug", 30));
			datas.Add(new DataPoint("Sep", 26));
			datas.Add(new DataPoint("Oct", 20));
			datas.Add(new DataPoint("Nov", 14));
			datas.Add(new DataPoint("Dec", 8));
			return datas;
		}
		public static List<DataPoint> GetRangeColumnData1()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("Jan", 6.1, 0.7));
			datas.Add(new DataPoint("Mar", 8.5, 1.9));
			datas.Add(new DataPoint("May", 14.4, 5.7));
			datas.Add(new DataPoint("Jul", 19.2, 10.6));
			datas.Add(new DataPoint("Sep", 16.1, 8.5));
			datas.Add(new DataPoint("Nov", 6.9, 1.5));
			return datas;
		}
		public static List<DataPoint> GetRangeColumnData2()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("Jan", 7.7, 1.7));
			datas.Add(new DataPoint("Mar", 7.5, 1.2));
			datas.Add(new DataPoint("May", 11.4, 4.7));
			datas.Add(new DataPoint("Jul", 17.2, 9.6));
			datas.Add(new DataPoint("Sep", 15.1, 7.5));
			datas.Add(new DataPoint("Nov", 7.9, 1.2));
			return datas;
		}

		public static List<DataPoint> GetRangeArea()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("Jan/10", 45, 32));
			datas.Add(new DataPoint("Feb/10", 48, 34));
			datas.Add(new DataPoint("Mar/10", 46, 32));
			datas.Add(new DataPoint("Apr/10", 48, 36));
			datas.Add(new DataPoint("May/10", 46, 32));
			datas.Add(new DataPoint("Jun/10", 49, 34));
			return datas;
		}

		public static List<DataPoint> GetRangeArea1()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("Jan/10", 30, 18));
			datas.Add(new DataPoint("Feb/10", 24, 12));
			datas.Add(new DataPoint("Mar/10", 29, 15));
			datas.Add(new DataPoint("Apr/10", 24, 10));
			datas.Add(new DataPoint("May/10", 30, 18));
			datas.Add(new DataPoint("Jun/10", 24, 10));
			return datas;
		}

		public static List<DataPoint> GetStepLineData1()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint(2006, 463));
			datas.Add(new DataPoint(2007, 449));
			datas.Add(new DataPoint(2008, 458));
			datas.Add(new DataPoint(2009, 450));
			datas.Add(new DataPoint(2010, 425));
			datas.Add(new DataPoint(2011, 430));
			return datas;
		}

		public static List<DataPoint> GetStepLineData2()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint(2006, 519));
			datas.Add(new DataPoint(2007, 508));
			datas.Add(new DataPoint(2008, 502));
			datas.Add(new DataPoint(2009, 495));
			datas.Add(new DataPoint(2010, 485));
			datas.Add(new DataPoint(2011, 470));
			return datas;
		}

		public static List<DataPoint> GetStepLineData3()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint(2006, 570));
			datas.Add(new DataPoint(2007, 579));
			datas.Add(new DataPoint(2008, 563));
			datas.Add(new DataPoint(2009, 550));
			datas.Add(new DataPoint(2010, 545));
			datas.Add(new DataPoint(2011, 525));
			return datas;
		}

		public static List<DataPoint> GetStepLineData4()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint(2006, 570));
			datas.Add(new DataPoint(2007, 579));
			datas.Add(new DataPoint(2008, 563));
			datas.Add(new DataPoint(2009, 550));
			datas.Add(new DataPoint(2010, 545));
			datas.Add(new DataPoint(2011, 525));
			return datas;
		}

		public static List<DataPoint> GetPieData()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("Other personal", 94658));
			datas.Add(new DataPoint("Medical care", 9090));
			datas.Add(new DataPoint("Housing", 2577));
			return datas;
		}
		public static List<DataPoint> GetDoughnutData()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("Labour", 28));
			datas.Add(new DataPoint("Legal", 10));
			datas.Add(new DataPoint("Production", 20));
			datas.Add(new DataPoint("License", 15));
			datas.Add(new DataPoint("Facilities", 23));
			datas.Add(new DataPoint("Taxes", 17));
			datas.Add(new DataPoint("Insurance", 12));
			return datas;
		}
		public static List<DataPoint> GetPyramidData()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("India", 24));
			datas.Add(new DataPoint("Japan", 25));
			datas.Add(new DataPoint("Australia", 20));
			datas.Add(new DataPoint("USA", 35));
			datas.Add(new DataPoint("China", 23));
			datas.Add(new DataPoint("Germany", 27));
			datas.Add(new DataPoint("France", 22));
			return datas;
		}

		public static List<DataPoint> GetFunnelData()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("Renewed", 18.2));
			datas.Add(new DataPoint("Subscribe", 27.3));
			datas.Add(new DataPoint("Support", 55.9));
			datas.Add(new DataPoint("Downloaded", 76.8));
			datas.Add(new DataPoint("Visited", 100));
			return datas;
		}
		public static List<DataPoint> GetBubbleData()
		{
			var data = new List<DataPoint>();
			data.Add(new DataPoint(92.2, 7.8, 0.47));
			data.Add(new DataPoint(74, 6.5, 0.241));
			data.Add(new DataPoint(90.4, 6.0, 0.238));
			data.Add(new DataPoint(99.4, 2.2, 0.312));
			data.Add(new DataPoint(88.6, 1.3, 0.197));
			data.Add(new DataPoint(54.9, 3.7, 0.177));
			data.Add(new DataPoint(99, 0.7, 0.0818));
			data.Add(new DataPoint(72, 2.0, 0.0826));
			data.Add(new DataPoint(99.6, 3.4, 0.143));
			data.Add(new DataPoint(99, 0.2, 0.128));
			data.Add(new DataPoint(86.1, 4.0, 0.115));
			data.Add(new DataPoint(92.6, 6.6, 0.096));
			data.Add(new DataPoint(61.3, 14.5, 0.162));
			data.Add(new DataPoint(56.8, 6.1, 0.151));
			return data;
		}
		public static List<DataPoint> GetCandleData()
		{
			var dateTime = new DateTime(2000, 1, 1);
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint(dateTime, 90, 125, 70, 115));
			dateTime = dateTime.AddMonths(1);
			datas.Add(new DataPoint(dateTime, 120, 150, 60, 70));
			dateTime = dateTime.AddMonths(1);
			datas.Add(new DataPoint(dateTime, 190, 200, 140, 160));
			dateTime = dateTime.AddMonths(1);
			datas.Add(new DataPoint(dateTime, 110, 160, 90, 140));
			dateTime = dateTime.AddMonths(1);
			datas.Add(new DataPoint(dateTime, 120, 200, 100, 180));
			dateTime = dateTime.AddMonths(1);
			datas.Add(new DataPoint(dateTime, 70, 100, 45, 50));
			return datas;
		}
		public static List<DataPoint> GetOhlcData()
		{
			var dateTime = new DateTime(2000, 1, 1);
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint(dateTime, 115, 125, 70, 90));
			dateTime = dateTime.AddMonths(1);
			datas.Add(new DataPoint(dateTime, 120, 150, 60, 70));
			dateTime = dateTime.AddMonths(1);
			datas.Add(new DataPoint(dateTime, 160, 200, 140, 190));
			dateTime = dateTime.AddMonths(1);
			datas.Add(new DataPoint(dateTime, 140, 160, 90, 110));
			dateTime = dateTime.AddMonths(1);
			datas.Add(new DataPoint(dateTime, 180, 200, 100, 120));
			dateTime = dateTime.AddMonths(1);
			datas.Add(new DataPoint(dateTime, 70, 100, 45, 50));
			return datas;
		}

		public static List<DataPoint> GetStackedAreaData1()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("2002", 6));
			datas.Add(new DataPoint("2003", 7.5));
			datas.Add(new DataPoint("2004", 6));
			datas.Add(new DataPoint("2005", 6.5));
			datas.Add(new DataPoint("2006", 7.4));
			datas.Add(new DataPoint("2007", 7.9));
			datas.Add(new DataPoint("2008", 7.5));
			datas.Add(new DataPoint("2009", 8.5));
			datas.Add(new DataPoint("2010", 4.8));
			datas.Add(new DataPoint("2011", 9.3));
			return datas;
		}

		public static List<DataPoint> GetStackedAreaData2()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("2002", 3.5));
			datas.Add(new DataPoint("2003", 4.9));
			datas.Add(new DataPoint("2004", 3.7));
			datas.Add(new DataPoint("2005", 7.5));
			datas.Add(new DataPoint("2006", 4.8));
			datas.Add(new DataPoint("2007", 2.6));
			datas.Add(new DataPoint("2008", 4.7));
			datas.Add(new DataPoint("2009", 3.7));
			datas.Add(new DataPoint("2010", 3.5));
			datas.Add(new DataPoint("2011", 3.6));
			return datas;
		}

		public static List<DataPoint> GetStackedAreaData3()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("2002", 8.1));
			datas.Add(new DataPoint("2003", 8.8));
			datas.Add(new DataPoint("2004", 6.7));
			datas.Add(new DataPoint("2005", 6.4));
			datas.Add(new DataPoint("2006", 4.0));
			datas.Add(new DataPoint("2007", 4.8));
			datas.Add(new DataPoint("2008", 7.4));
			datas.Add(new DataPoint("2009", 3.5));
			datas.Add(new DataPoint("2010", 8.3));
			datas.Add(new DataPoint("2011", 4.7));
			return datas;
		}

		public static List<DataPoint> GetStackedAreaData4()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("2002", 2.5));
			datas.Add(new DataPoint("2003", 6.1));
			datas.Add(new DataPoint("2004", 6.2));
			datas.Add(new DataPoint("2005", 1.8));
			datas.Add(new DataPoint("2006", 4.0));
			datas.Add(new DataPoint("2007", 6.5));
			datas.Add(new DataPoint("2008", 6.7));
			datas.Add(new DataPoint("2009", 7.2));
			datas.Add(new DataPoint("2010", 8.4));
			datas.Add(new DataPoint("2011", 6.9));
			return datas;
		}

		public static List<DataPoint> GetStackedArea100Data1()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("2006", 34));
			datas.Add(new DataPoint("2007", 20));
			datas.Add(new DataPoint("2008", 40));
			datas.Add(new DataPoint("2009", 51));
			datas.Add(new DataPoint("2010", 26));
			datas.Add(new DataPoint("2011", 37));
			datas.Add(new DataPoint("2012", 54));
			datas.Add(new DataPoint("2013", 44));
			datas.Add(new DataPoint("2014", 48));
			return datas;
		}
		public static List<DataPoint> GetStackedArea100Data2()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("2006", 51));
			datas.Add(new DataPoint("2007", 26));
			datas.Add(new DataPoint("2008", 37));
			datas.Add(new DataPoint("2009", 51));
			datas.Add(new DataPoint("2010", 26));
			datas.Add(new DataPoint("2011", 37));
			datas.Add(new DataPoint("2012", 43));
			datas.Add(new DataPoint("2013", 23));
			datas.Add(new DataPoint("2014", 55));
			return datas;
		}
		public static List<DataPoint> GetStackedArea100Data3()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("2006", 14));
			datas.Add(new DataPoint("2007", 34));
			datas.Add(new DataPoint("2008", 73));
			datas.Add(new DataPoint("2009", 51));
			datas.Add(new DataPoint("2010", 26));
			datas.Add(new DataPoint("2011", 37));
			datas.Add(new DataPoint("2012", 12));
			datas.Add(new DataPoint("2013", 16));
			datas.Add(new DataPoint("2014", 34));
			return datas;
		}
		public static List<DataPoint> GetStackedArea100Data4()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("2006", 37));
			datas.Add(new DataPoint("2007", 16));
			datas.Add(new DataPoint("2008", 53));
			datas.Add(new DataPoint("2009", 51));
			datas.Add(new DataPoint("2010", 26));
			datas.Add(new DataPoint("2011", 37));
			datas.Add(new DataPoint("2012", 54));
			datas.Add(new DataPoint("2013", 44));
			datas.Add(new DataPoint("2014", 23));
			return datas;
		}
		public static List<DataPoint> GetStackedBarData1()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("Jan", 6));
			datas.Add(new DataPoint("Feb", 8));
			datas.Add(new DataPoint("Mar", 12));
			datas.Add(new DataPoint("Apr", 15.5));
			datas.Add(new DataPoint("May", 20));
			datas.Add(new DataPoint("Jun", 24));
			datas.Add(new DataPoint("Jul", 28));
			datas.Add(new DataPoint("Aug", 32));
			datas.Add(new DataPoint("Sep", 33));
			datas.Add(new DataPoint("Oct", 35));
			datas.Add(new DataPoint("Nov", 40));
			datas.Add(new DataPoint("Dec", 42));
			return datas;
		}

		public static List<DataPoint> GetStackedBarData2()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("Jan", 6));
			datas.Add(new DataPoint("Feb", 8));
			datas.Add(new DataPoint("Mar", 11));
			datas.Add(new DataPoint("Apr", 16));
			datas.Add(new DataPoint("May", 21));
			datas.Add(new DataPoint("Jun", 25));
			datas.Add(new DataPoint("Jul", 27));
			datas.Add(new DataPoint("Aug", 31));
			datas.Add(new DataPoint("Sep", 34));
			datas.Add(new DataPoint("Oct", 34));
			datas.Add(new DataPoint("Nov", 41));
			datas.Add(new DataPoint("Dec", 42));
			return datas;
		}

		public static List<DataPoint> GetStackedBarData3()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("Jan", -1));
			datas.Add(new DataPoint("Feb", -1.5));
			datas.Add(new DataPoint("Mar", -2));
			datas.Add(new DataPoint("Apr", -2.5));
			datas.Add(new DataPoint("May", -3));
			datas.Add(new DataPoint("Jun", -3.5));
			datas.Add(new DataPoint("Jul", -4));
			datas.Add(new DataPoint("Aug", -4.5));
			datas.Add(new DataPoint("Sep", -5));
			datas.Add(new DataPoint("Oct", -5.5));
			datas.Add(new DataPoint("Nov", -6));
			datas.Add(new DataPoint("Dec", -6.5));
			return datas;
		}
		public static List<DataPoint> GetStackedBar100Data1()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint(2007, 453));
			datas.Add(new DataPoint(2008, 354));
			datas.Add(new DataPoint(2009, 282));
			datas.Add(new DataPoint(2010, 321));
			datas.Add(new DataPoint(2011, 333));
			datas.Add(new DataPoint(2012, 351));
			datas.Add(new DataPoint(2013, 403));
			datas.Add(new DataPoint(2014, 421));
			return datas;
		}
		public static List<DataPoint> GetStackedBar100Data2()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint(2007, 876));
			datas.Add(new DataPoint(2008, 564));
			datas.Add(new DataPoint(2009, 242));
			datas.Add(new DataPoint(2010, 121));
			datas.Add(new DataPoint(2011, 343));
			datas.Add(new DataPoint(2012, 451));
			datas.Add(new DataPoint(2013, 203));
			datas.Add(new DataPoint(2014, 431));
			return datas;
		}
		public static List<DataPoint> GetStackedBar100Data3()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint(2007, 356));
			datas.Add(new DataPoint(2008, 876));
			datas.Add(new DataPoint(2009, 898));
			datas.Add(new DataPoint(2010, 567));
			datas.Add(new DataPoint(2011, 456));
			datas.Add(new DataPoint(2012, 345));
			datas.Add(new DataPoint(2013, 543));
			datas.Add(new DataPoint(2014, 654));
			return datas;
		}
		public static List<DataPoint> GetStackedBar100Data4()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint(2007, 122));
			datas.Add(new DataPoint(2008, 444));
			datas.Add(new DataPoint(2009, 222));
			datas.Add(new DataPoint(2010, 231));
			datas.Add(new DataPoint(2011, 122));
			datas.Add(new DataPoint(2012, 333));
			datas.Add(new DataPoint(2013, 354));
			datas.Add(new DataPoint(2014, 100));
			return datas;
		}
		public static List<DataPoint> GetStackedColumnData1()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("Jan", 900));
			datas.Add(new DataPoint("Feb", 820));
			datas.Add(new DataPoint("Mar", 880));
			datas.Add(new DataPoint("Apr", 725));
			datas.Add(new DataPoint("May", 765));
			datas.Add(new DataPoint("Jun", 679));
			return datas;
		}

		public static List<DataPoint> GetStackedColumnData2()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("Jan", 190));
			datas.Add(new DataPoint("Feb", 226));
			datas.Add(new DataPoint("Mar", 194));
			datas.Add(new DataPoint("Apr", 250));
			datas.Add(new DataPoint("May", 222));
			datas.Add(new DataPoint("Jun", 181));
			return datas;
		}

		public static List<DataPoint> GetStackedColumnData3()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("Jan", 250));
			datas.Add(new DataPoint("Feb", 145));
			datas.Add(new DataPoint("Mar", 190));
			datas.Add(new DataPoint("Apr", 220));
			datas.Add(new DataPoint("May", 225));
			datas.Add(new DataPoint("Jun", 135));
			return datas;
		}

		public static List<DataPoint> GetStackedColumnData4()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("Jan", 150));
			datas.Add(new DataPoint("Feb", 120));
			datas.Add(new DataPoint("Mar", 115));
			datas.Add(new DataPoint("Apr", 125));
			datas.Add(new DataPoint("May", 132));
			datas.Add(new DataPoint("Jun", 137));
			return datas;
		}

		public static List<DataPoint> GetScatterData()
		{
			var datas = new List<DataPoint>();
			Java.Util.Random random = new Java.Util.Random();
			for (int i = 0; i < 1000; i++)
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
				datas.Add(new DataPoint(300 + (x * (random.NextDouble() + 0.12)),
						100 + (y * (random.NextDouble() + 0.12))));
			}
			return datas;
		}

		public static List<DataPoint> GetScatterDataForZoomPan()
		{
			var datas = new List<DataPoint>();
			Java.Util.Random random = new Java.Util.Random();
			for (int i = 0; i < 300; i++)
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
				datas.Add(new DataPoint(300 + (x * (random.NextDouble() + 0.12)),
						100 + (y * (random.NextDouble() + 0.12))));
			}
			return datas;
		}

		public static List<DataPoint> GetLineData()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("2010", 45.68));
			datas.Add(new DataPoint("2011", 89.25));
			datas.Add(new DataPoint("2012", 23.73));
			datas.Add(new DataPoint("2013", 43.5));
			datas.Add(new DataPoint("2014", 54.92));
			return datas;
		}
		public static List<DataPoint> GetStepLineData()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("2002", 36));
			datas.Add(new DataPoint("2003", 40));
			datas.Add(new DataPoint("2004", 34));
			datas.Add(new DataPoint("2005", 40));
			datas.Add(new DataPoint("2006", 44));
			datas.Add(new DataPoint("2007", 38));
			datas.Add(new DataPoint("2008", 30));
			return datas;
		}

		public static List<DataPoint> GetCategoryData()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("Bentley", 54));
			datas.Add(new DataPoint("Audi", 24));
			datas.Add(new DataPoint("BMW", 53));
			datas.Add(new DataPoint("Jaguar", 63));
			datas.Add(new DataPoint("Skoda", 35));
			return datas;
		}

		public static List<DataPoint> GetNumericalData()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint(2001, 75));
			datas.Add(new DataPoint(2002, 90));
			datas.Add(new DataPoint(2003, 85));
			datas.Add(new DataPoint(2004, 70));
			datas.Add(new DataPoint(2005, 55));
			datas.Add(new DataPoint(2006, 65));
			return datas;
		}
		public static List<DataPoint> GetData2()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("2010", 54));
			datas.Add(new DataPoint("2011", 24));
			datas.Add(new DataPoint("2012", 53));
			datas.Add(new DataPoint("2013", 63));
			datas.Add(new DataPoint("2014", 35));
			return datas;
		}

		public static List<DataPoint> GetData3()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("2010", 14));
			datas.Add(new DataPoint("2011", 54));
			datas.Add(new DataPoint("2012", 23));
			datas.Add(new DataPoint("2013", 53));
			datas.Add(new DataPoint("2014", 25));
			return datas;
		}

		public static List<DataPoint> GetFinancialData()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("2010", 873.8, 878.85, 855.5, 860.5));
			datas.Add(new DataPoint("2011", 861, 868.4, 835.2, 843.45));
			datas.Add(new DataPoint("2012", 846.15, 853, 838.5, 847.5));
			datas.Add(new DataPoint("2013", 846, 860.75, 841, 855));
			datas.Add(new DataPoint("2014", 841, 845, 827.85, 838.65));
			return datas;
		}

		public static List<DataPoint> GetSelectionData()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("Jan", 42));
			datas.Add(new DataPoint("Feb", 44));
			datas.Add(new DataPoint("Mar", 53));
			datas.Add(new DataPoint("Apr", 64));
			datas.Add(new DataPoint("May", 75));
			datas.Add(new DataPoint("Jun", 83));
			return datas;
		}

		public static List<DataPoint> GetTooltipData()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("2007", 1.61));
			datas.Add(new DataPoint("2008", 2.34));
			datas.Add(new DataPoint("2009", 2.16));
			datas.Add(new DataPoint("2010", 2.1));
			datas.Add(new DataPoint("2011", 1.61));
			datas.Add(new DataPoint("2012", 2.05));
			datas.Add(new DataPoint("2013", 2.5));
			datas.Add(new DataPoint("2014", 2.21));
			datas.Add(new DataPoint("2015", 2.34));
			return datas;
		}

		public static List<DataPoint> GetDateTimeValue()
		{
			var dateTime = new DateTime(2015, 1, 1);
			List<DataPoint> datas = new List<DataPoint>();
			datas.Add(new DataPoint(dateTime, 10d));
			dateTime = dateTime.AddMonths(1);
			datas.Add(new DataPoint(dateTime, 31d));
			dateTime = dateTime.AddMonths(1);
			datas.Add(new DataPoint(dateTime, 28d));
			dateTime = dateTime.AddMonths(1);
			datas.Add(new DataPoint(dateTime, 45d));
			dateTime = dateTime.AddMonths(1);
			datas.Add(new DataPoint(dateTime, 10d));
			dateTime = dateTime.AddMonths(1);
			datas.Add(new DataPoint(dateTime, 23d));
			dateTime = dateTime.AddMonths(1);
			datas.Add(new DataPoint(dateTime, 35d));
			dateTime = dateTime.AddMonths(1);
			datas.Add(new DataPoint(dateTime, 56d));
			dateTime = dateTime.AddMonths(1);
			datas.Add(new DataPoint(dateTime, 10d));
			dateTime = dateTime.AddMonths(1);
			datas.Add(new DataPoint(dateTime, 39d));
			dateTime = dateTime.AddMonths(1);
			datas.Add(new DataPoint(dateTime, 26d));
			dateTime = dateTime.AddMonths(1);
			datas.Add(new DataPoint(dateTime, 21d));
            dateTime = dateTime.AddMonths(1);
            datas.Add(new DataPoint(dateTime, 31d));
            return datas;
		}

		public static List<DataPoint> GetDateTimValue()
		{
			var dateTime = new DateTime(2014, 1, 1);
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint(dateTime, 10d));
			dateTime = dateTime.AddDays(1);
			datas.Add(new DataPoint(dateTime, 23d));
			dateTime = dateTime.AddDays(1);
			datas.Add(new DataPoint(dateTime, 22d));
			dateTime = dateTime.AddDays(1);
			datas.Add(new DataPoint(dateTime, 32d));
			dateTime = dateTime.AddDays(1);
			datas.Add(new DataPoint(dateTime, 31d));
			dateTime = dateTime.AddDays(1);
			datas.Add(new DataPoint(dateTime, 12d));
			dateTime = dateTime.AddDays(1);
			datas.Add(new DataPoint(dateTime, 26d));

			return datas;
		}

		public static List<DataPoint> GetSeriesData1()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("2005", 31));
			datas.Add(new DataPoint("2006", 28));
			datas.Add(new DataPoint("2007", 30));
			datas.Add(new DataPoint("2008", 36));
			datas.Add(new DataPoint("2009", 38));
			datas.Add(new DataPoint("2010", 39));
			return datas;
		}

		public static List<DataPoint> GetSeriesData2()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("2005", 35));
			datas.Add(new DataPoint("2006", 32));
			datas.Add(new DataPoint("2007", 34));
			datas.Add(new DataPoint("2008", 40));
			datas.Add(new DataPoint("2009", 42));
			datas.Add(new DataPoint("2010", 43));
			return datas;
		}

		public static List<DataPoint> GetSeriesData3()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("2005", 39));
			datas.Add(new DataPoint("2006", 36));
			datas.Add(new DataPoint("2007", 38));
			datas.Add(new DataPoint("2008", 44));
			datas.Add(new DataPoint("2009", 46));
			datas.Add(new DataPoint("2010", 47));
			return datas;
		}

		public static List<DataPoint> GetTriangularData()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("Bentley", 800));
			datas.Add(new DataPoint("Audi", 810));
			datas.Add(new DataPoint("BMW", 825));
			datas.Add(new DataPoint("Jaguar", 860));
			datas.Add(new DataPoint("Skoda", 875));
			return datas;
		}

		public static Color ConvertHexaToColor(uint hex)
		{
			var alpha = (hex & 0xFF000000) >> 24;
			var red = (hex & 0xFF0000) >> 16;
			var green = (hex & 0xFF00) >> 8;
			var blue = (hex & 0xFF);
			return Color.Argb((int)alpha, (int)red, (int)green, (int)blue);
		}

		public static List<DataPoint> GetPolarData1()
		{
			List<DataPoint> datas = new List<DataPoint>();
			datas.Add(new DataPoint("North", 80));
			datas.Add(new DataPoint("NorthEast", 85));
			datas.Add(new DataPoint("East", 78));
			datas.Add(new DataPoint("SouthEast", 90));
			datas.Add(new DataPoint("South", 78));
			datas.Add(new DataPoint("SouthWest", 83));
			datas.Add(new DataPoint("West", 79));
			datas.Add(new DataPoint("NorthWest", 88));

			return datas;
		}

		public static List<DataPoint> GetPolarData2()
		{
			List<DataPoint> datas = new List<DataPoint>();
			datas.Add(new DataPoint("North", 63));
			datas.Add(new DataPoint("NorthEast", 70));
			datas.Add(new DataPoint("East", 45));
			datas.Add(new DataPoint("SouthEast", 70));
			datas.Add(new DataPoint("South", 47));
			datas.Add(new DataPoint("SouthWest", 65));
			datas.Add(new DataPoint("West", 40));
			datas.Add(new DataPoint("NorthWest", 60));

			return datas;
		}

		public static List<DataPoint> GetPolarData3()
		{
			List<DataPoint> datas = new List<DataPoint>();
			datas.Add(new DataPoint("North", 42));
			datas.Add(new DataPoint("NorthEast", 40));
			datas.Add(new DataPoint("East", 25));
			datas.Add(new DataPoint("SouthEast", 40));
			datas.Add(new DataPoint("South", 20));
			datas.Add(new DataPoint("SouthWest", 45));
			datas.Add(new DataPoint("West", 25));
			datas.Add(new DataPoint("NorthWest", 40));

			return datas;
		}

		public static List<DataPoint> GetTechnicalIndicatorData()
		{
			var dateTime = new DateTime(1990, 1, 1);
			var datas1 = new List<DataPoint>();
			datas1.Add(new DataPoint(dateTime, 65.75, 67.27, 65.75, 65.98, 7938200));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 65.98, 65.70, 65.04, 65.11, 10185300));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 65.11, 65.05, 64.26, 64.97, 10835800));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 64.97, 65.16, 64.09, 64.29, 9613400));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 64.29, 62.73, 61.85, 62.44, 17175000));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 62.44, 62.02, 61.29, 61.47, 18040600));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 61.47, 62.75, 61.55, 61.59, 13456300));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 61.59, 64.78, 62.22, 64.64, 8045100));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 64.64, 64.50, 63.03, 63.28, 8608900));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 63.28, 63.70, 62.70, 63.59, 15025500));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 63.59, 64.45, 63.26, 63.61, 10065800));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 63.61, 64.56, 63.81, 64.52, 6178200));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 64.52, 64.84, 63.66, 63.91, 5478500));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 63.91, 65.30, 64.50, 65.22, 7964300));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 65.22, 65.36, 64.46, 65.06, 5679300));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 65.06, 64.54, 63.56, 63.65, 10758300));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 63.65, 64.03, 63.33, 63.73, 5665900));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 63.73, 63.40, 62.80, 62.83, 5833000));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 62.83, 63.75, 62.96, 63.60, 3500800));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 63.6, 63.64, 62.51, 63.51, 5044700));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 63.51, 64.03, 63.53, 63.76, 4871300));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 63.76, 63.77, 63.01, 63.65, 7040400));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 63.65, 63.95, 63.58, 63.79, 4727800));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 63.79, 63.47, 62.92, 63.25, 6334900));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 63.25, 63.96, 63.21, 63.48, 6823200));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 63.48, 63.63, 62.55, 63.50, 9718400));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 63.5, 63.25, 62.82, 62.90, 2827000));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 62.9, 62.34, 62.05, 62.18, 4942700));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 62.18, 62.86, 61.94, 62.81, 4582800));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 62.81, 63.06, 62.44, 62.83, 12423900));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 62.83, 63.16, 62.66, 63.09, 4940500));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 63.09, 62.89, 62.43, 62.66, 6132300));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 62.66, 62.39, 61.90, 62.25, 6263800));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 62.25, 61.69, 60.97, 61.50, 5008300));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 61.5, 61.87, 61.18, 61.79, 6662500));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 61.79, 63.41, 62.72, 63.16, 5254000));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 63.16, 64.40, 63.65, 63.89, 5356600));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 63.89, 63.45, 61.60, 61.87, 5052600));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 61.87, 62.35, 61.30, 61.54, 6266700));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 61.54, 61.49, 60.33, 61.06, 6190800));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 61.06, 60.78, 59.84, 60.09, 6452300));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 60.09, 59.62, 58.62, 58.80, 5954000));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 58.8, 59.60, 58.89, 59.53, 6250000));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 59.53, 60.96, 59.42, 60.68, 5307300));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 60.68, 61.12, 60.65, 60.73, 6192900));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 60.73, 61.19, 60.62, 61.19, 6355600));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 61.19, 61.07, 60.54, 60.97, 2946300));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 60.97, 61.05, 59.65, 59.75, 2257600));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 59.75, 60.58, 55.99, 59.93, 2872000));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 59.93, 60.12, 59.26, 59.73, 2737500));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 59.73, 60.11, 59.35, 59.57, 2589700));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 59.57, 60.40, 59.60, 60.10, 7315800));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 60.1, 60.31, 59.76, 60.28, 6883900));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 60.28, 61.68, 60.50, 61.50, 5570700));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 61.5, 62.72, 61.64, 62.26, 5976000));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 62.26, 64.08, 63.10, 63.70, 3641400));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 63.7, 64.60, 63.99, 64.39, 6711600));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 64.39, 64.45, 63.92, 64.25, 6427000));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 64.25, 65.40, 64.66, 64.70, 5863200));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 64.7, 65.86, 65.32, 65.75, 4711400));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 65.75, 65.22, 64.63, 64.75, 5930600));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 64.75, 65.39, 64.76, 65.04, 5602700));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 65.04, 65.30, 64.78, 65.18, 7487300));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 65.18, 65.09, 64.42, 65.09, 9085400));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 65.09, 65.64, 65.20, 65.25, 6455300));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 65.25, 65.59, 64.74, 64.84, 6135500));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 64.84, 65.84, 65.42, 65.82, 5846400));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 65.82, 66.75, 65.85, 66.00, 6681200));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 66, 67.41, 66.17, 67.41, 8780000));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 67.41, 68.61, 68.06, 68.41, 10780900));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 68.41, 68.91, 68.42, 68.76, 2336450));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 68.76, 69.58, 68.86, 69.01, 11902000));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 69.01, 69.14, 68.74, 68.94, 7513300));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 68.94, 68.73, 68.06, 68.65, 12074800));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 68.65, 68.79, 68.19, 68.67, 8785400));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 68.67, 69.75, 68.68, 68.74, 11373200));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 68.74, 68.82, 67.71, 67.76, 12378300));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 67.76, 69.05, 68.43, 69.00, 8458700));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 69, 68.39, 67.77, 68.02, 10779200));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 68.02, 67.94, 67.22, 67.72, 9665400));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 67.72, 68.15, 67.32, 67.32, 12258400));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 67.32, 67.95, 67.13, 67.32, 7563600));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 67.32, 68.00, 67.16, 67.96, 5509900));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 67.96, 68.89, 68.34, 68.61, 12135500));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 68.61, 69.47, 68.30, 68.51, 8462000));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 68.51, 68.69, 68.21, 68.62, 2011950));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 68.62, 68.39, 65.80, 68.37, 8536800));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 68.37, 67.75, 65.00, 62.00, 7624900));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 67.62, 67.04, 65.04, 67.00, 13694600));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 66, 66.83, 65.02, 67.60, 8911200));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 66.6, 66.98, 65.44, 66.73, 6679600));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 66.73, 66.84, 65.10, 66.11, 6451900));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 66.11, 66.59, 65.69, 66.38, 6739100));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 66.38, 67.98, 66.51, 67.67, 2103260));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 67.67, 69.21, 68.59, 68.90, 10551800));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 68.9, 69.96, 69.27, 69.44, 5261100));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 69.44, 69.01, 68.14, 68.18, 5905400));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 68.18, 68.93, 68.08, 68.14, 10283600));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 68.14, 68.60, 66.92, 67.25, 5006800));
			dateTime = dateTime.AddMonths(1);
			datas1.Add(new DataPoint(dateTime, 67.25, 67.77, 67.23, 67.77, 4110000));
			return datas1;
		}

        public static List<DataPoint> BubbleSeries()
        {
            DateTime dt = new DateTime(2000, 1, 1);

           var Datas = new List<DataPoint>()
            {
                new DataPoint ( dt.AddMonths(4),  70 , 5),
                new DataPoint ( dt.AddMonths(8),  50 , 8),
                new DataPoint ( dt.AddMonths(12),  -30 , 30),
                new DataPoint ( dt.AddMonths(16),  -70 , 10),
                new DataPoint ( dt.AddMonths(20),  40 , 12),
                new DataPoint ( dt.AddMonths(24),  80 , 13),
                new DataPoint ( dt.AddMonths(28),  -70 , 6),
                new DataPoint ( dt.AddMonths(32),  30 , 8),
                new DataPoint ( dt.AddMonths(36),  80 , 3),
                new DataPoint ( dt.AddMonths(40),  -30 , 5),
                new DataPoint ( dt.AddMonths(44),  -80 , 7),
                new DataPoint ( dt.AddMonths(48),  40 , 3),
                new DataPoint ( dt.AddMonths(52),  -50 , 8),
                new DataPoint ( dt.AddMonths(56),  -10 , 4),
                 new DataPoint ( dt.AddMonths(60),  -80 , 9),
                new DataPoint ( dt.AddMonths(64),  40 , 10),
                new DataPoint ( dt.AddMonths(68),  -50 , 6)
            };
            return Datas;
        }        

    }

	public class Data
	{
		public static List<DataPoint> GetDateTimeValue()
		{
			var dateTime = new DateTime(2014, 1, 1);

			var datas = new List<DataPoint>();

			datas.Add(new DataPoint(dateTime, 10d));
			dateTime = dateTime.AddYears(1);
			datas.Add(new DataPoint(dateTime, 30d));
			dateTime = dateTime.AddYears(1);
			datas.Add(new DataPoint(dateTime, 15d));
			dateTime = dateTime.AddYears(1);
			datas.Add(new DataPoint(dateTime, 65d));
			dateTime = dateTime.AddYears(1);
			datas.Add(new DataPoint(dateTime, 90d));
			dateTime = dateTime.AddYears(1);
			datas.Add(new DataPoint(dateTime, 85d));
			return datas;
		}

		public static List<DataPoint> GetAreaData()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("2010", 45));
			datas.Add(new DataPoint("2011", 56));
			datas.Add(new DataPoint("2012", 23));
			datas.Add(new DataPoint("2013", 43));
			datas.Add(new DataPoint("2014", Double.NaN));
			datas.Add(new DataPoint("2015", 54));
			datas.Add(new DataPoint("2016", 43));
			datas.Add(new DataPoint("2017", 23));
			datas.Add(new DataPoint("2018", 34));
			return datas;
		}

		public static List<DataPoint> GetData1()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("2010", 45));
			datas.Add(new DataPoint("2011", 86));
			datas.Add(new DataPoint("2012", 23));
			datas.Add(new DataPoint("2013", 43));
			datas.Add(new DataPoint("2014", 54));
			return datas;
		}
		public static List<DataPoint> GetCategoryData()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("Product A", 10));
			datas.Add(new DataPoint("Product B", 30));
			datas.Add(new DataPoint("Product C", 15));
			datas.Add(new DataPoint("Product D", 65));
			datas.Add(new DataPoint("Product E", 90));
			datas.Add(new DataPoint("Product F", 85));
			return datas;
		}

		public static List<DataPoint> GetNumericalData()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint(1, 54));
			datas.Add(new DataPoint(2, 24));
			datas.Add(new DataPoint(3, 53));
			datas.Add(new DataPoint(4, 63));
			datas.Add(new DataPoint(5, 35));
			return datas;
		}

		public static List<DataPoint> GetData2()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("2010", 54));
			datas.Add(new DataPoint("2011", 24));
			datas.Add(new DataPoint("2012", 53));
			datas.Add(new DataPoint("2013", 63));
			datas.Add(new DataPoint("2014", 35));
			return datas;
		}

		public static List<DataPoint> GetData3()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("2010", 14));
			datas.Add(new DataPoint("2011", 54));
			datas.Add(new DataPoint("2012", 23));
			datas.Add(new DataPoint("2013", 53));
			datas.Add(new DataPoint("2014", 25));
			return datas;
		}

		public static List<DataPoint> GetFinancialData()
		{
			var datas = new List<DataPoint>();
			datas.Add(new DataPoint("2010", 873.8, 878.85, 855.5, 860.5));
			datas.Add(new DataPoint("2011", 861, 868.4, 835.2, 843.45));
			datas.Add(new DataPoint("2012", 846.15, 853, 838.5, 847.5));
			datas.Add(new DataPoint("2013", 846, 860.75, 841, 855));
			datas.Add(new DataPoint("2014", 841, 845, 827.85, 838.65));
			return datas;
		}

		public static List<DataPoint> CrossingData()
               {
            var axisCrossingData = new List<DataPoint>();

            axisCrossingData.Add(new DataPoint("2000", 70, 5));
            axisCrossingData.Add(new DataPoint("2001", 50, 8));
            axisCrossingData.Add(new DataPoint("2002", -30, 30));
            axisCrossingData.Add(new DataPoint("2003", -70, 10));
            axisCrossingData.Add(new DataPoint("2004", 40, 12));
            axisCrossingData.Add(new DataPoint("2005", 80, 13));
            axisCrossingData.Add(new DataPoint("2006", -70, 6));
            axisCrossingData.Add(new DataPoint("2007", 30, 8));
            axisCrossingData.Add(new DataPoint("2008", 80, 3));
            axisCrossingData.Add(new DataPoint("2009", -30, 5));
            axisCrossingData.Add(new DataPoint("2010", -80, 7));
            axisCrossingData.Add(new DataPoint("2011", 40, 3));
            axisCrossingData.Add(new DataPoint("2012", -50, 8));
            axisCrossingData.Add(new DataPoint("2013", -10, 4));
            axisCrossingData.Add(new DataPoint("2014", -80, 9));
            axisCrossingData.Add(new DataPoint("2015", 40, 10));
            axisCrossingData.Add(new DataPoint("2016", -50, 6));

            return axisCrossingData;
        }
	}
}