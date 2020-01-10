using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace Pomodoro.Data
{
    public class Pomodoro
    {
        private Timer WorkTimer;
        private Stopwatch StopWatch;
        double WorkTimeInMilliseconds;

        public Pomodoro()
        {
            WorkTimeInMilliseconds = TimeSpan.FromMinutes(25).TotalMilliseconds;
            WorkTimer = new Timer(WorkTimeInMilliseconds);
            WorkTimer.Elapsed += Timer_Elapsed;
            StopWatch = new Stopwatch();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //CODE APPELE QUAND LE TEMPS EST ECOULE
        }

        public void StartTimer()
        {
            WorkTimer.Start();
            StopWatch.Start();
        }

        public void StopTimer()
        {
            WorkTimer.Stop();
            StopWatch.Stop();
        }

        public double TimeElapsed()
        {
            return WorkTimeInMilliseconds - StopWatch.ElapsedMilliseconds;
        }
    }
}
