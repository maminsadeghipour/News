using System;
using CWNews.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CWNews.Database
{
	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		public CategoryConfiguration()
		{
		}

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired();

            builder.Property(p => p.Title).IsRequired();


        }
    }
}

