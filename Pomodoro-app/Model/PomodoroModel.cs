using System.ComponentModel.DataAnnotations;

namespace Pomodoro.Model
{
    public class PomodoroModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int Position { get; set; }

        [Required]
        public int SessionId { get; set; }

        public SessionModel Session { get; set; }

        public int? TagId { get; set; }

        public TagModel Tag { get; set; }
    }
}