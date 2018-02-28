#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Syncfusion.SfSunburstChart.iOS;
using CoreGraphics;
using UIKit;
using System.Collections.ObjectModel;

namespace SampleBrowser
{
	public class SunburstChart : SampleView
	{
		SfSunburstChart chart;
		public SunburstChart()
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

            chart = new SfSunburstChart();
			chart.ItemsSource = Data;
			chart.Radius = 0.95;
			chart.ValueMemberPath = "EmployeesCount";
			var levels = new SunburstLevelCollection()
            {
				new SunburstHierarchicalLevel() { GroupMemberPath = "Country"},
				new SunburstHierarchicalLevel() { GroupMemberPath = "JobDescription"},
				new SunburstHierarchicalLevel() { GroupMemberPath = "JobGroup"},
			};
			chart.Levels = levels;
			chart.ColorModel.Palette = SunburstColorPalette.Pineapple;

            chart.Title.IsVisible = true;
            chart.Title.Text = "Employee Count";
			chart.Title.Margin = new UIEdgeInsets(10, 5, 5, 5);

            chart.Legend.IsVisible = true;
            chart.Legend.LegendPosition = SunburstDockPosition.Bottom;

            chart.DataLabel.ShowLabel = true;

            this.AddSubview(chart);

		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();

			chart.Frame = new CGRect(0, 20, this.Bounds.Width, this.Bounds.Height);
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