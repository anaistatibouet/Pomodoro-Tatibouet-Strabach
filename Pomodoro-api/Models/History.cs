
using System;
using System.ComponentModel.DataAnnotations;

namespace Pomodoro_api.Models
{
    public class History
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int TagId { get; set; }

        public Tag Tag { get; set; }
    }
}