using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pomodoro.Data
{

    [Table("pomodoro")]
    public class Pomodoro
    {
        [Column("ID")]
        [Key]
        public int ID { get; set; }
        [Column("Tag")]
        [Required]
        private int Tag { get; set; }
        //Le tag d'un pomodoro sera une clée étrangère vers une table "tag"
        public virtual Session Session { get; set; }
    }
}
