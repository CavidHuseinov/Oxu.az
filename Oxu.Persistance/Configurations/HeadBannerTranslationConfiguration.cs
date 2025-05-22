
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oxu.Domain.Entities;

namespace Oxu.Persistance.Configurations
{
    public class HeadBannerTranslationConfiguration : IEntityTypeConfiguration<HeadBannerTranslation>
    {
        public void Configure(EntityTypeBuilder<HeadBannerTranslation> builder)
        {
            builder.Property(x=>x.Id).ValueGeneratedOnAdd();

            builder.OwnsOne(x => x.CreatedAt, createdAtBuilder =>
            {
                createdAtBuilder.Property(x => x.Date)
                .HasColumnName("CreatedAt");
            });
            builder.Property(x => x.Content).IsRequired();
        }
    }
}
