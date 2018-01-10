#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfListView
{
    [Preserve(AllMembers = true)]

    #region DataTemplateSelectorBehavior

    public class DataTemplateSelectorBehavior : Behavior<Syncfusion.ListView.XForms.SfListView>
    {
        #region Fields

        private ViewModel DataTemplateSelectorViewModel;
        private Syncfusion.ListView.XForms.SfListView ListView;
        private ScrollView scrollView;

        #endregion

        #region Overrides
        protected override void OnAttachedTo(Syncfusion.ListView.XForms.SfListView bindable)
        {
            ListView = bindable;
            scrollView = bindable.FindByName<ScrollView>("scrollView");
            DataTemplateSelectorViewModel = new ViewModel();
            DataTemplateSelectorViewModel.ListView = ListView;
            ListView.BindingContext = DataTemplateSelectorViewModel;
            ListView.ItemsSource = DataTemplateSelectorViewModel.MessageInfo;
            ListView.Loaded += ListView_Loaded;
            base.OnAttachedTo(bindable);
        }

        private async void ListView_Loaded(object sender, ListViewLoadedEventArgs e)
        {
            ListView.HeightRequest = scrollView.Height;
            (ListView.LayoutManager as LinearLayout).ScrollToRowIndex(DataTemplateSelectorViewModel.MessageInfo.Count - 1);
            await Task.Delay(500);
        }

        protected override void OnDetachingFrom(Syncfusion.ListView.XForms.SfListView bindable)
        {
            ListView = null;
            base.OnDetachingFrom(bindable);
        }

        #endregion

    }

    #endregion
}
