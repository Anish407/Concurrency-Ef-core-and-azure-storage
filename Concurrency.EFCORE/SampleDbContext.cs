using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace Concurrency.EFCORE
{
    public class SampleDbContext : DbContext
    {
        public DbSet<Students> Student { get; set; }

        public SampleDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Students>().HasData(new Students { Name = "Anish", Address = "mvlk", Age = 31, Id = 1 });

            //modelBuilder.Entity<Students>().Property(p => p.RowVersion).IsConcurrencyToken();

            base.OnModelCreating(modelBuilder);
        }
    }

    public class Students
    {
        public int Id { get; set; }


        public string Name { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        [Timestamp] //use if not using fluent apis
        public byte[] RowVersion { get; set; }
    }
}
