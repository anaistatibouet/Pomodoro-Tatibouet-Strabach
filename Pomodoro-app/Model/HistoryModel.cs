using System;
using System.ComponentModel.DataAnnotations;

namespace Pomodoro.Model
{
    public class HistoryModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int TagId { get; set; }

        public TagModel Tag { get; set; }
    }
}