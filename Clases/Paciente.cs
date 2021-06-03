using System.Collections.Generic;
using VirtualHosp.Enums;

namespace VirtualHosp.Clases
{
    class Paciente : Usuario
    {
        public PlanMedico Plan { get; set; }
        public List<Consulta> Consultas { get; set; }
        public string HistorialMedico { get; set; }        
        public string AntecedentesMedicos { get; set; }
        public string Medicamentos { get; set; }
        public List<Estudio> Estudios { get; set; }

    }
}
