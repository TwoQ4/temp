using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WpfApp2.model;

namespace WpfApp2
{
    class MyDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }

        public MyDbContext() {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=.\SQLEXPRESS;Database=library;Trusted_Connection=true;");
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<User>()
                .ToTable("usr").HasKey(p => p.Id);
            builder.Entity<User>()
               .Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Entity<Book>()
                .ToTable("book").HasKey(p => p.Id);
            builder.Entity<Book>()
                .Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Entity<Book>()
                .Property(p => p.UserId).HasColumnName("usr_id");
            builder.Entity<Book>()
                .HasOne<User>(u => u.User)
                .WithMany(b => b.Books)
                .HasForeignKey(b=>b.UserId);

            builder.Entity<Ticket>()
                .ToTable("ticket").HasKey(p => p.Id);
            builder.Entity<Ticket>()
                .Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Entity<Ticket>()
                .Property(p => p.UserId).HasColumnName("usr_id");
            builder.Entity<Ticket>()
                .HasOne<User>(u => u.User)
                .WithOne(t => t.Ticket)
                .HasForeignKey<Ticket>(p => p.UserId);

        }

        public int SaveChanges<TEntity>() where TEntity : class
        {
            var original = this.ChangeTracker.Entries()
                        .Where(x => !typeof(TEntity).IsAssignableFrom(x.Entity.GetType()) && x.State != EntityState.Unchanged)
                        .GroupBy(x => x.State)
                        .ToList();


            foreach (var entry in this.ChangeTracker.Entries().Where(x => !typeof(TEntity).IsAssignableFrom(x.Entity.GetType())))
            {
                entry.State = EntityState.Unchanged;
            }

            var rows = base.SaveChanges();

            foreach (var state in original)
            {
                foreach (var entry in state)
                {
                    entry.State = state.Key;
                }
            }

            return rows;
        }
    }
}
