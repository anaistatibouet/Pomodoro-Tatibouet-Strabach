using System;
using System.Diagnostics;
using System.Timers;

namespace Pomodoro.Data
{
    public class Pomodoro
    {
        private Timer TimerPomodoro;
        private Stopwatch StopWatch;
        private double TimerPomodoroInMilliseconds;
        private int TabIndexSeq = 0;
        private int[] Sequence = new int[] { 25 , 5, 25, 5, 25, 5, 25, 15 };

        /// <summary>
        ///   Initialisation du pomodoro : timer et chrono. 
        ///   L'index de la séquence débute à 0
        /// </summary>
        public Pomodoro()
        {
            TimerPomodoroInMilliseconds = TimeSpan.FromMinutes(Sequence[TabIndexSeq]).TotalMilliseconds;
            TimerPomodoro = new Timer(TimerPomodoroInMilliseconds);
            TimerPomodoro.Elapsed += Timer_Elapsed;
            StopWatch = new Stopwatch();
        }

        /// <summary>
        ///   Permet de démarrer le pomodoro 
        /// </summary>
        public void StartPomodoro()
        {
            TimerPomodoro.Start();
            StopWatch.Start();
        }

        /// <summary>
        ///   Permet de mettre en pause le pomodoro
        /// </summary>
        public void StopPomodoro()
        {
            TimerPomodoro.Stop();
            StopWatch.Stop();
        }

        /// <summary>
        ///   Permet de remettre le pomodoro à son état initial
        /// </summary>
        public void ResetPomodoro()
        {
            StopWatch.Reset();
        }

        public int getIndexTabSeq()
        {
            return TabIndexSeq;
        }

        /// <summary>
        ///   Evènement appelé quand le temps est écoulé
        ///   On incrémente l'index de la séquence pour passer au pomodoro suivant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            StopPomodoro();
            ResetPomodoro();

            if(TabIndexSeq < 8)
            {
                TabIndexSeq++;
            } else
            {
                TabIndexSeq = 0;
            }
            
            TimerPomodoroInMilliseconds = TimeSpan.FromMinutes(Sequence[TabIndexSeq]).TotalMilliseconds;
            TimerPomodoro = new Timer(TimerPomodoroInMilliseconds);
            StartPomodoro();
        }

        /// <summary>
        ///   Calcul du temps écoulé
        /// </summary>
        /// <returns>
        ///   Temps écoulé en milliseconds
        /// </returns>
        public double TimeElapsed()
        {
            return TimerPomodoroInMilliseconds - StopWatch.ElapsedMilliseconds;
        }
    }
}
