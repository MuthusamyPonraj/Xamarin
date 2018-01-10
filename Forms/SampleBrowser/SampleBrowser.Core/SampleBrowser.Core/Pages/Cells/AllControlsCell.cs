#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Xamarin.Forms;

namespace SampleBrowser.Core
{
	/// <summary>
	/// ViewCell for displaying controls in ControlsHomePage.
	/// </summary>
	public class AllControlsCell : ViewCell
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AllControlsCell"/> class.
		/// </summary>
		public AllControlsCell()
		{
			View = new AllControlsView();
		}
	}

    /// <summary>
    /// ViewCell for displaying Samples in SamplesListPage.
    /// </summary>
    public class SamplesViewCell : ViewCell
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="LongLabel"/> class.
		/// </summary>
		public SamplesViewCell()
		{
			View = new SamplesListView();
		}
	}
}