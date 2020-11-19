using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ExampleForKevin.Data
{
    public partial class ExampleKevinDbContext : DbContext
    {
        public ExampleKevinDbContext()
        {
        }

        public ExampleKevinDbContext(DbContextOptions<ExampleKevinDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<StockMarketStuff> StockMarketStuff { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ExampleKevinDb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockMarketStuff>(entity =>
            {
                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Note).HasMaxLength(100);

                entity.Property(e => e.TickerSymbol).HasMaxLength(10);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
