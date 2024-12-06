﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PerformanceTrackingService.Data;

#nullable disable

namespace PerformanceTrackingService.Migrations
{
    [DbContext(typeof(PerformanceContext))]
    [Migration("20241202193944_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PerformanceTrackingService.Model.Performance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GamesPlayed")
                        .HasColumnType("int");

                    b.Property<int>("Losses")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("TotalScore")
                        .HasColumnType("int");

                    b.Property<int>("Wins")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Performances");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GamesPlayed = 0,
                            Losses = 0,
                            PlayerId = 1,
                            TotalScore = 0,
                            Wins = 0
                        },
                        new
                        {
                            Id = 2,
                            GamesPlayed = 0,
                            Losses = 0,
                            PlayerId = 2,
                            TotalScore = 0,
                            Wins = 0
                        },
                        new
                        {
                            Id = 3,
                            GamesPlayed = 0,
                            Losses = 0,
                            PlayerId = 3,
                            TotalScore = 0,
                            Wins = 0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}