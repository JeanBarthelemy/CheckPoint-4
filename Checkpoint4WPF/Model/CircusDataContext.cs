using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checkpoint4WPF
{
    public class CircusDataContext : DbContext
    {
        public virtual DbSet<Show> Show { get; set; }
        public virtual DbSet<Troupe> Troupe { get; set; }
        public virtual DbSet<Artist> Artist { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<ShowEvent> ShowEvent { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LOCALHOST\SQLEXPRESS;Database=Checkpoint4;Integrated Security=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          //  modelBuilder.Entity<Troupe>()
           // .HasOne(t => t.Show)
            //.WithMany();

            modelBuilder.Entity<ShowEvent>()
                .HasKey(se => new { se.ShowId, se.EventId });
            modelBuilder.Entity<ShowEvent>()
                .HasOne(se => se.Show)
                .WithMany(s => s.ManyShowEvents)
                .HasForeignKey(se => se.ShowId);
            modelBuilder.Entity<ShowEvent>()
                .HasOne(se => se.Event)
                .WithMany(e => e.ManyShowEvents)
                .HasForeignKey(se => se.EventId);

        }
    }

}

