using System;
using System.Diagnostics;
using System.Timers;

namespace Pomodoro.Data
{
    public class Pomodoro
    {
        private Timer TimerPomodoro;
        private Stopwatch StopWatch;
        private Session Session { get; set; }

        private double TimerPomodoroInMilliseconds;
        private int Position { get; set; }
        private bool InBreak { get; set; }

        /// <summary>
        ///   Initialisation du pomodoro : timer et chrono.
        /// </summary>
        public Pomodoro(int position, Session session)
        {
            this.Position = position;
            this.InBreak = false;
            this.Session = session; //Accès vers la session à laquelle il appartient.

            TimerPomodoroInMilliseconds = TimeSpan.FromMinutes(25).TotalMilliseconds;
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

        /// <summary>
        /// Retourne l'état de "InBreak" en nb entier : false = 0, true = 1
        /// </summary>
        /// <returns></returns>
        public bool GetBreakState()
        {
            return InBreak;
        }

        /// <summary>
        ///   Evènement appelé quand le temps est écoulé
        ///   Si l'état "InBreak" était à 'false', on le passe à true et on redémarre le pomodoro à 5 ou 15 min.
        ///   Si l'état "InBreak" était à 'true', on incrémente l'index de la séquence pour passer au pomodoro suivant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            StopPomodoro();
            ResetPomodoro();

            if (this.InBreak == false) //On redémarre avec la durée de la pause
            {
                this.InBreak = true;
                if (this.Position % 4 != 3) //Si le pomodoro est le 4ème, 8ème, 12ème, etc..., la pause est de 15min.
                {
                    TimerPomodoroInMilliseconds = TimeSpan.FromMinutes(5).TotalMilliseconds;
                }
                else
                {
                    TimerPomodoroInMilliseconds = TimeSpan.FromMinutes(15).TotalMilliseconds;
                }
                TimerPomodoro = new Timer(TimerPomodoroInMilliseconds);
                TimerPomodoro.Elapsed += Timer_Elapsed;
                StartPomodoro();
            }
            else //On réinitialise le pomodoro à 25 min sans le déclencher
            {
                this.InBreak = false;
                TimerPomodoroInMilliseconds = TimeSpan.FromMinutes(25).TotalMilliseconds;
                TimerPomodoro = new Timer(TimerPomodoroInMilliseconds);
                TimerPomodoro.Elapsed += Timer_Elapsed;
                StopPomodoro();
                this.Session.SwitchActivePomodoro(); // On change le pomodoro actif dans la session
            }
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