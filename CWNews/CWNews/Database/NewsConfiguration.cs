using System;
using Microsoft.EntityFrameworkCore;
using CWNews.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CWNews.Database
{
	public class NewsConfiguration : IEntityTypeConfiguration<News>
	{
		public NewsConfiguration()
		{
		}

        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.ToTable("News");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).IsRequired();

            builder.Property(p => p.Title).IsRequired();

            builder.Property(p => p.Description).IsRequired();

            builder.Property(p => p.AddTime).IsRequired();

            builder.Property(p => p.IsDeleted).IsRequired();

            builder.Property(p => p.NumberOfViews).IsRequired();

            builder.Property(p => p.IsAcceptedByAdmin).IsRequired();

            builder.Property(p => p.JornalistId).IsRequired();

            builder.Property(p => p.CategoryId).IsRequired();

            builder.HasOne(p => p.Category)
                .WithMany(p => p.News)
                .HasForeignKey(p => p.CategoryId);

            builder.HasOne(p => p.Journalist)
                .WithMany(p => p.News)
                .HasForeignKey(p => p.JornalistId);

            builder.HasMany(p => p.Comments)
                .WithOne(p => p.News)
                .HasForeignKey(p=>p.NewsId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}

