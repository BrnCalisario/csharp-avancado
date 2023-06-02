using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DesafioRPA.Model;

public partial class RpaCsharpContext : DbContext
{
    public RpaCsharpContext()
    {
    }

    public RpaCsharpContext(DbContextOptions<RpaCsharpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<GitDirectory> GitDirectories { get; set; }

    public virtual DbSet<WatchDirectory> WatchDirectories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CT-C-0018A\\SQLEXPRESS;Initial Catalog=RPA_Csharp;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GitDirectory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GitDirec__3214EC27F7D92A0C");

            entity.ToTable("GitDirectory");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Dpath)
                .IsRequired()
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("DPath");
            entity.Property(e => e.LastPull).HasColumnType("datetime");
            entity.Property(e => e.ParentDirectory)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RegisterDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.ParentDirectoryNavigation).WithMany(p => p.GitDirectories)
                .HasForeignKey(d => d.ParentDirectory)
                .HasConstraintName("FK__GitDirect__Paren__3B75D760");
        });

        modelBuilder.Entity<WatchDirectory>(entity =>
        {
            entity.HasKey(e => e.Tag).HasName("PK__WatchDir__C451641221D567F9");

            entity.ToTable("WatchDirectory");

            entity.HasIndex(e => e.Dpath, "UQ__WatchDir__7DF0FDDB11AAEDBE").IsUnique();

            entity.Property(e => e.Tag)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Dpath)
                .IsRequired()
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("DPath");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
