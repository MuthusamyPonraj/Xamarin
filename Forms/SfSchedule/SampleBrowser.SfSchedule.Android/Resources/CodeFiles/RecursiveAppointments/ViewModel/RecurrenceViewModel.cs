#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfSchedule
{
	[Preserve(AllMembers = true)]
	public class RecurrenceViewModel
	{
		#region Properties

		public ScheduleAppointmentCollection RecursiveAppointmentCollection { get; set; }

		#endregion Properties

		#region Constructor

		public RecurrenceViewModel()
		{
			CreateRecurrsiveAppointments();

		}

		#endregion Constructor

		#region creating RecurrsiveAppointments

		//creating RecurrsiveAppointments
		private void CreateRecurrsiveAppointments()
		{
			RecursiveAppointmentCollection = new ScheduleAppointmentCollection();

			//Recurrence Appointment 1
			ScheduleAppointment alternativeDayAppointment = new ScheduleAppointment();
			DateTime currentDate = DateTime.Now;
			DateTime startTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 9, 0, 0);
			DateTime endTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 10, 0, 0);
			alternativeDayAppointment.StartTime = startTime;
			alternativeDayAppointment.EndTime = endTime;
			alternativeDayAppointment.Color = Color.FromHex("#FFA2C139");
			alternativeDayAppointment.Subject = "Occurs every 2 days";
			alternativeDayAppointment.IsRecursive = true;
			RecurrenceProperties recurrencePropertiesForAlternativeDay = new RecurrenceProperties();
			recurrencePropertiesForAlternativeDay.RecurrenceType = RecurrenceType.Daily;
			recurrencePropertiesForAlternativeDay.IsDailyEveryNDays = true;
			recurrencePropertiesForAlternativeDay.DailyNDays = 2;
			recurrencePropertiesForAlternativeDay.IsRangeRecurrenceCount = true;
			recurrencePropertiesForAlternativeDay.IsRangeNoEndDate = false;
			recurrencePropertiesForAlternativeDay.IsRangeEndDate = false;
			recurrencePropertiesForAlternativeDay.RangeRecurrenceCount = 10;
			recurrencePropertiesForAlternativeDay.RecurrenceRule = "FREQ=DAILY;COUNT=10;INTERVAL=2";
			alternativeDayAppointment.RecurrenceRule = recurrencePropertiesForAlternativeDay.RecurrenceRule;
			RecursiveAppointmentCollection.Add(alternativeDayAppointment);

			//Recurrence Appointment 2
			ScheduleAppointment weeklyAppointment = new ScheduleAppointment();
			DateTime startTime1 = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 11, 0, 0);
			DateTime endTime1 = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 12, 0, 0);
			weeklyAppointment.StartTime = startTime1;
			weeklyAppointment.EndTime = endTime1;
			weeklyAppointment.Color = Color.FromHex("#FFD80073");
			weeklyAppointment.Subject = "Occurs every monday";
			weeklyAppointment.IsRecursive = true;

			RecurrenceProperties recurrencePropertiesForWeeklyAppointment = new RecurrenceProperties();
			recurrencePropertiesForWeeklyAppointment.RecurrenceType = RecurrenceType.Weekly;
			recurrencePropertiesForWeeklyAppointment.IsRangeRecurrenceCount = true;
			recurrencePropertiesForWeeklyAppointment.WeeklyEveryNWeeks = 1;
			recurrencePropertiesForWeeklyAppointment.IsWeeklySunday = false;
			recurrencePropertiesForWeeklyAppointment.IsWeeklyMonday = true;
			recurrencePropertiesForWeeklyAppointment.IsWeeklyTuesday = false;
			recurrencePropertiesForWeeklyAppointment.IsWeeklyWednesday = false;
			recurrencePropertiesForWeeklyAppointment.IsWeeklyThursday = false;
			recurrencePropertiesForWeeklyAppointment.IsWeeklyFriday = false;
			recurrencePropertiesForWeeklyAppointment.IsWeeklySaturday = false;
			recurrencePropertiesForWeeklyAppointment.RangeRecurrenceCount = 10;
			recurrencePropertiesForWeeklyAppointment.RecurrenceRule = "FREQ=WEEKLY;COUNT=10;BYDAY=MO";
			weeklyAppointment.RecurrenceRule = recurrencePropertiesForWeeklyAppointment.RecurrenceRule;
			RecursiveAppointmentCollection.Add(weeklyAppointment);
		}

		#endregion creating RecurrsiveAppointments

	}
}

