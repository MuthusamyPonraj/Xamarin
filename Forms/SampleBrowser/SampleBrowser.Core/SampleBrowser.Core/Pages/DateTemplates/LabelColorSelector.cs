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
    /// DataTemplateSelector for Selecting Label color on Selection in AllCotntrolsSamplePage.
    /// </summary>
    public class LabelColorSelector : DataTemplateSelector
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LabelColorSelector"/> class.
        /// </summary>
        public LabelColorSelector()
        {
            labelSelected = new DataTemplate(typeof(LabelSelectedViewCell));
        }

        /// <summary>
        /// Method for selecting template.
        /// </summary>
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var listView = container as SfListView;
            if (listView == null)
                return null;

            var data = item as SamplesModel;
            if (data == null)
                return null;
            else
            {
                if (listView.SelectedItem != data)
                    data.TextColor = Device.RuntimePlatform == Device.UWP ? Color.White : Color.Black;
                else
                    data.TextColor = Device.RuntimePlatform == Device.UWP ? Color.FromHex("#F3C746") : Color.FromHex("#007ED6");
                return labelSelected;
            }
        }

        private readonly DataTemplate labelSelected;
    }

	/// <summary>
	/// DataTemplateSelector for Selecting Samples on selection in CodeViewerPage.
	/// </summary>
	public class CodeLabelSelector : DataTemplateSelector
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CodeLabelSelector"/> class.
        /// </summary>
        public CodeLabelSelector()
        {
            labelSelected = new DataTemplate(typeof(SelectedCell));
            labelNotSelected = new DataTemplate(typeof(NotSelectedCell));
        }

        /// <summary>
        /// Method for selecting template.
        /// </summary>
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var listView = container as SfListView;
            if (listView == null)
                return null;


            var data = item as string;
            if (data == null)
                return null;


            return (listView.SelectedItem as string != data) ? labelNotSelected : labelSelected;
        }

        private readonly DataTemplate labelSelected;
        private readonly DataTemplate labelNotSelected;
    }
}