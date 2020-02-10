using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pomodoro_api.Models
{
    public class Pomodoro
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Position { get; set; }


        [Required]
        public int SessionId { get; set; }

        public Session Session { get; set; }


        public int? TagId { get; set; }

        public Tag Tag { get; set; }
    }
}