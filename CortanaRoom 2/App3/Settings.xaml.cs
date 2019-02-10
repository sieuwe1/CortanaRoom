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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CoRGB
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Settings : Page
    {
        public Settings()
        {
            this.InitializeComponent();
            loadDefaults();
        }
        
        private void HelpOn_Click(object sender, RoutedEventArgs e)
        {
            applySettings();
            this.Frame.Navigate(typeof(Help));
        }

        private void HomeOn_Click(object sender, RoutedEventArgs e)
        {
            applySettings();
            this.Frame.Navigate(typeof(MainPage));
        }


        private void ConnectionOn_Click(object sender, RoutedEventArgs e)
        {
            Setting.Instance.PID = PID.Text;
            Setting.Instance.VID = VID.Text;

            Board.instance.connect();
            ConnectionStatus.Background = (SolidColorBrush)Resources["Green"];
        }

        private void ReadSensorOn_Click(object sender, RoutedEventArgs e)
        {

            if (Setting.Instance.ReadSensorOn == false)
            {
                Setting.Instance.ReadSensorOn = true;
                Setting.Instance.ReadingLightOn = true;
                ReadSensorStatus.Background = (SolidColorBrush)Resources["Green"];
            }
            else
            {
                Setting.Instance.ReadSensorOn = false;
                Setting.Instance.ReadingLightOn = false;
                ReadSensorStatus.Background = (SolidColorBrush)Resources["Red"];
            }

        }

        private void applySettings()
        {
            Setting.Instance.WakeUpTime = Convert.ToInt32(WakeUpTime.Text);
            Setting.Instance.MainLightpin = Convert.ToInt32(MainLightPin.Text);
            Setting.Instance.OfficeLightpin = Convert.ToInt32(OfficeLightPin.Text);
            Setting.Instance.ReadingLightpin = Convert.ToInt32(ReadingLightPin.Text);
            Setting.Instance.TVpin = Convert.ToInt32(TVPin.Text);
            Setting.Instance.Officepin = Convert.ToInt32(OfficePin.Text);
            Setting.Instance.Rpin = Convert.ToInt32(Rpin.Text);
            Setting.Instance.Gpin = Convert.ToInt32(Gpin.Text);
            Setting.Instance.Bpin = Convert.ToInt32(Bpin.Text);
            Setting.Instance.SensorPin = SensorPin.Text;
            Setting.Instance.VID = VID.Text;
            Setting.Instance.PID = PID.Text;

        }

        private void loadDefaults()
        {

            WakeUpTime.Text = Setting.Instance.WakeUpTime.ToString();
            PID.Text = Setting.Instance.PID;
            VID.Text = Setting.Instance.VID;

            MainLightPin.Text = Setting.Instance.MainLightpin.ToString();
            OfficeLightPin.Text = Setting.Instance.OfficeLightpin.ToString();
            ReadingLightPin.Text = Setting.Instance.ReadingLightpin.ToString();
            TVPin.Text = Setting.Instance.TVpin.ToString();
            OfficePin.Text = Setting.Instance.Officepin.ToString();
            Rpin.Text = Setting.Instance.Rpin.ToString();
            Gpin.Text = Setting.Instance.Gpin.ToString();
            Bpin.Text = Setting.Instance.Bpin.ToString();
            SensorPin.Text = Setting.Instance.SensorPin.ToString();


            if (Board.instance.IsConnencion() == true)
            {
                ConnectionStatus.Background = (SolidColorBrush)Resources["Green"];
            }

            else
            {
                ConnectionStatus.Background = (SolidColorBrush)Resources["Red"];
            }

            }
    }
}
