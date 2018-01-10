#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Syncfusion.SfSchedule.iOS;

#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using CGRect = System.Drawing.RectangleF;
using CGPoint = System.Drawing.PointF;
using CGSize = System.Drawing.SizeF;
using nfloat = System.Single;
using System.Drawing;
#endif

namespace SampleBrowser
{
	public class ScheduleViews : SampleView
	{


		public static SFSchedule schedule;
		static UIView editor;
		static UIButton button_cancel;
		static UIButton button_save;
		static UITextView label_subject;
		static UITextView label_location;
		static UILabel label_starts;
		static UILabel label_ends;
		static UIButton button_startDate;
		static UIButton button_endDate;
		static UIDatePicker picker_startDate;
		static UIDatePicker picker_endDate;
		static UIButton done_button;
		static ScheduleAppointment selectedAppointment;
		static int indexOfAppointment;


		//private readonly IList<string> scheduleTypes = new List<string>();
		//private string selectedType;
		//UIPickerView scheduleTypePicker = new UIPickerView();
		//UILabel label = new UILabel();
		//UIButton button = new UIButton();
		//UIButton textbutton = new UIButton();

		UIButton headerButton = new UIButton();
		UIButton moveToDate = new UIButton();
		static UILabel monthText = new UILabel();
		//UITextView monthText = new UITextView();
		UIButton editorView = new UIButton();
		static UIView headerView = new UIView();
		//UISegmentedControl segmentControl = new UISegmentedControl();
		public static UITableView tableView = new UITableView();
		public ScheduleViews()
		{
			schedule = new SFSchedule();
			editor = new UIView();


			schedule.AppointmentsForDate += Schedule_AppointmentsForDate;
			schedule.AppointmentsFromDate += Schedule_AppointmentsFromDate;
			schedule.CellTapped += Schedule_ScheduleTapped;
			schedule.VisibleDatesChanged += Schedule_VisibleDatesChanged;

			schedule.ScheduleView = SFScheduleView.SFScheduleViewWeek;
			schedule.Appointments = CreateAppointments();
			createEditor();

			schedule.HeaderHeight = 0;
			schedule.ViewHeaderHeight = 50;

			schedule.Hidden = false;
			editor.Hidden = true;
		}

		private void Schedule_VisibleDatesChanged(object sender, VisibleDatesChangedEventArgs e)
		{
			int CurrentVisibleMonth = 0;
			if (schedule.ScheduleView == SFScheduleView.SFScheduleViewMonth)
			{
				CurrentVisibleMonth = 8;
			}
			else
			{
				CurrentVisibleMonth = 0;
			}
			NSDate date = e.VisibleDates.GetItem<NSDate>((nuint)CurrentVisibleMonth);
			NSDateFormatter dateFormat = new NSDateFormatter();
			dateFormat.DateFormat = "MMMM YYYY";
			string monthName = dateFormat.ToString(date);
			monthText.Text = monthName;
			tableView.Hidden = true;
		}

		private void Schedule_ScheduleTapped(object sender, CellTappedEventArgs e)
		{
			if (schedule.ScheduleView == SFScheduleView.SFScheduleViewMonth)
			{

				schedule.ScheduleView = SFScheduleView.SFScheduleViewDay;
				schedule.MoveToDate(e.Date);
				schedule.Hidden = false;
				editor.Hidden = true;
				headerView.Hidden = false;
			}
			//base.didSelectDate (schedule, selectedDate, appointments);
			else
			{
				editor.Hidden = false;
				headerView.Hidden = true;
				schedule.Hidden = true;
			}

			indexOfAppointment = -1;
			tableView.Hidden = true;
			if (e.ScheduleAppointment != null)
			{
				for (nuint i = 0; i < schedule.Appointments.Count; i++)
				{
					if (schedule.Appointments.GetItem<ScheduleAppointment>(i) == e.ScheduleAppointment)
					{
						indexOfAppointment = int.Parse(i.ToString());
						break;
					}
				}
				selectedAppointment = (e.ScheduleAppointment);
				label_subject.Text = selectedAppointment.Subject;
				label_location.Text = selectedAppointment.Location;
				String _sDate = DateTime.Parse((selectedAppointment.StartTime.ToString())).ToString();
				button_startDate.SetTitle(_sDate, UIControlState.Normal);
				picker_startDate.SetDate(selectedAppointment.StartTime, true);
				String _eDate = DateTime.Parse((selectedAppointment.EndTime.ToString())).ToString();
				button_endDate.SetTitle(_eDate, UIControlState.Normal);
				picker_endDate.SetDate(selectedAppointment.EndTime, true);
				editor.EndEditing(true);
			}
			else
			{
				List<UIColor> colorCollection = new List<UIColor>();
				colorCollection.Add(UIColor.FromRGB(0xA2, 0xC1, 0x39));
				colorCollection.Add(UIColor.FromRGB(0xD8, 0x00, 0x73));
				label_subject.Text = "Subject";
				label_location.Text = "Location";
				String _sDate = DateTime.Parse((e.Date.ToString())).ToString();
				picker_startDate.SetDate(e.Date, true);
				button_startDate.SetTitle(_sDate, UIControlState.Normal);
				String _eDate = DateTime.Parse((e.Date.AddSeconds(3600).ToString())).ToString();
				picker_endDate.SetDate(e.Date.AddSeconds(3600), true);
				button_endDate.SetTitle(_eDate, UIControlState.Normal);

			}
		}

