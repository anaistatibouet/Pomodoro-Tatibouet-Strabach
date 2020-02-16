using System.ComponentModel.DataAnnotations;

namespace Pomodoro.Model
{
    public class TagModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Name is too long.")]
        public string Name { get; set; }
    }
}