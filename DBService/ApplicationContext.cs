using DBService.Entitties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBService
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Page> Pages { get; set; }

        public ApplicationContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PHPLab2;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Page>().
                 HasOne(s => s.Parent).
                 WithMany().
                 HasForeignKey(s => s.ParentId);

            modelBuilder.Entity<Page>().
                 HasOne(s => s.Alias).
                 WithMany().
                 HasForeignKey(s => s.CustomAliasId);
        }
    }
}
