using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MovieApp.model;

public partial class MovieDbContext : DbContext
{
    public MovieDbContext(DbContextOptions<MovieDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<Usermaster> Usermasters { get; set; }

    public virtual DbSet<Usertype> Usertypes { get; set; }

    public virtual DbSet<Watchlist> Watchlists { get; set; }

    public virtual DbSet<WatchlistItems> Watchlistitems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GenreID).HasName("Genre_pkey");

            entity.ToTable("Genre");

            entity.Property(e => e.GenreID)
                .ValueGeneratedNever()
                .HasColumnName("GenreID");
            entity.Property(e => e.GenreName)
                .HasMaxLength(20)
                .HasColumnName("GenreName");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.MovieID).HasName("Movie_pkey");

            entity.ToTable("Movie");

            entity.Property(e => e.MovieID)
                .ValueGeneratedNever()
                .HasColumnName("MovieID");
            entity.Property(e => e.Duration).HasColumnName("Duration");
            entity.Property(e => e.Genre)
                .HasMaxLength(20)
                .HasColumnName("Genre");
            entity.Property(e => e.Language)
                .HasMaxLength(20)
                .HasColumnName("Language");
            entity.Property(e => e.Overview)
                .HasMaxLength(1024)
                .HasColumnName("Overview");
            entity.Property(e => e.Posterpath)
                .HasMaxLength(100)
                .HasColumnName("Posterpath");
            entity.Property(e => e.Rating)
                .HasPrecision(2, 1)
                .HasColumnName("Rating");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("Title");
        });

        modelBuilder.Entity<Usermaster>(entity =>
        {
            entity.HasKey(e => e.UserID).HasName("Usermaster_pkey");

            entity.ToTable("Usermaster");

            entity.Property(e => e.UserID)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.Firstname)
                .HasMaxLength(20)
                .HasColumnName("Firstname");
            entity.Property(e => e.Gender)
                .HasMaxLength(6)
                .HasColumnName("Gender");
            entity.Property(e => e.Lastname)
                .HasMaxLength(20)
                .HasColumnName("Lastname");
            entity.Property(e => e.Password)
                .HasMaxLength(40)
                .HasColumnName("Password");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .HasColumnName("Username");
            entity.Property(e => e.UserTypeName)
                .HasMaxLength(20)
                .HasColumnName("UserTypeName");
        });

        modelBuilder.Entity<Usertype>(entity =>
        {
            entity.HasKey(e => e.UserTypeID).HasName("UserType_pkey");

            entity.ToTable("Usertype");

            entity.Property(e => e.UserTypeID)
                .ValueGeneratedNever()
                .HasColumnName("UserTypeID");
            entity.Property(e => e.UserTypeName)
                .HasMaxLength(20)
                .HasColumnName("UserTypeName");
        });

        modelBuilder.Entity<Watchlist>(entity =>
        {
            entity.HasKey(e => e.WatchlistID).HasName("Watchlist_pkey");

            entity.ToTable("Watchlist");

            entity.Property(e => e.WatchlistID)
                .HasMaxLength(36)
                .HasColumnName("WatchlistID");
            entity.Property(e => e.DateCreated)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("DateCreated");
            entity.Property(e => e.UserID).HasColumnName("UserID");
        });

        modelBuilder.Entity<WatchlistItems>(entity =>
        {
            entity.HasKey(e => e.WatchlistItemID).HasName("WatchlistItems_pkey");

            entity.ToTable("\"WatchlistItems\"");

            entity.Property(e => e.WatchlistItemID)
                .ValueGeneratedNever()
                .HasColumnName("WatchlistItemID");
            entity.Property(e => e.MovieID).HasColumnName("MovieID");
            entity.Property(e => e.WatchlistID)
                .HasMaxLength(36)
                .HasColumnName("WatchlistID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
