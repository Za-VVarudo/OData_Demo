﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OData_Demo.Models;

#nullable disable

namespace OData_Demo.Migrations
{
    [DbContext(typeof(MovieCollectionContext))]
    partial class MovieCollectionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OData_Demo.Models.ActedIn", b =>
                {
                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("movie_id");

                    b.Property<Guid>("ActorId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("actor_id");

                    b.HasKey("MovieId", "ActorId");

                    b.ToTable("ActedIn", (string)null);
                });

            modelBuilder.Entity("OData_Demo.Models.Actor", b =>
                {
                    b.Property<Guid>("ActorId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("actor_id");

                    b.Property<string>("ActorName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("actor_name");

                    b.Property<byte>("Age")
                        .HasColumnType("tinyint")
                        .HasColumnName("age");

                    b.Property<decimal>("AverageMovieSalary")
                        .HasColumnType("money")
                        .HasColumnName("average_movie_salary");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nationality");

                    b.HasKey("ActorId");

                    b.ToTable("Actor", (string)null);
                });

            modelBuilder.Entity("OData_Demo.Models.Genre", b =>
                {
                    b.Property<byte>("GenreId")
                        .HasColumnType("tinyint")
                        .HasColumnName("genre_id");

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("genre_name");

                    b.HasKey("GenreId");

                    b.ToTable("Genre", (string)null);
                });

            modelBuilder.Entity("OData_Demo.Models.Movie", b =>
                {
                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("movie_id");

                    b.Property<decimal>("AmountOfMoney")
                        .HasColumnType("money")
                        .HasColumnName("amount_of_money");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("comment");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("director");

                    b.Property<int>("Duration")
                        .HasColumnType("int")
                        .HasColumnName("duration");

                    b.Property<byte>("GenreId")
                        .HasColumnType("tinyint")
                        .HasColumnName("genre");

                    b.Property<string>("ImageLink")
                        .HasMaxLength(300)
                        .IsUnicode(false)
                        .HasColumnType("varchar(300)");

                    b.Property<string>("MovieName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("movie_name");

                    b.HasKey("MovieId");

                    b.HasIndex("GenreId");

                    b.HasIndex(new[] { "ImageLink" }, "UQ__Movie__CF729F9A323CC2F7")
                        .IsUnique()
                        .HasFilter("[ImageLink] IS NOT NULL");

                    b.ToTable("Movie", (string)null);
                });

            modelBuilder.Entity("OData_Demo.Models.ActedIn", b =>
                {
                    b.HasOne("OData_Demo.Models.Actor", "Actor")
                        .WithMany("ActedIns")
                        .HasForeignKey("MovieId")
                        .IsRequired()
                        .HasConstraintName("FK__ActedIn__actor_i__2A4B4B5E");

                    b.HasOne("OData_Demo.Models.Movie", "Movie")
                        .WithMany("ActedIns")
                        .HasForeignKey("MovieId")
                        .IsRequired()
                        .HasConstraintName("FK__ActedIn__movie_i__2B3F6F97");

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("OData_Demo.Models.Movie", b =>
                {
                    b.HasOne("OData_Demo.Models.Genre", "Genre")
                        .WithMany("Movies")
                        .HasForeignKey("GenreId")
                        .IsRequired()
                        .HasConstraintName("FK__Movie__genre__2C3393D0");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("OData_Demo.Models.Actor", b =>
                {
                    b.Navigation("ActedIns");
                });

            modelBuilder.Entity("OData_Demo.Models.Genre", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("OData_Demo.Models.Movie", b =>
                {
                    b.Navigation("ActedIns");
                });
#pragma warning restore 612, 618
        }
    }
}