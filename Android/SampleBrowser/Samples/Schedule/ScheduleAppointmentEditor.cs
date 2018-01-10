#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Android.Widget;
using Android.Views;
using Android.Content;
using Android.Graphics;
using Android.App;
using Android.OS;
using System.Collections.ObjectModel;
using Com.Syncfusion.Schedule;
using Com.Syncfusion.Schedule.Enums;
using System.Collections.Generic;
using Java.Util;
using Java.Text;
using Android.Util;
using Android.Views.InputMethods;

namespace SampleBrowser
{
	public class ScheduleAppointmentEditor
	{

		#region Properties and variables

		private Context mContext;

		private EditText subjectInput, locationInput;
		private SfSchedule sfSchedule;
		private TextView startDateName, startTimeName, endDateName, endTimeName;
		internal Button saveButton, cancelButton;

		private SimpleDateFormat dateFormat = new SimpleDateFormat("MMM dd,  yyyy", Locale.Us);
		private SimpleDateFormat timeFormat = new SimpleDateFormat("hh:mm aa", Locale.Us);

		public TableLayout EditorLayout
		{
			get;
			set;
		}

		public ScheduleAppointment SelectedAppointment;
		private Calendar StartTime;
		private Calendar EndTime;


		private DisplayMetrics density;

		#endregion

		#region Constructor

		public ScheduleAppointmentEditor(Context context, SfSchedule _schedule)
		{
			mContext = context;
			sfSchedule = _schedule;
			density = mContext.Resources.DisplayMetrics;
			EditorLayout = new TableLayout(context);
			EditorLayout.SetBackgroundColor(Color.White);
			EditorLayout.StretchAllColumns = true;
			EditorLayout.SetPaddingRelative(30, 30, 30, 30);
			EditorLayout.LayoutParameters = new ViewGroup.LayoutParams((density.WidthPixels), (density.HeightPixels));
			AddInputControls();

		}



		#endregion

		#region Methods
		private void AddInputControls()
		{

			subjectInput = new EditText(mContext);
			subjectInput.Gravity = GravityFlags.Fill;
			subjectInput.LayoutParameters = new ViewGroup.LayoutParams(LinearLayout.LayoutParams.MatchParent, (density.HeightPixels / 12));
			subjectInput.SetTextColor(Color.Black);
			subjectInput.Hint = "Event name";
			subjectInput.TextSize = 30;
			subjectInput.SetLines(1);

			subjectInput.KeyPress += (object sender, View.KeyEventArgs e) =>
			 {
				 e.Handled = false;
				 if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
				 {
					 InputMethodManager inputmanager = (InputMethodManager)mContext.GetSystemService(Context.InputMethodService);
					 inputmanager.HideSoftInputFromWindow(subjectInput.WindowToken, 0);
					 e.Handled = true;
				 }
			 };

			EditorLayout.AddView(subjectInput);

			locationInput = new EditText(mContext);
			locationInput.SetTextColor(Color.Black);
			locationInput.LayoutParameters = new ViewGroup.LayoutParams(LinearLayout.LayoutParams.MatchParent, (density.HeightPixels / 12));
			locationInput.Gravity = GravityFlags.Fill;
			locationInput.SetMinimumHeight(80);
			locationInput.SetLines(1);
			locationInput.TextSize = 18;
			locationInput.Hint = "Location";
			locationInput.KeyPress += (object sender, View.KeyEventArgs e) =>
						{
							e.Handled = false;
							if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
							{
								InputMethodManager inputmanager = (InputMethodManager)mContext.GetSystemService(Context.InputMethodService);
								inputmanager.HideSoftInputFromWindow(subjectInput.WindowToken, 0);
								e.Handled = true;
							}
						};
			EditorLayout.AddView(locationInput);

			LinearLayout timeLayout = new LinearLayout(mContext);
			timeLayout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
			timeLayout.Orientation = Orientation.Vertical;

			TextView startTimeLabel = new TextView(mContext);
			startTimeLabel.Text = "FROM";
			startTimeLabel.LayoutParameters = new ViewGroup.LayoutParams(LinearLayout.LayoutParams.MatchParent, (density.HeightPixels / 12));
			startTimeLabel.TextSize = 18;
			timeLayout.AddView(startTimeLabel);

			//startTime row
			LinearLayout minuteLayout = new LinearLayout(mContext);
			minuteLayout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, (density.HeightPixels / 12));
			minuteLayout.Orientation = Orientation.Horizontal;


