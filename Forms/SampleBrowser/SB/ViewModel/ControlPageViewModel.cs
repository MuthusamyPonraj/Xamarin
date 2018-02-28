#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Xml;
using SampleBrowser.Core;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;

namespace SampleBrowser
{
    public class ControlPageViewModel
    {
        #region fields

        //AllControlDetails
        private ObservableCollection<ControlModel> controlsList;

        private IEnumerable<SampleModel> samplesList;

        private AssemblyName controlName;

        private Assembly controlAssemblies;

        #endregion

        #region ctor

        public ControlPageViewModel()
        {
            controlsList = new ObservableCollection<ControlModel>();

            samplesList = new ObservableCollection<SampleModel>();

			SortOption = SortOption.None;

            PopulateControlsList();
        }

        #endregion

        #region properties

        public ObservableCollection<ControlModel> ControlsList
		{
			get { return controlsList; }
			set { controlsList = value; }
		}

        public IEnumerable<SampleModel> SamplesList
        {
            get { return samplesList; }
            set { samplesList = value; }
        }

		public SortOption SortOption
		{
			get;
			set;
		}

        #endregion

        #region methods

        private static string GetDataFromXmlReader(XmlReader reader, string attribute)
        {
            reader.MoveToAttribute(attribute);
            return reader.Value;
        }

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
                            var controlModel = new ControlModel();
                            controlModel.ImageId = GetDataFromXmlReader(xmlReader, "ImageId");
                            controlModel.Title = GetDataFromXmlReader(xmlReader, "Title");
                            controlModel.ControlName = GetDataFromXmlReader(xmlReader, "ControlName");
                            try
                            {
                                controlName = new AssemblyName("SampleBrowser." + controlModel.ControlName + ", Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
                                controlAssemblies = Assembly.Load(controlName);
                                if (controlAssemblies != null)
                                {
                                   var samples = Core.SampleBrowser.GetSamplesData("SampleBrowser." + controlModel.ControlName + ".SamplesList.SamplesList.xml", "SampleBrowser." + controlModel.ControlName, ref isUpdated);
                                    if (samples.Count > 0 && samples != null)
                                    {
                                        controlModel.Samples = samples;
                                        controlModel.SamplesCount = samples.Count;
                                        samplesList = samplesList.Concat(samples);
                                    }

                                    if (isUpdated)
                                    {
                                        controlModel.UpdateType = GetUpdateType("true", "IsUpdated");
                                    }
                                }
                            }
                            catch
                            {
                            }

                            controlModel.Description = GetDataFromXmlReader(xmlReader, "Description");
                            controlModel.Tags = GetControlSearchTags(xmlReader);

                            if (null != xmlReader.GetAttribute("IsPreview"))
                            {
                                controlModel.UpdateType = GetUpdateType(GetDataFromXmlReader(xmlReader, "IsPreview"), "IsPreview");
                            }

                            if (null != xmlReader.GetAttribute("IsNew"))
                            {
                                controlModel.UpdateType = GetUpdateType(GetDataFromXmlReader(xmlReader, "IsNew"), "IsNew");
                            }

                            currentControlTitle = controlModel.Title;
                            if (controlModel != null)
                            {
                                if (Device.RuntimePlatform == Device.UWP && controlModel.Title == "TabView")
                                    continue;

                                controlsList.Add(controlModel);
                            }
                        }
                    }

                    xmlReader.Read();
                }
            }
        }

        private string GetUpdateType(string value, string type)
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

			return string.Empty;
		}

        private string[] GetControlSearchTags(XmlReader xmlReader)
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

        #endregion
    }

	public enum SortOption
	{
		None,
		Ascending,
		Descending
	}
}