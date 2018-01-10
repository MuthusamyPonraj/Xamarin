#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.ListView.XForms;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using System.Reflection;

namespace SampleBrowser.Core
{
	/// <summary>
    /// Content page for displaying Code Viewer functionality
	/// </summary>
	public partial class CodeviewerPage : ContentPage
    {
        double samplesHeight, listViewHeight;
        string[] fileNames, fileContent;

		/// <summary>
		/// Initializes a new instance of the <see cref="CodeviewerPage"/> class.
		/// </summary>
        public CodeviewerPage(string controlName, string sampleName, string pageTitle)
		{
			InitializeComponent();

            if (controlName != null && sampleName != null)
			{
                AssemblyName assemblyName = new AssemblyName("SampleBrowser." + controlName + ", Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
                Assembly assembly = Assembly.Load(assemblyName);
                Title = pageTitle;
				var codeFiles = new List<KeyValuePair<string, string>>();
                if (assembly != null)
                {
                    codeFiles = DependencyService.Get<ISampleBrowserService>().GetCodeViewerContent(controlName, sampleName);
                }
                else
                {
                    codeFiles.Add(new KeyValuePair<string, string>(controlName, "Files in Resources/CodeFiles/" + controlName + " or " + sampleName + " folder is missing"));
                }

				if (codeFiles != null)
				{
					fileNames = codeFiles.Select(kvp => kvp.Key).ToArray();
					fileContent = codeFiles.Select(kvp => kvp.Value).ToArray();

					if (fileNames != null)
					{
						horizontalSampleListView.ItemsSource = fileNames;
					}
					if (fileContent[0] != null)
					{
						code.Text = fileContent[0];
					}

					if (horizontalSampleListView != null)
					{
                        horizontalSampleListView.SelectedItem = fileNames[0];
                        horizontalSampleListView.ItemTemplate = new CodeLabelSelector();
					}
				}
			}
			
			
            if (Device.RuntimePlatform == Device.UWP)
            {
                if (Device.Idiom == TargetIdiom.Desktop)
                {
                    listViewHeight = 0.95 * SampleBrowser.ScreenHeight;
                    horizontalSampleListView.ItemSize = 200;
                }
                else
                {
                    listViewHeight = 0.90 * SampleBrowser.ScreenHeight;
                }
                horizontalSampleListView.BackgroundColor = Color.FromHex("#343435");
            }
            else
            {
                if (Device.Idiom == TargetIdiom.Tablet)
                    listViewHeight = (float)(0.08 * SampleBrowser.ScreenHeight);
                else
                    listViewHeight = (float)(0.1 * SampleBrowser.ScreenHeight);
            }
            horListViewRow.Height = listViewHeight;
            samplesRow.Height = SampleBrowser.ScreenHeight - listViewHeight;
		}

		  /// <summary>
        /// Method for calculating Screen Height and Width.
        /// </summary>
        protected override void OnSizeAllocated(double width, double height)
        {
            if (Device.RuntimePlatform == Device.UWP)
            {
                if (width > 0 && height > 0)
                {
                    samplesHeight = height - (SampleBrowser.NavigationBarHeight + SampleBrowser.StatusBarHeight);

                    if (Device.RuntimePlatform == Device.UWP)
                    {
                        if (Device.Idiom == TargetIdiom.Desktop)
                        {
                            listViewHeight = 0.95 * height;
                            horizontalSampleListView.ItemSize = 200;
                        }
                        else
                        {
                            listViewHeight = 0.90 * height;
                        }
                        horizontalSampleListView.BackgroundColor = Color.FromHex("#343435");
                    }
                    else
                    {
                        if (Device.Idiom == TargetIdiom.Tablet)
                            listViewHeight = (float)(0.08 * height);
                        else
                            listViewHeight = (float)(0.1 * samplesHeight);
                    }
                    horListViewRow.Height = listViewHeight;
                    samplesRow.Height = height - listViewHeight;
                }
            }
            base.OnSizeAllocated(width, height);
        }
		
		private void HorizontalSampleListView_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            int index;
            codeView.ScrollToAsync(code, ScrollToPosition.Start, false);
            if (horizontalSampleListView != null && e.ItemData != null)
            {
                index = horizontalSampleListView.DataSource.DisplayItems.IndexOf(e.ItemData);
                (horizontalSampleListView.LayoutManager as LinearLayout).ScrollToRowIndex(index - 1);

                if (fileContent != null && index != -1 && fileNames != null)
				{
                    code.Text = fileContent[index];
                }
            }
        }
    }
}