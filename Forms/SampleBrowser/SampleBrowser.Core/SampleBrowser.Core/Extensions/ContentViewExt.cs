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
	/// Content View from which all samples has been inherited
	/// </summary>
	public class SampleView : ContentView
	{

		/// <summary>
		/// Initializes a new instance of the <see cref="SampleView"/> class.
		/// </summary>
		public SampleView()
		{
		}

		/// <summary>
		/// View from which property view for samples has been included
		/// </summary>
		public View PropertyView
		{
			get;
			set;
		}

		/// <summary>
		/// Hooked when sample view disappears
		/// </summary>
		public virtual void OnDisappearing()
        {

        }

        /// <summary>
        /// Hooked when sample view appears
        /// </summary>
        public virtual void OnAppearing()
        {

        }
    }
}