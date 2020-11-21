using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CEEHACK_ASPServer.Models
{
    public partial class CEEHackContext : DbContext
    {
        public CEEHackContext()
        {
        }

        public CEEHackContext(DbContextOptions<CEEHackContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DrugType> DrugTypes { get; set; }
        public virtual DbSet<GenderType> GenderTypes { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<PatientCase> PatientCases { get; set; }
        public virtual DbSet<Record> Records { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=Legion-Y530\\SQLExpress;Database=CEEHack;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DrugType>(entity =>
            {
                entity.ToTable("DrugType");

                entity.Property(e => e.DrugTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("drugTypeID");

                entity.Property(e => e.DrugTypeDescription)
                    .HasMaxLength(255)
                    .HasColumnName("drugTypeDescription");
            });

            modelBuilder.Entity<GenderType>(entity =>
            {
                entity.HasKey(e => e.GenderId)
                    .HasName("PK__GenderTy__306E2220137F1AD0");

                entity.ToTable("GenderType");

                entity.Property(e => e.GenderId)
                    .ValueGeneratedNever()
                    .HasColumnName("genderID");

                entity.Property(e => e.GenderDescription)
                    .HasMaxLength(255)
                    .HasColumnName("genderDescription");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patient");

                entity.Property(e => e.PatientId)
                    .ValueGeneratedNever()
                    .HasColumnName("patientID");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.IsHeight).HasColumnName("isHeight");

                entity.Property(e => e.IsWeight).HasColumnName("isWeight");

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.Surname).HasMaxLength(20);

                entity.HasOne(d => d.GenderNavigation)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.Gender)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Patient__gender__4D94879B");
            });

            modelBuilder.Entity<PatientCase>(entity =>
            {
                entity.HasKey(e => e.CaseId)
                    .HasName("PK__PatientC__956FA6C9AB51EC7D");

                entity.Property(e => e.CaseId)
                    .ValueGeneratedNever()
                    .HasColumnName("caseId");

                entity.Property(e => e.PatientId).HasColumnName("patientId");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.PatientCases)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__PatientCa__patie__5070F446");
            });

            modelBuilder.Entity<Record>(entity =>
            {
                entity.Property(e => e.RecordId)
                    .ValueGeneratedNever()
                    .HasColumnName("recordID");

                entity.Property(e => e.CaseId).HasColumnName("caseID");

                entity.Property(e => e.CorrectedValue).HasColumnName("correctedValue");

                entity.Property(e => e.DrugType).HasColumnName("drugType");

                entity.Property(e => e.PredictedValue).HasColumnName("predictedValue");

                entity.Property(e => e.RecordDate)
                    .HasColumnType("datetime")
                    .HasColumnName("recordDate");

                entity.HasOne(d => d.Case)
                    .WithMany(p => p.Records)
                    .HasForeignKey(d => d.CaseId)
                    .HasConstraintName("FK__Records__caseID__534D60F1");

                entity.HasOne(d => d.DrugTypeNavigation)
                    .WithMany(p => p.Records)
                    .HasForeignKey(d => d.DrugType)
                    .HasConstraintName("FK__Records__drugTyp__5441852A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
