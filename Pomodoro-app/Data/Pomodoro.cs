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
            // Initialisation du pomodoro : timer et chrono 
            TimerPomodoroInMilliseconds = TimeSpan.FromMinutes(25).TotalMilliseconds;
            TimerPomodoro = new Timer(TimerPomodoroInMilliseconds);
            TimerPomodoro.Elapsed += Timer_Elapsed;
            StopWatch = new Stopwatch();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //CODE APPELE QUAND LE TEMPS EST ECOULE
        }

        /// <summary>
        /// Permet de démarrer le pomodoro 
        /// </summary>
        public void StartPomodoro()
        {
            TimerPomodoro.Start();
            StopWatch.Start();
        }

        /// <summary>
        /// Permet de mettre en pause le pomodoro
        /// </summary>
        public void StopPomodoro()
        {
            TimerPomodoro.Stop();
            StopWatch.Stop();
        }

        /// <summary>
        /// Permet de remettre le pomodoro à son état initial
        /// </summary>
        public void ResetPomodoro()
        {
            StopWatch.Reset();
        }
        
        /// <summary>
        /// Calcul du temps écoulé
        /// </summary>
        /// <returns>Temps écoulé en milliseconds</returns>
        public double TimeElapsed()
        {
            return TimerPomodoroInMilliseconds - StopWatch.ElapsedMilliseconds;
        }
    }
}
