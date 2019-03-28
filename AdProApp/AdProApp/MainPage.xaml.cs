using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace AdProApp
{
    public partial class MainPage : ContentPage
    {
        //1.1 share static type in weather and then check weather and time in that area
        //1.2 two threads carrying out long task NOT UI THREAD
        //1.3 
        //  Location = new location();
        public MainPage()
        {
            InitializeComponent();
        }

        //private async Task GetLocAsync(object sender, EventArgs e)
        //{
        //    Location Loc = new Location();
        //    string a = await Loc.GetLocationAsync();
        //    string y = a.ToString();

        //    xLocation.Text = y.ToString();
        //}

        private async void GetLocAsync(object sender, EventArgs e)
        {
            try
            {


                Location Loc = new Location();
                string a = await Loc.GetLocationAsync();
                string y = a.ToString();

                xLocation.Text = y.ToString();
                //Fix
                WeatherMethods Wm = new WeatherMethods();
                var b =await Wm.GetWeather(a.ToString());
                string c = b.ToString();
                xTemperature.Text = c.ToString();
            }
            catch (Exception GetLocAsyncEX)
            {
                await DisplayAlert("Error", GetLocAsyncEX.ToString(), "ok");
                throw;
            }
        }

        private async void CheckTime(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WeatherTimePage());
        }
    }
}
