using System.Collections.Generic;

namespace Pomodoro.Data
{
    public class Session
    {
        private string Name { get; set; }
        public List<Countdown> Sequence = new List<Countdown>();
        public int ActivePomodoro { get; set; }

        public Session()
        {
            this.Sequence.Add(new Countdown(0, this));
        }

        /// <summary>
        /// Change le pomodoro actif pour le pomodoro suivant
        /// </summary>
        public void SwitchActivePomodoro()
        {
            if (this.ActivePomodoro < Sequence.Count -1)
            {
                this.ActivePomodoro += 1;
                Sequence[ActivePomodoro].StartPomodoro();
                //Todo : Démarrer le pomodoro suivant
            }
            else
            {
                this.ActivePomodoro = 0;
                //Stopper la session
            }
        }
    }
}