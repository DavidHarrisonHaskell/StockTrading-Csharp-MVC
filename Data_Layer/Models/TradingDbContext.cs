using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Data_Layer;

public partial class TradingDbContext : DbContext
{
    public TradingDbContext()
    {
    }

    public TradingDbContext(DbContextOptions<TradingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<CurrencyPair> CurrencyPairs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SqlExpress;Database=TradingDB;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Currency>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Currency__3214EC072A2DCC6F");
        });

        modelBuilder.Entity<CurrencyPair>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Currency__3214EC070CAC50B4");

            entity.HasOne(d => d.BaseCurrency).WithMany(p => p.CurrencyPairBaseCurrencies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CurrencyP__BaseC__3A81B327");

            entity.HasOne(d => d.QuoteCurrency).WithMany(p => p.CurrencyPairQuoteCurrencies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CurrencyP__Quote__3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
