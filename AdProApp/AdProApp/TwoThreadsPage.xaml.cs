using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AdProApp.Services;
using System.Threading;

namespace AdProApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TwoThreadsPage : ContentPage
	{
        //static variables  to share
        public static string choice = "Choose a Country";
        public static string spain = "Madrid";
        public static string china = "Beijing";
        public static string NewY = "New York";
        public static string LA = "Los Angeles";

        public string chosenLocation = "";

        public TwoThreadsPage ()
		{
			
            InitializeComponent();
            Pick.Items.Add(choice.ToString());
            Pick.Items.Add(spain.ToString());
            Pick.Items.Add(china.ToString());
            Pick.Items.Add(NewY.ToString());
            Pick.Items.Add(LA.ToString());
            Pick.SelectedIndex = 0;
            Pick.SelectedIndexChanged += this.myPickerSelectedIndexChanged;
        }


        public async void myPickerSelectedIndexChanged(object sender, EventArgs e)
        {

            //Method call every time when picker selection changed.
            var selectedValue = Pick.Items[Pick.SelectedIndex];
            chosenLocation = selectedValue;
            if (Pick.SelectedIndex == 0)
            {

            }
            else
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                // Thread.Sleep(10000);
                // Creating and initializing new thread 
                Thread thr = new Thread(mywork);
                thr.Start();
                
                Time Tim = new Time();
                DateTime a = await Tim.GetTime(chosenLocation.ToString());
                string y = a.ToString();
                y.ToString();
                string expl = ("It is " + y.ToString() + " in local time");

                xTime.Text = expl.ToString();

                WeatherMethods Wm = new WeatherMethods();
                var b = await Wm.GetWeather(chosenLocation.ToString());
                string c = b.ToString();
                string expl2 = ("It is " + c.ToString() + "°C");
                xTemperature.Text = expl2.ToString();



                stopWatch.Stop();
                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopWatch.Elapsed;

                // Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                string h = ("On One Thread it took : " + elapsedTime);
                xOneThread.Text = h.ToString();
            }

        }

        
    }
}