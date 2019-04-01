using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AdProApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainThreadRespPage : ContentPage
    {
        public MainThreadRespPage()
        {
            try
            {

                Console.WriteLine("Start");
                InitializeComponent();

                Thread OneThousand = new Thread(Count1000);
                OneThousand.Start();

                Thread zero = new Thread(Count0);
                zero.Start();
                Console.WriteLine("End");
            }
            catch (Exception f)
            {
                f.ToString();
                throw;
            }
        }

        private void ColorChanged(object sender, EventArgs e)
        {
            try
            {


                Random random = new Random();
                int randomNumber = random.Next(0, 5);

                switch (randomNumber)
                {
                    case 1:
                        this.BackgroundColor = Color.Red;

                        break;
                    case 2:
                        this.BackgroundColor = Color.Yellow;
                        break;
                    case 3:
                        this.BackgroundColor = Color.Green;
                        break;
                    case 4:
                        this.BackgroundColor = Color.Blue;
                        break;
                    default:
                        this.BackgroundColor = Color.White;
                        break;
                }

            }

            catch (Exception ex)
            {
                ex.ToString();
                throw;
            }

        }


        public async void Count1000()
        {
            try
            {


                for (int i = 0; i < 10000; i++)
                {
                    await Task.Delay(1000);
                    Device.BeginInvokeOnMainThread(() =>
                    {//display on main thread
                        First.Text = i.ToString();

                    });

                    
                }
            }
            
            catch (Exception ex0)
            {
                ex0.ToString();
                throw;
            }
}

public async void Count0()
{
    try
    {

        for (int i = 10000; i > 0; i--)
        {
            await Task.Delay(1000);
                    Device.BeginInvokeOnMainThread(() =>
                    {//display on main thread
                        Second.Text = i.ToString();

                    });
                }
    }
    catch (Exception ex1)
    {
        ex1.ToString();
        throw;
    }
}

    }
}