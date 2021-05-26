using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GoldenCities.ClassModels;
using SQLite;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace GoldenCities
{
    public partial class App : Application
    {
        static UserDatabases database;

        public App()
        {
            Debug.WriteLine($"*** {this.GetType().Name}.{nameof(App)}: ctor");
            InitializeComponent();

            MainPage = new NavigationPage(new GoldenCitiesPage());
        }

        public static UserDatabases Database{
            get{
                if(database == null)
                {
                    database = new UserDatabases(DependencyService.Get<ILocalFileHelper>().GetLocalFilePath("User.db3"));
                }
                return database;
            }
        }

        protected override void OnStart()
        {
            Debug.WriteLine($"****{this.GetType().Name}.{nameof(OnStart)}");
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            Debug.WriteLine($"****{this.GetType().Name}.{nameof(OnSleep)}");
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            Debug.WriteLine($"****{this.GetType().Name}.{nameof(OnResume)}");
            // Handle when your app resumes
        }
    }
}
