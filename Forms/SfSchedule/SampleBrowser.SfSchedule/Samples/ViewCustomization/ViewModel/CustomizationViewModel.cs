#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
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

        private ScheduleAppointment family, medical;

        #region HeaderLabelValue
        private string headerLabelValue = DateTime.Today.Date.ToString("dd, MMMM, yyyy");

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
            family = new ScheduleAppointment();
            family.Subject = "Family";
            family.StartTime = DateTime.Now.Date.AddHours(10);
            family.EndTime = DateTime.Now.Date.AddHours(12);
            family.Color = (Color.FromHex("#FFD80073"));

            medical = new ScheduleAppointment();
            medical.Subject = "Checkup";
            medical.StartTime = DateTime.Now.Date.AddDays(1).AddHours(9);
            medical.EndTime = DateTime.Now.Date.AddDays(1).AddHours(11);
            medical.Color = Color.FromHex("#FFA2C139");

            Appointments.Add(family);
            Appointments.Add(medical);
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

