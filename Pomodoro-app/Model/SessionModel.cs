using System;
using System.ComponentModel.DataAnnotations;

namespace Pomodoro.Model
{
    public class SessionModel
    {
        [Required]
        [StringLength(20, ErrorMessage = "Name is too long.")]
        public string Name { get; set; }

        [Required]
        [Range(1, 16, ErrorMessage = "Choose a number between 0 and 16")]
        public int NbPomodoros { get; set; }
    }
}