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
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

[assembly: Dependency(typeof(SampleBrowser.Core.UWP.SampleBrowserUWP))]
namespace SampleBrowser.Core.UWP
{
	public class SampleBrowserUWP : ISampleBrowserService
	{
        List<Assembly> assemblies = new List<Assembly>();

        private async Task<IEnumerable<Assembly>> GetAssemblyListAsync()
        {
            var folder = Windows.ApplicationModel.Package.Current.InstalledLocation;

            foreach (Windows.Storage.StorageFile file in await folder.GetFilesAsync())
            {
                if (file.FileType == ".dll" || file.FileType == ".exe")
                {
                    AssemblyName name = new AssemblyName()
                    {
                        Name = Path.GetFileNameWithoutExtension(file.Name)
                    };
                    Assembly asm = Assembly.Load(name);
                    assemblies.Add(asm);
                }
            }

            return assemblies;
        }

        public SampleBrowserUWP()
		{
		}

		public Type GetAssembliesType(string assemblyName, string sampleName)
		{
			Type type = null;
			if (assemblies.Count> 0)
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
                AssemblyName name = new AssemblyName(assemblyName);
                Assembly assm = Assembly.Load(name);
				type = assm.GetType(assemblyName + "." + sampleName);
			}
			return type;
		}

		public Stream GetSamplesList(string xmlFilePath, string assemblyName)
		{
			Stream stream = null;
            GetAssemblyListAsync();
			if (assemblies.Count > 0)
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
                AssemblyName name = new AssemblyName(assemblyName);
                Assembly assm = Assembly.Load(name);
                stream = assm.GetManifestResourceStream(xmlFilePath);
			}
			return stream;
		}


		public List<KeyValuePair<string, string>> GetCodeViewerContent(string controlName, string sampleName)
		{
			GetAssemblyListAsync();

			List<KeyValuePair<string, string>> files = new List<KeyValuePair<string, string>>();
            AssemblyName name = new AssemblyName("SampleBrowser." + controlName + ".UWP");
            Assembly assembly = Assembly.Load(name);
			var resourceNamesInAssembly = GetFilesInFolder(assembly, "SampleBrowser." + controlName + ".UWP.Resources.CodeFiles." + sampleName);
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


		private string[] GetFilesInFolder(Assembly executingAssembly, string sampleFolderPath)
		{
			string folderName = string.Format(sampleFolderPath);
			var listOfFiles = new List<string>();
			string[] resources = executingAssembly.GetManifestResourceNames();
            foreach (string item in resources)
            {
                if (item.Contains(folderName))
                {
                    if (item.Contains(".xaml") || item.Contains(".xaml.cs") || item.Contains(".cs"))
                        listOfFiles.Add(item);
                }
            }
			return listOfFiles.ToArray();
		}
	}
}