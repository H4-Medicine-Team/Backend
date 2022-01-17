using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataAccess.Dtos
{
    public partial class MedicineContext : DbContext
    {
        public MedicineContext()
        {
        }

        public MedicineContext(DbContextOptions<MedicineContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Day> Days { get; set; }
        public virtual DbSet<Dosage> Dosages { get; set; }
        public virtual DbSet<Drug> Drugs { get; set; }
        public virtual DbSet<Interval> Intervals { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=ZBC-E-RO-23300;Database=Medicine;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Danish_Norwegian_CI_AS");

            modelBuilder.Entity<Day>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");
            });

            modelBuilder.Entity<Dosage>(entity =>
            {
                entity.ToTable("Dosage");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.AmountType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("amountType");

                entity.Property(e => e.DrugId).HasColumnName("drug_id");

                entity.Property(e => e.IntervalId).HasColumnName("interval_id");

                entity.Property(e => e.UserId).HasColumnName("User_id");

                entity.HasOne(d => d.Drug)
                    .WithMany(p => p.Dosages)
                    .HasForeignKey(d => d.DrugId)
                    .HasConstraintName("FK__Dosage__drug_id__2D27B809");

                entity.HasOne(d => d.Interval)
                    .WithMany(p => p.Dosages)
                    .HasForeignKey(d => d.IntervalId)
                    .HasConstraintName("FK__Dosage__interval__2E1BDC42");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Dosages)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Dosage__User_id__2F10007B");
            });

            modelBuilder.Entity<Drug>(entity =>
            {
                entity.ToTable("Drug");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ExternalId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("external_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Interval>(entity =>
            {
                entity.ToTable("Interval");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ConsumptionTime).HasColumnName("consumption_time");

                entity.Property(e => e.DaysId).HasColumnName("days_id");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasColumnName("end_time");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasColumnName("start_time");

                entity.HasOne(d => d.Days)
                    .WithMany(p => p.Intervals)
                    .HasForeignKey(d => d.DaysId)
                    .HasConstraintName("FK__Interval__days_i__2A4B4B5E");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ExternalId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("external_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
