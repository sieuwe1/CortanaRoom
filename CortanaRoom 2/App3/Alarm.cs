using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoRGB
{
    class Alarm 
    {

        
       private Timer timer;

       public void SetUpTimer()
        {
            var uren = Setting.Instance.AlarmTime.Hours;
            var min = Setting.Instance.AlarmTime.Minutes;

            DateTime now = DateTime.Now;

            DateTime alarm = new DateTime(now.Year, now.Month, now.Day, uren, min, 0);


            if (DateTime.Compare(now, alarm) == 1)
            {
                alarm = alarm.AddDays(1);
            }

            alarm = alarm.Subtract(new TimeSpan(0, Setting.Instance.WakeUpTime, 0));

            TimeSpan diffrence = alarm.Subtract(now);
            this.timer = new Timer(x =>
            {
                RiseSun();
                timer.Dispose();
                Setting.Instance.AlarmOn = false;

            }, null, diffrence, Timeout.InfiniteTimeSpan);
            
            System.Diagnostics.Debug.WriteLine(diffrence.ToString());
            
        }

        public void stopAlarm()
        {
            if (timer != null)
            {
                timer.Dispose();
            }
        }

        private async void RiseSun()
        {
            var green = 0;
            var delay = (Setting.Instance.WakeUpTime * 60000) / 25;

            for (int red = 0; red < 255; red++)
            {
                if (green < 100 && red > 10)
                {
                    green++;
                    red++;
                }

                Board.Instance.WriteColor(red, green, 0);
                await Board.Instance.Delay(delay);

            }
        }
    }
}



