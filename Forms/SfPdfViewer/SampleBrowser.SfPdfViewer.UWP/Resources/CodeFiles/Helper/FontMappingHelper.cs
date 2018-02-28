#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleBrowser.SfPdfViewer
{
    public class FontMappingHelper
    {
        public static string ShowFile = Device.RuntimePlatform == Device.Android ? "\uE705" : Device.RuntimePlatform == Device.iOS ? "\uE71d" : "\uE720";

        public static string Back = Device.RuntimePlatform == Device.Android ? "\uE700" : Device.RuntimePlatform == Device.iOS ? "\uE71c" : "\uE70d";

        public static string Search = Device.RuntimePlatform == Device.Android ? "\uE708" : Device.RuntimePlatform == Device.iOS ? "\uE719" : "\uE71c";

        public static string Save = Device.RuntimePlatform == Device.Android ? "\uE70a" : Device.RuntimePlatform == Device.iOS ? "\uE718" : "\uE705";

        public static string Undo = Device.RuntimePlatform == Device.Android ? "\uE70c" : Device.RuntimePlatform == Device.iOS ? "\uE70a" : "\uE71f";

        public static string Underline = Device.RuntimePlatform == Device.Android ? "\uE70d" : Device.RuntimePlatform == Device.iOS ? "\uE70c" : "\uE721";

        public static string Redo = Device.RuntimePlatform == Device.Android ? "\uE70f" : Device.RuntimePlatform == Device.iOS ? "\uE716" : "\uE706";

        public static string StrikeThrough = Device.RuntimePlatform == Device.Android ? "\uE711" : Device.RuntimePlatform == Device.iOS ? "\uE71e" : "\uE709";

        public static string Highlight = Device.RuntimePlatform == Device.Android ? "\uE715" : Device.RuntimePlatform == Device.iOS ? "\uE710" : "\uE70c";

        public static string Select = Device.RuntimePlatform == Device.Android ? "\uE71c" : Device.RuntimePlatform == Device.iOS ? "\uE715" : "\uE70b";

        public static string Ink = Device.RuntimePlatform == Device.Android ? "\uE71d" : Device.RuntimePlatform == Device.iOS ? "\uE704" : "\uE704";

        public static string Delete = Device.RuntimePlatform == Device.Android ? "\uE71e" : Device.RuntimePlatform == Device.iOS ? "\uE714" : "\uE718";

        public static string Annotation = Device.RuntimePlatform == Device.Android ? "\uE720" : Device.RuntimePlatform == Device.iOS ? "\uE706" : "\uE708";

        public static string Previous = Device.RuntimePlatform == Device.Android ? "\uE70b" : Device.RuntimePlatform == Device.iOS ? "\uE708" : "\uE70f";

        public static string Next = Device.RuntimePlatform == Device.Android ? "\uE721" : Device.RuntimePlatform == Device.iOS ? "\uE70b" : "\uE700";

        public static string Close = Device.RuntimePlatform == Device.Android ? "\uE70e" : Device.RuntimePlatform == Device.iOS ? "\uE70f" : "\uE701";

        public static string SearchBack = Device.RuntimePlatform == Device.Android ? "\uE713" : Device.RuntimePlatform == Device.iOS ? "\uE71b" : "\uE702";

        public static string TextMarkup = Device.RuntimePlatform == Device.Android ? "\uE719" : Device.RuntimePlatform == Device.iOS ? "\uE70e" : "\uE719";

        public static string Thickness = Device.RuntimePlatform == Device.Android ? "\uE722" : Device.RuntimePlatform == Device.iOS ? "\uE722" : "\uE722";

        public static string Transparent = Device.RuntimePlatform == Device.Android ? "\uE71a" : Device.RuntimePlatform == Device.iOS ? "\uE71a" : "\uE707";

        public static string PageUp = "\uE723";

        public static string PageDown = "\uE722";

        public static string TextPath =

        Device.RuntimePlatform == Device.Android ?
            "PdfViewer_Text_font.ttf#" :

            Device.RuntimePlatform == Device.iOS ?

            "PdfViewer_Text_font" :

            "/Assets/Fonts/PdfViewer_Text_font.ttf#PdfViewer_Text_font";

        public static string FontFamily =
            Device.RuntimePlatform == Device.Android ?

            "Final_PDFViewer_Android_FontUpdate.ttf#" :

            Device.RuntimePlatform == Device.iOS ?

            "Final_PDFViewer_IOS_FontUpdate" :

            "/Assets/Fonts/Final_PDFViewer_UWP_FontUpdate.ttf#Final_PDFViewer_UWP_FontUpdate";

    }
}
