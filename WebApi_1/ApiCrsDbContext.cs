using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApi_1;

public partial class ApiCrsDbContext : DbContext
{
    public ApiCrsDbContext()
    {
    }

    public ApiCrsDbContext(DbContextOptions<ApiCrsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Course__3214EC27A69E9906");

            entity.ToTable("Course");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CrsDesc)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Crs_Desc");
            entity.Property(e => e.CrsName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Crs_Name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
