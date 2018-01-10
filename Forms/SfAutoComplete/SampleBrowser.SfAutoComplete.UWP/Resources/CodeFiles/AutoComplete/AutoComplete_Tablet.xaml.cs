#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfAutoComplete.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SampleBrowser.SfAutoComplete
{
    public partial class AutoComplete_Tablet : SampleView
    {
        List<String> jobList { get; set; }
        List<String> countryList { get; set; }
        List<String> experienceList { get; set; }
        String valueCountry, valueJobField;
        Button closeButton;
        int minpref = 1, maxDrop = 150, pop = 100, suggestion = 0, autocompletemode = 0;
        StackLayout view;
        Entry minPrefixCharacterText = null, maximumDropDownHeightText = null, PopupDelayText = null;
        Picker suggestionModepicker = null, autoCompleteModepicker = null;
        Label minimumPrefixCharacterLabel, maximumDropDownHeightLabel, popupDelayLabel;

        public AutoComplete_Tablet()
        {
            InitializeComponent();
            addCountryList();
            countryAutoComplete.BindingContext = countryList;
            DeviceChanges();
            getPropertiesWindow();
            PropertyLayout();
        }
        public void closeAction()
        {
            view.BackgroundColor = Color.White;
            Property_Windows.Children.Add(temp);
            Property_Windows.Children.Remove(view);
        }

        void tab_Tapped(object sender, EventArgs e)
        {
            closeAction();
        }
        public void addCountryList()
        {
            countryList = new List<string>();
            countryList.Add("Afghanistan");
            countryList.Add("Akrotiri");
            countryList.Add("Albania");
            countryList.Add("Algeria");
            countryList.Add("American Samoa");
            countryList.Add("Andorra");
            countryList.Add("Angola");
            countryList.Add("Anguilla");
            countryList.Add("Antarctica");
            countryList.Add("Antigua and Barbuda");
            countryList.Add("Argentina");
            countryList.Add("Armenia");
            countryList.Add("Aruba");
            countryList.Add("Ashmore and Cartier Islands");
            countryList.Add("Australia");
            countryList.Add("Austria");
            countryList.Add("Azerbaijan");
            countryList.Add("Bahamas, The");
            countryList.Add("Bahrain");
            countryList.Add("Bangladesh");
            countryList.Add("Barbados");
            countryList.Add("Bassas da India");
            countryList.Add("Belarus");
            countryList.Add("Belgium");
            countryList.Add("Belize");
            countryList.Add("Benin");
            countryList.Add("Bermuda");
            countryList.Add("Bhutan");
            countryList.Add("Bolivia");
            countryList.Add("Bosnia and Herzegovina");
            countryList.Add("Botswana");
            countryList.Add("Bouvet Island");
            countryList.Add("Brazil");
            countryList.Add("British Indian Ocean Territory");
            countryList.Add("British Virgin Islands");
            countryList.Add("Brunei");
            countryList.Add("Bulgaria");
            countryList.Add("Burkina Faso");
            countryList.Add("Burma");
            countryList.Add("Burundi");
            countryList.Add("Cambodia");
            countryList.Add("Cameroon");
            countryList.Add("Canada");
            countryList.Add("Cape Verde");
            countryList.Add("Cayman Islands");
            countryList.Add("Central African Republic");
            countryList.Add("Chad");
            countryList.Add("Chile");
            countryList.Add("China");
            countryList.Add("Christmas Island");
            countryList.Add("Clipperton Island");
            countryList.Add("Cocos (Keeling) Islands");
            countryList.Add("Colombia");
            countryList.Add("Comoros");
            countryList.Add("Congo");
            countryList.Add("Congo, Republic of the");
            countryList.Add("Cook Islands");
            countryList.Add("Coral Sea Islands");
            countryList.Add("Costa Rica");
            countryList.Add("Cote d'Ivoire");
            countryList.Add("Croatia");
            countryList.Add("Cuba");
            countryList.Add("Cyprus");
            countryList.Add("Czech Republic");
            countryList.Add("Denmark");
            countryList.Add("Dhekelia");
            countryList.Add("Djibouti");
            countryList.Add("Dominica");
            countryList.Add("Dominican Republic");
            countryList.Add("Ecuador");
            countryList.Add("Egypt");
            countryList.Add("El Salvador");
            countryList.Add("Equatorial Guinea");
            countryList.Add("Eritrea");
            countryList.Add("Estonia");
            countryList.Add("Ethiopia");
            countryList.Add("Europa Island");
            countryList.Add("Falkland Islands");
            countryList.Add("Faroe Islands");
            countryList.Add("Fiji");
            countryList.Add("Finland");
            countryList.Add("France");
            countryList.Add("French Guiana");
            countryList.Add("French Polynesia");
            countryList.Add("French Southern and Antarctic Lands");
            countryList.Add("Gabon");
            countryList.Add("Gambia, The");
            countryList.Add("Gaza Strip");
            countryList.Add("Georgia");
            countryList.Add("Germany");
            countryList.Add("Ghana");
            countryList.Add("Gibraltar");
            countryList.Add("Glorioso Islands");
            countryList.Add("Greece");
            countryList.Add("Greenland");
            countryList.Add("Grenada");
            countryList.Add("Guadeloupe");
            countryList.Add("Guam");
            countryList.Add("Guatemala");
            countryList.Add("Guernsey");
            countryList.Add("Guinea");
            countryList.Add("Guinea-Bissau");
            countryList.Add("Guyana");
            countryList.Add("Haiti");
            countryList.Add("Heard Island and McDonald Islands");
            countryList.Add("Holy See");
            countryList.Add("Honduras");
            countryList.Add("Hong Kong");
            countryList.Add("Hungary");
            countryList.Add("Iceland");
            countryList.Add("India");
            countryList.Add("Indonesia");
            countryList.Add("Iran");
            countryList.Add("Iraq");
            countryList.Add("Ireland");
            countryList.Add("Isle of Man");
            countryList.Add("Israel");
            countryList.Add("Italy");
            countryList.Add("Jamaica");
            countryList.Add("Jan Mayen");
            countryList.Add("Japan");
            countryList.Add("Jersey");
            countryList.Add("Jordan");
            countryList.Add("Juan de Nova Island");
            countryList.Add("Kazakhstan");
            countryList.Add("Kenya");
            countryList.Add("Kiribati");
            countryList.Add("Korea, North");
            countryList.Add("Korea, South");
            countryList.Add("Kuwait");
            countryList.Add("Kyrgyzstan");
            countryList.Add("Laos");
            countryList.Add("Latvia");
            countryList.Add("Lebanon");
            countryList.Add("Lesotho");
            countryList.Add("Liberia");
            countryList.Add("Libya");
            countryList.Add("Liechtenstein");
            countryList.Add("Lithuania");
            countryList.Add("Luxembourg");
            countryList.Add("Macau");
            countryList.Add("Macedonia");
            countryList.Add("Madagascar");
            countryList.Add("Malawi");
            countryList.Add("Malaysia");
            countryList.Add("Maldives");
            countryList.Add("Mali");
            countryList.Add("Malta");
            countryList.Add("Marshall Islands");
            countryList.Add("Martinique");
            countryList.Add("Mauritania");
            countryList.Add("Mauritius");
            countryList.Add("Mayotte");
            countryList.Add("Mexico");
            countryList.Add("Micronesia");
            countryList.Add("Moldova");
            countryList.Add("Monaco");
            countryList.Add("Mongolia");
            countryList.Add("Montserrat");
            countryList.Add("Morocco");
            countryList.Add("Mozambique");
            countryList.Add("Namibia");
            countryList.Add("Nauru");
            countryList.Add("Navassa Island");
            countryList.Add("Nepal");
            countryList.Add("Netherlands");
            countryList.Add("Netherlands Antilles");
            countryList.Add("New Caledonia");
            countryList.Add("New Zealand");
            countryList.Add("Nicaragua");
            countryList.Add("Niger");
            countryList.Add("Nigeria");
            countryList.Add("Niue");
            countryList.Add("Norfolk Island");
            countryList.Add("Northern Mariana Islands");
            countryList.Add("Norway");
            countryList.Add("Oman");
            countryList.Add("Pakistan");
            countryList.Add("Palau");
            countryList.Add("Panama");
            countryList.Add("Papua New Guinea");
            countryList.Add("Paracel Islands");
            countryList.Add("Paraguay");
            countryList.Add("Peru");
            countryList.Add("Philippines");
            countryList.Add("Pitcairn Islands");
            countryList.Add("Poland");
            countryList.Add("Portugal");
            countryList.Add("Puerto Rico");
            countryList.Add("Qatar");
            countryList.Add("Reunion");
            countryList.Add("Romania");
            countryList.Add("Russia");
            countryList.Add("Rwanda");
            countryList.Add("Saint Helena");
            countryList.Add("Saint Kitts and Nevis");
            countryList.Add("Saint Lucia");
            countryList.Add("Saint Pierre and Miquelon");
            countryList.Add("Saint Vincent");
            countryList.Add("Samoa");
            countryList.Add("San Marino");
            countryList.Add("Sao Tome and Principe");
            countryList.Add("Saudi Arabia");
            countryList.Add("Senegal");
            countryList.Add("Serbia and Montenegro");
            countryList.Add("Seychelles");
            countryList.Add("Sierra Leone");
            countryList.Add("Singapore");
            countryList.Add("Slovakia");
            countryList.Add("Slovenia");
            countryList.Add("Solomon Islands");
            countryList.Add("Somalia");
            countryList.Add("South Africa");
            countryList.Add("South Georgia");
            countryList.Add("Spain");
            countryList.Add("Spratly Islands");
            countryList.Add("Sri Lanka");
            countryList.Add("Sudan");
            countryList.Add("Suriname");
            countryList.Add("Svalbard");
            countryList.Add("Swaziland");
            countryList.Add("Sweden");
            countryList.Add("Switzerland");
            countryList.Add("Syria");
            countryList.Add("Taiwan");
            countryList.Add("Tajikistan");
            countryList.Add("Tanzania");
            countryList.Add("Thailand");
            countryList.Add("Timor-Leste");
            countryList.Add("Togo");
            countryList.Add("Tokelau");
            countryList.Add("Tonga");
            countryList.Add("Trinidad and Tobago");
            countryList.Add("Tromelin Island");
            countryList.Add("Tunisia");
            countryList.Add("Turkey");
            countryList.Add("Turkmenistan");
            countryList.Add("Turks and Caicos Islands");
            countryList.Add("Tuvalu");
            countryList.Add("Uganda");
            countryList.Add("Ukraine");
            countryList.Add("United Arab Emirates");
            countryList.Add("United Kingdom");
            countryList.Add("United States");
            countryList.Add("Uruguay");
            countryList.Add("Uzbekistan");
            countryList.Add("Vanuatu");
            countryList.Add("Venezuela");
            countryList.Add("Vietnam");
            countryList.Add("Virgin Islands");
            countryList.Add("Wake Island");
            countryList.Add("Wallis and Futuna");
            countryList.Add("West Bank");
            countryList.Add("Western Sahara");
            countryList.Add("Yemen");
            countryList.Add("Zambia");
            countryList.Add("Zimbabwe");
        }

        void DeviceChanges()
        {
            searchButton.BackgroundColor = Color.FromRgb(51, 153, 255);
            if (Device.OS == TargetPlatform.iOS)
            {
                searchButton.TextColor = Color.White;
                sampleLayout1.Padding = new Thickness(50, 30, 50, 0);
                layout1.Padding = new Thickness(50, 50, 50, 0);
                jobSearchLabel.FontSize = 18;
                countryLayout.Padding = new Thickness(50, 10, 50, 10);
                jobLayout.Padding = new Thickness(50, 10, 50, 10);
                searchlayout.Padding = new Thickness(50, 10, 50, 10);
                buttonLayout.Padding = new Thickness(50, 10, 50, 10);
            }
        }
        public void getPropertiesWindow()
        {
            if (Device.OS == TargetPlatform.iOS)
            {
                Property_Windows.HeightRequest = 400;
            }
            view = new StackLayout();
            suggestionModepicker = new Picker();
            autoCompleteModepicker = new Picker();
            minPrefixCharacterText = new Entry();
            maximumDropDownHeightText = new Entry();

            view.HeightRequest = Property_Windows.HeightRequest;
            view.BackgroundColor = Color.FromRgb(250, 250, 250);

            StackLayout propertyLayout = new StackLayout();
            propertyLayout.Padding = new Thickness(10, 0, 0, 0);
            propertyLayout.Orientation = StackOrientation.Horizontal;
            propertyLayout.BackgroundColor = Color.FromRgb(230, 230, 230);
            TapGestureRecognizer tab = new TapGestureRecognizer();
            tab.Tapped += tab_Tapped;
            propertyLayout.GestureRecognizers.Add(tab);
            Label propertyLabel = new Label();
            propertyLabel.Text = "OPTIONS";
            propertyLabel.WidthRequest = 150;
            propertyLabel.VerticalOptions = LayoutOptions.Center;
            propertyLabel.HorizontalOptions = LayoutOptions.Start;
            propertyLabel.FontFamily = "Helvetica";
            propertyLabel.FontSize = 18;
            closeButton = new Button();

            if (Device.OS == TargetPlatform.iOS)
            {
                closeButton.Text = "X";
                closeButton.TextColor = Color.FromRgb(51, 153, 255);
            }
            else
                closeButton.Image = "sfclosebutton.png";
            closeButton.Clicked += Close_Button;
            temp.BackgroundColor = Color.FromRgb(230, 230, 230);
            closeButton.BackgroundColor = Color.FromRgb(230, 230, 230);
            Property_Button.BackgroundColor = Color.FromRgb(230, 230, 230);

            closeButton.HorizontalOptions = LayoutOptions.EndAndExpand;
            propertyLayout.Children.Add(propertyLabel);
            propertyLayout.Children.Add(closeButton);

            StackLayout emptyLayout = new StackLayout();
            emptyLayout.BackgroundColor = Color.FromRgb(250, 250, 250);
            if (Device.OS == TargetPlatform.iOS)
                emptyLayout.Padding = new Thickness(30, 10, 40, 0);
            else
                emptyLayout.Padding = new Thickness(30, 10, 40, 10);

            StackLayout suggestionLayout = new StackLayout();
            suggestionLayout.Orientation = StackOrientation.Horizontal;
            if (Device.OS == TargetPlatform.iOS)
                suggestionLayout.Padding = new Thickness(0, 10, 0, 20);
            else
                suggestionLayout.Padding = new Thickness(0, 0, 0, 0);
            Label suggestionLabel = new Label();
            suggestionLabel.Text = "Suggestion Mode";
            suggestionLabel.WidthRequest = 250;
            suggestionLabel.VerticalOptions = LayoutOptions.Center;
            suggestionLabel.HorizontalOptions = LayoutOptions.EndAndExpand;
            suggestionLabel.FontFamily = "Helvetica";
            suggestionLabel.FontSize = 16;
            suggestionModepicker.IsEnabled = true;
            suggestionModepicker.WidthRequest = 250;
            suggestionModepicker.HorizontalOptions = LayoutOptions.StartAndExpand;
            suggestionModepicker.VerticalOptions = LayoutOptions.Center;
            suggestionLayout.Children.Add(suggestionLabel);
            suggestionLayout.Children.Add(suggestionModepicker);

            StackLayout modeLayout = new StackLayout();
            modeLayout.Orientation = StackOrientation.Horizontal;
            if (Device.OS == TargetPlatform.iOS)
                modeLayout.Padding = new Thickness(0, 20, 0, 20);
            else
                modeLayout.Padding = new Thickness(0, 20, 0, 0);

            Label modeLabel = new Label();
            modeLabel.Text = "AutoComplete Mode";
            modeLabel.WidthRequest = 250;
            modeLabel.VerticalOptions = LayoutOptions.Center;
            modeLabel.HorizontalOptions = LayoutOptions.EndAndExpand;
            modeLabel.FontFamily = "Helvetica";
            modeLabel.FontSize = 16;
            autoCompleteModepicker.WidthRequest = 250;
            autoCompleteModepicker.IsEnabled = true;
            autoCompleteModepicker.HorizontalOptions = LayoutOptions.StartAndExpand;
            autoCompleteModepicker.VerticalOptions = LayoutOptions.Center;
            modeLayout.Children.Add(modeLabel);
            modeLayout.Children.Add(autoCompleteModepicker);

            //SuggestionModePicker Items

            suggestionModepicker.Items.Add("StartsWith");
            suggestionModepicker.Items.Add("StartsWithCaseSensitive");
            suggestionModepicker.Items.Add("Contains");
            suggestionModepicker.Items.Add("ContainsWithCaseSensitive");
            suggestionModepicker.Items.Add("EndsWith");
            suggestionModepicker.Items.Add("EndsWithCaseSensitive");
            suggestionModepicker.Items.Add("Equals");
            suggestionModepicker.Items.Add("EqualsWithCaseSensitive");
            suggestionModepicker.SelectedIndexChanged += SelectionIndex_Changed;

            //AutoCompleteModePicker Items

            autoCompleteModepicker.Items.Add("Suggest");
            autoCompleteModepicker.Items.Add("Append");
            autoCompleteModepicker.Items.Add("SuggestAppend");
            autoCompleteModepicker.SelectedIndexChanged += autoCompleteModepicker_Changed;

            autoCompleteModepicker.SelectedIndex = autocompletemode;
            suggestionModepicker.SelectedIndex = suggestion;

            StackLayout prefixLabelLayout = new StackLayout();
            prefixLabelLayout.Orientation = StackOrientation.Horizontal;
            if (Device.OS == TargetPlatform.iOS)
                prefixLabelLayout.Padding = new Thickness(5, 20, 0, 20);
            else
                prefixLabelLayout.Padding = new Thickness(0, 20, 0, 0);
            minimumPrefixCharacterLabel = new Label();
            minimumPrefixCharacterLabel.Text = "Minimum Prefix Character";
            if (Device.OS == TargetPlatform.iOS)
                minimumPrefixCharacterLabel.WidthRequest = 250;
            else
                minimumPrefixCharacterLabel.WidthRequest = 250;
            minimumPrefixCharacterLabel.HorizontalOptions = LayoutOptions.EndAndExpand;
            minimumPrefixCharacterLabel.VerticalOptions = LayoutOptions.Center;
            minimumPrefixCharacterLabel.FontFamily = "Helvetica";
            minimumPrefixCharacterLabel.FontSize = 16;
            if (Device.OS == TargetPlatform.iOS)
                minPrefixCharacterText.WidthRequest = 250;
            else
                minPrefixCharacterText.WidthRequest = 250;

            minPrefixCharacterText.Keyboard = Keyboard.Numeric;
            minPrefixCharacterText.VerticalOptions = LayoutOptions.Center;
            minPrefixCharacterText.HorizontalOptions = LayoutOptions.StartAndExpand;
            minPrefixCharacterText.FontFamily = "Helvetica";
            minPrefixCharacterText.FontSize = 16;
            //	minPrefixCharacterText.HorizontalTextAlignment = TextAlignment.Center;
            minPrefixCharacterText.Text = minpref.ToString();
            minPrefixCharacterText.TextChanged += PrefixCharacter_Changed;
            prefixLabelLayout.Children.Add(minimumPrefixCharacterLabel);
            prefixLabelLayout.Children.Add(minPrefixCharacterText);

            StackLayout dropDownLabelLayout = new StackLayout();
            dropDownLabelLayout.Orientation = StackOrientation.Horizontal;
            if (Device.OS == TargetPlatform.iOS)
                dropDownLabelLayout.Padding = new Thickness(5, 20, 0, 20);
            else
                dropDownLabelLayout.Padding = new Thickness(0, 20, 0, 0);
            maximumDropDownHeightLabel = new Label();
            maximumDropDownHeightLabel.Text = "Maximum DropDown Height";
            if (Device.OS == TargetPlatform.iOS)
                maximumDropDownHeightLabel.WidthRequest = 250;
            else
                maximumDropDownHeightLabel.WidthRequest = 250;
            maximumDropDownHeightLabel.VerticalOptions = LayoutOptions.Center;
            maximumDropDownHeightLabel.HorizontalOptions = LayoutOptions.EndAndExpand;
            maximumDropDownHeightLabel.FontFamily = "Helvetica";
            maximumDropDownHeightLabel.FontSize = 16;
            maximumDropDownHeightText = new Entry();
            if (Device.OS == TargetPlatform.iOS)
                maximumDropDownHeightText.WidthRequest = 250;
            else
                maximumDropDownHeightText.WidthRequest = 250;
            maximumDropDownHeightText.VerticalOptions = LayoutOptions.Center;
            maximumDropDownHeightText.HorizontalOptions = LayoutOptions.StartAndExpand;
            maximumDropDownHeightText.FontFamily = "Helvetica";
            //	maximumDropDownHeightText.HorizontalTextAlignment = TextAlignment.Center;
            maximumDropDownHeightText.FontSize = 16;
            maximumDropDownHeightText.Keyboard = Keyboard.Numeric;
            maximumDropDownHeightText.Text = maxDrop.ToString();
            maximumDropDownHeightText.TextChanged += MaximumHeight_Changed;
            dropDownLabelLayout.Children.Add(maximumDropDownHeightLabel);
            dropDownLabelLayout.Children.Add(maximumDropDownHeightText);

            StackLayout PopUpLayout = new StackLayout();
            PopUpLayout.Orientation = StackOrientation.Horizontal;
            if (Device.OS == TargetPlatform.iOS)
                PopUpLayout.Padding = new Thickness(5, 20, 0, 20);
            else
                PopUpLayout.Padding = new Thickness(0, 20, 0, 0);

            popupDelayLabel = new Label();
            popupDelayLabel.Text = "PopUp Delay";
            if (Device.OS == TargetPlatform.iOS)
                popupDelayLabel.WidthRequest = 250;
            else
                popupDelayLabel.WidthRequest = 250;
            popupDelayLabel.VerticalOptions = LayoutOptions.Center;
            popupDelayLabel.HorizontalOptions = LayoutOptions.EndAndExpand;
            popupDelayLabel.FontFamily = "Helvetica";
            popupDelayLabel.FontSize = 16;
            PopupDelayText = new Entry();
            if (Device.OS == TargetPlatform.iOS)
                PopupDelayText.WidthRequest = 250;
            else
                PopupDelayText.WidthRequest = 250;
            PopupDelayText.VerticalOptions = LayoutOptions.Center;
            PopupDelayText.HorizontalOptions = LayoutOptions.StartAndExpand;
            //PopupDelayText.HorizontalTextAlignment = TextAlignment.Center;
            PopupDelayText.FontFamily = "Helvetica";
            PopupDelayText.Keyboard = Keyboard.Numeric;
            PopupDelayText.FontSize = 16;
            PopupDelayText.Text = pop.ToString();
            PopupDelayText.TextChanged += PopUp_Changed;
            PopUpLayout.Children.Add(popupDelayLabel);
            PopUpLayout.Children.Add(PopupDelayText);

            emptyLayout.Children.Add(suggestionLayout);
            emptyLayout.Children.Add(modeLayout);
            emptyLayout.Children.Add(prefixLabelLayout);
            emptyLayout.Children.Add(dropDownLabelLayout);
            emptyLayout.Children.Add(PopUpLayout);

            view.Children.Add(propertyLayout);
            view.Children.Add(emptyLayout);
            Property_Windows.Children.Remove(temp);
            Property_Windows.Children.Insert(0, view);
        }

        void tap_Gestue_Prob_Tapped(object sender, EventArgs e)
        {
            getPropertiesWindow();
        }


        void PropertyLayout()
        {
            TapGestureRecognizer tap_Gestue_Prob = new TapGestureRecognizer();
            tap_Gestue_Prob.Tapped += tap_Gestue_Prob_Tapped;
            temp.GestureRecognizers.Add(tap_Gestue_Prob);

            Property_Button.Clicked += Property_Button_Click;
            searchButton.Clicked += search_Clicked;

            jobList = new List<string>();
            jobList.Add("Banking");
            jobList.Add("Media");
            jobList.Add("Medical");
            jobList.Add("software");

            jobFieldAutoComplete.BindingContext = jobList;
            countryAutoComplete.ValueChanged += (object sender, Syncfusion.SfAutoComplete.XForms.ValueChangedEventArgs e) =>
            {
                valueCountry = e.Value;
            };
            jobFieldAutoComplete.ValueChanged += (object sender, Syncfusion.SfAutoComplete.XForms.ValueChangedEventArgs e) =>
            {
                valueJobField = e.Value;
            };

            experiencePicker.Items.Add("1");
            experiencePicker.Items.Add("2");
            experiencePicker.Items.Add("3");

            experiencePicker.SelectedIndex = 0;
            valueCountry = string.Empty;
            valueJobField = string.Empty;


            if (Device.OS == TargetPlatform.iOS)
            {
                countryAutoComplete.HeightRequest = 30;
                jobFieldAutoComplete.HeightRequest = 30;
                countryAutoComplete.DropDownTextSize = 16;
                jobFieldAutoComplete.DropDownTextSize = 16;
            }
            else if (Device.OS == TargetPlatform.WinPhone)
            {
                sampleLayout.Padding = new Thickness(10, 0, 0, 0);
                countryAutoComplete.HeightRequest = 80;
                jobFieldAutoComplete.HeightRequest = 80;
                if (minPrefixCharacterText != null && PopupDelayText != null && maximumDropDownHeightText != null)
                {
                    minPrefixCharacterText.WidthRequest = 120;
                    PopupDelayText.WidthRequest = 120;
                    maximumDropDownHeightText.WidthRequest = 120;
                    minPrefixCharacterText.HeightRequest = 80;
                    PopupDelayText.HeightRequest = 80;
                }
            }
            if (Device.OS == TargetPlatform.Windows)
            {

                if (minPrefixCharacterText != null && PopupDelayText != null)
                {
                    minPrefixCharacterText.WidthRequest = 120;
                    PopupDelayText.WidthRequest = 120;
                }

            }

            //if (App.Platform == Platforms.UWP && (Device.Idiom != TargetIdiom.Phone))
            {
                if (minimumPrefixCharacterLabel != null && maximumDropDownHeightLabel != null)
                {
                    minimumPrefixCharacterLabel.HeightRequest = 40;
                    maximumDropDownHeightLabel.HeightRequest = 40;
                }

            }
        }
        public void Property_Button_Click(object sender, EventArgs e)
        {
            getPropertiesWindow();

        }
        public View getContent()
        {
            return this.Content;
        }
        public void Close_Button(object c, EventArgs e)
        {
            closeAction();
        }
        public void SelectionIndex_Changed(object c, EventArgs e)
        {
            if (suggestionModepicker != null)
            {
                switch (suggestionModepicker.SelectedIndex)
                {
                    case 0:
                        {
                            countryAutoComplete.SuggestionMode = SuggestionMode.StartsWith;
                            jobFieldAutoComplete.SuggestionMode = SuggestionMode.StartsWith;
                            suggestion = 0;
                        }
                        break;
                    case 1:
                        {
                            countryAutoComplete.SuggestionMode = SuggestionMode.StartsWithCaseSensitive;
                            jobFieldAutoComplete.SuggestionMode = SuggestionMode.StartsWithCaseSensitive;
                            suggestion = 1;
                        }
                        break;
                    case 2:
                        {
                            countryAutoComplete.SuggestionMode = SuggestionMode.Contains;
                            jobFieldAutoComplete.SuggestionMode = SuggestionMode.Contains;
                            suggestion = 2;
                        }
                        break;
                    case 3:
                        {
                            countryAutoComplete.SuggestionMode = SuggestionMode.ContainsWithCaseSensitive;
                            jobFieldAutoComplete.SuggestionMode = SuggestionMode.ContainsWithCaseSensitive;
                            suggestion = 3;
                        }
                        break;
                    case 4:
                        {
                            countryAutoComplete.SuggestionMode = SuggestionMode.EndsWith;
                            jobFieldAutoComplete.SuggestionMode = SuggestionMode.EndsWith;
                            suggestion = 4;
                        }
                        break;
                    case 5:
                        {
                            countryAutoComplete.SuggestionMode = SuggestionMode.EndsWithCaseSensitive;
                            jobFieldAutoComplete.SuggestionMode = SuggestionMode.EndsWithCaseSensitive;
                            suggestion = 5;
                        }

                        break;
                    case 6:
                        {
                            countryAutoComplete.SuggestionMode = SuggestionMode.Equals;
                            jobFieldAutoComplete.SuggestionMode = SuggestionMode.Equals;
                            suggestion = 6;
                        }
                        break;
                    case 7:
                        {
                            countryAutoComplete.SuggestionMode = SuggestionMode.EqualsWithCaseSensitive;
                            jobFieldAutoComplete.SuggestionMode = SuggestionMode.EqualsWithCaseSensitive;
                            suggestion = 7;
                        }
                        break;
                }
            }
        }
        public void autoCompleteModepicker_Changed(object c, EventArgs e)
        {
            if (autoCompleteModepicker != null)
            {
                switch (autoCompleteModepicker.SelectedIndex)
                {
                    case 0:
                        {
                            countryAutoComplete.AutoCompleteMode = AutoCompleteMode.Suggest;
                            jobFieldAutoComplete.AutoCompleteMode = AutoCompleteMode.Suggest;
                            autocompletemode = 0;
                        }
                        break;
                    case 1:
                        {
                            countryAutoComplete.AutoCompleteMode = AutoCompleteMode.Append;
                            jobFieldAutoComplete.AutoCompleteMode = AutoCompleteMode.Append;
                            autocompletemode = 1;
                        }
                        break;
                    case 2:
                        {
                            countryAutoComplete.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                            jobFieldAutoComplete.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                            autocompletemode = 2;

                        }
                        break;
                }
            }

        }

        //autocomplete mode selected index change
        public void PrefixCharacter_Changed(object c, TextChangedEventArgs e)
        {
            if (minPrefixCharacterText != null)
            {
                if (e.NewTextValue.Length > 0)
                {
                    int minimumPrefixCharacters;
                    if (int.TryParse(e.NewTextValue, out minimumPrefixCharacters))
                    {
                        countryAutoComplete.MinimumPrefixCharacters = minimumPrefixCharacters;
                        jobFieldAutoComplete.MinimumPrefixCharacters = minimumPrefixCharacters;
                        minpref = minimumPrefixCharacters;
                    }
                }
            }
        }
        public void MaximumHeight_Changed(object c, TextChangedEventArgs e)
        {
            if (maximumDropDownHeightText != null)
            {
                if (e.NewTextValue.Length > 0)
                {
                    int maximumDropDownHeight;
                    if (int.TryParse(e.NewTextValue, out maximumDropDownHeight))
                    {
                        countryAutoComplete.MaximumDropDownHeight = maximumDropDownHeight;
                        jobFieldAutoComplete.MaximumDropDownHeight = maximumDropDownHeight;
                        maxDrop = maximumDropDownHeight;
                    }
                }
            }

        }
        public void PopUp_Changed(object c, TextChangedEventArgs e)
        {

            if (PopupDelayText != null)
            {
                if (e.NewTextValue.Length > 0)
                {
                    int popupDelay;
                    if (int.TryParse(e.NewTextValue, out popupDelay))
                    {
                        countryAutoComplete.PopupDelay = popupDelay;
                        jobFieldAutoComplete.PopupDelay = popupDelay;
                        pop = popupDelay;
                    }
                }
            }
        }
        public void search_Clicked(object c, EventArgs e)
        {
            if (valueCountry != "" && valueJobField != "")
            {
                Random r = new Random();
                Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Results", r.Next(9, 50) + " Jobs found", "OK");
            }
            else
            {
				Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Results", "0 Jobs found", "OK");
            }
        }
    }
}


