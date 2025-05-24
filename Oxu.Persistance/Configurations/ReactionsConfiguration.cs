
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oxu.Domain.Entities;

namespace Oxu.Persistance.Configurations
{
    public class ReactionsConfiguration : IEntityTypeConfiguration<Reactions>
    {
        public void Configure(EntityTypeBuilder<Reactions> builder)
        {
            builder.Property(x=>x.Id).ValueGeneratedOnAdd();
            builder.OwnsOne(x => x.CreatedAt, createdAtBuilder =>
            {
                createdAtBuilder.Property(x => x.Date)
                .HasColumnName("CreatedAt");
            });
            builder.HasOne(x=>x.News)
                .WithMany(x=>x.Reactions)
                .HasForeignKey(x=>x.NewsId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
