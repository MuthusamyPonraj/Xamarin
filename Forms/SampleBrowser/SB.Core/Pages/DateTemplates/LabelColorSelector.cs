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
    /// DataTemplateSelector for Selecting Label color on Selection in AllControlsSamplePage.
    /// </summary>
    public class LabelColorSelector : DataTemplateSelector
    {
        #region fields
        
        private readonly DataTemplate labelSelected;

        #endregion

        #region ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelColorSelector"/> class.
        /// </summary>
        public LabelColorSelector()
        {
            labelSelected = new DataTemplate(typeof(DefaultLabelTemplate));
        }

        #endregion

        #region methods

        /// <summary>
        /// Method for selecting template.
        /// </summary>
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var listView = container as SfListView;
            if (listView == null)
                return null;

            var data = item as SampleModel;
            if (data == null)
                return null;
            else
            {
                if (listView.SelectedItem != data)
                    data.TextColor = Device.RuntimePlatform == Device.UWP && Device.Idiom != TargetIdiom.Phone ? Color.White : Color.Black;
                else
                    data.TextColor = Device.RuntimePlatform == Device.UWP && Device.Idiom != TargetIdiom.Phone ? Color.FromHex("#F3C746") : Color.FromHex("#007ED6");
                return labelSelected;
            }
        }

        #endregion
    }

    /// <summary>
    /// DataTemplateSelector for Selecting Samples on selection in CodeViewerPage.
    /// </summary>
    public class CodeLabelSelector : DataTemplateSelector
    {
        #region fields

        private readonly DataTemplate labelSelected;

        private readonly DataTemplate labelNotSelected;

        #endregion

        #region ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="CodeLabelSelector"/> class.
        /// </summary>
        public CodeLabelSelector()
        {
            labelSelected = new DataTemplate(typeof(CodeViewSelectedLabelTemplate));
            labelNotSelected = new DataTemplate(typeof(CodeViewUnSelectedLabelTemplate));
        }

        #endregion

        #region methods

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

        #endregion
    }
}