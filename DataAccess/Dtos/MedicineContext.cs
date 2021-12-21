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

        public virtual DbSet<AmountType> AmountTypes { get; set; }
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
                optionsBuilder.UseSqlServer("Data Source=93.176.82.48;Initial Catalog=Medicine;Persist Security Info=True;User ID=saadmin;Password=Kode1234!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Danish_Norwegian_CI_AS");

            modelBuilder.Entity<AmountType>(entity =>
            {
                entity.ToTable("AmountType");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Day>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Friday).HasColumnName("friday");

                entity.Property(e => e.Monday).HasColumnName("monday");

                entity.Property(e => e.Saturday).HasColumnName("saturday");

                entity.Property(e => e.Sunday).HasColumnName("sunday");

                entity.Property(e => e.Thursday).HasColumnName("thursday");

                entity.Property(e => e.Tuesday).HasColumnName("tuesday");

                entity.Property(e => e.Wednesday).HasColumnName("wednesday");
            });

            modelBuilder.Entity<Dosage>(entity =>
            {
                entity.ToTable("Dosage");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.AmountTypeId).HasColumnName("amount_type_id");

                entity.Property(e => e.DrugId).HasColumnName("drug_id");

                entity.Property(e => e.IntervalId).HasColumnName("interval_id");

                entity.HasOne(d => d.AmountType)
                    .WithMany(p => p.Dosages)
                    .HasForeignKey(d => d.AmountTypeId)
                    .HasConstraintName("FK__Dosage__amount_t__46E78A0C");

                entity.HasOne(d => d.Drug)
                    .WithMany(p => p.Dosages)
                    .HasForeignKey(d => d.DrugId)
                    .HasConstraintName("FK__Dosage__drug_id__47DBAE45");

                entity.HasOne(d => d.Interval)
                    .WithMany(p => p.Dosages)
                    .HasForeignKey(d => d.IntervalId)
                    .HasConstraintName("FK__Dosage__interval__48CFD27E");
            });

            modelBuilder.Entity<Drug>(entity =>
            {
                entity.ToTable("Drug");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Drugs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Drug__user_id__3D5E1FD2");
            });

            modelBuilder.Entity<Interval>(entity =>
            {
                entity.ToTable("Interval");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

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
                    .HasConstraintName("FK__Interval__days_i__440B1D61");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ExternalId).HasColumnName("external_id");

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
