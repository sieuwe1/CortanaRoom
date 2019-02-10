using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CoRGB
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page 
    {
        //Sensor s;
        Alarm a;
        private int count;

        public MainPage()
        {
            this.InitializeComponent();

            if (count == 0)
            {
                //startup code
                LoadDefaults();

                if (Setting.Instance.ReadSensorOn == true)
                {
                    //s = new Sensor();
                }

                Board.Instance.connect();
                WriteDefaults();
                a = new Alarm();
                UiUpdater();

                count++;
            }
            else
            {
                Board.Instance.connect();
                a = new Alarm();
            }
        }

        private void MainLight_Click(object sender, RoutedEventArgs e)
        {

            if (Setting.Instance.MainLightOn == false)
            {
                Board.Instance.ChangePinState(Setting.Instance.MainLightpin, 0); //doeterug
                Setting.Instance.MainLightOn = true;
            }
            else
            {
                Board.Instance.ChangePinState(Setting.Instance.MainLightpin, 1);
                Setting.Instance.MainLightOn = false;
            }
        }

        private void OfficeLight_Click(object sender, RoutedEventArgs e)
        {
            if (Setting.Instance.OfficeLightOn == false)
            {
                Board.Instance.ChangePinState(Setting.Instance.OfficeLightpin, 1);
                Setting.Instance.OfficeLightOn = true;
            }
            else
            {
                Board.Instance.ChangePinState(Setting.Instance.OfficeLightpin, 0);
                Setting.Instance.OfficeLightOn = false;
            }
        }

        private void ReadingLight_Click(object sender, RoutedEventArgs e)
        {
            if (Setting.Instance.ReadingLightOn == false)
            {
                Board.Instance.ChangePinState(Setting.Instance.ReadingLightpin, 0); //doeterug
                Setting.Instance.ReadingLightOn = true;
            }
            else
            {
                Board.Instance.ChangePinState(Setting.Instance.ReadingLightpin, 1);
                Setting.Instance.ReadingLightOn = false;
            }
        }

        private void TVOn_Click(object sender, RoutedEventArgs e)
        {
            if (Setting.Instance.TVOn == false)
            {
                Board.Instance.ChangePinState(Setting.Instance.TVpin, 0);
                Setting.Instance.TVOn = true;
            }
            else
            {
                Board.Instance.ChangePinState(Setting.Instance.TVpin, 1);
                Setting.Instance.TVOn = false;
            }
        }

        private void OfficeOn_Click(object sender, RoutedEventArgs e)
        {
            if (Setting.Instance.OfficeOn == false)
            {
                Board.Instance.ChangePinState(Setting.Instance.Officepin, 1);
                Setting.Instance.OfficeOn = true;
            }
            else
            {
                Board.Instance.ChangePinState(Setting.Instance.Officepin, 0);
                Setting.Instance.OfficeOn = false;
            }
        }

        private void FlashOn_Click(object sender, RoutedEventArgs e)
        {
            if (Setting.Instance.FlashOn == false)
            {
                Setting.Instance.flashColor = FlashColor.Text;
                Setting.Instance.flashTime = Convert.ToInt32(FlashTime.Text);
                Setting.Instance.FlashOn = true;
                Ledstrip.Flash();
            }
            else
            {
                Setting.Instance.FlashOn = false;
            }
        }

        private void FadeOneOn_Click(object sender, RoutedEventArgs e)
        {
            if (Setting.Instance.FadeOneOn == false)
            {
                Setting.Instance.fadeOneColor = FadeOneColor.Text;
                Setting.Instance.fadeOneTime = Convert.ToInt32(FadeOneTime.Text);
                Setting.Instance.FadeOneOn = true;
                Ledstrip.FadeOne();
            }
            else
            {
                Setting.Instance.FadeOneOn = false;
            }
        }

        private void FadeOn_Click(object sender, RoutedEventArgs e)
        {
            if (Setting.Instance.FadeOn == false)
            {
                Setting.Instance.fadeTime = Convert.ToInt32(FadeTime.Text);
                Setting.Instance.FadeOn = true;
                Ledstrip.Fade();
            }
            else
            {
                Setting.Instance.FadeOn = false;
            }
        }

        private void LedOn_Click(object sender, RoutedEventArgs e)
        {
            Setting.Instance.LedColor = LedColor.Text;

            switch (LedColor.Text)
            {
                case "Red":
                    Board.Instance.WriteColor(0, 0, 0);
                    Board.Instance.WriteSmoothColor(255, 0, 0);
                    break;
                case "Green":
                    Board.Instance.WriteColor(0, 0, 0);
                    Board.Instance.WriteSmoothColor(0, 255, 0);
                    break;
                case "Blue":
                    Board.Instance.WriteColor(0, 0, 0);
                    Board.Instance.WriteSmoothColor(0, 0, 255);
                    break;
                case "Yellow":
                    Board.Instance.WriteColor(0, 0, 0);
                    Board.Instance.WriteSmoothColor(255, 255, 0);
                    break;
                case "Purple":
                    Board.Instance.WriteColor(0, 0, 0);
                    Board.Instance.WriteSmoothColor(128, 0, 128);
                    break;
                case "White":
                    Board.Instance.WriteColor(0, 0, 0);
                    Board.Instance.WriteSmoothColor(255, 255, 255);
                    break;
                case "Cyan":
                    Board.Instance.WriteColor(0, 0, 0);
                    Board.Instance.WriteSmoothColor(0, 255, 255);
                    break;
                default:
                    Board.Instance.WriteColor(0, 0, 0);
                    break;
            }
        }

        private void LoadDefaults()
        {
            FadeOneTime.Text = Setting.Instance.fadeOneTime.ToString();
            FadeTime.Text = Setting.Instance.fadeTime.ToString();
            FlashTime.Text = Setting.Instance.flashTime.ToString();
            FlashColor.Text = Setting.Instance.flashColor;
            FadeOneColor.Text = Setting.Instance.fadeOneColor;
            LedColor.Text = Setting.Instance.LedColor;
            AlarmPicker.Time = Setting.Instance.AlarmTime;
            
            switch (Setting.Instance.LedColor)
            {
                case "Red":
                    LEDstatus.Background = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                    break;
                case "Green":
                    LEDstatus.Background = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
                    break;
                case "Blue":
                    LEDstatus.Background = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
                    break;
                case "Yellow":
                    LEDstatus.Background = new SolidColorBrush(Color.FromArgb(255, 255, 0, 255));
                    break;
                case "Purple":
                    LEDstatus.Background = new SolidColorBrush(Color.FromArgb(255, 128, 0, 128));
                    break;
                case "White":
                    LEDstatus.Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                    break;
                case "Cyan":
                    LEDstatus.Background = new SolidColorBrush(Color.FromArgb(255, 0, 255, 255));
                    break;
                default:
                    LEDstatus.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                    break;
            }
        }

        private void WriteDefaults()
        {

            if (Setting.Instance.MainLightOn == false)
            {
                Board.Instance.ChangePinState(Setting.Instance.MainLightpin, 1);
            }
            if (Setting.Instance.ReadingLightOn == false)
            {
                Board.Instance.ChangePinState(Setting.Instance.ReadingLightpin, 1);
            }
            if (Setting.Instance.OfficeLightOn == false)
            {
                Board.Instance.ChangePinState(Setting.Instance.OfficeLightpin, 0);
            }
            if (Setting.Instance.TVOn == false)
            {
                Board.Instance.ChangePinState(Setting.Instance.TVpin, 1);
            }
            if (Setting.Instance.OfficeOn == false)
            {
                Board.Instance.ChangePinState(Setting.Instance.Officepin ,0);
            }
            if (Setting.Instance.LedColor == "blank")
            {
                Board.Instance.WriteColor(0, 0, 0);
            }
            
            //uipdate for on

            if (Setting.Instance.MainLightOn == true)
            {
                Board.Instance.ChangePinState(Setting.Instance.MainLightpin, 0);
            }
            if (Setting.Instance.ReadingLightOn == true)
            {
                Board.Instance.ChangePinState(Setting.Instance.ReadingLightpin, 0);
            }
            if (Setting.Instance.OfficeLightOn == true)
            {
                Board.Instance.ChangePinState(Setting.Instance.OfficeLightpin, 1);
            }
            if (Setting.Instance.TVOn == true)
            {
                Board.Instance.ChangePinState(Setting.Instance.TVpin, 0);
            }
            if (Setting.Instance.OfficeOn == true)
            {
                Board.Instance.ChangePinState(Setting.Instance.Officepin, 1);
            }
            
            switch(Setting.Instance.LedColor)
            { 
             case "Red":
                    Board.Instance.WriteColor(0, 0, 0);
            Board.Instance.WriteSmoothColor(255, 0, 0);
            break;
                case "Green":
                    Board.Instance.WriteColor(0, 0, 0);
            Board.Instance.WriteSmoothColor(0, 255, 0);
            break;
                case "Blue":
                    Board.Instance.WriteColor(0, 0, 0);
            Board.Instance.WriteSmoothColor(0, 0, 255);
            break;
                case "Yellow":
                    Board.Instance.WriteColor(0, 0, 0);
            Board.Instance.WriteSmoothColor(255, 255, 0);
            break;
                case "Purple":
                    Board.Instance.WriteColor(0, 0, 0);
            Board.Instance.WriteSmoothColor(128, 0, 128);
            break;
                case "White":
                    Board.Instance.WriteColor(0, 0, 0);
            Board.Instance.WriteSmoothColor(255, 255, 255);
            break;
                case "Cyan":
                    Board.Instance.WriteColor(0, 0, 0);
            Board.Instance.WriteSmoothColor(0, 255, 255);
            break;
            default:
                    Board.Instance.WriteColor(0, 0, 0);
            break;
        }


        }


        private Task UiUpdater()
        {
           
            return Task.Run(async () =>
            {
                while (true)
                {
                    await Board.Instance.Delay(30);
                    

                        Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
() =>
{

                        if (Setting.Instance.MainLightOn == false)
                        {
                            MainLightStatus.Background = (SolidColorBrush)Resources["Red"];
                        }
                        if (Setting.Instance.ReadingLightOn == false)
                        {
                            ReadingLightStatus.Background = (SolidColorBrush)Resources["Red"];
                        }
                        if (Setting.Instance.OfficeLightOn == false)
                        {
                            OfficeLightStatus.Background = (SolidColorBrush)Resources["Red"];
                        }
                        if (Setting.Instance.TVOn == false)
                        {
                            TVStatus.Background = (SolidColorBrush)Resources["Red"];
                        }
                        if (Setting.Instance.OfficeOn == false)
                        {
                            OfficeStatus.Background = (SolidColorBrush)Resources["Red"];
                        }
                        if (Setting.Instance.LedColor == "blank")
                        {
                            LEDstatus.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                          
                        }

                        if (Setting.Instance.FadeOn == false)
                        {
                            FadeStatus.Background = (SolidColorBrush)Resources["Red"];
                        }
                        if (Setting.Instance.FadeOneOn == false)
                        {
                            FadeOneStatus.Background = (SolidColorBrush)Resources["Red"];
                        }
                        if (Setting.Instance.FlashOn == false)
                        {
                            FlashStatus.Background = (SolidColorBrush)Resources["Red"];
                        }
                        if (Setting.Instance.SensorTriggerd == false )
                        {
                            SensorStatus.Background = (SolidColorBrush)Resources["Red"]; 
                        }
                        if (Setting.Instance.AlarmOn == false)
                        {
                            AlarmStatus.Background = (SolidColorBrush)Resources["Red"];
                        }

                        //uipdate for on

                        if (Setting.Instance.MainLightOn == true)
                        {
                            MainLightStatus.Background = (SolidColorBrush)Resources["Green"];
                        }
                        if (Setting.Instance.ReadingLightOn == true)
                        {
                            ReadingLightStatus.Background = (SolidColorBrush)Resources["Green"];
                        }
                        if (Setting.Instance.OfficeLightOn == true)
                        {
                            OfficeLightStatus.Background = (SolidColorBrush)Resources["Green"];
                        }
                        if (Setting.Instance.TVOn == true)
                        {
                            TVStatus.Background = (SolidColorBrush)Resources["Green"];
                        }
                        if (Setting.Instance.OfficeOn == true)
                        {
                            OfficeStatus.Background = (SolidColorBrush)Resources["Green"];
                        }
                        if (Setting.Instance.FadeOn == true)
                        {
                            FadeStatus.Background = (SolidColorBrush)Resources["Green"];
                        }
                        if (Setting.Instance.FadeOneOn == true)
                        {
                            FadeOneStatus.Background = (SolidColorBrush)Resources["Green"];
                        }
                        if (Setting.Instance.FlashOn == true)
                        {
                            FlashStatus.Background = (SolidColorBrush)Resources["Green"];
                        }
                        if (Setting.Instance.SensorTriggerd == true)
                        {
                            SensorStatus.Background = (SolidColorBrush)Resources["Green"];
                        }
                        if (Setting.Instance.AlarmOn == true)
                        {
                            AlarmStatus.Background = (SolidColorBrush)Resources["Green"];
                        }

                        switch (Setting.Instance.LedColor)
                        {
                            case "Red":
                                LEDstatus.Background = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                              
                                break;
                            case "Green":
                                LEDstatus.Background = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
                              
                                break;
                            case "Blue":
                                LEDstatus.Background = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
                             
                                break;
                            case "Yellow":
                                LEDstatus.Background = new SolidColorBrush(Color.FromArgb(255, 255, 0, 255));
                              
                                break;
                            case "Purple":
                                LEDstatus.Background = new SolidColorBrush(Color.FromArgb(255, 128, 0, 128));
                                
                                break;
                            case "White":
                                LEDstatus.Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                                
                                break;
                            case "Cyan":
                                LEDstatus.Background = new SolidColorBrush(Color.FromArgb(255, 0, 255, 255));
                               
                                break;
                            default:
                                LEDstatus.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                              
                                break;
                        }

                    }
                    );

                    }
                
            });
        }


        private void SettingsOn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Settings));
        }

        private void HelpOn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Help));
        }

        private void AllOff_Click(object sender, RoutedEventArgs e)
        {
            Board.instance.AllOff();
        }

        private void AlarmOn_Click(object sender, RoutedEventArgs e)
        {

            if (Setting.Instance.AlarmOn == false)
            {
                Setting.Instance.AlarmTime = AlarmPicker.Time;
                a.SetUpTimer();
                Setting.Instance.AlarmOn = true;
            }
            else
            {
                a.stopAlarm();
                Setting.Instance.AlarmOn = false;
            }
           
        }

       
    }
}
