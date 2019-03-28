using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdProApp.Services
{
    public class Time
    {
        public async Task<DateTime> GetTime(string Location)
        {//get the time now 
            try
            {


                DateTime time ;//empty to store the retreived time
                DateTime currentTime = DateTime.UtcNow;//time now

            switch (Location.ToString())
            {//convert time now to different time zones.
                case "Madrid":
                        TimeZoneInfo euZone = TimeZoneInfo.FindSystemTimeZoneById("Europe/Madrid");//get Time zone
                        DateTime euTime = TimeZoneInfo.ConvertTimeFromUtc(currentTime, euZone); //take current from other to get time in spain
                        time = euTime;
                        break;
                case "Beijing":
                        
                    TimeZoneInfo asZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Shanghai");
                        DateTime asTime = TimeZoneInfo.ConvertTimeFromUtc(currentTime, asZone);//china
                        time = asTime;
                        break;
                case "New York":
                        TimeZoneInfo estZone = TimeZoneInfo.FindSystemTimeZoneById("America/New_York");
                        DateTime easternTime = TimeZoneInfo.ConvertTimeFromUtc(currentTime, estZone); //east america
                        //easternTime = easternTime.ToShortTimeString();
                        time = easternTime;

                        break;
                case "Los Angles":
                        TimeZoneInfo pstZone = TimeZoneInfo.FindSystemTimeZoneById("America/Los_Angeles");
                        DateTime LaTime = TimeZoneInfo.ConvertTimeFromUtc(currentTime, pstZone);   
                        time = LaTime;
                    break;
                default:
                    time = DateTime.Now;
                    break;
            }
            //return time to page
            return time;
            }
            catch (TimeZoneNotFoundException tznfEX)
            {
                Console.WriteLine(tznfEX.ToString());
                throw;
            }
        }

    }
}