			startDateName = new TextView(mContext);
			startDateName.Text = (sfSchedule.VisibleDates as IList<Calendar>).ToString();
			startDateName.TextSize = 18;
			startDateName.SetPadding(0, 0, density.WidthPixels / 4, 0);
			startDateName.SetTextColor(Color.Black);
			minuteLayout.AddView(startDateName);

			startTimeName = new TextView(mContext);
			startTimeName.Text = (sfSchedule.VisibleDates as IList<Calendar>).ToString();
			startTimeName.TextSize = 18;
			startTimeName.SetTextColor(Color.Black);
			minuteLayout.AddView(startTimeName);
			timeLayout.AddView(minuteLayout);

			//endTime label row

			TextView endTimeLabel = new TextView(mContext);
			endTimeLabel.Text = "TO";
			endTimeLabel.LayoutParameters = new ViewGroup.LayoutParams(LinearLayout.LayoutParams.MatchParent, (density.HeightPixels / 12));
			endTimeLabel.TextSize = 18;
			timeLayout.AddView(endTimeLabel);

			//endTime row
			LinearLayout minuteToLayout = new LinearLayout(mContext);
			minuteToLayout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, (density.HeightPixels / 12));
			minuteToLayout.Orientation = Orientation.Horizontal;

			endDateName = new TextView(mContext);
			endDateName.SetRawInputType(Android.Text.InputTypes.DatetimeVariationTime);
			endDateName.SetTextColor(Color.Black);
			endDateName.SetPadding(0, 0, density.WidthPixels / 4, 0);
			endDateName.Text = (sfSchedule.VisibleDates as IList<Calendar>).ToString();
			endDateName.TextSize = 18;
			minuteToLayout.AddView(endDateName);

			endTimeName = new TextView(mContext);
			endTimeName.Text = (sfSchedule.VisibleDates as IList<Calendar>).ToString();
			endTimeName.SetTextColor(Color.Black);
			endTimeName.TextSize = 18;
			minuteToLayout.AddView(endTimeName);
			timeLayout.AddView(minuteToLayout);

			//button row
			saveButton = new Button(mContext);
			saveButton.Text = "Save";
			saveButton.TextSize = 15;
			saveButton.SetTextColor(Color.White);
			timeLayout.AddView(saveButton);

			cancelButton = new Button(mContext);
			cancelButton.Text = "Cancel";
			cancelButton.TextSize = 15;
			cancelButton.SetTextColor(Color.White);
			timeLayout.AddView(cancelButton);

