using System.Threading.Tasks;
using Cwiczenia6.Models.DTO;
using Cwiczenia6.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenia6.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDbService _service;

        public DoctorsController(IDbService dbService)
        {
            _service = dbService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            var doctors = await _service.GetDoctors();
            return Ok(doctors);
        }

        [HttpPut]
        public async Task<IActionResult> AddDoctor([FromBody] DoctorDTO doctorDto)
        {
            if (_service.AddDoctor(doctorDto).Result) return Ok(doctorDto);

            return NotFound("Did not make any changes");
        }


        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> EditDoctor([FromBody] DoctorDTO doctorDto, int id)
        {
            if (_service.EditDoctor(id, doctorDto).Result) return Ok(doctorDto);

            return NotFound("Oops! Something went wrong. Are you cursed? ");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> EditDoctor(int id)
        {
            if (_service.DeleteDoctor(id).Result) return Ok("Ok, Deleted");

            return NotFound("Oops! Something went wrong. Are you cursed? ");
        }

        [HttpGet]
        [Route("prescriptions")]
        public async Task<IActionResult> GetPrescriptions([FromBody] PrescriptionDTO prescriptionDto)
        {
            var prescriptions = await _service.GetPrescription(prescriptionDto);
            return Ok(prescriptions);
        }
    }
}