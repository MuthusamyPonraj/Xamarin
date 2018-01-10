#region Copyright Syncfusion Inc. 2001 - 2017
// Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfDataGrid;
using Xamarin.Forms;
using Syncfusion.SfDataGrid.XForms;

namespace SampleBrowser.SfDataGrid
{
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class Green : DataGridStyle
	{
		public Green ()
		{
		}

        public override Color GetHeaderBackgroundColor()
        {
            return Color.FromRgb (242, 242, 242);
        }

		public override Color GetSelectionBackgroundColor ()
		{
			return Color.FromRgb (123, 149, 52);
		}

		public override Color GetSelectionForegroundColor ()
		{
			return Color.FromRgb (255, 255, 255);
		}

		public override Color GetCaptionSummaryRowBackgroundColor ()
		{
			return Color.FromRgb (224, 224, 224);
		}

		public override Color GetCaptionSummaryRowForegroundColor ()
		{
			return Color.FromRgb (51, 51, 51);
		}

		public override Color GetBorderColor ()
		{
			return Color.FromRgb (180, 180, 180);
		}

		public override Color GetAlternatingRowBackgroundColor()
		{
			return Color.FromRgb (248, 249, 229);
		}
	}
}

