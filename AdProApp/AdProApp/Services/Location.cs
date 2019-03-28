using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdProApp
{
   public class Location
    {
        public async Task<string> GetLocationAsync()        // this method gets the device location and the address using geoLocator plugin
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));


            var address = await locator.GetAddressesForPositionAsync(new Plugin.Geolocator.Abstractions.Position(position.Latitude, position.Longitude));

            var a = address.FirstOrDefault();
            var b = address.ElementAt(1);
            //await  DisplayAlert("add","Address: Thoroughfare" + a.Thoroughfare +"Locality " + a.Locality + " CountryCode " + a.CountryCode + "CountryName " + a.CountryName + "PostalCode " + a.PostalCode +  "SubLocality" + a.SubLocality+"SubThoroughfare" + a.SubThoroughfare ,"ok");

            string area = a.Locality; // town name
                                      //string longi = position.Longitude.ToString();
            string County = b.SubAdminArea;

            //string lat = position.Latitude.ToString();

            //string Location = lat + " " + longi;

            string displayloc = a.Thoroughfare + " " + b.FeatureName + ", " + a.Locality;

           // LocationLabel.Text = displayloc.ToString();

           // await GetWeather(a.Locality);





            return County;
        }
    }

    
}
