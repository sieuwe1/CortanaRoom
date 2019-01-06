using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoRGB
{
    class Sensor 
    {
        public Sensor()
        {

            ReadSensor();

        }

        public Task ReadSensor()
        {

            var state = 0;

            return Task.Run(async () =>
            {
                while (Setting.Instance.ReadSensorOn == true)
                {
                    Debug.WriteLine(Board.Instance.ReadSensor(Setting.Instance.SensorPin));

                    if (Board.Instance.ReadSensor(Setting.Instance.SensorPin) >= 600 && state == 0)
                    {
                        Board.Instance.WriteSmoothColor(255, 255, 255);
                        state = 1;
                    }

                    if (Board.Instance.ReadSensor(Setting.Instance.SensorPin) < 600 && state == 1)
                    {
                        //wait 30 seconds to check if still nobody is in the room to prevent false triggers
                        await Board.Instance.Delay(30000);

                        if (Board.Instance.ReadSensor(Setting.Instance.SensorPin) < 600)
                        {
                            Board.Instance.AllOff();
                            state = 0;
                        }
                    }
                    await Board.Instance.Delay(500);
                }
            });
        }
    }
}