using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Maker.Serial;
using Microsoft.Maker.RemoteWiring;
using System.Threading.Tasks;
using Windows.System.Threading;
using System.Threading;
using System.Diagnostics;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        
        String input;
       public static int Count = 0;

        public static String stat;

        public static ushort green = 0;

        static RemoteDevice arduino;

        public MainPage()
        {
            this.InitializeComponent();


            UsbSerial usb = new UsbSerial("VID_2341", "PID_0043");


            arduino = new RemoteDevice(usb);


            usb.begin(57600, SerialConfig.SERIAL_8N1);



        }




        static async Task Delay(int DelayTime)
        {

            await Task.Delay(DelayTime);

        }







        //officelight

        private void officelightoffclick(object sender, RoutedEventArgs e) { officelightoff(); }

        private void officelightonclick(object sender, RoutedEventArgs e) { officelighton(); }

        public static void officelighton() { arduino.digitalWrite(7, PinState.LOW); }

        public static void officelightoff() { arduino.digitalWrite(7, PinState.HIGH); }


        //mainlight

        private void mainlightoffclick(object sender, RoutedEventArgs e) { mainlightoff(); }

        private void mainlightonclick(object sender, RoutedEventArgs e) { mainlighton(); }

        public static void mainlighton() { arduino.digitalWrite(3, PinState.LOW); }

        public static void mainlightoff() { arduino.digitalWrite(3, PinState.HIGH); }

        //readinglight

        private void readinglightoffclick(object sender, RoutedEventArgs e) { readinglightoff(); }

        private void readinglightonclick(object sender, RoutedEventArgs e) { readinglighton(); }

        public static void readinglighton() { arduino.digitalWrite(2, PinState.LOW); }

        public static void readinglightoff() { arduino.digitalWrite(2, PinState.HIGH); }


        //officedevices

        private void officedevicesoffclick(object sender, RoutedEventArgs e) { officedevicesoff(); }

        private void officedevicesonclick(object sender, RoutedEventArgs e) { officedeviceson(); }

        public static void officedeviceson() { arduino.digitalWrite(4, PinState.LOW); }

        public static void officedevicesoff() { arduino.digitalWrite(4, PinState.HIGH); }



        //door

        private void opendoorclick(object sender, RoutedEventArgs e) { opendoor(); }

        private void closedoorclick(object sender, RoutedEventArgs e) { closedoor(); }

        public static async void opendoor() {

            arduino.digitalWrite(8, PinState.HIGH);
            arduino.digitalWrite(9, PinState.LOW);
            await Delay(10000);
            arduino.digitalWrite(8, PinState.LOW);
            arduino.digitalWrite(9, PinState.LOW);

        }

        public static async void closedoor() {

            arduino.digitalWrite(8, PinState.LOW);
            arduino.digitalWrite(9, PinState.HIGH);
           await  Delay(10000);
            arduino.digitalWrite(8, PinState.LOW);
            arduino.digitalWrite(9, PinState.LOW);

            

        }


        //ledstrip

        private void ledstripoffclick(object sender, RoutedEventArgs e) {

            ledstripoff();

        }

        private void ledstriponclick(object sender, RoutedEventArgs e) {

            input = this.colorbox.Text;
           
           

            switch (input)
            {
                //6=blue;
                //10=green;
                //5=red;

                case "blue":
                    ledstriponblue();

                    break;

                case "red":

                    ledstriponred();

                    break;

                case "green":

                    ledstripongreen();

                    break;
                case "normal":

                    ledstripon();

                    break;

                case "yellow":

                    ledstriponyellow();

                    break;

                case "cyan":

                    ledstriponcyan();

                    break;

                case "orange":

                    ledstriponorange();

                    break;

                case "pink":

                    ledstriponpink();
                    break;



                case "purple":

                    ledstriponpurple();
                    break;


            }

        }



        public static async void ledstriponblue()
        {


            for (ushort x = 0; x < 255; x++)
            {

                arduino.analogWrite(6, x);
                arduino.analogWrite(5, 0);
                arduino.analogWrite(10, 0);
                await Delay(10);

            }


        }

        public static async void ledstripongreen()
        {




            for (ushort x = 0; x < 255; x++)
            {

                arduino.analogWrite(6, 0);
                arduino.analogWrite(5, 0);
                arduino.analogWrite(10, x);
                await Delay(10);

            }



        }

        public static async void ledstriponred()
        {

            for (ushort x = 0; x < 255; x++)
            {

                arduino.analogWrite(6, 0);
                arduino.analogWrite(5, x);
                arduino.analogWrite(10, 0);
                await Delay(10);
            }

        }

        public static async void ledstripon()
        {
            for (ushort x = 0; x < 255; x++)
            {

                arduino.analogWrite(6, x);
                arduino.analogWrite(5, x);
                arduino.analogWrite(10, x);
                await Delay(10);
            }

        }

        public static async void ledstriponyellow()
        {


            for (ushort x = 0; x < 255; x++)
            {

                arduino.analogWrite(6, 0);
                arduino.analogWrite(5, x);
                arduino.analogWrite(10, x);
                await Delay(10);
            }
        }

        public static async void ledstriponcyan()
        {


            for (ushort x = 0; x < 255; x++)
            {

                arduino.analogWrite(6, x);
                arduino.analogWrite(5, 0);
                arduino.analogWrite(10, x);
                await Delay(10);
            }
        }

        public static async void ledstriponorange()
        {


            for (ushort x = 0; x < 100; x++)
            {

                arduino.analogWrite(6, 0);
                arduino.analogWrite(5, 0);
                arduino.analogWrite(10, x);
                await Delay(10);
            }

            for (ushort x1 = 0; x1 < 255; x1++)
            {

                arduino.analogWrite(6, 0);
                arduino.analogWrite(5, x1);
                arduino.analogWrite(10, 100);
                await Delay(10);
            }
        }

        public static async void ledstriponpink()
        {

            

            for (ushort x = 0; x < 147; x++)
            {

                arduino.analogWrite(6, x);
                arduino.analogWrite(5, 0);
                arduino.analogWrite(10, 0);
                await Delay(10);
            }

            for (ushort x1 = 0; x1 < 255; x1++)
            {

                arduino.analogWrite(6, 147);
                arduino.analogWrite(5, x1);
                arduino.analogWrite(10, 0);
                await Delay(10);
            }

            for (ushort x2 = 0; x2 < 20; x2++)
            {

                arduino.analogWrite(6, 147);
                arduino.analogWrite(5, 255);
                arduino.analogWrite(10, x2);
                await Delay(10);
            }
        }

        public static async void ledstriponpurple()
        {


            for (ushort x = 0; x < 211; x++)
            {

                arduino.analogWrite(6, x);
                arduino.analogWrite(5, 0);
                arduino.analogWrite(10, 0);
                await Delay(10);
            }

            for (ushort x1 = 0; x1 < 148; x1++)
            {

                arduino.analogWrite(6, 211);
                arduino.analogWrite(5, x1);
                arduino.analogWrite(10, 0);
                await Delay(10);
            }
        }

        public static void ledstripoff()
        {

            arduino.analogWrite(6, 0);
            arduino.analogWrite(5, 0);
            arduino.analogWrite(10, 0);
            Count = 1;



        }
        
        //all

        private void allonclick(object sender, RoutedEventArgs e) { allon(); }

        private void alloffclick(object sender, RoutedEventArgs e) { alloff(); }

        public static void allon() {


            

            mainlighton();
            readinglighton();
            officedeviceson();
            officelighton();
         


        }

        public static void alloff() {

            arduino.analogWrite(6, 0);
            arduino.analogWrite(5, 0);
            arduino.analogWrite(10, 0);


            mainlightoff();
            readinglightoff();
            officedevicesoff();
            officelightoff();

          

        }

        //fade

     


        private void fadeonclick(object sender, RoutedEventArgs e) {

            

            fadeon();
            

        }


        public void getText()
        {

          // int speed = (int) fadespeed.Text;

 

        }

        public static async void fadeon()
        {

            Count = 0;

            while (Count == 0)
            {

                setColourRgb(0, 0, 0);

                ushort[] rgbColour = { 255, 0, 0 };




                // Choose the colours to increment and decrement.

                for (int decColour = 0; decColour < 3; decColour += 1)
                {

                    int incColour = decColour == 2 ? 0 : decColour + 1;



                    // cross-fade the two colours.

                    for (int i = 0; i < 255; i += 1)
                    {

                        rgbColour[decColour] -= 1;

                        rgbColour[incColour] += 1;




                        setColourRgb(rgbColour[0], rgbColour[1], rgbColour[2]);

                         await Delay(10);




                    }

                }

            }

            ledstripoff();

        }





        public static void setColourRgb(ushort red, ushort green, ushort blue)
        {

            arduino.analogWrite(6, blue);

            arduino.analogWrite(10, green);

            arduino.analogWrite(5, red);




        }















        //keyboard support Coming Soon!


        //Alarm code
        private System.Threading.Timer timer;
        private void SetUpTimer(int uren,int min)
        {


            DateTime now = DateTime.Now;
            //20:03- 23:00

            DateTime alarm = new DateTime(now.Year,now.Month,now.Day,uren,min,0);


           


            if (DateTime.Compare(now, alarm) == 1)
            {

                alarm = alarm.AddDays(1);

            }


            TimeSpan diffrence = alarm.Subtract(now);
            this.timer = new Timer(x =>
            {
              

                RiseSun();
                timer.Dispose() ;

                

                
              
            }, null, diffrence, Timeout.InfiniteTimeSpan);




            System.Diagnostics.Debug.WriteLine(diffrence.ToString());



        }

      
    

        private void setAlarm_Click(object sender, RoutedEventArgs e)
        {

            int uren = int.Parse(hours.Text);

            int min = int.Parse(minutes.Text);

            
            Status.Text = "Status: Alarm set " + uren + ":" + min;

            SetUpTimer(uren,min);

            System.Diagnostics.Debug.WriteLine("alarm gezet" + uren + min);
        }


        private void stop_Click(object sender, RoutedEventArgs e)
        {

            ledstripoff();
            timer.Dispose();
            

        }

        public static void RiseSun()
        {

            System.Diagnostics.Debug.WriteLine("tut tut tut");

            




            for (ushort red = 0; red < 255; red++)
            {


                if (green < 100 && red > 10)
                {

                    green++;
                    red++;

                }

                

                arduino.analogWrite(6, 0);
                arduino.analogWrite(5, red);
                arduino.analogWrite(10, green);
                Task.Delay(TimeSpan.FromSeconds(10)) .Wait();

            }

       
        
        }

       
    }





}




