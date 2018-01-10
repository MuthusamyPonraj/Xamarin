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
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleBrowser.SfSchedule
{
    internal class AgendaViewBehavior : Behavior<SampleView>
    {
        private Syncfusion.SfSchedule.XForms.SfSchedule schedule;

        protected override void OnAttachedTo(SampleView bindable)
        {
            base.OnAttachedTo(bindable);
            schedule = bindable.Content.FindByName<Syncfusion.SfSchedule.XForms.SfSchedule>("schedule");
            schedule.SelectedDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            GetSelectedDateMeeting();
            schedule.CellTapped += ScheduleCellTapped;
        }

        private void GetSelectedDateMeeting()
        {
            var viewModel = (this.schedule.BindingContext as AgendaViewModel);
            viewModel.SelectedDateMeetings = new ObservableCollection<Meeting>();
            foreach (var meeting in viewModel.Meetings)
            {
                if (meeting.From.Date.Equals(((DateTime)schedule.SelectedDate).Date))
                    viewModel.SelectedDateMeetings.Add(meeting);
            }
            viewModel.SelectedDate = ((DateTime)schedule.SelectedDate).Date.ToString("MMMM dd yyyy");
        }

        protected override void OnDetachingFrom(SampleView bindable)
        {
            base.OnDetachingFrom(bindable);
            schedule.CellTapped -= ScheduleCellTapped;
            schedule = null;
        }

        private void ScheduleCellTapped(object sender, CellTappedEventArgs e)
        {
            var viewModel = (this.schedule.BindingContext as AgendaViewModel);
            viewModel.SelectedDate = e.Datetime.Date.ToString("MMMM dd yyyy");

            if (!schedule.MonthViewSettings.BlackoutDates.Contains(e.Datetime.Date))
            {
                viewModel.SelectedDateMeetings = new ObservableCollection<Meeting>();
                if (e.Appointments != null)
                {
                    foreach (var item in e.Appointments)
                    {
                        viewModel.SelectedDateMeetings.Add(item as Meeting);
                    }
                }
            }
        }
    }
}
