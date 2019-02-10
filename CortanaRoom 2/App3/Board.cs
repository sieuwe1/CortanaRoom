﻿using Microsoft.Maker.RemoteWiring;
using Microsoft.Maker.Serial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace CoRGB
{
    class Board
    {
        public static Board instance;

        private RemoteDevice arduino;
        private UsbSerial usb;

        public static Board Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new Board();

                }
                return instance;
            }

        }


        public void connect()
        {
            String VID = Setting.Instance.VID;
            String PID = Setting.Instance.PID;

            if (VID != null && PID != null && !IsConnencion())
            {
                
                    usb = new UsbSerial(VID, PID);
                    arduino = new RemoteDevice(usb);
                    usb.begin(57600, SerialConfig.SERIAL_8N1);

                if (arduino == null)
                {
                    var box = new MessageDialog("No Arduino Connected or wrong PID and VID. Please check settings");
                    box.ShowAsync();
                }

                }
            }

        

        public void Disconnect()
        {
            arduino.Dispose();
            usb.end();
        }

        public void ChangePinState(int pin, int state)
        {

            if (state == 1)
            {
                arduino.digitalWrite(Convert.ToByte(pin), PinState.HIGH);
            }

            else {
                arduino.digitalWrite(Convert.ToByte(pin), PinState.LOW);
            }

        }



        public async void WriteSmoothColor(int R, int G, int B)
        {
            for (int x =0; x < R; x++)
            {
                    arduino.analogWrite(Convert.ToByte(Setting.Instance.Rpin), (ushort)x);
                    await Delay(10);
            }
            for (int x=0; x < G; x++)
            {
                    arduino.analogWrite(Convert.ToByte(Setting.Instance.Gpin), (ushort)x);
                    await Delay(10);
            }
            for (int x = 0; x < B; x++)
            {
                    arduino.analogWrite(Convert.ToByte(Setting.Instance.Bpin), (ushort)x);
                    await Delay(10);
            }
        }

        public void WriteColor(int R, int G, int B) 
        {
            arduino.analogWrite(Convert.ToByte(Setting.Instance.Rpin), (ushort)R);
            arduino.analogWrite(Convert.ToByte(Setting.Instance.Gpin), (ushort)G);
            arduino.analogWrite(Convert.ToByte(Setting.Instance.Bpin), (ushort)B);
        }

        public ushort ReadSensor(string pin)
        {

            return arduino.analogRead(pin);

        }

        public void AllOff()
        {
            /*
            for(int x = 1; x < 13; x++)
            {
                ChangePinState(x, 0);
            }
            */
                ChangePinState(Setting.Instance.MainLightpin, 1);
                ChangePinState(Setting.Instance.ReadingLightpin, 1);
                ChangePinState(Setting.Instance.OfficeLightpin, 0);
                ChangePinState(Setting.Instance.TVpin, 1);
                ChangePinState(Setting.Instance.Officepin,0);
                WriteColor(0, 0, 0);

            Setting.Instance.MainLightOn = false;
            Setting.Instance.ReadingLightOn = false;
            Setting.Instance.OfficeLightOn = false;
            Setting.Instance.OfficeOn = false;
            Setting.Instance.TVOn = false;
            Setting.Instance.LEDOn = false;
            Setting.Instance.FlashOn = false;
            Setting.Instance.FadeOn = false;
            Setting.Instance.FadeOneOn = false;
            Setting.Instance.LedColor = "blank";

            //voeg alles aan functie toe met ui updator

        }

        public void AllOn()
        {
            /*
            for(int x = 1; x < 13; x++)
            {
                ChangePinState(x, 0);
            }
            */
            ChangePinState(Setting.Instance.MainLightpin, 0);
            ChangePinState(Setting.Instance.ReadingLightpin, 0);
            ChangePinState(Setting.Instance.OfficeLightpin, 1);
            ChangePinState(Setting.Instance.TVpin, 0);
            ChangePinState(Setting.Instance.Officepin, 1);
            

            Setting.Instance.MainLightOn = true;
            Setting.Instance.ReadingLightOn = true;
            Setting.Instance.OfficeLightOn = true;
            Setting.Instance.OfficeOn = true;
            Setting.Instance.TVOn = true;
            Setting.Instance.LEDOn = true;
            Setting.Instance.FlashOn = true;
            Setting.Instance.FadeOn = true;
            Setting.Instance.FadeOneOn = true;
            Setting.Instance.LedColor = "White";
            WriteSmoothColor(255, 255, 255);

            //voeg alles aan functie toe met ui updator

        }


        public async Task Delay(int DelayTime)
        {

            await Task.Delay(DelayTime);

        }

        public bool IsConnencion()
        {
            if(arduino == null)
            {
                return false;
            }

            else
            {
                return true;
            }
        }

    }
}
