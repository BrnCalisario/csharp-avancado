using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backend.Model;

public partial class RepoExemploContext : DbContext
{
    public RepoExemploContext()
    {
    }

    public RepoExemploContext(DbContextOptions<RepoExemploContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Mensagem> Mensagems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CTPC3627;Initial Catalog=repoExemplo;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Mensagem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Mensagem__3214EC271000AEF6");

            entity.ToTable("Mensagem");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Horario).HasColumnType("datetime");
            entity.Property(e => e.Texto).IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
