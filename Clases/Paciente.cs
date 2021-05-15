using System.Collections.Generic;
using VirtualHosp.Enums;

namespace VirtualHosp.Clases
{
    class Paciente : Usuario
    {
        public PlanMedico Plan { get; set; }
        public List<Turno> Turnos { get; set; }
        public string HistorialMedico { get; set; }
        public string HistorialMedico { get; set; }




    }
}
