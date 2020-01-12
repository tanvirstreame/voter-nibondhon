using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
// using Projectile.Models

namespace projectile.Contex {
    public class BloggingContext : DbContext
        {
            public DbSet<Person> Person { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder options)
                => options.UseSqlite("Data Source=nid.db");
        }


}