			EditorLayout.AddView(timeLayout);
			HookEvents();
		}


		public void UpdateEditor(ScheduleAppointment appointment, Calendar date)
		{
			SelectedAppointment = appointment;

			if (appointment != null)
			{
				subjectInput.Text = appointment.Subject.ToString();
				startDateName.Text = dateFormat.Format(appointment.StartTime.Time);
				startTimeName.Text = timeFormat.Format(appointment.StartTime.Time);
				endDateName.Text = dateFormat.Format(appointment.EndTime.Time);
				endTimeName.Text = timeFormat.Format(appointment.EndTime.Time);
				StartTime = appointment.StartTime;
				EndTime = appointment.EndTime;
			}
			else
			{
				subjectInput.Text = "";
				startDateName.Text = dateFormat.Format(date.Time);
				startTimeName.Text = timeFormat.Format(date.Time) + "";
				Calendar _endTime = (Calendar)date.Clone();
				_endTime.Add(CalendarField.Hour, 1);
				endDateName.Text = dateFormat.Format(_endTime.Time);
				endTimeName.Text = timeFormat.Format(_endTime.Time) + "";
				StartTime = date;
				EndTime = _endTime;
			}
		}

		private void HookEvents()
		{
			startDateName.Click += StartDateName_Click;
			startTimeName.Click += StartTimeName_Click;
			endDateName.Click += EndDateName_Click;
			endTimeName.Click += EndTimeName_Click;
			cancelButton.Click += CancelButton_Click;
			saveButton.Click += SaveButton_Click;
		}


		private void StartTimePickerCallback(object sender, TimePickerDialog.TimeSetEventArgs e)
		{
			Calendar modifiedTime = Calendar.Instance;
			modifiedTime.Set(CalendarField.HourOfDay, e.HourOfDay);
			modifiedTime.Set(CalendarField.Minute, e.Minute);
			startTimeName.Text = timeFormat.Format(modifiedTime.Time);

			StartTime.Set(CalendarField.HourOfDay, e.HourOfDay);
			StartTime.Set(CalendarField.Minute, e.Minute);
			EndTime.Set(CalendarField.HourOfDay, e.HourOfDay + 1);
			EndTime.Set(CalendarField.Minute, e.Minute);
			endTimeName.Text = timeFormat.Format(EndTime.Time);
			startTimeName.Text = timeFormat.Format(modifiedTime.Time);
		}

		private void EndTimePickerCallback(object sender, TimePickerDialog.TimeSetEventArgs e)
		{
			Calendar modifiedTime = Calendar.Instance;
			modifiedTime.Set(CalendarField.HourOfDay, e.HourOfDay);
			modifiedTime.Set(CalendarField.Minute, e.Minute);
			endTimeName.Text = timeFormat.Format(modifiedTime.Time);
			EndTime.Set(CalendarField.HourOfDay, e.HourOfDay);
			EndTime.Set(CalendarField.Minute, e.Minute);

			endTimeName.Text = timeFormat.Format(modifiedTime.Time);
		}




		private void StartDatePickerCallback(object sender, DatePickerDialog.DateSetEventArgs e)
		{
			Calendar modifiedDate = Calendar.Instance;
			modifiedDate.Set(CalendarField.DayOfMonth, e.DayOfMonth);
			modifiedDate.Set(CalendarField.Month, e.Month);
			modifiedDate.Set(CalendarField.Year, e.Year);

			startDateName.Text = dateFormat.Format(modifiedDate.Time);
			startTimeName.Text = timeFormat.Format(modifiedDate.Time);

			StartTime.Set(CalendarField.DayOfMonth, e.DayOfMonth);
			StartTime.Set(CalendarField.Month, e.Month);
			StartTime.Set(CalendarField.Year, e.Year);

			startDateName.Text = dateFormat.Format(modifiedDate.Time);

		}

		private void EndDatePickerCallback(object sender, DatePickerDialog.DateSetEventArgs e)
		{
			Calendar modifiedDate = Calendar.Instance;
			modifiedDate.Set(CalendarField.DayOfMonth, e.DayOfMonth);
			modifiedDate.Set(CalendarField.Month, e.Month);
			modifiedDate.Set(CalendarField.Year, e.Year);

			endDateName.Text = dateFormat.Format(modifiedDate.Time);
			endTimeName.Text = timeFormat.Format(modifiedDate.Time);

			EndTime.Set(CalendarField.DayOfMonth, e.DayOfMonth);
			EndTime.Set(CalendarField.Month, e.Month);
			EndTime.Set(CalendarField.Year, e.Year);

			endDateName.Text = dateFormat.Format(modifiedDate.Time);
		}

		#endregion



		#region Events



		private void StartDateName_Click(object sender, EventArgs e)
		{
			DatePickerDialog datePickerDialog = new DatePickerDialog(mContext,
																	 StartDatePickerCallback,
																	 StartTime.Get(CalendarField.Year),
																	 StartTime.Get(CalendarField.Month),
																	 StartTime.Get(CalendarField.DayOfMonth));

			datePickerDialog.Show();

		}

		private void StartTimeName_Click(object sender, EventArgs e)
		{
			TimePickerDialog timePicker = new TimePickerDialog(mContext,
															   StartTimePickerCallback,
															   StartTime.Get(CalendarField.HourOfDay),
															   StartTime.Get(CalendarField.Minute),
															   false);
			timePicker.Show();
		}

		private void EndDateName_Click(object sender, EventArgs e)
		{
			DatePickerDialog datePickerDialog = new DatePickerDialog(mContext,
																	 EndDatePickerCallback,
																	 EndTime.Get(CalendarField.Year),
																	 EndTime.Get(CalendarField.Month),
																	 EndTime.Get(CalendarField.DayOfMonth));

			datePickerDialog.Show();
		}

		private void EndTimeName_Click(object sender, EventArgs e)
		{
			TimePickerDialog timePicker = new TimePickerDialog(mContext,
															   EndTimePickerCallback,
															   EndTime.Get(CalendarField.HourOfDay),
															   EndTime.Get(CalendarField.Minute),
															   false);
			timePicker.Show();
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			if (SelectedAppointment == null)
			{
				SelectedAppointment = new ScheduleAppointment();
			}
			SelectedAppointment.Subject = subjectInput.Text;
			SelectedAppointment.StartTime = StartTime;
			SelectedAppointment.EndTime = EndTime;

			EditorLayout.Visibility = ViewStates.Invisible;
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			EditorLayout.Visibility = ViewStates.Invisible;
		}
		#endregion
	}
}

