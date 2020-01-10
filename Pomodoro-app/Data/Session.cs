using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pomodoro.Data
{
    [Table("session")]
    public class Session
    {
        [Column("ID")]
        [Key]
        public int ID { get; set; }

        public virtual ICollection<Pomodoro> Pomodoros { get; set; }
    }
}
