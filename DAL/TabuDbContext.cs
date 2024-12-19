using Microsoft.EntityFrameworkCore;
using Tabu.Entites;

namespace Tabu.DAL
{
    public class TabuDbContext : DbContext
    {
        public TabuDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Language> Languages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>(l =>
            {
                l.HasKey(x => x.Code);
                l.Property(x=>x.Code)
                .IsFixedLength(true)
                .HasMaxLength(2);
                l.HasIndex(x => x.Name)
                .IsUnique();
                l.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(32);
                l.Property(x=>x.Icon)
                .HasMaxLength(512);
                l.HasData(new Language
                {
                    Code = "Az",
                    Name = "Azerbaycanca",
                    Icon = "https://www.google.com/imgres?q=Azerbaijani%20flag&imgurl=https%3A%2F%2Fupload.wikimedia.org%2Fwikipedia%2Fcommons%2Fthumb%2Fd%2Fdd%2FFlag_of_Azerbaijan.svg%2F1200px-Flag_of_Azerbaijan.svg.png&imgrefurl=https%3A%2F%2Fen.wikipedia.org%2Fwiki%2FFlag_of_Azerbaijan&docid=mVnN4VXAhdmFoM&tbnid=i-LWaprbfLW65M&vet=12ahUKEwjQuuOfzbSKAxVmFhAIHYFrJY0QM3oECBUQAA..i&w=1200&h=600&hcb=2&ved=2ahUKEwjQuuOfzbSKAxVmFhAIHYFrJY0QM3oECBUQAA"

                });

            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
