using Microsoft.EntityFrameworkCore;
using People.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Text;

namespace People.DataAccess.DataContext
{
    public class MyDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Student>().HasIndex(e => e.Name).IsUnique().IsClustered();
        }
    }
}
