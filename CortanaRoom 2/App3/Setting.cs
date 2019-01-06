using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoRGB
{
    class Setting
    {

        private static Setting instance;


        private Windows.Storage.ApplicationDataContainer localsettings = Windows.Storage.ApplicationData.Current.LocalSettings;
        private Windows.Storage.ApplicationDataCompositeValue composite = new Windows.Storage.ApplicationDataCompositeValue();

        
        private bool sensortriggerd;

        public string VID
        {

            get
            {
                if (localsettings.Values["vid"] == null)
                {

                    localsettings.Values["vid"] = "VID_1A86";

                }

                return (string)localsettings.Values["vid"];

            }
            set
            {

                localsettings.Values["vid"] = value;



            }


        }



        public string PID
        {

            get
            {
                if (localsettings.Values["pid"] == null)
                {

                    localsettings.Values["pid"] = "PID_7523";

                }

                return (string)localsettings.Values["pid"];

            }
            set
            {

                localsettings.Values["pid"] = value;



            }


        }

        public string flashColor
        {

            get
            {
                if (localsettings.Values["flashcolor"] == null)
                {

                    localsettings.Values["flashcolor"] = "Blue";

                }

                return (string)localsettings.Values["flashcolor"];

            }
            set
            {

                localsettings.Values["flashcolor"] = value;



            }


        }

        public int fadeOneTime
        {

            get
            {
                if (localsettings.Values["fadeonetime"] == null)
                {

                    localsettings.Values["fadeonetime"] = 20;

                }

                return (int)localsettings.Values["fadeonetime"];

            }
            set
            {

                localsettings.Values["fadeonetime"] = value;



            }


        }

        public string fadeOneColor
        {

            get
            {
                if (localsettings.Values["fadeonecolor"] == null)
                {

                    localsettings.Values["fadeonecolor"] = "Red";

                }

                return (string)localsettings.Values["fadeonecolor"];

            }
            set
            {

                localsettings.Values["fadeonecolor"] = value;



            }


        }

        public int flashTime
        {

            get
            {
                if (localsettings.Values["flashtime"] == null)
                {

                    localsettings.Values["flashtime"] = 20;

                }

                return (int)localsettings.Values["flashtime"];

            }
            set
            {

                localsettings.Values["flashtime"] = value;



            }


        }

        public int fadeTime
        {

            get
            {
                if (localsettings.Values["fadetime"] == null)
                {

                    localsettings.Values["fadetime"] = 20;

                }

                return (int)localsettings.Values["fadetime"];

            }
            set
            {

                localsettings.Values["fadetime"] = value;



            }


        }


        /// <summary>
        /// Pins
        /// </summary>

        public int Rpin
        {
            get
            {
                if (localsettings.Values["rpin"] == null)
                {

                    localsettings.Values["rpin"] = 9;

                }
                return (int)localsettings.Values["rpin"];
            }
            set
            {
                localsettings.Values["rpin"] = value;
            }
        }

        public int Gpin
        {
            get
            {
                if (localsettings.Values["gpin"] == null)
                {

                    localsettings.Values["gpin"] = 10;

                }
                return (int)localsettings.Values["gpin"];
            }
            set
            {
                localsettings.Values["gpin"] = value;
            }
        }

        public int Bpin
        {
            get
            {
                if (localsettings.Values["bpin"] == null)
                {

                    localsettings.Values["bpin"] = 11;

                }
                return (int)localsettings.Values["bpin"];
            }
            set
            {
                localsettings.Values["bpin"] = value;
            }
        }

        public int MainLightpin
        {
            get
            {
                if (localsettings.Values["mainlightpin"] == null)
                {

                    localsettings.Values["mainlightpin"] = 3;

                }
                return (int)localsettings.Values["mainlightpin"];
            }
            set
            {
                localsettings.Values["mainlightpin"] = value;
            }
        }

        public int OfficeLightpin
        {
            get
            {
                if (localsettings.Values["officelightpin"] == null)
                {

                    localsettings.Values["officelightpin"] = 4;

                }
                return (int)localsettings.Values["officelightpin"];
            }
            set
            {
                localsettings.Values["officelightpin"] = value;
            }
        }

        public int ReadingLightpin
        {
            get
            {
                if (localsettings.Values["readinglightpin"] == null)
                {

                    localsettings.Values["readinglightpin"] = 5;

                }
                return (int)localsettings.Values["readinglightpin"];
            }
            set
            {
                localsettings.Values["readinglightpin"] = value;
            }
        }

        public int TVpin
        {
            get
            {
                if (localsettings.Values["tvpin"] == null)
                {

                    localsettings.Values["tvpin"] = 6;

                }
                return (int)localsettings.Values["tvpin"];
            }
            set
            {
                localsettings.Values["tvpin"] = value;
            }
        }

        public int Officepin
        {
            get
            {
                if (localsettings.Values["officepin"] == null)
                {

                    localsettings.Values["officepin"] = 7;

                }
                return (int)localsettings.Values["officepin"];
            }
            set
            {
                localsettings.Values["officepin"] = value;
            }
        }

        public string SensorPin
        {
            get
            {
                if (localsettings.Values["sensorpin"] == null)
                {

                    localsettings.Values["sensorpin"] = "A0";

                }
                return (string)localsettings.Values["sensorpin"];
            }
            set
            {
                localsettings.Values["sensorpin"] = value;
            }
        }

        /// <summary>
        /// Applcication variables
        /// </summary>

        public string LedColor
        {
            get
            {
                if (localsettings.Values["ledcolor"] == null)
                {

                    localsettings.Values["ledcolor"] = "Red";

                }
                return (string)localsettings.Values["ledcolor"];
            }
            set
            {
                localsettings.Values["ledcolor"] = value;
            }
        }

        /// <summary>
        /// On or Off status flags 
        /// </summary>

        public bool MainLightOn
        {
            get
            {
                if (localsettings.Values["mainlighton"] == null)
                {

                    localsettings.Values["mainlighton"] = false;

                }
                return (bool)localsettings.Values["mainlighton"];
            }
            set
            {
                localsettings.Values["mainlighton"] = value;
            }
        }

        public bool OfficeLightOn
        {
            get
            {
                if (localsettings.Values["officelighton"] == null)
                {

                    localsettings.Values["officelighton"] = false;

                }
                return (bool)localsettings.Values["officelighton"];
            }
            set
            {
                localsettings.Values["officelighton"] = value;
            }
        }

        public bool ReadingLightOn
        {
            get
            {
                if (localsettings.Values["readinglighton"] == null)
                {

                    localsettings.Values["readinglighton"] = false;

                }
                return (bool)localsettings.Values["readinglighton"];
            }
            set
            {
                localsettings.Values["readinglighton"] = value;
            }
        }

        public bool TVOn
        {
            get
            {
                if (localsettings.Values["tvon"] == null)
                {

                    localsettings.Values["tvon"] = false;

                }
                return (bool)localsettings.Values["tvon"];
            }
            set
            {
                localsettings.Values["tvon"] = value;
            }
        }

        public bool OfficeOn
        {
            get
            {
                if (localsettings.Values["officeon"] == null)
                {

                    localsettings.Values["officeon"] = false;

                }
                return (bool)localsettings.Values["officeon"];
            }
            set
            {
                localsettings.Values["officeon"] = value;
            }
        }

        public bool LEDOn
        {
            get
            {
                if (localsettings.Values["ledon"] == null)
                {

                    localsettings.Values["ledon"] = false;

                }
                return (bool)localsettings.Values["ledon"];
            }
            set
            {
                localsettings.Values["ledon"] = value;
            }
        }


        public bool FadeOneOn
        {
            get
            {
                if (localsettings.Values["fadeoneon"] == null)
                {

                    localsettings.Values["fadeoneon"] = false;

                }
                return (bool)localsettings.Values["fadeoneon"];
            }
            set
            {
                localsettings.Values["fadeoneon"] = value;
            }
        }

        public bool FlashOn
        {
            get
            {
                if (localsettings.Values["flashon"] == null)
                {

                    localsettings.Values["flashon"] = false;

                }
                return (bool)localsettings.Values["flashon"];
            }
            set
            {
                localsettings.Values["flashon"] = value;
            }
        }

        public bool FadeOn
        {
            get
            {
                if (localsettings.Values["fadeon"] == null)
                {

                    localsettings.Values["fadeon"] = false;

                }
                return (bool)localsettings.Values["fadeon"];
            }
            set
            {
                localsettings.Values["fadeon"] = value;
            }
        }

        public bool ReadSensorOn
        {
            get
            {
                if (localsettings.Values["readsensor"] == null)
                {

                    localsettings.Values["readsensor"] = true;

                }
                return (bool)localsettings.Values["readsensor"];
            }
            set
            {
                localsettings.Values["readsensor"] = value;
            }
        }


        public bool AlarmOn
        {
            get
            {
                if (localsettings.Values["alarmon"] == null)
                {

                    localsettings.Values["alarmon"] = false;

                }
                return (bool)localsettings.Values["alarmon"];
            }
            set
            {
                localsettings.Values["alarmon"] = value;
            }
        }

        public TimeSpan AlarmTime
        {
            get
            {
                if (localsettings.Values["alarmtime"] == null)
                {

                    localsettings.Values["alarmtime"] = TimeSpan.FromHours(0);

                }
                return (TimeSpan)localsettings.Values["alarmtime"];
            }
            set
            {
                localsettings.Values["alarmtime"] = value;
            }
        }

        public int WakeUpTime
        {
            get
            {
                if (localsettings.Values["wakeuptime"] == null)
                {

                    localsettings.Values["wakeuptime"] = 5;

                }
                return (int)localsettings.Values["wakeuptime"];
            }
            set
            {
                localsettings.Values["wakeuptime"] = value;
            }
        }


        public bool SensorTriggerd
        {
            get
            {
                return sensortriggerd;
            }
            set
            {
                sensortriggerd = value;
            }
        }

        /// <summary>
        /// UI update variables
        /// </summary>

        public static Setting Instance
        {

            get
            {
                if (instance ==  null)
                {
                    instance = new Setting();

                }
                return instance;
            }

        }

    }
}
