using System;
using Microsoft.EntityFrameworkCore;

namespace Cwiczenia6.Models
{
    public class MainDbContext : DbContext
    {
        protected MainDbContext()
        {
        }

        public MainDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Prescription_Medicament> PrescriptionMedicaments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Patient>(p =>
            {
                p.HasKey(e => e.IdPatient);
                p.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                p.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                p.Property(e => e.BirthDate).IsRequired();

                p.HasData(
                    new Patient
                    {
                        IdPatient = 1, FirstName = "John", LastName = "Doe", BirthDate = DateTime.Parse("2000-01-01")
                    });
            });

            modelBuilder.Entity<Doctor>(p =>
            {
                p.HasKey(e => e.IdDoctor);
                p.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                p.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                p.Property(e => e.Email).IsRequired().HasMaxLength(100);

                p.HasData(
                    new Doctor
                    {
                        IdDoctor = 2, FirstName = "Way", LastName = "Doe", Email = "waudoe@gmail.com"
                    });
            });

            modelBuilder.Entity<Prescription>(p =>
            {
                p.HasKey(e => e.IdPrescription);
                p.Property(e => e.Date).IsRequired();
                p.Property(e => e.DueDate).IsRequired();
                p.HasOne(e => e.Patient).WithMany(d => d.Prescriptions).HasForeignKey(c => c.IdPatient);
                p.HasOne(e => e.Doctor).WithMany(v => v.Prescriptions).HasForeignKey(c => c.IdDoctor);


                p.HasData(
                    new Prescription
                    {
                        IdPrescription = 10, Date = DateTime.Parse("1950-01-01"), DueDate = DateTime.Now, IdDoctor = 2,
                        IdPatient = 1
                    });
            });

            modelBuilder.Entity<Medicament>(p =>
            {
                p.HasKey(e => e.IdMedicament);
                p.Property(e => e.Name).IsRequired().HasMaxLength(100);
                p.Property(e => e.Description).IsRequired().HasMaxLength(100);
                p.Property(e => e.Type).IsRequired().HasMaxLength(100);
                ;
                p.HasData(
                    new Medicament
                    {
                        IdMedicament = 110, Name = "Paracetamol", Description = "placebo", Type = "powerful"
                    });
                p.HasData(
                    new Medicament
                    {
                        IdMedicament = 220, Name = "Paracetabol", Description = "placebolasbolas", Type = "powerful"
                    });
            });

            modelBuilder.Entity<Prescription_Medicament>(p =>
            {
                p.HasKey(e => new
                {
                    e.IdMedicament,
                    e.IdPrescription
                });
                p.Property(e => e.Dose);
                p.Property(e => e.Details).IsRequired().HasMaxLength(100);
                p.HasOne(e => e.Prescription).WithMany(e => e.PrescriptionMedicaments)
                    .HasForeignKey(e => e.IdPrescription);
                p.HasOne(e => e.Medicament).WithMany(e => e.PrescriptionMedicaments)
                    .HasForeignKey(e => e.IdMedicament);


                p.HasData(
                    new Prescription_Medicament
                    {
                        Dose = 5, Details = "Apply every day", IdPrescription = 10, IdMedicament = 110
                    });

                p.HasData(
                    new Prescription_Medicament
                    {
                        Dose = 5, Details = "Apply every day", IdPrescription = 10, IdMedicament = 220
                    });
            });
        }
    }
}