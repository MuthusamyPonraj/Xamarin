#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleBrowser.SfSchedule
{
    internal class EditorLayoutBehavior : Behavior<StackLayout>
    {
        #region Fields

        private Button saveButton;
        private Button cancelButton;

        private DatePicker endDatePicker;
        private TimePicker endTimePicker;
        private Meeting selectedAppointment;
        private DateTime selectedDate;
        private DatePicker startDatePicker;
        private TimePicker startTimePicker;
        private StackLayout editorLayout;
        private Switch switchAllDay;
        private Entry eventNameText;
        private Entry organizerText;

        private Grid endTimeLabelLayout;
        private Grid startDateTimePickerLayout;
        private Grid startDatePickerLayout;
        private Grid startTimePickerLayout;
        private Grid EndDateTimePickerLayout;
        private Grid endDatePickerLayout;
        private Grid endTimePickerLayout;
        private Grid startTimeLabelLayout;
        private Grid organizerLayout;

        #endregion

        #region OnAttached
        protected override void OnAttachedTo(StackLayout bindable)
        {
            editorLayout = bindable;

            eventNameText = bindable.FindByName<Entry>("eventNameText");
            organizerText = bindable.FindByName<Entry>("organizerText");

            cancelButton = bindable.FindByName<Button>("cancelButton");
            saveButton = bindable.FindByName<Button>("saveButton");

            endDatePicker = bindable.FindByName<DatePicker>("endDate_picker");
            endTimePicker = bindable.FindByName<TimePicker>("endTime_picker");

            startDatePicker = bindable.FindByName<DatePicker>("startDate_picker");
            startTimePicker = bindable.FindByName<TimePicker>("startTime_picker");
            switchAllDay = bindable.FindByName<Switch>("switchAllDay");

            endTimeLabelLayout = bindable.FindByName<Grid>("endTimeLabel_layout");
            startDateTimePickerLayout = bindable.FindByName<Grid>("StartdateTimePicker_layout");
            startDatePickerLayout = bindable.FindByName<Grid>("start_datepicker_layout");
            organizerLayout = bindable.FindByName<Grid>("organizer_layout");

            startTimePickerLayout = bindable.FindByName<Grid>("start_timepicker_layout");
            startTimeLabelLayout = bindable.FindByName<Grid>("startTimeLabel_layout");
            EndDateTimePickerLayout = bindable.FindByName<Grid>("EndDateTimePicker_layout");

            endDatePickerLayout = bindable.FindByName<Grid>("end_datepicker_layout");
            EndDateTimePickerLayout = bindable.FindByName<Grid>("EndDateTimePicker_layout");
            endTimePickerLayout = bindable.FindByName<Grid>("end_timepicker_layout");

            saveButton.Clicked += SaveButton_Clicked;
            cancelButton.Clicked += CancelButton_Clicked;
            switchAllDay.Toggled += SwitchAllDay_Toggled;
        }
    
        #endregion

        #region SwitchAllDay_Toggled
        private void SwitchAllDay_Toggled(object sender, ToggledEventArgs e)
        {
            if ((sender as Switch).IsToggled)
            {
                startTimePicker.Time = new TimeSpan(12, 0, 0);
                startTimePicker.IsEnabled = false;
                endTimePicker.Time = new TimeSpan(12, 0, 0);
                endTimePicker.IsEnabled = false;
            }
            else
            {
                startTimePicker.IsEnabled = true;
                endTimePicker.IsEnabled = true;
                (sender as Switch).IsToggled = false;
            }

        }
        #endregion

        #region CancelButton_Clicked
        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            ScheduleAppointmentModifiedEventArgs args = new ScheduleAppointmentModifiedEventArgs();
            args.Appointment = null;
            args.IsModified = false;
            (editorLayout.BindingContext as EditorLayoutViewModel).OnAppointmentModified(args);
            editorLayout.IsVisible = false;
        }
        #endregion

        #region SaveButton_Clicked
        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            var endDate = endDatePicker.Date;
            var startDate = startDatePicker.Date;
            var endTime = endTimePicker.Time;
            var startTime = startTimePicker.Time;

            if (endDate < startDate)
            {
                Application.Current.MainPage.DisplayAlert("", "End time should be greater than start time", "OK");
            }
            else if (endDate == startDate)
            {
                if (endTime < startTime)
                {
                    Application.Current.MainPage.DisplayAlert("", "End time should be greater than start time", "OK");
                }
                else
                {
                    AppointmentDetails();
                    editorLayout.IsVisible = false;
                }
            }
            else
            {
                AppointmentDetails();
                editorLayout.IsVisible = false;
            }
        }
        #endregion

        #region AppointmentDetails

        private void AppointmentDetails()
        {
            if (selectedAppointment == null)
            {
                selectedAppointment = new Meeting();
                selectedAppointment.color = Color.FromHex("#5EDAF2");
            }
            if (eventNameText.Text != null)
            {
                selectedAppointment.EventName = eventNameText.Text.ToString();
                if (string.IsNullOrEmpty(selectedAppointment.EventName))
                    selectedAppointment.EventName = "Untitled";
            }
            if (organizerText.Text != null)
            {
                selectedAppointment.Organizer = organizerText.Text.ToString();
            }
            selectedAppointment.From = startDatePicker.Date.Add(startTimePicker.Time);
            selectedAppointment.To = endDatePicker.Date.Add(endTimePicker.Time);
            selectedAppointment.IsAllDay = switchAllDay.IsToggled;
            ScheduleAppointmentModifiedEventArgs args = new ScheduleAppointmentModifiedEventArgs();
            args.Appointment = selectedAppointment;
            args.IsModified = true;
            (editorLayout.BindingContext as EditorLayoutViewModel).OnAppointmentModified(args);
        }

        #endregion

        #region OpenEditor

        public void OpenEditor(Meeting appointment, DateTime date)
        {
            cancelButton.BackgroundColor = Color.FromHex("#E5E5E5");
            saveButton.BackgroundColor = Color.FromHex("#2196F3");
            eventNameText.Placeholder = "Event name";
            organizerText.Placeholder = "Organizer";
            selectedAppointment = null;
            if (appointment != null)
            {
                selectedAppointment = appointment;
                selectedDate = date;
            }
            else
            {
                selectedDate = date;
            }
            UpdateEditor();
        }

        #endregion

        #region UpdateEditor

        private void UpdateEditor()
        {
            if (selectedAppointment != null)
            {
                eventNameText.Text = selectedAppointment.EventName.ToString();
                organizerText.Text = selectedAppointment.Organizer;
                startDatePicker.Date = selectedAppointment.From;
                endDatePicker.Date = selectedAppointment.To;

                if (!selectedAppointment.IsAllDay)
                {
                    startTimePicker.Time = new TimeSpan(selectedAppointment.From.Hour, selectedAppointment.From.Minute, selectedAppointment.From.Second);
                    endTimePicker.Time = new TimeSpan(selectedAppointment.To.Hour, selectedAppointment.To.Minute, selectedAppointment.To.Second);
                    switchAllDay.IsToggled = false;
                }
                else
                {
                    startTimePicker.Time = new TimeSpan(12, 0, 0);
                    startTimePicker.IsEnabled = false;
                    endTimePicker.Time = new TimeSpan(12, 0, 0);
                    endTimePicker.IsEnabled = false;
                    switchAllDay.IsToggled = true;
                }
            }
            else
            {
                eventNameText.Text = "";
                organizerText.Text = "";
                switchAllDay.IsToggled = false;
                startDatePicker.Date = selectedDate;
                startTimePicker.Time = new TimeSpan(selectedDate.Hour, selectedDate.Minute, selectedDate.Second);
                endDatePicker.Date = selectedDate;
                endTimePicker.Time = new TimeSpan(selectedDate.Hour + 1, selectedDate.Minute, selectedDate.Second);
            }
        }
        #endregion

        #region UpdateElements

        internal void AddEditorElements()
        {
            if (Device.RuntimePlatform == "UWP" && Device.Idiom == TargetIdiom.Phone)
            {
                organizerLayout.IsVisible = false;

                startDateTimePickerLayout.Padding = new Thickness(20, 0, 20, 0);
                startDateTimePickerLayout.ColumnDefinitions.Clear();
                startDateTimePickerLayout.RowDefinitions = new RowDefinitionCollection()
                {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                };
                Grid.SetRow(startDatePickerLayout, 0);
                Grid.SetColumnSpan(startDatePickerLayout, 3);
                Grid.SetColumn(startTimePickerLayout, 0);
                Grid.SetColumnSpan(startTimePickerLayout, 3);
                Grid.SetRow(startTimePickerLayout, 1);
                startDatePickerLayout.HeightRequest = 40;
                startTimePickerLayout.HeightRequest = 40;
                startTimeLabelLayout.Padding = new Thickness(20, 5, 0, 0);
                startDateTimePickerLayout.Padding = new Thickness(20, 0, 20, 0);

                EndDateTimePickerLayout.ColumnDefinitions.Clear();
                EndDateTimePickerLayout.Padding = new Thickness(20, 0, 20, 0);
                EndDateTimePickerLayout.RowDefinitions = new RowDefinitionCollection()
                {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                };
                Grid.SetRow(endDatePickerLayout, 0);
                Grid.SetRow(endTimePickerLayout, 1);
                Grid.SetColumnSpan(endDatePickerLayout, 3);
                Grid.SetColumn(endTimePickerLayout, 0);
                Grid.SetColumnSpan(endTimePickerLayout, 3);
                endDatePickerLayout.HeightRequest = 40;
                endTimePickerLayout.HeightRequest = 40;
                endTimeLabelLayout.Padding = new Thickness(20, 5, 0, 0);
            }
            else if (Device.RuntimePlatform == "Android")
            {
                editorLayout.Padding = 20;
            }
        }

        #endregion

        #region OnDetachingFrom
        protected override void OnDetachingFrom(StackLayout bindable)
        {
            saveButton.Clicked -= SaveButton_Clicked;
            cancelButton.Clicked -= CancelButton_Clicked;
            switchAllDay.Toggled -= SwitchAllDay_Toggled;

            organizerLayout = null;
            editorLayout = null;
            eventNameText = null;
            organizerText = null;
            cancelButton = null;
            saveButton = null;
            endDatePicker = null;
            endTimePicker = null;
            startDatePicker = null;
            startTimePicker = null;
            switchAllDay = null;

            endTimeLabelLayout = null;
            startDateTimePickerLayout = null;
            startDatePickerLayout = null;

            startTimePickerLayout = null;
            startTimeLabelLayout = null;
            EndDateTimePickerLayout = null;

            endDatePickerLayout = null;
            EndDateTimePickerLayout = null;
            endTimePickerLayout = null;
        }
        #endregion
    }
}
