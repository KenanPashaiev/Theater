using Microsoft.EntityFrameworkCore;
using System;
using Theater.Models;

namespace Theater.DAL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=theater;Trusted_Connection=True;");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
