using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace GoldenCities.ClassModels
{
    public class ListClass
    {

        public ImageSource IconSource
        {
            get;
            set;
        }

        public string websiteName
        {
            get;
            set;
        }

        public string websiteDescription
        {
            get;
            set;
        }


        public string city
        {
            get;
            set;
        }


        public double[] latitude
        {
            get;
            set;
        }

        public double[] longitude
        {
            get;
            set;
        }

        public string[] places
        {
            get;
            set;
        }
        public string wetherkey
        {
            get;
            set;
        }
    }
}
