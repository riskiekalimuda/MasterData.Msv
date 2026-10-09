using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace MasterData.Msv.Models
{

    public partial class MasterDataMsvDbContext : DbContext
    {
        public MasterDataMsvDbContext()
        {
        }

        public MasterDataMsvDbContext(DbContextOptions<MasterDataMsvDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MstCustomer> MstCustomers { get; set; }    

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Name=ConnectionStrings:MasterDataMsvDBConnection");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MstCustomer>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("customer_pkey");

                entity.ToTable("mst_customer");

                entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
                entity.Property(e => e.Address).HasColumnName("address");
                entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("created_at");
                entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
                entity.Property(e => e.Telp)
                .HasMaxLength(30)
                .HasColumnName("telp");
            });

            this.OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
