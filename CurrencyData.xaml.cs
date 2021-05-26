using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Plugin.Connectivity;
using System.Net.Http;
using GoldenCities.ClassModels;
using Xamarin.Forms;

namespace GoldenCities
{
    public partial class CurrencyData : ContentPage
    {
        string[] keys = new string[168];
        double[] values = new double[168];
        int touchIndex = 0;

        public CurrencyData()
        {
            InitializeComponent();
            if (CrossConnectivity.Current.IsConnected != true)
            {
                DisplayAlert("Wifi Connection Status", "No Service you are not connected to Wifi", "Try Again");
          
            }
            else
            {
                getData();
            }
        }

        async void getData()
        {

          
                HttpClient client = new HttpClient();

                var uri = new Uri(
                    string.Format(
                        $"http://www.apilayer.net/api/live?access_key=" +
                        $"{TransKeys.CurrencyKey}"));


                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Get;
                request.RequestUri = uri;
                request.Headers.Add("Application", "application / json");

                HttpResponseMessage response = await client.SendAsync(request);

                Currency Money = null;

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Money = Currency.FromJson(content);

                    Dictionary<string, double> pairs = Money.Quotes;

                    Source.Text = Money.Source;

                    pairs.Keys.CopyTo(keys, 0);
                    pairs.Values.CopyTo(values, 0);
                    Picker();
                }
           
        }
        private void Picker()
        {
            Selector.SelectedIndex = 0;

            var Country_Selector_Source = new ObservableCollection<string>();

            for (int i = 0; i < 168; i++)
            {
                Country_Selector_Source.Add(keys[i]);
            }
            Selector.ItemsSource = Country_Selector_Source;
        }

        void Handle_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var selector = (Picker)sender;
            touchIndex = selector.SelectedIndex;
            Quotes.Text = "Country: ";
            amount.Text = "Currency: ";
        }

        void Handle_ClickedCurrency(object sender, System.EventArgs e)
        {
            Quotes.Text += keys[touchIndex];
            amount.Text += values[touchIndex];
        }
    }
}