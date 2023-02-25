#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CarRentAPI.Models;

namespace CarRentAPI.Data
{
    public partial class carrentalshopContext : DbContext
    {
        public carrentalshopContext()
        {
        }

        public carrentalshopContext(DbContextOptions<carrentalshopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bicycle> Bicycles { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Van> Vans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Bicycle>(entity =>
            {
                entity.HasKey(e => e.PlateNo)
                    .HasName("PRIMARY");

                entity.ToTable("bicycle");

                entity.Property(e => e.PlateNo).HasMaxLength(8);

                entity.Property(e => e.Ac)
                    .HasMaxLength(3)
                    .HasColumnName("AC");

                entity.Property(e => e.Airbags).HasMaxLength(3);

                entity.Property(e => e.Drive).HasMaxLength(5);

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.Transmission).HasMaxLength(6);

                entity.Property(e => e.Url)
                    .HasMaxLength(100)
                    .HasColumnName("URL");
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.PlateNo)
                    .HasName("PRIMARY");

                entity.ToTable("car");

                entity.Property(e => e.PlateNo).HasMaxLength(8);

                entity.Property(e => e.Ac)
                    .HasMaxLength(3)
                    .HasColumnName("AC");

                entity.Property(e => e.Airbags).HasMaxLength(3);

                entity.Property(e => e.Drive).HasMaxLength(5);

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.Transmission).HasMaxLength(6);

                entity.Property(e => e.Url)
                    .HasMaxLength(60)
                    .HasColumnName("URL");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("payments");

                entity.HasIndex(e => e.UserNic, "pay_CONST");

                entity.Property(e => e.PaymentId)
                    .HasMaxLength(5)
                    .HasColumnName("Payment_ID");

                entity.Property(e => e.Date).HasMaxLength(15);

                entity.Property(e => e.Status).HasMaxLength(10);

                entity.Property(e => e.UserNic).HasColumnName("User_NIC");

                entity.Property(e => e.VehicalId)
                    .HasMaxLength(8)
                    .HasColumnName("Vehical_ID");

                entity.HasOne(d => d.UserNicNavigation)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.UserNic)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("pay_CONST");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Nic)
                    .HasName("PRIMARY");

                entity.ToTable("users");

                entity.Property(e => e.Nic)
                    .ValueGeneratedNever()
                    .HasColumnName("NIC");

                entity.Property(e => e.Contact).HasMaxLength(10);

                entity.Property(e => e.Email).HasMaxLength(30);

                entity.Property(e => e.FirstName).HasMaxLength(20);

                entity.Property(e => e.LastName).HasMaxLength(20);
            });

            modelBuilder.Entity<Van>(entity =>
            {
                entity.HasKey(e => e.PlateNo)
                    .HasName("PRIMARY");

                entity.ToTable("van");

                entity.Property(e => e.PlateNo).HasMaxLength(8);

                entity.Property(e => e.Ac)
                    .HasMaxLength(3)
                    .HasColumnName("AC");

                entity.Property(e => e.Airbags).HasMaxLength(3);

                entity.Property(e => e.Drive).HasMaxLength(5);

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.Transmission).HasMaxLength(6);

                entity.Property(e => e.Url)
                    .HasMaxLength(60)
                    .HasColumnName("URL");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}