#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Xml;
using SampleBrowser.Core;
using Xamarin.Forms;

namespace SampleBrowser
{
    public class ControlPageViewModel
    {

		//AllControlDetails
		private ObservableCollection<ControlModel> allControlsList;

		public ObservableCollection<ControlModel> AllControlsList
		{
			get { return allControlsList; }
			set { allControlsList = value; }
		}


		public ControlPageViewModel()
        {
			allControlsList = new ObservableCollection<ControlModel>();

			PopulateControlsList();
        }

        AssemblyName controlName;
        Assembly controlAssemblies;
        private void PopulateControlsList()
        {
            bool isUpdated = false;
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("SampleBrowser.ControlsList.ControlsList.xml");
            string currentControlTitle = string.Empty;
            using (var reader = new StreamReader(stream))
            {
                var xmlReader = XmlReader.Create(reader);
                xmlReader.Read();

                while (!xmlReader.EOF)
                {
                    if (xmlReader.Name == "Group" && xmlReader.IsStartElement())
                    {
                        if (xmlReader.HasAttributes)
                        {
                            var control = new ControlModel();
                            control.ImageId = GetDataFromXmlReader(xmlReader, "ImageId");
                            control.Title = GetDataFromXmlReader(xmlReader, "Title");
                            control.ControlName = GetDataFromXmlReader(xmlReader, "ControlName");
                            try
                            {
                                controlName = new AssemblyName("SampleBrowser." + control.ControlName + ", Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
                                controlAssemblies = Assembly.Load(controlName);
                                if (controlAssemblies != null)
                                {
                                   var samples = Core.SampleBrowser.GetSamplesData("SampleBrowser." + control.ControlName + ".SamplesList.SamplesList.xml", "SampleBrowser." + control.ControlName, ref isUpdated);
                                    if (samples.Count > 0 && samples != null)
                                    {
                                        control.Samples = samples;
                                        control.SamplesCount = samples.Count;
                                    }
                                    if (isUpdated)
                                        control.UpdateType = GetUpdateType("true", "IsUpdated");
                                }
                            }
                            catch
                            {
                                
                            }
                            control.Description = GetDataFromXmlReader(xmlReader, "Description");
                            control.Tags = GetControlSearchTags(xmlReader);

                            if (null != xmlReader.GetAttribute("IsPreview"))
                            {
                                control.UpdateType = GetUpdateType(GetDataFromXmlReader(xmlReader, "IsPreview"), "IsPreview");
                            }
                            if (null != xmlReader.GetAttribute("IsNew"))
                            {
                                control.UpdateType = GetUpdateType(GetDataFromXmlReader(xmlReader, "IsNew"), "IsNew");
                            }
                            currentControlTitle = control.Title;
                            if (control != null)
                            {
                                if (control.Title == "RadialMenu" && Device.RuntimePlatform == Device.UWP)
                                    continue;
                                allControlsList.Add(control);
                            }

                        }
                    }
                    xmlReader.Read();
                }
            }
        }

        string GetUpdateType(string value, string type)
		{
			if (value == "true" && type == "IsPreview")
			{
				return "Tags/preview.png";
			}

			if (value == "true" && type == "IsNew")
			{
				return "Tags/newimage.png";
			}

			if (value == "true" && type == "IsUpdated")
			{
				return "Tags/updated.png";
			}
			return "";
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