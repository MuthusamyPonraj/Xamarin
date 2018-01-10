#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Android.Content;
using Com.Syncfusion.Schedule;
using Com.Syncfusion.Schedule.Enums;
using Android.Views;
using Android.Widget;
using Java.Util;
using System.Collections.Generic;
using Android.Graphics;
using Java.Text;

namespace SampleBrowser
{
	public class Recurrence : SamplePage
	{
		Context context;
		public Recurrence()
		{

		}

		private SfSchedule sfschedule;
		private TextView startTime, endTime, subjectText;
		public override View GetSampleContent(Context con)
		{

			context = con;
			sfschedule = new SfSchedule(con);
			sfschedule.ScheduleView = ScheduleView.MonthView;
			sfschedule.FirstDayOfWeek = 1;
			getAppointments();
			sfschedule.Appointments = appointmentCollection;
			MonthViewSettings monthViewSettings = new MonthViewSettings();
			monthViewSettings.ShowAppointmentsInline = true;
			sfschedule.MonthViewSettings = monthViewSettings;
			sfschedule.EnableNavigation = true;


			sfschedule.MonthInlineAppointmentLoaded += Sfschedule_MonthInlineAppointmentLoadedEvent;
			sfschedule.MonthInlineLoaded += Sfschedule_MonthInlineLoadedEvent;
			return sfschedule;
		}

		private void Sfschedule_MonthInlineLoadedEvent(object sender, MonthInlineLoadedEventArgs e)
		{
			e.MonthInlineViewStyle.BackgroundColor = Color.ParseColor("#F6F6F6"); ;
		}

		private void Sfschedule_MonthInlineAppointmentLoadedEvent(object sender, MonthInlineAppointmentLoadedEventArgs e)
		{
			LayoutInflater layoutInflater = LayoutInflater.From(context);
			e.View = layoutInflater.Inflate(Resource.Layout.Recurrence, null);

			startTime = (TextView)e.View.FindViewById(Resource.Id.starttime);
			startTime.Text = new SimpleDateFormat("hh:mm a", Locale.English).Format((e.Appointment.StartTime).Time);

			endTime = (TextView)e.View.FindViewById(Resource.Id.endtime);
			endTime.Text = new SimpleDateFormat("hh:mm a", Locale.English).Format((e.Appointment.EndTime).Time);

			subjectText = (TextView)e.View.FindViewById(Resource.Id.subject);
			subjectText.Text = (e.Appointment.Subject);
		}

		private ScheduleAppointmentCollection appointmentCollection;

		//Creating appointments for ScheduleAppointmentCollection
		public void getAppointments()
		{
			appointmentCollection = new ScheduleAppointmentCollection();


			//Recurrence Appointment 1

			ScheduleAppointment appointment1 = new ScheduleAppointment();
			Calendar currentDate = Calendar.Instance;
			Calendar startTime = (Calendar)currentDate.Clone();
			Calendar endTime = (Calendar)currentDate.Clone();
			startTime.Set(
				currentDate.Get(CalendarField.Year),
				currentDate.Get(CalendarField.Month),
				currentDate.Get(CalendarField.DayOfMonth),
				4, 0, 0


			);
			endTime.Set(
				currentDate.Get(CalendarField.Year),
				currentDate.Get(CalendarField.Month),
				currentDate.Get(CalendarField.DayOfMonth),
				6, 0, 0
			);
			appointment1.StartTime = startTime;
			appointment1.EndTime = endTime;
			appointment1.Color = Color.ParseColor("#FF1BA1E2");
			appointment1.Subject = "Occurs once in every two days";
			appointment1.IsRecursive = true;
			RecurrenceProperties recurrenceProp1 = new RecurrenceProperties();
			recurrenceProp1.RecurrenceType = RecurrenceType.Daily;
			recurrenceProp1.IsDailyEveryNDays = true;
			recurrenceProp1.DailyNDays = 2;
			recurrenceProp1.IsRangeRecurrenceCount = true;
			recurrenceProp1.IsRangeNoEndDate = false;
			recurrenceProp1.IsRangeEndDate = false;
			recurrenceProp1.RangeRecurrenceCount = 10;
			recurrenceProp1.RecurrenceRule = ScheduleHelper.RRuleGenerator(recurrenceProp1, appointment1.StartTime, appointment1.EndTime);
			appointment1.RecurrenceRule = recurrenceProp1.RecurrenceRule;
			appointmentCollection.Add(appointment1);

			//Recurrence Appointment 2

			ScheduleAppointment scheduleAppointment1 = new ScheduleAppointment();
			Calendar currentDate1 = Calendar.Instance;
			Calendar startTime1 = (Calendar)currentDate1.Clone();
			Calendar endTime1 = (Calendar)currentDate1.Clone();
			startTime1.Set(
				currentDate.Get(CalendarField.Year),
				currentDate.Get(CalendarField.Month),
				currentDate.Get(CalendarField.DayOfMonth),
				10, 0, 0


			);
			endTime1.Set(
				currentDate.Get(CalendarField.Year),
				currentDate.Get(CalendarField.Month),
				currentDate.Get(CalendarField.DayOfMonth),
				12, 0, 0
			);

			scheduleAppointment1.StartTime = startTime1;
			scheduleAppointment1.EndTime = endTime1;
			scheduleAppointment1.Color = Color.ParseColor("#FFD80073");
			scheduleAppointment1.Subject = "Occurs every Monday";
			scheduleAppointment1.IsRecursive = true;
			RecurrenceProperties recurrenceProperties1 = new RecurrenceProperties();
			recurrenceProperties1.RecurrenceType = RecurrenceType.Weekly;
			recurrenceProperties1.IsRangeRecurrenceCount = true;
			recurrenceProperties1.WeeklyEveryNWeeks = 1;
			recurrenceProperties1.IsWeeklySunday = false;
			recurrenceProperties1.IsWeeklyMonday = true;
			recurrenceProperties1.IsWeeklyTuesday = false;
			recurrenceProperties1.IsWeeklyWednesday = false;
			recurrenceProperties1.IsWeeklyThursday = false;
			recurrenceProperties1.IsWeeklyFriday = false;
			recurrenceProperties1.IsWeeklySaturday = false;
			recurrenceProperties1.RangeRecurrenceCount = 10;
			recurrenceProperties1.RecurrenceRule = ScheduleHelper.RRuleGenerator(recurrenceProperties1, scheduleAppointment1.StartTime, scheduleAppointment1.EndTime);
			scheduleAppointment1.RecurrenceRule = recurrenceProperties1.RecurrenceRule;



			appointmentCollection.Add(scheduleAppointment1);
		}
		public void onNothingSelected(object sender, AdapterView.ItemSelectedEventArgs e)
		{
			sfschedule.ScheduleView = ScheduleView.WeekView;
		}
		public override void Destroy()
		{
			if (sfschedule != null)
			{
				sfschedule.MonthInlineAppointmentLoaded -= Sfschedule_MonthInlineAppointmentLoadedEvent;
				sfschedule.MonthInlineLoaded -= Sfschedule_MonthInlineLoadedEvent;
				sfschedule.Dispose();
				sfschedule = null;
			}
			base.Destroy();
		}
	}

}