		private void Schedule_AppointmentsFromDate(object sender, AppointmentsFromDateEventArgs e)
		{
			NSCalendar calendar = NSCalendar.CurrentCalendar;
			NSDateComponents components = calendar.Components(NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, e.EndDate);
			components.Hour = 23;
			components.Minute = 59;
			components.Second = 59;
			NSDate rangeEndDateWithTime = calendar.DateFromComponents(components);
			NSPredicate predicate = NSPredicate.FromFormat(@"(startTime <= %@) AND (startTime >= %@)", rangeEndDateWithTime, e.StartDate);

		}

		private void Schedule_AppointmentsForDate(object sender, AppointmentsForDateEventArgs e)
		{
			NSCalendar calendar = NSCalendar.CurrentCalendar;
			NSDateComponents components = calendar.Components(NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, (NSDate)e.Date);
			components.Hour = 23;
			components.Minute = 59;
			components.Second = 59;
			NSDate rangeEndDateWithTime = calendar.DateFromComponents(components);
			NSPredicate predicate = NSPredicate.FromFormat(@"(startTime <= %@) AND (startTime >= %@)", rangeEndDateWithTime, (NSDate)e.Date);

		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (schedule != null)
				{
					schedule.AppointmentsForDate -= Schedule_AppointmentsForDate;
					schedule.AppointmentsFromDate -= Schedule_AppointmentsFromDate;
					schedule.CellTapped -= Schedule_ScheduleTapped;
					schedule.VisibleDatesChanged -= Schedule_VisibleDatesChanged;
					schedule.Dispose();
					schedule = null;
				}
				if (moveToDate != null)
				{
					moveToDate.TouchUpInside -= MoveToDate_TouchUpInside;
					moveToDate.Dispose();
					moveToDate = null;
				}
				if (headerButton != null)
				{
					headerButton.TouchUpInside -= HeaderButton_TouchUpInside;
					headerButton.Dispose();
					headerButton = null;
				}
				if (editorView != null)
				{
					editorView.TouchUpInside -= EditorView_TouchUpInside;
					editorView.Dispose();
					editorView = null;
				}
			}
			base.Dispose(disposing);
		}



		void EditorView_TouchUpInside(object sender, EventArgs e)
		{
			editor.Hidden = false;
			schedule.Hidden = true;
			headerView.Hidden = true;
			tableView.Hidden = true;

			NSDate today = new NSDate();
			NSCalendar calendar = NSCalendar.CurrentCalendar;
			// Get the year, month, day from the date
			NSDateComponents components = calendar.Components(
				NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, today);
			NSDate startDate = calendar.DateFromComponents(components);

			label_subject.Text = "Subject";
			label_location.Text = "Location";
			String _sDate = DateTime.Parse((startDate.ToString())).ToString();
			picker_startDate.SetDate(startDate, true);
			button_startDate.SetTitle(_sDate, UIControlState.Normal);
			String _eDate = DateTime.Parse((startDate.AddSeconds(3600).ToString())).ToString();
			picker_endDate.SetDate(startDate.AddSeconds(3600), true);
			button_endDate.SetTitle(_eDate, UIControlState.Normal);

		}
		void MoveToDate_TouchUpInside(object sender, EventArgs e)
		{
			tableView.Hidden = true;
			NSDate today = new NSDate();
			NSCalendar calendar = NSCalendar.CurrentCalendar;
			// Get the year, month, day from the date
			NSDateComponents components = calendar.Components(
				NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, today);
			NSDate startDate = calendar.DateFromComponents(components);

			schedule.MoveToDate(startDate);
		}
		void HeaderButton_TouchUpInside(object sender, EventArgs e)
		{
			tableView.Hidden = false;
		}

