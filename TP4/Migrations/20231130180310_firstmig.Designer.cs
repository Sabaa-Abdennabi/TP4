﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Movie.Models;

#nullable disable

namespace TP4.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231130180310_firstmig")]
    partial class firstmig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CustomersMovies", b =>
                {
                    b.Property<int>("CustomersId")
                        .HasColumnType("int");

                    b.Property<int>("MoviesId")
                        .HasColumnType("int");

                    b.HasKey("CustomersId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("CustomersMovies");
                });

            modelBuilder.Entity("Movie.Models.Customers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("memebrshiptypesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("memebrshiptypesId");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("Movie.Models.Genres", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("GenreName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GenreName = "GenreFromJsonFile1"
                        },
                        new
                        {
                            Id = 2,
                            GenreName = "GenreFromJsonFile2"
                        });
                });

            modelBuilder.Entity("Movie.Models.memebrshiptypes", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<float>("DiscountRate")
                        .HasColumnType("real");

                    b.Property<int>("DurationMonth")
                        .HasColumnType("int");

                    b.Property<float>("SignUpFee")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.ToTable("memebrshiptypes");

                    b.HasData(
                        new
                        {
                            id = 1,
                            DiscountRate = 0f,
                            DurationMonth = 1,
                            SignUpFee = 50f
                        },
                        new
                        {
                            id = 2,
                            DiscountRate = 5f,
                            DurationMonth = 3,
                            SignUpFee = 100f
                        },
                        new
                        {
                            id = 3,
                            DiscountRate = 10f,
                            DurationMonth = 6,
                            SignUpFee = 150f
                        });
                });

            modelBuilder.Entity("Movie.Models.Movies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Genresid")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Genresid");

                    b.ToTable("movies");
                });

            modelBuilder.Entity("CustomersMovies", b =>
                {
                    b.HasOne("Movie.Models.Customers", null)
                        .WithMany()
                        .HasForeignKey("CustomersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Movie.Models.Movies", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Movie.Models.Customers", b =>
                {
                    b.HasOne("Movie.Models.memebrshiptypes", "memebrshiptypes")
                        .WithMany("Customers")
                        .HasForeignKey("memebrshiptypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("memebrshiptypes");
                });

            modelBuilder.Entity("Movie.Models.Movies", b =>
                {
                    b.HasOne("Movie.Models.Genres", "Genres")
                        .WithMany("Movies")
                        .HasForeignKey("Genresid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genres");
                });

            modelBuilder.Entity("Movie.Models.Genres", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("Movie.Models.memebrshiptypes", b =>
                {
                    b.Navigation("Customers");
                });
#pragma warning restore 612, 618
        }
    }
}
