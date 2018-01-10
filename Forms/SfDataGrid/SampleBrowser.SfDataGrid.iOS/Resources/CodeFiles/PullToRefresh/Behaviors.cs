#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleBrowser.SfDataGrid
{
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class PullToRefreshBehavior : Behavior<SampleView>
    {
        private Syncfusion.SfPullToRefresh.XForms.SfPullToRefresh pullToRefresh;
        private Syncfusion.SfDataGrid.XForms.SfDataGrid datagrid;
        private GettingStartedViewModel viewModel;

        protected override void OnAttachedTo(SampleView bindable)
        {
            viewModel = new GettingStartedViewModel();
            bindable.BindingContext = viewModel;
            pullToRefresh = bindable.FindByName<Syncfusion.SfPullToRefresh.XForms.SfPullToRefresh>("pullToRefresh");
            datagrid = bindable.FindByName<Syncfusion.SfDataGrid.XForms.SfDataGrid>("dataGrid");
            datagrid.ItemsSource = viewModel.OrdersInfo;
            pullToRefresh.Refreshing += PullToRefresh_Refreshing;
            base.OnAttachedTo(bindable);
        }

        private async void PullToRefresh_Refreshing(object sender, EventArgs e)
        {
            pullToRefresh.IsRefreshing = true;
            datagrid.IsBusy = true;
            await Task.Delay(new TimeSpan(0, 0, 2));
            viewModel.ItemsSourceRefresh();
            datagrid.IsBusy = false;
            pullToRefresh.IsRefreshing = false;
        }

        protected override void OnDetachingFrom(BindableObject bindable)
        {
            pullToRefresh.Refreshing -= PullToRefresh_Refreshing;
            pullToRefresh = null;
            datagrid = null;
            viewModel = null;
            base.OnDetachingFrom(bindable);
        }
    }
}
