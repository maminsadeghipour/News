using System;
using CWNews.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CWNews.Database
{
	public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
		public AdminConfiguration()
		{
		}

        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.ToTable("Admins");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Username).IsRequired();

            builder.Property(p => p.Password).IsRequired();
        }
    }
}

