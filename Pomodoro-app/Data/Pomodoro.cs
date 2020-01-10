using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace Pomodoro.Data
{
    public class Countdown
    {
        private Timer Timer;
        private Stopwatch StopWatch;

        public Countdown()
        {
            Timer = new Timer(TimeSpan.FromMinutes(3).TotalMilliseconds);
            Timer.Elapsed += Timer_Elapsed;
            StopWatch = new Stopwatch();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //CODE APPELE QUAND LE TEMPS EST ECOULE
        }

        public void StartTimer()
        {
            Timer.Start();
            StopWatch.Start();
        }

        // StopWtch.Elapsed => temps écoulé depuis le stopWatch.start

        public void StopTimer()
        {
            Timer.Stop();
        }

        public double TimeElapsed()
        {
            return 3 - TimeSpan.FromMilliseconds(StopWatch.ElapsedMilliseconds).TotalMinutes;
        }

    }
}
