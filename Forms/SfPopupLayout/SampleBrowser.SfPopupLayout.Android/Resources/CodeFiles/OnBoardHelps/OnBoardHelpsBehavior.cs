#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Threading.Tasks;
using SampleBrowser.Core;
using Xamarin.Forms;
using SampleBrowser.SfDataGrid;
using Syncfusion.SfDataGrid.XForms;

namespace SampleBrowser.SfPopupLayout
{
    public class OnBoardHelpsBehavior : Behavior<SampleView>
    {
        private Syncfusion.XForms.PopupLayout.SfPopupLayout popupLayout;
        private Image infoNotification;
        private Image resizingIllustration;
        private Image editIllustration;
        private Image swipeIllustration;
        private Image handSymbol;
        private Image dragAndDropIllustration;
        private RelativeLayout relativePage;
        private Label nextlabel;
        private Label oklabel;
        private int tappingCount = 0;
        private SwipingViewModel viewModel;
        private Syncfusion.SfDataGrid.XForms.SfDataGrid datagrid;
        protected override void OnAttachedTo(SampleView bindable)
        {
            base.OnAttachedTo(bindable);
            popupLayout = bindable.Content.FindByName<Syncfusion.XForms.PopupLayout.SfPopupLayout>("popupLayout");
            datagrid = bindable.Content.FindByName<Syncfusion.SfDataGrid.XForms.SfDataGrid>("dataGrid");
            relativePage = bindable.FindByName<RelativeLayout>("relativeLayout");
            relativePage.BackgroundColor = Color.FromRgba(0, 0, 0, 0.8);
            AddTapGeture();
            infoNotification = bindable.FindByName<Image>("InfoNotification");
            infoNotification.Source = ImageSource.FromResource("SampleBrowser.SfPopupLayout.Icons.InfoNotification.png");

            resizingIllustration = bindable.FindByName<Image>("ResizingIllustration");
            resizingIllustration.Source = ImageSource.FromResource("SampleBrowser.SfPopupLayout.Icons.ResizingIllustration.png");

            editIllustration = bindable.FindByName<Image>("EditIllustration");
            editIllustration.Source = ImageSource.FromResource("SampleBrowser.SfPopupLayout.Icons.EditIllustration.png");

            swipeIllustration = bindable.FindByName<Image>("SwipeIllustration");
            swipeIllustration.Source = ImageSource.FromResource("SampleBrowser.SfPopupLayout.Icons.SwipeIllustration.png");

            handSymbol = bindable.FindByName<Image>("HandSymbol");
            handSymbol.Source = ImageSource.FromResource("SampleBrowser.SfPopupLayout.Icons.HandSymbol.png");

            dragAndDropIllustration = bindable.FindByName<Image>("DragAndDropIllustration");
            dragAndDropIllustration.Source = ImageSource.FromResource("SampleBrowser.SfPopupLayout.Icons.DragAndDropIllustration.png");

            nextlabel = bindable.FindByName<Label>("label");
            oklabel = bindable.FindByName<Label>("oklabel");
            oklabel.IsVisible = false;
            viewModel = new SwipingViewModel();
            bindable.BindingContext = viewModel;
            viewModel.SetRowstoGenerate(30);
            datagrid.ItemsSource = viewModel.OrdersInfo;
            if (Device.RuntimePlatform == Device.UWP)
            {
                relativePage.Children.RemoveAt(0);
                infoNotification.IsVisible = false;
                oklabel.IsVisible = false;
                resizingIllustration.IsVisible = true;
                AnimateResizingIllustrationImage();
                tappingCount++;
            }
            else
                AnimateinfoNotificationImage();
        }

