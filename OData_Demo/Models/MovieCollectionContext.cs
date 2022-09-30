using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OData_Demo.Models
{
    public partial class MovieCollectionContext : DbContext
    {
        public MovieCollectionContext()
        {
        }

        public MovieCollectionContext(DbContextOptions<MovieCollectionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActedIn> ActedIns { get; set; } = null!;
        public virtual DbSet<Actor> Actors { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<Movie> Movies { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActedIn>(entity =>
            {
                entity.HasKey(a => new {a.MovieId, a.ActorId});

                entity.ToTable("ActedIn");

                entity.Property(e => e.ActorId).HasColumnName("actor_id");

                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.HasOne(d => d.Actor)
                    .WithMany()
                    .HasForeignKey(d => d.ActorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ActedIn__actor_i__2A4B4B5E");

                entity.HasOne(d => d.Movie)
                    .WithMany()
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ActedIn__movie_i__2B3F6F97");
            });

            modelBuilder.Entity<Actor>(entity =>
            {
                entity.ToTable("Actor");

                entity.Property(e => e.ActorId)
                    .ValueGeneratedNever()
                    .HasColumnName("actor_id");

                entity.Property(e => e.ActorName)
                    .HasMaxLength(100)
                    .HasColumnName("actor_name");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.AverageMovieSalary)
                    .HasColumnType("money")
                    .HasColumnName("average_movie_salary");

                entity.Property(e => e.Nationality)
                    .HasMaxLength(50)
                    .HasColumnName("nationality");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genre");

                entity.Property(e => e.GenreId).HasColumnName("genre_id");

                entity.Property(e => e.GenreName)
                    .HasMaxLength(50)
                    .HasColumnName("genre_name");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("Movie");

                entity.HasIndex(e => e.ImageLink, "UQ__Movie__CF729F9A323CC2F7")
                    .IsUnique();

                entity.Property(e => e.MovieId)
                    .ValueGeneratedNever()
                    .HasColumnName("movie_id");

                entity.Property(e => e.AmountOfMoney)
                    .HasColumnType("money")
                    .HasColumnName("amount_of_money");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.Director)
                    .HasMaxLength(100)
                    .HasColumnName("director");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.GenreId).HasColumnName("genre");

                entity.Property(e => e.ImageLink)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.MovieName)
                    .HasMaxLength(100)
                    .HasColumnName("movie_name");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Movie__genre__2C3393D0");
            });

            modelBuilder.Entity<Movie>()
                .HasMany(m => m.ActedIns)
                .WithOne(a => a.Movie)
                .HasForeignKey(a => a.MovieId);

            modelBuilder.Entity<Actor>()
                .HasMany(m => m.ActedIns)
                .WithOne(a => a.Actor)
                .HasForeignKey(a => a.MovieId);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
