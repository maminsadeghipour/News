using System;
using CWNews.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CWNews.Database
{
	public class AppDbContext : DbContext
	{
		public AppDbContext()
		{
		}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=127.0.0.1,1433;Initial Catalog=CWNews;User ID=sa;Password=user@2023;TrustServerCertificate=True;Encrypt=True");
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new JournalistConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new NewsConfiguration());
            modelBuilder.ApplyConfiguration(new AdminConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<News> News { get; set; }

        public DbSet<Journalist> Journalists { get; set; }

        public DbSet<Admin> Admins { get; set; }

  
    }


}

