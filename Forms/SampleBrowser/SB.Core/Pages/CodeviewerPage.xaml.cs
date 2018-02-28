#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
	public partial class CodeViewerPage : ContentPage
    {
        #region fields

        private string[] fileNames, fileContent;

        #endregion

        #region ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="CodeViewerPage"/> class.
        /// </summary>
        public CodeViewerPage(string controlName, string sampleName, string pageTitle)
		{
			InitializeComponent();

            if(Device.RuntimePlatform == Device.UWP && Device.Idiom != TargetIdiom.Phone)
            {
                Grid.SetRow(horizontalSampleListView, 0);
                Grid.SetRow(codeView, 1);
            }

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
					fileNames = codeFiles.Select(c => c.Key).ToArray();
					fileContent = codeFiles.Select(c => c.Value).ToArray();

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
		}

        #endregion

        #region methods

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

        #endregion
    }
}