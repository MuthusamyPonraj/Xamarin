#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfListView
{
    [Preserve(AllMembers = true)]
    public class PagingViewModel : INotifyPropertyChanged
    {    
        private PagingProductRepository pagingProductRepository;
    
        public ObservableCollection<PagingProduct> pagingProducts { get; set; }

        public PagingViewModel()
        {
            pagingProductRepository = new PagingProductRepository();
            pagingProducts = new ObservableCollection<PagingProduct>();
            GenerateSource();
        }
       

        private void GenerateSource()
        {
            var index = 0;

            for (int i = 0; i < pagingProductRepository.Names.Count(); i++)
            {
                if (index == 21)
                    index = 0;

                var name = pagingProductRepository.Names1[index];
                var p = new PagingProduct()
                {
                    Name = pagingProductRepository.Names[i],
                    Weight = pagingProductRepository.Weights[i],
                    Price = pagingProductRepository.Prices[i],
                    ReviewValue = pagingProductRepository.ReviewValue[i],
                    Ratings = pagingProductRepository.Ratings[i],
                    Offer = pagingProductRepository.Offer[i],
                    Image1 = ImageSource.FromResource("SampleBrowser.SfListView.Icons.Rating.png"),
                    Image = ImageSource.FromResource("SampleBrowser.SfListView.Icons.LoadMore." + name.Replace(" ", string.Empty) + ".jpg")
                };

                index++;
                pagingProducts.Add(p);
            }
        }

        private void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
