#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using System.ComponentModel;

namespace SampleBrowser.SfSchedule
{
	[Preserve(AllMembers = true)]
	public class CustomizationViewModel : INotifyPropertyChanged
    {
		#region Properties
		public ScheduleAppointmentCollection Appointments { get; set; }

        private ScheduleAppointment conference, medical, systemTroubleShoot, birthday;

        #region HeaderLabelValue
        private string headerLabelValue = DateTime.Today.Date.ToString("dd, MMMM yyyy");

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

        #endregion Properties

        #region Constructor

        public CustomizationViewModel()
		{
			Appointments = new ScheduleAppointmentCollection();
            conference = new ScheduleAppointment();
            conference.Subject = "Conference";
            conference.StartTime = DateTime.Now.Date.AddHours(10);
            conference.EndTime = DateTime.Now.Date.AddHours(12);
            conference.Color = (Color.FromHex("#FFD80073"));

            systemTroubleShoot = new ScheduleAppointment();
            systemTroubleShoot.Subject = "System Troubleshoot";
            systemTroubleShoot.StartTime = DateTime.Now.Date.AddDays(1).AddHours(9);
            systemTroubleShoot.EndTime = DateTime.Now.Date.AddDays(1).AddHours(11);
            systemTroubleShoot.Color = Color.FromHex("#FF00ABA9");
            systemTroubleShoot.IsAllDay = true;

            medical = new ScheduleAppointment();
            medical.Subject = "Checkup";
            medical.StartTime = DateTime.Now.Date.AddDays(2).AddHours(10);
            medical.EndTime = DateTime.Now.Date.AddDays(2).AddHours(12);
            medical.Color = Color.FromHex("#FFA2C139");

            birthday = new ScheduleAppointment();
            birthday.Subject = "Jeni's Birthday";
            birthday.StartTime = DateTime.Now.Date.AddDays(3).AddHours(9);
            birthday.EndTime = DateTime.Now.Date.AddDays(3).AddHours(11);
            birthday.Color = Color.FromHex("#FF1BA1E2");
            birthday.IsAllDay = true;

            Appointments.Add(conference);
            Appointments.Add(systemTroubleShoot);
            Appointments.Add(medical);
            Appointments.Add(birthday);
        }

		#endregion Constructor

        #region Property Changed Event

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaiseOnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}

