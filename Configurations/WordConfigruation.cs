using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tabu.Entites;

namespace Tabu.Configurations
{

    public class WordConfigruation : IEntityTypeConfiguration<Word>
    {
        public void Configure(EntityTypeBuilder<Word> builder)
        {
            builder.Property(x => x.Text)
                   .IsRequired()
                   .HasMaxLength(32);
            builder.HasOne(x => x.Language)
            .WithMany(x => x.Words)
            .HasForeignKey(x => x.LanguageCode);
            builder.HasMany(x => x.BannedWords)
            .WithOne(x => x.Words)
            .HasForeignKey(x => x.WordId);
        }
    }
}
