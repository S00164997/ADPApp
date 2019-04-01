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

        public string chosenLocation = "";//empty shared variable to make accessable to other methods

        public TwoThreadsPage ()
		{//display previous thread time 
			
            InitializeComponent();
            // add static string to Picker Items for displaying
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
            chosenLocation = selectedValue;//shared variable
            if (Pick.SelectedIndex == 0)
            {

            }
            else
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                // Thread.Sleep(10000);
                // Creating and initializing new thread 
                Thread Timethread = new Thread(DoTime);
                Timethread.Start();

                Thread Weatherthread = new Thread(DoWeather);
                Weatherthread.Start();





                stopWatch.Stop();
                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopWatch.Elapsed;

                // Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                string h = ("On Two Thread's it took : " + elapsedTime);
                xOneThread.Text = h.ToString();
            }

        }

        public async void DoTime()
        {
            Time Tim = new Time();
            DateTime a = await Tim.GetTime(chosenLocation.ToString());
            string y = a.ToString();
            y.ToString();
            string expl = ("It is " + y.ToString() + " in local time");

            xTime.Text = expl.ToString();

        }

        public async void DoWeather()
        {
            WeatherMethods Wm = new WeatherMethods();
            var b = await Wm.GetWeather(chosenLocation.ToString());
            string c = b.ToString();
            string expl2 = ("It is " + c.ToString() + "°C");
            xTemperature.Text = expl2.ToString();
        }

        }
}