#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Xml;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.Core
{
	/// <summary>
	/// ViewModel class for getting Samples from control.
	/// </summary>
	public class SampleBrowser
	{
        public static bool IsIndividualSB;
		/// <summary>
		/// Gets or sets ScreenWidth of Application.
		/// </summary>
		public static double ScreenWidth;

		/// <summary>
		/// Gets or sets ScreenHeight of Application.
		/// </summary>
		public static double ScreenHeight;

		/// <summary>
		/// Gets or sets NavigationBar Height of Application.
		/// </summary>
		public static double NavigationBarHeight;

		/// <summary>
		/// Gets or sets StatusBar Height of Application.
		/// </summary>
		public static double StatusBarHeight;

		/// <summary>
		/// Gets or sets Screen Density of Application.
		/// </summary>
		public static double Density;

		/// <summary>
		/// Initializes a new instance of the <see cref="SampleBrowser"/> class.
		/// </summary>
		public static NavigationPage GetMainPage(object controlsList, string assemblyName)
		{
            IsIndividualSB = true;

			ContentPage contentPage;
			bool isUpdated = false;

			var controls = controlsList as ControlModel;
			var samples = GetSamplesData(assemblyName + ".SamplesList.SamplesList.xml", assemblyName, ref isUpdated);
			if (samples != null && !string.IsNullOrEmpty(assemblyName))
			{

				if (assemblyName == "SampleBrowser.SfChart")
				{
					contentPage = new ChartSamplesPage(samples);
				}
				else
				{
					if (samples.Count < 6)
					{
						if (controls != null)
							contentPage = new AllControlsSamplePage(controls, samples, controls.Title, 0);
						else
							contentPage = new AllControlsSamplePage(controlsList, samples, controlsList.ToString(), 0);
					}
					else
					{
						if (controls != null)
							contentPage = new SamplesListPage(samples, controls.Title);
						else
							contentPage = new SamplesListPage(samples, controlsList.ToString());
					}
				}
			}
			else
			{
				contentPage = new ContentPage();
			}
			return new NavigationPage(contentPage)
			{
				BarTextColor = Color.White,
				BarBackgroundColor = Color.FromHex("007DE6")
			};
		}

		/// <summary>
		/// Returns ContentPage based on SamplesCount in control.
		/// </summary>
		public static ContentPage GetSamplesPage(ObservableCollection<SamplesModel> sampleList, string assemblyName, string controlName, string controlTitle)
		{
			ContentPage contentPage;

			if (sampleList != null && !string.IsNullOrEmpty(assemblyName))
			{
				if (assemblyName == "SampleBrowser.SfChart")
				{
					contentPage = new ChartSamplesPage(sampleList);
				}
				else
				{
					if (sampleList.Count < 6)
					{
						contentPage = new AllControlsSamplePage(null, sampleList, controlName, 0);

					}
					else
					{
						contentPage = new SamplesListPage(sampleList, controlName);
						contentPage.Title = controlTitle;
					}
				}
			}
			else
			{
				contentPage = new ContentPage();
			}

			return contentPage;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		static string GetUpdateType(string value, string type)
		{
            string imageTag = "";
            string updateTypeValue = (value as string).ToLower();
            if (updateTypeValue == "true" && type == "IsPreview")
            {
                if (Device.RuntimePlatform == Device.UWP)
                    imageTag = IsIndividualSB ? "SampleBrowser.Core.UWP/Tags/preview.png" : "Tags/preview.png";
                else
                    imageTag = "Tags/preview.png";
            }

            if (updateTypeValue == "true" && type == "IsNew")
			{
                if (Device.RuntimePlatform == Device.UWP)
                    imageTag = IsIndividualSB ? "SampleBrowser.Core.UWP/Tags/newimage.png" : "Tags/newimage.png";
                else
                    imageTag = "Tags/newimage.png";
			}

            if (updateTypeValue == "true" && type == "IsUpdated")
			{
                if (Device.RuntimePlatform == Device.UWP)
                    imageTag = IsIndividualSB ? "SampleBrowser.Core.UWP/Tags/updated.png" : "Tags/updated.png";
                else
                    imageTag = "Tags/updated.png";
			}
            return imageTag;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SampleBrowser"/> class.
		/// </summary>
		public SampleBrowser()
		{
		}

		/// <summary>
		/// Gets or sets Samples in the control.
		/// </summary>
		public static ObservableCollection<SamplesModel> GetSamplesData(string xmlFileName, string assemblyName, ref bool IsUpdated)
		{
			var samplesList = new ObservableCollection<SamplesModel>();
			IsUpdated = false;
			Stream stream = DependencyService.Get<ISampleBrowserService>().GetSamplesList(xmlFileName, assemblyName);
			string currentControlTitle = string.Empty;
			if (stream != null)
			{
				using (var reader = new StreamReader(stream))
				{
					var xmlReader = XmlReader.Create(reader);
					xmlReader.Read();

					while (!xmlReader.EOF)
					{
						if (xmlReader.Name == "Sample" && xmlReader.IsStartElement())
						{
							var sample = new SamplesModel();
							sample.Description = GetDataFromXmlReader(xmlReader, "Description");
							sample.Title = GetDataFromXmlReader(xmlReader, "Title");
							sample.Name = GetDataFromXmlReader(xmlReader, "Name");
							sample.ImageSelected = GetDataFromXmlReader(xmlReader, "ImageSelected");
							sample.Icon = assemblyName + "." + GetDataFromXmlReader(xmlReader, "Icon");
							sample.Category = GetDataFromXmlReader(xmlReader, "Category");
                            sample.EnableLoadingIndicator = GetLoadingIndicatorTag(GetDataFromXmlReader(xmlReader, "EnableLoadingIndicator"));

							if (null != xmlReader.GetAttribute("IsUpdated"))
							{
								sample.UpdateType = GetUpdateType(GetDataFromXmlReader(xmlReader, "IsUpdated"), "IsUpdated");
								IsUpdated = true;
							}
							else if (null != xmlReader.GetAttribute("IsNew"))
							{
								sample.UpdateType = GetUpdateType(GetDataFromXmlReader(xmlReader, "IsNew"), "IsNew");
								IsUpdated = true;
							}

							//ImageEditor and RadialMenu control doesn't available in UWP, so skip this sample.
							if (Device.RuntimePlatform == Device.UWP && (currentControlTitle == "RadialMenu")) continue;

							// iOS Word viewer doesn't preserves the Charts in the document, So hide the Chart samples from the Xamarin.Forms.iOS samplebrowser
							if (Device.RuntimePlatform == Device.iOS && (sample.Title == "Bar Chart" || sample.Title == "Pie Chart"))
								continue;

							if (sample != null)
							{
								samplesList.Add(sample);
							}
						}
						xmlReader.Read();
					}
				}
			}
			return samplesList;
		}

        static bool GetLoadingIndicatorTag(string attribute)
        {
            bool enableIndicator;
            bool.TryParse(attribute, out enableIndicator);
            return enableIndicator;
        }

		static string GetDataFromXmlReader(XmlReader reader, string attribute)
		{
			reader.MoveToAttribute(attribute);
			return reader.Value;
		}

		string[] GetControlSearchTags(XmlReader xmlReader)
		{
			string[] tags;
			if (xmlReader.GetAttribute("SearchTags") != null)
			{
				xmlReader.MoveToAttribute("SearchTags");
				tags = xmlReader.Value.Split(',');
				return (tags.Length > 0) ? tags : null;
			}
			return null;
		}
	}
}