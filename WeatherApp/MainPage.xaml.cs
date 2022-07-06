using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherData;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WeatherApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void GetWeatherButton_Clicked(object sender, EventArgs e)
        {


            var data = await GetOpenWeatherData();



            BindingContext = data;

        }

        public async Task<OpenWeatherData> GetOpenWeatherData()
        {
            var location = await Geolocation.GetLocationAsync();

            double latitude = location.Latitude;
            double longitude = location.Longitude;

            HttpClient client = new HttpClient();

            string url = $"https://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitude}&units=metric&appid=3c81e988888dff5556464af4bb252cc2";
            string response = await client.GetStringAsync(url);

            OpenWeatherData data = JsonConvert.DeserializeObject<OpenWeatherData>(response);

            return data;

        }



    }
}
