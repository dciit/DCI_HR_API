using System;
using System.Collections.Generic;
using DCI_HR_API.Models;
using Microsoft.EntityFrameworkCore;

namespace DCI_HR_API.Contexts;

public partial class DBDCI : DbContext
{
    public DBDCI()
    {
    }

    public DBDCI(DbContextOptions<DBDCI> options)
        : base(options)
    {
    }

    public virtual DbSet<DciwebCounterVisitorLog> DciwebCounterVisitorLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=192.168.226.145;Database=dbDCI;TrustServerCertificate=True;uid=sa;password=decjapan");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Thai_CI_AS");

        modelBuilder.Entity<DciwebCounterVisitorLog>(entity =>
        {
            entity.ToTable("DCIWEB_COUNTER_VISITOR_LOG");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DtStamp)
                .HasColumnType("datetime")
                .HasColumnName("DT_Stamp");
            entity.Property(e => e.Ip)
                .HasMaxLength(50)
                .HasColumnName("IP");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
