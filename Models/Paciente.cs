using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VirtualHosp.Models.Enums;

namespace VirtualHosp.Models
{
    public class Paciente : Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public PlanMedico Plan { get; set; }
        public List<Consulta> Consultas { get; set; }
        public string HistorialMedico { get; set; }
        public string AntecedentesMedicos { get; set; }
        public string Medicamentos { get; set; }
        public List<Estudio> Estudios { get; set; }
    }
}
