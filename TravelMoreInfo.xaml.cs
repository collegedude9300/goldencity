using System;
using System.Collections.Generic;
using GoldenCities.ClassModels;
using Xamarin.Forms;

namespace GoldenCities
{
    public partial class TravelMoreInfo : ContentPage
    {
        ListClass x;

        public TravelMoreInfo()
        {
            InitializeComponent();
        }

        public TravelMoreInfo(ListClass listclass)
        {
            InitializeComponent();
            BindingContext = listclass;
            x = listclass;
        }
    }
}
