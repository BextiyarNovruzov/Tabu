﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tabu.DAL;

#nullable disable

namespace Tabu.Migrations
{
    [DbContext(typeof(TabuDbContext))]
    [Migration("20241219200917_SeedDataForLanguage")]
    partial class SeedDataForLanguage
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tabu.Entites.Language", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(2)
                        .HasColumnType("nchar(2)")
                        .IsFixedLength();

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Code");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            Code = "Az",
                            Icon = "https://www.google.com/imgres?q=Azerbaijani%20flag&imgurl=https%3A%2F%2Fupload.wikimedia.org%2Fwikipedia%2Fcommons%2Fthumb%2Fd%2Fdd%2FFlag_of_Azerbaijan.svg%2F1200px-Flag_of_Azerbaijan.svg.png&imgrefurl=https%3A%2F%2Fen.wikipedia.org%2Fwiki%2FFlag_of_Azerbaijan&docid=mVnN4VXAhdmFoM&tbnid=i-LWaprbfLW65M&vet=12ahUKEwjQuuOfzbSKAxVmFhAIHYFrJY0QM3oECBUQAA..i&w=1200&h=600&hcb=2&ved=2ahUKEwjQuuOfzbSKAxVmFhAIHYFrJY0QM3oECBUQAA",
                            Name = "Azerbaycanca"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}