using System;
using CWNews.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CWNews.Database
{
	public class JournalistConfiguration : IEntityTypeConfiguration<Journalist>
    {
		public JournalistConfiguration()
		{
		}

        public void Configure(EntityTypeBuilder<Journalist> builder)
        {
            builder.ToTable("Journalists");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).IsRequired();

            builder.Property(p => p.Username).IsRequired();

            builder.Property(p => p.Password).IsRequired();

            builder.Property(p => p.IsDeleted).IsRequired();

            builder.HasMany(p => p.News);
        }
    }
}

