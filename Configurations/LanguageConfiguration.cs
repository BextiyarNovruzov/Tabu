using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tabu.Entites;

namespace Tabu.Configurations
{

    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(x => x.Code);
            builder.Property(x => x.Code).
            IsFixedLength(true).
            HasMaxLength(2);
            builder.HasIndex(x => x.Name).
            IsUnique();
            builder.Property(x => x.Name).
            IsRequired().
            HasMaxLength(32);
            builder.Property(x => x.Icon)
            .HasMaxLength(512);
        }
    }
}
