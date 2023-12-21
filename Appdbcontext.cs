using System;
using Microsoft.EntityFrameworkCore;
using LoginSign.Models;

namespace LoginSign.Data
{
	public class Appdbcontext:DbContext
	{
        
        public Appdbcontext(DbContextOptions<Appdbcontext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}
