using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace Pomodoro.Data
{
    public class Countdown
    {
        private Timer Timer;

        public Countdown()
        {
            Timer = new Timer(TimeSpan.FromMinutes(25).TotalMilliseconds);
        }

        public void StartTimer()
        {
            Timer.Start();
        }

        public void StopTimer()
        {
            Timer.Stop();
        }

    }
}
