
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oxu.Domain.Entities;

namespace Oxu.Persistance.Configurations
{
    public class NewsAndTagConfiguration : IEntityTypeConfiguration<NewsAndTag>
    {
        public void Configure(EntityTypeBuilder<NewsAndTag> builder)
        {
            builder.HasKey(xy => new { xy.NewsId, xy.TagId });

            builder.HasOne(x => x.Tag)
                .WithMany()
                .HasForeignKey(x => x.TagId);

            builder.HasOne(x => x.News)
                .WithMany()
                .HasForeignKey(x => x.NewsId);
                
        }
    }
}
