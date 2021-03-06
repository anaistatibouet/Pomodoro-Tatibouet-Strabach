﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Pomodoro_api.Data
{
    public class PomodoroApiContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public PomodoroApiContext() : base("name=PomodoroApiContext")
        {
        }

        public System.Data.Entity.DbSet<Pomodoro_api.Models.Session> Sessions { get; set; }

        public System.Data.Entity.DbSet<Pomodoro_api.Models.Pomodoro> Pomodoroes { get; set; }

        public System.Data.Entity.DbSet<Pomodoro_api.Models.Tag> Tags { get; set; }

        public System.Data.Entity.DbSet<Pomodoro_api.Models.History> Histories { get; set; }
    }
}
