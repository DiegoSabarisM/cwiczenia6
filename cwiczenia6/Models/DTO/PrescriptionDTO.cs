using System;
using System.Collections.Generic;

namespace Cwiczenia6.Models.DTO
{
    public class PrescriptionDTO
    {
        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public int IdPatient { get; set; }
        public int IdDoctor { get; set; }

        public virtual IEnumerable<PrescriptionMedicamentsDTO> PrescriptionMedicaments { get; set; }
        public virtual IEnumerable<Medicament> Medicaments { get; set; }
    }
}