#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.ListView.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.Core
{
	/// <summary>
    /// DataTemplateSelector for Selecting Images based on Selection in ChartTypesView
    /// </summary>
    public class ImageSelector : DataTemplateSelector
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageSelector"/> class.
        /// </summary>
        public ImageSelector()
		{
			imageSelected = new DataTemplate(typeof(ImageSelectedViewCell));
			imageNotSelected = new DataTemplate(typeof(ImageNotSelectedViewCell));
        }

        /// <summary>
        /// Method for selecting Template.
        /// </summary>
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
		{
			var listView = container as SfListView;
			if (listView == null)
				return null;

			var data = item as SamplesModel;
			if (data == null)
				return null;


			return (listView.SelectedItem != data) ? imageNotSelected : imageSelected;
		}

		private readonly DataTemplate imageSelected;
		private readonly DataTemplate imageNotSelected;
	}
}