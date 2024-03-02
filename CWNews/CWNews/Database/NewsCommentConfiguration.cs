using System;
using CWNews.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CWNews.Database
{
	public class NewsCommentConfiguration : IEntityTypeConfiguration<NewsComment>
	{
		public NewsCommentConfiguration()
		{
		}

        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<NewsComment> builder)
        {
            builder.ToTable("NewsComments");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.AddTime).IsRequired();
            builder.Property(p => p.Description).IsRequired().HasMaxLength(300);
            builder.Property(p => p.IsAccepteByAdmin).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();

            builder.Property(p => p.NumberOfDislikes).IsRequired().HasDefaultValue(0);
            builder.Property(p => p.NumberOfLikes).IsRequired().HasDefaultValue(0);

            builder.Property(p => p.VisitorId).IsRequired();
            builder.Property(p => p.NewsId).IsRequired();

            builder.HasOne(p => p.Visitor)
                .WithMany(p => p.NewsComments)
                .HasForeignKey(p => p.VisitorId);

            builder.HasOne(p => p.News)
                .WithMany(p => p.Comments)
                .HasForeignKey(p => p.NewsId);

        }
    }
}

