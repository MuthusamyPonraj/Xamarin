#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Android.Content.Res;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

[assembly: Dependency(typeof(SampleBrowser.Core.Droid.SampleBrowserDroid))]
namespace SampleBrowser.Core.Droid
{
    public class SampleBrowserDroid : ISampleBrowserService
    {
        Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

		public SampleBrowserDroid()
        {
        }

        public Type GetAssembliesType(string assemblyName, string sampleName)
        {
            Type type = null;
            if (assemblies.Length > 0)
            {
                foreach (Assembly sampleAssembly in assemblies)
                {
                    if (sampleAssembly.GetName().Name == assemblyName)
                    {
                        type = sampleAssembly.GetType(assemblyName + "." + sampleName);
                    }
                }
            }
            if (type == null)
            {
                Assembly assm = Assembly.Load(assemblyName + ", Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
                type = assm.GetType(assemblyName + "." + sampleName);
            }
            return type;
        }

        public Stream GetSamplesList(string xmlFilePath, string assemblyName)
        {
            Stream stream = null;
            if (assemblies.Length > 0)
            {
                foreach (Assembly sampleAssembly in assemblies)
                {
                    if (sampleAssembly.GetName().Name == assemblyName)
                    {
                        stream = sampleAssembly.GetManifestResourceStream(xmlFilePath);
                    }
                }
            }
            if (stream == null)
            {
                Assembly assm = Assembly.Load(assemblyName + ", Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
                stream = assm.GetManifestResourceStream(xmlFilePath);
            }
            return stream;
        }

        public List<KeyValuePair<string, string>> GetCodeViewerContent(string controlName, string sampleName)
        {
            Assembly[] assem = AppDomain.CurrentDomain.GetAssemblies();

            List<KeyValuePair<string, string>> files = new List<KeyValuePair<string, string>>();
            var assembly = Assembly.Load("SampleBrowser." + controlName + ".Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
			var resourceNamesInAssembly = GetFilesInFolder(assembly, sampleName);

			if (resourceNamesInAssembly.Length > 0)
            {
                foreach (var item in resourceNamesInAssembly)
                {
                    Stream stream = assembly.GetManifestResourceStream(item);
                    string fileContent = "";
                    if (stream != null)
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            fileContent = reader.ReadToEnd();
                        }
                    }
                    var split = item.Split('.');
                    var count = split.Length;
                    var fileName = "";
                    if (split[count - 1] == "cs")
                    {
                        if (split[count - 2] == "xaml")
                            fileName = split[count - 3] + ".xaml.cs";
                        else
                            fileName = split[count - 2] + ".cs";
                    }
                    else
                        fileName = split[count - 2] + ".xaml";

                    files.Add(new KeyValuePair<string, string>(fileName, fileContent));
                }
            }
            else
            {
                files.Add(new KeyValuePair<string, string>(controlName, "Files in Resources/CodeFiles/" + controlName + " or " + sampleName + " folder is missing"));
            }
            return files;
        }


        private string[] GetFilesInFolder(Assembly executingAssembly, string sampleName)
        {
            var listOfFiles = new List<string>();
            string[] resources = executingAssembly.GetManifestResourceNames();
            foreach (string item in resources)
            {
                if (item.Contains("CodeFiles." + sampleName))
                {
                    if (item.Contains(".xaml") || item.Contains(".xaml.cs") || item.Contains(".cs"))
                        listOfFiles.Add(item);
                }
            }
            return listOfFiles.ToArray();
        }
    }
}