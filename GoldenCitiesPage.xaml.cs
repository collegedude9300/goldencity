using System;
using System.Diagnostics;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace GoldenCities
{
    public partial class GoldenCitiesPage : ContentPage
    {
        public GoldenCitiesPage()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(GoldenCitiesPage)}: ctor");
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        void Handle_ClickedLogin(object sender, System.EventArgs e)
        {

            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(Handle_ClickedLogin)}");

                Navigation.PushAsync(new LoginPage());
           
        }

        void Handle_ClickedRegister(object sender, System.EventArgs e)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(Handle_ClickedRegister)}");
            Navigation.PushAsync(new RegisterActivity());
        }
        void Handle_ClickedContinents (object sender, System.EventArgs e)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(Handle_ClickedRegister)}");
            Navigation.PushAsync(new ContinentsListView());
        }

        void Handle_ClickedMoney(object sender, System.EventArgs e)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(Handle_ClickedRegister)}");
            if (CrossConnectivity.Current.IsConnected != true)
            {
                DisplayAlert("Wifi Connection Status", "No Service you are not connected to Wifi", "Try Again");
            }
            else
            {
                Navigation.PushAsync(new CurrencyData());
            }
        }

    }
}
