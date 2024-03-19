using System;
using System.Collections.Generic;
using DCI_HR_API.Models;
using Microsoft.EntityFrameworkCore;

namespace DCI_HR_API.Contexts;

public partial class DBSCM : DbContext
{
    public DBSCM()
    {
    }

    public DBSCM(DbContextOptions<DBSCM> options)
        : base(options)
    {
    }

    public virtual DbSet<DciPrivilege> DciPrivileges { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=192.168.226.86;Database=dbSCM;TrustServerCertificate=True;uid=sa;password=decjapan");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Thai_CI_AS");

        modelBuilder.Entity<DciPrivilege>(entity =>
        {
            entity.HasKey(e => new { e.PrivId, e.PrivModule, e.PrivRef, e.PrivAction });

            entity.ToTable("DCI_PRIVILEGE");

            entity.Property(e => e.PrivId)
                .ValueGeneratedOnAdd()
                .HasColumnName("PRIV_ID");
            entity.Property(e => e.PrivModule)
                .HasMaxLength(50)
                .HasColumnName("PRIV_MODULE");
            entity.Property(e => e.PrivRef)
                .HasMaxLength(20)
                .HasComment("BY DEPT  SECT  GRP USER")
                .HasColumnName("PRIV_REF");
            entity.Property(e => e.PrivAction)
                .HasMaxLength(50)
                .HasComment("CREATE INSERT EDIT DELETE MODIFY")
                .HasColumnName("PRIV_ACTION");
            entity.Property(e => e.PrivComponent)
                .HasMaxLength(50)
                .HasColumnName("PRIV_COMPONENT");
            entity.Property(e => e.PrivCreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("PRIV_CREATE_DATE");
            entity.Property(e => e.PrivStatus)
                .HasMaxLength(50)
                .HasDefaultValueSql("(N'T')")
                .HasColumnName("PRIV_STATUS");
            entity.Property(e => e.PrivUpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("PRIV_UPDATE_DATE");
            entity.Property(e => e.PrivVal)
                .HasMaxLength(50)
                .HasColumnName("PRIV_VAL");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
