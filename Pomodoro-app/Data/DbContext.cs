using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Pomodoro.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("dbConnect")
        {

        }

        public DbSet<Pomodoro> Pomodoros { get; set; }
        public DbSet<Session> Sessions { get; set; }

    }
}
