using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using System.Diagnostics;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static AdProApp.openw;

namespace AdProApp
{
    public class WeatherMethods
    {




        public async Task<object> GetWeather(string zipCode)//this method gets the weather based on the location of the device
        {
            ////Sign up for a free API key at http://openweathermap.org/appid  
            string key = "c4377316540a54826135576671db07f2";
            ////string queryString = "http://api.openweathermap.org/data/2.5/weather?q={" + zipCode.ToString() + "}&appid=" + key;

            var client = new HttpClient();

            client.BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/weather?q=");
            string str1 = "http://api.openweathermap.org/data/2.5/weather?q=";

            var query = zipCode.ToString() + "&appid=" + key + "&units=metric";

            var url = string.Format(str1 + query);
            var test = await client.GetStringAsync(url);

            Debug.Write("==============================");
            Debug.Write(test);
            Debug.Write("==============================");
            //var objlist = Newtonsoft.Json.d
            //var myobjList = Json.Deserialize<List<Main>>(test);
            //var myObj = myobjList[0];
            //var rootObject = JsonConvert.DeserializeObject<openw.RootObject>(test);

            RootObject @object = JsonConvert.DeserializeObject<RootObject>(test);
            // rootObject.main.temp.ToString();
            @object.ToString();

            Debug.Write("==============================");
           // string temp = main.main.temp.ToString();
            //TemperatureLabel.Text = temp.ToString() + "°C";
            //Debug.Write(main.temp_max.ToString());
            //Debug.Write(main.temp_min.ToString());
            Debug.Write("==============================");
            // TempLabel.Text = openw1..temp.ToString();

            //client.DefaultRequestHeaders
            // dynamic results = await DataService.GetDataFromService(queryString).ConfigureAwait(false);

            //var response = await client.GetAsync(query);
            //await DisplayAlert("hi", main.temp_max.ToString(), "ok");

            //dynamic data = null;

            //if (response != null)
            //{
            //    string json = response.Content.ReadAsStringAsync().Result;
            //    data = JsonConvert.DeserializeObject(json);

            //    //string viewz = Convert.ToString(data);

            //}

            // string apiKey = "Your API KEY";
            //HttpWebRequest apiRequest = WebRequest.Create("http://api.openweathermap.org/data/2.5/weather?q=" + zipCode + "&appid=" + key + "&units=metric") as HttpWebRequest;

            //string apiResponse = "";
            //using (HttpWebResponse response1 = apiRequest.GetResponse() as HttpWebResponse)
            //{
            //    StreamReader reader = new StreamReader(response1.GetResponseStream());
            //    apiResponse = reader.ReadToEnd();
            //    var rootObject = JsonConvert.DeserializeObject(response1.ToString());
            //    await DisplayAlert("hi", rootObject.ToString(), "ok");
            //}
            //var rootObject = JsonConvert.DeserializeObject(response1);

            //await DisplayAlert("hi", apiResponse.ToString(), "ok");

            //if (results["weather"] != null)
            //{
            //    Weather weather = new Weather();
            //    weather.Title = (string)results["name"];
            //    weather.Temperature = (string)results["main"]["temp"] + " F";
            //    weather.Wind = (string)results["wind"]["speed"] + " mph";
            //    weather.Humidity = (string)results["main"]["humidity"] + " %";
            //    weather.Visibility = (string)results["weather"][0]["main"];

            //    DateTime time = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            //    DateTime sunrise = time.AddSeconds((double)results["sys"]["sunrise"]);
            //    DateTime sunset = time.AddSeconds((double)results["sys"]["sunset"]);
            //    weather.Sunrise = sunrise.ToString() + " UTC";
            //    weather.Sunset = sunset.ToString() + " UTC";
            //    return weather;
            //}
            //else
            //{
            //    return null;
            //}


            return @object.main.temp;

        }
    }

    public class openw
    {//class to store location & weather

        public class Coord
        {
            public double lon { get; set; }
            public double lat { get; set; }
        }

        public class Weather
        {
            public int id { get; set; }
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }

        public class Main
        {
            public double temp { get; set; }
            public double pressure { get; set; }
            public double humidity { get; set; }
            public double temp_min { get; set; }
            public double temp_max { get; set; }
        }

        public class Wind
        {
            public double speed { get; set; }
        }

        public class Clouds
        {
            public int all { get; set; }
        }

        public class Sys
        {
            public int type { get; set; }
            public int id { get; set; }
            public double message { get; set; }
            public string country { get; set; }
            public int sunrise { get; set; }
            public int sunset { get; set; }
        }

        public class RootObject
        {
            public Coord coord { get; set; }
            public List<Weather> weather { get; set; }
            public string @base { get; set; }
            public Main main { get; set; }
            public int visibility { get; set; }
            public Wind wind { get; set; }
            public Clouds clouds { get; set; }
            public int dt { get; set; }
            public Sys sys { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public int cod { get; set; }
        }



    }
   
}
