using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HospitalManagement.DataAccess.Models
{
    public partial class SWD392_DBContext : DbContext
    {
        public SWD392_DBContext()
        {
        }

        public SWD392_DBContext(DbContextOptions<SWD392_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<Assignment> Assignments { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Disease> Diseases { get; set; } = null!;
        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; } = null!;
        public virtual DbSet<MedicalExaminationCard> MedicalExaminationCards { get; set; } = null!;
        public virtual DbSet<MedicalRecord> MedicalRecords { get; set; } = null!;
        public virtual DbSet<Medication> Medications { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;
        public virtual DbSet<PatientExamTest> PatientExamTests { get; set; } = null!;
        public virtual DbSet<Prescription> Prescriptions { get; set; } = null!;
        public virtual DbSet<PrescriptionDetail> PrescriptionDetails { get; set; } = null!;
        public virtual DbSet<Profile> Profiles { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<Sympton> Symptons { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=LAPTOP-F3VHIUES; database =SWD392_DB;uid=sa;pwd=123456; Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("Appointment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_Appointment_Department");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_Appointment_Patient");
            });

            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.ToTable("Assignment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.From)
                    .HasColumnType("datetime")
                    .HasColumnName("from");

                entity.Property(e => e.To)
                    .HasColumnType("datetime")
                    .HasColumnName("to");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_Assignment_Department");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_Assignment_User");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Disease>(entity =>
            {
                entity.ToTable("Disease");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cause)
                    .HasMaxLength(100)
                    .HasColumnName("cause");

                entity.Property(e => e.Complication)
                    .HasMaxLength(100)
                    .HasColumnName("complication");

                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Prevention)
                    .HasMaxLength(100)
                    .HasColumnName("prevention");

                entity.Property(e => e.Treatment)
                    .HasMaxLength(100)
                    .HasColumnName("treatment");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.MedicalExaminationCardId)
                    .HasName("PK__Invoice__FB43839E4DDDE9E8");

                entity.ToTable("Invoice");

                entity.Property(e => e.MedicalExaminationCardId)
                    .ValueGeneratedNever()
                    .HasColumnName("medical_examination_card_id");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("create_at");

                entity.Property(e => e.InsuranceInfo)
                    .HasColumnType("text")
                    .HasColumnName("insurance_info");

                entity.Property(e => e.PaymentMethod)
                    .HasColumnType("text")
                    .HasColumnName("payment_method");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TotalCost)
                    .HasColumnType("money")
                    .HasColumnName("total_cost");

                entity.HasOne(d => d.MedicalExaminationCard)
                    .WithOne(p => p.Invoice)
                    .HasForeignKey<Invoice>(d => d.MedicalExaminationCardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invoice_MedicalExaminationCard");
            });

            modelBuilder.Entity<InvoiceDetail>(entity =>
            {
                entity.ToTable("InvoiceDetail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MedicalExaminationCardId).HasColumnName("medical_examination_card_id");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.HasOne(d => d.MedicalExaminationCard)
                    .WithMany(p => p.InvoiceDetails)
                    .HasForeignKey(d => d.MedicalExaminationCardId)
                    .HasConstraintName("FK_InvoiceDetail_MedicalExaminationCard");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.InvoiceDetails)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK_InvoiceDetail_Service");
            });

            modelBuilder.Entity<MedicalExaminationCard>(entity =>
            {
                entity.ToTable("MedicalExaminationCard");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DiseaseId).HasColumnName("disease_id");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.MedicalRecordId).HasColumnName("medical_record_id");

                entity.Property(e => e.PrescriptionId).HasColumnName("prescription_id");

                entity.Property(e => e.SymptonId).HasColumnName("sympton_id");

                entity.HasOne(d => d.Disease)
                    .WithMany(p => p.MedicalExaminationCards)
                    .HasForeignKey(d => d.DiseaseId)
                    .HasConstraintName("FK_MedicalExaminationCard_Disease");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.MedicalExaminationCards)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_MedicalExaminationCard_User");

                entity.HasOne(d => d.MedicalRecord)
                    .WithMany(p => p.MedicalExaminationCards)
                    .HasForeignKey(d => d.MedicalRecordId)
                    .HasConstraintName("FK_MedicalExaminationCard_MedicalRecord");

                entity.HasOne(d => d.Prescription)
                    .WithMany(p => p.MedicalExaminationCards)
                    .HasForeignKey(d => d.PrescriptionId)
                    .HasConstraintName("FK_MedicalExaminationCard_Prescription");

                entity.HasOne(d => d.Sympton)
                    .WithMany(p => p.MedicalExaminationCards)
                    .HasForeignKey(d => d.SymptonId)
                    .HasConstraintName("FK_MedicalExaminationCard_Sympton");
            });

            modelBuilder.Entity<MedicalRecord>(entity =>
            {
                entity.ToTable("MedicalRecord");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FamilyHistory)
                    .HasColumnType("ntext")
                    .HasColumnName("family_history");

                entity.Property(e => e.MedicalHistory)
                    .HasColumnType("ntext")
                    .HasColumnName("medical_history");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.MedicalRecords)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_MedicalRecord_Patient");
            });

            modelBuilder.Entity<Medication>(entity =>
            {
                entity.ToTable("Medication");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Contraindication)
                    .HasMaxLength(100)
                    .HasColumnName("contraindication");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .HasColumnName("description");

                entity.Property(e => e.DosageForm)
                    .HasMaxLength(50)
                    .HasColumnName("dosage_form");

                entity.Property(e => e.Interaction)
                    .HasMaxLength(100)
                    .HasColumnName("interaction");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.SideEffect)
                    .HasMaxLength(100)
                    .HasColumnName("side_effect");

                entity.Property(e => e.StorageCondition)
                    .HasMaxLength(100)
                    .HasColumnName("storage_condition");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patient");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProfileId).HasColumnName("profile_id");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.ProfileId)
                    .HasConstraintName("FK_Patient_Profile");
            });

            modelBuilder.Entity<PatientExamTest>(entity =>
            {
                entity.ToTable("PatientExamTest");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.MedicalExaminationCardId).HasColumnName("medical_examination_card_id");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.HasOne(d => d.MedicalExaminationCard)
                    .WithMany(p => p.PatientExamTests)
                    .HasForeignKey(d => d.MedicalExaminationCardId)
                    .HasConstraintName("FK_PatientExamTest_MedicalExaminationCard");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.PatientExamTests)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK_PatientExamTest_Service");
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.ToTable("Prescription");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_Prescription_User");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_Prescription_Patient");
            });

            modelBuilder.Entity<PrescriptionDetail>(entity =>
            {
                entity.ToTable("PrescriptionDetail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MedicationFrequency)
                    .HasMaxLength(50)
                    .HasColumnName("medication_frequency");

                entity.Property(e => e.MedicationId).HasColumnName("medication_id");

                entity.Property(e => e.MedicationQuantity)
                    .HasMaxLength(50)
                    .HasColumnName("medication_quantity");

                entity.Property(e => e.PrescriptionId).HasColumnName("prescription_id");

                entity.HasOne(d => d.Medication)
                    .WithMany(p => p.PrescriptionDetails)
                    .HasForeignKey(d => d.MedicationId)
                    .HasConstraintName("FK_PrescriptionDetail_Medication");

                entity.HasOne(d => d.Prescription)
                    .WithMany(p => p.PrescriptionDetails)
                    .HasForeignKey(d => d.PrescriptionId)
                    .HasConstraintName("FK_PrescriptionDetail_Prescription");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.ToTable("Profile");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .HasColumnName("address");

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("dob");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.IdNo)
                    .HasMaxLength(50)
                    .HasColumnName("id_no");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");
            });

            modelBuilder.Entity<Sympton>(entity =>
            {
                entity.ToTable("Sympton");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnType("ntext")
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Degree)
                    .HasMaxLength(50)
                    .HasColumnName("degree");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.ProfileId).HasColumnName("profile_id");

                entity.Property(e => e.Role).HasColumnName("role");

                entity.Property(e => e.Specialization)
                    .HasMaxLength(50)
                    .HasColumnName("specialization");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .HasColumnName("user_name");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.ProfileId)
                    .HasConstraintName("FK_User_Profile");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
