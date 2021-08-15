using GameCatalogue.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameCatalogue.Infra.Data.EntitiesConfiguration
{
    public class PlatformConfiguration : IEntityTypeConfiguration<Platform>
    {
        public void Configure(EntityTypeBuilder<Platform> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();

            builder.HasData(
                new Platform(1, "Microsoft Windows"),
                new Platform(2, "Microsoft Xbox One"),
                new Platform(3, "PlayStation 4")
            );
        }
    }
}
