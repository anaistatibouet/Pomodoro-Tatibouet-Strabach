using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace Pomodoro.Data
{
    public class Pomodoro
    {
        private Timer TimerPomodoro;
        private Stopwatch StopWatch;
        private double TimerPomodoroInMilliseconds;

        public Pomodoro()
        {
            TimerPomodoroInMilliseconds = TimeSpan.FromMinutes(25).TotalMilliseconds;
            TimerPomodoro = new Timer(TimerPomodoroInMilliseconds);
            TimerPomodoro.Elapsed += Timer_Elapsed;
            StopWatch = new Stopwatch();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //CODE APPELE QUAND LE TEMPS EST ECOULE
        }

        public void StartPomodoro()
        {
            TimerPomodoro.Start();
            StopWatch.Start();
        }

        public void StopPomodoro()
        {
            TimerPomodoro.Stop();
            StopWatch.Stop();
        }

        public void ResetPomodoro()
        {
            StopWatch.Reset();
        }

        public double TimeElapsed()
        {
            return TimerPomodoroInMilliseconds - StopWatch.ElapsedMilliseconds;
        }
    }
}
