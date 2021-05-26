using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GoldenCities.ClassModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace GoldenCities
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        void SignInProcedure(object sender, EventArgs e)
        {
            User user = new User(Entry_Username.Text, Entry_Password.Text);


            if (String.IsNullOrEmpty(Entry_Username.Text) || String.IsNullOrEmpty(Entry_Password.Text))
            {
                DisplayAlert("Login", "The Username or Password is Blank", "Try Again");
            }

            else if (user.CheckInformation())
            {
                Navigation.PushAsync(new ContinentsListView());
            }
            else
            {
                DisplayAlert("Login", "The Username or Password is incorrect", "Try Again");
            }
        }
    }
}