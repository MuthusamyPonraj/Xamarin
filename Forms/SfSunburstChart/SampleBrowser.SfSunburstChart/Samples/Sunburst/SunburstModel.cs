#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfSunburstChart
{
   [Preserve(AllMembers = true)]
	public class SunburstModel
	{
		public string Quarter { get; set; }
		public string Month { get; set; }
		public string Week { get; set; }
		public double Sales { get; set; }
	}
}
