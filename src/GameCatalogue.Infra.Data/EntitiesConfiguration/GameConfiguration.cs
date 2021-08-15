using GameCatalogue.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameCatalogue.Infra.Data.EntitiesConfiguration
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Producer).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Gender).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Quantity).IsRequired();

            builder.HasOne(e => e.Platform).WithMany(e => e.Games).HasForeignKey(e => e.PlatformId);
        }
    }
}
