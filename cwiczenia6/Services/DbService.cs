using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cwiczenia6.Models;
using Cwiczenia6.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace Cwiczenia6.Services
{
    public class DbService : IDbService
    {
        private readonly MainDbContext _context;

        public DbService(MainDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DoctorDTO>> GetDoctors()
        {
            return await _context.Doctors
                .Select(e => new DoctorDTO
                {
                    IdDoctor = e.IdDoctor,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email
                }).ToListAsync();
        }

        public async Task<bool> AddDoctor(DoctorDTO doctor)
        {
            var addDoctor = new Doctor
            {
                IdDoctor = doctor.IdDoctor,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Email = doctor.Email
            };
            _context.Add(addDoctor);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditDoctor(int id, DoctorDTO doctorDto)
        {
            var editDoctor = await _context.Doctors.Where(e => e.IdDoctor == id).FirstOrDefaultAsync();

            editDoctor.FirstName = doctorDto.FirstName;
            editDoctor.LastName = doctorDto.LastName;
            editDoctor.Email = doctorDto.Email;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDoctor(int id)
        {
            var deleteDoctor = await _context.Doctors.Where(e => e.IdDoctor == id).FirstOrDefaultAsync();
            _context.Remove(deleteDoctor);
            _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<PrescriptionDTO>> GetPrescription(PrescriptionDTO prescriptionDto)
        {
            return await _context.Prescriptions
                .Include(e => e.PrescriptionMedicaments)
                .Where(e => e.IdDoctor == prescriptionDto.IdDoctor && e.IdPatient == prescriptionDto.IdPatient)
                .Select(e => new PrescriptionDTO
                {
                    IdDoctor = e.IdDoctor,
                    IdPatient = e.IdPatient,
                    IdPrescription = e.IdPrescription,
                    PrescriptionMedicaments = e.PrescriptionMedicaments.Select(p => new PrescriptionMedicamentsDTO
                    {
                        IdPrescription = p.IdPrescription,
                        IdMedicament = p.IdMedicament
                    }).ToList()
                }).ToListAsync();
        }
    }
}