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

namespace SampleBrowser.Core
{
    /// <summary>
    /// Interface/DependencyService used in SampleBrowser.
    /// </summary>
    public interface ISampleBrowserService
    {
        /// <summary>
        /// Used to get Samples List of the controls.
        /// </summary>
        Stream GetSamplesList(string xmlFilePath, string assemblyName);

        /// <summary>
        /// Used to get Assemblies of the controls.
        /// </summary>
        Type GetAssembliesType(string assemblyName, string sampleName);

        /// <summary>
        /// Used to get CodeViewer content of the sample.
        /// </summary>
        List<KeyValuePair<string, string>> GetCodeViewerContent(string controlName, string sampleName);
    }
}