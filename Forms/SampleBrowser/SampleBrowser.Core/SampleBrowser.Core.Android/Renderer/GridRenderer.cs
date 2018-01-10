#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Xamarin.Forms;
using SampleBrowser.Droid;
using Xamarin.Forms.Platform.Android;
using SampleBrowser;
[assembly: ExportRenderer(typeof(GridViewExt), typeof(GridRenderer))]
namespace SampleBrowser.Droid
{
	class GridRenderer : ViewRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
		{
			base.OnElementChanged(e);
			Android.Views.View grid = this;
			if (grid != null)
			{
				string name = "grid_background";
				int resourceId = (int)typeof(Resource.Drawable).GetField(name).GetValue(null);
				grid.SetBackgroundResource(resourceId);
			}
		}
	}
}