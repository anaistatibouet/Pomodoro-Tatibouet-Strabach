using System.ComponentModel.DataAnnotations;

namespace Pomodoro_api.Models
{
    public class Session
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}