#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Xamarin.Forms;

namespace SampleBrowser
{
    public class TemplateSelector : DataTemplateSelector
    {
        #region ctor

        public TemplateSelector()
        {
            DefaultControlItemTemplate = new DataTemplate(typeof(DefaultControlItemTempate));
            GroupingControlItemTemplate = new DataTemplate(typeof(GroupingControlItemTemplate));
            GroupingSampleItemTemplate = new DataTemplate(typeof(GroupingSampleItemTemplate));
        }

        #endregion

        #region properties

        public static bool GroupingEnabled { get; set; }

        public DataTemplate DefaultControlItemTemplate { get; set; }

        public DataTemplate GroupingControlItemTemplate { get; set; }

        public DataTemplate GroupingSampleItemTemplate { get; set; }

        #endregion

        #region methods

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return !GroupingEnabled ? DefaultControlItemTemplate
                : (item is ControlModel) ? GroupingControlItemTemplate : GroupingSampleItemTemplate;
        }

        #endregion
    }
}
