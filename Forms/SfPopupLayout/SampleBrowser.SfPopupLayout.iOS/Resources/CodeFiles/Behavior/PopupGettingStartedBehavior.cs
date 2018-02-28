#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using SampleBrowser.Core;
using Syncfusion.XForms.PopupLayout;
using Xamarin.Forms;

namespace SampleBrowser.SfPopupLayout
{
    public class PopupGettingStartedBehavior : Behavior<SampleView>
    {
        private Syncfusion.SfPopupLayout.XForms.SfPopupLayout popupLayout;
        private Picker animatePicker;
        private Picker translationPicker;
        private Button relativePosition;
        private Grid MainLayout;
        private Picker buttonlayoutPicker;
        private Button showPopupCenter;
      
        protected override void OnAttachedTo(SampleView bindable)
        {
            base.OnAttachedTo(bindable);
            popupLayout = bindable.Content.FindByName<Syncfusion.SfPopupLayout.XForms.SfPopupLayout>("popupLayout");
            SetDefaultValues();

            animatePicker = bindable.FindByName<Picker>("AnimationTypePicker");
            buttonlayoutPicker = bindable.FindByName<Picker>("ButtonlayoutTypePicker");
            translationPicker = bindable.FindByName<Picker>("RelativePositionPicker");
            relativePosition = bindable.FindByName<Button>("RelativeButton");
            showPopupCenter = bindable.FindByName<Button>("centerPositionButton");
            MainLayout = bindable.FindByName<Grid>("mainLayout");
            AddGesture();
           
            animatePicker.SelectedIndexChanged += AnimationPicker_SelectedIndexChanged;
            buttonlayoutPicker.SelectedIndexChanged+= ButtonlayoutPicker_SelectedIndexChanged;
            relativePosition.Clicked+= RelativePosition_Clicked;
            showPopupCenter.Clicked+= ShowPopupCenter_Clicked;
            buttonlayoutPicker.SelectedIndex = 2;
            animatePicker.SelectedIndex = 0;
            translationPicker.SelectedIndex = 8;
        }

        private void ShowPopupCenter_Clicked(object sender, EventArgs e)
        {
            popupLayout.ShowPopup();
        }

        private void SetDefaultValues()
        {
            popupLayout.PopupView.HeightRequest = 200;
            popupLayout.PopupView.WidthRequest = 200;
            popupLayout.PopupView.HeaderTitle = "Popup";
            popupLayout.PopupView.AcceptButtonText = "Ok";
            popupLayout.PopupView.DeclineButtonText = "Decline";
            popupLayout.PopupView.LayoutAppearance = LayoutAppearance.OneButton;
            popupLayout.PopupView.PopupMessage = "This is a one button layout";
            popupLayout.PopupView.BackgroundColor = Color.White;
            popupLayout.PopupView.PopupStyle.AcceptButtonBackgroundColor = Color.White;
            popupLayout.PopupView.PopupStyle.HeaderBackgroundColor = Color.White;
            popupLayout.PopupView.PopupStyle.MessageBackgroundColor = Color.White;
            popupLayout.PopupView.PopupStyle.AcceptButtonTextColor = Color.Blue;
            popupLayout.PopupView.PopupStyle.DeclineButtonTextColor = Color.Blue;
            popupLayout.PopupView.PopupStyle.DeclineButtonBackgroundColor = Color.White;
            popupLayout.PopupView.PopupStyle.HeaderTextAlignment = TextAlignment.Start;
        }

        private void AddGesture()
        {
            var tgr = new TapGestureRecognizer();
            tgr.Tapped += (sender, e) => { popupLayout.ShowPopupAtTouchPoint();};
            MainLayout.GestureRecognizers.Add(tgr);
        }

        private void RelativePosition_Clicked(object sender, EventArgs e)
        {
            if (translationPicker != null)
                SetRelativePosition(translationPicker.SelectedIndex);
            else
            popupLayout.ShowPopup();
        }

        private void ButtonlayoutPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as Picker).SelectedIndex)
            {
                case 0:
                    popupLayout.PopupView.ShowHeader = true;
                    popupLayout.PopupView.ShowFooter = true;
                    popupLayout.PopupView.LayoutAppearance = LayoutAppearance.OneButton;
                    popupLayout.PopupView.PopupMessage = "This is a one button layout";
                    popupLayout.ShowPopup();
                    break;
                case 1:
                    popupLayout.PopupView.ShowHeader = true;
                    popupLayout.PopupView.ShowFooter = true;
                    popupLayout.PopupView.LayoutAppearance = LayoutAppearance.TwoButton;
                    popupLayout.PopupView.PopupMessage = "This is a Two button layout";
                    popupLayout.ShowPopup();
                    break;
                case 2:
                    popupLayout.PopupView.ShowHeader = false;
                    popupLayout.PopupView.ShowFooter = false;
                    popupLayout.PopupView.PopupMessage = "This is a custom popup layout";
                    popupLayout.ShowPopup();
                    break;
            }
        }

        private void SetRelativePosition(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    popupLayout.ShowPopupRelativeToView(relativePosition as View, RelativePosition.AlignToLeftOf);
                    break;
                case 1:
                    popupLayout.ShowPopupRelativeToView(relativePosition as View, RelativePosition.AlignTop);
                    break;
                case 2:
                    popupLayout.ShowPopupRelativeToView(relativePosition as View, RelativePosition.AlignBottom);
                    break;
                case 3:
                    popupLayout.ShowPopupRelativeToView(relativePosition as View, RelativePosition.AlignToRightOf);
                    break;
                case 4:
                    popupLayout.ShowPopupRelativeToView(relativePosition as View, RelativePosition.AlignTopLeft);
                    break;
                case 5:
                    popupLayout.ShowPopupRelativeToView(relativePosition as View, RelativePosition.AlignTopRight);
                    break;
                case 6:
                    popupLayout.ShowPopupRelativeToView(relativePosition as View, RelativePosition.AlignBottomLeft);
                    break;
                case 7:
                    popupLayout.ShowPopupRelativeToView(relativePosition as View, RelativePosition.AlignBottomRight);
                    break;
                case 8:
                    popupLayout.ShowPopup();
                    break;
            }
        }

        private void AnimationPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as Picker).SelectedIndex)
            {
                case 0:
                    popupLayout.PopupView.PopupAnimation = PopupAnimation.Fade;
                    break;
                case 1:
                    popupLayout.PopupView.PopupAnimation = PopupAnimation.SlideHorizontally;
                    break;
                case 2:
                    popupLayout.PopupView.PopupAnimation = PopupAnimation.SlideVertically;
                    break;
                case 3:
                    popupLayout.PopupView.PopupAnimation = PopupAnimation.Zoom;
                    break;
                case 4:
                    popupLayout.PopupView.PopupAnimation = PopupAnimation.None;
                    break;
            }
        }

        protected override void OnDetachingFrom(SampleView bindable)
        {
            animatePicker.SelectedIndexChanged -= AnimationPicker_SelectedIndexChanged;
            buttonlayoutPicker.SelectedIndexChanged -= ButtonlayoutPicker_SelectedIndexChanged;
            relativePosition.Clicked -= RelativePosition_Clicked;
            animatePicker = null;
            buttonlayoutPicker = null;
            translationPicker = null;
            popupLayout = null;
            relativePosition = null;
            base.OnDetachingFrom(bindable);
        }
    }
}
