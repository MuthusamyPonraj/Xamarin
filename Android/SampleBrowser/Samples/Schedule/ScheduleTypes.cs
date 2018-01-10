#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Com.Syncfusion.Schedule;
using Com.Syncfusion.Schedule.Enums;
using Android.Views;
using Android.Content;
using Android.Widget;
using System.Collections.Generic;
using Android.Graphics;
using Java.Util;
using Android.App;
using Java.Text;
using Android.Util;

namespace SampleBrowser
{
	public class ScheduleTypes : SamplePage
	{
		public ScheduleTypes()
		{
		}
		private SfSchedule sfSchedule;
		private LinearLayout linearLayout;
		private IList<Calendar> visibleDates;
		private ScheduleCustomHeader scheduleCustomHeader;
		private ScheduleAppointmentEditor editor;
		private ScheduleViewOptionLayout viewOptionLayout;
		private ScheduleAppointment SelectedAppointment;
		private int indexOfAppointment = -1;
		private DisplayMetrics density;
		private FrameLayout mainLayout;

		private Context mContext;
		public override View GetSampleContent(Context context)
		{
			mainLayout = new FrameLayout(context);
			mContext = context;
			mainLayout.LayoutParameters = new ViewGroup.LayoutParams(FrameLayout.LayoutParams.MatchParent, FrameLayout.LayoutParams.MatchParent);
			density = mContext.Resources.DisplayMetrics;
			linearLayout = new LinearLayout(context);
			linearLayout.Orientation = Orientation.Vertical;
			linearLayout.LayoutParameters = new ViewGroup.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.MatchParent);

			//creating instance for Schedule
			sfSchedule = new SfSchedule(context);
			sfSchedule.LayoutParameters = new ViewGroup.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.MatchParent);
			sfSchedule.ScheduleView = ScheduleView.DayView;
			sfSchedule.HeaderHeight = 0;
			scheduleCustomHeader = new ScheduleCustomHeader(context);

			ViewHeaderStyle viewHeader = new ViewHeaderStyle();
			viewHeader.BackgroundColor = Color.Argb(255, 242, 242, 242);
			sfSchedule.ViewHeaderStyle = viewHeader;

			//set the appointment collection
			getAppointments();
			sfSchedule.Appointments = appointmentCollection;


			linearLayout.AddView(scheduleCustomHeader.HeaderLayout);
			linearLayout.AddView(sfSchedule);

