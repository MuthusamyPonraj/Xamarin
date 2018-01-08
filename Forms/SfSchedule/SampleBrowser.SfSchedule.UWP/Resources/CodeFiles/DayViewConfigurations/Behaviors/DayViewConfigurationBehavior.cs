#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfSchedule.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleBrowser.SfSchedule
{
    class DayViewConfigurationBehavior : Behavior<SampleView>
    {
        private Syncfusion.SfSchedule.XForms.SfSchedule schedule;
        private Slider startTimeSlider;
        private Slider endTimeSlider;
        private Picker viewPicker;
        private DatePicker datePicker;

        #region OnAttached
        protected override void OnAttachedTo(SampleView bindable)
        {
            schedule = (bindable.Content as Grid).Children[0] as Syncfusion.SfSchedule.XForms.SfSchedule;

            startTimeSlider = bindable.PropertyView.FindByName<Slider>("startTimeSlider");
            endTimeSlider = bindable.PropertyView.FindByName<Slider>("endTimeSlider");
            viewPicker = bindable.PropertyView.FindByName<Picker>("viewPicker");
            datePicker = bindable.PropertyView.FindByName<DatePicker>("datePicker");

            viewPicker.SelectedIndex = 0;

            startTimeSlider.ValueChanged += StartTimeSlider_ValueChanged;
            endTimeSlider.ValueChanged += EndTimeSlider_ValueChanged;
            viewPicker.SelectedIndexChanged += ViewPicker_SelectedIndexChanged;
            datePicker.DateSelected += DatePicker_DateSelected;

            SetNonAccessibleBlocks();
        }
        #endregion

        #region DatePicker_DateSelected
        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            DatePickerGoToDate(e.NewDate);
        }
        #endregion

        #region ViewPicker_SelectedIndexChanged
        private void ViewPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetScheduleView(sender);
        }
        #endregion

        #region EndTimeSlider_ValueChanged
        private void EndTimeSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (e.NewValue >= startTimeSlider.Value)
                (schedule.BindingContext as ConfigurationViewModel).EndHour = (int)e.NewValue;
            else
                endTimeSlider.Value = startTimeSlider.Value;
        }
        #endregion

        #region StartTimeSlider_ValueChanged
        private void StartTimeSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (e.NewValue <= endTimeSlider.Value)
                (schedule.BindingContext as ConfigurationViewModel).WorkStartHour = (int)e.NewValue;
            else
                startTimeSlider.Value = endTimeSlider.Value;
        }
        #endregion

        #region SetNonAccessibleBlocks

        private void SetNonAccessibleBlocks()
        {
            if (Device.RuntimePlatform == "Android" || Device.RuntimePlatform == "iOS")
            {
                NonAccessibleBlocksCollection nonAccessibleBlocks = new NonAccessibleBlocksCollection();
                var nonAccessibleBlock = new NonAccessibleBlock();
                nonAccessibleBlock.StartTime = 13;
                nonAccessibleBlock.EndTime = 14;
                nonAccessibleBlock.Text = "Lunch time";
                nonAccessibleBlocks.Add(nonAccessibleBlock);
                schedule.DayViewSettings.NonAccessibleBlocks = nonAccessibleBlocks;
                schedule.WeekViewSettings.NonAccessibleBlocks = nonAccessibleBlocks;
                schedule.WorkWeekViewSettings.NonAccessibleBlocks = nonAccessibleBlocks;
            }

        }

        #endregion

        #region SetScheduleView
        internal void SetScheduleView(object sender)
        {
            switch ((sender as Picker).SelectedIndex)
            {
                case 0:
                    schedule.ScheduleView = ScheduleView.DayView;
                    break;
                case 1:
                    schedule.ScheduleView = ScheduleView.WeekView;
                    break;
                case 2:
                    schedule.ScheduleView = ScheduleView.WorkWeekView;
                    break;
            }
        }
        #endregion

        #region DatePickerGoToDate
        internal void DatePickerGoToDate(DateTime date)
        {
            schedule.MoveToDate = date;
        }
        #endregion

        #region OnDetachingFrom
        protected override void OnDetachingFrom(SampleView bindable)
        {
            startTimeSlider.ValueChanged -= StartTimeSlider_ValueChanged;
            endTimeSlider.ValueChanged -= EndTimeSlider_ValueChanged;
            viewPicker.SelectedIndexChanged -= ViewPicker_SelectedIndexChanged;
            datePicker.DateSelected -= DatePicker_DateSelected;

            schedule = null;
            startTimeSlider = null;
            endTimeSlider = null;
            viewPicker = null;
            datePicker = null;
        }
        #endregion
    }
}
