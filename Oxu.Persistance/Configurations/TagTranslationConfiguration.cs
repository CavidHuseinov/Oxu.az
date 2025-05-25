
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oxu.Domain.Entities;

namespace Oxu.Persistance.Configurations
{
    public class TagTranslationConfiguration : IEntityTypeConfiguration<TagTranslation>
    {
        public void Configure(EntityTypeBuilder<TagTranslation> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.OwnsOne(x => x.CreatedAt, createdAtBuilder =>
            {
                createdAtBuilder.Property(x => x.Date)
                .HasColumnName("CreatedAt");
            });
            builder.Property(x=>x.Name).IsRequired();
        }
    }
}
