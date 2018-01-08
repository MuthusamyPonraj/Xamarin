#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfSchedule
{
    #region AppointmentEditorViewModel
    [Preserve(AllMembers = true)]
    public class AppointmentEditorViewModel : INotifyPropertyChanged
    {
        List<string> currentDayMeetings;
        List<Color> color_collection;

        #region ScheduleType

        private ObservableCollection<ScheduleTypeClass> scheduleTypeCollection = new ObservableCollection<ScheduleTypeClass>();

        public ObservableCollection<ScheduleTypeClass> ScheduleTypeCollection
        {
            get { return scheduleTypeCollection; }
            set
            {
                scheduleTypeCollection = value;
                RaiseOnPropertyChanged("ScheduleTypeCollection");
            }
        }
        #endregion

        #region ListOfMeeting

        private ObservableCollection<Meeting> listOfMeeting;

        public ObservableCollection<Meeting> ListOfMeeting
        {
            get { return listOfMeeting; }
            set
            {
                listOfMeeting = value;
                RaiseOnPropertyChanged("ListOfMeeting");
            }
        }
        #endregion

        #region HeaderLabelValue
        private string headerLabelValue = DateTime.Today.Date.ToString("MMMM, yyyy");

        public string HeaderLabelValue
        {
            get { return headerLabelValue; }
            set
            {
                headerLabelValue = value;
                RaiseOnPropertyChanged("HeaderLabelValue");
            }
        }
        #endregion

        public AppointmentEditorViewModel()
        {
            ListOfMeeting = new ObservableCollection<Meeting>();
            InitializeDataForBookings();
            BookingAppointments();
            AddScheduleType();
        }

        private void AddScheduleType()
        {
            this.ScheduleTypeCollection.Add(new ScheduleTypeClass() { ScheduleType = "Day view" });
            this.ScheduleTypeCollection.Add(new ScheduleTypeClass() { ScheduleType = "Week view" });
            this.ScheduleTypeCollection.Add(new ScheduleTypeClass() { ScheduleType = "Work week view" });
            this.ScheduleTypeCollection.Add(new ScheduleTypeClass() { ScheduleType = "Month view" });
        }

        #region BookingAppointments

        private void BookingAppointments()
        {
            Random randomTime = new Random();
            List<Point> randomTimeCollection = GettingTimeRanges();

            DateTime date;
            DateTime DateFrom = DateTime.Now.AddDays(-10);
            DateTime DateTo = DateTime.Now.AddDays(10);
            DateTime dateRangeStart = DateTime.Now.AddDays(-3);
            DateTime dateRangeEnd = DateTime.Now.AddDays(3);

            for (date = DateFrom; date < DateTo; date = date.AddDays(1))
            {
                if ((DateTime.Compare(date, dateRangeStart) > 0) && (DateTime.Compare(date, dateRangeEnd) < 0))
                {
                    for (int AdditionalAppointmentIndex = 0; AdditionalAppointmentIndex < 3; AdditionalAppointmentIndex++)
                    {
                        Meeting meeting = new Meeting();
                        int hour = (randomTime.Next((int)randomTimeCollection[AdditionalAppointmentIndex].X, (int)randomTimeCollection[AdditionalAppointmentIndex].Y));
                        meeting.From = new DateTime(date.Year, date.Month, date.Day, hour, 0, 0);
                        meeting.To = (meeting.From.AddHours(1));
                        meeting.EventName = currentDayMeetings[randomTime.Next(9)];
                        meeting.color = color_collection[randomTime.Next(9)];
                        meeting.IsAllDay = false;
                        ListOfMeeting.Add(meeting);
                    }
                }
                else
                {
                    Meeting meeting = new Meeting();
                    meeting.From = new DateTime(date.Year, date.Month, date.Day, randomTime.Next(9, 11), 0, 0);
                    meeting.To = (meeting.From.AddDays(2).AddHours(1));
                    meeting.EventName = currentDayMeetings[randomTime.Next(9)];
                    meeting.color = color_collection[randomTime.Next(9)];
                    meeting.IsAllDay = true;
                    ListOfMeeting.Add(meeting);
                }
            }
        }

        #endregion BookingAppointments

        #region GettingTimeRanges

        private List<Point> GettingTimeRanges()
        {
            List<Point> randomTimeCollection = new List<Point>();
            randomTimeCollection.Add(new Point(9, 11));
            randomTimeCollection.Add(new Point(12, 14));
            randomTimeCollection.Add(new Point(15, 17));

            return randomTimeCollection;
        }

        #endregion GettingTimeRanges

        #region InitializeDataForBookings

        private void InitializeDataForBookings()
        {
            currentDayMeetings = new List<string>();
            currentDayMeetings.Add("General Meeting");
            currentDayMeetings.Add("Plan Execution");
            currentDayMeetings.Add("Project Plan");
            currentDayMeetings.Add("Consulting");
            currentDayMeetings.Add("Performance Check");
            currentDayMeetings.Add("Yoga Therapy");
            currentDayMeetings.Add("Plan Execution");
            currentDayMeetings.Add("Project Plan");
            currentDayMeetings.Add("Consulting");
            currentDayMeetings.Add("Performance Check");

            color_collection = new List<Color>();
            color_collection.Add(Color.FromHex("#FF339933"));
            color_collection.Add(Color.FromHex("#FF00ABA9"));
            color_collection.Add(Color.FromHex("#FFE671B8"));
            color_collection.Add(Color.FromHex("#FF1BA1E2"));
            color_collection.Add(Color.FromHex("#FFD80073"));
            color_collection.Add(Color.FromHex("#FFA2C139"));
            color_collection.Add(Color.FromHex("#FFA2C139"));
            color_collection.Add(Color.FromHex("#FFD80073"));
            color_collection.Add(Color.FromHex("#FF339933"));
            color_collection.Add(Color.FromHex("#FFE671B8"));
            color_collection.Add(Color.FromHex("#FF00ABA9"));

        }

        #endregion InitializeDataForBookings

        #region Property Changed Event

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaiseOnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
    #endregion

    #region ScheduleTypeClass
    public class ScheduleTypeClass : INotifyPropertyChanged
    {

        #region ScheduleType

        private string scheduleType=" ";

        public string ScheduleType
        {
            get { return scheduleType; }
            set
            {
                scheduleType = value;
                RaiseOnPropertyChanged("ScheduleType");
            }
        } 
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaiseOnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    } 
    #endregion
}




