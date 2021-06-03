using System;
using VirtualHosp.Enums;

namespace VirtualHosp.Clases

{
    abstract class Consulta
    {
        public DateTime Fecha { get; set; }        

        public Medico Medico { get; set; }

        public Estado Estado { get; set; }

        public double Coseguro { get; set; }

    }
}
