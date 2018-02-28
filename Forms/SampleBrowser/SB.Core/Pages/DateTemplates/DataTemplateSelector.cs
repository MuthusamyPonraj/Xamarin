#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
    public class ChartSampleViewTemplateSelector : DataTemplateSelector
    {
        #region fields

        private readonly DataTemplate labelSelected;

        #endregion

        #region ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="ChartSampleViewTemplateSelector"/> class.
        /// </summary>
        public ChartSampleViewTemplateSelector()
		{
            labelSelected = new DataTemplate(typeof(DefaultLabelTemplate));
        }

        #endregion

        #region methods

        /// <summary>
        /// Method for selecting Template.
        /// </summary>
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
		{
			var listView = container as SfListView;
			if (listView == null) return null;

			var sampleModel = item as SampleModel;
			if (sampleModel == null) return null;

            if (listView.SelectedItem != sampleModel)
                sampleModel.TextColor = Device.RuntimePlatform == Device.UWP && Device.Idiom != TargetIdiom.Phone ? Color.White : Color.Black;
            else
                sampleModel.TextColor = Device.RuntimePlatform == Device.UWP && Device.Idiom != TargetIdiom.Phone ? Color.FromHex("#F3C746") : Color.FromHex("#007ED6");

            return labelSelected;
        }

        #endregion
    }
}