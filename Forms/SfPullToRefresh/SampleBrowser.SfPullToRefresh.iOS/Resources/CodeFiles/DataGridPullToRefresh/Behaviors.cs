#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfDataGrid.XForms;
using Syncfusion.SfPullToRefresh.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleBrowser.SfPullToRefresh
{
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class DataGridPullToRefreshBehaviors : Behavior<SampleView>
    {
        private Syncfusion.SfPullToRefresh.XForms.SfPullToRefresh pullToRefresh;
        private DataGridPullToRefreshViewModel viewModel;
        private SfDataGrid dataGrid;
        private PickerExt transitionType;

        protected override void OnAttachedTo(SampleView bindable)
        {
            viewModel = new DataGridPullToRefreshViewModel();
            bindable.BindingContext = viewModel;
            pullToRefresh = bindable.FindByName<Syncfusion.SfPullToRefresh.XForms.SfPullToRefresh>("pullToRefresh");
            dataGrid = bindable.FindByName<SfDataGrid>("dataGrid");
            transitionType = bindable.FindByName<PickerExt>("transitionType");
            dataGrid.ItemsSource = viewModel.OrdersInfo;
            transitionType.Items.Add("Push");
            transitionType.Items.Add("SlideOnTop");
            transitionType.SelectedIndex = 1;
            transitionType.SelectedIndexChanged += OnSelectionChanged;
            pullToRefresh.Refreshing += PullToRefresh_Refreshing;
            base.OnAttachedTo(bindable);
        }
        private async void PullToRefresh_Refreshing(object sender, EventArgs e)
        {
            pullToRefresh.IsRefreshing = true;
            await Task.Delay(2000);
            this.dataGrid.IsBusy = true;
            await Task.Delay(new TimeSpan(0, 0, 2));
            this.viewModel.ItemsSourceRefresh();
            this.dataGrid.IsBusy = false;
            pullToRefresh.IsRefreshing = false;
        }
        private void OnSelectionChanged(object sender, EventArgs e)
        {
            if (transitionType.SelectedIndex == 0)
            {
                pullToRefresh.ProgressBackgroundColor = Color.FromHex("0065ff");
                pullToRefresh.ProgressStrokeColor = Color.FromHex("#ffffff");
                pullToRefresh.TransitionMode = TransitionType.Push;
            }
            else
            {
                pullToRefresh.ProgressBackgroundColor = Color.FromHex("0065ff");
                pullToRefresh.ProgressStrokeColor = Color.FromHex("#ffffff");
                pullToRefresh.TransitionMode = TransitionType.SlideOnTop;
            }
        }
        protected override void OnDetachingFrom(SampleView bindable)
        {
            transitionType.SelectedIndexChanged -= OnSelectionChanged;
            pullToRefresh.Refreshing -= PullToRefresh_Refreshing;
            pullToRefresh = null;
            dataGrid = null;
            transitionType = null;
            base.OnDetachingFrom(bindable);
        }
    }
}
