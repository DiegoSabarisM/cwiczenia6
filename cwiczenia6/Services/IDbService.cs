using System.Collections.Generic;
using System.Threading.Tasks;
using Cwiczenia6.Models.DTO;

namespace Cwiczenia6.Services
{
    public interface IDbService
    {
        Task<IEnumerable<DoctorDTO>> GetDoctors();

        Task<bool> AddDoctor(DoctorDTO doctor);

        Task<bool> EditDoctor(int id, DoctorDTO doctorDto);

        Task<bool> DeleteDoctor(int id);

        Task<IEnumerable<PrescriptionDTO>> GetPrescription(PrescriptionDTO prescriptionDto);
    }
}