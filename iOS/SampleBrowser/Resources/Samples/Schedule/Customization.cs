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
	public class Customization : SampleView
	{
		SFSchedule schedule;
		private readonly IList<string> scheduleTypes = new List<string>();
		private string selectedType;
		UIPickerView scheduleTypePicker = new UIPickerView();
		UILabel label = new UILabel();
		UIButton button = new UIButton();
		UIButton textbutton = new UIButton();
		//CGRect rect = new CGRect();
		UISegmentedControl customizationSegment = new UISegmentedControl();
		//UIView scheduleView = new UIView();
		SFHeaderStyle headerStyle;
		SFViewHeaderStyle viewHeaderStyle;
		//UIButton headerButton = new UIButton();
		//UIButton moveToDate = new UIButton();
		//UILabel monthText = new UILabel();
		////UITextView monthText = new UITextView();
		//UIButton editorView = new UIButton();
		//UIView headerView = new UIView();
		//UISegmentedControl segmentControl = new UISegmentedControl();
		//UITableView views = new UITableView();
		//string[] tableItems = new string[] { };

		public Customization()
		{
			schedule = new SFSchedule();

			label.Text = "Select the Schedule Type";
			label.TextColor = UIColor.Black;
			//this.AddSubview(label);

			 headerStyle = new SFHeaderStyle();
			 viewHeaderStyle = new SFViewHeaderStyle();

			schedule.HeaderHeight = 30;
			//schedule.HeaderStyle.BackgroundColor = UIColor.FromRGB(17, 17, 17);
			//schedule.HeaderStyle.TextColor = UIColor.FromRGB(238, 199, 43);
			//schedule.DayHeaderStyle.BackgroundColor = UIColor.FromRGB(28, 28, 28);
			//schedule.DayHeaderStyle.DayTextColor = UIColor.FromRGB(238, 199, 43); ;
			//schedule.DayHeaderStyle.DateTextColor = UIColor.FromRGB(238, 199, 43); ;

			textbutton.SetTitle("Day View", UIControlState.Normal);
			textbutton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			textbutton.BackgroundColor = UIColor.Clear;
			textbutton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			textbutton.Hidden = false;
			textbutton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
			textbutton.Layer.BorderWidth = 4;
			textbutton.Layer.CornerRadius = 8;
			textbutton.TouchUpInside += ShowPicker;
			//this.AddSubview(textbutton);

			button.SetTitle("Done\t", UIControlState.Normal);
			button.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
			button.BackgroundColor = UIColor.FromRGB(240, 240, 240);
			button.SetTitleColor(UIColor.Black, UIControlState.Normal);
			button.Hidden = true;
			button.TouchUpInside += HidePicker;

			schedule.Delegate = new ScheduleDelegate();
			schedule.Appointments = CreateAppointments();
			schedule.ScheduleView = SFScheduleView.SFScheduleViewDay;


			schedule.DayViewSettings = new DayViewSettings();
			schedule.DayViewSettings.TimeTextColor = UIColor.FromRGB(168, 168, 173);
			schedule.DayViewSettings.TimeSlotBorderColor = UIColor.FromRGB(219, 219, 219);
			schedule.DayViewSettings.NonWorkingHourTimeSlotBorderColor = UIColor.FromRGB(219, 219, 219);

			UIButton SelectionView = new UIButton();
			SelectionView.BackgroundColor = UIColor.FromRGB(0, 122,255);
			SelectionView.SetTitle("+ New Event", UIControlState.Normal);
			schedule.SelectionView = SelectionView;

			viewHeaderStyle.BackgroundColor = UIColor.FromRGB(247, 247, 247);
			viewHeaderStyle.DayTextStyle = UIFont.SystemFontOfSize(18);
			viewHeaderStyle.DayTextColor = UIColor.FromRGB(3, 3, 3);

			headerStyle.TextPosition = UITextAlignment.Center;
			headerStyle.TextColor = UIColor.FromRGB(3, 3, 3);
			schedule.HeaderStyle = headerStyle;
			schedule.DayHeaderStyle = viewHeaderStyle;
            schedule.AppointmentViewLayout = SFViewLayoutOptions.Overlay;​​​
			//control = this;
			//this.OptionView = new UIView();
			this.scheduleTypes.Add((NSString)"Day View");
			this.scheduleTypes.Add((NSString)"Month View");

			Localization.SchedulePickerModel model = new Localization.SchedulePickerModel(this.scheduleTypes);
			model.PickerChanged += (sender, e) =>
			{
				this.selectedType = e.SelectedValue;
				textbutton.SetTitle(selectedType, UIControlState.Normal);
				if (selectedType == "Day View")
				{
					schedule.ScheduleView = SFScheduleView.SFScheduleViewDay;
				}
				else if (selectedType == "Month View")
				{
					schedule.ScheduleView = SFScheduleView.SFScheduleViewMonth;
				}
			};
			scheduleTypePicker.ShowSelectionIndicator = true;
			scheduleTypePicker.Hidden = true;
			scheduleTypePicker.Model = model;
			scheduleTypePicker.BackgroundColor = UIColor.White;
		}
		protected override void Dispose(bool disposing)
		{
			if (schedule != null)
			{
				this.schedule.Dispose();
			}
			this.schedule = null;
		}
		void ShowPicker(object sender, EventArgs e)
		{

			button.Hidden = false;
			scheduleTypePicker.Hidden = false;
			this.BecomeFirstResponder();
		}

		void HidePicker(object sender, EventArgs e)
		{

			button.Hidden = true;
			scheduleTypePicker.Hidden = true;
			this.BecomeFirstResponder();
		}



		public override void LayoutSubviews()
		{
			string deviceType = UIDevice.CurrentDevice.Model;
			if (deviceType == "iPhone" || deviceType == "iPod touch")
			{
				label.Frame = new CGRect(15, 10, this.Frame.Size.Width - 20, 40);
				textbutton.Frame = new CGRect(10, 50, this.Frame.Size.Width - 20, 40);
				button.Frame = new CGRect(this.Frame.X + 10, 90, this.Frame.Size.Width - 20, 30);
				scheduleTypePicker.Frame = new CGRect(0, 120, this.Frame.Size.Width - 20, 150);
			}
			else
			{
				schedule.DayViewSettings.WorkStartHour = 7;
				schedule.DayViewSettings.WorkEndHour = 18;

				label.Frame = new CGRect(15, 10, this.Frame.Size.Width - 20, 40);
				textbutton.Frame = new CGRect(10, 60, (this.Frame.Size.Width / 2.5), 40);
				button.Frame = new CGRect(this.Frame.X + 10, 100, (this.Frame.Size.Width / 2.5), 30);
				scheduleTypePicker.Frame = new CGRect(0, 120, (this.Frame.Size.Width / 2.5), 120);
				//picker_scheduleView.Frame = new CGRect(this.Frame.X + 10, this.Frame.Y + 170, (this.Frame.Size.Width / 2.5), 120);
			}

				customizationSegment.InsertSegment("Day", 0, false);
				customizationSegment.InsertSegment("Month", 1, false);

				customizationSegment.SelectedSegment = 0;
				customizationSegment.ValueChanged += (sender, e) =>
				{
					var selectedSegmentId = (sender as UISegmentedControl).SelectedSegment;
					if (selectedSegmentId == 0)
					{
						schedule.ScheduleView = SFScheduleView.SFScheduleViewDay;
					}
					else if (selectedSegmentId == 1)
					{
						schedule.ScheduleView = SFScheduleView.SFScheduleViewMonth;
					}

				};
				this.AddSubview(customizationSegment);
			//}
			//else
			//{
			//	//this.CreateOptionView();
			//}


			//this.CreateOptionView();
			schedule.Frame = new CGRect(0, 0, this.Frame.Size.Width, this.Frame.Size.Height);
			this.AddSubview(schedule);


			//base.LayoutSubviews();
		}

		private void CreateOptionView()
		{
			this.OptionView.AddSubview(label);
			this.OptionView.AddSubview(textbutton);
			this.OptionView.AddSubview(scheduleTypePicker);
			this.OptionView.AddSubview(button);
		}

		NSMutableArray CreateAppointments()
		{
			NSDate today = new NSDate();
			NSCalendar calendar = NSCalendar.CurrentCalendar;
			// Get the year, month, day from the date
			NSDateComponents components = calendar.Components(
				NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, today);

			// Set the hour, minute, second
			components.Hour = 10;
			components.Minute = 0;
			components.Second = 0;
			NSDate startDate = calendar.DateFromComponents(components);
			// Get the year, month, day from the date
			NSDateComponents endDateComponents = calendar.Components(NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, today);

			// Set the hour, minute, second
			endDateComponents.Hour = 12;
			endDateComponents.Minute = 0;
			endDateComponents.Second = 0;
			NSDate endDate = calendar.DateFromComponents(endDateComponents);
			ScheduleAppointment appointment = new ScheduleAppointment();
			appointment.StartTime = startDate;
			appointment.EndTime = endDate;
			appointment.Subject = new NSString("Jeni's B'Day Celebration");
			appointment.AppointmentBackground = UIColor.FromRGB(0xA2, 0xC1, 0x39);
			NSDateComponents components1 = calendar.Components(NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, today);

			// Set the hour, minute, second
			components1.Hour = 11;
			components1.Minute = 0;
			components1.Second = 0;
			components1.Day = components1.Day + 1;
			NSDate startDate1 = calendar.DateFromComponents(components1);
			// Get the year, month, day from the date
			NSDateComponents endDateComponents1 = calendar.Components(NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, today);

			// Set the hour, minute, second
			endDateComponents1.Hour = 13;
			endDateComponents1.Minute = 30;
			endDateComponents1.Second = 0;
			endDateComponents1.Day = endDateComponents1.Day + 1;
			NSDate endDate1 = calendar.DateFromComponents(endDateComponents1);
			ScheduleAppointment appointment1 = new ScheduleAppointment();
			appointment1.StartTime = startDate1;
			appointment1.EndTime = endDate1;
			appointment1.Subject = new NSString("Checkup");
			appointment1.AppointmentBackground = UIColor.FromRGB(0xD8, 0x00, 0x73);
			NSMutableArray appCollection = new NSMutableArray();
			appCollection.Add(appointment);
			appCollection.Add(appointment1);
			return appCollection;
		}

	}

	public class ScheduleDelegate : SFScheduleDelegate
	{
		
		public override void didMonthcellLoaded(SFMonthCellLoaded monthCellLoaded)
		{
			NSDate date = monthCellLoaded.Date;
			NSDateFormatter dateFormat = new NSDateFormatter();
			dateFormat.DateFormat = "EEEE";
			string monthName = dateFormat.ToString(date);

			if (monthCellLoaded.IsToday)
			{
				monthCellLoaded.CellStyle.TextColor = UIColor.FromRGB(238, 199, 43);
				//monthCellLoadedaded.CellStyle.BackgroundColor = UIColor.Black;
			}

			if (((monthName == "Sunday") || (monthName == "Saturday")))
			{
				monthCellLoaded.CellStyle.TextColor = UIColor.Red;
			}
			if (monthCellLoaded.IsPreviousMonthDate)
			{
				monthCellLoaded.CellStyle.TextColor = UIColor.White;
			}
		   if (monthCellLoaded.IsNextMonthDate)
			{
				monthCellLoaded.CellStyle.TextColor = UIColor.White;
			}
		}
		public override void didAppointmentLoaded(SFAppointmentLoaded appointmentLoaded)
		{
			//if (appointmentLoaded.Appointment is ScheduleAppointment)
			//{
				if (appointmentLoaded.Appointment.Subject == "Checkup")
				{
					UIImageView hospitalImage = new UIImageView();
					hospitalImage.Image = UIImage.FromFile("Images/Hospital.png");
					hospitalImage.Frame = new CGRect(50, 35, 50.0f, 50.0f);
					UIStackView stackPanel = new UIStackView();
					stackPanel.Frame = new CGRect(0, 0, 100, 50);
					stackPanel.Add(hospitalImage);

					appointmentLoaded.AppointmentStyle.TextStyle = UIFont.FromName(@"Arial", 16);
					appointmentLoaded.AppointmentStyle.TextColor = UIColor.White;
					appointmentLoaded.View = stackPanel;
				}
				else
				{
					UIImageView familyImage = new UIImageView();
					familyImage.Image = UIImage.FromFile("Images/family.png");
					familyImage.Frame = new CGRect(50, 35, 50.0f, 30.0f);
					UIStackView stackPanel = new UIStackView();
					stackPanel.Frame = new CGRect(0, 0, 100, 30);
					stackPanel.Add(familyImage);

					appointmentLoaded.AppointmentStyle.TextStyle = UIFont.FromName(@"Arial", 16);
					appointmentLoaded.AppointmentStyle.TextColor = UIColor.White;
					appointmentLoaded.View = stackPanel;
			}
			//}
		}
		//override didap
	}

	#region CustomMonthDayCell
	public class CustomMonthDayCell : SFMonthDayView
	{
		NSDateComponents today;

		public override void Draw(CGRect rect)
		{
			today = NSCalendar.CurrentCalendar.Components(NSCalendarUnit.Day |
				NSCalendarUnit.Weekday | NSCalendarUnit.Year |
				NSCalendarUnit.Month, new NSDate());
			DrawAllBorders();
			AddAppointments();
			AddDayNumber();
		}

		public void DrawAllBorders()
		{

			CGContext context = UIGraphics.GetCurrentContext();
			context.SetLineWidth(1.0f);
			context.SaveState();
			context.SetStrokeColor((UIColor.LightGray).CGColor);

			//drawing right border
			context.MoveTo(this.Frame.Size.Width, 0);
			context.AddLineToPoint(this.Frame.Size.Width, this.Frame.Size.Height);
			context.StrokePath();
			context.RestoreState();

			context.SetLineWidth(1.0f);
			context.SaveState();
			context.SetStrokeColor((UIColor.LightGray).CGColor);

			//drawing bottom border
			context.MoveTo(this.Frame.Size.Width, this.Frame.Size.Height);
			context.AddLineToPoint(0, this.Frame.Size.Height);
			context.StrokePath();
			context.RestoreState();

			context.SetLineWidth(1.0f);
			context.SaveState();
			context.SetStrokeColor((UIColor.LightGray).CGColor);

			//drawing left border
			context.MoveTo(0, this.Frame.Size.Height);
			context.AddLineToPoint(0, 0);
			context.StrokePath();
			context.RestoreState();

			context.SetLineWidth(1.0f);
			context.SaveState();
			context.SetStrokeColor((UIColor.LightGray).CGColor);

			//drawing left border
			context.MoveTo(0, 0);
			context.AddLineToPoint(this.Frame.Size.Width, 0); context.StrokePath();
			context.RestoreState();

		}
		public void AddAppointments()
		{
			float xPosition = 0;
			float yPosition = 20;
			uint appCount = 0;
			if (this.VisibleAppointments != null)
			{
				appCount = (uint)this.VisibleAppointments.Count;
			}
			for (int i = 0; i < appCount; i++)
			{
#if __UNIFIED__
				ScheduleAppointment app = this.VisibleAppointments.GetItem<ScheduleAppointment>((nuint)i);
#else
				ScheduleAppointment app = this.VisibleAppointments.GetItem<ScheduleAppointment>(i);
#endif
				CGContext context = UIGraphics.GetCurrentContext();
				context.SetLineWidth(1.0f);
				context.SaveState();
				context.SetStrokeColor((app.AppointmentBackground).CGColor);
				context.SetFillColor((app.AppointmentBackground).CGColor);

				CGRect rect = new CGRect(xPosition, yPosition, 20, 5);
				context.FillRect(rect);
				context.StrokeRect(rect);
				context.RestoreState();

				yPosition += 7;
				if (yPosition > this.Frame.Size.Height)
				{
					yPosition = (float)(this.Frame.Size.Height - 10);
				}
			}
		}

		public void AddDayNumber()
		{
			NSString labelText = new NSString(this.Day.Day.ToString());
			UIFont textFont = UIFont.SystemFontOfSize(17.0f);
			UIColor textColor = UIColor.Black;
			int presentDay = (int)this.Day.Day;
			int presentMonth = (int)this.Day.Month;
			int presentYear = (int)this.Day.Year;
			if (!this.IsInCurrentMonth)
			{
				textColor = UIColor.LightGray;
			}
			if (presentDay == today.Day && presentMonth == today.Month && presentYear == today.Year)
			{
				textColor = UIColor.Blue;
			}
			if (this.IsSelected)
			{
				textColor = UIColor.Brown;
			}
			CGSize textSize = labelText.GetSizeUsingAttributes(new UIStringAttributes()
			{
				Font = textFont,
				ForegroundColor = textColor
			});

			CGRect textRect = new CGRect((float)Math.Ceiling(this.Bounds.Size.Width - (textSize.Width) - 5), (float)Math.Ceiling(textSize.Height / 2), textSize.Width, textSize.Height);
			UIStringAttributes attributes = new UIStringAttributes { ForegroundColor = textColor, Font = textFont };
			labelText.DrawString(textRect, attributes);
		}

	}
	#endregion

	#region CustomDayAppointment

	public class CustomDayAppointment : UIView
	{
		//static UIImageView hospitalImage;
		//static UIImage bDayImage;
		//UIImageView appointmentImage = new UIImageView();
		//public CustomDayAppointment()
		//{
		//	hospitalImage.Image = UIImage.FromFile("Images/Hospital.png");

		//	bDayImage = new UIImage("Images/family.png");
		//	appointmentImage = hospitalImage;
		//	appointmentImage.Frame = new CGRect(50, 35, 50.0f, 50.0f);
		//	this.Add(hospitalImage);

		//}

		//public override void Draw(CGRect rect)
		//{
		//	if (this.Data.Subject == "Checkup")
		//	{
		//		appointmentImage = hospitalImage;
		//	}
		//	else
		//	{
		//		appointmentImage = bDayImage;
		//	}
		//	appointmentImage.Draw(new CGRect(50, 35, 50.0f, 50.0f));

		//	base.Draw(rect);
		//}
		public override void LayoutSubviews()
		{
			base.LayoutSubviews();

		}
	}

	#endregion
}

