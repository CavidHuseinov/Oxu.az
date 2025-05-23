
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oxu.Domain.Entities;

namespace Oxu.Persistance.Configurations
{
    public class NewsTranslationConfiguration : IEntityTypeConfiguration<NewsTranslation>
    {
        public void Configure(EntityTypeBuilder<NewsTranslation> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.OwnsOne(x => x.CreatedAt, createdAtBuilder =>
            {
                createdAtBuilder.Property(x => x.Date)
                .HasColumnName("CreatedAt");
            });
            builder.Property(x => x.Content).IsRequired();
            builder.Property(x => x.Title).IsRequired();
        }
    }
}
