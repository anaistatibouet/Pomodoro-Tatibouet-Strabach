using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pomodoro.Data
{
    public class Session
    {
        private string Name { get; set; }
        public List<Pomodoro> Sequence = new List<Pomodoro>();
        public int ActivePomodoro { get; set; }

        public Session(int nbPomodoro)
        {
            this.InitSession(nbPomodoro);
        }
        
        /// <summary>
        /// Initialisation de la session.
        /// Ajoute autant de pomodoro dans le tableau des Pomodoros, que le nombre passé en paramètre.
        /// </summary>
        /// <param name="nbPomodoro"></param>
        public void InitSession(int nbPomodoro)
        {
            for(int i = 0; i < nbPomodoro; i++)
            {
                this.Sequence.Insert(i, new Pomodoro(i, this));
                this.ActivePomodoro = 0;
            }
        }

        /// <summary>
        /// Change le pomodoro actif pour le pomodoro suivant
        /// </summary>
        public void SwitchActivePomodoro()
        {
            if (this.ActivePomodoro < Sequence.Count)
            {
                this.ActivePomodoro += 1;
                Sequence[ActivePomodoro].StartPomodoro();
                //Todo : Démarrer le pomodoro suivant
            } else
            {
                this.ActivePomodoro = 0;
                //Stopper la session
            }
            
        }
    }
}
