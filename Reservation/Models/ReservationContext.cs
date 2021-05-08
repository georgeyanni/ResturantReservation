using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Reservation.Helper;
using Reservation.Dtos;

#nullable disable

namespace Reservation.Models
{
    public partial class ReservationContext : DbContext
    {
        public ReservationContext()
        {
        }

        public ReservationContext(DbContextOptions<ReservationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FoodList> FoodLists { get; set; }
        public virtual DbSet<ReservationTable> ReservationTables { get; set; }
        public virtual DbSet<User> Users { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<FoodList>(entity =>
            {
                entity.ToTable("FoodList");

                entity.Property(e => e.FoodType).HasMaxLength(50);
            });

            modelBuilder.Entity<ReservationTable>(entity =>
            {
                entity.ToTable("ReservationTable");

                entity.Property(e => e.ReservationDate).HasColumnType("date");

                entity.HasOne(d => d.FoodType)
                    .WithMany(p => p.ReservationTables)
                    .HasForeignKey(d => d.FoodTypeId)
                    .HasConstraintName("FK_ReservationTable_FoodTypes");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ReservationTables)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ReservationTable_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(50);
            });
            modelBuilder.Seed();
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<Reservation.Dtos.ReservationDto> ReservationDto { get; set; }
    }
}