        private void AddTapGeture()
        {
            var tgr = new TapGestureRecognizer();
            relativePage.GestureRecognizers.Add(tgr);
            tgr.Tapped += (object sender, EventArgs e) => {
                if (tappingCount == 0)
                {
                    relativePage.Children.RemoveAt(0);
                    infoNotification.IsVisible = false;
                    oklabel.IsVisible = false;
                    resizingIllustration.IsVisible = true;
                    AnimateResizingIllustrationImage();
                    tappingCount++;
                }
                else if (tappingCount == 1)
                {
                    relativePage.Children.RemoveAt(0);
                    resizingIllustration.IsVisible = false;
                    oklabel.IsVisible = false;
                    editIllustration.IsVisible = true;
                    AnimateEditIllustrationImage();
                    tappingCount++;
                }
                else if (tappingCount == 2)
                {
                    relativePage.Children.RemoveAt(0);
                    editIllustration.IsVisible = false;
                    oklabel.IsVisible = false;
                    swipeIllustration.IsVisible = true;
                    AnimateSwipeIllustration();
                    tappingCount++;
                }
                else if (tappingCount == 3)
                {
                    relativePage.Children.RemoveAt(0);
                    swipeIllustration.IsVisible = false;
                    nextlabel.IsVisible = false;
                    handSymbol.IsVisible = true;
                    dragAndDropIllustration.IsVisible = true;
                    oklabel.IsVisible = true;
                    AnimateDragAndDropIllustration();
                    tappingCount++;
                }
                else
                {
                    handSymbol.IsVisible = false;
                    dragAndDropIllustration.IsVisible = false;
                    (relativePage.Parent as Grid).Children.RemoveAt(1);
                }
            };
        }

        private async void AnimateinfoNotificationImage()
        {
            // Where we animate image based on its yposition value.

            // Move to top yposition
            await infoNotification.TranslateTo(0, 0, 1000);
            // Move to initial yposition
            await infoNotification.TranslateTo(0, -50, 1000);
            // Repeat animation while infoNotification image was visible.
            if (infoNotification.IsVisible)
                AnimateinfoNotificationImage();
        }

        private async void AnimateResizingIllustrationImage()
        {
            // Where we animate image based on its xposition value.

            // Move to left xposition
            await resizingIllustration.TranslateTo(100, 0, 1000);
            // Move to initial xposition
            await resizingIllustration.TranslateTo(0, 0, 0);
            // Repeat animation while resizingIllustration was visible.
            if (resizingIllustration.IsVisible)
                AnimateResizingIllustrationImage();
        }

        private async void AnimateEditIllustrationImage()
        {
            // Where we animate image based on its Opacity value, we have change opacity value Simultaneously.

            // Default opacity value as zero and we set 1 as dynamically, we have dont this operation two time due to achive 
            // double click animate view.
            editIllustration.Opacity = 0;
            await editIllustration.FadeTo(1, 250);
            editIllustration.Opacity = 0;
            await editIllustration.FadeTo(1, 250);

            // Repeat animation while editIllustration image is visible.
            if (editIllustration.IsVisible)
            {
                await Task.Delay(1000);
                AnimateEditIllustrationImage();
            }
        }
        private async void AnimateSwipeIllustration()
        {
            // Where we animate image based on its xposition value.

            // Move to right xposition value
            await swipeIllustration.TranslateTo(150, 0, 2000);
            await swipeIllustration.TranslateTo(0, 0, 0);

            // Repeat animation while swipeIllustration image is visible.
            if (swipeIllustration.IsVisible)
                AnimateSwipeIllustration();
        }
        private async void AnimateDragAndDropIllustration()
        {

            handSymbol.AnchorY = 10;
            // Rotate View to 10 degree
            await handSymbol.RotateTo(10, 500);

            //transalte View to based on x, y point
            await handSymbol.TranslateTo(25, 25, 500);

            //Reset rotaion,x,y position
            handSymbol.Rotation = 0;
            await handSymbol.TranslateTo(0, 0, 0);

            //Repeat animation while both images are visible
            if (handSymbol.IsVisible && dragAndDropIllustration.IsVisible)
                AnimateDragAndDropIllustration();
        }
        protected override void OnDetachingFrom(SampleView bindable)
        {
            infoNotification = null;
            editIllustration = null;
            resizingIllustration = null;
            popupLayout = null;
            relativePage = null;
            base.OnDetachingFrom(bindable);
        }
    }
}
