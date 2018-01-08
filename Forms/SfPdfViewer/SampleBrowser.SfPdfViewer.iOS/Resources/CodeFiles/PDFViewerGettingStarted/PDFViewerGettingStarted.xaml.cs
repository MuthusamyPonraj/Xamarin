#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfPdfViewer.XForms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SampleBrowser.Core;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfPdfViewer
{
    [Preserve(AllMembers = true)]
    public partial class PDFViewerGettingStarted : SampleView
    {
		public PDFViewerGettingStarted()
		{
			InitializeComponent();

			if (Device.Idiom == TargetIdiom.Phone)
			{
				Content = new PDFViewerGettingStarted_Phone();
			}
			else if(Device.Idiom == TargetIdiom.Tablet)
			{
				Content = new PDFViewerGettingStarted_Tablet();
			}
            else if(Device.Idiom == TargetIdiom.Desktop)
            {
                Content = new PDFViewerGettingStarted_Desktop();
            }

		}

    }

}