		public override void LayoutSubviews()
		{
			foreach (var view in this.Subviews)
			{
				view.Frame = new CGRect(Frame.X, 0, Frame.Width, Frame.Height);
			}

			nfloat yMargin = nfloat.Parse((this.Frame.Height * 0.1).ToString());
			nfloat xMargin = nfloat.Parse((this.Frame.Width * 0.1).ToString());
			nfloat elementWidth = nfloat.Parse((this.Frame.Width - (xMargin * 2)).ToString());
			if (Utility.IsIpad)
			{
				editor.Frame = new CGRect((this.Frame.Size.Width / 2) - ((this.Frame.Size.Width / 2) / 1.5), (this.Frame.Size.Width / 2) - ((this.Frame.Size.Height / 2) / 2), this.Frame.Size.Width / 1.5, this.Frame.Size.Height / 1.5);
				elementWidth = nfloat.Parse((this.Frame.Width / 1.5 - (xMargin * 2)).ToString());

				button_cancel.Frame = new CGRect(xMargin, yMargin - 50, elementWidth / 2, 50);
				button_save.Frame = new CGRect(270, yMargin - 50, elementWidth / 2, 50);
				label_subject.Frame = new CGRect(xMargin, yMargin * 1.5, elementWidth, 50);
				label_location.Frame = new CGRect(xMargin, yMargin * 2.5, elementWidth, 50);
				label_starts.Frame = new CGRect(xMargin, yMargin * 3.5, elementWidth, 30);
				button_startDate.Frame = new CGRect(xMargin, yMargin * 4, elementWidth, 50);
				label_ends.Frame = new CGRect(xMargin, yMargin * 5, elementWidth, 30);
				button_endDate.Frame = new CGRect(xMargin, yMargin * 5.5, elementWidth, 50);

				button_cancel.BackgroundColor = UIColor.White;
				button_save.BackgroundColor = UIColor.White;
				button_startDate.BackgroundColor = UIColor.White;
				button_endDate.BackgroundColor = UIColor.White;

				button_cancel.Layer.CornerRadius = 6;
				button_save.Layer.CornerRadius = 6;
				button_startDate.Layer.CornerRadius = 6;
				button_endDate.Layer.CornerRadius = 6;

				picker_startDate.Frame = new CGRect(xMargin, yMargin * 3.5, elementWidth, 200);
				picker_endDate.Frame = new CGRect(xMargin, yMargin * 3.5, elementWidth, 200);
				done_button.Frame = new CGRect(xMargin, yMargin * 3.5, elementWidth, 30);
			}
			else
			{
				editor.Frame = new CGRect(0, 0, this.Frame.Size.Width, this.Frame.Size.Height);
				button_cancel.Frame = new CGRect(20, yMargin, 200, 30);
				button_save.Frame = new CGRect((this.Frame.Width) - 220, yMargin, 200, 30);
				label_subject.Frame = new CGRect(xMargin, yMargin * 2, elementWidth, 30);
				label_location.Frame = new CGRect(xMargin, yMargin * 3, elementWidth, 30);
				label_starts.Frame = new CGRect(xMargin, yMargin * 4, elementWidth, 30);
				button_startDate.Frame = new CGRect(xMargin, yMargin * 5, elementWidth, 30);
				label_ends.Frame = new CGRect(xMargin, yMargin * 6, elementWidth, 30);
				button_endDate.Frame = new CGRect(xMargin, yMargin * 7, elementWidth, 30);

				picker_startDate.Frame = new CGRect(xMargin, yMargin * 4, elementWidth, 200);
				picker_endDate.Frame = new CGRect(xMargin, yMargin * 4, elementWidth, 200);
				done_button.Frame = new CGRect(xMargin, yMargin * 4, elementWidth, 30);
			}


			UIImageView image1 = new UIImageView();
			UIImageView image2 = new UIImageView();
			UIImageView image3 = new UIImageView();

			moveToDate = new UIButton();
			editorView = new UIButton();
			monthText = new UILabel();

			headerView = new UIView();

			headerView.BackgroundColor = UIColor.FromRGB(214, 214, 214);




			NSDate today = new NSDate();
			NSCalendar calendar = NSCalendar.CurrentCalendar;
			// Get the year, month, day from the date
			NSDateComponents components = calendar.Components(
				NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, today);
			NSDate startDate = calendar.DateFromComponents(components);
			NSDateFormatter dateFormat = new NSDateFormatter();
			dateFormat.DateFormat = "MMMM YYYY";
			string monthName = dateFormat.ToString(startDate);
			monthText.Text = monthName;
			monthText.TextColor = UIColor.Black;
			monthText.TextAlignment = UITextAlignment.Left;
			moveToDate.AddSubview(image2);
			headerButton.AddSubview(image1);
			editorView.AddSubview(image3);


			string[] tableItems = new string[] { "Day", "Week", "WorkWeek", "Month" };
			tableView = new UITableView();
			tableView.Frame = new CGRect(0, 0, this.Frame.Size.Width / 2, 60.0f * 4);
			tableView.Hidden = true;
			tableView.Source = new ScheduleTableSource(tableItems);

			string deviceType = UIDevice.CurrentDevice.Model;
			if (deviceType == "iPhone" || deviceType == "iPod touch")
			{
				image1.Frame = new CGRect(0, 0, 60, 60);
				image1.Image = UIImage.FromFile("black-09.png");
				image2.Frame = new CGRect(0, 0, 60, 60);
				image2.Image = UIImage.FromFile("black-11.png");
				image3.Frame = new CGRect(0, 0, 60, 60);
				image3.Image = UIImage.FromFile("black-10.png");

				headerView.Frame = new CGRect(0, 0, this.Frame.Size.Width, 50);
				moveToDate.Frame = new CGRect((this.Frame.Size.Width / 6) + (this.Frame.Size.Width / 2), -10, this.Frame.Size.Width / 8, 50);
				editorView.Frame = new CGRect((this.Frame.Size.Width / 6) + (this.Frame.Size.Width / 6) + (this.Frame.Size.Width / 2), -10, this.Frame.Size.Width / 8, 50);
				headerButton.Frame = new CGRect(-10, -10, this.Frame.Size.Width / 8, 50);
				monthText.Frame = new CGRect(this.Frame.Size.Width / 8, -10, this.Frame.Size.Width / 2, 60);
				schedule.Frame = new CGRect(0, 50, this.Frame.Size.Width, this.Frame.Size.Height - 50);
			}
			else
			{
				schedule.DayViewSettings.WorkStartHour = 7;
				schedule.DayViewSettings.WorkEndHour = 18;

				schedule.WeekViewSettings.WorkStartHour = 7;
				schedule.WeekViewSettings.WorkEndHour = 18;

				schedule.WorkWeekViewSettings.WorkStartHour = 7;
				schedule.WorkWeekViewSettings.WorkEndHour = 18;

				image1.Frame = new CGRect(0, 0, 80, 80);
				image1.Image = UIImage.FromFile("black-09.png");
				image2.Frame = new CGRect(0, 0, 80, 80);
				image2.Image = UIImage.FromFile("black-11.png");
				image3.Frame = new CGRect(0, 0, 80, 80);
				image3.Image = UIImage.FromFile("black-10.png");

				headerView.Frame = new CGRect(0, 0, this.Frame.Size.Width, 60);
				moveToDate.Frame = new CGRect((this.Frame.Size.Width / 5) + (this.Frame.Size.Width / 2) + (this.Frame.Size.Width / 8), -10, this.Frame.Size.Width / 8, 50);
				editorView.Frame = new CGRect((this.Frame.Size.Width / 5) + (this.Frame.Size.Width / 5) + (this.Frame.Size.Width / 2), -10, this.Frame.Size.Width / 8, 50);
				headerButton.Frame = new CGRect(0, -10, this.Frame.Size.Width / 8, 50);
				monthText.Frame = new CGRect(this.Frame.Size.Width / 8, 5, this.Frame.Size.Width / 2, 50);
				schedule.Frame = new CGRect(0, 60, this.Frame.Size.Width, this.Frame.Size.Height - 60);
			}

			if (Utility.IsIpad)
			{
				editor.BackgroundColor = UIColor.FromRGB(0xD7, 0xD7, 0xD7);
			}
			moveToDate.TouchUpInside += MoveToDate_TouchUpInside;
			headerButton.TouchUpInside += HeaderButton_TouchUpInside;
			editorView.TouchUpInside += EditorView_TouchUpInside;




			headerView.AddSubview(moveToDate);
			headerView.AddSubview(editorView);
			headerView.AddSubview(monthText);
			headerView.AddSubview(headerButton);
			this.AddSubview(schedule);
			this.AddSubview(headerView);
			this.AddSubview(editor);
			this.AddSubview(tableView);
			base.LayoutSubviews();
		}

