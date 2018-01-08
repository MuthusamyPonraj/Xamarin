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
    internal class SetScheduleViewBehavior : Behavior<SampleView>
    {
        private Syncfusion.SfSchedule.XForms.SfSchedule schedule;
        private Picker viewPicker;
        protected override void OnAttachedTo(SampleView bindable)
        {
            base.OnAttachedTo(bindable);

            schedule = bindable.Content.FindByName<Syncfusion.SfSchedule.XForms.SfSchedule>("Schedule");
            viewPicker = bindable.PropertyView.FindByName<Picker>("viewPicker");

            if (bindable.GetType().Equals(typeof(RecursiveAppointments)))
                viewPicker.SelectedIndex = 3;
            else
                viewPicker.SelectedIndex = 2;

            viewPicker.SelectedIndexChanged += ViewPicker_SelectedIndexChanged;
       
        }

        private void ViewPicker_SelectedIndexChanged(object sender, EventArgs e)
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
                case 3:
                    schedule.ScheduleView = ScheduleView.MonthView;
                    break;
            }
        }

        protected override void OnDetachingFrom(SampleView bindable)
        {
            base.OnDetachingFrom(bindable);
            viewPicker.SelectedIndexChanged -= ViewPicker_SelectedIndexChanged;
            schedule = null;
            viewPicker = null;
        }
    }
}
