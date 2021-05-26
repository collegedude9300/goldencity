using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GoldenCities.ClassModels;
using Xamarin.Forms;

namespace GoldenCities
{
    public partial class ContinentsListView : ContentPage
    {
        public ContinentsListView()
        {
            InitializeComponent();
           
        }

        void HandleClickedNA(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NorthAmerica());
        }
       
        void HandleClickedSA(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SouthAmerica());
        }
       
        void HandleClickedEUR(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Europe());
        }
       
        void HandleClickedAF(object sender, EventArgs e)
        {
            Navigation.PushAsync(new African());
        }
       
        void HandleClickedAS(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Asia());
        }
       
        void HandleClickedAUS(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Australia());
        }

        void HandleClickedANT(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Antartica());
        }
       
       

       
    }
}
