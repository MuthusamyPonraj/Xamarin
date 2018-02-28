#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace SampleBrowser
{
    public class MasterPageViewModel
    {
        #region fields

        //Navigation Drawer links
        private ObservableCollection<NavigationLinkModel> applinks;

        #endregion

        #region ctor

        public MasterPageViewModel()
        {
            GenerateNavigationLinks();
        }

        #endregion

        #region properties

        //Naviagtion Header content
        public NavigationDrawerModel AppDetails { get; set; }

        public ObservableCollection<NavigationLinkModel> AppLinks
        {
            get { return applinks; }
            set { applinks = value; }
        }

        private string Version
        {
            get
            {
                var assembly = typeof(App).GetTypeInfo().Assembly;
                var assemblyName = new AssemblyName(assembly.FullName);
                return assemblyName.Version.Major + "." + assemblyName.Version.Minor + "." + assemblyName.Version.Build + "." + assemblyName.Version.Revision;
            }
        }

        #endregion

        #region methods

        public static ContentPage GetSamplesList(string controlName)
        {
            return null;
        }

        internal void GenerateNavigationLinks()
        {
            AppDetails = new NavigationDrawerModel();
            AppDetails.AppVersion = "Version " + Version;
            AppDetails.AppDesc = string.Empty;

            applinks = new ObservableCollection<NavigationLinkModel>();
            applinks.Add(new NavigationLinkModel { LinkText = "Product Page", LinkIcons = "productpage.png", LinkURL = "https://www.syncfusion.com/products/xamarin" });
            applinks.Add(new NavigationLinkModel { LinkText = "Whats New", LinkIcons = "whatsnew.png", LinkURL = "https://www.syncfusion.com/products/whatsnew/xamarin-forms" });
            applinks.Add(new NavigationLinkModel { LinkText = "Documentation", LinkIcons = "documentation.png", LinkURL = "https://help.syncfusion.com/xamarin/introduction/overview" });
        }

        #endregion
    }
}