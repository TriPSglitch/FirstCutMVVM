using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FirstCutMVVM.Models;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=3553675Max");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresExtension("pg_catalog", "adminpack")
            .HasPostgresExtension("pgagent", "pgagent");

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Country_pk");

            entity.ToTable("Country");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnType("character varying");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("User_pk");

            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasColumnType("character varying");
            entity.Property(e => e.DateOfBirth).HasColumnType("character varying");
            entity.Property(e => e.Fio)
                .HasColumnType("character varying")
                .HasColumnName("fio");
            entity.Property(e => e.Idcountry).HasColumnName("IDCountry");
            entity.Property(e => e.PhoneNumber).HasColumnType("character varying");

            entity.HasOne(d => d.IdcountryNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Idcountry)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("User_Country_id_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
