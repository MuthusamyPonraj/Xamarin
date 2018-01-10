#region Copyright Syncfusion Inc. 2001 - 2017
// Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using System;
using Syncfusion.SfSunburstChart.Android;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SampleBrowser
{
	public class SunburstChart :SamplePage
	{
		SfSunburstChart chart;
		public override View GetSampleContent(Context context)
		{
			var Data = new ObservableCollection<SunburstModel>();

            Data.Add(new SunburstModel() { Category = "Employees", Country = "USA", JobDescription = "Sales", JobGroup = "Executive", EmployeesCount = 50 });
            Data.Add(new SunburstModel() { Category = "Employees", Country = "USA", JobDescription = "Sales", JobGroup = "Analyst", EmployeesCount = 40 });
            Data.Add(new SunburstModel() { Category = "Employees", Country = "USA", JobDescription = "Marketing", EmployeesCount = 40 });
            Data.Add(new SunburstModel() { Category = "Employees", Country = "USA", JobDescription = "Technical", JobGroup = "Testers", EmployeesCount = 35 });
            Data.Add(new SunburstModel() { Category = "Employees", Country = "USA", JobDescription = "Technical", JobGroup = "Developers", JobRole = "Windows", EmployeesCount = 175 });
            Data.Add(new SunburstModel() { Category = "Employees", Country = "USA", JobDescription = "Technical", JobGroup = "Developers", JobRole = "Web", EmployeesCount = 70 });
            Data.Add(new SunburstModel() { Category = "Employees", Country = "USA", JobDescription = "Management", EmployeesCount = 40 });
            Data.Add(new SunburstModel() { Category = "Employees", Country = "USA", JobDescription = "Accounts", EmployeesCount = 60 });

            Data.Add(new SunburstModel() { Category = "Employees", Country = "India", JobDescription = "Technical", JobGroup = "Testers", EmployeesCount = 33 });
            Data.Add(new SunburstModel() { Category = "Employees", Country = "India", JobDescription = "Technical", JobGroup = "Developers", JobRole = "Windows", EmployeesCount = 125 });
            Data.Add(new SunburstModel() { Category = "Employees", Country = "India", JobDescription = "Technical", JobGroup = "Developers", JobRole = "Web", EmployeesCount = 60 });
            Data.Add(new SunburstModel() { Category = "Employees", Country = "India", JobDescription = "HR Executives", EmployeesCount = 70 });
            Data.Add(new SunburstModel() { Category = "Employees", Country = "India", JobDescription = "Accounts", EmployeesCount = 45 });

            Data.Add(new SunburstModel() { Category = "Employees", Country = "Germany", JobDescription = "Sales", JobGroup = "Executive", EmployeesCount = 30 });
            Data.Add(new SunburstModel() { Category = "Employees", Country = "Germany", JobDescription = "Sales", JobGroup = "Analyst", EmployeesCount = 40 });
            Data.Add(new SunburstModel() { Category = "Employees", Country = "Germany", JobDescription = "Marketing", EmployeesCount = 50 });
            Data.Add(new SunburstModel() { Category = "Employees", Country = "Germany", JobDescription = "Technical", JobGroup = "Testers", EmployeesCount = 40 });
            Data.Add(new SunburstModel() { Category = "Employees", Country = "Germany", JobDescription = "Technical", JobGroup = "Developers", JobRole = "Windows", EmployeesCount = 65 });
            Data.Add(new SunburstModel() { Category = "Employees", Country = "Germany", JobDescription = "Technical", JobGroup = "Developers", JobRole = "Web", EmployeesCount = 27 });
            Data.Add(new SunburstModel() { Category = "Employees", Country = "Germany", JobDescription = "Management", EmployeesCount = 33 });
            Data.Add(new SunburstModel() { Category = "Employees", Country = "Germany", JobDescription = "Accounts", EmployeesCount = 55 });

            Data.Add(new SunburstModel() { Category = "Employees", Country = "UK", JobDescription = "Technical", JobGroup = "Testers", EmployeesCount = 25 });
            Data.Add(new SunburstModel() { Category = "Employees", Country = "UK", JobDescription = "Technical", JobGroup = "Developers", JobRole = "Windows", EmployeesCount = 96 });
            Data.Add(new SunburstModel() { Category = "Employees", Country = "UK", JobDescription = "Technical", JobGroup = "Developers", JobRole = "Web", EmployeesCount = 55 });
            Data.Add(new SunburstModel() { Category = "Employees", Country = "UK", JobDescription = "HR Executives", EmployeesCount = 60 });
            Data.Add(new SunburstModel() { Category = "Employees", Country = "UK", JobDescription = "Accounts", EmployeesCount = 30 });

            chart = new SfSunburstChart(context);
			chart.ItemsSource = Data;
			chart.Radius = 0.95;
			chart.ValueMemberPath = "EmployeesCount";
			var levels = new SunburstLevelCollection()
            {
				new SunburstHierarchicalLevel() { GroupMemberPath = "Country"},
				new SunburstHierarchicalLevel() { GroupMemberPath = "JobDescription"},
				new SunburstHierarchicalLevel() { GroupMemberPath = "JobGroup"},
				new SunburstHierarchicalLevel() { GroupMemberPath = "JobRole"}
            };
			chart.Levels = levels;

            chart.Title.IsVisible = true;
            chart.Title.Margin = new Thickness(10, 5, 5, 5);
            chart.Title.Text = "Employees Count";
            chart.Title.TextSize = 20;

            chart.Legend.IsVisible = true;

            chart.DataLabel.ShowLabel = true;

            return chart;
		}
	}
		public class SunburstModel
		{
			public string Category { get; set; }
			public string Country { get; set; }
			public string JobDescription { get; set; }
			public string JobGroup { get; set; }
			public string JobRole { get; set; }
			public double EmployeesCount { get; set; }	
	}
}