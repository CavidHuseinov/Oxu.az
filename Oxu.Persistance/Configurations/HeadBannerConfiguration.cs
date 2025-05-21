
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oxu.Domain.Entities;

namespace Oxu.Presentation.Configurations
{
    public class HeadBannerConfiguration : IEntityTypeConfiguration<HeadBanner>
    {
        public void Configure(EntityTypeBuilder<HeadBanner> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.OwnsOne(x => x.CreatedAt, createdAtBuilder =>
            {
                createdAtBuilder.Property(x => x.Date)
                .HasColumnName("CreatedAt");
            });

            builder.Property(x=>x.Content).IsRequired();
        }
    }
}