		private void createEditor()
		{
			button_cancel = new UIButton();
			button_save = new UIButton();
			label_subject = new UITextView();
			label_location = new UITextView();
			label_ends = new UILabel();
			label_starts = new UILabel();
			button_startDate = new UIButton();
			button_endDate = new UIButton();
			picker_startDate = new UIDatePicker();
			picker_endDate = new UIDatePicker();
			done_button = new UIButton();


			//cancel button
			button_cancel.SetTitle("Cancel", UIControlState.Normal);
			button_cancel.SetTitleColor(UIColor.Blue, UIControlState.Normal);
			button_cancel.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			button_cancel.TouchUpInside += (object sender, EventArgs e) =>
			{

				editor.Hidden = true;
				schedule.Hidden = false;
				editor.EndEditing(true);
				headerView.Hidden = false;

			};

			//save button
			button_save.SetTitle("Save", UIControlState.Normal);
			button_save.SetTitleColor(UIColor.Blue, UIControlState.Normal);
			button_save.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			button_save.TouchUpInside += (object sender, EventArgs e) =>
			{
				headerView.Hidden = false;
				if (indexOfAppointment != -1)
				{
					schedule.Appointments.GetItem<ScheduleAppointment>(nuint.Parse(indexOfAppointment.ToString())).Subject = (NSString)label_subject.Text;
					schedule.Appointments.GetItem<ScheduleAppointment>(nuint.Parse(indexOfAppointment.ToString())).Location = (NSString)label_location.Text;
					schedule.Appointments.GetItem<ScheduleAppointment>(nuint.Parse(indexOfAppointment.ToString())).StartTime = picker_startDate.Date;
					schedule.Appointments.GetItem<ScheduleAppointment>(nuint.Parse(indexOfAppointment.ToString())).EndTime = picker_endDate.Date;
				}
				else
				{
					ScheduleAppointment appointment = new ScheduleAppointment();
					appointment.Subject = (NSString)label_subject.Text;
					appointment.Location = (NSString)label_location.Text;
					appointment.StartTime = picker_startDate.Date;
					appointment.EndTime = picker_endDate.Date;
					appointment.AppointmentBackground = UIColor.FromRGB(0xA2, 0xC1, 0x39);
					schedule.Appointments.Add(appointment);
				}
				editor.Hidden = true;
				schedule.Hidden = false;
				schedule.ReloadData();
				editor.EndEditing(true);
			};

			//subject label
			label_subject.TextColor = UIColor.Black;
			label_subject.TextAlignment = UITextAlignment.Left;
			label_subject.Layer.CornerRadius = 8;
			label_subject.Layer.BorderWidth = 2;
			label_subject.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;


			//location label
			label_location.TextColor = UIColor.Black;
			label_location.TextAlignment = UITextAlignment.Left;
			label_location.Layer.CornerRadius = 8;
			label_location.Layer.BorderWidth = 2;
			label_location.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;

			//starts time

			label_starts.Text = "Start Time :";
			label_starts.TextColor = UIColor.Black;

			button_startDate.SetTitle("Start time", UIControlState.Normal);
			button_startDate.SetTitleColor(UIColor.Blue, UIControlState.Normal);
			button_startDate.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			button_startDate.TouchUpInside += (object sender, EventArgs e) =>
			{
				picker_startDate.Hidden = false;
				done_button.Hidden = false;
				label_ends.Hidden = true;
				button_endDate.Hidden = true;
				button_startDate.Hidden = true;
				label_starts.Hidden = true;
				editor.EndEditing(true);
			};

			//end time

			label_ends.Text = "End Time :";
			label_ends.TextColor = UIColor.Black;


			//end date
			button_endDate.SetTitle("End time", UIControlState.Normal);
			button_endDate.SetTitleColor(UIColor.Blue, UIControlState.Normal);
			button_endDate.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			button_endDate.TouchUpInside += (object sender, EventArgs e) =>
			{
				picker_endDate.Hidden = false;
				done_button.Hidden = false;
				label_ends.Hidden = true;
				button_endDate.Hidden = true;
				button_startDate.Hidden = true;
				label_starts.Hidden = true;
				editor.EndEditing(true);
			};

			//date and time pickers
			picker_startDate.Hidden = true;
			picker_endDate.Hidden = true;

			//done button
			done_button.SetTitle("Done", UIControlState.Normal);
			done_button.SetTitleColor(UIColor.Blue, UIControlState.Normal);
			done_button.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
			done_button.TouchUpInside += (object sender, EventArgs e) =>
			{
				picker_startDate.Hidden = true;
				picker_endDate.Hidden = true;
				done_button.Hidden = true;
				label_ends.Hidden = false;
				button_endDate.Hidden = false;
				button_startDate.Hidden = false;
				label_starts.Hidden = false;

				String _sDate = DateTime.Parse((picker_startDate.Date.ToString())).ToString();
				button_startDate.SetTitle(_sDate, UIControlState.Normal);

				String _eDate = DateTime.Parse((picker_endDate.Date.ToString())).ToString();
				button_endDate.SetTitle(_eDate, UIControlState.Normal);
				editor.EndEditing(true);

			};

			button_cancel.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 10, 100, 30);
			button_save.Frame = new CGRect(100, this.Frame.Y + 10, 300, 30);
			label_subject.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 50, 300, 30);
			label_location.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 90, 300, 30);
			label_starts.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 140, 300, 30);
			button_startDate.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 180, 300, 30);
			label_ends.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 220, 300, 30);
			button_endDate.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 260, 300, 30);

			picker_startDate.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 180, 300, 30);
			picker_endDate.Frame = new CGRect(100, this.Frame.Y + 180, 300, 30);
			picker_endDate.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 180, 300, 30);
			done_button.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 180, 300, 30);
			done_button.Hidden = true;

			editor.Add(button_cancel);
			editor.Add(button_save);
			editor.Add(label_subject);
			editor.Add(label_location);
			editor.Add(label_starts);
			editor.Add(button_startDate);
			editor.Add(label_ends);
			editor.Add(button_endDate);
			editor.Add(picker_endDate);
			editor.Add(picker_startDate);
			editor.Add(done_button);
		}

		NSMutableArray CreateAppointments()
		{
			NSDate today = new NSDate();
			setColors();
			setSubjects();
			NSMutableArray appCollection = new NSMutableArray();
			NSCalendar calendar = NSCalendar.CurrentCalendar;
			// Get the year, month, day from the date
			NSDateComponents components = calendar.Components(
				NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, today);
			// Set the hour, minute, second
			components.Hour = 10;
			components.Minute = 0;
			components.Second = 0;

			// Get the year, month, day from the date
			NSDateComponents endDateComponents = calendar.Components(NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, today);
			// Set the hour, minute, second
			endDateComponents.Hour = 12;
			endDateComponents.Minute = 0;
			endDateComponents.Second = 0;
			Random randomNumber = new Random();

			for (int i = 0; i < 10; i++)
			{
				components.Hour = randomNumber.Next(10, 16);
				endDateComponents.Hour = components.Hour + randomNumber.Next(1, 3);
				NSDate startDate = calendar.DateFromComponents(components);
				NSDate endDate = calendar.DateFromComponents(endDateComponents);
				ScheduleAppointment appointment = new ScheduleAppointment();
				appointment.StartTime = startDate;
				appointment.EndTime = endDate;
				components.Day = components.Day + 1;
				endDateComponents.Day = endDateComponents.Day + 1;
				appointment.Subject = (NSString)subjectCollection[i];
				appointment.AppointmentBackground = colorCollection[i];

				appCollection.Add(appointment);
			}
			return appCollection;
		}
		List<String> subjectCollection;

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
		List<UIColor> colorCollection;
		private void setColors()
		{
			colorCollection = new List<UIColor>();
			colorCollection.Add(UIColor.FromRGB(0xA2, 0xC1, 0x39));
			colorCollection.Add(UIColor.FromRGB(0xD8, 0x00, 0x73));
			colorCollection.Add(UIColor.FromRGB(0x1B, 0xA1, 0xE2));
			colorCollection.Add(UIColor.FromRGB(0xE6, 0x71, 0xB8));
			colorCollection.Add(UIColor.FromRGB(0xF0, 0x96, 0x09));
			colorCollection.Add(UIColor.FromRGB(0x33, 0x99, 0x33));
			colorCollection.Add(UIColor.FromRGB(0x00, 0xAB, 0xA9));
			colorCollection.Add(UIColor.FromRGB(0xE6, 0x71, 0xB8));
			colorCollection.Add(UIColor.FromRGB(0x1B, 0xA1, 0xE2));
			colorCollection.Add(UIColor.FromRGB(0xD8, 0x00, 0x73));
			colorCollection.Add(UIColor.FromRGB(0xA2, 0xC1, 0x39));
			colorCollection.Add(UIColor.FromRGB(0xD8, 0x00, 0x73));
			colorCollection.Add(UIColor.FromRGB(0x33, 0x99, 0x33));
			colorCollection.Add(UIColor.FromRGB(0xE6, 0x71, 0xB8));
			colorCollection.Add(UIColor.FromRGB(0x00, 0xAB, 0xA9));
		}

	}

	public class SchedulePickerModel : UIPickerViewModel
	{
		private readonly IList<string> values;

		public event EventHandler<SchedulePickerChangedEventArgs> PickerChanged;

		public SchedulePickerModel(IList<string> values)
		{
			this.values = values;
		}
#if __UNIFIED__
		public override nint GetComponentCount(UIPickerView picker)
		{
			return 1;
		}

		public override nint GetRowsInComponent(UIPickerView picker, nint component)
		{
			return values.Count;
		}

		public override string GetTitle(UIPickerView picker, nint row, nint component)
		{
			return values[(int)row];
		}

		public override nfloat GetRowHeight(UIPickerView picker, nint component)
		{
			return 30f;
		}

		public override void Selected(UIPickerView picker, nint row, nint component)
		{
			if (this.PickerChanged != null)
			{
				this.PickerChanged(this, new SchedulePickerChangedEventArgs { SelectedValue = values[(int)row] });
			}
		}
#else
		public override int GetComponentCount(UIPickerView picker)
		{
			return 1;
		}

		public override int GetRowsInComponent(UIPickerView picker, int component)
		{
			return values.Count;
		}

		public override string GetTitle(UIPickerView picker, int row, int component)
		{
			return values[(int)row];
		}

		public override nfloat GetRowHeight(UIPickerView picker, int component)
		{
			return 30f;
		}

		public override void Selected(UIPickerView picker, int row, int component)
		{
			if (this.PickerChanged != null)
			{
				this.PickerChanged(this, new SchedulePickerChangedEventArgs { SelectedValue = values[(int)row] });
			}
		}
#endif
	}

	public class SchedulePickerChangedEventArgs : EventArgs
	{
		public string SelectedValue { get; set; }
	}
	public class ScheduleTableSource : UITableViewSource
	{
		string[] TableItems;
		string CellIdentifier = "TableCell";
		public ScheduleTableSource(string[] items)
		{
			TableItems = items;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			int i = TableItems.Length;
			return (nint)i;
		}
		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{

			switch (indexPath.Row)
			{
				case 0:
					ScheduleViews.schedule.ScheduleView = SFScheduleView.SFScheduleViewDay;
					ScheduleViews.tableView.Hidden = true;
					break;
				case 1:
					ScheduleViews.schedule.ScheduleView = SFScheduleView.SFScheduleViewWeek;
					ScheduleViews.tableView.Hidden = true;
					break;
				case 2:
					ScheduleViews.schedule.ScheduleView = SFScheduleView.SFScheduleViewWorkWeek;
					ScheduleViews.tableView.Hidden = true;
					break;
				case 3:
					ScheduleViews.schedule.ScheduleView = SFScheduleView.SFScheduleViewMonth;
					ScheduleViews.tableView.Hidden = true;
					break;

			}
		}
		public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
		{
			return 60.0f;

		}


		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);

			string item = TableItems[indexPath.Row];
			if (cell == null)
			{ cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier); }
			cell.TextLabel.Text = item;
			return cell;
		}
	}
}
