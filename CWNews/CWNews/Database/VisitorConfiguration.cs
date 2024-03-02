using System;
using CWNews.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CWNews.Database
{
	public class VisitorConfiguration : IEntityTypeConfiguration<Visitor>
    {
		public VisitorConfiguration()
		{
		}

        public void Configure(EntityTypeBuilder<Visitor> builder)
        {
            builder.ToTable("Visitors");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Username).IsRequired();
            builder.Property(p => p.Password).IsRequired();

            builder.HasMany(p => p.NewsComments);
        }
    }
}

