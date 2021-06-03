using System.Collections.Generic;

namespace VirtualHosp.Clases
{
    class Consultorio
    {
        public string Direccion { get; set; }

        public string Nombre { get; set; }

        public List<Medico> Medicos { get; set; }
    }
}
