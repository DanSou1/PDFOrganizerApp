using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PDFProcessor.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Dockey> Dockeys { get; set; }

    public virtual DbSet<Logprocess> Logprocesses { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=PruebaPDF;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dockey>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DOCKEY__3214EC07E5A71A3D");
        });

        modelBuilder.Entity<Logprocess>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LOGPROCE__3214EC07768168DF");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