			editor = new ScheduleAppointmentEditor(context, sfSchedule);
			editor.EditorLayout.LayoutParameters = new ViewGroup.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.MatchParent);

			viewOptionLayout = new ScheduleViewOptionLayout(mContext, sfSchedule);
			//viewOptionLayout.LayoutParameters = new ViewGroup.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.MatchParent);
			mainLayout.AddView(linearLayout);
			mainLayout.AddView(editor.EditorLayout);
			mainLayout.AddView(viewOptionLayout.OptionLayout);
			mainLayout.GetChildAt(2).SetY(density.HeightPixels / 14);
			editor.EditorLayout.Visibility = ViewStates.Invisible;
			viewOptionLayout.OptionLayout.Visibility = ViewStates.Invisible;
			HookEvents();
			return mainLayout;
		}

		private void HookEvents()
		{
			scheduleCustomHeader.scheduleCalendar.Click += ScheduleCalendar_Click;
			scheduleCustomHeader.schedulePlus.Click += EditorLayout_Click;
			scheduleCustomHeader.scheduleOption.Click += ScheduleOption_Click;
			sfSchedule.CellTapped += SfSchedule_ScheduleTappedEvent;
			sfSchedule.VisibleDatesChanged += SfSchedule_VisibleDatesChanged;

			editor.saveButton.Click += SaveButton_Click;
			editor.cancelButton.Click += CancelButton_Click;

			viewOptionLayout.day.Click += Day_Click;
			viewOptionLayout.week.Click += Week_Click;
			viewOptionLayout.workweek.Click += Workweek_Click;
			viewOptionLayout.month.Click += Month_Click;
		}

		private void SfSchedule_VisibleDatesChanged(object sender, VisibleDatesChangedEventArgs e)
		{
			visibleDates = e.VisibleDates;
			viewOptionLayout.OptionLayout.Visibility = ViewStates.Invisible;

			SimpleDateFormat dateFormat = new SimpleDateFormat("MMMM, yyyy", Locale.Us);
			if (sfSchedule.ScheduleView == ScheduleView.DayView)
			{
				scheduleCustomHeader.monthText.Text = dateFormat.Format(visibleDates[0].Time);
			}
			else if (sfSchedule.ScheduleView == ScheduleView.WeekView)
			{
				scheduleCustomHeader.monthText.Text = dateFormat.Format(visibleDates[visibleDates.Count / 2].Time);
			}
			else if (sfSchedule.ScheduleView == ScheduleView.WorkWeekView)
			{
				scheduleCustomHeader.monthText.Text = dateFormat.Format(visibleDates[visibleDates.Count / 2].Time);
			}
			else
			{
				scheduleCustomHeader.monthText.Text = dateFormat.Format(visibleDates[visibleDates.Count / 2].Time);
			}
		}

		private void SfSchedule_ScheduleTappedEvent(object sender, CellTappedEventArgs e)
		{
			viewOptionLayout.OptionLayout.Visibility = ViewStates.Invisible;
			var schedule = (sender as SfSchedule);
			if ((e.ScheduleAppointment as ScheduleAppointment) != null)
			{
				SelectedAppointment = (e.ScheduleAppointment as ScheduleAppointment);
				indexOfAppointment = schedule.Appointments.IndexOf((e.ScheduleAppointment as ScheduleAppointment));
			}
			else
			{
				SelectedAppointment = null;
				indexOfAppointment = -1;
			}

			if (schedule.ScheduleView == ScheduleView.MonthView)
			{
				schedule.ScheduleView = ScheduleView.DayView;
				schedule.MoveToDate = e.Calendar;
			}
			else
			{
				linearLayout.Visibility = ViewStates.Invisible;
				editor.EditorLayout.Visibility = ViewStates.Visible;

				editor.UpdateEditor((e.ScheduleAppointment as ScheduleAppointment), (e.Calendar as Calendar));
			}

		}

		private void ScheduleCalendar_Click(object sender, EventArgs e)
		{
			sfSchedule.MoveToDate = Calendar.GetInstance(Locale.English);
			viewOptionLayout.OptionLayout.Visibility = ViewStates.Invisible;
		}

		private void EditorLayout_Click(object sender, EventArgs e)
		{
			linearLayout.Visibility = ViewStates.Invisible;
			editor.EditorLayout.Visibility = ViewStates.Visible;
			editor.UpdateEditor(null, visibleDates[0]);
			viewOptionLayout.OptionLayout.Visibility = ViewStates.Invisible;
		}

		private void ScheduleOption_Click(object sender, EventArgs e)
		{
			showInputDialog();
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			linearLayout.Visibility = ViewStates.Visible;
			editor.EditorLayout.Visibility = ViewStates.Invisible;

			if (SelectedAppointment != null)
			{
				sfSchedule.Appointments.RemoveAt(indexOfAppointment);
				sfSchedule.Appointments.Add(editor.SelectedAppointment);
			}
			else
			{
				sfSchedule.Appointments.Add(editor.SelectedAppointment);
			}

			editor.SelectedAppointment = null;
			viewOptionLayout.OptionLayout.Visibility = ViewStates.Invisible;
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			linearLayout.Visibility = ViewStates.Visible;
			editor.EditorLayout.Visibility = ViewStates.Invisible;
			viewOptionLayout.OptionLayout.Visibility = ViewStates.Invisible;
		}

		protected void showInputDialog()
		{
			viewOptionLayout.OptionLayout.Visibility = ViewStates.Visible;

		}

		private void Day_Click(object sender, EventArgs e)
		{
			sfSchedule.ScheduleView = ScheduleView.DayView;
			viewOptionLayout.OptionLayout.Visibility = ViewStates.Invisible;
		}

		private void Month_Click(object sender, EventArgs e)
		{
			sfSchedule.ScheduleView = ScheduleView.MonthView;
			viewOptionLayout.OptionLayout.Visibility = ViewStates.Invisible;
		}

		private void Workweek_Click(object sender, EventArgs e)
		{
			sfSchedule.ScheduleView = ScheduleView.WorkWeekView;
			viewOptionLayout.OptionLayout.Visibility = ViewStates.Invisible;
		}

		private void Week_Click(object sender, EventArgs e)
		{
			sfSchedule.ScheduleView = ScheduleView.WeekView;
			viewOptionLayout.OptionLayout.Visibility = ViewStates.Invisible;

		}

		private List<string> subjectCollection = new List<string>();
		private List<string> colorCollection = new List<string>();
		private List<Calendar> startTimeCollection = new List<Calendar>();
		private List<Calendar> endTimeCollection = new List<Calendar>();
		private ScheduleAppointmentCollection appointmentCollection;

		//Creating appointments for ScheduleAppointmentCollection
		private void getAppointments()
		{
			appointmentCollection = new ScheduleAppointmentCollection();
			setColors();
			RandomNumbers();
			setSubjects();
			setStartTime();
			setEndTime();
			for (int i = 0; i < 10; i++)
			{
				ScheduleAppointment scheduleAppointment = new ScheduleAppointment();
				scheduleAppointment.Color = Color.ParseColor(colorCollection[i]);
				scheduleAppointment.Subject = subjectCollection[i];
				scheduleAppointment.StartTime = startTimeCollection[i];
				scheduleAppointment.EndTime = endTimeCollection[i];
				appointmentCollection.Add(scheduleAppointment);
			}
		}
		private void setSubjects()
		{
			subjectCollection = new List<String>();
			subjectCollection.Add("GoToMeeting");
			subjectCollection.Add("Business Meeting");
			subjectCollection.Add("Conference");
			subjectCollection.Add("Project Status Discussion");
			subjectCollection.Add("Auditing");
			subjectCollection.Add("Client Meeting");
			subjectCollection.Add("Generate Report");
			subjectCollection.Add("Target Meeting");
			subjectCollection.Add("General Meeting");
			subjectCollection.Add("Pay House Rent");
			subjectCollection.Add("Car Service");
			subjectCollection.Add("Medical Check Up");
			subjectCollection.Add("Wedding Anniversary");
			subjectCollection.Add("Sam's Birthday");
			subjectCollection.Add("Jenny's Birthday");
		}

		// adding colors collection
		private void setColors()
		{
			colorCollection = new List<String>();
			colorCollection.Add("#FFA2C139");
			colorCollection.Add("#FFD80073");
			colorCollection.Add("#FF1BA1E2");
			colorCollection.Add("#FFE671B8");
			colorCollection.Add("#FFF09609");
			colorCollection.Add("#FF339933");
			colorCollection.Add("#FF00ABA9");
			colorCollection.Add("#FFE671B8");
			colorCollection.Add("#FF1BA1E2");
			colorCollection.Add("#FFD80073");
			colorCollection.Add("#FFA2C139");
			colorCollection.Add("#FFD80073");
			colorCollection.Add("#FF339933");
			colorCollection.Add("#FFE671B8");
			colorCollection.Add("#FF00ABA9");
		}

		List<int> randomNums = new List<int>();
		private void RandomNumbers()
		{
			randomNums = new List<int>();
			Java.Util.Random rand = new Java.Util.Random();
			for (int i = 0; i < 10; i++)
			{
				int randomNum = rand.NextInt((15 - 9) + 1) + 9;
				randomNums.Add(randomNum);
			}
		}
		// adding StartTime collection
		private void setStartTime()
		{

			startTimeCollection = new List<Calendar>();
			Calendar currentDate = Calendar.Instance;
			int count = 0;
			for (int i = -5; i < 5; i++)
			{

				Calendar startTime = (Calendar)currentDate.Clone();
				startTime.Set
				(
					currentDate.Get(CalendarField.Year),
					currentDate.Get(CalendarField.Month),
					currentDate.Get(CalendarField.DayOfMonth) + i,
					randomNums[count],
					0,
					0
				);
				startTimeCollection.Add(startTime);
				count++;
			}
		}

		// adding EndTime collection
		private void setEndTime()
		{
			endTimeCollection = new List<Calendar>();
			Calendar currentDate = Calendar.Instance;
			int count = 0;
			for (int i = -5; i < 5; i++)
			{
				Calendar endTime = (Calendar)currentDate.Clone();
				endTime.Set
				(
					currentDate.Get(CalendarField.Year),
					currentDate.Get(CalendarField.Month),
					currentDate.Get(CalendarField.DayOfMonth) + i,
					randomNums[count] + 1,
					0,
					0
				);
				endTimeCollection.Add(endTime);
				count++;
			}
		}
		public override void Destroy()
		{
			if (sfSchedule != null)
			{
				sfSchedule.CellTapped -= SfSchedule_ScheduleTappedEvent;
				sfSchedule.VisibleDatesChanged -= SfSchedule_VisibleDatesChanged;
				sfSchedule.Dispose();
				sfSchedule = null;
			}
			if (scheduleCustomHeader != null)
			{
				if (scheduleCustomHeader.scheduleCalendar != null)
				{
					scheduleCustomHeader.scheduleCalendar.Click -= ScheduleCalendar_Click;
					scheduleCustomHeader.scheduleCalendar.Dispose();
					scheduleCustomHeader.scheduleCalendar = null;
				}
				if (scheduleCustomHeader.schedulePlus != null)
				{
					scheduleCustomHeader.schedulePlus.Click -= EditorLayout_Click;
					scheduleCustomHeader.schedulePlus.Dispose();
					scheduleCustomHeader.schedulePlus = null;
				}
				if (scheduleCustomHeader.scheduleOption != null)
				{
					scheduleCustomHeader.scheduleOption.Click -= ScheduleOption_Click;
					scheduleCustomHeader.scheduleOption.Dispose();
					scheduleCustomHeader.scheduleOption = null;
				}
				scheduleCustomHeader = null;
			}
			if (editor != null)
			{
				if (editor.saveButton != null)
				{
					editor.saveButton.Click -= SaveButton_Click;
					editor.saveButton.Dispose();
					editor.saveButton = null;
				}
				if (editor.cancelButton != null)
				{
					editor.cancelButton.Click -= CancelButton_Click;
					editor.cancelButton.Dispose();
					editor.cancelButton = null;
				}
			}
			if (viewOptionLayout != null)
			{
				if (viewOptionLayout.day != null)
				{
					viewOptionLayout.day.Click -= Day_Click;
					viewOptionLayout.day.Dispose();
					viewOptionLayout.day = null;
				}
				if (viewOptionLayout.week != null)
				{
					viewOptionLayout.week.Click -= Week_Click;
					viewOptionLayout.week.Dispose();
					viewOptionLayout.week = null;
				}
				if (viewOptionLayout.workweek != null)
				{
					viewOptionLayout.workweek.Click -= Workweek_Click;
					viewOptionLayout.workweek.Dispose();
					viewOptionLayout.workweek = null;
				}
				if (viewOptionLayout.month != null)
				{
					viewOptionLayout.month.Click -= Month_Click;
					viewOptionLayout.month.Dispose();
					viewOptionLayout = null;
				}
			}
			base.Destroy();
		}
	}
}

