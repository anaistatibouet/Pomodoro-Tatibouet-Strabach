using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
